Imports System.Windows.Forms

Public Class FormMascotas
    Private propietarioRepository As PropietarioRepository

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        propietarioRepository = New PropietarioRepository()
    End Sub

    Private Sub FormMascotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarMascotas()
        CargarPropietarios()
    End Sub

    Private Sub CargarMascotas()
        Dim mascotas As List(Of Mascota) = MascotaRepository.GetAllMascotas()
        dgvMascotas.DataSource = mascotas
        dgvMascotas.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMascotas.ReadOnly = True
        dgvMascotas.AllowUserToAddRows = False
        dgvMascotas.AllowUserToDeleteRows = False
    End Sub

    Private Sub CargarPropietarios()
        Dim propietarios As List(Of Propietario) = propietarioRepository.ObtenerTodos()
        cmbPropietario.DataSource = propietarios
        cmbPropietario.DisplayMember = "NombreCompleto"
        cmbPropietario.ValueMember = "IdPropietario"
    End Sub

    Private Sub dgvMascotas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMascotas.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvMascotas.Rows(e.RowIndex)
            txtNombre.Text = row.Cells("Nombre").Value.ToString()
            txtEspecie.Text = row.Cells("Especie").Value.ToString()
            txtRaza.Text = row.Cells("Raza").Value.ToString()
            txtEdad.Text = row.Cells("Edad").Value.ToString()
            cmbPropietario.SelectedValue = row.Cells("IdPropietario").Value
        End If
    End Sub

    Private Sub btnModificarMascota_Click(sender As Object, e As EventArgs) Handles btnModificarMascota.Click
        If dgvMascotas.SelectedRows.Count > 0 Then
            Dim idMascota As Integer = Convert.ToInt32(dgvMascotas.SelectedRows(0).Cells("IdMascota").Value)
            Dim mascota As New Mascota With {
                .IdMascota = idMascota,
                .Nombre = txtNombre.Text,
                .Especie = txtEspecie.Text,
                .Raza = txtRaza.Text,
                .Edad = Integer.Parse(txtEdad.Text),
                .IdPropietario = CType(cmbPropietario.SelectedValue, Integer)
            }
            MascotaRepository.UpdateMascota(mascota)
            CargarMascotas()
            MessageBox.Show("Mascota actualizada correctamente.")
        Else
            MessageBox.Show("Seleccione una mascota para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnEliminarMascota_Click(sender As Object, e As EventArgs) Handles btnEliminarMascota.Click
        If dgvMascotas.SelectedRows.Count > 0 Then
            If MessageBox.Show("¿Está seguro que desea eliminar esta mascota?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim idMascota As Integer = Convert.ToInt32(dgvMascotas.SelectedRows(0).Cells("IdMascota").Value)
                MascotaRepository.DeleteMascota(idMascota)
                CargarMascotas()
            End If
        Else
            MessageBox.Show("Seleccione una mascota para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnAgregarMascota_Click(sender As Object, e As EventArgs) Handles btnAgregarMascota.Click
        If cmbPropietario.SelectedItem Is Nothing Then
            MessageBox.Show("Debe seleccionar un propietario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim nuevaMascota As New Mascota With {
            .Nombre = txtNombre.Text,
            .Especie = txtEspecie.Text,
            .Raza = txtRaza.Text,
            .Edad = Integer.Parse(txtEdad.Text),
            .IdPropietario = CType(cmbPropietario.SelectedValue, Integer)
        }
        MascotaRepository.AddMascota(nuevaMascota)
        CargarMascotas()
        MessageBox.Show("Mascota agregada correctamente.")
    End Sub
End Class