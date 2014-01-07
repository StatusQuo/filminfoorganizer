Imports System.Windows.Forms

Public Class Dialog_Online_Save
    Public m As Movie
    Public r As Search_Result

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click



        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



    Private Sub Panel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Click
        Panel1.Focus()
    End Sub

    Private Sub Dialog2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Font = SystemFonts.MessageBoxFont
        Select Case Einstellungen.Config_Overwrite.Mode
            Case Is = Overwritemode.Automatisch
                ToolStrip_auto.Checked = True
            Case Is = Overwritemode.Ergänzen
                ToolStrip_ergänzen.Checked = True
            Case Is = Overwritemode.Ersetzen
                ToolStrip_ersetzen.Checked = True
            Case Is = Overwritemode.Benutzerdefiniert
                ToolStrip_user.Checked = True
        End Select
        ToolStrip1.Renderer = New MyNativRenderer
        ToolStripDropDownButton1.DropDown = MainForm.ContextMenu_Overwrite

        If Not IsNothing(m) And Not IsNothing(r) Then
            Fill()
        End If
    End Sub

    Private Sub Fill()
        'Suche
        If r.meta_loaded = False Then
            MetaScrapper.LoadAll(r)
        End If

        Online_Autoren.t = r.Autoren
        Online_Bewertung.t = r.Bewertung
        Online_Darsteller.t = r.Darsteller
        Online_FSK.t = r.FSK
        Online_Genre.t = r.Genre
        Online_IMDB_ID.t = r.IMDB_ID
        Online_Inhalt.t = r.Inhalt
        Online_Produktionsjahr.t = r.Produktionsjahr
        Online_Originaltitel.t = r.Originaltitel
        Online_Produktionsland.t = r.Produktionsland
        Online_Regisseur.t = r.Regisseur
        Online_Sort.t = r.Sort
        Online_Studios.t = r.Studios
        Online_Titel.t = r.Titel
        'Lokal
        Offline_Autoren.t = m.Autoren
        Offline_Bewertung.t = m.Bewertung
        Offline_Darsteller.t = m.Darsteller
        Offline_FSK.t = m.FSK
        Offline_Genre.t = m.Genre
        Offline_IMDB_ID.t = m.IMDB_ID
        Offline_Inhalt.t = m.Inhalt
        Offline_Produktionsjahr.t = m.Produktionsjahr
        Offline_Originaltitel.t = m.Originaltitel
        Offline_Produktionsland.t = m.Produktionsland
        Offline_Regisseur.t = m.Regisseur
        Offline_Sort.t = m.Sort
        Offline_Studios.t = m.Studios
        Offline_Titel.t = m.Titel






        CheckBoxes()



        'If Online_Titel.t = "" Then
        '    Offline_Titel.Checked = True
        'ElseIf Offline_Titel.t = "" Then
        '    Online_Titel.Checked = True
        'Else
        '    If Einstellungen.Overwrite.Titel = True Then
        '        Online_Titel.Checked = True
        '    Else
        '        Online_Titel.Checked = False
        '    End If
        'End If
        'If Online_Originaltitel.t = "" Then
        '    Offline_Originaltitel.Checked = True
        'ElseIf Offline_Originaltitel.t = "" Then
        '    Online_Originaltitel.Checked = True
        'Else
        '    If Einstellungen.Overwrite.Originaltitel = True Then
        '        Online_Originaltitel.Checked = True
        '    Else
        '        Online_Originaltitel.Checked = False
        '    End If
        'End If
        'If Online_IMDB_ID.t = "" Then
        '    Offline_IMDB_ID.Checked = True
        'ElseIf Offline_IMDB_ID.t = "" Then
        '    Online_IMDB_ID.Checked = True
        'Else
        '    If Einstellungen.Overwrite.IMDB_ID = True Then
        '        Online_IMDB_ID.Checked = True
        '    Else
        '        Online_IMDB_ID.Checked = False
        '    End If
        'End If
        'If Online_Darsteller.t = "" Then
        '    Offline_Darsteller.Checked = True
        'ElseIf Offline_Darsteller.t = "" Then
        '    Online_Darsteller.Checked = True
        'Else
        '    If Einstellungen.Overwrite.Darsteller = True Then
        '        Online_Darsteller.Checked = True
        '    Else
        '        Online_Darsteller.Checked = False
        '    End If
        'End If
        'If Online_Regisseur.t = "" Then
        '    Offline_Regisseur.Checked = True
        'ElseIf Offline_Regisseur.t = "" Then
        '    Online_Regisseur.Checked = True
        'Else
        '    If Einstellungen.Overwrite.Regisseur = True Then
        '        Online_Regisseur.Checked = True
        '    Else
        '        Online_Regisseur.Checked = False
        '    End If
        'End If
        'If Online_Autoren.t = "" Then
        '    Offline_Autoren.Checked = True
        'ElseIf Offline_Autoren.t = "" Then
        '    Online_Autoren.Checked = True
        'Else
        '    If Einstellungen.Overwrite.Autoren = True Then
        '        Online_Autoren.Checked = True
        '    Else
        '        Online_Autoren.Checked = False
        '    End If
        'End If
        'If Online_Studios.t = "" Then
        '    Offline_Studios.Checked = True
        'ElseIf Offline_Studios.t = "" Then
        '    Online_Studios.Checked = True
        'Else
        '    If Einstellungen.Overwrite.Studios = True Then
        '        Online_Studios.Checked = True
        '    Else
        '        Online_Studios.Checked = False
        '    End If
        'End If
        'If Online_Produktionsjahr.t = "" Then
        '    Offline_Produktionsjahr.Checked = True
        'ElseIf Offline_Produktionsjahr.t = "" Then
        '    Online_Produktionsjahr.Checked = True
        'Else
        '    If Einstellungen.Overwrite.Produktionsjahr = True Then
        '        Online_Produktionsjahr.Checked = True
        '    Else
        '        Online_Produktionsjahr.Checked = False
        '    End If
        'End If
        'If Online_Produktionsland.t = "" Then
        '    Offline_Produktionsland.Checked = True
        'ElseIf Offline_Produktionsland.t = "" Then
        '    Online_Produktionsland.Checked = True
        'Else
        '    If Einstellungen.Overwrite.Produktionsland = True Then
        '        Online_Produktionsland.Checked = True
        '    Else
        '        Online_Produktionsland.Checked = False
        '    End If
        'End If
        'If Online_Genre.t = "" Then
        '    Offline_Genre.Checked = True
        'ElseIf Offline_Genre.t = "" Then
        '    Online_Genre.Checked = True
        'Else
        '    If Einstellungen.Overwrite.Genre = True Then
        '        Online_Genre.Checked = True
        '    Else
        '        Online_Genre.Checked = False
        '    End If
        'End If
        'If Online_FSK.t = "" Then
        '    Offline_FSK.Checked = True
        'ElseIf Offline_FSK.t = "" Then
        '    Online_FSK.Checked = True
        'Else
        '    If Einstellungen.Overwrite.FSK = True Then
        '        Online_FSK.Checked = True
        '    Else
        '        Online_FSK.Checked = False
        '    End If
        'End If
        'If Online_Bewertung.t = "" Then
        '    Offline_Bewertung.Checked = True
        'ElseIf Offline_Bewertung.t = "" Then
        '    Online_Bewertung.Checked = True
        'Else
        '    If Einstellungen.Overwrite.Bewertung = True Then
        '        Online_Bewertung.Checked = True
        '    Else
        '        Online_Bewertung.Checked = False
        '    End If
        'End If

        'If Online_Inhalt.t = "" Then
        '    Offline_Inhalt.Checked = True
        'ElseIf Offline_Inhalt.t = "" Then
        '    Online_Inhalt.Checked = True
        'Else
        '    If Einstellungen.Overwrite.Inhalt = True Then
        '        Online_Inhalt.Checked = True
        '    Else
        '        Online_Inhalt.Checked = False
        '    End If
        'End If
        'If Online_Sort.t = "" Then
        '    Offline_Sort.Checked = True
        'ElseIf Offline_Sort.t = "" Then
        '    Online_Sort.Checked = True
        'Else
        '    If Einstellungen.Overwrite.Sort = True Then
        '        Online_Sort.Checked = True
        '    Else
        '        Online_Sort.Checked = False
        '    End If
        'End If



    End Sub
    Private Sub Ersetzen()
        Online_Titel.Checked = True
        Online_Originaltitel.Checked = True
        Online_IMDB_ID.Checked = True
        Online_Darsteller.Checked = True
        Online_Regisseur.Checked = True
        Online_Autoren.Checked = True
        Online_Studios.Checked = True
        Online_Produktionsjahr.Checked = True
        Online_Produktionsland.Checked = True
        Online_Genre.Checked = True
        Online_FSK.Checked = True
        Online_Bewertung.Checked = True
        Online_Inhalt.Checked = True
        Online_Sort.Checked = True
    End Sub
    Private Sub Ergänzen()

        If Offline_Titel.t = "" And Not Online_Titel.t = "" Then
            Online_Titel.Checked = True
        Else
            Offline_Titel.Checked = True
        End If
        If Offline_Originaltitel.t = "" And Not Online_Originaltitel.t = "" Then
            Online_Originaltitel.Checked = True
        Else
            Offline_Originaltitel.Checked = True
        End If
        If Offline_IMDB_ID.t = "" And Not Online_IMDB_ID.t = "" Then
            Online_IMDB_ID.Checked = True
        Else
            Offline_IMDB_ID.Checked = True
        End If
        If Offline_Darsteller.t = "" And Not Online_Darsteller.t = "" Then
            Online_Darsteller.Checked = True
        Else
            Offline_Darsteller.Checked = True
        End If
        If Offline_Regisseur.t = "" And Not Online_Regisseur.t = "" Then
            Online_Regisseur.Checked = True
        Else
            Offline_Regisseur.Checked = True
        End If
        If Offline_Autoren.t = "" And Not Online_Autoren.t = "" Then
            Online_Autoren.Checked = True
        Else
            Offline_Autoren.Checked = True
        End If
        If Offline_Studios.t = "" And Not Online_Studios.t = "" Then
            Online_Studios.Checked = True
        Else
            Offline_Studios.Checked = True
        End If
        If Offline_Produktionsjahr.t = "" And Not Online_Produktionsjahr.t = "" Then
            Online_Produktionsjahr.Checked = True
        Else
            Offline_Produktionsjahr.Checked = True
        End If
        If Offline_Produktionsland.t = "" And Not Online_Produktionsland.t = "" Then
            Online_Produktionsland.Checked = True
        Else
            Offline_Produktionsland.Checked = True
        End If
        If Offline_Genre.t = "" And Not Online_Genre.t = "" Then
            Online_Genre.Checked = True
        Else
            Offline_Genre.Checked = True
        End If
        If Offline_FSK.t = "" And Not Online_FSK.t = "" Then
            Online_FSK.Checked = True
        Else
            Offline_FSK.Checked = True
        End If
        If Offline_Bewertung.t = "" And Not Online_Bewertung.t = "" Then
            Online_Bewertung.Checked = True
        Else
            Offline_Bewertung.Checked = True
        End If
        If Offline_Inhalt.t = "" And Not Online_Inhalt.t = "" Then
            Online_Inhalt.Checked = True
        Else
            Offline_Inhalt.Checked = True
        End If
        If Offline_Sort.t = "" And Not Online_Sort.t = "" Then
            Online_Sort.Checked = True
        Else
            Offline_Sort.Checked = True
        End If



    End Sub
    Private Sub Benutzerdefiniert()
        If (Einstellungen.Config_Overwrite.Titel = True Or Offline_Titel.t = "") And Not Online_Titel.t = "" Then
            Online_Titel.Checked = True
        Else
            Offline_Titel.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.Originaltitel = True Or Offline_Originaltitel.t = "") And Not Online_Originaltitel.t = "" Then
            Online_Originaltitel.Checked = True
        Else
            Offline_Originaltitel.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.IMDB_ID = True Or Offline_IMDB_ID.t = "") And Not Online_IMDB_ID.t = "" Then
            Online_IMDB_ID.Checked = True
        Else
            Offline_IMDB_ID.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.Darsteller = True Or Offline_Darsteller.t = "") And Not Online_Darsteller.t = "" Then
            Online_Darsteller.Checked = True
        Else
            Offline_Darsteller.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.Regisseur = True Or Offline_Regisseur.t = "") And Not Online_Regisseur.t = "" Then
            Online_Regisseur.Checked = True
        Else
            Offline_Regisseur.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.Autoren = True Or Offline_Autoren.t = "") And Not Online_Autoren.t = "" Then
            Online_Autoren.Checked = True
        Else
            Offline_Autoren.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.Studios = True Or Offline_Studios.t = "") And Not Online_Studios.t = "" Then
            Online_Studios.Checked = True
        Else
            Offline_Studios.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.Produktionsjahr = True Or Offline_Produktionsjahr.t = "") And Not Online_Produktionsjahr.t = "" Then
            Online_Produktionsjahr.Checked = True
        Else
            Offline_Produktionsjahr.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.Produktionsland = True Or Offline_Produktionsland.t = "") And Not Online_Produktionsland.t = "" Then
            Online_Produktionsland.Checked = True
        Else
            Offline_Produktionsland.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.Genre = True Or Offline_Genre.t = "") And Not Online_Genre.t = "" Then
            Online_Genre.Checked = True
        Else
            Offline_Genre.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.FSK = True Or Offline_FSK.t = "") And Not Online_FSK.t = "" Then
            Online_FSK.Checked = True
        Else
            Offline_FSK.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.Bewertung = True Or Offline_Bewertung.t = "") And Not Online_Bewertung.t = "" Then
            Online_Bewertung.Checked = True
        Else
            Offline_Bewertung.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.Inhalt = True Or Offline_Inhalt.t = "") And Not Online_Inhalt.t = "" Then
            Online_Inhalt.Checked = True
        Else
            Offline_Inhalt.Checked = True
        End If
        If (Einstellungen.Config_Overwrite.Sort = True Or Offline_Sort.t = "") And Not Online_Sort.t = "" Then
            Online_Sort.Checked = True
        Else
            Offline_Sort.Checked = True
        End If



    End Sub
    Sub CheckBoxes()
        Online_Titel.Checked = False
        Online_Originaltitel.Checked = False
        Online_IMDB_ID.Checked = False
        Online_Darsteller.Checked = False
        Online_Regisseur.Checked = False
        Online_Autoren.Checked = False
        Online_Studios.Checked = False
        Online_Produktionsjahr.Checked = False
        Online_Produktionsland.Checked = False
        Online_Genre.Checked = False
        Online_FSK.Checked = False
        Online_Bewertung.Checked = False
        Online_Inhalt.Checked = False
        Online_Sort.Checked = False
        Offline_Titel.Checked = False
        Offline_Originaltitel.Checked = False
        Offline_IMDB_ID.Checked = False
        Offline_Darsteller.Checked = False
        Offline_Regisseur.Checked = False
        Offline_Autoren.Checked = False
        Offline_Studios.Checked = False
        Offline_Produktionsjahr.Checked = False
        Offline_Produktionsland.Checked = False
        Offline_Genre.Checked = False
        Offline_FSK.Checked = False
        Offline_Bewertung.Checked = False
        Offline_Inhalt.Checked = False
        Offline_Sort.Checked = False
        Select Case Einstellungen.Config_Overwrite.Mode
            Case Is = Overwritemode.Automatisch

                If Offline_IMDB_ID.t = "" Then
                    Ersetzen()
                ElseIf Offline_IMDB_ID.t = Online_IMDB_ID.t Then
                    Ergänzen()
                Else
                    Ersetzen()
                End If

            Case Is = Overwritemode.Benutzerdefiniert
                Benutzerdefiniert()
            Case Is = Overwritemode.Ergänzen
                Ergänzen()
            Case Is = Overwritemode.Ersetzen
                Ersetzen()
        End Select


    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        CheckBoxes()

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_user.Click
        ToolStrip_auto.Checked = False
        ToolStrip_ersetzen.Checked = False
        ToolStrip_ergänzen.Checked = False
        ToolStrip_user.Checked = True
        Einstellungen.Config_Overwrite.Mode = Overwritemode.Benutzerdefiniert
        CheckBoxes()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_ergänzen.Click
        ToolStrip_auto.Checked = False
        ToolStrip_ersetzen.Checked = False
        ToolStrip_ergänzen.Checked = True
        ToolStrip_user.Checked = False
        Einstellungen.Config_Overwrite.Mode = Overwritemode.Ergänzen
        CheckBoxes()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_ersetzen.Click
        ToolStrip_auto.Checked = False
        ToolStrip_ersetzen.Checked = True
        ToolStrip_ergänzen.Checked = False
        ToolStrip_user.Checked = False
        Einstellungen.Config_Overwrite.Mode = Overwritemode.Ersetzen
        CheckBoxes()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_auto.Click
        ToolStrip_auto.Checked = True
        ToolStrip_ersetzen.Checked = False
        ToolStrip_ergänzen.Checked = False
        ToolStrip_user.Checked = False
        Einstellungen.Config_Overwrite.Mode = Overwritemode.Automatisch
        CheckBoxes()
    End Sub

    Public Sub modifyResult()
        If m.focused Then
            MainForm.InfoPanel_Movie1.SelectedResult = New Search_Result(r)
            MainForm.InfoPanel_Movie1.ToolStripButton_Ergebnisbearbeiten.Visible = True
        End If




        r.modified = True
        If Offline_Titel.Checked = True Then
            r.Titel = Offline_Titel.t
        Else
            r.Titel = Online_Titel.t
        End If
        If Offline_Originaltitel.Checked = True Then
            r.Originaltitel = Offline_Originaltitel.t
        Else
            r.Originaltitel = Online_Originaltitel.t
        End If
        If Offline_IMDB_ID.Checked = True Then
            r.IMDB_ID = Offline_IMDB_ID.t
        Else
            r.IMDB_ID = Online_IMDB_ID.t
        End If
        If Offline_Darsteller.Checked = True Then
            r.Darsteller = Offline_Darsteller.t
        Else
            r.Darsteller = Online_Darsteller.t
        End If
        If Offline_Regisseur.Checked = True Then
            r.Regisseur = Offline_Regisseur.t
        Else
            r.Regisseur = Online_Regisseur.t
        End If
        If Offline_Autoren.Checked = True Then
            r.Autoren = Offline_Autoren.t
        Else
            r.Autoren = Online_Autoren.t
        End If
        If Offline_Studios.Checked = True Then
            r.Studios = Offline_Studios.t
        Else
            r.Studios = Online_Studios.t
        End If
        If Offline_Produktionsjahr.Checked = True Then
            r.Produktionsjahr = Offline_Produktionsjahr.t
        Else
            r.Produktionsjahr = Online_Produktionsjahr.t
        End If
        If Offline_Produktionsland.Checked = True Then
            r.Produktionsland = Offline_Produktionsland.t
        Else
            r.Produktionsland = Online_Produktionsland.t
        End If
        If Offline_Genre.Checked = True Then
            r.Genre = Offline_Genre.t
        Else
            r.Genre = Online_Genre.t
        End If
        If Offline_FSK.Checked = True Then
            r.FSK = Offline_FSK.t
        Else
            r.FSK = Online_FSK.t
        End If
        If Offline_Bewertung.Checked = True Then
            r.Bewertung = Offline_Bewertung.t
        Else
            r.Bewertung = Online_Bewertung.t
        End If
        If Offline_Inhalt.Checked = True Then
            r.Inhalt = Offline_Inhalt.t
        Else
            r.Inhalt = Online_Inhalt.t
        End If
        If Offline_Sort.Checked = True Then
            r.Sort = Offline_Sort.t
        Else
            r.Sort = Online_Sort.t
        End If

    End Sub

End Class
