' An instance of the SortWrapper class is created for 
' each item and added to the ArrayList for sorting.
Public Class SortWrapper
    Friend sortItem As ListViewItem
    Friend sortColumn As Integer

    ' A SortWrapper requires the item and the index of the clicked column.
    Public Sub New(ByVal Item As ListViewItem, ByVal iColumn As Integer)
        sortItem = Item
        sortColumn = iColumn
    End Sub

    ' Text property for getting the text of an item.
    Public ReadOnly Property [Text]() As String
        Get
            Return sortItem.SubItems(sortColumn).Text
        End Get
    End Property

    ' Implementation of the IComparer 
    ' interface for sorting ArrayList items.
    Public Class SortComparer
        Implements IComparer
        Private ascending As Boolean


        ' Constructor requires the sort order;
        ' true if ascending, otherwise descending.
        Public Sub New(ByVal asc As Boolean)
            Me.ascending = asc
        End Sub


        ' Implemnentation of the IComparer:Compare 
        ' method for comparing two objects.
        Public Function [Compare](ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim xItem As SortWrapper = CType(x, SortWrapper)
            Dim yItem As SortWrapper = CType(y, SortWrapper)

            Dim xText As String = xItem.sortItem.SubItems(xItem.sortColumn).Text
            Dim yText As String = yItem.sortItem.SubItems(yItem.sortColumn).Text
            Return xText.CompareTo(yText) * If(Me.ascending, 1, -1)
        End Function
    End Class
End Class
' The ColHeader class is a ColumnHeader object with an 
' added property for determining an ascending or descending sort.
' True specifies an ascending order, false specifies a descending order.
Public Class ColHeader
    Inherits ColumnHeader
    Public ascending As Boolean = True
    Sub New()
    End Sub
    Public Sub New(ByVal [text] As String, ByVal width As Integer, ByVal align As HorizontalAlignment, ByVal asc As Boolean)
        Me.Text = [text]
        Me.Width = width
        Me.TextAlign = align
        Me.ascending = asc
    End Sub
End Class