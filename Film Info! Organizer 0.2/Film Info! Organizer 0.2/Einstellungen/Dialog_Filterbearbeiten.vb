Imports System.Windows.Forms

Public Class Dialog_Filterbearbeiten

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub DataGridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        If DataGridView1.SelectedRows.Count = 0 Then
            GroupBox1.Enabled = False

        Else
            GroupBox1.Enabled = True
            TextBox1.Text = CStr(DataGridView1.SelectedRows(0).Cells(1).Value)
            TextBox2.Text = CStr(DataGridView1.SelectedRows(0).Cells(2).Value).Replace(";", vbCrLf)
            TextBox3.Text = CStr(DataGridView1.SelectedRows(0).Cells(3).Value)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If DataGridView1.SelectedRows.Count = 1 Then
            DataGridView1.SelectedRows(0).Cells(1).Value = TextBox1.Text

        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If DataGridView1.SelectedRows.Count = 1 Then
            DataGridView1.SelectedRows(0).Cells(2).Value = TextBox2.Text.Replace(vbCrLf, ";")
        End If
    End Sub


    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        If DataGridView1.SelectedRows.Count = 1 Then
            DataGridView1.SelectedRows(0).Cells(3).Value = TextBox3.Text.Replace(vbCrLf, ";")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.Rows.Add("", "", "", "")
        DataGridView1.ClearSelection()
        DataGridView1.Rows(DataGridView1.Rows.Count - 1).Selected = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
        End If
    End Sub

    Private Sub LinkLabel21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel21.Click
        Dim list As New List(Of Einstellungen.gFilter)
        list = Einstellungen.GenreFilter.Load_standard
        DataGridView1.Rows.Clear()
        If List.Count > 0 Then

            Dim rc(List.Count - 1) As DataGridViewRow
            For x As Integer = 0 To List.Count - 1
                Dim r As New DataGridViewRow

                r.CreateCells(DataGridView1)
                r.Cells(0).Value = list(x).id
                r.Cells(1).Value = list(x).Name
                r.Cells(2).Value = list(x).Filter
                r.Cells(3).Value = list(x).altName
                rc(x) = r

            Next
            DataGridView1.Rows.AddRange(rc)
        End If
    End Sub
End Class
