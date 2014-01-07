'---------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms.VisualStyles
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Drawing.Design

Namespace AdvancedDataGridView
	''' <summary>
	''' Summary description for TreeGridView.
	''' </summary>
       Public Class TreeGridView
        Inherits DataGridView
        Private _indentWidth As Integer
        Private _root As TreeGridNode
        Private _expandableColumn As TreeGridColumn
        Private _disposing As Boolean = False
        Friend _imageList As ImageList
        Private _inExpandCollapse As Boolean = False
        Friend _inExpandCollapseMouseCapture As Boolean = False
        Private hideScrollBarControl As Control
        Private _showLines As Boolean = True
        Private _virtualNodes As Boolean = False

        Friend rOpen As New VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Opened)
        Friend rClosed As New VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Closed)

#Region "Constructor"
        Public Sub New()
            ' Control when edit occurs because edit mode shouldn't start when expanding/collapsing
            Me.EditMode = DataGridViewEditMode.EditProgrammatically
            Me.RowTemplate = TryCast(New TreeGridNode(), DataGridViewRow)
            ' This sample does not support adding or deleting rows by the user.
            Me.AllowUserToAddRows = False
            Me.AllowUserToDeleteRows = False
            Me._root = New TreeGridNode(Me)
            Me._root.IsRoot = True

            ' Ensures that all rows are added unshared by listening to the CollectionChanged event.
            'AddHandler MyBase.Rows.CollectionChanged, Function(sender As Object, e As System.ComponentModel.CollectionChangeEventArgs) 

		End Sub
#End Region

#Region "Keyboard F2 to begin edit support"
        Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
            ' Cause edit mode to begin since edit mode is disabled to support 
            ' expanding/collapsing 
            MyBase.OnKeyDown(e)
            If Not e.Handled Then
                If e.KeyCode = Keys.F2 AndAlso Me.CurrentCellAddress.X > -1 AndAlso Me.CurrentCellAddress.Y > -1 Then
                    If Not Me.CurrentCell.Displayed Then
                        Me.FirstDisplayedScrollingRowIndex = Me.CurrentCellAddress.Y
                        ' TODO:calculate if the cell is partially offscreen and if so scroll into view
                    Else
                    End If
                    Me.SelectionMode = DataGridViewSelectionMode.CellSelect
                    Me.BeginEdit(True)
                ElseIf e.KeyCode = Keys.Enter AndAlso Not Me.IsCurrentCellInEditMode Then
                    Me.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    Me.CurrentCell.OwningRow.Selected = True
                End If
            End If
        End Sub
#End Region

#Region "Shadow and hide DGV properties"

        ' This sample does not support databinding
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property DataSource() As Object
            Get
                Return Nothing
            End Get
            Set(ByVal value As Object)
                Throw New NotSupportedException("The TreeGridView does not support databinding")
            End Set
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property DataMember() As Object
            Get
                Return Nothing
            End Get
            Set(ByVal value As Object)
                Throw New NotSupportedException("The TreeGridView does not support databinding")
            End Set
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows ReadOnly Property Rows() As DataGridViewRowCollection
            Get
                Return MyBase.Rows
            End Get
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property VirtualMode() As Boolean
            Get
                Return False
            End Get
            Set(ByVal value As Boolean)
                Throw New NotSupportedException("The TreeGridView does not support virtual mode")
            End Set
        End Property

        ' none of the rows/nodes created use the row template, so it is hidden.
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property RowTemplate() As DataGridViewRow
            Get
                Return MyBase.RowTemplate
            End Get
            Set(ByVal value As DataGridViewRow)
                MyBase.RowTemplate = Value
            End Set
        End Property

#End Region

#Region "Public methods"
        <Description("Returns the TreeGridNode for the given DataGridViewRow")> _
        Public Function GetNodeForRow(ByVal row As DataGridViewRow) As TreeGridNode
            Return TryCast(row, TreeGridNode)
        End Function

        <Description("Returns the TreeGridNode for the given DataGridViewRow")> _
        Public Function GetNodeForRow(ByVal index As Integer) As TreeGridNode
            Return GetNodeForRow(MyBase.Rows(index))
        End Function
#End Region

#Region "Public properties"
        <Category("Data"), Description("The collection of root nodes in the treelist."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Editor(GetType(CollectionEditor), GetType(UITypeEditor))> _
        Public ReadOnly Property Nodes() As TreeGridNodeCollection
            Get
                Return Me._root.Nodes
            End Get
        End Property

        Public Shadows ReadOnly Property CurrentRow() As TreeGridNode
            Get
                Return TryCast(MyBase.CurrentRow, TreeGridNode)
            End Get
        End Property

        <DefaultValue(False), Description("Causes nodes to always show as expandable. Use the NodeExpanding event to add nodes.")> _
        Public Property VirtualNodes() As Boolean
            Get
                Return _virtualNodes
            End Get
            Set(ByVal value As Boolean)
                _virtualNodes = Value
            End Set
        End Property

        Public ReadOnly Property CurrentNode() As TreeGridNode
            Get
                Return Me.CurrentRow
            End Get
        End Property

        <DefaultValue(True)> _
        Public Property ShowLines() As Boolean
            Get
                Return Me._showLines
            End Get
            Set(ByVal value As Boolean)
                If Value <> Me._showLines Then
                    Me._showLines = Value
                    Me.Invalidate()
                End If
            End Set
        End Property

        Public Property ImageList() As ImageList
            Get
                Return Me._imageList
            End Get
            Set(ByVal value As ImageList)
                'TODO: should we invalidate cell styles when setting the image list?

                Me._imageList = Value
            End Set
        End Property

        Public Shadows Property RowCount() As Integer
            Get
                Return Me.Nodes.Count
            End Get
            Set(ByVal value As Integer)
                For i As Integer = 0 To Value - 1
                    Me.Nodes.Add(New TreeGridNode())

                Next
            End Set
        End Property
#End Region

#Region "Site nodes and collapse/expand support"
        Protected Overrides Sub OnRowsAdded(ByVal e As DataGridViewRowsAddedEventArgs)
            MyBase.OnRowsAdded(e)
            ' Notify the row when it is added to the base grid 
            Dim count As Integer = e.RowCount - 1
            Dim row As TreeGridNode
            While count >= 0
                row = TryCast(MyBase.Rows(e.RowIndex + count), TreeGridNode)
                If row IsNot Nothing Then
                    row.Sited()
                End If
                count -= 1
            End While
        End Sub

        Protected Friend Sub UnSiteAll()
            Me.UnSiteNode(Me._root)
        End Sub

        Protected Friend Overridable Sub UnSiteNode(ByVal node As TreeGridNode)
            If node.IsSited OrElse node.IsRoot Then
                ' remove child rows first
                For Each childNode As TreeGridNode In node.Nodes
                    Me.UnSiteNode(childNode)
                Next

                ' now remove this row except for the root
                If Not node.IsRoot Then
                    MyBase.Rows.Remove(node)
                    ' Row isn't sited in the grid anymore after remove. Note that we cannot
                    ' Use the RowRemoved event since we cannot map from the row index to
                    ' the index of the expandable row/node.
                    node.UnSited()
                End If
            End If
        End Sub

        Protected Friend Overridable Function CollapseNode(ByVal node As TreeGridNode) As Boolean
            If node.IsExpanded Then
                Dim exp As New CollapsingEventArgs(node)
                Me.OnNodeCollapsing(exp)

                If Not exp.Cancel Then
                    Me.LockVerticalScrollBarUpdate(True)
                    Me.SuspendLayout()
                    _inExpandCollapse = True
                    node.IsExpanded = False

                    For Each childNode As TreeGridNode In node.Nodes
                        Debug.Assert(childNode.RowIndex <> -1, "Row is NOT in the grid.")
                        Me.UnSiteNode(childNode)
                    Next

                    Dim exped As New CollapsedEventArgs(node)
                    Me.OnNodeCollapsed(exped)
                    'TODO: Convert this to a specific NodeCell property
                    _inExpandCollapse = False
                    Me.LockVerticalScrollBarUpdate(False)
                    Me.ResumeLayout(True)

                    Me.InvalidateCell(node.Cells(0))
                End If

                Return Not exp.Cancel
            Else
                ' row isn't expanded, so we didn't do anything.				
                Return False
            End If
        End Function

        Protected Friend Overridable Sub SiteNode(ByVal node As TreeGridNode)
            'TODO: Raise exception if parent node is not the root or is not sited.
            Dim rowIndex As Integer = -1
            Dim currentRow As TreeGridNode
            node._grid = Me

            If node.Parent IsNot Nothing AndAlso node.Parent.IsRoot = False Then
                ' row is a child
                Debug.Assert(node.Parent IsNot Nothing AndAlso node.Parent.IsExpanded = True)

                If node.Index > 0 Then
                    currentRow = node.Parent.Nodes(node.Index - 1)
                Else
                    currentRow = node.Parent
                End If
            Else
                ' row is being added to the root
                If node.Index > 0 Then
                    currentRow = node.Parent.Nodes(node.Index - 1)
                Else
                    currentRow = Nothing

                End If
            End If

            If currentRow IsNot Nothing Then
                While currentRow.Level >= node.Level
                    If currentRow.RowIndex < MyBase.Rows.Count - 1 Then
                        currentRow = TryCast(MyBase.Rows(currentRow.RowIndex + 1), TreeGridNode)
                        Debug.Assert(currentRow IsNot Nothing)
                    Else
                        ' no more rows, site this node at the end.
                        Exit While

                    End If
                End While
                If currentRow Is node.Parent Then
                    rowIndex = currentRow.RowIndex + 1
                ElseIf currentRow.Level < node.Level Then
                    rowIndex = currentRow.RowIndex
                Else
                    rowIndex = currentRow.RowIndex + 1
                End If
            Else
                rowIndex = 0
            End If


            Debug.Assert(rowIndex <> -1)
            Me.SiteNode(node, rowIndex)

            Debug.Assert(node.IsSited)
            If node.IsExpanded Then
                ' add all child rows to display
                For Each childNode As TreeGridNode In node.Nodes
                    'TODO: could use the more efficient SiteRow with index.
                    Me.SiteNode(childNode)
                Next
            End If
        End Sub


        Protected Friend Overridable Sub SiteNode(ByVal node As TreeGridNode, ByVal index As Integer)
            If index < MyBase.Rows.Count Then
                MyBase.Rows.Insert(index, node)
            Else
                ' for the last item.
                MyBase.Rows.Add(node)
            End If
        End Sub

        Protected Friend Overridable Function ExpandNode(ByVal node As TreeGridNode) As Boolean
            If Not node.IsExpanded OrElse Me._virtualNodes Then
                Dim exp As New ExpandingEventArgs(node)
                Me.OnNodeExpanding(exp)

                If Not exp.Cancel Then
                    Me.LockVerticalScrollBarUpdate(True)
                    Me.SuspendLayout()
                    _inExpandCollapse = True
                    node.IsExpanded = True

                    'TODO Convert this to a InsertRange
                    For Each childNode As TreeGridNode In node.Nodes
                        Debug.Assert(childNode.RowIndex = -1, "Row is already in the grid.")

                        'this.BaseRows.Insert(rowIndex + 1, childRow);
                        'TODO : remove -- just a test.
                        'childNode.Cells[0].Value = "child";
                        Me.SiteNode(childNode)
                    Next

                    Dim exped As New ExpandedEventArgs(node)
                    Me.OnNodeExpanded(exped)
                    'TODO: Convert this to a specific NodeCell property
                    _inExpandCollapse = False
                    Me.LockVerticalScrollBarUpdate(False)
                    Me.ResumeLayout(True)
                    Me.InvalidateCell(node.Cells(0))
                End If

                Return Not exp.Cancel
            Else
                ' row is already expanded, so we didn't do anything.
                Return False
            End If
        End Function

        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            ' used to keep extra mouse moves from selecting more rows when collapsing
            MyBase.OnMouseUp(e)
            Me._inExpandCollapseMouseCapture = False
        End Sub
        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            ' while we are expanding and collapsing a node mouse moves are
            ' supressed to keep selections from being messed up.
            If Not Me._inExpandCollapseMouseCapture Then
                MyBase.OnMouseMove(e)
            End If

        End Sub
#End Region

#Region "Collapse/Expand events"
        Public Event NodeExpanding As ExpandingEventHandler
        Public Event NodeExpanded As ExpandedEventHandler
        Public Event NodeCollapsing As CollapsingEventHandler
        Public Event NodeCollapsed As CollapsedEventHandler

        Protected Overridable Sub OnNodeExpanding(ByVal e As ExpandingEventArgs)
            RaiseEvent NodeExpanding(Me, e)
        End Sub
        Protected Overridable Sub OnNodeExpanded(ByVal e As ExpandedEventArgs)
            RaiseEvent NodeExpanded(Me, e)
        End Sub
        Protected Overridable Sub OnNodeCollapsing(ByVal e As CollapsingEventArgs)
            RaiseEvent NodeCollapsing(Me, e)

        End Sub
        Protected Overridable Sub OnNodeCollapsed(ByVal e As CollapsedEventArgs)
            RaiseEvent NodeCollapsed(Me, e)
        End Sub
#End Region

#Region "Helper methods"
        Protected Overrides Sub Dispose(ByVal disposing__1 As Boolean)
            Me._disposing = True
            MyBase.Dispose(Disposing)
            Me.UnSiteAll()
        End Sub

        Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
            MyBase.OnHandleCreated(e)

            ' this control is used to temporarly hide the vertical scroll bar
            hideScrollBarControl = New Control()
            hideScrollBarControl.Visible = False
            hideScrollBarControl.Enabled = False
            hideScrollBarControl.TabStop = False
            ' control is disposed automatically when the grid is disposed
            Me.Controls.Add(hideScrollBarControl)
        End Sub

        Protected Overrides Sub OnRowEnter(ByVal e As DataGridViewCellEventArgs)
            ' ensure full row select
            MyBase.OnRowEnter(e)
            If Me.SelectionMode = DataGridViewSelectionMode.CellSelect OrElse (Me.SelectionMode = DataGridViewSelectionMode.FullRowSelect AndAlso MyBase.Rows(e.RowIndex).Selected = False) Then
                Me.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                MyBase.Rows(e.RowIndex).Selected = True
            End If
        End Sub

        Private Sub LockVerticalScrollBarUpdate(ByVal lockUpdate As Boolean)
            ', bool delayed
            ' Temporarly hide/show the vertical scroll bar by changing its parent
            If Not Me._inExpandCollapse Then
                If lockUpdate Then
                    Me.VerticalScrollBar.Parent = hideScrollBarControl
                Else
                    Me.VerticalScrollBar.Parent = Me
                End If
            End If
        End Sub

        Protected Overrides Sub OnColumnAdded(ByVal e As DataGridViewColumnEventArgs)
            If GetType(TreeGridColumn).IsAssignableFrom(e.Column.[GetType]()) Then
                If _expandableColumn Is Nothing Then
                    ' identify the expanding column.			
                    _expandableColumn = DirectCast(e.Column, TreeGridColumn)
                    ' this.Columns.Remove(e.Column);
                    'throw new InvalidOperationException("Only one TreeGridColumn per TreeGridView is supported.");
                Else
                End If
            End If

            ' Expandable Grid doesn't support sorting. This is just a limitation of the sample.
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable

            MyBase.OnColumnAdded(e)
        End Sub

        Private NotInheritable Class Win32Helper
            Private Sub New()
            End Sub
            Public Const WM_SYSKEYDOWN As Integer = &H104, WM_KEYDOWN As Integer = &H100, WM_SETREDRAW As Integer = &HB

            <System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
            Public Shared Function SendMessage(ByVal hWnd As System.Runtime.InteropServices.HandleRef, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
            End Function

            <System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
            Public Shared Function SendMessage(ByVal hWnd As System.Runtime.InteropServices.HandleRef, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr
            End Function

            <System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
            Public Shared Function PostMessage(ByVal hwnd As System.Runtime.InteropServices.HandleRef, ByVal msg As Integer, ByVal wparam As IntPtr, ByVal lparam As IntPtr) As Boolean
            End Function

        End Class
#End Region


    End Class
End Namespace
