Imports System.Windows.Forms

Public Class Dialog1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ListViewVista1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewVista1.SelectedIndexChanged
        If ListViewVista1.SelectedItems.Count = 0 Then
            Panel_nothigselected.Visible = True
        Else
            Panel_nothigselected.Visible = False
        End If
    End Sub
End Class
