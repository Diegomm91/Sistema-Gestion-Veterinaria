Imports System.Data.SQLite

Public Class ProductoRepository
    Public Function ObtenerTodos() As List(Of Producto)
        Dim productos As New List(Of Producto)
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "SELECT id_producto, nombre, categoria, precio, stock FROM Productos ORDER BY nombre"
        Using command As New SQLiteCommand(sql, connection)
            Using reader As SQLiteDataReader = command.ExecuteReader()
                While reader.Read()
                    productos.Add(New Producto With {
                        .IdProducto = reader.GetInt32(0),
                        .Nombre = reader.GetString(1),
                        .Categoria = If(reader.IsDBNull(2), Nothing, reader.GetString(2)),
                        .Precio = reader.GetDecimal(3),
                        .Stock = reader.GetInt32(4)
                    })
                End While
            End Using
        End Using
        Return productos
    End Function

    Public Sub Insertar(producto As Producto)
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "INSERT INTO Productos (nombre, categoria, precio, stock) VALUES (@nombre, @categoria, @precio, @stock)"
        Using command As New SQLiteCommand(sql, connection)
            command.Parameters.AddWithValue("@nombre", producto.Nombre)
            command.Parameters.AddWithValue("@categoria", producto.Categoria)
            command.Parameters.AddWithValue("@precio", producto.Precio)
            command.Parameters.AddWithValue("@stock", producto.Stock)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub Actualizar(producto As Producto)
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "UPDATE Productos SET nombre = @nombre, categoria = @categoria, precio = @precio, stock = @stock WHERE id_producto = @id_producto"
        Using command As New SQLiteCommand(sql, connection)
            command.Parameters.AddWithValue("@nombre", producto.Nombre)
            command.Parameters.AddWithValue("@categoria", producto.Categoria)
            command.Parameters.AddWithValue("@precio", producto.Precio)
            command.Parameters.AddWithValue("@stock", producto.Stock)
            command.Parameters.AddWithValue("@id_producto", producto.IdProducto)
            command.ExecuteNonQuery()
        End Using
    End Sub

    Public Sub Eliminar(id As Integer)
        Dim connection As SQLiteConnection = DatabaseHelper.GetConnection()
        Dim sql As String = "DELETE FROM Productos WHERE id_producto = @id"
        Using command As New SQLiteCommand(sql, connection)
            command.Parameters.AddWithValue("@id", id)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Class