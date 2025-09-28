Imports System.Text.RegularExpressions

Public Class FormPropietarios
    Private propietarioRepository As PropietarioRepository

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        propietarioRepository = New PropietarioRepository()
    End Sub

    Private Sub FormPropietarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarPropietarios()
        LimpiarCampos()
    End Sub

    Private Sub CargarPropietarios()
        Dim propietariosOrdenados = propietarioRepository.ObtenerTodos().OrderBy(Function(p) p.Apellido).ToList()
        dgvPropietarios.DataSource = propietariosOrdenados
        ' Configurar DataGridView para selección de fila completa
        dgvPropietarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPropietarios.ReadOnly = True
        dgvPropietarios.AllowUserToAddRows = False
        dgvPropietarios.AllowUserToDeleteRows = False
    End Sub

    Private Sub LimpiarCampos()
        txtIdPropietario.Text = ""
        txtNombre.Text = ""
        txtApellido.Text = ""
        txtDni.Text = ""
        txtTelefono.Text = ""
        txtDireccion.Text = ""
        btnGuardar.Text = "Guardar"
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarCampos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Not ValidarCampos() Then
            Return
        End If

        Dim propietario As New Propietario With {
            .Nombre = txtNombre.Text,
            .Apellido = txtApellido.Text,
            .Dni = txtDni.Text,
            .Telefono = txtTelefono.Text,
            .Direccion = txtDireccion.Text
        }

        If String.IsNullOrEmpty(txtIdPropietario.Text) Then
            ' Alta
            propietarioRepository.Insertar(propietario)
            MessageBox.Show("Propietario guardado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' Modificación
            propietario.IdPropietario = Convert.ToInt32(txtIdPropietario.Text)
            propietarioRepository.Actualizar(propietario)
            MessageBox.Show("Propietario actualizado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        CargarPropietarios()
        LimpiarCampos()
    End Sub

    Private Sub dgvPropietarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPropietarios.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvPropietarios.Rows(e.RowIndex)
            txtIdPropietario.Text = row.Cells("IdPropietario").Value.ToString()
            txtNombre.Text = row.Cells("Nombre").Value.ToString()
            txtApellido.Text = row.Cells("Apellido").Value.ToString()
            txtDni.Text = row.Cells("Dni").Value.ToString()
            txtTelefono.Text = row.Cells("Telefono").Value.ToString()
            txtDireccion.Text = row.Cells("Direccion").Value.ToString()
            btnGuardar.Text = "Modificar"
        End If
    End Sub

    Private Sub btnGestionMascotas_Click(sender As Object, e As EventArgs) Handles btnGestionMascotas.Click
        Dim formMascotas As New FormMascotas()
        formMascotas.ShowDialog()
    End Sub

    Private Sub btnGestionProductos_Click(sender As Object, e As EventArgs) Handles btnGestionProductos.Click
        Dim formProductos As New FormProductos()
        formProductos.ShowDialog()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Not String.IsNullOrEmpty(txtIdPropietario.Text) Then
            If MessageBox.Show("¿Está seguro que desea eliminar este propietario?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ' Implementar método Eliminar en PropietarioRepository
                propietarioRepository.Eliminar(Convert.ToInt32(txtIdPropietario.Text))
                CargarPropietarios()
                LimpiarCampos()
            End If
        Else
            MessageBox.Show("Seleccione un propietario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function ValidarCampos() As Boolean
        If String.IsNullOrWhiteSpace(txtNombre.Text) OrElse
           String.IsNullOrWhiteSpace(txtApellido.Text) OrElse
           String.IsNullOrWhiteSpace(txtDni.Text) Then
            MessageBox.Show("Nombre, Apellido y DNI son campos obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If Not String.IsNullOrWhiteSpace(txtTelefono.Text) AndAlso Not Regex.IsMatch(txtTelefono.Text, "^\d*$") Then
            MessageBox.Show("El teléfono debe contener solo números.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True
    End Function
End Class
