<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMascotas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgvMascotas = New System.Windows.Forms.DataGridView()
        Me.btnAgregarMascota = New System.Windows.Forms.Button()
        Me.btnModificarMascota = New System.Windows.Forms.Button()
        Me.btnEliminarMascota = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtEspecie = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRaza = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEdad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPropietario = New System.Windows.Forms.ComboBox()
        CType(Me.dgvMascotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMascotas
        '
        Me.dgvMascotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMascotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMascotas.Location = New System.Drawing.Point(281, 12)
        Me.dgvMascotas.Name = "dgvMascotas"
        Me.dgvMascotas.Size = New System.Drawing.Size(507, 426)
        Me.dgvMascotas.TabIndex = 0
        '
        'btnAgregarMascota
        '
        Me.btnAgregarMascota.Location = New System.Drawing.Point(12, 230)
        Me.btnAgregarMascota.Name = "btnAgregarMascota"
        Me.btnAgregarMascota.Size = New System.Drawing.Size(245, 23)
        Me.btnAgregarMascota.TabIndex = 1
        Me.btnAgregarMascota.Text = "Agregar Mascota"
        Me.btnAgregarMascota.UseVisualStyleBackColor = True
        '
        'btnModificarMascota
        '
        Me.btnModificarMascota.Location = New System.Drawing.Point(12, 259)
        Me.btnModificarMascota.Name = "btnModificarMascota"
        Me.btnModificarMascota.Size = New System.Drawing.Size(245, 23)
        Me.btnModificarMascota.TabIndex = 12
        Me.btnModificarMascota.Text = "Modificar Mascota"
        Me.btnModificarMascota.UseVisualStyleBackColor = True
        '
        'btnEliminarMascota
        '
        Me.btnEliminarMascota.Location = New System.Drawing.Point(12, 288)
        Me.btnEliminarMascota.Name = "btnEliminarMascota"
        Me.btnEliminarMascota.Size = New System.Drawing.Size(245, 23)
        Me.btnEliminarMascota.TabIndex = 13
        Me.btnEliminarMascota.Text = "Eliminar Mascota"
        Me.btnEliminarMascota.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(87, 12)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(170, 20)
        Me.txtNombre.TabIndex = 3
        '
        'txtEspecie
        '
        Me.txtEspecie.Location = New System.Drawing.Point(87, 38)
        Me.txtEspecie.Name = "txtEspecie"
        Me.txtEspecie.Size = New System.Drawing.Size(170, 20)
        Me.txtEspecie.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Especie:"
        '
        'txtRaza
        '
        Me.txtRaza.Location = New System.Drawing.Point(87, 64)
        Me.txtRaza.Name = "txtRaza"
        Me.txtRaza.Size = New System.Drawing.Size(170, 20)
        Me.txtRaza.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Raza:"
        '
        'txtEdad
        '
        Me.txtEdad.Location = New System.Drawing.Point(87, 90)
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.Size = New System.Drawing.Size(170, 20)
        Me.txtEdad.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Edad:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Propietario:"
        '
        'cmbPropietario
        '
        Me.cmbPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPropietario.FormattingEnabled = True
        Me.cmbPropietario.Location = New System.Drawing.Point(87, 116)
        Me.cmbPropietario.Name = "cmbPropietario"
        Me.cmbPropietario.Size = New System.Drawing.Size(170, 21)
        Me.cmbPropietario.TabIndex = 11
        '
        'FormMascotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnEliminarMascota)
        Me.Controls.Add(Me.btnModificarMascota)
        Me.Controls.Add(Me.cmbPropietario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtEdad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRaza)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtEspecie)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAgregarMascota)
        Me.Controls.Add(Me.dgvMascotas)
        Me.Name = "FormMascotas"
        Me.Text = "Gestión de Mascotas"
        CType(Me.dgvMascotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvMascotas As DataGridView
    Friend WithEvents btnAgregarMascota As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtEspecie As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRaza As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEdad As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbPropietario As ComboBox
    Friend WithEvents btnModificarMascota As Button
    Friend WithEvents btnEliminarMascota As Button
End Class