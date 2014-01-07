Imports System.Windows.Forms

Public Class Dialog_LoadingMethode
    Public p() As String
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Einstellungen.Config_Laden.Laden_Ordner_Suche = Check_search.Checked
        Einstellungen.Config_Laden.Laden_Ordner_MediaInfo = Check_MediaInfo.Checked
        Einstellungen.Config_Laden.Laden_Ordner_neuerOrdner = Check_CreateFolder.Checked
        Einstellungen.Config_Laden.Laden_Ordner_Einstellungenimmerneu = CheckBox1.Checked
        Einstellungen.Config_Laden.Laden_Ordner_suchmodus = Laden_Ordner_suchmodus.SelectedIndex
        Dim Datenlader As New Progress_LoadFolder(p)
        Datenlader.Run()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog_LoadingMethode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckBox1.Checked = Einstellungen.Config_Laden.Laden_Ordner_Einstellungenimmerneu
        Check_MediaInfo.Checked = Einstellungen.Config_Laden.Laden_Ordner_MediaInfo
        Check_search.Checked = Einstellungen.Config_Laden.Laden_Ordner_Suche
        Check_CreateFolder.Checked = Einstellungen.Config_Laden.Laden_Ordner_neuerOrdner
        If Not Einstellungen.Config_Laden.Laden_Ordner_suchmodus = -1 Then
            Laden_Ordner_suchmodus.SelectedIndex = Einstellungen.Config_Laden.Laden_Ordner_suchmodus
        Else
            Laden_Ordner_suchmodus.SelectedIndex = 1
        End If
    End Sub
End Class
