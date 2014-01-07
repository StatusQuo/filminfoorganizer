Imports System.Windows.Forms

Public Class Dialog_GenreSelect
    Public list As New List(Of Movie)
    Public d As Movie
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub tvw_ItemDrag2(ByVal sender As Object, ByVal e As ItemDragEventArgs) Handles TreeViewVista1.ItemDrag
        TreeViewVista1.DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub tvw_DragEnter2(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeViewVista1.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub tvw_DragDrop2(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeViewVista1.DragDrop
        Dim loc As Point = (CType(sender, TreeView)).PointToClient(New Point(e.X, e.Y))
        Dim node As TreeNode = CType(e.Data.GetData(GetType(TreeNode)), TreeNode)
        Dim destNode As TreeNode = (CType(sender, TreeView)).GetNodeAt(loc)

        If Not node Is destNode Then



            If node.Parent Is Nothing Then
                node.TreeView.Nodes.Remove(node)
            Else
                node.Parent.Nodes.Remove(node)
            End If
            If destNode Is Nothing Then
                TreeViewVista1.Nodes.Add(node)
            Else
                If destNode.Parent Is Nothing Then


                    destNode.TreeView.Nodes.Insert(destNode.Index + 1, node)

                Else
                    destNode.Parent.Nodes.Insert(destNode.Index + 1, node)
            End If
            End If
            TreeViewVista1.SelectedNode = node
            'Dim r As DataGridViewColumn = CType(node.Tag, DataGridViewColumn)
            'DataGridView1.Columns(r.Index).DisplayIndex = node.Index
            'r.DisplayIndex = node.Index
        End If
    End Sub
    Private Sub tvw_ItemDrag(ByVal sender As Object, ByVal e As ItemDragEventArgs) Handles TreeViewVista2.ItemDrag
        TreeViewVista2.DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub tvw_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeViewVista2.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub tvw_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeViewVista2.DragDrop
        Dim loc As Point = (CType(sender, TreeView)).PointToClient(New Point(e.X, e.Y))
        Dim node As TreeNode = CType(e.Data.GetData(GetType(TreeNode)), TreeNode)
        Dim destNode As TreeNode = (CType(sender, TreeView)).GetNodeAt(loc)

        If Not node Is destNode Then



            If node.Parent Is Nothing Then
                node.TreeView.Nodes.Remove(node)
            Else
                node.Parent.Nodes.Remove(node)
            End If

            If destNode.Parent Is Nothing Then
                destNode.TreeView.Nodes.Insert(destNode.Index + 1, node)
            Else
                destNode.Parent.Nodes.Insert(destNode.Index + 1, node)
            End If
            TreeViewVista2.SelectedNode = node
            'Dim r As DataGridViewColumn = CType(node.Tag, DataGridViewColumn)
            'DataGridView1.Columns(r.Index).DisplayIndex = node.Index
            'r.DisplayIndex = node.Index
        End If
    End Sub
    Public Sub Fill()
        If Einstellungen.GenreFilter.FilterList.Count > 0 Then
            For x As Integer = 0 To Einstellungen.GenreFilter.FilterList.Count - 1
                Dim r As Boolean = True
                For Each m In list
                    If m.Genre.Contains(Einstellungen.GenreFilter.FilterList(x).Name) Or m.Genre.Contains(Einstellungen.GenreFilter.FilterList(x).altName) Then
                    Else
                        r = False
                        Exit For
                    End If
                Next
                If r = True Then
                    TreeViewVista1.Nodes.Add(Einstellungen.GenreFilter.FilterList(x).Name)
                Else
                    TreeViewVista2.Nodes.Add(Einstellungen.GenreFilter.FilterList(x).Name)
                End If
            Next
        End If
    End Sub
    Public Sub Fill(ByVal m As String)
        If Einstellungen.GenreFilter.FilterList.Count > 0 Then
            For x As Integer = 0 To Einstellungen.GenreFilter.FilterList.Count - 1
                Dim r As Boolean = True
                If m.Contains(Einstellungen.GenreFilter.FilterList(x).Name) Or m.Contains(Einstellungen.GenreFilter.FilterList(x).altName) Then
                Else
                    r = False
                End If
                If r = True Then
                    TreeViewVista1.Nodes.Add(Einstellungen.GenreFilter.FilterList(x).Name)
                Else
                    TreeViewVista2.Nodes.Add(Einstellungen.GenreFilter.FilterList(x).Name)
                End If
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim node As TreeNode = TreeViewVista2.SelectedNode
        If Not node Is Nothing Then
            If node.Parent Is Nothing Then
                node.TreeView.Nodes.Remove(node)
            Else
                node.Parent.Nodes.Remove(node)
            End If
            TreeViewVista1.Nodes.Add(node)
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim node As TreeNode = TreeViewVista1.SelectedNode
        If Not node Is Nothing Then
            If node.Parent Is Nothing Then
                node.TreeView.Nodes.Remove(node)
            Else
                node.Parent.Nodes.Remove(node)
            End If
            TreeViewVista2.Nodes.Add(node)
        End If

    End Sub

    Private Sub Dialog_GenreSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Font = SystemFonts.MessageBoxFont
    End Sub

End Class
