Public Class Propietario
    Public Property IdPropietario As Integer
    Public Property Nombre As String
    Public Property Apellido As String
    Public Property Dni As String
    Public Property Telefono As String
    Public Property Direccion As String

    Public ReadOnly Property NombreCompleto As String
        Get
            Return $"{Nombre} {Apellido}"
        End Get
    End Property
End Class