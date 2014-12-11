

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            Dim enc As New System.Text.UTF8Encoding

            ' XmlTextWriter-Objekt für unsere Ausgabedatei erzeugen: 
            Dim XMLobj As Xml.XmlTextWriter _
              = New Xml.XmlTextWriter(TextBoxDest.Text & "\update.xml", enc)

            With XMLobj
                .Formatting = Xml.Formatting.Indented
                .Indentation = 4
                .WriteStartDocument()
                .WriteStartElement("Update")
                .WriteStartElement("Version") ' <Person 
                .WriteAttributeString("Version_Major", TextBox1.Text)
                .WriteAttributeString("Version_Minor", TextBox2.Text)
                .WriteAttributeString("Version_Build", TextBox3.Text)
                .WriteAttributeString("Version_Revision", TextBox4.Text)
                .WriteEndElement()
                .WriteStartElement("Source") ' <Person 
                .WriteValue(TextBox5.Text)
                .WriteEndElement()
                Dim lines() As String = TextBox6.Text.Split(vbCrLf)
                If lines.Length > 0 Then
                    For x As Integer = 0 To lines.Length - 1
                        If Not lines(x) = "" Then
                            .WriteStartElement("Change") ' <Person 
                            .WriteValue(lines(x))
                            '.WriteValue(TextBox6.Text)
                            .WriteEndElement()
                        End If

                    Next
                End If
                .WriteEndElement()
                ' ... und schließen das XML-Dokument (und die Datei) 
                .Close() ' Document 

            End With

        Catch ex As Exception
            If MsgBox("Es ist ein Fehler beim Speichern der mymovies.xml aufgetreten." & vbCrLf & vbCrLf, MsgBoxStyle.Exclamation, "Fehler") = MsgBoxResult.Ok Then
                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
            End If

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged, TextBox3.TextChanged, TextBox2.TextChanged, TextBox1.TextChanged
        TextBox5.Text = "http://www.downloadcounter.de/counter.pl?user=StatusQuo&amp;file=http://dl.dropbox.com/u/6880006/Update/Film%20Info%21%20Updater%20" & TextBox1.Text & "." & TextBox2.Text & "." & TextBox3.Text & "." & TextBox4.Text & ".exe"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim path As String
        path = TextBoxSource.Text & "\Resources\Ver.txt"
        Dim t As String = TextBox1.Text & "." & TextBox2.Text & "." & TextBox3.Text & "." & TextBox4.Text
        My.Computer.FileSystem.WriteAllText(path, t, False)
        Zipper.Zip(TextBoxSource.Text)


        Dim sheet As New Process
        sheet.StartInfo.FileName = "C:\Windows\Microsoft.NET\Framework\v3.5\MSBuild.exe"
        sheet.StartInfo.Arguments = "/property:Configuration=Debug " & """" & TextBoxSource.Text & "\Film Info! Updater.vbproj"""
        sheet.StartInfo.UseShellExecute = False
        sheet.StartInfo.RedirectStandardOutput = True
        'sheet.StartInfo.CreateNoWindow = True
        sheet.Start()
        sheet.WaitForExit()
        sheet.Dispose()
        Dim s As String = TextBoxSource.Text & "\bin\Debug\Film Info! Updater.exe"
        Dim d As String = TextBoxDest.Text & "\Film Info! Updater " & TextBox1.Text & "." & TextBox2.Text & "." & TextBox3.Text & "." & TextBox4.Text & ".exe"

        'Process.Start("D:\Eigene Dokumente\Visual Studio 2010\Projects\Film Info! Updater\Film Info! Updater\bin\Debug")
        If IO.File.Exists(s) Then
            If IO.File.Exists(d) Then
                IO.File.Delete(d)
            End If
            IO.File.Move(s, d)
        End If
        MsgBox("Updatefile erfolgreich erstellt")
    End Sub
    Private Shared Function toDbl(ByVal s As String) As Double
        Dim r As Double = -1
        Try
            r = CDbl(s)
        Catch ex As Exception

        End Try
        Return r
    End Function
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AdminRights.hasRight()
        If IO.File.Exists(TextBoxDest.Text & "\update.xml") Then


            Dim maj As Double
            Dim min As Double
            Dim bui As Double
            Dim rev As Double

            Dim xml As New Xml.XmlDocument
            xml.Load(TextBoxDest.Text & "\update.xml")
            'xml = MyFunctions.HttploadXML("http://dl.dropbox.com/u/6880006/Update/update.xml")
            'xml = MyFunctions.HttploadXML("http://fio.square7.ch/legend/update/update.xml")
            Dim nxml As Xml.XmlNode
            If Not xml Is Nothing Then

                nxml = xml.SelectSingleNode("//Version")

                maj = toDbl(nxml.Attributes("Version_Major").Value)
                min = toDbl(nxml.Attributes("Version_Minor").Value)
                bui = toDbl(nxml.Attributes("Version_Build").Value)
                rev = toDbl(nxml.Attributes("Version_Revision").Value)

                Dim changes As String = ""
                Dim j As Integer = xml.SelectNodes("//Change").Count
                If j > 0 Then
                    For x As Integer = 0 To j - 1
                        If changes = "" Then
                            changes = xml.SelectNodes("//Change").Item(x).InnerText
                        Else
                            changes &= vbCrLf & xml.SelectNodes("//Change").Item(x).InnerText
                        End If
                    Next
                End If
                TextBox1.Text = maj
                TextBox2.Text = min
                TextBox3.Text = bui
                TextBox4.Text = rev
                TextBox6.Text = changes

                'Changes = If(xml.SelectNodes("//Change").Count > 0, xml.SelectSingleNode("//Change").InnerText, "")
            Else
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Process.Start(TextBoxDest.Text)
        Catch ex As Exception

        End Try
    End Sub


End Class
