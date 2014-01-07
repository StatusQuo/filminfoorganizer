'---------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------
Imports System.Collections.Generic
Imports System.Text

Namespace AdvancedDataGridView
    Public Class TreeGridNodeCollection
        Implements System.Collections.Generic.IList(Of TreeGridNode)
        Implements System.Collections.IList
        Friend _list As System.Collections.Generic.List(Of TreeGridNode)
        Friend _owner As TreeGridNode
        Friend Sub New(ByVal owner As TreeGridNode)
            Me._owner = owner
            Me._list = New List(Of TreeGridNode)()
        End Sub

#Region "Public Members"
        Public Sub Add(ByVal item As TreeGridNode)
            ' The row needs to exist in the child collection before the parent is notified.
            item._grid = Me._owner._grid

            Dim hadChildren As Boolean = Me._owner.HasChildren
            item._owner = Me

            Me._list.Add(item)

            Me._owner.AddChildNode(item)

            ' if the owner didn't have children but now does (asserted) and it is sited update it
            If Not hadChildren AndAlso Me._owner.IsSited Then
                Me._owner._grid.InvalidateRow(Me._owner.RowIndex)
            End If
        End Sub

        Public Function Add(ByVal text As String) As TreeGridNode
            Dim node As New TreeGridNode()
            Me.Add(node)

            node.Cells(0).Value = text
            Return node
        End Function

        Public Function Add(ByVal ParamArray values As Object()) As TreeGridNode
            Dim node As New TreeGridNode()
            Me.Add(node)

            Dim cell As Integer = 0

            If values.Length > node.Cells.Count Then
                Throw New ArgumentOutOfRangeException("values")
            End If

            For Each o As Object In values
                node.Cells(cell).Value = o
                cell += 1
            Next
            Return node
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal item As TreeGridNode)
            ' The row needs to exist in the child collection before the parent is notified.
            item._grid = Me._owner._grid
            item._owner = Me

            Me._list.Insert(index, item)

            Me._owner.InsertChildNode(index, item)
        End Sub

        Public Function Remove(ByVal item As TreeGridNode) As Boolean
            ' The parent is notified first then the row is removed from the child collection.
            Me._owner.RemoveChildNode(item)
            item._grid = Nothing
            Return Me._list.Remove(item)
        End Function

        Public Sub RemoveAt(ByVal index As Integer) Implements IList(Of TreeGridNode).RemoveAt
            Dim row As TreeGridNode = Me._list(index)

            ' The parent is notified first then the row is removed from the child collection.
            Me._owner.RemoveChildNode(row)
            row._grid = Nothing
            Me._list.RemoveAt(index)
        End Sub

        Public Sub Clear() Implements ICollection(Of TreeGridNode).Clear
            ' The parent is notified first then the row is removed from the child collection.
            Me._owner.ClearNodes()
            Me._list.Clear()
        End Sub

        Public Function IndexOf(ByVal item As TreeGridNode) As Integer
            Return Me._list.IndexOf(item)
        End Function

        Default Public Property Item(ByVal index As Integer) As TreeGridNode Implements IList(Of TreeGridNode).Item, System.Collections.IList.Item
            Get
                Return Me._list(index)
            End Get
            Set(ByVal value As TreeGridNode)
                Throw New Exception("The method or operation is not implemented.")
            End Set
        End Property

        Public Function Contains(ByVal item As TreeGridNode) As Boolean
            Return Me._list.Contains(item)
        End Function

        Public Sub CopyTo(ByVal array As TreeGridNode(), ByVal arrayIndex As Integer)
            Throw New Exception("The method or operation is not implemented.")
        End Sub

        Public ReadOnly Property Count() As Integer Implements ICollection(Of TreeGridNode).Count
            Get
                Return Me._list.Count
            End Get
        End Property

        Public ReadOnly Property IsReadOnly() As Boolean Implements ICollection(Of TreeGridNode).IsReadOnly
            Get
                Return False
            End Get
        End Property
#End Region

#Region "IList Interface"
        Private Sub System_Collections_IList_Remove(ByVal value As Object) Implements System.Collections.IList.Remove
            Me.Remove(TryCast(value, TreeGridNode))
        End Sub


        Private Function System_Collections_IList_Add(ByVal value As Object) As Integer Implements System.Collections.IList.Add
            Dim item As TreeGridNode = TryCast(value, TreeGridNode)
            Me.Add(item)
            Return item.Index
        End Function

        Private Sub System_Collections_IList_RemoveAt(ByVal index As Integer) Implements System.Collections.IList.RemoveAt
            Me.RemoveAt(index)
        End Sub


        Private Sub System_Collections_IList_Clear() Implements System.Collections.IList.Clear
            Me.Clear()
        End Sub

        Private ReadOnly Property System_Collections_IList_IsReadOnly() As Boolean Implements System.Collections.IList.IsReadOnly
            Get
                Return Me.IsReadOnly
            End Get
        End Property

        Private ReadOnly Property System_Collections_IList_IsFixedSize() As Boolean Implements System.Collections.IList.IsFixedSize
            Get
                Return False
            End Get
        End Property

        Private Function System_Collections_IList_IndexOf(ByVal item As Object) As Integer Implements System.Collections.IList.IndexOf
            Return Me.IndexOf(TryCast(item, TreeGridNode))
        End Function

        Private Sub System_Collections_IList_Insert(ByVal index As Integer, ByVal value As Object) Implements System.Collections.IList.Insert
            Me.Insert(index, TryCast(value, TreeGridNode))
        End Sub
        Private ReadOnly Property System_Collections_ICollection_Count() As Integer Implements System.Collections.ICollection.Count
            Get
                Return Me.Count
            End Get
        End Property
        Private Function System_Collections_IList_Contains(ByVal value As Object) As Boolean Implements System.Collections.IList.Contains
            Return Me.Contains(TryCast(value, TreeGridNode))
        End Function
        Private Sub System_Collections_ICollection_CopyTo(ByVal array As Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
            Throw New Exception("The method or operation is not implemented.")
        End Sub
        Default Property System_Collections_IList_Item(ByVal index As Integer) As Object Implements System.Collections.IList.this
            Get
                Return Me(index)
            End Get
            Set(ByVal value As Object)
                Throw New Exception("The method or operation is not implemented.")
            End Set
        End Property



#Region "IEnumerable<ExpandableRow> Members"

        Public Function GetEnumerator() As IEnumerator(Of TreeGridNode) Implements IEnumerable(Of TreeGridNode).GetEnumerator
            Return Me._list.GetEnumerator()
        End Function

#End Region


#Region "IEnumerable Members"

        Private Function System_Collections_IEnumerable_GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.GetEnumerator()
        End Function

#End Region
#End Region

#Region "ICollection Members"

        Private ReadOnly Property System_Collections_ICollection_IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property

        Private ReadOnly Property System_Collections_ICollection_SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
            Get
                Throw New Exception("The method or operation is not implemented.")
            End Get
        End Property

#End Region
    End Class

End Namespace
