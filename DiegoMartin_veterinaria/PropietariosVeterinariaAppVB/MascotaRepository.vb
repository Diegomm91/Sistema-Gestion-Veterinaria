Imports System.Data.SQLite

Public Class MascotaRepository
    Public Shared Function GetAllMascotas() As List(Of Mascota)
        Dim mascotas As New List(Of Mascota)
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "SELECT id_mascota, nombre, especie, raza, edad, id_propietario FROM Mascotas"
        Using command As New SQLiteCommand(sql, connection)
            Using reader As SQLiteDataReader = command.ExecuteReader()
                While reader.Read()
                    mascotas.Add(New Mascota With {
                        .IdMascota = reader.GetInt32(0),
                        .Nombre = reader.GetString(1),
                        .Especie = reader.GetString(2),
                        .Raza = If(reader.IsDBNull(3), Nothing, reader.GetString(3)),
                        .Edad = If(reader.IsDBNull(4), 0, reader.GetInt32(4)),
                        .IdPropietario = reader.GetInt32(5)
                    })
                End While
            End Using
        End Using
        Return mascotas
    End Function

    Public Shared Sub AddMascota(mascota As Mascota)
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "INSERT INTO Mascotas (nombre, especie, raza, edad, id_propietario) VALUES (@nombre, @especie, @raza, @edad, @id_propietario)"
        Using command As New SQLiteCommand(sql, connection)
            command.Parameters.AddWithValue("@nombre", mascota.Nombre)
            command.Parameters.AddWithValue("@especie", mascota.Especie)
            command.Parameters.AddWithValue("@raza", mascota.Raza)
            command.Parameters.AddWithValue("@edad", mascota.Edad)
            command.Parameters.AddWithValue("@id_propietario", mascota.IdPropietario)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Shared Sub UpdateMascota(mascota As Mascota)
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "UPDATE Mascotas SET nombre = @nombre, especie = @especie, raza = @raza, edad = @edad, id_propietario = @id_propietario WHERE id_mascota = @id_mascota"
        Using command As New SQLiteCommand(sql, connection)
            command.Parameters.AddWithValue("@nombre", mascota.Nombre)
            command.Parameters.AddWithValue("@especie", mascota.Especie)
            command.Parameters.AddWithValue("@raza", mascota.Raza)
            command.Parameters.AddWithValue("@edad", mascota.Edad)
            command.Parameters.AddWithValue("@id_propietario", mascota.IdPropietario)
            command.Parameters.AddWithValue("@id_mascota", mascota.IdMascota)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Shared Sub DeleteMascota(idMascota As Integer)
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "DELETE FROM Mascotas WHERE id_mascota = @id_mascota"
        Using command As New SQLiteCommand(sql, connection)
            command.Parameters.AddWithValue("@id_mascota", idMascota)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Class