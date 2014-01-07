Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.IO
Friend Class NativeMethods
    Public Const TV_FIRST As Integer = &H1100
    Public Const TVM_SETEXTENDEDSTYLE As Integer = TV_FIRST + 44
    Public Const TVM_GETEXTENDEDSTYLE As Integer = TV_FIRST + 45
    Public Const TVM_SETAUTOSCROLLINFO As Integer = TV_FIRST + 59
    Public Const TVS_NOHSCROLL As Integer = &H8000
    Public Const TVS_EX_AUTOHSCROLL As Integer = &H20
    Public Const TVS_EX_FADEINOUTEXPANDOS As Integer = &H40
    Public Const GWL_STYLE As Integer = -16

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)> _
    Friend Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInt32, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)> _
    Friend Shared Sub SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer)
    End Sub

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)> _
    Friend Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function

    <DllImport("uxtheme.dll", CharSet:=CharSet.Unicode)> _
    Public Shared Function SetWindowTheme(ByVal hWnd As IntPtr, ByVal pszSubAppName As String, ByVal pszSubIdList As String) As Integer
    End Function
End Class
Public Class TreeViewVista
    Inherits System.Windows.Forms.TreeView
    Property _Autosize As Boolean = False
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cp.Style = cp.Style Or NativeMethods.TVS_NOHSCROLL
            ' lose the horizotnal scrollbar
            Return cp
        End Get
    End Property

    'Protected Overrides Sub OnAfterExpand(ByVal e As System.Windows.Forms.TreeViewEventArgs)
    '    MyBase.OnAfterExpand(e)
    '    Me.Size = New Size(Me.Size.Width, Me.VisibleCount * Me.ItemHeight)
    'End Sub
    'Protected Overrides Sub OnAfterCollapse(ByVal e As System.Windows.Forms.TreeViewEventArgs)
    '    MyBase.OnAfterCollapse(e)
    '    Me.Size = New Size(Me.Size.Width, Me.VisibleCount * Me.ItemHeight)

    'End Sub
    'Sub New()
    '    'Me.DrawMode = TreeViewDrawMode.OwnerDrawAll

    '    Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    '    Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

    'End Sub

    'Protected Overrides Sub OnDrawNode(ByVal e As System.Windows.Forms.DrawTreeNodeEventArgs)
    '    'If e.Node Is Nothing Then
    '    '    If e.Node.Tag Is Nothing Then


    '    '        If Not e.Node.Tag.ToString = "dum" Then
    '    '            MyBase.OnDrawNode(e)
    '    '        End If
    '    '    Else
    '    '        MyBase.OnDrawNode(e)
    '    '    End If
    '    'Else
    '    MyBase.OnDrawNode(e)
    '    'End If

    'End Sub
    'Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)



    '    MyBase.OnMouseEnter(e)
    '    ' get style
    '    Dim dw As Integer = NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_GETEXTENDEDSTYLE, 0, 0)

    '    'Update(style)
    '    dw = dw Or NativeMethods.TVS_EX_AUTOHSCROLL
    '    ' autoscroll horizontaly
    '    dw = dw Or NativeMethods.TVS_EX_FADEINOUTEXPANDOS
    '    ' auto hide the +/- signs
    '    'set style
    '    NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_SETEXTENDEDSTYLE, 0, dw)

    '    ' little black/empty arrows and blue highlight on treenodes
    '    NativeMethods.SetWindowTheme(Me.Handle, "explorer", Nothing)
    'End Sub
    Private Function CountVisNodes() As Integer
        Dim i As Integer = 0
        i += Me.Nodes.Count
        For Each n As TreeNode In Me.Nodes
            If n.IsExpanded Then
                i += CountVisNodes(n)
                i += 1
            Else

            End If
        Next
        Return i
    End Function
    Private Function CountVisNodes(ByVal m As TreeNode) As Integer
        Dim i As Integer = 0
        i += m.Nodes.Count
        For Each n As TreeNode In m.Nodes
            If n.IsExpanded Then
                i += CountVisNodes(n)
            End If
        Next
        Return i
    End Function
    Protected Overrides Sub OnDrawNode(ByVal e As System.Windows.Forms.DrawTreeNodeEventArgs)
        If e.Node.Text = "" Then
            e.Graphics.FillRectangle(Brushes.White, e.Bounds)
        Else
            e.DrawDefault = True
            MyBase.OnDrawNode(e)
        End If
    End Sub
    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)

        MyBase.OnHandleCreated(e)
        Dim dw As Integer = NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_GETEXTENDEDSTYLE, 0, 0)

        ' Update style
        dw = dw Or NativeMethods.TVS_EX_AUTOHSCROLL
        ' autoscroll horizontaly
        'dw = dw Or NativeMethods.TVS_EX_FADEINOUTEXPANDOS
        ' auto hide the +/- signs
        'set style
        NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_SETEXTENDEDSTYLE, 0, dw)


        ' little black/empty arrows and blue highlight on treenodes
        NativeMethods.SetWindowTheme(Me.Handle, "explorer", Nothing)
    End Sub

End Class
Class clsFileIcon
    Declare Function FindExecutable Lib "shell32.dll" Alias "FindExecutableA" (ByVal lpFile As String, ByVal lpDirectory As String, ByVal lpResult As String) As Integer
    Shared Function LaunchNewBrowser() As String
        Dim BrowserExec As String = New String(" "c, 255)
        Try
            'CREATE SOME VARIABLES

            Dim FileName As String
            Dim RetVal As Long
            'Dim FileNumber As Integer
            Dim SWriter As StreamWriter
            'CREATE A TEMP HTM FILE SO WE CAN FIND OUT WHAT BROWSER IS
            'THE DEFAULT ONE ON THE SYSTEM
            FileName = Einstellungen.ChachePath & "\tm.html"
            SWriter = File.CreateText(FileName)
            SWriter.Write("<html></html>")
            SWriter.Close()
            'CALL THE API TO FIND THE EXE ASSOCIATED WITH HTM FILES
            RetVal = FindExecutable(FileName, vbNullString, BrowserExec)

            BrowserExec = BrowserExec.Trim
            File.Delete(FileName)
            'IF WE GET ONE, LAUNCH THE URL IN THE NEW INSTANCE OF THE BROWSER
            If RetVal <= 32 Or BrowserExec = String.Empty Then
                MessageBox.Show("Could not find a valid web browser")
                Return defaultbrowser()
            Else
                Return BrowserExec.Trim
                'Process.Start(BrowserExec, strUrl)
            End If
            'DELETE THAT PESKY TEMP FILE

        Catch ex As Exception
            'IF ANYTHING GOES WRONG, LET PEOPLE KNOW WHO'S FAULT IT IS

            'MessageBox.Show("An error has occured cause kleinma obviously can't write good code" & ControlChars.CrLf & ex.Message)
        End Try
        Return BrowserExec.Trim
    End Function
    Shared Function defaultbrowser() As String
        defaultbrowser = CStr(My.Computer.Registry.GetValue("HKEY_CLASSES_ROOT\HTTP\shell\open\command", "", "Not Found"))
        Dim shitplit() As String = Split(defaultbrowser, """")
        Return shitplit(1)
    End Function
    Shared Function GetDefaultIcon(ByVal arg As String) As System.Drawing.Icon
        Dim hImgSmall As IntPtr  ' Handle zur System-Image-List
        Dim shinfo As SHFILEINFO

        Try
            shinfo = New SHFILEINFO
            shinfo.szDisplayName = New String(Chr(0), 260)
            shinfo.szTypeName = New String(Chr(0), 80)
            hImgSmall = SHGetFileInfo(arg, 0, shinfo, Marshal.SizeOf(shinfo), _
              SHGFI_ICON Or SHGFI_SMALLICON)
            GetDefaultIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon)


        Catch ex As Exception
            shinfo.szDisplayName = New String(Chr(0), 260)
        End Try
    End Function
    ' Datei, für die das Icon ermittelt werden soll

#Region "Variablendeklaration"
    Private Structure SHFILEINFO
        Public hIcon As IntPtr  ' : icon
        Public iIcon As Integer ' : icondex
        Public dwAttributes As Integer ' : SFGAO_ flags
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> _
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> _
        Public szTypeName As String
    End Structure

    Private Declare Auto Function SHGetFileInfo Lib "shell32.dll" ( _
      ByVal pszPath As String, _
      ByVal dwFileAttributes As Integer, _
      ByRef psfi As SHFILEINFO, _
      ByVal cbFileInfo As Integer, _
      ByVal uFlags As Integer) As IntPtr

    Private Const SHGFI_ICON = &H100
    Private Const SHGFI_SMALLICON = &H1
    Private Const SHGFI_LARGEICON = &H0         ' Großes Symbol
    Private nIndex As Integer = 0
#End Region



End Class
Public Class ToolStripSeven
    Inherits System.Windows.Forms.ToolStrip
    Sub New()
        MyBase.New()
    End Sub

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cp.Style = cp.Style Or NativeMethods.TVS_NOHSCROLL
            ' lose the horizotnal scrollbar
            Return cp
        End Get
    End Property
    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        ' get style
        'Dim dw As Integer = NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_GETEXTENDEDSTYLE, 0, 0)

        '' Update style
        'dw = dw Or NativeMethods.TVS_EX_AUTOHSCROLL
        ' '' autoscroll horizontaly
        'dw = dw Or NativeMethods.TVS_EX_FADEINOUTEXPANDOS
        ' '' auto hide the +/- signs
        '' set style
        'NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_SETEXTENDEDSTYLE, 0, dw)

        ' little black/empty arrows and blue highlight on treenodes
        NativeMethods.SetWindowTheme(Me.Handle, "explorer", Nothing)
    End Sub
    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        MyBase.OnHandleCreated(e)
        Dim dw As Integer = NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_GETEXTENDEDSTYLE, 0, 0)

        '' Update style
        dw = dw Or NativeMethods.TVS_EX_AUTOHSCROLL
        '' autoscroll horizontaly
        dw = dw Or NativeMethods.TVS_EX_FADEINOUTEXPANDOS
        '' auto hide the +/- signs
        ' set style
        NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_SETEXTENDEDSTYLE, 0, dw)

        ' little black/empty arrows and blue highlight on treenodes
        NativeMethods.SetWindowTheme(Me.Handle, "explorer", Nothing)

    End Sub

End Class
Public Class ListViewVista
    Inherits System.Windows.Forms.ListView
    'Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
    '    'Get
    '    '    Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
    '    '    cp.Style = cp.Style Or NativeMethods.TVS_NOHSCROLL
    '    '    ' lose the horizotnal scrollbar
    '    '    Return cp
    '    'End Get
    'End Property

    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        MyBase.OnHandleCreated(e)

        '' get style
        'Dim dw As Integer = NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_GETEXTENDEDSTYLE, 0, 0)

        '' Update style

        ''dw = dw Or NativeMethods.TVS_EX_AUTOHSCROLL
        '' autoscroll horizontaly
        ''dw = dw Or NativeMethods.TVS_EX_FADEINOUTEXPANDOS
        '' auto hide the +/- signs
        '' set style
        'NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_SETEXTENDEDSTYLE, 0, dw)

        ' little black/empty arrows and blue highlight on treenodes
        NativeMethods.SetWindowTheme(Me.Handle, "explorer", Nothing)
    End Sub

End Class
Public Class DataGridViewStatusColumn
    Inherits DataGridViewImageColumn
    Public Sub New()
        Me.CellTemplate = New DataGridViewStatusCell
    End Sub

End Class
Public Class DataGridViewStatusCell
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
        Static emptyImage As Bitmap = New Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        GetFormattedValue = emptyImage
    End Function
    Protected Overrides Sub Paint(ByVal g As System.Drawing.Graphics, ByVal clipBounds As System.Drawing.Rectangle, ByVal cellBounds As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal cellState As System.Windows.Forms.DataGridViewElementStates, ByVal value As Object, ByVal formattedValue As Object, ByVal errorText As String, ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal advancedBorderStyle As System.Windows.Forms.DataGridViewAdvancedBorderStyle, ByVal paintParts As System.Windows.Forms.DataGridViewPaintParts)
        Dim progressVal As Integer = CType(value, Integer)
        'Dim percentage As Single = CType((progressVal / 100), Single)
        'Dim backBrush As Brush = New SolidBrush(cellStyle.BackColor)
        'Dim foreBrush As Brush = New SolidBrush(cellStyle.ForeColor)
        ' Call the base class method to paint the default cell appearance.
        MyBase.Paint(g, clipBounds, cellBounds, rowIndex, cellState, _
            value, formattedValue, errorText, cellStyle, _
            advancedBorderStyle, paintParts)


        Dim x, y, b, h, big As Integer
        big = 24
        If cellBounds.Height > 48 Then
            big = 48
        End If
        If cellBounds.Width > cellBounds.Height Then
            b = If(cellBounds.Height - 4 > 24, 24, cellBounds.Height - 4)
            h = If(cellBounds.Height - 4 > big, big, cellBounds.Height - 4)

        Else
            b = If(cellBounds.Width - 4 > 24, 24, cellBounds.Width - 4)
            h = If(cellBounds.Width - 4 > big, big, cellBounds.Width - 4)
        End If
        x = CInt(cellBounds.X + cellBounds.Width / 2 - b / 2)
        y = CInt(cellBounds.Y + cellBounds.Height / 2 - h / 2)
        If cellBounds.Height > 48 Then
            h = Convert.ToInt32(b * 2)
            y = CInt(cellBounds.Y + cellBounds.Height / 2 - b)
        End If
        Dim img As Bitmap = New Bitmap(24, 24)


        'Select Case progressVal
        '    Case Is = 1
        '        If cellBounds.Height < 48 Then
        '            img = My.Resources.Status1
        '        Else
        '            img = My.Resources.Status1big
        '        End If
        '    Case Is = 2
        '        If cellBounds.Height < 48 Then
        '            img = My.Resources.Status2
        '        Else
        '            img = My.Resources.Status2big
        '        End If
        '    Case Is = 3
        '        If cellBounds.Height < 48 Then
        '            img = My.Resources.Status3
        '        Else
        '            img = My.Resources.Status3big
        '        End If
        '    Case Is = 4
        '        If cellBounds.Height < 48 Then
        '            img = My.Resources.Status4
        '        Else
        '            img = My.Resources.Status4big
        '        End If
        '    Case Is = 5
        '        If cellBounds.Height < 48 Then
        '            img = My.Resources.Status5
        '        Else
        '            img = My.Resources.Status5big
        '        End If
        'End Select
        g.DrawImage(img, x, y, b, h)

        'If percentage > 0.0 Then
        '    ' Draw the progress bar and the text
        'g.FillRectangle(New SolidBrush(Color.FromArgb(163, 189, 242)), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 4)

        '    'g.FillRectangle(New SolidBrush(Color.FromArgb(15, 170, 46)), cellBounds.X + 2, cellBounds.Y + 2, Convert.ToInt32((percentage * cellBounds.Width - 4)), cellBounds.Height - 4)

        '    g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreBrush, cellBounds.X + 6, cellBounds.Y + 4)
        'Else
        '    'draw the text
        '    If Not Me.DataGridView.CurrentCell Is Nothing AndAlso Me.DataGridView.CurrentCell.RowIndex = rowIndex Then
        '        g.DrawString(progressVal.ToString() & "%", cellStyle.Font, New SolidBrush(cellStyle.SelectionForeColor), cellBounds.X + 6, cellBounds.Y + 4)
        '    Else
        '        g.DrawString(progressVal.ToString() & "%", cellStyle.Font, foreBrush, cellBounds.X + 6, cellBounds.Y + 4)
        '    End If

        'End If
    End Sub
End Class
Public Class ExpTree2
    Inherits System.Windows.Forms.TreeView
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As System.Windows.Forms.CreateParams = MyBase.CreateParams
            cp.Style = cp.Style Or NativeMethods.TVS_NOHSCROLL
            ' lose the horizotnal scrollbar
            Return cp
        End Get
    End Property
    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        ' get style
        Dim dw As Integer = NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_GETEXTENDEDSTYLE, 0, 0)

        ' Update style
        'dw = dw Or NativeMethods.TVS_EX_AUTOHSCROLL
        '' autoscroll horizontaly
        'dw = dw Or NativeMethods.TVS_EX_FADEINOUTEXPANDOS
        '' auto hide the +/- signs
        ' set style
        NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_SETEXTENDEDSTYLE, 0, dw)

        ' little black/empty arrows and blue highlight on treenodes
        NativeMethods.SetWindowTheme(Me.Handle, "explorer", Nothing)
    End Sub
    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        MyBase.OnHandleCreated(e)
        Dim dw As Integer = NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_GETEXTENDEDSTYLE, 0, 0)

        '' Update style
        'dw = dw Or NativeMethods.TVS_EX_AUTOHSCROLL
        '' autoscroll horizontaly
        'dw = dw Or NativeMethods.TVS_EX_FADEINOUTEXPANDOS
        '' auto hide the +/- signs
        ' set style
        NativeMethods.SendMessage(Me.Handle, NativeMethods.TVM_SETEXTENDEDSTYLE, 0, dw)

        ' little black/empty arrows and blue highlight on treenodes
        NativeMethods.SetWindowTheme(Me.Handle, "explorer", Nothing)

    End Sub
    Dim iList As New ImageList

    Public Sub New()
        Me.Sort()
        Me.HotTracking = True
        Me.HideSelection = False
        Me.ShowLines = False
        iList.ColorDepth = ColorDepth.Depth32Bit
        Me.ImageList = iList
        Me.FullRowSelect = True
        Me.ItemHeight = 20

    End Sub

    Public Sub ShowTree()
        For Each d As DriveInfo In DriveInfo.GetDrives
            If d.IsReady Then
                Me.ShowTree(d.Name)
            End If
        Next
    End Sub

    Public Sub ShowTree(ByVal Path As String)
        Dim nNode As New TreeNode(Path)
        nNode.ImageIndex = NEwIcon(Path)
        nNode.SelectedImageIndex = nNode.ImageIndex
        Me.Nodes.Add(nNode)
        Me.FillTreeNode(nNode)
    End Sub

    Public Sub ShowTree(ByVal DriveType As DriveType)
        For Each d As DriveInfo In DriveInfo.GetDrives
            If d.DriveType = DriveType Then
                Dim f As DirectoryInfo = d.RootDirectory
                If f.Attributes = (FileAttributes.System Or f.Attributes) Or f.Attributes = (FileAttributes.Hidden Or f.Attributes) Then
                Else
                    If d.IsReady Then
                        Me.ShowTree(d.Name)
                    End If
                End If

            End If
        Next
    End Sub

    Private Sub FillTreeNode(ByVal dNode As TreeNode)
        Try
            Dim d As New DirectoryInfo(dNode.FullPath)
            For Each f As DirectoryInfo In d.GetDirectories
                If f.Attributes = (FileAttributes.System Or f.Attributes) Or f.Attributes = (FileAttributes.Hidden Or f.Attributes) Then


                Else


                    Dim nNode As New TreeNode(f.Name)
                    nNode.ImageIndex = NEwIcon(f.FullName)
                    nNode.SelectedImageIndex = nNode.ImageIndex
                    dNode.Nodes.Add(nNode)
                    nNode.Nodes.Add("")
                End If


            Next
        Catch : End Try
    End Sub

    Protected Overrides Sub OnBeforeExpand(ByVal e As System.Windows.Forms.TreeViewCancelEventArgs)
        Dim n As TreeNode = CType(e.Node, TreeNode)
        If n.Nodes(0).Text = "" Then
            Me.BeginUpdate()
            n.Nodes.Clear()
            Me.FillTreeNode(n)
            Me.EndUpdate()
        End If
        MyBase.OnBeforeExpand(e)
    End Sub

    Private Function NEwIcon(ByVal Path As String) As Integer

        Dim img As Icon = clsFileIcon.GetDefaultIcon(Path)
        If Not IsNothing(img) Then
            iList.Images.Add(img)
        End If

        Return iList.Images.Count - 1
    End Function

End Class
' For the latest version visit: http://wyday.com/linklabel2/

' Bugs or suggestions: http://wyday.com/forum/
Public Class test
    Inherits TabControl
  
    <DllImport("user32.dll")> _
    Public Shared Function LoadCursor(ByVal hInstance As Integer, ByVal lpCursorName As Integer) As Integer
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SetCursor(ByVal hCursor As Integer) As Integer
    End Function

    Protected Overloads Overrides Sub WndProc(ByRef m As Message)
        'WM_SETCURSOR == 32
        If m.Msg = 32 Then
            'IDC_HAND == 32649
            SetCursor(LoadCursor(0, 32649))

            'the message has been handled
            m.Result = IntPtr.Zero
            Exit Sub
        End If

        MyBase.WndProc(m)
    End Sub
End Class
Namespace wyDay.Controls
    Public Class LinkLabel2
        Inherits Control
        Private hoverFont As Font

        Private textRect As Rectangle

        Private isHovered As Boolean
        Private keyAlreadyProcessed As Boolean

        Private m_image As Image
        Private m_imageRightPad As Integer = 8



        <DefaultValue(8)> _
        Public Property ImageRightPad() As Integer
            Get
                Return m_imageRightPad
            End Get
            Set(ByVal value As Integer)
                m_imageRightPad = value

                RefreshTextRect()
                Invalidate()
            End Set
        End Property

        '<DefaultValue(Nothing)> _
        Public Property Image() As Image
            Get
                Return m_image
            End Get
            Set(ByVal value As Image)
                m_image = value

                RefreshTextRect()
                Invalidate()
            End Set
        End Property

        Private _HoverUnderline As Boolean
        <DefaultValue(True)> _
        Public Property HoverUnderline() As Boolean
            Get
                Return _HoverUnderline
            End Get
            Set(ByVal value As Boolean)
                _HoverUnderline = value
            End Set
        End Property

        Private _UseSystemColor As Boolean
        <DefaultValue(True)> _
        Public Property UseSystemColor() As Boolean
            Get
                Return _UseSystemColor
            End Get
            Set(ByVal value As Boolean)
                _UseSystemColor = value
            End Set
        End Property


        Private _RegularColor As Color
        Public Property RegularColor() As Color
            Get
                Return _RegularColor
            End Get
            Set(ByVal value As Color)
                _RegularColor = value
            End Set
        End Property
        Private _HoverColor As Color
        Public Property HoverColor() As Color
            Get
                Return _HoverColor
            End Get
            Set(ByVal value As Color)
                _HoverColor = value
            End Set
        End Property


        <DllImport("user32.dll")> _
        Public Shared Function LoadCursor(ByVal hInstance As Integer, ByVal lpCursorName As Integer) As Integer
        End Function

        <DllImport("user32.dll")> _
        Public Shared Function SetCursor(ByVal hCursor As Integer) As Integer
        End Function

        Public Overloads Overrides Property Text() As String
            Get
                Return MyBase.Text
            End Get
            Set(ByVal value As String)
                MyBase.Text = value

                RefreshTextRect()

                Invalidate()
            End Set
        End Property

        Public Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.FixedHeight Or ControlStyles.FixedWidth, True)

            SetStyle(ControlStyles.StandardClick Or ControlStyles.StandardDoubleClick, False)

            hoverFont = New Font(Font, FontStyle.Underline)

            ForeColor = SystemColors.HotTrack

            UseSystemColor = True
            HoverUnderline = True
        End Sub

        Protected Overloads Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            If e.Button = MouseButtons.Left Then
                Focus()
            End If

            MyBase.OnMouseDown(e)
        End Sub

        Protected Overloads Overrides Sub OnMouseEnter(ByVal e As EventArgs)
            isHovered = True
            Invalidate()

            MyBase.OnMouseEnter(e)
        End Sub

        Protected Overloads Overrides Sub OnMouseLeave(ByVal e As EventArgs)
            isHovered = False
            Invalidate()

            MyBase.OnMouseLeave(e)
        End Sub

        Protected Overloads Overrides Sub OnMouseMove(ByVal mevent As MouseEventArgs)
            MyBase.OnMouseMove(mevent)
            If mevent.Button <> MouseButtons.None Then
                If Not ClientRectangle.Contains(mevent.Location) Then
                    If isHovered Then
                        isHovered = False
                        Invalidate()
                    End If
                ElseIf Not isHovered Then
                    isHovered = True
                    Invalidate()
                End If
            End If
        End Sub

        Protected Overloads Overrides Sub OnGotFocus(ByVal e As EventArgs)
            Invalidate()

            MyBase.OnGotFocus(e)
        End Sub

        Protected Overloads Overrides Sub OnLostFocus(ByVal e As EventArgs)
            keyAlreadyProcessed = False
            Invalidate()

            MyBase.OnLostFocus(e)
        End Sub



        Protected Overloads Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
            If Not keyAlreadyProcessed AndAlso e.KeyCode = Keys.Enter Then
                keyAlreadyProcessed = True
                OnClick(e)
            End If

            MyBase.OnKeyDown(e)
        End Sub

        Protected Overloads Overrides Sub OnKeyUp(ByVal e As KeyEventArgs)
            keyAlreadyProcessed = False

            MyBase.OnKeyUp(e)
        End Sub

        Protected Overloads Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            If isHovered AndAlso e.Clicks = 1 AndAlso (e.Button = MouseButtons.Left OrElse e.Button = MouseButtons.Middle) Then
                OnClick(e)
            End If

            MyBase.OnMouseUp(e)
        End Sub

        Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed
            e.Graphics.InterpolationMode = InterpolationMode.Low

            ' image
            If m_image IsNot Nothing Then
                e.Graphics.DrawImage(m_image, New Rectangle(0, 0, m_image.Width, m_image.Height), New Rectangle(0, 0, m_image.Width, m_image.Height), GraphicsUnit.Pixel)
            End If

            'text
            TextRenderer.DrawText(e.Graphics, Text, If(isHovered AndAlso HoverUnderline, hoverFont, Font), textRect, If(UseSystemColor, ForeColor, (If(isHovered, HoverColor, RegularColor))), TextFormatFlags.SingleLine Or TextFormatFlags.NoPrefix)

            ' draw the focus rectangle.
            If Focused AndAlso ShowFocusCues Then
                ControlPaint.DrawFocusRectangle(e.Graphics, ClientRectangle)
            End If
        End Sub

        Protected Overloads Overrides Sub OnFontChanged(ByVal e As EventArgs)
            hoverFont = New Font(Font, FontStyle.Underline)
            RefreshTextRect()

            MyBase.OnFontChanged(e)
        End Sub

        Private Sub RefreshTextRect()
            textRect = New Rectangle(Point.Empty, TextRenderer.MeasureText(Text, Font, Size, TextFormatFlags.SingleLine Or TextFormatFlags.NoPrefix))
            Dim width As Integer = textRect.Width + 1, height As Integer = textRect.Height + 1

            If m_image IsNot Nothing Then
                width = textRect.Width + 1 + m_image.Width + m_imageRightPad

                'adjust the x position of the text
                textRect.X += m_image.Width + m_imageRightPad

                If m_image.Height > textRect.Height Then
                    height = m_image.Height + 1

                    ' adjust the y-position of the text
                    textRect.Y = CInt(textRect.Y + ((m_image.Height - textRect.Height) / 2))
                End If
            End If

            Size = New Size(width, height)
        End Sub

        Protected Overloads Overrides Sub WndProc(ByRef m As Message)
            'WM_SETCURSOR == 32
            If m.Msg = 32 Then
                'IDC_HAND == 32649
                SetCursor(LoadCursor(0, 32649))

                'the message has been handled
                m.Result = IntPtr.Zero
                Exit Sub
            End If

            MyBase.WndProc(m)
        End Sub
    End Class



End Namespace
