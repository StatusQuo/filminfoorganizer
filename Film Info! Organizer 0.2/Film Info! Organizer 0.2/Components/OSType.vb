''' <summary>
''' Ermöglicht die Abfrage, ob es sich um ein 32- oder 64-Bit basierendes Betriebssystem handelt.
''' </summary>
<System.ComponentModel.Description("Ermöglicht die Abfrage, ob es sich um ein 32- oder 64-Bit basierendes Betriebssystem handelt.")> _
Public Class OS
    Public Enum OSType
        Is32Bit
        Is64Bit
    End Enum

    ''' <summary>
    ''' Gibt den Typ des Betriebssystems zurück (32 oder 64 Bit)
    ''' </summary>
    <System.ComponentModel.Description("Gibt den Typ des Betriebssystems zurück, also 32 oder 64 Bit")> _
    Public Shared Function GetOSType() As OSType
        Return If(IntPtr.Size = 4, OSType.Is32Bit, OSType.Is64Bit)
    End Function
End Class