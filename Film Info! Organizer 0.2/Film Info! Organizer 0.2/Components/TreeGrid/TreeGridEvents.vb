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
	Public Class TreeGridNodeEventBase
		Private _node As TreeGridNode

		Public Sub New(node As TreeGridNode)
			Me._node = node
		End Sub

		Public ReadOnly Property Node() As TreeGridNode
			Get
				Return _node
			End Get
		End Property
	End Class
	Public Class CollapsingEventArgs
		Inherits System.ComponentModel.CancelEventArgs
		Private _node As TreeGridNode

		Private Sub New()
		End Sub
		Public Sub New(node As TreeGridNode)
			MyBase.New()
			Me._node = node
		End Sub
		Public ReadOnly Property Node() As TreeGridNode
			Get
				Return _node
			End Get
		End Property

	End Class
	Public Class CollapsedEventArgs
		Inherits TreeGridNodeEventBase
		Public Sub New(node As TreeGridNode)
			MyBase.New(node)
		End Sub
	End Class

	Public Class ExpandingEventArgs
		Inherits System.ComponentModel.CancelEventArgs
		Private _node As TreeGridNode

		Private Sub New()
		End Sub
		Public Sub New(node As TreeGridNode)
			MyBase.New()
			Me._node = node
		End Sub
		Public ReadOnly Property Node() As TreeGridNode
			Get
				Return _node
			End Get
		End Property

	End Class
	Public Class ExpandedEventArgs
		Inherits TreeGridNodeEventBase
		Public Sub New(node As TreeGridNode)
			MyBase.New(node)
		End Sub
	End Class

	Public Delegate Sub ExpandingEventHandler(sender As Object, e As ExpandingEventArgs)
	Public Delegate Sub ExpandedEventHandler(sender As Object, e As ExpandedEventArgs)

	Public Delegate Sub CollapsingEventHandler(sender As Object, e As CollapsingEventArgs)
	Public Delegate Sub CollapsedEventHandler(sender As Object, e As CollapsedEventArgs)

End Namespace
