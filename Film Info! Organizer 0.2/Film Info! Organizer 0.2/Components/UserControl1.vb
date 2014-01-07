Public Class UserControl1
    Dim sChecked As Boolean
    Dim sCoop As UserControl1
    Public Property t As String
        Get
            Return TextBox1.Text
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value
        End Set
    End Property

    Public Property Multiline As Boolean
        Get
            Return TextBox1.Multiline
        End Get
        Set(ByVal value As Boolean)
            TextBox1.Multiline = value
            If value = True Then
                TextBox1.ScrollBars = ScrollBars.Vertical
            Else
                TextBox1.ScrollBars = ScrollBars.None
            End If
        End Set
    End Property

    Public Property Coop As UserControl1
        Get
            Return sCoop
        End Get
        Set(ByVal value As UserControl1)
            sCoop = value
        End Set
    End Property
    Public Property Checked As Boolean
        Get
            Return CheckBox1.Checked
        End Get
        Set(ByVal value As Boolean)
            CheckBox1.Checked = value
            Checkit(False)
        End Set
    End Property
    Private Sub PreviewCover_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave, CheckBox1.MouseLeave, TextBox1.MouseLeave, Panel1.MouseLeave

        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Else
            Me.BackColor = Color.Transparent
            Panel1.BackColor = Color.Transparent
        End If

    End Sub
    Private Sub PreviewCover_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter, CheckBox1.MouseEnter, TextBox1.MouseEnter, Panel1.MouseEnter
        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Else
            Me.BackColor = Color.FromArgb(100, 2, 135, 197)
            Panel1.BackColor = Color.FromArgb(242, 251, 255)
        End If
    End Sub

    Private Sub PreviewCover_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus, CheckBox1.GotFocus, TextBox1.GotFocus, Panel1.GotFocus
        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Else
            Me.BackColor = Color.FromArgb(100, 2, 135, 197)
            'Me.BackColor = Color.FromArgb(201, 234, 247)
            Panel1.BackColor = Color.FromArgb(242, 251, 255)
        End If
    End Sub

    Private Sub PreviewCover_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus, CheckBox1.LostFocus, TextBox1.LostFocus, Panel1.LostFocus
        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Else
            Me.BackColor = Color.Transparent
            Panel1.BackColor = Color.Transparent
        End If
    End Sub
    Sub Checkit(ByVal Change As Boolean)




        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
            If Not IsNothing(sCoop) And Change = True Then
                sCoop.Checked = False
            End If
        Else

            Me.BackColor = Color.Transparent
            Panel1.BackColor = Color.Transparent
            If Not IsNothing(sCoop) And Change = True Then
                sCoop.Checked = True
            End If
        End If


    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        Checkit(True)
        RaiseEvent CheckChanged()


    End Sub

    Private Sub Panel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Click

        Checked = Not Checked
        Checkit(True)
    End Sub
    Public Event CheckChanged()

End Class
