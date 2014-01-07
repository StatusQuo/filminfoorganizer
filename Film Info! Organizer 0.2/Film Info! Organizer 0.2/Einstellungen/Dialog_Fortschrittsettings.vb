Public Class Bewertungsmuster

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



    Private Sub LinkLabel21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel21.Click
        With Me
            .Num_Titel.Value = 1
            .Num_Originaltitel.Value = 1
            .Num_IMDB_ID.Value = 1
            .Num_Darsteller.Value = 1
            .Num_Regisseur.Value = 1
            .Num_Autoren.Value = 1
            .Num_Studio.Value = 1
            .Num_Produktionsjahr.Value = 1
            .Num_Produktionsland.Value = 1
            .Num_Genre.Value = 1
            .Num_FSK.Value = 1
            .Num_Bewertung.Value = 1
            .Num_Spieldauer.Value = 1
            '.Num_Kurzbeschreibung.Value = Config_Fortschritt.Kurzbeschreibung
            .Num_Inhalt.Value = 1
            .Num_Sort.Value = 1
            .Num_VideoAuflösung.Value = 1
            .Num_VideoSeitenverhältnis.Value = 1
            .Num_VideoBildwiederholungsrate.Value = 1
            .Num_VideoCodec.Value = 1
            .Num_AudioKanäle.Value = 1
            .Num_AudioCodec.Value = 1
            .Num_AudioSprachen.Value = 1
            .Num_Cover.Value = 1
            .Num_Cover_better.Value = 1
            .Num_Backdrops.Value = 1
            .Num_Backdrops_more.Value = 1
            .Num_Trailer.Value = 0
            .Num_FileName.Value = 1
            .Num_Foldername.Value = 1
        End With
    End Sub
End Class