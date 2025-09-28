Imports System.Data.SQLite
Imports System.IO

Public Class DatabaseHelper
    Private Const DbFileName As String = "veterinaria.db"
    Private Shared ReadOnly LazyConnection As Lazy(Of SQLiteConnection) = New Lazy(Of SQLiteConnection)(AddressOf CreateConnection)

    Private Shared Function CreateConnection() As SQLiteConnection
        Dim dbFilePath As String = Path.Combine(Application.StartupPath, DbFileName)
        Dim connectionString As String = $"Data Source={dbFilePath};Version=3;"

        If Not File.Exists(dbFilePath) Then
            SQLiteConnection.CreateFile(dbFilePath)
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Dim sql As String = "
                    CREATE TABLE Propietarios (
                        id_propietario INTEGER PRIMARY KEY AUTOINCREMENT,
                        nombre TEXT NOT NULL,
                        apellido TEXT NOT NULL,
                        dni TEXT NOT NULL UNIQUE,
                        telefono TEXT,
                        direccion TEXT
                    );"
                Using command As New SQLiteCommand(sql, connection)
                    command.ExecuteNonQuery()
                End Using

                Dim sqlMascotas As String = "
                    CREATE TABLE Mascotas (
                        id_mascota INTEGER PRIMARY KEY AUTOINCREMENT,
                        nombre TEXT NOT NULL,
                        especie TEXT NOT NULL,
                        raza TEXT,
                        edad INTEGER,
                        id_propietario INTEGER,
                        FOREIGN KEY (id_propietario) REFERENCES Propietarios(id_propietario)
                    );"
                Using commandMascotas As New SQLiteCommand(sqlMascotas, connection)
                    commandMascotas.ExecuteNonQuery()
                End Using

                Dim sqlProductos As String = "
                    CREATE TABLE Productos (
                        id_producto INTEGER PRIMARY KEY AUTOINCREMENT,
                        nombre TEXT NOT NULL,
                        categoria TEXT,
                        precio REAL NOT NULL,
                        stock INTEGER NOT NULL
                    );"
                Using commandProductos As New SQLiteCommand(sqlProductos, connection)
                    commandProductos.ExecuteNonQuery()
                End Using
            End Using
        End If

        Dim dbConnection As New SQLiteConnection(connectionString)
        dbConnection.Open()
        Return dbConnection
    End Function

    Public Shared Function GetConnection() As SQLiteConnection
        Return LazyConnection.Value
    End Function
End Class