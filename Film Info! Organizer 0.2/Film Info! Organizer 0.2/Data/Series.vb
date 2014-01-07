Imports Film_Info__Organizer.MyFunctions
Public Class Series
    Public Seasons As New List(Of Season)
    Dim sPath As String = ""
    Dim sNode As TreeNode
    Public Property Node() As TreeNode
        Get
            Return sNode
        End Get
        Set(ByVal value As TreeNode)
            sNode = value
        End Set
    End Property
    Public Property Pfad() As String
        Get
            Return sPath
        End Get
        Set(ByVal value As String)
            sPath = value

        End Set
    End Property

    Property Titel As String

    Property ID As String

    Property Bewertung As String

    Property Studio As String

    Property Jahr As String

    Property Darsteller As String

    Property Genre As String

    Property IMDB_ID As String

    Property Inhalt As String

End Class
Public Class Season
    Public Episodes As New List(Of Episode)
    Dim sPath As String = ""
    Dim sNode As TreeNode

    Public Property Pfad() As String
        Get
            Return sPath
        End Get
        Set(ByVal value As String)
            sPath = value

        End Set
    End Property

    Property Title As String

    Property Num As Integer

    '    Property Node As AdvancedDataGridView.TreeGridNode

    Property Rate_Cover As Integer
    Property Rate_Info As Integer
    Property Rate_MediaInfo As Integer
    Property Rate_Filename As Integer
    Property Fortschritt As Integer
    Sub refresh()




        'If Not Node Is Nothing Then
        '    Einstellungen.Config_Fortschritt.getFortschritt(Me)
        '    'Node.CreateCells(MainForm.Serien_Grid_View, {Num, Fortschritt, Rate_Cover, Rate_Info, Rate_MediaInfo, Rate_Filename, " " & Title, Pfad})
        'End If

    End Sub

End Class
Public Class Episode
    Property Rate_Cover As Integer = 0
    Property Rate_Info As Integer = 0
    Property Rate_MediaInfo As Integer = 0
    Property Rate_Filename As Integer = 0
    Property Fortschritt As Integer = 0
    Property Pfad As String = ""

    Property Titel As String = ""

    Property Jahr As String = ""

    Property Darsteller As String = ""

    Property Regisseur As String = ""

    Property Autoren As String = ""

    Property Bewertung As String = ""

    Property Spieldauer As String = ""

    Property Inhalt As String = ""

    Property MediaInfo As String = ""

    Property Datum As String = ""

    Property Gesehen As String = ""

    Property VideoAuflösung As String = ""

    Property VideoSeitenverhältnis As String = ""

    Property VideoBreite As String = ""

    Property VideoHöhe As String = ""

    Property VideoBildwiederholungsrate As String = ""

    Property VideoCodec As String = ""

    Property AudioCodec As String = ""

    Property AudioKanäle As String = ""

    Property AudioSprachen As String = ""

    Property Num As String = ""

    '  Property Node As AdvancedDataGridView.TreeGridNode

    Property bild As String = ""

    Property State_Info_tip As New List(Of String)

    Property State_Info_text As String = ""

    Property State_MediaInfo_tip As New List(Of String)

    Property State_MediaInfo_text As String = ""

    Property files As String()

    Sub refresh()
'
    End Sub

End Class
