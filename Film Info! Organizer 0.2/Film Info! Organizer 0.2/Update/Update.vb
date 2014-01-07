Public Class Updater
    Public Shared Dest As String = IO.Path.Combine(Einstellungen.ChachePath, "updater.exe")
    Public Shared Source As String = ""
    Private Shared Function toDbl(ByVal s As String) As Double
        Dim r As Double = -1
        Try
            r = CDbl(s)
        Catch ex As Exception

        End Try
        Return r
    End Function
    'Public Shared Sub Check_For_Updates(ByVal showmsg As Boolean)
    '    Dim r As Boolean = False
    '    Dim neuer As Boolean = False
    '    Dim nvs As String = ""
    '    Dim log As String = ""

    '    Dim maj As Double
    '    Dim min As Double
    '    Dim bui As Double
    '    Dim rev As Double


    '    'Dim i, j As Integer    ' Hilfsvariablen
    '    'Dim xml As Xml.XmlDocument
    '    'Xml = MyFunctions.HttploadXML("http://fio.square7.ch/legend/update/update.xml")
    '    ' '' xml = MyFunctions.HttploadXML("http://dl.dropbox.com/u/6880006/update.xml")
    '    'If IsNothing(xml) Then
    '    '    MsgBox("Keine Verbindung")
    '    '    Exit Sub
    '    'End If
    '    ''xml.Save("D:\test.xml")
    '    'Dim xpath As String

    '    'maj = toDbl(If(Xml.SelectNodes("//Version_Major").Count > 0, Xml.SelectSingleNode("//Version_Major").InnerText, ""))
    '    'min = toDbl(If(xml.SelectNodes("//Version_Minor").Count > 0, xml.SelectSingleNode("//Version_Minor").InnerText, ""))
    '    'bui = toDbl(If(xml.SelectNodes("//Version_Build").Count > 0, xml.SelectSingleNode("//Version_Build").InnerText, ""))
    '    'rev = toDbl(If(xml.SelectNodes("//Version_Revision").Count > 0, xml.SelectSingleNode("//Version_Revision").InnerText, ""))
    '    'If maj > My.Application.Info.Version.Major Then
    '    '    neuer = True
    '    'End If
    '    'If min > My.Application.Info.Version.Minor Then
    '    '    neuer = True
    '    'End If
    '    'If bui > My.Application.Info.Version.Build Then
    '    '    neuer = True
    '    'End If
    '    'If rev > My.Application.Info.Version.Revision Then
    '    '    neuer = True
    '    'End If
    '    'Source = If(xml.SelectNodes("//Source").Count > 0, xml.SelectSingleNode("//Source").InnerText, "")
    '    'log = If(xml.SelectNodes("//Changes").Count > 0, xml.SelectSingleNode("//Changes").InnerText, "")
    '    Dim XMLReader As Xml.XmlReader _
    '         = New Xml.XmlTextReader("http://fio.square7.ch/legend/update/update.xml")
    '    With XMLReader

    '        '.MoveToAttribute("Wert")
    '        'Label1.Text = .Name & "|" & .Value
    '        'Try
    '        .ReadToFollowing("Version")
    '        .MoveToAttribute("Version_Major")
    '        nvs = .Value

    '        If toDbl(.Value) > My.Application.Info.Version.Major Then
    '            neuer = True
    '        End If
    '        .MoveToAttribute("Version_Minor")
    '        nvs &= "." & .Value

    '        If toDbl(.Value) > My.Application.Info.Version.Minor Then
    '            neuer = True
    '        End If
    '        .MoveToAttribute("Version_Build")
    '        nvs &= "." & .Value
    '        If toDbl(.Value) > My.Application.Info.Version.Build Then
    '            neuer = True
    '        End If
    '        .MoveToAttribute("Version_Revision")
    '        nvs &= "." & .Value
    '        If toDbl(.Value) > My.Application.Info.Version.Revision Then
    '            neuer = True
    '        End If

    '        .MoveToAttribute("Version_zusatz")
    '        If .Value <> "" Then
    '            nvs &= " " & .Value

    '            'nvs &= .Value
    '        Else
    '            '.MoveToAttribute("Version_Revision")
    '            'nvs &= " r" & .Value
    '            '.MoveToAttribute("Version_Build")
    '            'nvs &= " Build:" & .Value
    '        End If
    '        .ReadToFollowing("Source")

    '        Source = .ReadInnerXml
    '        .ReadToFollowing("Changes")

    '        log = .ReadInnerXml


    '        '    'Catch ex As Exception
    '        '    '    'If showmessage = True Then
    '        '    '    MsgBox("Kein Verbindungsaufbau möglich", MsgBoxStyle.Critical, "Update")
    '        '    '    'End If

    '        '    '    'GoTo ende
    '        '    'End Try



    '        .Close()  ' XMLTextReader schließen 

    '    End With


    '    If neuer = True Then
    '        Dialog_Update.newVersion.Text = "Neue Version: " & nvs
    '        Dialog_Update.TextBox1.Text = log
    '        Dialog_Update.Location = New Point(CInt((Screen.PrimaryScreen.WorkingArea.Width / 2) - (Dialog_Update.Width / 2)), CInt((Screen.PrimaryScreen.WorkingArea.Height / 2) - (560 / 2)))
    '        Dialog_Update.Show()
    '    Else

    '        If showmsg = True Then
    '            Dialog_Update.newVersion.Text = ""
    '            Dialog_Update.OK_Button.Enabled = False
    '            Dialog_Update.newText.Text = "Sie besitzen bereits die aktuellste Version."
    '            Dialog_Update.Location = New Point(CInt((Screen.PrimaryScreen.WorkingArea.Width / 2) - (Dialog_Update.Width / 2)), CInt((Screen.PrimaryScreen.WorkingArea.Height / 2) - (560 / 2)))
    '            Dialog_Update.Show()
    '        End If

    '    End If

    '    '    If MsgBox("Es ist eine neue Version " & nvs & " verfügbar. Möchten Sie die Downloadseite öffnen?", MsgBoxStyle.YesNo, "Update") = MsgBoxResult.Yes Then
    '    '        Process.Start("http://www.mce-community.de/forum/index.php?showtopic=38085")
    '    '    End If
    '    '    'lastupdate = Date.Today
    '    'Else
    '    '    'If showmessage = True Then
    '    '    MsgBox("Sie besitzen bereits die aktuellste Version.", MsgBoxStyle.Information, "Update")
    '    '    'End If

    '    '    'lastupdate = Date.Today

    '    'End If
    '    'Return r

    'End Sub
End Class
