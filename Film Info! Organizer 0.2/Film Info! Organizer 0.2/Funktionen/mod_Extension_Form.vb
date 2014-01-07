Module mod_Extension_Form
    ' API-Funktion, um das Fenster-Handle des Fensters im 
    ' Vordergrund zu bestimmen
    Private Declare Function GetForegroundWindow Lib "user32" _
      Alias "GetForegroundWindow" () As IntPtr

    Private Function GetFGWindowHandle() As IntPtr
        Dim fg_hwnd As IntPtr = GetForegroundWindow()
        Return fg_hwnd
    End Function

    ' Deklaration der Extension-Method durch Attribut und Funktions-Kopf
    ' Bei Extension-Methods gibt der Datentyp des ersten Parameters in der 
    ' Liste an, welche Klasse erweitert werden soll. 
    ' (Hier die Klasse Windows.Forms.Form)
    <System.Runtime.CompilerServices.Extension()> _
    Friend Function IsMeForeGroundWindow(ByVal f As Form) As Boolean
        ' Auswertung ob das Handle des aktiven Fensters gleich dem des 
        ' eigenen Fensters ist
        ' (--> Das eigene Fenster ist im Vordergrund)
        Return Not CBool(f.Handle.ToInt32 Xor GetFGWindowHandle().ToInt32)
    End Function
End Module
