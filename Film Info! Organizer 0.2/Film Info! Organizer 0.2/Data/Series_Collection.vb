
Public Class SeriesCollection
    Public Serien As New List(Of Series)
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

End Class
