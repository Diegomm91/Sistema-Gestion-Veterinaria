Imports System.Data.SQLite
Imports System.Collections.Generic

Public Class PropietarioRepository
    Public Sub Insertar(propietario As Propietario)
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "INSERT INTO Propietarios (nombre, apellido, dni, telefono, direccion) VALUES (@nombre, @apellido, @dni, @telefono, @direccion)"
        Using command As New SQLiteCommand(sql, connection)
            command.Parameters.AddWithValue("@nombre", propietario.Nombre)
            command.Parameters.AddWithValue("@apellido", propietario.Apellido)
            command.Parameters.AddWithValue("@dni", propietario.Dni)
            command.Parameters.AddWithValue("@telefono", propietario.Telefono)
            command.Parameters.AddWithValue("@direccion", propietario.Direccion)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub Actualizar(propietario As Propietario)
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "UPDATE Propietarios SET nombre = @nombre, apellido = @apellido, dni = @dni, telefono = @telefono, direccion = @direccion WHERE id_propietario = @id_propietario"
        Using command As New SQLiteCommand(sql, connection)
            command.Parameters.AddWithValue("@nombre", propietario.Nombre)
            command.Parameters.AddWithValue("@apellido", propietario.Apellido)
            command.Parameters.AddWithValue("@dni", propietario.Dni)
            command.Parameters.AddWithValue("@telefono", propietario.Telefono)
            command.Parameters.AddWithValue("@direccion", propietario.Direccion)
            command.Parameters.AddWithValue("@id_propietario", propietario.IdPropietario)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Function ObtenerTodos() As List(Of Propietario)
        Dim propietarios As New List(Of Propietario)
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "SELECT id_propietario, nombre, apellido, dni, telefono, direccion FROM Propietarios ORDER BY apellido"
        Using command As New SQLiteCommand(sql, connection)
            Using reader As SQLiteDataReader = command.ExecuteReader()
                While reader.Read()
                    propietarios.Add(New Propietario With {
                        .IdPropietario = reader.GetInt32(0),
                        .Nombre = reader.GetString(1),
                        .Apellido = reader.GetString(2),
                        .Dni = reader.GetString(3),
                        .Telefono = reader.GetString(4),
                        .Direccion = reader.GetString(5)
                    })
                End While
            End Using
        End Using
        Return propietarios
    End Function

    Public Function ObtenerPorId(id As Integer) As Propietario
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "SELECT id_propietario, nombre, apellido, dni, telefono, direccion FROM Propietarios WHERE id_propietario = @id"
        Using command As New SQLiteCommand(sql, connection)
            command.Parameters.AddWithValue("@id", id)
            Using reader As SQLiteDataReader = command.ExecuteReader()
                If reader.Read() Then
                    Return New Propietario With {
                        .IdPropietario = reader.GetInt32(0),
                        .Nombre = reader.GetString(1),
                        .Apellido = reader.GetString(2),
                        .Dni = reader.GetString(3),
                        .Telefono = reader.GetString(4),
                        .Direccion = reader.GetString(5)
                    }
                End If
            End Using
        End Using
        Return Nothing
    End Function
    Public Sub Eliminar(id As Integer)
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "DELETE FROM Propietarios WHERE id_propietario = @id"
        Using command As New SQLiteCommand(sql, connection)
            command.Parameters.AddWithValue("@id", id)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Class