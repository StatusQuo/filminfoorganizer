Imports System.Drawing
Imports System.ComponentModel
Module ImageQuality
    Public ims As System.Drawing.Imaging.PixelFormat = System.Drawing.Imaging.PixelFormat.Format32bppArgb

End Module

Public NotInheritable Class Rendering
    Private bgcContext As BufferedGraphicsContext 'Erzeugt den buffer
    Private clrBackColor As Color = Color.Black 'Hintergrundfarbe

    Public Property BackColor() As Color
        Get
            Return clrBackColor
        End Get
        Set(ByVal value As Color)
            clrBackColor = value
        End Set
    End Property

    Public Sub Render(ByVal surface As Graphics)
        'erzeugt das BufferedGraphics-Objekt für ein Graphics-Objekt
        Dim bg As BufferedGraphics = bgcContext.Allocate(surface, Rectangle.Round(surface.ClipBounds))
        Draw(bg)
        bg.Render()
        bg.Dispose()
    End Sub

    Public Sub Render(ByVal surface As Graphics, ByVal clipRectangle As Rectangle)
        'erzeugt das BufferedGraphics-Objekt für ein Graphics-Objekt
        Dim bg As BufferedGraphics = bgcContext.Allocate(surface, Rectangle.Round(clipRectangle))
        Draw(bg)
        bg.Render()
        bg.Dispose()
    End Sub

    Public Sub Render(ByVal deviceContext As IDeviceContext, ByVal clipRectangle As Rectangle, ByVal p As Integer)
        'erzeugt das BufferedGraphics-Objekt für ein DeviceContext-Objekt
        Dim bg As BufferedGraphics = bgcContext.Allocate(deviceContext.GetHdc, clipRectangle)

        Draw(bg, clipRectangle, p)
        bg.Render()
        bg.Dispose()
    End Sub

    Private Sub Draw(ByVal bufferedSurface As BufferedGraphics)
        With bufferedSurface.Graphics
            'zeichnen
            .Clear(clrBackColor)
            .FillEllipse(Brushes.Blue, 100, 100, 10, 10)
        End With
    End Sub

    Public Sub New()
        bgcContext = BufferedGraphicsManager.Current
    End Sub

    Public Sub New(ByVal context As BufferedGraphicsContext)
        bgcContext = context
    End Sub

    Private Sub Draw(ByVal bg As BufferedGraphics, ByVal cellbounds As Rectangle, ByVal p As Integer)
        With bg.Graphics


        End With
    End Sub

End Class


Public Class DataGridViewCombiColumn
    Inherits DataGridViewImageColumn
    Public Sub New()
        Me.CellTemplate = New DataGridViewCombiCell
    End Sub


End Class
Public Class DataGridViewCombiCell
    Inherits DataGridViewImageCell

    Sub New()
        ValueType = Type.GetType("String")
    End Sub
    ' Method required to make the Progress Cell consistent with the default Image Cell. 
    ' The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an Integer.
    Protected Overrides Function GetFormattedValue( _
        ByVal value As Object, _
        ByVal rowIndex As Integer, _
        ByRef cellStyle As DataGridViewCellStyle, _
        ByVal valueTypeConverter As TypeConverter, _
        ByVal formattedValueTypeConverter As TypeConverter, _
        ByVal context As DataGridViewDataErrorContexts _
        ) As Object
        Static emptyImage As Bitmap = New Bitmap(1, 1, ImageQuality.ims)
        GetFormattedValue = emptyImage
    End Function

    Protected Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal clipBounds As System.Drawing.Rectangle, ByVal cellBounds As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal cellState As System.Windows.Forms.DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal advancedBorderStyle As System.Windows.Forms.DataGridViewAdvancedBorderStyle, ByVal paintParts As System.Windows.Forms.DataGridViewPaintParts)
        Dim m As Movie = CType(Me.DataGridView.Rows(rowIndex).Tag, Movie)
        Dim foreBrush As Brush = New SolidBrush(cellStyle.ForeColor)
        Dim grayBrush As Brush = New SolidBrush(SystemColors.GrayText)
        Dim bluBrush As Brush = New SolidBrush(Color.DodgerBlue)
        Dim redBrush As Brush = New SolidBrush(Color.DarkRed)
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        'g.TextRenderingHint = Text.TextRenderingHint.AntiAliasGridFit AndAlso Text.TextRenderingHint.SystemDefault

        If Me.DataGridView.Rows(rowIndex).Selected = True Then
            foreBrush = New SolidBrush(cellStyle.SelectionForeColor)
            bluBrush = foreBrush
        End If



        MyBase.Paint(g, clipBounds, cellBounds, rowIndex, cellState, _
    value, formattedValue, errorText, cellStyle, _
    advancedBorderStyle, paintParts)

        Dim x As Integer = 10
        'Titel
        g.DrawString(m.Titel, cellStyle.Font, foreBrush, cellBounds.X + x, cellBounds.Y + 2)
        x = CInt(x + g.MeasureString(m.Titel, cellStyle.Font).Width)
        'Jahr
        g.DrawString(" - " & m.Produktionsjahr, cellStyle.Font, grayBrush, cellBounds.X + x, cellBounds.Y + 2)
        x = CInt(x + g.MeasureString(" - " & m.Produktionsjahr, cellStyle.Font).Width)
        'Quali
        Dim s As String = m.VideoAuflösung
        If Not s.EndsWith("p") Then
            s &= "p"
        End If
        g.DrawString(s, cellStyle.Font, bluBrush, cellBounds.X + x, cellBounds.Y + 2)
        x = CInt(x + g.MeasureString(s, cellStyle.Font).Width)
        'If Not m.Cover = "" Then
        '    g.DrawImage(MyFunctions.ImageFromJpeg(m.Cover), cellBounds.X, cellBounds.Y, CInt(cellBounds.Height / 1.5), cellBounds.Height)
        'End If


        'Cover
        If m.State_Cover = 0 Then
            g.DrawString("Cover", cellStyle.Font, redBrush, cellBounds.X + x, cellBounds.Y + 2)
            x = CInt(x + g.MeasureString("Cover", cellStyle.Font).Width)
        End If



    End Sub
End Class
Public Class DataGridViewProgressColumn
    Inherits DataGridViewImageColumn
    Public Sub New()
        Me.CellTemplate = New DataGridViewProgressCell
    End Sub


End Class
Public Class DataGridViewProgressCell
    Inherits DataGridViewImageCell

    Sub New()
        ValueType = Type.GetType("Integer")
    End Sub
    ' Method required to make the Progress Cell consistent with the default Image Cell. 
    ' The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an Integer.
    Protected Overrides Function GetFormattedValue( _
        ByVal value As Object, _
        ByVal rowIndex As Integer, _
        ByRef cellStyle As DataGridViewCellStyle, _
        ByVal valueTypeConverter As TypeConverter, _
        ByVal formattedValueTypeConverter As TypeConverter, _
        ByVal context As DataGridViewDataErrorContexts _
        ) As Object


        Static emptyImage As Bitmap = New Bitmap(1, 1, ImageQuality.ims)
        GetFormattedValue = emptyImage
        'Static emptyImage As Bitmap = New Bitmap(CInt(value), 10, ImageQuality.ims)
        'Dim g As Graphics = Graphics.FromImage(emptyImage)
        'g.FillRectangle(New SolidBrush(cellStyle.ForeColor), 1, 1, CInt(value), 4)

        'GetFormattedValue = emptyImage
    End Function

    Protected Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal clipBounds As System.Drawing.Rectangle, ByVal cellBounds As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal cellState As System.Windows.Forms.DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal advancedBorderStyle As System.Windows.Forms.DataGridViewAdvancedBorderStyle, ByVal paintParts As System.Windows.Forms.DataGridViewPaintParts)
        Dim progressVal As Integer = CType(value, Integer)
        Dim percentage As Single = CType((progressVal / 100), Single)
        Dim backBrush As Brush = New SolidBrush(cellStyle.BackColor)
        Dim foreBrush As Brush = New SolidBrush(cellStyle.ForeColor)
        ' Call the base class method to paint the default cell appearance.
        MyBase.Paint(g, clipBounds, cellBounds, rowIndex, cellState, _
            value, formattedValue, errorText, cellStyle, _
            advancedBorderStyle, paintParts)
        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighSpeed
        If percentage > 0.0 Then
            ' Draw the progress bar and the text

            Dim c As Color
            c = Color.FromArgb(51, 153, 51)

            Dim c2 As Color
            c2 = Color.FromArgb(51, 153, 51)
            'If Main.DataGridView1.Rows(rowIndex).Selected Then
            'Debug.WriteLine(percentage)

            c = Color.FromArgb(123, 183, 38)
            c2 = Color.FromArgb(90, 133, 30)
            If percentage < 0.3 Then
                c = Color.FromArgb(255, 66, 0)
            ElseIf percentage < 0.7 Then
                c = Color.FromArgb(220, 192, 36)
            ElseIf percentage < 0.9 Then
                c = Color.FromArgb(153, 204, 0)
            End If

            'Debug.WriteLine(percentage)
            If percentage < 0.3 Then
                c2 = Color.FromArgb(162, 42, 0)
            ElseIf percentage < 0.7 Then
                c2 = Color.FromArgb(146, 128, 25)
            ElseIf percentage < 0.9 Then
                c2 = Color.FromArgb(90, 133, 30)
            End If
            'Else
            '    c = Color.FromArgb(153, 123, 183, 38)
            '    c2 = Color.FromArgb(71, 159, 18)
            '    'Debug.WriteLine(percentage)
            '    If percentage < 0.3 Then
            '        c = Color.FromArgb(153, 255, 66, 0)
            '    ElseIf percentage < 0.7 Then
            '        c = Color.FromArgb(153, 220, 192, 36)
            '    ElseIf percentage < 0.9 Then
            '        c = Color.FromArgb(153, 153, 204, 0)
            '    End If

            '    'Debug.WriteLine(percentage)
            '    If percentage < 0.3 Then
            '        c2 = Color.FromArgb(214, 35, 31)
            '    ElseIf percentage < 0.7 Then
            '        c2 = Color.FromArgb(222, 157, 18)
            '    ElseIf percentage < 0.9 Then
            '        c2 = Color.FromArgb(71, 159, 18)
            '    End If
            'End If

            Dim rect2 As New Rectangle(cellBounds.X + 2, cellBounds.Y + 3, Convert.ToInt32((1 * cellBounds.Width)) - 6, cellBounds.Height - 7)

            Dim rect As New Rectangle(cellBounds.X + 2, cellBounds.Y + 3, Convert.ToInt32((percentage * cellBounds.Width)) - 6, cellBounds.Height - 7)
            Dim b As New SolidBrush(c)
            Dim b2 As New SolidBrush(c2)
            Dim b3 As New Drawing.SolidBrush(Color.LightGray)
            Dim b4 As New Drawing.SolidBrush(Color.Gray)
            g.FillRectangle(b4, rect2)
            g.FillRectangle(b3, rect2.Left + 1, rect2.Top + 1, rect2.Width - 2, rect2.Height - 2)
            g.FillRectangle(b2, rect)
            g.FillRectangle(b, rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2)
            'Dim rc2 As RectangleF = mygraphics.DrawRoundedRectangle(g, rect.Left, rect.Top, rect.Width, rect.Height, 6, c2)
            'g.FillRectangle(b, rect.Left + 1, rect.Top + 2, 1, rect.Height - 3)

            'g.FillRectangle(b, rect.Left + 2, rect.Top + 1, rect.Width - 3, rect.Height - 1)


            'g.FillRectangle(b, rect.Left + rect.Width - 1, rect.Top + 2, 1, rect.Height - 3)



            'g.FillRectangle(b, rc2)
            'e.Item.ForeColor = Color.Black

            'g.FillRectangle(New SolidBrush(c), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 4)
            'g.FillRectangle(New SolidBrush(c), cellBounds.X, cellBounds.Y + 4, Convert.ToInt32((percentage * cellBounds.Width)), cellBounds.Height - 8)

            g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreBrush, cellBounds.X + 6, cellBounds.Y + 2)

        Else
            'draw the text
            If Not Me.DataGridView.CurrentCell Is Nothing AndAlso Me.DataGridView.CurrentCell.RowIndex = rowIndex Then
                g.DrawString(progressVal.ToString() & "%", cellStyle.Font, New SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + 6, cellBounds.Y + 2)
            Else
                g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreBrush, cellBounds.X + 6, cellBounds.Y + 2)
            End If
        End If
    End Sub
End Class

Public Class DataGridViewDownloadProgressColumn
    Inherits DataGridViewImageColumn
    Public Sub New()
        Me.CellTemplate = New DataGridViewDownloadProgressCell
    End Sub


End Class
Public Class DataGridViewDownloadProgressCell
    Inherits DataGridViewImageCell

    Sub New()
        ValueType = Type.GetType("Integer")
    End Sub
    ' Method required to make the Progress Cell consistent with the default Image Cell. 
    ' The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an Integer.
    Protected Overrides Function GetFormattedValue( _
        ByVal value As Object, _
        ByVal rowIndex As Integer, _
        ByRef cellStyle As DataGridViewCellStyle, _
        ByVal valueTypeConverter As TypeConverter, _
        ByVal formattedValueTypeConverter As TypeConverter, _
        ByVal context As DataGridViewDataErrorContexts _
        ) As Object
        Static emptyImage As Bitmap = New Bitmap(1, 1, ImageQuality.ims)
        GetFormattedValue = emptyImage
    End Function

    Protected Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal clipBounds As System.Drawing.Rectangle, ByVal cellBounds As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal cellState As System.Windows.Forms.DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal advancedBorderStyle As System.Windows.Forms.DataGridViewAdvancedBorderStyle, ByVal paintParts As System.Windows.Forms.DataGridViewPaintParts)
        Dim progressVal As Integer = CType(value, Integer)
        Dim percentage As Single = CType((progressVal / 100), Single)
        Dim backBrush As Brush = New SolidBrush(cellStyle.BackColor)
        Dim foreBrush As Brush = New SolidBrush(cellStyle.ForeColor)
        ' Call the base class method to paint the default cell appearance.
        MyBase.Paint(g, clipBounds, cellBounds, rowIndex, cellState, _
            value, formattedValue, errorText, cellStyle, _
            advancedBorderStyle, paintParts)

        If progressVal > 100 Then
            progressVal = CInt(progressVal / 100)
            percentage = CType((progressVal / 100), Single)
            Dim c As Color
            c = Color.FromArgb(51, 175, 247)
            Dim c2 As Color
            c2 = Color.FromArgb(13, 121, 184)
            'Dim c As Color
            'c = Color.FromArgb(153, 204, 0)
            'Dim c2 As Color
            'c2 = Color.FromArgb(90, 133, 30)
            Dim rect2 As New Rectangle(cellBounds.X + 2, cellBounds.Y + 3, Convert.ToInt32((1 * cellBounds.Width)) - 6, cellBounds.Height - 7)

            Dim rect As New Rectangle(cellBounds.X + 2, cellBounds.Y + 3, Convert.ToInt32((percentage * cellBounds.Width)) - 6, cellBounds.Height - 7)
            Dim b As New SolidBrush(c)
            Dim b2 As New SolidBrush(c2)
            Dim b3 As New Drawing.SolidBrush(Color.FromArgb(227, 245, 254))
            Dim b4 As New Drawing.SolidBrush(Color.FromArgb(2, 135, 197))
            g.FillRectangle(b4, rect2)
            g.FillRectangle(b3, rect2.Left + 1, rect2.Top + 1, rect2.Width - 2, rect2.Height - 2)
            g.FillRectangle(b2, rect)
            g.FillRectangle(b, rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2)
            g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreBrush, cellBounds.X + 6, cellBounds.Y + 2)

        Else
            If percentage > 0.0 Then
                ' Draw the progress bar and the text


                Dim c As Color
                c = Color.FromArgb(227, 245, 254)

                Dim c2 As Color
                c2 = Color.FromArgb(2, 135, 197)
                Dim rect2 As New Rectangle(cellBounds.X + 2, cellBounds.Y + 3, Convert.ToInt32((1 * cellBounds.Width)) - 6, cellBounds.Height - 7)

                Dim rect As New Rectangle(cellBounds.X + 2, cellBounds.Y + 3, Convert.ToInt32((percentage * cellBounds.Width)) - 6, cellBounds.Height - 7)
                Dim b As New SolidBrush(c)
                Dim b2 As New SolidBrush(c2)
                Dim b3 As New Drawing.SolidBrush(Color.White)
                Dim b4 As New Drawing.SolidBrush(Color.Gray)
                g.FillRectangle(b4, rect2)
                g.FillRectangle(b3, rect2.Left + 1, rect2.Top + 1, rect2.Width - 2, rect2.Height - 2)
                g.FillRectangle(b2, rect)
                g.FillRectangle(b, rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2)
                g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreBrush, cellBounds.X + 6, cellBounds.Y + 2)
            Else


                Dim rect2 As New Rectangle(cellBounds.X + 2, cellBounds.Y + 3, Convert.ToInt32((1 * cellBounds.Width)) - 6, cellBounds.Height - 7)

                Dim rect As New Rectangle(cellBounds.X + 2, cellBounds.Y + 3, Convert.ToInt32((percentage * cellBounds.Width)) - 6, cellBounds.Height - 7)
                'Dim b As New SolidBrush(c)
                'Dim b2 As New SolidBrush(c2)
                Dim b3 As New Drawing.SolidBrush(Color.White)
                Dim b4 As New Drawing.SolidBrush(Color.Gray)
                g.FillRectangle(b4, rect2)
                g.FillRectangle(b3, rect2.Left + 1, rect2.Top + 1, rect2.Width - 2, rect2.Height - 2)
                'g.FillRectangle(b2, rect)
                'g.FillRectangle(b, rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2)
                g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreBrush, cellBounds.X + 6, cellBounds.Y + 2)

                'draw the text
                'If Not Me.DataGridView.CurrentCell Is Nothing AndAlso Me.DataGridView.CurrentCell.RowIndex = rowIndex Then
                '    g.DrawString(progressVal.ToString() & "%", cellStyle.Font, New SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + 6, cellBounds.Y + 2)
                'Else
                '    g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreBrush, cellBounds.X + 6, cellBounds.Y + 2)
                'End If
            End If
        End If


    End Sub
End Class

Public Class DataGridViewRateColumn
    Inherits DataGridViewImageColumn
    Public Sub New()
        Me.CellTemplate = New DataGridViewRateCell
    End Sub
End Class



Public Module RateSymbols
    Public green As Bitmap = New Bitmap(16, 16, ImageQuality.ims)
    Public orange As Bitmap = New Bitmap(16, 16, ImageQuality.ims)
    Public red As Bitmap = New Bitmap(16, 16, ImageQuality.ims)
    Sub New()
        Dim g As Graphics
        Dim cHell As Color
        Dim cDunkel As Color
        Dim außen As New Rectangle(0, 0, 16, 16)
        Dim innen As New Rectangle(1, 1, 14, 14)
        Dim dunkel As SolidBrush
        Dim hell As SolidBrush

        g = Graphics.FromImage(red)
        cHell = Color.FromArgb(255, 66, 0)
        cDunkel = Color.FromArgb(162, 42, 0)

        dunkel = New SolidBrush(cDunkel)
        hell = New SolidBrush(cHell)
        g.FillRectangle(dunkel, außen)
        g.FillRectangle(hell, innen)

        g = Graphics.FromImage(orange)
        cHell = Color.FromArgb(220, 192, 36)
        cDunkel = Color.FromArgb(146, 128, 25)

        dunkel = New SolidBrush(cDunkel)
        hell = New SolidBrush(cHell)
        g.FillRectangle(dunkel, außen)
        g.FillRectangle(hell, innen)



        g = Graphics.FromImage(green)
        cHell = Color.FromArgb(153, 204, 0)
        cDunkel = Color.FromArgb(90, 133, 30)

        dunkel = New SolidBrush(cDunkel)
        hell = New SolidBrush(cHell)
        g.FillRectangle(dunkel, außen)
        g.FillRectangle(hell, innen)



    End Sub

End Module


Public Class DataGridViewRateCell

    Inherits DataGridViewImageCell
    Dim i As Integer = 0
    Dim its As Image
    Sub New()
        ValueType = Type.GetType("Integer")
    End Sub
    ' Method required to make the Progress Cell consistent with the default Image Cell. 
    ' The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an Integer.
    Protected Overrides Function GetFormattedValue( _
        ByVal value As Object, _
        ByVal rowIndex As Integer, _
        ByRef cellStyle As DataGridViewCellStyle, _
        ByVal valueTypeConverter As TypeConverter, _
        ByVal formattedValueTypeConverter As TypeConverter, _
        ByVal context As DataGridViewDataErrorContexts _
        ) As Object
        Static emptyImage As Bitmap = New Bitmap(1, 1, ImageQuality.ims)
        Dim i As Integer = CType(value, Integer)
        Select Case i
            Case Is = 0
                GetFormattedValue = RateSymbols.red
            Case Is = 1
                GetFormattedValue = RateSymbols.orange
            Case Is = 2
                GetFormattedValue = RateSymbols.green
            Case Else
                GetFormattedValue = emptyImage
        End Select


    End Function

    'Protected Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal clipBounds As System.Drawing.Rectangle, ByVal cellBounds As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal cellState As System.Windows.Forms.DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal advancedBorderStyle As System.Windows.Forms.DataGridViewAdvancedBorderStyle, ByVal paintParts As System.Windows.Forms.DataGridViewPaintParts)
    '    Dim progressVal As Integer = CType(value, Integer)

    '    Dim backBrush As Brush = New SolidBrush(cellStyle.BackColor)
    '    Dim foreBrush As Brush = New SolidBrush(cellStyle.ForeColor)
    '    ' Call the base class method to paint the default cell appearance.
    '    MyBase.Paint(g, clipBounds, cellBounds, rowIndex, cellState, _
    '        value, formattedValue, errorText, cellStyle, _
    '        advancedBorderStyle, paintParts)

    '    Dim c As Color
    '    Dim c2 As Color

    '    c = Color.FromArgb(255, 66, 0)
    '    c2 = Color.FromArgb(162, 42, 0)

    '    If progressVal = 1 Then
    '        c = Color.FromArgb(220, 192, 36)
    '        c2 = Color.FromArgb(146, 128, 25)
    '    ElseIf progressVal = 2 Then
    '        c = Color.FromArgb(153, 204, 0)
    '        c2 = Color.FromArgb(90, 133, 30)
    '    End If

    '    Dim b As New SolidBrush(c)

    '    Dim b2 As New SolidBrush(c2)
    '    Dim ca As New Rectangle(CInt((cellBounds.Width / 2) - 8) + cellBounds.X, CInt((cellBounds.Height / 2) - 8) + cellBounds.Y, 16, 16)
    '    Dim recti As New Rectangle(CInt((cellBounds.Width / 2) - 7) + cellBounds.X, CInt((cellBounds.Height / 2) - 7) + cellBounds.Y, 14, 14)

    '    g.FillRectangle(b2, ca)
    '    g.FillRectangle(b, recti)

    'End Sub
End Class

Public Class DataGridViewSizeColumn
    Inherits DataGridViewTextBoxColumn
    Public Sub New()
        Me.CellTemplate = New DataGridViewSizeCell
    End Sub
End Class
Public Class DataGridViewSizeCell
    Inherits DataGridViewTextBoxCell

    Sub New()
        ValueType = Type.GetType("Long")
    End Sub
    ' Method required to make the Progress Cell consistent with the default Image Cell. 
    ' The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an Integer.
    Protected Overrides Function GetFormattedValue(ByVal value As Object, ByVal rowIndex As Integer, ByRef cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal valueTypeConverter As System.ComponentModel.TypeConverter, ByVal formattedValueTypeConverter As System.ComponentModel.TypeConverter, ByVal context As System.Windows.Forms.DataGridViewDataErrorContexts) As Object
        Return WebFunctions.FormatKiloBytes(CLng(value))

    End Function

End Class
Public Class DataGridViewFlagColumn
    Inherits DataGridViewImageColumn
    Public Sub New()
        Me.CellTemplate = New DataGridViewFlagCell
    End Sub
End Class
Public Class DataGridViewFlagCell
    Inherits DataGridViewImageCell

    Sub New()
        ValueType = Type.GetType("Integer")
    End Sub
    ' Method required to make the Progress Cell consistent with the default Image Cell. 
    ' The default Image Cell assumes an Image as a value, although the value of the Progress Cell is an Integer.
    Protected Overrides Function GetFormattedValue( _
        ByVal value As Object, _
        ByVal rowIndex As Integer, _
        ByRef cellStyle As DataGridViewCellStyle, _
        ByVal valueTypeConverter As TypeConverter, _
        ByVal formattedValueTypeConverter As TypeConverter, _
        ByVal context As DataGridViewDataErrorContexts _
        ) As Object
        Static emptyImage As Bitmap = New Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format16bppArgb1555)
        GetFormattedValue = emptyImage
    End Function

    Protected Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal clipBounds As System.Drawing.Rectangle, ByVal cellBounds As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal cellState As System.Windows.Forms.DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal advancedBorderStyle As System.Windows.Forms.DataGridViewAdvancedBorderStyle, ByVal paintParts As System.Windows.Forms.DataGridViewPaintParts)
        Dim progressVal As Integer = CType(value, Integer)

        Dim backBrush As Brush = New SolidBrush(cellStyle.BackColor)
        Dim foreBrush As Brush = New SolidBrush(cellStyle.ForeColor)
        ' Call the base class method to paint the default cell appearance.
        MyBase.Paint(g, clipBounds, cellBounds, rowIndex, cellState, _
            value, formattedValue, errorText, cellStyle, _
            advancedBorderStyle, paintParts)

        ' Draw the progress bar and the text


        'g.FillRectangle(New SolidBrush(c), cellBounds.X + 2, cellBounds.Y + 2, cellBounds.Width - 4, cellBounds.Height - 4)

        Dim img As Image = Nothing


        If progressVal = 1 Then
            img = Toolbar16.flag_new_qm
        ElseIf progressVal = 2 Then
            img = Toolbar16.flag_new
        ElseIf progressVal = 3 Then
            img = Toolbar16.Favoriten
        ElseIf progressVal = 4 Then
            img = Toolbar16.staty_16_cover_test
        ElseIf progressVal = 5 Then
            img = Toolbar16.staty_16_fanart
        ElseIf progressVal = 6 Then
            img = Toolbar16.staty_16_info
        ElseIf progressVal = 7 Then
            img = Toolbar16.Down
        ElseIf progressVal = 8 Then
            img = Toolbar16.flag_wichtig
        End If

        Dim ca As New Rectangle(CInt((cellBounds.Width / 2) - 8) + cellBounds.X, CInt((cellBounds.Height / 2) - 8) + cellBounds.Y, 16, 16)
        'Dim ca As New Rectangle(cellBounds.X, cellBounds.Y, cellBounds.Width, cellBounds.Height)
        If Not img Is Nothing Then
            g.DrawImage(img, ca)
        End If



        'g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreBrush, cellBounds.X + 6, cellBounds.Y + 2)

        'Else
        '    'draw the text
        '    If Not Me.DataGridView.CurrentCell Is Nothing AndAlso Me.DataGridView.CurrentCell.RowIndex = rowIndex Then
        '        g.DrawString(progressVal.ToString() & "%", cellStyle.Font, New SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + 6, cellBounds.Y + 2)
        '    Else
        '        g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreBrush, cellBounds.X + 6, cellBounds.Y + 2)
        '    End If
    End Sub
End Class