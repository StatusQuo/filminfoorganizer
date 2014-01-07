Public Class ToolStripSeperator2
    Inherits ToolStripSeparator
    Property _width As Integer = 8
    Property _height As Integer = 0
    Sub New()
        If Me.AutoSize = True Then
            Me.AutoSize = False
            If Not Me.Parent Is Nothing Then
                If _height = 0 Then
                    Me.Size = New Size(_width, Me.Parent.Height)
                Else
                    Me.Size = New Size(Me.Size.Width, _height)
                End If
            End If
        End If

    End Sub
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If Me.AutoSize = True Then
            Me.AutoSize = False
            If Not Me.Parent Is Nothing Then
                If _height = 0 Then
                    Me.Size = New Size(_width, Me.Parent.Height)
                Else
                    Me.Size = New Size(Me.Size.Width, _height)
                End If
            End If
        End If
        MyBase.OnPaint(e)
    End Sub
    Protected Overrides Sub OnVisibleChanged(ByVal e As System.EventArgs)

        If Me.AutoSize = True Then
            Me.AutoSize = False
            If Not Me.Parent Is Nothing Then
                If _height = 0 Then
                    Me.Size = New Size(_width, Me.Parent.Height)
                Else
                    Me.Size = New Size(Me.Size.Width, _height)
                End If
            End If
        End If

        MyBase.OnVisibleChanged(e)
    End Sub
    Protected Overrides Sub OnParentChanged(ByVal oldParent As System.Windows.Forms.ToolStrip, ByVal newParent As System.Windows.Forms.ToolStrip)
        If Me.AutoSize = True Then
            Me.AutoSize = False
            If Not Me.Parent Is Nothing Then
                If _height = 0 Then
                    Me.Size = New Size(_width, Me.Parent.Height)
                Else
                    Me.Size = New Size(Me.Size.Width, _height)
                End If
            End If
        End If
        MyBase.OnParentChanged(oldParent, newParent)
    End Sub
End Class
