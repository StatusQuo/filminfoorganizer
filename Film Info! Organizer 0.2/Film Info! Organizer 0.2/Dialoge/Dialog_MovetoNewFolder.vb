Imports System.Windows.Forms

Public Class Dialog_MovetoNewFolder

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If TreeViewVista1.Nodes.Count > 0 Then
            For x As Integer = 0 To TreeViewVista1.Nodes.Count - 1
                TreeViewVista1.Nodes(x).Checked = CheckBox1.Checked
            Next
        End If
    End Sub

End Class
