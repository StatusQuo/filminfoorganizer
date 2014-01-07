Public Class Dialog_Export_Wizard
    Dim aktPage As Panel

    Private Sub Dialog_Sortieren_Wizard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadioButton4.Text = "Alle Filme in der Liste (" & MainForm.Movie_GridView.RowCount & ")"
        aktPage = Page_1
    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        Label1.ForeColor = SystemColors.ControlText
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = SystemColors.GrayText
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Select_Auswahl.CheckedChanged
        Button_Auswahlübernehmen.Enabled = Select_Auswahl.Checked
        Select_Auswahl.Text = "Nur ausgewählte Filme (" & MainForm.Movie_GridView.SelectedRows.Count & ")"
    End Sub

    Private Sub Button_Auswahlübernehmen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Auswahlübernehmen.Click
        Select_Auswahl.Text = "Nur ausgewählte Filme (" & MainForm.Movie_GridView.SelectedRows.Count & ")"
    End Sub

    Private Sub Vorwärts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Vorwärts.Click
        If aktPage Is Page_1 Then
            Page2.BringToFront()
        End If
    End Sub

    Private Sub ComboBox1_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDown

    End Sub
End Class