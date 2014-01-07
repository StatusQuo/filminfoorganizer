Public Enum LoggerWriteLiType
    Fehler
    Fertig
    Prozess
End Enum
Public Class Logger
    Public Shared Sub Push(ByVal Type As LoggerWriteLiType, ByVal Title As String, ByVal cTitle As String, ByVal Text As String)
        RichTextBox1.Invoke(New LogDelegate(AddressOf LogChange), New Object() {Type, Title, cTitle, Text})
    End Sub
    Shared Property RichTextBox1 As RichTextBox

    Public Sub Write(ByVal Type As LoggerWriteLiType, ByVal Title As String, ByVal cTitle As String, ByVal Text As String)
        RichTextBox1.Select(RichTextBox1.Text.Length, 0)
        RichTextBox1.SelectionColor = SystemColors.MenuText
        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
        RichTextBox1.SelectedText = vbCrLf & "[" & addnull(Now.Hour) & ":" & addnull(Now.Minute) & ":" & addnull(Now.Second) & "]"
        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
        RichTextBox1.SelectionColor = Color.Red
        RichTextBox1.SelectedText = cTitle
        RichTextBox1.SelectionColor = SystemColors.MenuText
        RichTextBox1.SelectedText = " " & Title
        WriteText(Text)
    End Sub
    Public Sub WriteText(ByVal Text As String)
        RichTextBox1.Select(RichTextBox1.Text.Length, 0)
        RichTextBox1.SelectionColor = SystemColors.GrayText
        RichTextBox1.SelectedText = vbCrLf & Text
    End Sub
    Shared Function addnull(ByVal i As Integer) As String
        If i < 10 Then
            Return "0" & i
        Else
            Return CStr(i)
        End If
    End Function
    Delegate Sub LogDelegate(ByVal Type As LoggerWriteLiType, ByVal Title As String, ByVal cTitle As String, ByVal Text As String)

    Public Shared Sub LogChange(ByVal Type As LoggerWriteLiType, ByVal Title As String, ByVal cTitle As String, ByVal Text As String)
        RichTextBox1.Select(RichTextBox1.Text.Length, 0)
        RichTextBox1.SelectionColor = SystemColors.MenuText
        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
        RichTextBox1.SelectedText = vbCrLf & "[" & addnull(Now.Hour) & ":" & addnull(Now.Minute) & ":" & addnull(Now.Second) & "]"
        RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Regular)
        RichTextBox1.SelectionColor = Color.Red
        RichTextBox1.SelectedText = cTitle
        RichTextBox1.SelectionColor = SystemColors.MenuText
        RichTextBox1.SelectedText = " " & Title
        'WriteText(Text)
    End Sub
End Class
