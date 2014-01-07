Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Diagnostics.CodeAnalysis
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles
Imports System.Runtime.InteropServices
Imports System.Drawing.Drawing2D

Namespace Nativ
    Public Enum ToolbarTheme
        Toolbar
        MediaToolbar
        CommunicationsToolbar
        BrowserTabBar
    End Enum

    ''' <summary>
    ''' Renders a toolstrip using the UxTheme API via VisualStyleRenderer. Visual styles must be supported for this to work; if you need to support other operating systems use
    ''' </summary>
    Class UXThemeToolStripRenderer
        Inherits ToolStripSystemRenderer
        ''' <summary>
        ''' It shouldn't be necessary to P/Invoke like this, however a bug in VisualStyleRenderer.GetMargins forces my hand.
        ''' </summary>
        Friend NotInheritable Class NativeMethods
            Private Sub New()
            End Sub
            <StructLayout(LayoutKind.Sequential, Pack:=1)> _
            Public Structure MARGINS
                Public cxLeftWidth As Integer
                Public cxRightWidth As Integer
                Public cyTopHeight As Integer
                Public cyBottomHeight As Integer
            End Structure

            <DllImport("uxtheme", ExactSpelling:=True)> _
            Public Shared Function GetThemeMargins(ByVal hTheme As IntPtr, ByVal hdc As IntPtr, ByVal iPartId As Integer, ByVal iStateId As Integer, ByVal iPropId As Integer, ByVal rect As IntPtr, _
    ByRef pMargins As MARGINS) As Int32
            End Function
        End Class

        'See http://msdn2.microsoft.com/en-us/library/bb773210.aspx - "Parts and States"
#Region "Parts and States"
        Private Enum MenuParts As Integer
            MENU_MENUITEM_TMSCHEMA = 1
            MENU_MENUDROPDOWN_TMSCHEMA = 2
            MENU_MENUBARITEM_TMSCHEMA = 3
            MENU_MENUBARDROPDOWN_TMSCHEMA = 4
            MENU_CHEVRON_TMSCHEMA = 5
            MENU_SEPARATOR_TMSCHEMA = 6
            MENU_BARBACKGROUND = 7
            MENU_BARITEM = 8
            MENU_POPUPBACKGROUND = 9
            MENU_POPUPBORDERS = 10
            MENU_POPUPCHECK = 11
            MENU_POPUPCHECKBACKGROUND = 12
            MENU_POPUPGUTTER = 13
            MENU_POPUPITEM = 14
            MENU_POPUPSEPARATOR = 15
            MENU_POPUPSUBMENU = 16
            MENU_SYSTEMCLOSE = 17
            MENU_SYSTEMMAXIMIZE = 18
            MENU_SYSTEMMINIMIZE = 19
            MENU_SYSTEMRESTORE = 20
        End Enum

        Private Enum MenuBarStates As Integer
            MB_ACTIVE = 1
            MB_INACTIVE = 2
        End Enum

        Private Enum MenuBarItemStates As Integer
            MBI_NORMAL = 1
            MBI_HOT = 2
            MBI_PUSHED = 3
            MBI_DISABLED = 4
            MBI_DISABLEDHOT = 5
            MBI_DISABLEDPUSHED = 6
        End Enum

        Private Enum MenuPopupItemStates As Integer
            MPI_NORMAL = 1
            MPI_HOT = 2
            MPI_DISABLED = 3
            MPI_DISABLEDHOT = 4
        End Enum

        Private Enum MenuPopupCheckStates As Integer
            MC_CHECKMARKNORMAL = 1
            MC_CHECKMARKDISABLED = 2
            MC_BULLETNORMAL = 3
            MC_BULLETDISABLED = 4
        End Enum

        Private Enum MenuPopupCheckBackgroundStates As Integer
            MCB_DISABLED = 1
            MCB_NORMAL = 2
            MCB_BITMAP = 3
        End Enum

        Private Enum MenuPopupSubMenuStates As Integer
            MSM_NORMAL = 1
            MSM_DISABLED = 2
        End Enum

        Private Enum MarginTypes As Integer
            TMT_SIZINGMARGINS = 3601
            TMT_CONTENTMARGINS = 3602
            TMT_CAPTIONMARGINS = 3603
        End Enum

        Const RP_BACKGROUND As Integer = 6
#End Region

#Region "Theme helpers"
        Private Function GetThemeMargins(ByVal dc As IDeviceContext, ByVal marginType As MarginTypes) As Padding
            Dim margins As NativeMethods.MARGINS
            Try
                Dim hDC As IntPtr = dc.GetHdc()
                If 0 = NativeMethods.GetThemeMargins(renderer.Handle, hDC, renderer.Part, renderer.State, CInt(marginType), IntPtr.Zero, _
                 margins) Then
                    Return New Padding(margins.cxLeftWidth, margins.cyTopHeight, margins.cxRightWidth, margins.cyBottomHeight)
                End If
                Return New Padding(-1)
            Finally
                dc.ReleaseHdc()
            End Try
        End Function

        Private Shared Function GetItemState(ByVal item As ToolStripItem) As Integer
            Dim pressed As Boolean = item.Pressed
            Dim hot As Boolean = item.Selected

            If item.Owner.IsDropDown Then
                If item.Enabled Then
                    Return If(hot, CInt(MenuPopupItemStates.MPI_HOT), CInt(MenuPopupItemStates.MPI_NORMAL))
                End If
                Return If(hot, CInt(MenuPopupItemStates.MPI_DISABLEDHOT), CInt(MenuPopupItemStates.MPI_DISABLED))
            Else
                If pressed Then
                    Return If(item.Enabled, CInt(MenuBarItemStates.MBI_PUSHED), CInt(MenuBarItemStates.MBI_DISABLEDPUSHED))
                End If
                If item.Enabled Then
                    Return If(hot, CInt(MenuBarItemStates.MBI_HOT), CInt(MenuBarItemStates.MBI_NORMAL))
                End If
                Return If(hot, CInt(MenuBarItemStates.MBI_DISABLEDHOT), CInt(MenuBarItemStates.MBI_DISABLED))
            End If
        End Function
#End Region

#Region "Theme subclasses"
        Public Property Theme() As ToolbarTheme
            Get
                Return m_Theme
            End Get
            Set(ByVal value As ToolbarTheme)
                m_Theme = value
            End Set
        End Property
        Private m_Theme As ToolbarTheme

        Private ReadOnly Property RebarClass() As String
            Get
                Return SubclassPrefix & "Rebar"
            End Get
        End Property

        Private ReadOnly Property ToolbarClass() As String
            Get
                Return SubclassPrefix & "ToolBar"
            End Get
        End Property

        Private ReadOnly Property MenuClass() As String
            Get
                Return SubclassPrefix & "Menu"
            End Get
        End Property

        Private ReadOnly Property SubclassPrefix() As String
            Get
                Select Case Theme
                    Case ToolbarTheme.MediaToolbar
                        Return "Media::"
                    Case ToolbarTheme.CommunicationsToolbar
                        Return "Communications::"
                    Case ToolbarTheme.BrowserTabBar
                        Return "BrowserTabBar::"
                    Case Else
                        Return String.Empty
                End Select
            End Get
        End Property

        Private Function Subclass(ByVal element As VisualStyleElement) As VisualStyleElement
            Return VisualStyleElement.CreateElement(SubclassPrefix & element.ClassName, element.Part, element.State)
        End Function
#End Region

        Private renderer As VisualStyleRenderer

        Public Sub New(ByVal theme__1 As ToolbarTheme)
            Theme = theme__1
            renderer = New VisualStyleRenderer(VisualStyleElement.Button.PushButton.Normal)
        End Sub

#Region "Borders"
        Protected Overrides Sub OnRenderToolStripBorder(ByVal e As ToolStripRenderEventArgs)
            renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPBORDERS), 0)
            If e.ToolStrip.IsDropDown Then
                Dim oldClip As Region = e.Graphics.Clip

                'Tool strip borders are rendered *after* the content, for some reason.
                'So we have to exclude the inside of the popup otherwise we'll draw over it.
                Dim insideRect As Rectangle = e.ToolStrip.ClientRectangle
                insideRect.Inflate(-1, -1)
                e.Graphics.ExcludeClip(insideRect)

                renderer.DrawBackground(e.Graphics, e.ToolStrip.ClientRectangle, e.AffectedBounds)

                'Restore the old clip in case the Graphics is used again (does that ever happen?)
                e.Graphics.Clip = oldClip
            End If
        End Sub
#End Region

#Region "Backgrounds"
        Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
            Dim partId As Integer = If(e.Item.Owner.IsDropDown, CInt(MenuParts.MENU_POPUPITEM), CInt(MenuParts.MENU_BARITEM))
            renderer.SetParameters(MenuClass, partId, GetItemState(e.Item))

            Dim bgRect As Rectangle = e.Item.ContentRectangle

            Dim content As Padding = GetThemeMargins(e.Graphics, MarginTypes.TMT_CONTENTMARGINS), sizing As Padding = GetThemeMargins(e.Graphics, MarginTypes.TMT_SIZINGMARGINS), caption As Padding = GetThemeMargins(e.Graphics, MarginTypes.TMT_CAPTIONMARGINS)

            If Not e.Item.Owner.IsDropDown Then
                bgRect.Y = 0
                bgRect.Height = e.ToolStrip.Height
                'GetMargins here perhaps?
                bgRect.Inflate(-1, -1)
            End If

            renderer.DrawBackground(e.Graphics, bgRect, bgRect)
        End Sub

        Protected Overrides Sub OnRenderToolStripPanelBackground(ByVal e As ToolStripPanelRenderEventArgs)
            'Draw the background using Rebar & RP_BACKGROUND (or, if that is not available, fall back to
            'Rebar.Band.Normal)
            If VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement(RebarClass, RP_BACKGROUND, 0)) Then
                renderer.SetParameters(RebarClass, RP_BACKGROUND, 0)
            Else
                'renderer.SetParameters(VisualStyleElement.Taskbar.BackgroundBottom.Normal);
                'renderer.SetParameters(Subclass(VisualStyleElement.Rebar.Band.Normal));
                renderer.SetParameters(RebarClass, 0, 0)
            End If

            If renderer.IsBackgroundPartiallyTransparent() Then
                renderer.DrawParentBackground(e.Graphics, e.ToolStripPanel.ClientRectangle, e.ToolStripPanel)
            End If

            renderer.DrawBackground(e.Graphics, e.ToolStripPanel.ClientRectangle)

            'Draw the etched edges of each row.
            'renderer.SetParameters(Subclass(VisualStyleElement.Rebar.Band.Normal));
            'foreach (ToolStripPanelRow row in e.ToolStripPanel.Rows) {
            '    Rectangle rowBounds = row.Bounds;
            '    rowBounds.Offset(0, -1);
            '    renderer.DrawEdge(e.Graphics, rowBounds, Edges.Top, EdgeStyle.Etched, EdgeEffects.None);
            '}

            e.Handled = True
        End Sub

        'Render the background of an actual menu bar, dropdown menu or toolbar.
        Protected Overrides Sub OnRenderToolStripBackground(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
            If e.ToolStrip.IsDropDown Then
                renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPBACKGROUND), 0)
            Else
                'It's a MenuStrip or a ToolStrip. If it's contained inside a larger panel, it should have a
                'transparent background, showing the panel's background.

                If TypeOf e.ToolStrip.Parent Is ToolStripPanel Then
                    'The background should be transparent, because the ToolStripPanel's background will be visible.
                    '(Of course, we assume the ToolStripPanel is drawn using the same theme, but it's not my fault
                    'if someone does that.)
                    Return
                Else
                    'A lone toolbar/menubar should act like it's inside a toolbox, I guess.
                    'Maybe I should use the MenuClass in the case of a MenuStrip, although that would break
                    'the other themes...
                    If VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement(RebarClass, RP_BACKGROUND, 0)) Then
                        renderer.SetParameters(RebarClass, RP_BACKGROUND, 0)
                    Else
                        renderer.SetParameters(RebarClass, 0, 0)
                    End If
                End If
            End If

            If renderer.IsBackgroundPartiallyTransparent() Then
                renderer.DrawParentBackground(e.Graphics, e.ToolStrip.ClientRectangle, e.ToolStrip)
            End If

            renderer.DrawBackground(e.Graphics, e.ToolStrip.ClientRectangle, e.AffectedBounds)
        End Sub

        Protected Overrides Sub OnRenderToolStripContentPanelBackground(ByVal e As ToolStripContentPanelRenderEventArgs)
            'e.Graphics.FillRectangle(Brushes.RosyBrown, e.ToolStripContentPanel.ClientRectangle);
            'base.OnRenderToolStripContentPanelBackground(e);
        End Sub

        'Some sort of chevron thing?
        'protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e) {
        '    base.OnRenderOverflowButtonBackground(e);
        '}
#End Region

#Region "Text"
        Protected Overrides Sub OnRenderItemText(ByVal e As ToolStripItemTextRenderEventArgs)
            Dim partId As Integer = If(e.Item.Owner.IsDropDown, CInt(MenuParts.MENU_POPUPITEM), CInt(MenuParts.MENU_BARITEM))
            renderer.SetParameters(MenuClass, partId, GetItemState(e.Item))
            Dim color As Color = renderer.GetColor(ColorProperty.TextColor)

            If e.Item.Owner.IsDropDown OrElse TypeOf e.Item.Owner Is MenuStrip Then
                e.TextColor = color
            End If

            MyBase.OnRenderItemText(e)
        End Sub
#End Region

#Region "Glyphs"

        'protected override void OnRenderGrip(ToolStripGripRenderEventArgs e) {
        '    if (e.GripStyle == ToolStripGripStyle.Visible) {
        '        renderer.SetParameters(VisualStyleElement.Rebar.Gripper.Normal);
        '        renderer.DrawBackground(e.Graphics, e.GripBounds, e.AffectedBounds);
        '    }
        '}

        Protected Overrides Sub OnRenderImageMargin(ByVal e As ToolStripRenderEventArgs)
            If e.ToolStrip.IsDropDown Then
                renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPGUTTER), 0)
                Dim displayRect As Rectangle = e.ToolStrip.DisplayRectangle, marginRect As New Rectangle(0, displayRect.Top, displayRect.Left, displayRect.Height)
                'e.Graphics.DrawRectangle(Pens.Black, marginRect);
                renderer.DrawBackground(e.Graphics, marginRect, marginRect)
            End If
        End Sub

        Protected Overrides Sub OnRenderSeparator(ByVal e As ToolStripSeparatorRenderEventArgs)
            If e.ToolStrip.IsDropDown Then
                renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPSEPARATOR), 0)
                Dim rect As New Rectangle(e.ToolStrip.DisplayRectangle.Left, 0, e.ToolStrip.DisplayRectangle.Width, e.Item.Height)
                renderer.DrawBackground(e.Graphics, rect, rect)
            Else
                MyBase.OnRenderSeparator(e)
            End If
        End Sub

        Protected Overrides Sub OnRenderItemCheck(ByVal e As ToolStripItemImageRenderEventArgs)
            Dim item As ToolStripMenuItem = TryCast(e.Item, ToolStripMenuItem)
            If item IsNot Nothing Then
                If item.Checked Then
                    Dim rect As Rectangle = e.Item.ContentRectangle
                    rect.Width = rect.Height

                    'Center the checkmark horizontally in the gutter (looks ugly, though)
                    'rect.X = (e.ToolStrip.DisplayRectangle.Left - rect.Width) / 2;

                    renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPCHECKBACKGROUND), If(e.Item.Enabled, CInt(MenuPopupCheckBackgroundStates.MCB_NORMAL), CInt(MenuPopupCheckBackgroundStates.MCB_DISABLED)))
                    renderer.DrawBackground(e.Graphics, rect)

                    Dim margins As Padding = GetThemeMargins(e.Graphics, MarginTypes.TMT_SIZINGMARGINS)

                    rect = New Rectangle(rect.X + margins.Left, rect.Y + margins.Top, rect.Width - margins.Horizontal, rect.Height - margins.Vertical)

                    'I don't think ToolStrip even supports radio box items. So no need to render them.
                    renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPCHECK), If(e.Item.Enabled, CInt(MenuPopupCheckStates.MC_CHECKMARKNORMAL), CInt(MenuPopupCheckStates.MC_CHECKMARKDISABLED)))

                    renderer.DrawBackground(e.Graphics, rect)
                End If
            Else
                MyBase.OnRenderItemCheck(e)
            End If
        End Sub

        'This is broken for RTL
        Protected Overrides Sub OnRenderArrow(ByVal e As ToolStripArrowRenderEventArgs)
            Dim stateId As Integer = If(e.Item.Enabled, CInt(MenuPopupSubMenuStates.MSM_NORMAL), CInt(MenuPopupSubMenuStates.MSM_DISABLED))
            renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPSUBMENU), stateId)
            renderer.DrawBackground(e.Graphics, e.ArrowRectangle)
        End Sub

        Protected Overrides Sub OnRenderOverflowButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
            renderer.SetParameters(RebarClass, VisualStyleElement.Rebar.Chevron.Normal.Part, VisualStyleElement.Rebar.Chevron.Normal.State)
            renderer.DrawBackground(e.Graphics, e.Item.ContentRectangle)

            'base.OnRenderOverflowButtonBackground(e);
        End Sub
#End Region

        Public Shared ReadOnly Property IsSupported() As Boolean
            Get
                Try
                    If Not VisualStyleRenderer.IsSupported Then
                        Return False
                    End If

                    Return VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement("MENU", CInt(MenuParts.MENU_BARBACKGROUND), CInt(MenuBarStates.MB_ACTIVE)))
                Catch ex As Exception
                    Return False
                End Try

            End Get
        End Property
    End Class

    ''' <summary>
    ''' Renders a toolstrip using UXTheme if possible, and switches back to the default
    ''' ToolStripRenderer when UXTheme-based rendering is not available.
    ''' Designed for menu bars and context menus - it is not guaranteed to work with anything else.
    ''' </summary>
    ''' <example>
    ''' NativeToolStripRenderer.SetToolStripRenderer(toolStrip1, toolStrip2, contextMenuStrip1);
    ''' </example>
    ''' <example>
    ''' toolStrip1.Renderer = new NativeToolStripRenderer();
    ''' </example>
    Public Class NativeToolStripRenderer
        Inherits ToolStripRenderer
        Private nativeRenderer As UXThemeToolStripRenderer
        Private defaultRenderer As ToolStripRenderer
        Private mytoolStrip As ToolStrip

        'NativeToolStripRenderer looks best with no padding - but keep the old padding in case the
        'visual styles become unsupported again (e.g. user changes to windows classic skin)
        Private defaultPadding As Padding

#Region "Constructors"
        ''' <summary>
        ''' Creates a NativeToolStripRenderer for a particular ToolStrip. NativeToolStripRenderer  will subscribe to some events
        ''' of this ToolStrip.
        ''' </summary>
        ''' <param name="toolStrip">The toolstrip for this NativeToolStripRenderer. NativeToolStripRenderer  will subscribe to some events
        ''' of this ToolStrip.</param>
        Public Sub New(ByVal toolStrip As ToolStrip, ByVal theme__1 As ToolbarTheme)
            If toolStrip Is Nothing Then
                Throw New ArgumentNullException("toolStrip", "ToolStrip cannot be null.")
            End If

            Theme = theme__1

            Me.mytoolStrip = toolStrip
            defaultRenderer = New clsVistaToolStripRenderer

            defaultPadding = toolStrip.Padding

            'Can't initialize here - constructor throws if visual styles not enabled
            'nativeRenderer = new NativeToolStripRenderer();
            AddHandler toolStrip.SystemColorsChanged, New EventHandler(AddressOf toolStrip_SystemColorsChanged)
        End Sub

        Public Sub New(ByVal panel As ToolStripPanel, ByVal theme__1 As ToolbarTheme)
            If panel Is Nothing Then
                Throw New ArgumentNullException("panel", "Panel cannot be null.")
            End If

            Theme = theme__1

            Me.mytoolStrip = Nothing
            defaultRenderer = panel.Renderer
        End Sub
#End Region

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Theme() As ToolbarTheme
            Get
                Return m_Theme
            End Get
            Set(ByVal value As ToolbarTheme)
                m_Theme = value
            End Set
        End Property
        Private m_Theme As ToolbarTheme

        Private Sub toolStrip_SystemColorsChanged(ByVal sender As Object, ByVal e As EventArgs)
            If mytoolStrip Is Nothing Then
                Return
            End If

            If UXThemeToolStripRenderer.IsSupported Then
                mytoolStrip.Padding = Padding.Empty
            Else
                mytoolStrip.Padding = defaultPadding
            End If
        End Sub

        'This is indeed called every time a menu part is rendered, but I can't
        'find a way of caching it that I can be sure has no race conditions.
        'The check is no longer very costly, anyway.
        Protected ReadOnly Property ActualRenderer() As ToolStripRenderer
            Get
                Dim nativeSupported As Boolean = UXThemeToolStripRenderer.IsSupported

                If nativeSupported Then
                    If nativeRenderer Is Nothing Then
                        nativeRenderer = New UXThemeToolStripRenderer(Theme)
                    End If
                    Return nativeRenderer
                End If

                Return defaultRenderer
            End Get
        End Property

#Region "InitializeXXX"
        Protected Overrides Sub Initialize(ByVal toolStrip As ToolStrip)
            MyBase.Initialize(toolStrip)
            If TypeOf toolStrip Is StatusStrip Then
                toolStrip.ForeColor = Color.FromArgb(255, 102, 138, 174)
            ElseIf TypeOf toolStrip Is MenuStrip Then
                toolStrip.ForeColor = Color.Black
            ElseIf TypeOf toolStrip Is ToolStripDropDownMenu Then
                toolStrip.ForeColor = Color.Black
            ElseIf TypeOf toolStrip Is ToolStrip Then
                toolStrip.ForeColor = Color.Black
            ElseIf TypeOf toolStrip Is ContextMenuStrip Then
                toolStrip.ForeColor = Color.Black
            End If


            toolStrip.Padding = Padding.Empty

            '!(toolStrip is MenuStrip) &&
            If TypeOf toolStrip.Parent Is ToolStripPanel Then
                toolStrip.BackColor = Color.Transparent
            End If
        End Sub

        Protected Overrides Sub InitializePanel(ByVal toolStripPanel As ToolStripPanel)
            MyBase.InitializePanel(toolStripPanel)
        End Sub

        Protected Overrides Sub InitializeItem(ByVal item As ToolStripItem)

            MyBase.InitializeItem(item)
        End Sub
#End Region

#Region "SetToolStripRenderer"
        ''' <summary>
        ''' Sets the renderer of each ToolStrip to a NativeToolStripRenderer. A convenience method.
        ''' </summary>
        ''' <param name="toolStrips">A parameter list of ToolStrips.</param>
        <SuppressMessage("Microsoft.Design", "CA1062")> _
        Public Shared Sub SetToolStripRenderer(ByVal theme As ToolbarTheme, ByVal ParamArray toolStrips As Control())
            For Each ts As Control In toolStrips
                If ts Is Nothing Then
                    Throw New ArgumentNullException("toolStrips", "ToolStrips cannot contain a null reference.")
                End If
            Next

            For Each ts As Control In toolStrips
                If TypeOf ts Is ToolStrip Then
                    Dim t As ToolStrip = DirectCast(ts, ToolStrip)
                    t.Renderer = New NativeToolStripRenderer(t, theme)
                ElseIf TypeOf ts Is ToolStripPanel Then
                    Dim t As ToolStripPanel = DirectCast(ts, ToolStripPanel)
                    t.Renderer = New NativeToolStripRenderer(t, theme)
                Else
                    Throw New ArgumentException("Can't set the renderer for a " & ts.[GetType]().Name)
                End If
            Next
        End Sub

        Public Shared Sub SetToolStripRenderer(ByVal ParamArray toolStrips As Control())
            SetToolStripRenderer(ToolbarTheme.Toolbar, toolStrips)
        End Sub
#End Region
#Region "- Color Table -"
        ' List of all colors

        'Main background
        'Public Shared clrBGTop1 As Color = Color.FromArgb(255, 127, 166, 191)
        'Public Shared clrBGTop2 As Color = Color.FromArgb(255, 4, 72, 117)
        'Public Shared clrBGBottom1 As Color = Color.FromArgb(255, 57, 117, 156)
        'Public Shared clrBGBottom2 As Color = Color.FromArgb(150, 255, 255, 255)
        'Public Shared clrBGBorder As Color = Color.FromArgb(200, 176, 200, 216)
        'Public Shared clrBGGreen As Color = Color.FromArgb(100, 57, 161, 133)
        Public Shared clrBGTop1 As Color = Color.FromArgb(255, 250, 252, 253)
        Public Shared clrBGBottom1 As Color = Color.FromArgb(255, 230, 240, 250)

        Public Shared clrBGTop2 As Color = Color.FromArgb(255, 220, 230, 244)
        Public Shared clrBGBottom2 As Color = Color.FromArgb(255, 221, 233, 247)

        Public Shared clrBGBorder As Color = Color.FromArgb(200, 160, 175, 195)
        Public Shared clrBGGreen As Color = Color.FromArgb(100, 57, 161, 133)
        Public Shared clrBGBottomLine1 As Color = Color.FromArgb(228, 239, 251)
        Public Shared clrBGBottomLine2 As Color = Color.FromArgb(205, 218, 234)
        Public Shared clrBGBottomLine3 As Color = Color.FromArgb(160, 175, 195)


        'Statusstrip Background
        Public Shared clrSTTop As Color = Color.FromArgb(255, 189, 205, 221)
        Public Shared clrSTTopMid As Color = Color.FromArgb(255, 229, 238, 247)
        Public Shared clrSTBottomMid As Color = Color.FromArgb(255, 229, 238, 247)
        Public Shared clrSTBottom As Color = Color.FromArgb(255, 229, 238, 247)
        Public Shared clrSTUpperBottomLine As Color = Color.FromArgb(255, 182, 188, 204)
        Public Shared clrSTLowerBottomLine As Color = Color.FromArgb(255, 240, 240, 240)

        'MenuBar Background
        Public Shared clrMBTop As Color = Color.FromArgb(255, 255, 255, 255)
        Public Shared clrMBTopMid As Color = Color.FromArgb(255, 229, 234, 245)
        Public Shared clrMBBottomMid As Color = Color.FromArgb(255, 212, 219, 237)
        Public Shared clrMBBottom As Color = Color.FromArgb(255, 225, 230, 246)
        Public Shared clrMBUpperBottomLine As Color = Color.FromArgb(255, 182, 188, 204)
        Public Shared clrMBLowerBottomLine As Color = Color.FromArgb(255, 240, 240, 240)



        'MenuBar Buttons
        Public Shared clrMBButtonLight As Color = Color.FromArgb(60, 0, 0, 0)
        Public Shared clrMBButtonDark As Color = Color.FromArgb(20, 0, 0, 0)
        Public Shared clrMBButtonLightBorder As Color = Color.FromArgb(200, 177, 177, 177)
        Public Shared clrMBButtonLightBorder2 As Color = Color.FromArgb(200, 232, 235, 245)
        Public Shared clrMBButtonDarkBorder As Color = Color.FromArgb(140, 88, 88, 89)

        'Buttons
        Public Shared clrBtnDarkBorder As Color = Color.FromArgb(200, 3, 50, 81)
        Public Shared clrBtnLightBorder As Color = Color.FromArgb(200, 216, 228, 236)

        'Context Menus
        'Public Shared clrSelectedBorder As Color = Color.FromArgb(200, 255, 102, 0)
        'Public Shared clrSelectedBorder As Color = Color.FromArgb(200, 174, 207, 247)
        Public Shared clrSelectedBorder As Color = Color.FromArgb(100, 2, 135, 197)
        Public Shared clrSelectGradTop As Color = Color.FromArgb(200, 242, 251, 255)
        Public Shared clrSelectGradBottom As Color = Color.FromArgb(200, 242, 251, 255)
        'Public Shared clrSelectGradTop As Color = Color.FromArgb(255, 236, 245, 255)
        'Public Shared clrSelectGradBottom As Color = Color.FromArgb(255, 208, 229, 255)
        Public Shared clrSelectedAbleBorder As Color = Color.FromArgb(200, 212, 212, 212)
        Public Shared clrSelectAbleGradTop As Color = Color.FromArgb(255, 243, 243, 243)
        Public Shared clrSelectAbleGradBottom As Color = Color.FromArgb(255, 229, 229, 229)
        Public Shared clrMenuBorder As Color = Color.FromArgb(255, 160, 160, 160)

        'Checks in Menus
        Public Shared clrCheckBG As Color = Color.FromArgb(150, 210, 229, 244)
        Public Shared clrCheckBorder As Color = Color.FromArgb(150, 195, 201, 230)
        Public Shared clrImageMarginLine As Color = Color.FromArgb(255, 226, 227, 227)
#End Region

        Public Sub DrawEdgeRectangle(ByVal objGraphics As Graphics, _
                                ByVal m_intxAxis As Integer, _
                                ByVal m_intyAxis As Integer, _
                                ByVal m_intWidth As Integer, _
                                ByVal m_intHeight As Integer, _
                               ByVal color As Color)

            Dim pen As New Pen(color)

            'Dim g As Graphics
            Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
            'Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))
            'top left Arc
            'objGraphics.DrawArc(pen, ArcRect, 180, 90)
            objGraphics.DrawLine(pen, m_intxAxis, m_intyAxis, m_intxAxis + m_intWidth, m_intyAxis)

            ' top right arc
            'ArcRect.X = BaseRect.Right - m_diameter
            'objGraphics.DrawArc(pen, ArcRect, 270, 90)
            objGraphics.DrawLine(pen, m_intxAxis + m_intWidth, m_intyAxis + 1, m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - 1)

            ' bottom right arc
            'ArcRect.Y = BaseRect.Bottom - m_diameter
            'objGraphics.DrawArc(pen, ArcRect, 0, 90)
            objGraphics.DrawLine(pen, m_intxAxis, m_intyAxis + m_intHeight, m_intxAxis + m_intWidth, m_intyAxis + m_intHeight)

            ' bottom left arc
            'ArcRect.X = BaseRect.Left
            'objGraphics.DrawArc(pen, ArcRect, 90, 90)
            objGraphics.DrawLine(pen, m_intxAxis, m_intyAxis + 1, m_intxAxis, m_intyAxis + m_intHeight - 1)

        End Sub
        Public Sub DrawRoundedRectangle(ByVal objGraphics As Graphics, _
                                    ByVal m_intxAxis As Integer, _
                                    ByVal m_intyAxis As Integer, _
                                    ByVal m_intWidth As Integer, _
                                    ByVal m_intHeight As Integer, _
                                    ByVal m_diameter As Integer, ByVal color As Color)

            Dim pen As New Pen(color)

            'Dim g As Graphics
            Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
            Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))
            'top left Arc
            objGraphics.DrawArc(pen, ArcRect, 180, 90)
            objGraphics.DrawLine(pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)

            ' top right arc
            ArcRect.X = BaseRect.Right - m_diameter
            objGraphics.DrawArc(pen, ArcRect, 270, 90)
            objGraphics.DrawLine(pen, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

            ' bottom right arc
            ArcRect.Y = BaseRect.Bottom - m_diameter
            objGraphics.DrawArc(pen, ArcRect, 0, 90)
            objGraphics.DrawLine(pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis + m_intHeight)

            ' bottom left arc
            ArcRect.X = BaseRect.Left
            objGraphics.DrawArc(pen, ArcRect, 90, 90)
            objGraphics.DrawLine(pen, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

        End Sub




#Region "Overridden Methods - Deferred to actual renderer"
        Protected Overrides Sub OnRenderArrow(ByVal e As ToolStripArrowRenderEventArgs)
            e.ArrowColor = Color.Black
            If TypeOf (e.Item) Is ToolStripDropDownButton And MainForm.Nov_Main_alt.Items.Contains(e.Item) Then
                'e.ArrowColor = Color.FromArgb(30, 57, 91)
                'e.ArrowRectangle = New Rectangle(e.ArrowRectangle.X, CInt((e.ArrowRectangle.Y / 2) - 3), 9, 6)

                e.ArrowRectangle = New Rectangle(e.ArrowRectangle.X - 5, CInt((e.Item.Height / 2) - 3), 9, 6)
                e.Graphics.DrawImage(Toolbar16.arrow, e.ArrowRectangle)
                'MyBase.OnRenderArrow(e)
                'MyBase.OnRenderSplitButtonBackground(New ToolStripItemRenderEventArgs(e.Graphics, e.Item))
            Else
                ActualRenderer.DrawArrow(e)
            End If

        End Sub

        Protected Overrides Sub OnRenderButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
            ActualRenderer.DrawButtonBackground(e)



        End Sub

        Protected Overrides Sub OnRenderDropDownButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
            ActualRenderer.DrawButtonBackground(e)

            'If e.Item.Selected Then
            '    If Not e.Item.IsOnDropDown Then
            '        If e.Item.Pressed Then
            '            Dim s As ToolStripDropDownButton
            '            s = CType(e.Item, ToolStripDropDownButton)
            '            DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
            '            'DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)
            '            Dim shadow As New Rectangle(e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, 3)
            '            e.Graphics.FillRectangle(New LinearGradientBrush(shadow, Color.FromArgb(187, 202, 219), Color.FromArgb(0, 0, 0, 0), 90), shadow)
            '            If s.DropDown.Visible = True Then
            '                DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
            '                DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)

            '            End If

            '        ElseIf e.Item.IsOnOverflow Then
            '            DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
            '            'DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)
            '            Dim shadow As New Rectangle(e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, 3)
            '            e.Graphics.FillRectangle(New LinearGradientBrush(shadow, Color.FromArgb(187, 202, 219), Color.FromArgb(0, 0, 0, 0), 90), shadow)
            '        Else
            '            DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
            '            DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)



            '        End If
            '    Else
            '        DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
            '        DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)


            '    End If
            'ElseIf e.Item.Pressed Then
            '    DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
            '    DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)


            'End If
        End Sub

        Protected Overrides Sub OnRenderGrip(ByVal e As ToolStripGripRenderEventArgs)
            ActualRenderer.DrawGrip(e)
        End Sub

        Protected Overrides Sub OnRenderImageMargin(ByVal e As ToolStripRenderEventArgs)

            '// Shadow at the right of image margin
            Dim DarkLine As New Drawing.SolidBrush(clrImageMarginLine)
            Dim WhiteLine As New Drawing.SolidBrush(Color.White)
            'MsgBox(27 - e.AffectedBounds.Width)
            Dim rect As New Rectangle(e.AffectedBounds.Width + 3, 2, 1, e.AffectedBounds.Height)
            Dim rect2 As New Rectangle(e.AffectedBounds.Width + 4, 2, 1, e.AffectedBounds.Height)

            '// Border
            'Dim borderPen As New Pen(clrMenuBorder)
            'Dim rect4 As New Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 2)

            e.Graphics.FillRectangle(DarkLine, rect)
            e.Graphics.FillRectangle(WhiteLine, rect2)
            'ActualRenderer.DrawImageMargin(e)
        End Sub

        Protected Overrides Sub OnRenderItemBackground(ByVal e As ToolStripItemRenderEventArgs)

            ActualRenderer.DrawItemBackground(e)
        End Sub

        Protected Overrides Sub OnRenderItemCheck(ByVal e As ToolStripItemImageRenderEventArgs)

            ActualRenderer.DrawItemCheck(e)
            If e.Item.Name.ToString.StartsWith("Radio_") Then
                e.Graphics.DrawImage(My.Resources.toolstrip_radio_checked, 2, 1, e.Item.Height - 2, e.Item.Height - 2)
            End If
        End Sub

        Protected Overrides Sub OnRenderItemImage(ByVal e As ToolStripItemImageRenderEventArgs)
            ActualRenderer.DrawItemImage(e)
        End Sub

        Protected Overrides Sub OnRenderItemText(ByVal e As ToolStripItemTextRenderEventArgs)
            'If Not e.Item.ForeColor = Color.White Then

            'End If
            ActualRenderer.DrawItemText(e)
            'MyBase.OnRenderItemText(e)

        End Sub

        Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
            If TypeOf e.Item Is ToolStripMenuItem And e.Item.IsOnDropDown Then
                Dim s As ToolStripMenuItem = CType(e.Item, ToolStripMenuItem)
                If s.AutoSize = True Then
                    's.Margin = New Padding(2, 1, 2, 1)
                    s.AutoSize = False
                    s.TextAlign = Drawing.ContentAlignment.BottomLeft
                    s.Size = New Size(s.Size.Width, s.Size.Height + 2)
                End If

                's.Margin = New Padding(0, 1, 0, 1)

            End If
            ActualRenderer.DrawMenuItemBackground(e)
        End Sub

        Protected Overrides Sub OnRenderSeparator(ByVal e As ToolStripSeparatorRenderEventArgs)

            If (TypeOf e.ToolStrip Is ToolStripDropDownMenu) Then
                If (TypeOf e.Item Is ToolStripSeperator2) Then
                    Dim DarkLine As New SolidBrush(clrImageMarginLine)
                    Dim WhiteLine As New SolidBrush(Color.White)
                    Dim rect As New Rectangle(3, 3, e.Item.Width, 1)
                    Dim rect2 As New Rectangle(3, 4, e.Item.Width, 1)
                    e.Graphics.FillRectangle(DarkLine, rect)
                    e.Graphics.FillRectangle(WhiteLine, rect2)
                Else
                    Dim DarkLine As New SolidBrush(clrImageMarginLine)
                    Dim WhiteLine As New SolidBrush(Color.White)
                    Dim rect As New Rectangle(29, 3, e.Item.Width - 25, 1)
                    Dim rect2 As New Rectangle(29, 4, e.Item.Width - 25, 1)
                    e.Graphics.FillRectangle(DarkLine, rect)
                    e.Graphics.FillRectangle(WhiteLine, rect2)
                End If
            ElseIf (TypeOf e.ToolStrip Is ToolStrip) Then
                'Dim DarkLine As New SolidBrush(Color.FromArgb(220, 223, 224))
                'e.Graphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(0, 0, 1, e.Item.Height - 3))
                If Not e.ToolStrip.ToString.Contains("Nav") And Not e.ToolStrip.ToString.Contains("Vert") Then
                    If e.Item.Alignment = ToolStripItemAlignment.Left Then
                        e.Graphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(1, 0, 1, e.Item.Height - 2))
                        e.Graphics.FillRectangle(New SolidBrush(clrBGBottomLine3), New Rectangle(2, 0, 1, e.Item.Height - 1))
                        e.Graphics.FillRectangle(New SolidBrush(clrBGBottomLine2), New Rectangle(3, 0, 1, e.Item.Height - 2))
                        'e.Graphics.FillRectangle(New SolidBrush(clrBGBottomLine1), New Rectangle(4, 0, 1, e.Item.Height - 3))
                        Dim shadow As New Rectangle(3, 0, 5, e.Item.Height - 2)
                        e.Graphics.FillRectangle(New LinearGradientBrush(shadow, clrBGBottomLine2, Color.FromArgb(0, 0, 0, 0), 0), shadow)
                    Else
                        e.Graphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(7, 0, 1, e.Item.Height - 2))
                        e.Graphics.FillRectangle(New SolidBrush(clrBGBottomLine3), New Rectangle(6, 0, 1, e.Item.Height - 1))
                        e.Graphics.FillRectangle(New SolidBrush(clrBGBottomLine2), New Rectangle(5, 0, 1, e.Item.Height - 2))
                        'e.Graphics.FillRectangle(New SolidBrush(clrBGBottomLine1), New Rectangle(4, 0, 1, e.Item.Height - 3))
                        Dim shadow As New Rectangle(0, 0, 5, e.Item.Height - 2)
                        e.Graphics.FillRectangle(New LinearGradientBrush(shadow, Color.FromArgb(0, 0, 0, 0), clrBGBottomLine2, 0), shadow)
                    End If
                Else
       ActualRenderer.DrawSeparator(e)
                End If

                'a()

                'Dim DarkLine As New SolidBrush(clrBGBottomLine3)
                'Dim WhiteLine As New SolidBrush(clrBGBottomLine2)

                'Dim rect As New Rectangle(0, 0, 1, e.Item.Height - 1)
                'Dim rect2 As New Rectangle(1, 0, 1, e.Item.Height - 1)
                'Dim rect3 As New Rectangle(2, 0, 1, e.Item.Height - 1)
                ''Dim rect4 As New Rectangle(2, 0, 1, e.Item.Height - 1)
                ''Dim rect5 As New Rectangle(2, 0, 1, e.Item.Height - 1)
                'e.Graphics.FillRectangle(WhiteLine, rect)
                'e.Graphics.FillRectangle(DarkLine, rect2)
                'e.Graphics.FillRectangle(WhiteLine, rect3)
                'MyBase.OnRenderSeparator(e)
            Else

                ActualRenderer.DrawSeparator(e)
            End If

        End Sub

        Protected Overrides Sub OnRenderToolStripBackground(ByVal e As ToolStripRenderEventArgs)
            'MyBase.OnRenderToolStripBackground(e)
            If (TypeOf e.ToolStrip Is ToolStripDropDownMenu) OrElse (TypeOf e.ToolStrip Is ContextMenuStrip) Then
                'Dim topRect As New Rectangle(0, 0, 10, e.ToolStrip.Height)
                'Dim topBrush As New SolidBrush(Color.White)

                'e.Graphics.FillRectangle(topBrush, topRect)
            ElseIf (TypeOf e.ToolStrip Is StatusStrip) Then


                Dim topRect As New Rectangle(0, 1, e.ToolStrip.Width + 2, 4)
                Dim bottomRect As New Rectangle(0, 4, e.ToolStrip.Width + 2, e.ToolStrip.Height - 4)

                Dim topBrush As New LinearGradientBrush(topRect, clrSTTop, clrSTTopMid, LinearGradientMode.Vertical)
                Dim bottomBrush As New LinearGradientBrush(bottomRect, clrSTBottomMid, clrSTBottom, LinearGradientMode.Vertical)

                e.Graphics.FillRectangle(bottomBrush, bottomRect)
                e.Graphics.FillRectangle(topBrush, topRect)
                'e.Graphics.DrawRectangle(New Pen(clrBGBottomLine1, 1), New Rectangle(-1, 1, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))
                'e.Graphics.DrawRectangle(New Pen(clrBGBorder, 1), New Rectangle(0, e.ToolStrip.Height - 1, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1))

            ElseIf (TypeOf e.ToolStrip Is MenuStrip) Then
                ' MyBase.OnRenderToolStripBackground(e)
                If e.ToolStrip.ToString.Contains("Nav") Then

                    Dim topRect As New Rectangle(0, 0, e.ToolStrip.Width, e.ToolStrip.Height * 2)


                    Dim topBrush As New LinearGradientBrush(topRect, Color.FromArgb(0, 0, 0, 0), clrBGBottomLine2, LinearGradientMode.Vertical)
                    'Dim topBrush As New LinearGradientBrush(topRect, clrBGBorder, Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical)

                    e.Graphics.FillRectangle(topBrush, topRect)


                    e.Graphics.DrawRectangle(New Pen(clrBGBottomLine3, 1), New Rectangle(-1, e.ToolStrip.Height - 1, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))
                    'e.Graphics.DrawRectangle(New Pen(clrBGBottomLine2, 1), New Rectangle(-1, e.ToolStrip.Height - 2, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))
                    'e.Graphics.DrawRectangle(New Pen(clrBGBottomLine1, 1), New Rectangle(-1, e.ToolStrip.Height - 3, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))



                Else

                    Dim topRect As New Rectangle(0, 0, e.ToolStrip.Width + 2, CInt(e.ToolStrip.Height / 3))
                    Dim bottomRect As New Rectangle(0, CInt(e.ToolStrip.Height / 3), e.ToolStrip.Width + 2, CInt(e.ToolStrip.Height / 1.5))

                    Dim topBrush As New LinearGradientBrush(topRect, clrMBTop, clrMBTopMid, LinearGradientMode.Vertical)
                    Dim bottomBrush As New LinearGradientBrush(bottomRect, clrMBBottomMid, clrMBBottom, LinearGradientMode.Vertical)

                    e.Graphics.FillRectangle(topBrush, topRect)
                    e.Graphics.FillRectangle(bottomBrush, bottomRect)
                    e.Graphics.FillRectangle(New SolidBrush(clrMBUpperBottomLine), New Rectangle(0, e.ToolStrip.Height - 1, e.ToolStrip.Width, 1))
                End If

                ' e.Graphics.FillRectangle(New SolidBrush(clrMBLowerBottomLine), New Rectangle(0, e.ToolStrip.Height - 1, e.ToolStrip.Width, 1))
                'Dim topRect As New Rectangle(0, 0, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1)


                'Dim bottomRect As New Rectangle(0, e.ToolStrip.Height - 1, e.ToolStrip.Width + 2, e.ToolStrip.Height)
                ''Dim bottomGradRect As New Rectangle(0, 23, e.ToolStrip.Width + 2, 7)
                'Dim topBrush As New LinearGradientBrush(topRect, clrBGBottomLine3, Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical)

                ''Dim bottomBrush As New LinearGradientBrush(bottomRect, clrBGTop2, clrBGBottom2, LinearGradientMode.Vertical)
                ''Dim topBrush As New SolidBrush(clrBGTop2)
                'Dim bottomGradBrush As New LinearGradientBrush(bottomGradRect, clrBGTop2, clrBGBottom2, LinearGradientMode.Vertical)
                'Dim horGradBrush As New LinearGradientBrush(e.AffectedBounds, Color.Transparent, clrBGGreen, LinearGradientMode.Horizontal)

                'e.Graphics.FillRectangle(New SolidBrush(clrBGTop2), e.AffectedBounds)
                'e.Graphics.FillRectangle(bottomBrush, bottomRect)
                'e.Graphics.FillRectangle(topBrush, topRect)

            ElseIf (TypeOf e.ToolStrip Is ToolStrip) Then
                If e.ToolStrip.ToString.Contains("Vert") Then

                    Dim c As Color
                    c = Color.FromArgb(227, 245, 254)

                    Dim c2 As Color
                    c2 = Color.FromArgb(2, 135, 197)
                    Dim rect_frame As New Rectangle(0, 0, e.ToolStrip.Width, e.ToolStrip.Height)

                    Dim rect_back As New Rectangle(1, 1, e.ToolStrip.Width, e.ToolStrip.Height - 2)
                    Dim b As New SolidBrush(c)
                    Dim b2 As New SolidBrush(c2)
                    'Dim b3 As New Drawing.SolidBrush(Color.White)
                    'Dim b4 As New Drawing.SolidBrush(Color.Gray)
                    Dim b3 As New Drawing.SolidBrush(SystemColors.Window)
                    Dim b4 As New Drawing.SolidBrush(SystemColors.ScrollBar)
                    e.Graphics.FillRectangle(b4, rect_frame)
                    e.Graphics.FillRectangle(b3, rect_back)
                    'g.FillRectangle(b2, rect)
                    'g.FillRectangle(b, rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2)

                ElseIf e.ToolStrip.ToString.Contains("Nav") Then
                    Dim topRect As New Rectangle(0, 0, e.ToolStrip.Width + 2, CInt(e.ToolStrip.Height / 2 - 1))



                    Dim topBrush As New LinearGradientBrush(topRect, clrBGBottomLine2, Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical)
                    'Dim topBrush As New LinearGradientBrush(topRect, clrBGBorder, Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical)

                    e.Graphics.FillRectangle(topBrush, topRect)
                    If e.ToolStrip.ToString.Contains("Nav_line") Then
                        e.Graphics.DrawRectangle(New Pen(clrBGBottomLine3, 1), New Rectangle(-1, e.ToolStrip.Height - 1, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))
                        e.Graphics.DrawRectangle(New Pen(clrBGBottomLine2, 1), New Rectangle(-1, e.ToolStrip.Height - 2, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))
                        e.Graphics.DrawRectangle(New Pen(clrBGBottomLine1, 1), New Rectangle(-1, e.ToolStrip.Height - 3, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))

                    End If


                Else



                    Dim topRect As New Rectangle(0, 0, e.ToolStrip.Width + 2, CInt(e.ToolStrip.Height / 2 - 1))
                    Dim bottomRect As New Rectangle(0, CInt(e.ToolStrip.Height / 2 - 1), e.ToolStrip.Width + 2, CInt(e.ToolStrip.Height / 2 + 1))
                    'Dim bottomGradRect As New Rectangle(0, 23, e.ToolStrip.Width + 2, 7)
                    Dim topBrush As New LinearGradientBrush(topRect, clrBGTop1, clrBGBottom1, LinearGradientMode.Vertical)
                    Dim bottomBrush As New LinearGradientBrush(bottomRect, clrBGTop2, clrBGBottom2, LinearGradientMode.Vertical)
                    ''Dim topBrush As New SolidBrush(clrBGTop2)
                    'Dim bottomGradBrush As New LinearGradientBrush(bottomGradRect, clrBGTop2, clrBGBottom2, LinearGradientMode.Vertical)
                    'Dim horGradBrush As New LinearGradientBrush(e.AffectedBounds, Color.Transparent, clrBGGreen, LinearGradientMode.Horizontal)

                    'e.Graphics.FillRectangle(New SolidBrush(clrBGTop2), e.AffectedBounds)
                    e.Graphics.FillRectangle(bottomBrush, bottomRect)
                    e.Graphics.FillRectangle(topBrush, topRect)

                    'e.Graphics.FillRectangle(bottomGradBrush, bottomGradRect)
                    'e.Graphics.FillRectangle(horGradBrush, e.AffectedBounds)

                    e.Graphics.DrawRectangle(New Pen(clrBGBottomLine3, 1), New Rectangle(-1, e.ToolStrip.Height - 1, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))
                    e.Graphics.DrawRectangle(New Pen(clrBGBottomLine2, 1), New Rectangle(-1, e.ToolStrip.Height - 2, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))
                    e.Graphics.DrawRectangle(New Pen(clrBGBottomLine1, 1), New Rectangle(-1, e.ToolStrip.Height - 3, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))

                    If e.ToolStrip.ToString.Contains("Nov_line") Then
                        'Dim topRect2 As New Rectangle(0, 0, e.ToolStrip.Width + 2, CInt(e.ToolStrip.Height / 2 - 1))
                        'Dim topBrush2 As New LinearGradientBrush(topRect2, clrBGBottomLine2, Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical)
                        'e.Graphics.FillRectangle(topBrush2, topRect2)


                        Dim topRect2 As New Rectangle(0, 0, e.ToolStrip.Width, 5)
                        Dim topBrush2 As New LinearGradientBrush(topRect2, clrBGBottomLine2, Color.FromArgb(0, 0, 0, 0), LinearGradientMode.Vertical)
                        e.Graphics.FillRectangle(topBrush2, topRect2)
                    End If


                End If
                ' e.Graphics.DrawRectangle(New Pen(clrBGBorder, 1), New Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1))
                'e.Graphics.DrawRectangle(New Pen(clrBGBorder, 1), New Rectangle(0, e.ToolStrip.Height - 1, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1))


            End If

        End Sub
        Protected Overrides Sub OnRenderSplitButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)


            If e.Item.Selected Then
                Dim DarkLine As New SolidBrush(Color.FromArgb(171, 174, 176))
                Dim WhiteLine As New SolidBrush(Color.White)
                Dim rect As New Rectangle(e.Item.Width - 18, 1, 2, 1)
                Dim rect2 As New Rectangle(e.Item.Width - 18, 2, 2, 1)
                e.Graphics.FillRectangle(DarkLine, rect)
                e.Graphics.FillRectangle(WhiteLine, rect2)
                Dim drect As New Rectangle(e.Item.Width - 18, e.Item.Size.Height - 2, 2, 1)
                Dim drect2 As New Rectangle(e.Item.Width - 18, e.Item.Size.Height - 3, 2, 1)
                e.Graphics.FillRectangle(DarkLine, drect)
                e.Graphics.FillRectangle(WhiteLine, drect2)
                'ActualRenderer.DrawSplitButton(e)
            ElseIf e.Item.Pressed Then

                'Dim DarkLine As New SolidBrush(Color.FromArgb(171, 174, 176))
                ''Dim WhiteLine As New SolidBrush(Color.White)
                'Dim rect As New Rectangle(e.Item.Width - 18, 1, 2, 1)
                'Dim rect2 As New Rectangle(e.Item.Width - 18, 2, 2, 1)
                'e.Graphics.FillRectangle(DarkLine, rect)
                ''e.Graphics.FillRectangle(WhiteLine, rect2)
                'Dim drect As New Rectangle(e.Item.Width - 18, e.Item.Size.Height - 2, 2, 1)
                'Dim drect2 As New Rectangle(e.Item.Width - 18, e.Item.Size.Height - 3, 2, 1)
                'e.Graphics.FillRectangle(DarkLine, drect)
                'ActualRenderer.DrawSplitButton(e)
            End If
            ActualRenderer.DrawSplitButton(e)
        End Sub
        Protected Overrides Sub OnRenderToolStripBorder(ByVal e As ToolStripRenderEventArgs)
            ActualRenderer.DrawToolStripBorder(e)
        End Sub

        Protected Overrides Sub OnRenderToolStripContentPanelBackground(ByVal e As ToolStripContentPanelRenderEventArgs)
            ActualRenderer.DrawToolStripContentPanelBackground(e)
        End Sub

        Protected Overrides Sub OnRenderToolStripPanelBackground(ByVal e As ToolStripPanelRenderEventArgs)
            ActualRenderer.DrawToolStripPanelBackground(e)
        End Sub
#End Region
    End Class
End Namespace
'Namespace Nativ
'    Public Enum ToolbarTheme
'        Toolbar
'        MediaToolbar
'        CommunicationsToolbar
'        BrowserTabBar
'    End Enum

'    ''' <summary>
'    ''' Renders a toolstrip using the UxTheme API via VisualStyleRenderer. Visual styles must be supported for this to work; if you need to support other operating systems use
'    ''' </summary>
'    Class UXThemeToolStripRenderer
'        Inherits ToolStripSystemRenderer
'        ''' <summary>
'        ''' It shouldn't be necessary to P/Invoke like this, however a bug in VisualStyleRenderer.GetMargins forces my hand.
'        ''' </summary>
'        Friend NotInheritable Class NativeMethods
'            Private Sub New()
'            End Sub
'            <StructLayout(LayoutKind.Sequential, Pack:=1)> _
'            Public Structure MARGINS
'                Public cxLeftWidth As Integer
'                Public cxRightWidth As Integer
'                Public cyTopHeight As Integer
'                Public cyBottomHeight As Integer
'            End Structure

'            <DllImport("uxtheme", ExactSpelling:=True)> _
'            Public Shared Function GetThemeMargins(ByVal hTheme As IntPtr, ByVal hdc As IntPtr, ByVal iPartId As Integer, ByVal iStateId As Integer, ByVal iPropId As Integer, ByVal rect As IntPtr, _
'    ByRef pMargins As MARGINS) As Int32
'            End Function
'        End Class

'        'See http://msdn2.microsoft.com/en-us/library/bb773210.aspx - "Parts and States"
'#Region "Parts and States"
'        Private Enum MenuParts As Integer
'            MENU_MENUITEM_TMSCHEMA = 1
'            MENU_MENUDROPDOWN_TMSCHEMA = 2
'            MENU_MENUBARITEM_TMSCHEMA = 3
'            MENU_MENUBARDROPDOWN_TMSCHEMA = 4
'            MENU_CHEVRON_TMSCHEMA = 5
'            MENU_SEPARATOR_TMSCHEMA = 6
'            MENU_BARBACKGROUND = 7
'            MENU_BARITEM = 8
'            MENU_POPUPBACKGROUND = 9
'            MENU_POPUPBORDERS = 10
'            MENU_POPUPCHECK = 11
'            MENU_POPUPCHECKBACKGROUND = 12
'            MENU_POPUPGUTTER = 13
'            MENU_POPUPITEM = 14
'            MENU_POPUPSEPARATOR = 15
'            MENU_POPUPSUBMENU = 16
'            MENU_SYSTEMCLOSE = 17
'            MENU_SYSTEMMAXIMIZE = 18
'            MENU_SYSTEMMINIMIZE = 19
'            MENU_SYSTEMRESTORE = 20
'        End Enum

'        Private Enum MenuBarStates As Integer
'            MB_ACTIVE = 1
'            MB_INACTIVE = 2
'        End Enum

'        Private Enum MenuBarItemStates As Integer
'            MBI_NORMAL = 1
'            MBI_HOT = 2
'            MBI_PUSHED = 3
'            MBI_DISABLED = 4
'            MBI_DISABLEDHOT = 5
'            MBI_DISABLEDPUSHED = 6
'        End Enum

'        Private Enum MenuPopupItemStates As Integer
'            MPI_NORMAL = 1
'            MPI_HOT = 2
'            MPI_DISABLED = 3
'            MPI_DISABLEDHOT = 4
'        End Enum

'        Private Enum MenuPopupCheckStates As Integer
'            MC_CHECKMARKNORMAL = 1
'            MC_CHECKMARKDISABLED = 2
'            MC_BULLETNORMAL = 3
'            MC_BULLETDISABLED = 4
'        End Enum

'        Private Enum MenuPopupCheckBackgroundStates As Integer
'            MCB_DISABLED = 1
'            MCB_NORMAL = 2
'            MCB_BITMAP = 3
'        End Enum

'        Private Enum MenuPopupSubMenuStates As Integer
'            MSM_NORMAL = 1
'            MSM_DISABLED = 2
'        End Enum

'        Private Enum MarginTypes As Integer
'            TMT_SIZINGMARGINS = 3601
'            TMT_CONTENTMARGINS = 3602
'            TMT_CAPTIONMARGINS = 3603
'        End Enum

'        Const RP_BACKGROUND As Integer = 6
'#End Region

'#Region "Theme helpers"
'        Private Function GetThemeMargins(ByVal dc As IDeviceContext, ByVal marginType As MarginTypes) As Padding
'            Dim margins As NativeMethods.MARGINS
'            Try
'                Dim hDC As IntPtr = dc.GetHdc()
'                If 0 = NativeMethods.GetThemeMargins(renderer.Handle, hDC, renderer.Part, renderer.State, CInt(marginType), IntPtr.Zero, _
'                 margins) Then
'                    Return New Padding(margins.cxLeftWidth, margins.cyTopHeight, margins.cxRightWidth, margins.cyBottomHeight)
'                End If
'                Return New Padding(-1)
'            Finally
'                dc.ReleaseHdc()
'            End Try
'        End Function

'        Private Shared Function GetItemState(ByVal item As ToolStripItem) As Integer
'            Dim pressed As Boolean = item.Pressed
'            Dim hot As Boolean = item.Selected

'            If item.Owner.IsDropDown Then
'                If item.Enabled Then
'                    Return If(hot, CInt(MenuPopupItemStates.MPI_HOT), CInt(MenuPopupItemStates.MPI_NORMAL))
'                End If
'                Return If(hot, CInt(MenuPopupItemStates.MPI_DISABLEDHOT), CInt(MenuPopupItemStates.MPI_DISABLED))
'            Else
'                If pressed Then
'                    Return If(item.Enabled, CInt(MenuBarItemStates.MBI_PUSHED), CInt(MenuBarItemStates.MBI_DISABLEDPUSHED))
'                End If
'                If item.Enabled Then
'                    Return If(hot, CInt(MenuBarItemStates.MBI_HOT), CInt(MenuBarItemStates.MBI_NORMAL))
'                End If
'                Return If(hot, CInt(MenuBarItemStates.MBI_DISABLEDHOT), CInt(MenuBarItemStates.MBI_DISABLED))
'            End If
'        End Function
'#End Region

'#Region "Theme subclasses"
'        Public Property Theme() As ToolbarTheme
'            Get
'                Return m_Theme
'            End Get
'            Set(ByVal value As ToolbarTheme)
'                m_Theme = value
'            End Set
'        End Property
'        Private m_Theme As ToolbarTheme

'        Private ReadOnly Property RebarClass() As String
'            Get
'                Return SubclassPrefix & "Rebar"
'            End Get
'        End Property

'        Private ReadOnly Property ToolbarClass() As String
'            Get
'                Return SubclassPrefix & "ToolBar"
'            End Get
'        End Property

'        Private ReadOnly Property MenuClass() As String
'            Get
'                Return SubclassPrefix & "Menu"
'            End Get
'        End Property

'        Private ReadOnly Property SubclassPrefix() As String
'            Get
'                Select Case Theme
'                    Case ToolbarTheme.MediaToolbar
'                        Return "Media::"
'                    Case ToolbarTheme.CommunicationsToolbar
'                        Return "Communications::"
'                    Case ToolbarTheme.BrowserTabBar
'                        Return "BrowserTabBar::"
'                    Case Else
'                        Return String.Empty
'                End Select
'            End Get
'        End Property

'        Private Function Subclass(ByVal element As VisualStyleElement) As VisualStyleElement
'            Return VisualStyleElement.CreateElement(SubclassPrefix & element.ClassName, element.Part, element.State)
'        End Function
'#End Region

'        Private renderer As VisualStyleRenderer

'        Public Sub New(ByVal theme__1 As ToolbarTheme)
'            Theme = theme__1
'            renderer = New VisualStyleRenderer(VisualStyleElement.Button.PushButton.Normal)
'        End Sub

'#Region "Borders"
'        Protected Overrides Sub OnRenderToolStripBorder(ByVal e As ToolStripRenderEventArgs)
'            renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPBORDERS), 0)
'            If e.ToolStrip.IsDropDown Then
'                Dim oldClip As Region = e.Graphics.Clip

'                'Tool strip borders are rendered *after* the content, for some reason.
'                'So we have to exclude the inside of the popup otherwise we'll draw over it.
'                Dim insideRect As Rectangle = e.ToolStrip.ClientRectangle
'                insideRect.Inflate(-1, -1)
'                e.Graphics.ExcludeClip(insideRect)

'                renderer.DrawBackground(e.Graphics, e.ToolStrip.ClientRectangle, e.AffectedBounds)

'                'Restore the old clip in case the Graphics is used again (does that ever happen?)
'                e.Graphics.Clip = oldClip
'            End If
'        End Sub
'#End Region

'#Region "Backgrounds"
'        Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
'            Dim partId As Integer = If(e.Item.Owner.IsDropDown, CInt(MenuParts.MENU_POPUPITEM), CInt(MenuParts.MENU_BARITEM))
'            renderer.SetParameters(MenuClass, partId, GetItemState(e.Item))

'            Dim bgRect As Rectangle = e.Item.ContentRectangle

'            Dim content As Padding = GetThemeMargins(e.Graphics, MarginTypes.TMT_CONTENTMARGINS), sizing As Padding = GetThemeMargins(e.Graphics, MarginTypes.TMT_SIZINGMARGINS), caption As Padding = GetThemeMargins(e.Graphics, MarginTypes.TMT_CAPTIONMARGINS)

'            If Not e.Item.Owner.IsDropDown Then
'                bgRect.Y = 0
'                bgRect.Height = e.ToolStrip.Height
'                'GetMargins here perhaps?
'                bgRect.Inflate(-1, -1)
'            End If

'            renderer.DrawBackground(e.Graphics, bgRect, bgRect)
'        End Sub

'        Protected Overrides Sub OnRenderToolStripPanelBackground(ByVal e As ToolStripPanelRenderEventArgs)
'            'Draw the background using Rebar & RP_BACKGROUND (or, if that is not available, fall back to
'            'Rebar.Band.Normal)
'            If VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement(RebarClass, RP_BACKGROUND, 0)) Then
'                renderer.SetParameters(RebarClass, RP_BACKGROUND, 0)
'            Else
'                'renderer.SetParameters(VisualStyleElement.Taskbar.BackgroundBottom.Normal);
'                'renderer.SetParameters(Subclass(VisualStyleElement.Rebar.Band.Normal));
'                renderer.SetParameters(RebarClass, 0, 0)
'            End If

'            If renderer.IsBackgroundPartiallyTransparent() Then
'                renderer.DrawParentBackground(e.Graphics, e.ToolStripPanel.ClientRectangle, e.ToolStripPanel)
'            End If

'            renderer.DrawBackground(e.Graphics, e.ToolStripPanel.ClientRectangle)

'            'Draw the etched edges of each row.
'            'renderer.SetParameters(Subclass(VisualStyleElement.Rebar.Band.Normal));
'            'foreach (ToolStripPanelRow row in e.ToolStripPanel.Rows) {
'            '    Rectangle rowBounds = row.Bounds;
'            '    rowBounds.Offset(0, -1);
'            '    renderer.DrawEdge(e.Graphics, rowBounds, Edges.Top, EdgeStyle.Etched, EdgeEffects.None);
'            '}

'            e.Handled = True
'        End Sub

'        'Render the background of an actual menu bar, dropdown menu or toolbar.
'        Protected Overrides Sub OnRenderToolStripBackground(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
'            If e.ToolStrip.IsDropDown Then
'                renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPBACKGROUND), 0)
'            Else
'                'It's a MenuStrip or a ToolStrip. If it's contained inside a larger panel, it should have a
'                'transparent background, showing the panel's background.

'                If TypeOf e.ToolStrip.Parent Is ToolStripPanel Then
'                    'The background should be transparent, because the ToolStripPanel's background will be visible.
'                    '(Of course, we assume the ToolStripPanel is drawn using the same theme, but it's not my fault
'                    'if someone does that.)
'                    Return
'                Else
'                    'A lone toolbar/menubar should act like it's inside a toolbox, I guess.
'                    'Maybe I should use the MenuClass in the case of a MenuStrip, although that would break
'                    'the other themes...
'                    If VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement(RebarClass, RP_BACKGROUND, 0)) Then
'                        renderer.SetParameters(RebarClass, RP_BACKGROUND, 0)
'                    Else
'                        renderer.SetParameters(RebarClass, 0, 0)
'                    End If
'                End If
'            End If

'            If renderer.IsBackgroundPartiallyTransparent() Then
'                renderer.DrawParentBackground(e.Graphics, e.ToolStrip.ClientRectangle, e.ToolStrip)
'            End If

'            renderer.DrawBackground(e.Graphics, e.ToolStrip.ClientRectangle, e.AffectedBounds)
'        End Sub

'        Protected Overrides Sub OnRenderToolStripContentPanelBackground(ByVal e As ToolStripContentPanelRenderEventArgs)
'            'e.Graphics.FillRectangle(Brushes.RosyBrown, e.ToolStripContentPanel.ClientRectangle);
'            'base.OnRenderToolStripContentPanelBackground(e);
'        End Sub

'        'Some sort of chevron thing?
'        'protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e) {
'        '    base.OnRenderOverflowButtonBackground(e);
'        '}
'#End Region

'#Region "Text"
'        Protected Overrides Sub OnRenderItemText(ByVal e As ToolStripItemTextRenderEventArgs)
'            Dim partId As Integer = If(e.Item.Owner.IsDropDown, CInt(MenuParts.MENU_POPUPITEM), CInt(MenuParts.MENU_BARITEM))
'            renderer.SetParameters(MenuClass, partId, GetItemState(e.Item))
'            Dim color As Color = renderer.GetColor(ColorProperty.TextColor)

'            If e.Item.Owner.IsDropDown OrElse TypeOf e.Item.Owner Is MenuStrip Then
'                e.TextColor = color
'            End If

'            MyBase.OnRenderItemText(e)
'        End Sub
'#End Region

'#Region "Glyphs"

'        'protected override void OnRenderGrip(ToolStripGripRenderEventArgs e) {
'        '    if (e.GripStyle == ToolStripGripStyle.Visible) {
'        '        renderer.SetParameters(VisualStyleElement.Rebar.Gripper.Normal);
'        '        renderer.DrawBackground(e.Graphics, e.GripBounds, e.AffectedBounds);
'        '    }
'        '}

'        Protected Overrides Sub OnRenderImageMargin(ByVal e As ToolStripRenderEventArgs)
'            If e.ToolStrip.IsDropDown Then
'                renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPGUTTER), 0)
'                Dim displayRect As Rectangle = e.ToolStrip.DisplayRectangle, marginRect As New Rectangle(0, displayRect.Top, displayRect.Left, displayRect.Height)
'                'e.Graphics.DrawRectangle(Pens.Black, marginRect);
'                renderer.DrawBackground(e.Graphics, marginRect, marginRect)
'            End If
'        End Sub

'        Protected Overrides Sub OnRenderSeparator(ByVal e As ToolStripSeparatorRenderEventArgs)
'            If e.ToolStrip.IsDropDown Then
'                renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPSEPARATOR), 0)
'                Dim rect As New Rectangle(e.ToolStrip.DisplayRectangle.Left, 0, e.ToolStrip.DisplayRectangle.Width, e.Item.Height)
'                renderer.DrawBackground(e.Graphics, rect, rect)
'            Else
'                MyBase.OnRenderSeparator(e)
'            End If
'        End Sub

'        Protected Overrides Sub OnRenderItemCheck(ByVal e As ToolStripItemImageRenderEventArgs)
'            Dim item As ToolStripMenuItem = TryCast(e.Item, ToolStripMenuItem)
'            If item IsNot Nothing Then
'                If item.Checked Then
'                    Dim rect As Rectangle = e.Item.ContentRectangle
'                    rect.Width = rect.Height

'                    'Center the checkmark horizontally in the gutter (looks ugly, though)
'                    'rect.X = (e.ToolStrip.DisplayRectangle.Left - rect.Width) / 2;

'                    renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPCHECKBACKGROUND), If(e.Item.Enabled, CInt(MenuPopupCheckBackgroundStates.MCB_NORMAL), CInt(MenuPopupCheckBackgroundStates.MCB_DISABLED)))
'                    renderer.DrawBackground(e.Graphics, rect)

'                    Dim margins As Padding = GetThemeMargins(e.Graphics, MarginTypes.TMT_SIZINGMARGINS)

'                    rect = New Rectangle(rect.X + margins.Left, rect.Y + margins.Top, rect.Width - margins.Horizontal, rect.Height - margins.Vertical)

'                    'I don't think ToolStrip even supports radio box items. So no need to render them.
'                    renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPCHECK), If(e.Item.Enabled, CInt(MenuPopupCheckStates.MC_CHECKMARKNORMAL), CInt(MenuPopupCheckStates.MC_CHECKMARKDISABLED)))

'                    renderer.DrawBackground(e.Graphics, rect)
'                End If
'            Else
'                MyBase.OnRenderItemCheck(e)
'            End If
'        End Sub

'        'This is broken for RTL
'        Protected Overrides Sub OnRenderArrow(ByVal e As ToolStripArrowRenderEventArgs)
'            Dim stateId As Integer = If(e.Item.Enabled, CInt(MenuPopupSubMenuStates.MSM_NORMAL), CInt(MenuPopupSubMenuStates.MSM_DISABLED))
'            renderer.SetParameters(MenuClass, CInt(MenuParts.MENU_POPUPSUBMENU), stateId)
'            renderer.DrawBackground(e.Graphics, e.ArrowRectangle)
'        End Sub

'        Protected Overrides Sub OnRenderOverflowButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
'            renderer.SetParameters(RebarClass, VisualStyleElement.Rebar.Chevron.Normal.Part, VisualStyleElement.Rebar.Chevron.Normal.State)
'            renderer.DrawBackground(e.Graphics, e.Item.ContentRectangle)

'            'base.OnRenderOverflowButtonBackground(e);
'        End Sub
'#End Region

'        Public Shared ReadOnly Property IsSupported() As Boolean
'            Get
'                If Not VisualStyleRenderer.IsSupported Then
'                    Return False
'                End If

'                Return VisualStyleRenderer.IsElementDefined(VisualStyleElement.CreateElement("MENU", CInt(MenuParts.MENU_BARBACKGROUND), CInt(MenuBarStates.MB_ACTIVE)))
'            End Get
'        End Property
'    End Class

'    ''' <summary>
'    ''' Renders a toolstrip using UXTheme if possible, and switches back to the default
'    ''' ToolStripRenderer when UXTheme-based rendering is not available.
'    ''' Designed for menu bars and context menus - it is not guaranteed to work with anything else.
'    ''' </summary>
'    ''' <example>
'    ''' NativeToolStripRenderer.SetToolStripRenderer(toolStrip1, toolStrip2, contextMenuStrip1);
'    ''' </example>
'    ''' <example>
'    ''' toolStrip1.Renderer = new NativeToolStripRenderer();
'    ''' </example>
'    Public Class NativeToolStripRenderer
'        Inherits ToolStripRenderer
'        Private nativeRenderer As UXThemeToolStripRenderer
'        Private defaultRenderer As ToolStripRenderer
'        Private mytoolStrip As ToolStrip

'        'NativeToolStripRenderer looks best with no padding - but keep the old padding in case the
'        'visual styles become unsupported again (e.g. user changes to windows classic skin)
'        Private defaultPadding As Padding

'#Region "Constructors"
'        ''' <summary>
'        ''' Creates a NativeToolStripRenderer for a particular ToolStrip. NativeToolStripRenderer  will subscribe to some events
'        ''' of this ToolStrip.
'        ''' </summary>
'        ''' <param name="toolStrip">The toolstrip for this NativeToolStripRenderer. NativeToolStripRenderer  will subscribe to some events
'        ''' of this ToolStrip.</param>
'        Public Sub New(ByVal toolStrip As ToolStrip, ByVal theme__1 As ToolbarTheme)
'            If toolStrip Is Nothing Then
'                Throw New ArgumentNullException("toolStrip", "ToolStrip cannot be null.")
'            End If

'            Theme = theme__1

'            Me.mytoolStrip = toolStrip
'            defaultRenderer = toolStrip.Renderer

'            defaultPadding = toolStrip.Padding

'            'Can't initialize here - constructor throws if visual styles not enabled
'            'nativeRenderer = new NativeToolStripRenderer();
'            AddHandler toolStrip.SystemColorsChanged, New EventHandler(AddressOf toolStrip_SystemColorsChanged)
'        End Sub

'        Public Sub New(ByVal panel As ToolStripPanel, ByVal theme__1 As ToolbarTheme)
'            If panel Is Nothing Then
'                Throw New ArgumentNullException("panel", "Panel cannot be null.")
'            End If

'            Theme = theme__1

'            Me.mytoolStrip = Nothing
'            defaultRenderer = panel.Renderer
'        End Sub
'#End Region

'        Sub New()
'            ' TODO: Complete member initialization 
'        End Sub

'        Public Property Theme() As ToolbarTheme
'            Get
'                Return m_Theme
'            End Get
'            Set(ByVal value As ToolbarTheme)
'                m_Theme = value
'            End Set
'        End Property
'        Private m_Theme As ToolbarTheme

'        Private Sub toolStrip_SystemColorsChanged(ByVal sender As Object, ByVal e As EventArgs)
'            If mytoolStrip Is Nothing Then
'                Return
'            End If

'            If UXThemeToolStripRenderer.IsSupported Then
'                mytoolStrip.Padding = Padding.Empty
'            Else
'                mytoolStrip.Padding = defaultPadding
'            End If
'        End Sub

'        'This is indeed called every time a menu part is rendered, but I can't
'        'find a way of caching it that I can be sure has no race conditions.
'        'The check is no longer very costly, anyway.
'        Protected ReadOnly Property ActualRenderer() As ToolStripRenderer
'            Get
'                Dim nativeSupported As Boolean = UXThemeToolStripRenderer.IsSupported

'                If nativeSupported Then
'                    If nativeRenderer Is Nothing Then
'                        nativeRenderer = New UXThemeToolStripRenderer(Theme)
'                    End If
'                    Return nativeRenderer
'                End If

'                Return defaultRenderer
'            End Get
'        End Property

'#Region "InitializeXXX"
'        Protected Overrides Sub Initialize(ByVal toolStrip As ToolStrip)
'            MyBase.Initialize(toolStrip)

'            toolStrip.Padding = Padding.Empty

'            '!(toolStrip is MenuStrip) &&
'            If TypeOf toolStrip.Parent Is ToolStripPanel Then
'                toolStrip.BackColor = Color.Transparent
'            End If
'        End Sub

'        Protected Overrides Sub InitializePanel(ByVal toolStripPanel As ToolStripPanel)
'            MyBase.InitializePanel(toolStripPanel)
'        End Sub

'        Protected Overrides Sub InitializeItem(ByVal item As ToolStripItem)
'            MyBase.InitializeItem(item)
'        End Sub
'#End Region

'#Region "SetToolStripRenderer"
'        ''' <summary>
'        ''' Sets the renderer of each ToolStrip to a NativeToolStripRenderer. A convenience method.
'        ''' </summary>
'        ''' <param name="toolStrips">A parameter list of ToolStrips.</param>
'        'The parameter array is actually checked.
'        <SuppressMessage("Microsoft.Design", "CA1062")> _
'        Public Shared Sub SetToolStripRenderer(ByVal theme As ToolbarTheme, ByVal ParamArray toolStrips As Control())
'            For Each ts As Control In toolStrips
'                If ts Is Nothing Then
'                    Throw New ArgumentNullException("toolStrips", "ToolStrips cannot contain a null reference.")
'                End If
'            Next

'            For Each ts As Control In toolStrips
'                If TypeOf ts Is ToolStrip Then
'                    Dim t As ToolStrip = DirectCast(ts, ToolStrip)
'                    t.Renderer = New NativeToolStripRenderer(t, theme)
'                ElseIf TypeOf ts Is ToolStripPanel Then
'                    Dim t As ToolStripPanel = DirectCast(ts, ToolStripPanel)
'                    t.Renderer = New NativeToolStripRenderer(t, theme)
'                Else
'                    Throw New ArgumentException("Can't set the renderer for a " & ts.[GetType]().Name)
'                End If
'            Next
'        End Sub

'        Public Shared Sub SetToolStripRenderer(ByVal ParamArray toolStrips As Control())
'            SetToolStripRenderer(ToolbarTheme.Toolbar, toolStrips)
'        End Sub
'#End Region
'#Region "- Color Table -"
'        ' List of all colors

'        'Main background
'        'Public Shared clrBGTop1 As Color = Color.FromArgb(255, 127, 166, 191)
'        'Public Shared clrBGTop2 As Color = Color.FromArgb(255, 4, 72, 117)
'        'Public Shared clrBGBottom1 As Color = Color.FromArgb(255, 57, 117, 156)
'        'Public Shared clrBGBottom2 As Color = Color.FromArgb(150, 255, 255, 255)
'        'Public Shared clrBGBorder As Color = Color.FromArgb(200, 176, 200, 216)
'        'Public Shared clrBGGreen As Color = Color.FromArgb(100, 57, 161, 133)
'        Public Shared clrBGTop1 As Color = Color.FromArgb(255, 250, 252, 253)
'        Public Shared clrBGBottom1 As Color = Color.FromArgb(255, 230, 240, 250)

'        Public Shared clrBGTop2 As Color = Color.FromArgb(255, 220, 230, 244)
'        Public Shared clrBGBottom2 As Color = Color.FromArgb(255, 221, 233, 247)

'        Public Shared clrBGBorder As Color = Color.FromArgb(200, 160, 175, 195)
'        Public Shared clrBGGreen As Color = Color.FromArgb(100, 57, 161, 133)
'        Public Shared clrBGBottomLine1 As Color = Color.FromArgb(228, 239, 251)
'        Public Shared clrBGBottomLine2 As Color = Color.FromArgb(205, 218, 234)
'        Public Shared clrBGBottomLine3 As Color = Color.FromArgb(160, 175, 195)


'        'Statusstrip Background
'        Public Shared clrSTTop As Color = Color.FromArgb(255, 189, 205, 221)
'        Public Shared clrSTTopMid As Color = Color.FromArgb(255, 229, 238, 247)
'        Public Shared clrSTBottomMid As Color = Color.FromArgb(255, 229, 238, 247)
'        Public Shared clrSTBottom As Color = Color.FromArgb(255, 229, 238, 247)
'        Public Shared clrSTUpperBottomLine As Color = Color.FromArgb(255, 182, 188, 204)
'        Public Shared clrSTLowerBottomLine As Color = Color.FromArgb(255, 240, 240, 240)

'        'MenuBar Background
'        Public Shared clrMBTop As Color = Color.FromArgb(255, 255, 255, 255)
'        Public Shared clrMBTopMid As Color = Color.FromArgb(255, 229, 234, 245)
'        Public Shared clrMBBottomMid As Color = Color.FromArgb(255, 212, 219, 237)
'        Public Shared clrMBBottom As Color = Color.FromArgb(255, 225, 230, 246)
'        Public Shared clrMBUpperBottomLine As Color = Color.FromArgb(255, 182, 188, 204)
'        Public Shared clrMBLowerBottomLine As Color = Color.FromArgb(255, 240, 240, 240)



'        'MenuBar Buttons
'        Public Shared clrMBButtonLight As Color = Color.FromArgb(60, 0, 0, 0)
'        Public Shared clrMBButtonDark As Color = Color.FromArgb(20, 0, 0, 0)
'        Public Shared clrMBButtonLightBorder As Color = Color.FromArgb(200, 177, 177, 177)
'        Public Shared clrMBButtonLightBorder2 As Color = Color.FromArgb(200, 232, 235, 245)
'        Public Shared clrMBButtonDarkBorder As Color = Color.FromArgb(140, 88, 88, 89)

'        'Buttons
'        Public Shared clrBtnDarkBorder As Color = Color.FromArgb(200, 3, 50, 81)
'        Public Shared clrBtnLightBorder As Color = Color.FromArgb(200, 216, 228, 236)

'        'Context Menus
'        'Public Shared clrSelectedBorder As Color = Color.FromArgb(200, 255, 102, 0)
'        'Public Shared clrSelectedBorder As Color = Color.FromArgb(200, 174, 207, 247)
'        Public Shared clrSelectedBorder As Color = Color.FromArgb(100, 2, 135, 197)
'        Public Shared clrSelectGradTop As Color = Color.FromArgb(200, 242, 251, 255)
'        Public Shared clrSelectGradBottom As Color = Color.FromArgb(200, 242, 251, 255)
'        'Public Shared clrSelectGradTop As Color = Color.FromArgb(255, 236, 245, 255)
'        'Public Shared clrSelectGradBottom As Color = Color.FromArgb(255, 208, 229, 255)
'        Public Shared clrSelectedAbleBorder As Color = Color.FromArgb(200, 212, 212, 212)
'        Public Shared clrSelectAbleGradTop As Color = Color.FromArgb(255, 243, 243, 243)
'        Public Shared clrSelectAbleGradBottom As Color = Color.FromArgb(255, 229, 229, 229)
'        Public Shared clrMenuBorder As Color = Color.FromArgb(255, 160, 160, 160)

'        'Checks in Menus
'        Public Shared clrCheckBG As Color = Color.FromArgb(150, 210, 229, 244)
'        Public Shared clrCheckBorder As Color = Color.FromArgb(150, 195, 201, 230)
'        Public Shared clrImageMarginLine As Color = Color.FromArgb(255, 226, 227, 227)
'#End Region

'        Public Sub DrawEdgeRectangle(ByVal objGraphics As Graphics, _
'                                ByVal m_intxAxis As Integer, _
'                                ByVal m_intyAxis As Integer, _
'                                ByVal m_intWidth As Integer, _
'                                ByVal m_intHeight As Integer, _
'                               ByVal color As Color)

'            Dim pen As New Pen(color)

'            'Dim g As Graphics
'            Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
'            'Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))
'            'top left Arc
'            'objGraphics.DrawArc(pen, ArcRect, 180, 90)
'            objGraphics.DrawLine(pen, m_intxAxis, m_intyAxis, m_intxAxis + m_intWidth, m_intyAxis)

'            ' top right arc
'            'ArcRect.X = BaseRect.Right - m_diameter
'            'objGraphics.DrawArc(pen, ArcRect, 270, 90)
'            objGraphics.DrawLine(pen, m_intxAxis + m_intWidth, m_intyAxis + 1, m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - 1)

'            ' bottom right arc
'            'ArcRect.Y = BaseRect.Bottom - m_diameter
'            'objGraphics.DrawArc(pen, ArcRect, 0, 90)
'            objGraphics.DrawLine(pen, m_intxAxis, m_intyAxis + m_intHeight, m_intxAxis + m_intWidth, m_intyAxis + m_intHeight)

'            ' bottom left arc
'            'ArcRect.X = BaseRect.Left
'            'objGraphics.DrawArc(pen, ArcRect, 90, 90)
'            objGraphics.DrawLine(pen, m_intxAxis, m_intyAxis + 1, m_intxAxis, m_intyAxis + m_intHeight - 1)

'        End Sub
'        Public Sub DrawRoundedRectangle(ByVal objGraphics As Graphics, _
'                                    ByVal m_intxAxis As Integer, _
'                                    ByVal m_intyAxis As Integer, _
'                                    ByVal m_intWidth As Integer, _
'                                    ByVal m_intHeight As Integer, _
'                                    ByVal m_diameter As Integer, ByVal color As Color)

'            Dim pen As New Pen(color)

'            'Dim g As Graphics
'            Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
'            Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))
'            'top left Arc
'            objGraphics.DrawArc(pen, ArcRect, 180, 90)
'            objGraphics.DrawLine(pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis)

'            ' top right arc
'            ArcRect.X = BaseRect.Right - m_diameter
'            objGraphics.DrawArc(pen, ArcRect, 270, 90)
'            objGraphics.DrawLine(pen, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

'            ' bottom right arc
'            ArcRect.Y = BaseRect.Bottom - m_diameter
'            objGraphics.DrawArc(pen, ArcRect, 0, 90)
'            objGraphics.DrawLine(pen, m_intxAxis + CInt(m_diameter / 2), m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2), m_intyAxis + m_intHeight)

'            ' bottom left arc
'            ArcRect.X = BaseRect.Left
'            objGraphics.DrawArc(pen, ArcRect, 90, 90)
'            objGraphics.DrawLine(pen, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

'        End Sub




'#Region "Overridden Methods - Deferred to actual renderer"
'        Protected Overrides Sub OnRenderArrow(ByVal e As ToolStripArrowRenderEventArgs)
'            ActualRenderer.DrawArrow(e)
'        End Sub

'        Protected Overrides Sub OnRenderButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
'            ActualRenderer.DrawButtonBackground(e)
'            'If e.Item.Selected Then
'            '    If Not e.Item.IsOnDropDown Then
'            '        If e.Item.Pressed Then
'            '            DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
'            '            'DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)
'            '            Dim shadow As New Rectangle(e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, 3)
'            '            e.Graphics.FillRectangle(New LinearGradientBrush(shadow, Color.FromArgb(187, 202, 219), Color.FromArgb(0, 0, 0, 0), 90), shadow)
'            '        ElseIf e.Item.IsOnOverflow Then
'            '            DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
'            '            'DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)
'            '            Dim shadow As New Rectangle(e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, 3)
'            '            e.Graphics.FillRectangle(New LinearGradientBrush(shadow, Color.FromArgb(187, 202, 219), Color.FromArgb(0, 0, 0, 0), 90), shadow)
'            '        Else
'            '            DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
'            '            DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)



'            '        End If
'            '    Else
'            '        DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
'            '        DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)


'            '    End If
'            'ElseIf e.Item.Pressed Then
'            '    DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
'            '    DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)


'            'End If
'        End Sub

'        Protected Overrides Sub OnRenderDropDownButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
'            ActualRenderer.DrawButtonBackground(e)

'            If e.Item.Selected Then
'                If Not e.Item.IsOnDropDown Then
'                    If e.Item.Pressed Then
'                        Dim s As ToolStripDropDownButton
'                        s = CType(e.Item, ToolStripDropDownButton)
'                        DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
'                        'DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)
'                        Dim shadow As New Rectangle(e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, 3)
'                        e.Graphics.FillRectangle(New LinearGradientBrush(shadow, Color.FromArgb(187, 202, 219), Color.FromArgb(0, 0, 0, 0), 90), shadow)
'                        If s.DropDown.Visible = True Then
'                            DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
'                            DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)

'                        End If

'                    ElseIf e.Item.IsOnOverflow Then
'                        DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
'                        'DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)
'                        Dim shadow As New Rectangle(e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, 3)
'                        e.Graphics.FillRectangle(New LinearGradientBrush(shadow, Color.FromArgb(187, 202, 219), Color.FromArgb(0, 0, 0, 0), 90), shadow)
'                    Else
'                        DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
'                        DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)



'                    End If
'                Else
'                    DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
'                    DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)


'                End If
'            ElseIf e.Item.Pressed Then
'                DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 4, e.Item.ContentRectangle.Y + 4, e.Item.ContentRectangle.Width - 12, e.Item.ContentRectangle.Height - 8, Color.FromArgb(187, 202, 219))
'                DrawEdgeRectangle(e.Graphics, e.Item.ContentRectangle.X + 5, e.Item.ContentRectangle.Y + 5, e.Item.ContentRectangle.Width - 14, e.Item.ContentRectangle.Height - 10, Color.White)


'            End If
'        End Sub

'        Protected Overrides Sub OnRenderGrip(ByVal e As ToolStripGripRenderEventArgs)
'            ActualRenderer.DrawGrip(e)
'        End Sub

'        Protected Overrides Sub OnRenderImageMargin(ByVal e As ToolStripRenderEventArgs)
'            ActualRenderer.DrawImageMargin(e)
'        End Sub

'        Protected Overrides Sub OnRenderItemBackground(ByVal e As ToolStripItemRenderEventArgs)
'            ActualRenderer.DrawItemBackground(e)
'        End Sub

'        Protected Overrides Sub OnRenderItemCheck(ByVal e As ToolStripItemImageRenderEventArgs)
'            ActualRenderer.DrawItemCheck(e)
'        End Sub

'        Protected Overrides Sub OnRenderItemImage(ByVal e As ToolStripItemImageRenderEventArgs)
'            ActualRenderer.DrawItemImage(e)
'        End Sub

'        Protected Overrides Sub OnRenderItemText(ByVal e As ToolStripItemTextRenderEventArgs)
'            ActualRenderer.DrawItemText(e)
'        End Sub

'        Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As ToolStripItemRenderEventArgs)
'            ActualRenderer.DrawMenuItemBackground(e)
'        End Sub

'        Protected Overrides Sub OnRenderSeparator(ByVal e As ToolStripSeparatorRenderEventArgs)
'            ActualRenderer.DrawSeparator(e)
'        End Sub

'        Protected Overrides Sub OnRenderToolStripBackground(ByVal e As ToolStripRenderEventArgs)
'            If (TypeOf e.ToolStrip Is ToolStripDropDownMenu) OrElse (TypeOf e.ToolStrip Is ContextMenuStrip) Then

'                ActualRenderer.DrawToolStripBackground(e)
'            ElseIf TypeOf e.ToolStrip Is ToolStrip Then

'                Dim topRect As New Rectangle(0, 0, e.ToolStrip.Width + 2, CInt(e.ToolStrip.Height / 2 - 1))
'                Dim bottomRect As New Rectangle(0, CInt(e.ToolStrip.Height / 2 - 1), e.ToolStrip.Width + 2, CInt(e.ToolStrip.Height / 2 + 1))
'                'Dim bottomGradRect As New Rectangle(0, 23, e.ToolStrip.Width + 2, 7)
'                Dim topBrush As New LinearGradientBrush(topRect, clrBGTop1, clrBGBottom1, LinearGradientMode.Vertical)
'                Dim bottomBrush As New LinearGradientBrush(bottomRect, clrBGTop2, clrBGBottom2, LinearGradientMode.Vertical)
'                ''Dim topBrush As New SolidBrush(clrBGTop2)
'                'Dim bottomGradBrush As New LinearGradientBrush(bottomGradRect, clrBGTop2, clrBGBottom2, LinearGradientMode.Vertical)
'                'Dim horGradBrush As New LinearGradientBrush(e.AffectedBounds, Color.Transparent, clrBGGreen, LinearGradientMode.Horizontal)

'                'e.Graphics.FillRectangle(New SolidBrush(clrBGTop2), e.AffectedBounds)
'                e.Graphics.FillRectangle(bottomBrush, bottomRect)
'                e.Graphics.FillRectangle(topBrush, topRect)

'                'e.Graphics.FillRectangle(bottomGradBrush, bottomGradRect)
'                'e.Graphics.FillRectangle(horGradBrush, e.AffectedBounds)

'                e.Graphics.DrawRectangle(New Pen(clrBGBottomLine3, 1), New Rectangle(-1, e.ToolStrip.Height - 1, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))
'                e.Graphics.DrawRectangle(New Pen(clrBGBottomLine2, 1), New Rectangle(-1, e.ToolStrip.Height - 2, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))
'                e.Graphics.DrawRectangle(New Pen(clrBGBottomLine1, 1), New Rectangle(-1, e.ToolStrip.Height - 3, e.ToolStrip.Width + 2, e.ToolStrip.Height - 1))
'                '
'            Else
'                ActualRenderer.DrawToolStripBackground(e)
'            End If

'        End Sub
'        Protected Overrides Sub OnRenderSplitButtonBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
'            ActualRenderer.DrawSplitButton(e)
'        End Sub
'        Protected Overrides Sub OnRenderToolStripBorder(ByVal e As ToolStripRenderEventArgs)
'            ActualRenderer.DrawToolStripBorder(e)
'        End Sub

'        Protected Overrides Sub OnRenderToolStripContentPanelBackground(ByVal e As ToolStripContentPanelRenderEventArgs)
'            ActualRenderer.DrawToolStripContentPanelBackground(e)
'        End Sub

'        Protected Overrides Sub OnRenderToolStripPanelBackground(ByVal e As ToolStripPanelRenderEventArgs)
'            ActualRenderer.DrawToolStripPanelBackground(e)
'        End Sub
'#End Region
'    End Class
'End Namespace
