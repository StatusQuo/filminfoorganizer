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
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Drawing.Design
Imports System.Text

Namespace AdvancedDataGridView
	<ToolboxItem(False), DesignTimeVisible(False)> _
	Public Class TreeGridNode
		Inherits DataGridViewRow
		', IComponent
		Friend _grid As TreeGridView
		Friend _parent As TreeGridNode
		Friend _owner As TreeGridNodeCollection
		Friend IsExpanded As Boolean
		Friend IsRoot As Boolean
		Friend _isSited As Boolean
		Friend _isFirstSibling As Boolean
		Friend _isLastSibling As Boolean
		Friend _image As Image
		Friend _imageIndex As Integer

		Private rndSeed As New Random()
		Public UniqueValue As Integer = -1
		Private _treeCell As TreeGridCell
		Private childrenNodes As TreeGridNodeCollection

		Private _index As Integer
		Private _level As Integer
		Private childCellsCreated As Boolean = False

		' needed for IComponent
		Private m_site As ISite = Nothing
		Private disposed As EventHandler = Nothing

		Friend Sub New(owner As TreeGridView)
			Me.New()
			Me._grid = owner
			Me.IsExpanded = True
		End Sub

		Public Sub New()
			_index = -1
			_level = -1
			IsExpanded = False
			UniqueValue = Me.rndSeed.[Next]()
			_isSited = False
			_isFirstSibling = False
			_isLastSibling = False
			_imageIndex = -1
		End Sub

		Public Overrides Function Clone() As Object
			Dim r As TreeGridNode = DirectCast(MyBase.Clone(), TreeGridNode)
			r.UniqueValue = -1
			r._level = Me._level
			r._grid = Me._grid
			r._parent = Me.Parent

			r._imageIndex = Me._imageIndex
			If r._imageIndex = -1 Then
				r.Image = Me.Image
			End If

			r.IsExpanded = Me.IsExpanded
			'r.treeCell = new TreeGridCell();

			Return r
		End Function

		Protected Friend Overridable Sub UnSited()
			' This row is being removed from being displayed on the grid.
			Dim cell As TreeGridCell
			For Each DGVcell As DataGridViewCell In Me.Cells
				cell = TryCast(DGVcell, TreeGridCell)
				If cell IsNot Nothing Then
					cell.UnSited()
				End If
			Next
			Me._isSited = False
		End Sub

		Protected Friend Overridable Sub Sited()
			' This row is being added to the grid.
			Me._isSited = True
			Me.childCellsCreated = True
			Debug.Assert(Me._grid IsNot Nothing)

			Dim cell As TreeGridCell
			For Each DGVcell As DataGridViewCell In Me.Cells
				cell = TryCast(DGVcell, TreeGridCell)
				If cell IsNot Nothing Then
						' Level = this.Level;
					cell.Sited()
				End If
			Next

		End Sub

		' Represents the index of this row in the Grid
		<System.ComponentModel.Description("Represents the index of this row in the Grid. Advanced usage."), System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced), Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public ReadOnly Property RowIndex() As Integer
			Get
				Return MyBase.Index
			End Get
		End Property

		' Represents the index of this row based upon its position in the collection.
		<Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows Property Index() As Integer
			Get
				If _index = -1 Then
					' get the index from the collection if unknown
					_index = Me._owner.IndexOf(Me)
				End If

				Return _index
			End Get
			Friend Set
				_index = value
			End Set
		End Property

		<Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public ReadOnly Property ImageList() As ImageList
			Get
				If Me._grid IsNot Nothing Then
					Return Me._grid.ImageList
				Else
					Return Nothing
				End If
			End Get
		End Property

		Private Function ShouldSerializeImageIndex() As Boolean
			Return (Me._imageIndex <> -1 AndAlso Me._image Is Nothing)
		End Function

		<Category("Appearance"), Description("..."), DefaultValue(-1), TypeConverter(GetType(ImageIndexConverter)), Editor("System.Windows.Forms.Design.ImageIndexEditor", GetType(UITypeEditor))> _
		Public Property ImageIndex() As Integer
			Get
				Return _imageIndex
			End Get
			Set
				_imageIndex = value
				If _imageIndex <> -1 Then
					' when a imageIndex is provided we do not store the image.
					Me._image = Nothing
				End If
				If Me._isSited Then
					' when the image changes the cell's style must be updated
					Me._treeCell.UpdateStyle()
					If Me.Displayed Then
						Me._grid.InvalidateRow(Me.RowIndex)
					End If
				End If
			End Set
		End Property

		Private Function ShouldSerializeImage() As Boolean
			Return (Me._imageIndex = -1 AndAlso Me._image IsNot Nothing)
		End Function

		Public Property Image() As Image
			Get
				If _image Is Nothing AndAlso _imageIndex <> -1 Then
					If Me.ImageList IsNot Nothing AndAlso Me._imageIndex < Me.ImageList.Images.Count Then
						' get image from image index
						Return Me.ImageList.Images(Me._imageIndex)
					Else
						Return Nothing
					End If
				Else
					' image from image property
					Return Me._image
				End If
				

			End Get
			Set
				_image = value
				If _image IsNot Nothing Then
					' when a image is provided we do not store the imageIndex.
					Me._imageIndex = -1
				End If
				If Me._isSited Then
					' when the image changes the cell's style must be updated
					Me._treeCell.UpdateStyle()
					If Me.Displayed Then
						Me._grid.InvalidateRow(Me.RowIndex)
					End If
				End If
			End Set
		End Property

		Protected Overrides Function CreateCellsInstance() As DataGridViewCellCollection
			Dim cells As DataGridViewCellCollection = MyBase.CreateCellsInstance()
			AddHandler cells.CollectionChanged, AddressOf cells_CollectionChanged
			Return cells
		End Function

		Private Sub cells_CollectionChanged(sender As Object, e As System.ComponentModel.CollectionChangeEventArgs)
			' Exit if there already is a tree cell for this row
			If _treeCell IsNot Nothing Then
				Return
			End If

			If e.Action = System.ComponentModel.CollectionChangeAction.Add OrElse e.Action = System.ComponentModel.CollectionChangeAction.Refresh Then
				Dim treeCell As TreeGridCell = Nothing

				If e.Element Is Nothing Then
					For Each cell As DataGridViewCell In MyBase.Cells
						If cell.[GetType]().IsAssignableFrom(GetType(TreeGridCell)) Then
							treeCell = DirectCast(cell, TreeGridCell)
							Exit For

						End If
					Next
				Else
					treeCell = TryCast(e.Element, TreeGridCell)
				End If

				If treeCell IsNot Nothing Then
					_treeCell = treeCell
				End If
			End If
		End Sub

		<Category("Data"), Description("The collection of root nodes in the treelist."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Editor(GetType(CollectionEditor), GetType(UITypeEditor))> _
		Public Property Nodes() As TreeGridNodeCollection
			Get
				If childrenNodes Is Nothing Then
					childrenNodes = New TreeGridNodeCollection(Me)
				End If
				Return childrenNodes
			End Get
			Set
				

			End Set
		End Property

		' Create a new Cell property because by default a row is not in the grid and won't
		' have any cells. We have to fabricate the cell collection ourself.
		<Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows ReadOnly Property Cells() As DataGridViewCellCollection
			Get
				If Not childCellsCreated AndAlso Me.DataGridView Is Nothing Then
					If Me._grid Is Nothing Then
						Return Nothing
					End If

					Me.CreateCells(Me._grid)
					childCellsCreated = True
				End If
				Return MyBase.Cells
			End Get
		End Property

		<Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public ReadOnly Property Level() As Integer
			Get
				If Me._level = -1 Then
					' calculate level
					Dim walk As Integer = 0
					Dim walkRow As TreeGridNode = Me.Parent
					While walkRow IsNot Nothing
						walk += 1
						walkRow = walkRow.Parent
					End While
					Me._level = walk
				End If
				Return Me._level
			End Get
		End Property

		<Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public ReadOnly Property Parent() As TreeGridNode
			Get
				Return Me._parent
			End Get
		End Property

		<Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Overridable ReadOnly Property HasChildren() As Boolean
			Get
				Return (Me.childrenNodes IsNot Nothing AndAlso Me.Nodes.Count <> 0)
			End Get
		End Property

		<Browsable(False)> _
		Public ReadOnly Property IsSited() As Boolean
			Get
				Return Me._isSited
			End Get
		End Property
		<Browsable(False)> _
		Public ReadOnly Property IsFirstSibling() As Boolean
			Get
				Return (Me.Index = 0)
			End Get
		End Property

		<Browsable(False)> _
		Public ReadOnly Property IsLastSibling() As Boolean
			Get
				Dim parent As TreeGridNode = Me.Parent
				If parent IsNot Nothing AndAlso parent.HasChildren Then
                    Return (Me.Index = parent.Nodes.Count - 1)
				Else
					Return True
				End If
			End Get
		End Property

		Public Overridable Function Collapse() As Boolean
			Return Me._grid.CollapseNode(Me)
		End Function

		Public Overridable Function Expand() As Boolean
			If Me._grid IsNot Nothing Then
				Return Me._grid.ExpandNode(Me)
			Else
				Me.IsExpanded = True
				Return True
			End If
		End Function

		Protected Friend Overridable Function InsertChildNode(index As Integer, node As TreeGridNode) As Boolean
			node._parent = Me
			node._grid = Me._grid

			' ensure that all children of this node has their grid set
			If Me._grid IsNot Nothing Then
				UpdateChildNodes(node)
			End If

			'TODO: do we need to use index parameter?
			If (Me._isSited OrElse Me.IsRoot) AndAlso Me.IsExpanded Then
				Me._grid.SiteNode(node)
			End If
			Return True
		End Function

		Protected Friend Overridable Function InsertChildNodes(index As Integer, ParamArray nodes As TreeGridNode()) As Boolean
			For Each node As TreeGridNode In nodes
				Me.InsertChildNode(index, node)
			Next
			Return True
		End Function

		Protected Friend Overridable Function AddChildNode(node As TreeGridNode) As Boolean
			node._parent = Me
			node._grid = Me._grid

			' ensure that all children of this node has their grid set
			If Me._grid IsNot Nothing Then
				UpdateChildNodes(node)
			End If

			If (Me._isSited OrElse Me.IsRoot) AndAlso Me.IsExpanded AndAlso Not node._isSited Then
				Me._grid.SiteNode(node)
			End If

			Return True
		End Function
		Protected Friend Overridable Function AddChildNodes(ParamArray nodes As TreeGridNode()) As Boolean
			'TODO: Convert the final call into an SiteNodes??
			For Each node As TreeGridNode In nodes
				Me.AddChildNode(node)
			Next
			Return True

		End Function

		Protected Friend Overridable Function RemoveChildNode(node As TreeGridNode) As Boolean
			If (Me.IsRoot OrElse Me._isSited) AndAlso Me.IsExpanded Then
				'We only unsite out child node if we are sited and expanded.

				Me._grid.UnSiteNode(node)
			End If
			node._grid = Nothing
			node._parent = Nothing
			Return True

		End Function

		Protected Friend Overridable Function ClearNodes() As Boolean
			If Me.HasChildren Then
				For i As Integer = Me.Nodes.Count - 1 To 0 Step -1
					Me.Nodes.RemoveAt(i)
				Next
			End If
			Return True
		End Function

        '<Browsable(False), EditorBrowsable(EditorBrowsableState.Advanced)> _
        'Public Custom Event Disposed As EventHandler
        '    AddHandler(ByVal value As EventHandler)
        '        Me.disposed = DirectCast([Delegate].Combine(Me.disposed, value), EventHandler)
        '    End AddHandler
        '    RemoveHandler(ByVal value As EventHandler)
        '        Me.disposed = DirectCast([Delegate].Remove(Me.disposed, value), EventHandler)
        '    End RemoveHandler
        'End Event

		<Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Property Site() As ISite
			Get
				Return Me.m_site
			End Get
			Set
				Me.m_site = value
			End Set
		End Property

		Private Sub UpdateChildNodes(node As TreeGridNode)
			If node.HasChildren Then
				For Each childNode As TreeGridNode In node.Nodes
					childNode._grid = node._grid
					Me.UpdateChildNodes(childNode)
				Next
			End If
		End Sub

		Public Overrides Function ToString() As String
			Dim sb As New StringBuilder(36)
			sb.Append("TreeGridNode { Index=")
			sb.Append(Me.RowIndex.ToString(System.Globalization.CultureInfo.CurrentCulture))
			sb.Append(" }")
			Return sb.ToString()
		End Function

		'protected override void Dispose(bool disposing) {
		'    if (disposing)
		'    {
		'        lock(this)
		'        {
		'            if (this.site != null && this.site.Container != null)
		'            {
		'                this.site.Container.Remove(this);
		'            }

		'            if (this.disposed != null)
		'            {
		'                this.disposed(this, EventArgs.Empty);
		'            }
		'        }
		'    }

		'    base.Dispose(disposing);
		'}
	End Class

End Namespace
