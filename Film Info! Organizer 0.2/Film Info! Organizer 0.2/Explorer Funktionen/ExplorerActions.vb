
Imports System.Runtime.InteropServices

Public Class ExplorerActions
    ' KONSTANTEN DER FUNC

    ' Kopiert das File in pFROM nach pTo
    Private Const FN_COPY = &H2&

    ' Löscht das File in pFrom (pTo wird ignoriert)
    Private Const FN_DELETE = &H3&

    ' Verschiebt das File in pFROM nach pTo
    Private Const FN_MOVE = &H1&

    ' Umbenennen des Files in pTo
    Private Const FN_RENAME = &H4&


    ' KONSTANTEN DER FLAGS

    ' Undo Information -> Schiebt beim Löschen
    ' das (die) File(s) in den Papierkorb
    Private Const FNF_ALLOWUNDO = &H40&

    ' Bislang keine bekannte Funktion
    Private Const FNF_CONFIRMMOUSE = &H2&

    ' Handle zum Eltern-Fenster der
    ' Progress-Dialogbox (also Me.hwnd)
    Private Const FnF_CREATEPROGRESSDLG = &H0&

    ' Nur Files - KEINE ORDNER - wenn *.* als Source
    Private Const FnF_FILESONLY = &H80&

    ' Für diverse Stellen bei DEST (der "pTo" muss dann
    ' die gleiche Anzahl von Zielen aufweisen wie "pFrom"
    Private Const FnF_MULTIDESTFILES = &H1&

    ' ANTWORTET AUTOMATISCH MIT 'JA für alle'
    Private Const FnF_NOCONFIRMATION = &H10&

    ' Keine Abfrage für einen neuen Ordner, falls benötigt
    Private Const FnF_NOCONFIRMMKDIR = &H200&

    ' Bei Namenskollisionen im ZIEL wird ein neuer Name
    ' erzeugt (z.B. Kopie(2) von xy.tmp)
    Private Const FnF_RENAMEONCOLLISION = &H8&

    ' Zeigt keine Fortschritts-Dialogbox (fliegende Blätter)
    Private Const FnF_SILENT = &H4&

    ' Zeigt die Fortschritts-Dialogbox an, aber ohne Filenamen
    Private Const FnF_SIMPLEPROGRESS = &H100&

    ' Wenn FnF_RENAMECOLLISION gewählt wird,
    ' hNameMappings wird gefüllt (Anzahl)
    Private Const FnF_WANTMAPPINGHANDLE = &H20&

    ' Eine Funktion für vier Dateioperationen
    <DllImport("shell32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SHFileOperation(ByRef FileOp As SHFILEOPSTRUCT) As Integer
    End Function
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto, Pack:=1)> _
    Public Structure SHFILEOPSTRUCT
        Public hwnd As IntPtr
        <MarshalAs(UnmanagedType.U4)> _
        Public wFunc As Integer
        Public pFrom As String
        Public pTo As String
        Public fFlags As Short
        <MarshalAs(UnmanagedType.Bool)> _
        Public fAnyOperationsAborted As Boolean
        Public hNameMappings As IntPtr
        Public lpszProgressTitle As String
    End Structure
    Public Function fCopy(ByVal Source As String, ByVal Dest As String, _
  ByVal Ueberschreiben As Boolean) As Long

        ' Ueberschreiben: True, wenn ohne Warnung überschrieben
        '     werden soll (Entspricht -y beim DOS copy BEFEHL)

        Dim FileStructur As SHFILEOPSTRUCT
        Dim FLAG As Integer

        FLAG = 0
        If InStr(Source, vbNullChar + vbNullChar) > 0 Then _
          FLAG = CInt(FLAG + FnF_MULTIDESTFILES)

        If InStr(Source, "*") > 0 Then _
          FLAG = CInt(FLAG + FnF_FILESONLY)

        If Ueberschreiben = True Then _
          FLAG = CInt(FLAG + FnF_RENAMEONCOLLISION)

        With FileStructur
            .wFunc = FN_COPY
            .pFrom = Check_NullChars(Source)
            .pTo = Dest
            .fFlags = CShort(FLAG)
        End With

        fCopy = SHFileOperation(FileStructur)
    End Function
    Public Function fmanyCopy(ByVal li As List(Of Movie), ByVal Dest As String, _
ByVal Ueberschreiben As Boolean) As Long

        Dim FileStructur As SHFILEOPSTRUCT
        Dim FLAG As Integer


        For Each m In li
            With FileStructur
                FLAG = 0
                If InStr(m.Pfad, vbNullChar + vbNullChar) > 0 Then _
                  FLAG = CInt(FLAG + FnF_MULTIDESTFILES)

                If InStr(m.Pfad, "*") > 0 Then _
                  FLAG = CInt(FLAG + FnF_FILESONLY)

                If Ueberschreiben = True Then _
                  FLAG = CInt(FLAG + FnF_RENAMEONCOLLISION)
                .wFunc = FN_COPY
                .pFrom &= Check_SglNullChars(m.Pfad)
                .pTo = Dest
                .fFlags = CShort(FLAG)
            End With
        Next
        fmanyCopy = SHFileOperation(FileStructur)
    End Function
    Public Function fmanyMove(ByVal li As List(Of Movie), ByVal Dest As String) As Long

        Dim FileStructur As SHFILEOPSTRUCT

        For Each m In li
            With FileStructur

                .wFunc = FN_MOVE
                .pFrom &= Check_SglNullChars(m.Pfad)
                .pTo = Dest
                .fFlags = FnF_RENAMEONCOLLISION
            End With
        Next
        fmanyMove = SHFileOperation(FileStructur)
    End Function
    Public Function fmanyCopy(ByVal args() As String, ByVal Dest As String) As Long

        If Not args.Length = 0 Then
            Dim FileStructur As SHFILEOPSTRUCT
            For Each m In args
                With FileStructur
                    .wFunc = FN_COPY
                    .pFrom &= Check_SglNullChars(m)
                    .pTo = Dest
                    .fFlags = FNF_CONFIRMMOUSE
                End With
            Next
            fmanyCopy = SHFileOperation(FileStructur)
        End If
    End Function
    Public Function fmanyMove(ByVal args() As String, ByVal Dest As String) As Long


        If Not args.Length = 0 Then
            Dim FileStructur As SHFILEOPSTRUCT
            For Each m In args
                With FileStructur

                    .wFunc = FN_MOVE
                    .pFrom &= Check_SglNullChars(m)
                    .pTo = Dest
                    .fFlags = FNF_CONFIRMMOUSE
                End With
            Next
            fmanyMove = SHFileOperation(FileStructur)
        End If


    End Function


    Public Function fmanyDelete(ByVal li As List(Of Movie), ByVal DelToTrash As _
  Boolean, ByVal ShowDialog As Boolean) As Long

        ' DelToTrash: True, wenn in Papierkorb gelöscht
        ' ShowDialog: True, wenn zusätzlich Löschabfrage
        '             erfolgen soll

        Dim FileStructur As SHFILEOPSTRUCT
        Dim Flags As Long

        Flags = 0
        If DelToTrash Then Flags = FNF_ALLOWUNDO
        If Not ShowDialog Then Flags = Flags Or FnF_NOCONFIRMATION

        With FileStructur
            .wFunc = FN_DELETE
            For Each m In li
                .pFrom &= Check_SglNullChars(m.Pfad)
            Next


            .fFlags = CShort(Flags)
        End With

        fmanyDelete = SHFileOperation(FileStructur)
    End Function
    Public Function fDelete(ByVal Source As String, ByVal DelToTrash As _
  Boolean, ByVal ShowDialog As Boolean) As Long

        ' DelToTrash: True, wenn in Papierkorb gelöscht
        ' ShowDialog: True, wenn zusätzlich Löschabfrage
        '             erfolgen soll

        Dim FileStructur As SHFILEOPSTRUCT
        Dim Flags As Long

        Flags = 0
        If DelToTrash Then Flags = FNF_ALLOWUNDO
        If Not ShowDialog Then Flags = Flags Or FnF_NOCONFIRMATION

        With FileStructur
            .wFunc = FN_DELETE

            .pFrom = Check_NullChars(Source)

            .fFlags = CShort(Flags)
        End With

        fDelete = SHFileOperation(FileStructur)
    End Function
    Public Function fMove(ByVal Source As String, _
  ByVal Dest As String) As Long

        Dim FileStructur As SHFILEOPSTRUCT

        With FileStructur
            .wFunc = FN_MOVE
            .pFrom = Check_NullChars(Source)
            .pTo = Dest
            .fFlags = FnF_RENAMEONCOLLISION
        End With

        fMove = SHFileOperation(FileStructur)
    End Function
    Public Function fRename(ByVal Source As String, _
  ByVal Dest As String) As Long

        Dim FileStructur As SHFILEOPSTRUCT

        With FileStructur
            .wFunc = FN_RENAME
            .pFrom = Check_NullChars(Source)
            .pTo = Dest
            .fFlags = FnF_RENAMEONCOLLISION + FnF_SILENT
        End With

        fRename = SHFileOperation(FileStructur)
    End Function
    ' Alle Dateinamen eines Array-Datenfeldes hintereinander
    ' - durch vbNullChar getrennt - zusammenfassen
    Public Function FilesFromArray(ByVal Liste() As String) As String
        Dim i As Long
        Dim temp As String

        For i = 0 To UBound(Liste)
            If FileExists(Liste(CInt(i))) Then
                ' Datei-Eintrag mit CHR(0) abschließen
                temp = temp + Liste(CInt(i)) + vbNullChar
            Else
                MsgBox(Liste(CInt(i)) & "existiert hier nicht")
            End If
        Next

        ' Notwendig: Abschließendes CHR(0)
        FilesFromArray = temp + vbNullChar
    End Function

    ' Alle Angaben müssen mit vbNullChar+vbNullChar
    ' abgeschlossen werden. Hier wird's noch mal geprüft
    Private Function Check_NullChars(ByVal S As String) As String
        If Right(S, 2) <> vbNullChar + vbNullChar Then
            If Right(S, 1) <> vbNullChar Then
                S = S + vbNullChar + vbNullChar
            Else
                S = S + vbNullChar
            End If
        End If
        Check_NullChars = S
    End Function
    Private Function Check_SglNullChars(ByVal S As String) As String

        If Right(S, 1) <> vbNullChar Then
            S = S + vbNullChar
        End If
        Check_SglNullChars = S
    End Function
    ' Prüfen, ob Datei existiert
    Public Function FileExists(ByVal Filename As String) _
      As Boolean

        FileExists = (Dir(Filename) <> "")
    End Function

 

End Class
