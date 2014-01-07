Public Class Export_Value_Control
    Property _Text As String
        Get
            Return Label1.Text
        End Get
        Set(ByVal value As String)
            Label1.Text = value
        End Set
    End Property
    Property _Value As String
        Get
            Return ComboBox1.Text
        End Get
        Set(ByVal value As String)
            ComboBox1.Text = value
        End Set
    End Property
    Property _Type As value_Type
        Get
            If ComboBox1.DropDownStyle = ComboBoxStyle.DropDown Then
                Return value_Type.Text
            Else
                Return value_Type.DropDown
            End If

        End Get
        Set(ByVal value As value_Type)
            If value = value_Type.DropDown Then
                ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
            Else
                ComboBox1.DropDownStyle = ComboBoxStyle.DropDown
            End If
        End Set
    End Property
    Enum value_Type
        Text
        DropDown
    End Enum

End Class
