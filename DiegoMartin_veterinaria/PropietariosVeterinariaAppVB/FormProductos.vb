Public Class FormProductos
    Private productoRepository As New ProductoRepository()

    Private Sub FormProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductos()
        LimpiarCampos()
    End Sub

    Private Sub CargarProductos()
        Dim productos = productoRepository.ObtenerTodos()
        dgvProductos.DataSource = productos
        dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvProductos.ReadOnly = True
        dgvProductos.AllowUserToAddRows = False
        dgvProductos.AllowUserToDeleteRows = False
    End Sub

    Private Sub LimpiarCampos()
        txtIdProducto.Text = ""
        txtNombre.Text = ""
        txtCategoria.Text = ""
        txtPrecio.Text = ""
        txtStock.Text = ""
        btnGuardar.Text = "Guardar"
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarCampos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim producto As New Producto With {
            .Nombre = txtNombre.Text,
            .Categoria = txtCategoria.Text,
            .Precio = Decimal.Parse(txtPrecio.Text),
            .Stock = Integer.Parse(txtStock.Text)
        }

        If String.IsNullOrEmpty(txtIdProducto.Text) Then
            productoRepository.Insertar(producto)
            MessageBox.Show("Producto guardado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            producto.IdProducto = Convert.ToInt32(txtIdProducto.Text)
            productoRepository.Actualizar(producto)
            MessageBox.Show("Producto actualizado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        CargarProductos()
        LimpiarCampos()
    End Sub

    Private Sub dgvProductos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvProductos.Rows(e.RowIndex)
            txtIdProducto.Text = row.Cells("IdProducto").Value.ToString()
            txtNombre.Text = row.Cells("Nombre").Value.ToString()
            txtCategoria.Text = row.Cells("Categoria").Value.ToString()
            txtPrecio.Text = row.Cells("Precio").Value.ToString()
            txtStock.Text = row.Cells("Stock").Value.ToString()
            btnGuardar.Text = "Modificar"
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Not String.IsNullOrEmpty(txtIdProducto.Text) Then
            If MessageBox.Show("¿Está seguro que desea eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                productoRepository.Eliminar(Convert.ToInt32(txtIdProducto.Text))
                CargarProductos()
                LimpiarCampos()
            End If
        Else
            MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class