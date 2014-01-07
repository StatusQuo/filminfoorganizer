Imports Microsoft.WindowsAPICodePack
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System.Net
Public Class Messages
    Shared IsDialogSupported As Boolean = TaskDialog.IsPlatformSupported

    Shared Function Box(ByVal text As String, ByVal msgBoxStyle As MsgBoxStyle, ByVal Title As String) As MsgBoxResult
        If IsDialogSupported = True Then

            Dim tdError As TaskDialog = New TaskDialog()
            'tdError.StandardButtons = Microsoft.WindowsAPICodePack.Dialogs.TaskDialogStandardButtons.

            tdError.Text = text
            tdError.InstructionText = Title
            If msgBoxStyle = Microsoft.VisualBasic.MsgBoxStyle.Critical Then
                tdError.Icon = TaskDialogStandardIcon.Error
            End If
            tdError.Show()

        Else
            Return MsgBox(text, msgBoxStyle, Title)
        End If
    End Function

End Class