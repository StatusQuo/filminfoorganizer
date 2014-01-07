Imports System.Drawing.Drawing2D

Public Class mygraphics
    Public Shared Function DrawRoundedRectangle(ByVal objGraphics As Graphics, _
                            ByVal m_intxAxis As Integer, _
                            ByVal m_intyAxis As Integer, _
                            ByVal m_intWidth As Integer, _
                            ByVal m_intHeight As Integer, _
                            ByVal m_diameter As Integer, ByVal color As Color) As RectangleF

        Dim pen As New Pen(color)
        Dim pen2 As New Pen(color.FromArgb(153, color.R, color.G, color.B))
        'Dim g As Graphics
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))
        Dim ArcRect2 As New RectangleF(BaseRect.Location, New SizeF(CSng(m_diameter / 2), CSng(m_diameter / 2)))
        'top left Arc
        objGraphics.DrawArc(pen, ArcRect, 180, 90)
        objGraphics.DrawArc(pen2, ArcRect2, 180, 90)
        objGraphics.DrawLine(pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)

        'objGraphics.DrawLine(pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)
        ' top right arc
        ArcRect.X = BaseRect.Right - m_diameter
        ArcRect2.X = CSng(BaseRect.Right - (m_diameter / 2))
        objGraphics.DrawArc(pen, ArcRect, 270, 90)
        objGraphics.DrawArc(pen2, ArcRect2, 270, 90)
        objGraphics.DrawLine(pen, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        ArcRect2.Y = CSng(BaseRect.Bottom - (m_diameter / 2))
        objGraphics.DrawArc(pen, ArcRect, 0, 90)
        objGraphics.DrawArc(pen2, ArcRect2, 0, 90)
        objGraphics.DrawLine(pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis + m_intHeight)

        ' bottom left arc
        ArcRect.X = BaseRect.Left
        ArcRect2.X = BaseRect.Left
        objGraphics.DrawArc(pen, ArcRect, 90, 90)
        objGraphics.DrawArc(pen2, ArcRect2, 90, 90)
        objGraphics.DrawLine(pen, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))
        Return ArcRect
    End Function
    Public Shared Function DrawCoverShadow(ByVal img As Image) As Image



        Return DropShadow(CType(img, Bitmap), Color.Black, Color.Transparent, ShadowDirections.BOTTOM_RIGHT, 190, 4, 5)
    End Function

    Public Enum ShadowDirections As Integer
        TOP_RIGHT = 1
        BOTTOM_RIGHT = 2
        BOTTOM_LEFT = 3
        TOP_LEFT = 4
    End Enum

    <STAThread()> _
    Public Shared Function DropShadow(ByRef SourceImage As Drawing.Bitmap, _
                        ByVal ShadowColor As Drawing.Color, _
                        ByVal BackgroundColor As Drawing.Color, _
                        Optional ByVal ShadowDirection As ShadowDirections = _
                                              ShadowDirections.BOTTOM_RIGHT, _
                        Optional ByVal ShadowOpacity As Integer = 190, _
                        Optional ByVal ShadowSoftness As Integer = 4, _
                        Optional ByVal ShadowDistance As Integer = 5, _
                        Optional ByVal ShadowRoundedEdges As Boolean = True) As Bitmap
        Dim retur As Bitmap = SourceImage
        Dim ImgTarget As Bitmap = Nothing
        Dim ImgShadow As Bitmap = Nothing
        Dim g As Graphics = Nothing
        Try
            If SourceImage IsNot Nothing Then
                If ShadowOpacity < 0 Then
                    ShadowOpacity = 0
                ElseIf ShadowOpacity > 255 Then
                    ShadowOpacity = 255
                End If
                If ShadowSoftness < 1 Then
                    ShadowSoftness = 1
                ElseIf ShadowSoftness > 30 Then
                    ShadowSoftness = 30
                End If
                If ShadowDistance < 1 Then
                    ShadowDistance = 1
                ElseIf ShadowDistance > 50 Then
                    ShadowDistance = 50
                End If
                'If ShadowColor = Color.Transparent Then
                '    ShadowColor = Color.Black
                'End If
                'If BackgroundColor = Color.Transparent Then
                '    BackgroundColor = Color.White
                'End If

                'get shadow
                Dim shWidth As Integer = CInt(SourceImage.Width / ShadowSoftness)
                Dim shHeight As Integer = CInt(SourceImage.Height / ShadowSoftness)
                ImgShadow = New Bitmap(shWidth, shHeight)
                g = Graphics.FromImage(ImgShadow)
                g.Clear(Color.Transparent)
                g.InterpolationMode = InterpolationMode.HighQualityBicubic
                g.SmoothingMode = SmoothingMode.AntiAlias
                Dim sre As Integer = 0
                If ShadowRoundedEdges = True Then sre = 1
                g.FillRectangle(New SolidBrush(Color.FromArgb(ShadowOpacity, ShadowColor)), _
                                      sre, sre, shWidth, shHeight)
                g.Dispose()

                'draw shadow
                Dim d_shWidth As Integer = SourceImage.Width + ShadowDistance
                Dim d_shHeight As Integer = SourceImage.Height + ShadowDistance
                ImgTarget = New Bitmap(d_shWidth, d_shHeight)
                g = Graphics.FromImage(ImgTarget)
                g.Clear(BackgroundColor)
                g.InterpolationMode = InterpolationMode.HighQualityBicubic
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.DrawImage(ImgShadow, New Rectangle(0, 0, d_shWidth, d_shHeight), _
                                        0, 0, ImgShadow.Width, ImgShadow.Height, GraphicsUnit.Pixel)
                Select Case ShadowDirection
                    Case ShadowDirections.BOTTOM_RIGHT
                        g.DrawImage(SourceImage, _
                            New Rectangle(0, 0, SourceImage.Width, SourceImage.Height), _
                               0, 0, SourceImage.Width, SourceImage.Height, GraphicsUnit.Pixel)
                    Case ShadowDirections.BOTTOM_LEFT
                        g.Dispose()
                        ImgTarget.RotateFlip(RotateFlipType.RotateNoneFlipX)
                        g = Graphics.FromImage(ImgTarget)
                        g.DrawImage(SourceImage, _
                             New Rectangle(ShadowDistance, 0, SourceImage.Width, SourceImage.Height), _
                                    0, 0, SourceImage.Width, SourceImage.Height, GraphicsUnit.Pixel)
                    Case ShadowDirections.TOP_LEFT
                        g.Dispose()
                        ImgTarget.RotateFlip(RotateFlipType.Rotate180FlipNone)
                        g = Graphics.FromImage(ImgTarget)
                        g.DrawImage(SourceImage, _
                                      New Rectangle(ShadowDistance, ShadowDistance, _
                                                        SourceImage.Width, SourceImage.Height), _
                                      0, 0, SourceImage.Width, SourceImage.Height, GraphicsUnit.Pixel)
                    Case ShadowDirections.TOP_RIGHT
                        g.Dispose()
                        ImgTarget.RotateFlip(RotateFlipType.RotateNoneFlipY)
                        g = Graphics.FromImage(ImgTarget)
                        g.DrawImage(SourceImage, _
                           New Rectangle(0, ShadowDistance, SourceImage.Width, SourceImage.Height), _
                                  0, 0, SourceImage.Width, SourceImage.Height, GraphicsUnit.Pixel)
                End Select

                g.Dispose()
                g = Nothing
                ImgShadow.Dispose()
                ImgShadow = Nothing

                SourceImage = New Bitmap(ImgTarget)
                retur = SourceImage
                ImgTarget.Dispose()
                ImgTarget = Nothing
            End If

        Catch ex As Exception
            If g IsNot Nothing Then
                g.Dispose()
                g = Nothing
            End If
            If ImgShadow IsNot Nothing Then
                ImgShadow.Dispose()
                ImgShadow = Nothing
            End If
            If ImgTarget IsNot Nothing Then
                ImgTarget.Dispose()
                ImgTarget = Nothing
            End If
        End Try
        Return retur
    End Function

End Class
