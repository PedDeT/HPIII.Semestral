
Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports System.IO

Public Class FormColab
    Dim contador = 0
    'Public connectionString As String = "Data Source=DESKTOP-910LQQK;Initial Catalog=SEMESTRALPEDRORENEDB1;Integrated Security=True; Encrypt=False"
    Public connectionString As String = "Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB1;Integrated Security=True"
    'Public connectionString2 As String = "Data Source=DESKTOP-910LQQK;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True; Encrypt=False"
    Public connectionString2 As String = "Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True"
    Public Sub FormColab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ColabPanelAgregarClientes.Visible = False
        ColabPanelActualizarClientes.Visible = False
        ColabPanelEliminarCliente.Visible = False
        ColabPanelCerrarServicio.Visible = False
        ColabPanelAgregarProveedor.Visible = False
        ColabPanelEliminarProveedor.Visible = False
        ColabPanelInformes.Visible = False
        ColabPanelAyuda.Visible = False
        ColabPanelVersion.Visible = False
        ColabPanelReclutarEst.Visible = False
    End Sub

    Private Sub ShowPanel(panel As Panel)
        Dim container As Control = panel.Parent
        For Each p As Panel In container.Controls.OfType(Of Panel)()
            p.Visible = False
        Next
        panel.Visible = True
    End Sub
    'Agregar Clientes
    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click
        ShowPanel(ColabPanelAgregarClientes)
    End Sub
    'Actualizar Clientes
    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click
        ShowPanel(ColabPanelActualizarClientes)
        cargarCbCLIENTES()
        cargartablaActualizarCliente()

    End Sub
    'Eliminar Clientes
    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        ShowPanel(ColabPanelEliminarCliente)
        cargartablaEliminarCliente()
        cargarCbEliminarCLIENTES()
    End Sub
    'Reclutar Estudiantes
    Private Sub ReclutarEstudiantesReclutarToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ShowPanel(ColabPanelReclutarEst)
        Panel1.BackColor = Color.FromArgb(100, 140, 140, 140)
    End Sub
    'Cerrar servicio 
    Private Sub ServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiciosToolStripMenuItem.Click
        ShowPanel(ColabPanelCerrarServicio)
    End Sub



    Private Sub EliminarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem1.Click
        ShowPanel(ColabPanelEliminarProveedor)
    End Sub

    Private Sub InformeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformeToolStripMenuItem.Click
        ShowPanel(ColabPanelInformes)
    End Sub

    Private Sub VersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersionToolStripMenuItem.Click
        ShowPanel(ColabPanelVersion)
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem.Click
        ShowPanel(ColabPanelAyuda)
    End Sub
    '------------------------- Agregar Proveedor ----------------------------------------
    Private Sub AgregarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem1.Click
        ShowPanel(ColabPanelAgregarProveedor)
    End Sub

    Private Sub ColabBtnAgregarProveedor_Click(sender As Object, e As EventArgs) Handles ColabBtnAgregarProveedor.Click
        Dim nombreProveedor As String = ColabTBNombreProovedor.Text
        Dim rucProveedor As String = ColabTBRUCProveedor.Text
        Dim tipoProveedor As String = ColabTBTipoProveedor.Text

        ' Check if any of the fields is blank
        If String.IsNullOrEmpty(nombreProveedor) OrElse
           String.IsNullOrEmpty(rucProveedor) OrElse
           String.IsNullOrEmpty(tipoProveedor) Then
            MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT COUNT(*) FROM PROVEEDORES WHERE Nombre = @Nombre AND RUC = @RUC AND Tipo = @Tipo"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Nombre", nombreProveedor)
            command.Parameters.AddWithValue("@RUC", rucProveedor)
            command.Parameters.AddWithValue("@Tipo", tipoProveedor)

            Dim count As Integer = CInt(command.ExecuteScalar())

            If count > 0 Then
                MessageBox.Show("El proveedor con esta información ya existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End Using

        ' Perform database insertion here
        ' Assuming you have a connection string defined as "connectionString"
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "INSERT INTO PROVEEDORES (Nombre, RUC, Tipo) VALUES (@Nombre, @RUC, @Tipo)"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Nombre", nombreProveedor)
            command.Parameters.AddWithValue("@RUC", rucProveedor)
            command.Parameters.AddWithValue("@Tipo", tipoProveedor)

            command.ExecuteNonQuery()

            MessageBox.Show("Proveedor agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Clear the textboxes and combobox for new entries
            ColabTBNombreProovedor.Text = ""
            ColabTBRUCProveedor.Text = ""
            ColabTBTipoProveedor.SelectedIndex = -1 ' Clear the combobox selection
        End Using
    End Sub
    Private Sub FillDataGridView()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT Nombre, RUC, Tipo FROM PROVEEDORES"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ColabDGEliminarProveedor.DataSource = dt
        End Using
    End Sub
    Private Sub FillComboBox()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT Nombre FROM PROVEEDORES"
            Dim command As New SqlCommand(query, connection)

            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    ColabCBEliminarProveedor.Items.Add(reader("Nombre").ToString())
                End While
            End Using
        End Using
    End Sub
    ' ----------------------------------- Eliminar Proveedor --------------------------------------
    Private Sub ColabBtnEliminarProovedor_Click(sender As Object, e As EventArgs) Handles ColabBtnEliminarProovedor.Click
        Dim selectedNombre As String = ColabCBEliminarProveedor.Text

        ' Check if the ComboBox is blank
        If String.IsNullOrEmpty(selectedNombre) Then
            MessageBox.Show("Por favor, seleccione un proveedor de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Perform the database deletion
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim deleteQuery As String = "DELETE FROM PROVEEDORES WHERE Nombre = @Nombre"
            Dim deleteCommand As New SqlCommand(deleteQuery, connection)
            deleteCommand.Parameters.AddWithValue("@Nombre", selectedNombre)

            deleteCommand.ExecuteNonQuery()

            MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh the DataGridView and ComboBox after deletion
            FillDataGridView()
            ColabCBEliminarProveedor.Items.Clear()
            ColabCBEliminarProveedor.SelectedIndex = -1
            FillComboBox()
        End Using
    End Sub
    '---------------------------------------- Cerrar Servicios 
    Private Sub CerrarServicioBtnCerrar_Click(sender As Object, e As EventArgs) Handles CerrarServicioBtnCerrar.Click
        Dim selectedIdServicio As String = CerrarServicioCBServicio.Text

        ' Check if a service is selected in the ComboBox
        If String.IsNullOrEmpty(selectedIdServicio) Then
            MessageBox.Show("Por favor, seleccione un servicio para cerrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Perform database update
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim updateQuery As String = "UPDATE SERVICIOS SET Estado = 'Cerrado' WHERE IdServicios = @IdServicio"
            Dim updateCommand As New SqlCommand(updateQuery, connection)
            updateCommand.Parameters.AddWithValue("@IdServicio", selectedIdServicio)

            updateCommand.ExecuteNonQuery()

            MessageBox.Show("Servicio cerrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh the ComboBox and DataGridView
            CerrarServicioCBServicio.SelectedIndex = -1
            FillComboBoxCerrarServicio()
            FillDataGridViewCerrarServicio()
        End Using
    End Sub

    Private Sub FillComboBoxCerrarServicio()
        ' Load data into CerrarServicioCBServicio from the SERVICIOS table
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT IdServicios FROM SERVICIOS WHERE Estado = 'Abierto'"
            Dim command As New SqlCommand(query, connection)

            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    CerrarServicioCBServicio.Items.Add(reader("IdServicios").ToString())
                End While
            End Using
        End Using
    End Sub

    Private Sub FillDataGridViewCerrarServicio()
        ' Load data into AdminDGCerrarServicio from the SERVICIOS table where Estado is "Abierto"
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT * FROM SERVICIOS WHERE Estado = 'Abierto'"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ColabDGCerrarServicio.DataSource = dt
        End Using
    End Sub
    ' ------------------------------- INFORMES ---------------------------
    Private Function GetLastEntradasUsuario() As String
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT TOP 1 Entrada FROM ENTRADAS ORDER BY Id DESC"
            Dim command As New SqlCommand(query, connection)

            Dim lastEntradasUsuario As String = CStr(command.ExecuteScalar())

            Return lastEntradasUsuario
        End Using
    End Function

    Private Sub LoadEstudiantesData()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT * FROM ESTUDIANTESRECLUTADOS"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ColabDGInforme.DataSource = dt
        End Using
    End Sub

    Private Sub LoadProveedoresData()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT * FROM PROVEEDORES"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ColabDGInforme.DataSource = dt
        End Using
    End Sub

    Private Sub ColabCBInforme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColabCBInforme.SelectedIndexChanged
        Dim selectedOption As String = ColabCBInforme.SelectedItem.ToString()

        Select Case selectedOption
            Case "Estudiantes Reclutados"
                LoadEstudiantesData()
            Case "Proveedores"
                LoadProveedoresData()
            Case "Carreras"
                LoadCarreraData()
            Case "Proveedores"
                LoadProveedoresData()
            Case "Inventario Actual"
                LoadInventarioActualData()
            Case "Inventario Movimientos"
                LoadInventarioMovimientosData()

        End Select
    End Sub
    Private Sub LoadInventarioActualData()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT * FROM INVENTARIOACTUAL"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ColabDGInforme.DataSource = dt
        End Using
    End Sub
    Private Sub LoadInventarioMovimientosData()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT * FROM MOVINVENTARIO"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ColabDGInforme.DataSource = dt
        End Using
    End Sub
    Private Sub ColabBtnExportarInforme_Click(sender As Object, e As EventArgs) Handles ColabBtnExportarInforme.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Excel Files|*.xlsx"
        saveFileDialog.Title = "Exportar Informe a Excel"
        saveFileDialog.FileName = "Informe.xlsx"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = saveFileDialog.FileName
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial
            Using package As New ExcelPackage()
                Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Informe")

                ' Copy the DataGridView data to the Excel worksheet
                For i As Integer = 0 To ColabDGInforme.Rows.Count - 1
                    For j As Integer = 0 To ColabDGInforme.Columns.Count - 1
                        worksheet.Cells(i + 1, j + 1).Value = If(ColabDGInforme.Rows(i).Cells(j).Value Is Nothing, "", ColabDGInforme.Rows(i).Cells(j).Value.ToString())
                    Next
                Next

                ' Save the Excel file
                package.SaveAs(New FileInfo(filePath))
            End Using

            MessageBox.Show("Informe exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    '--------------------------------------- Agregar Clientes ----------------------------------- 


    Private Sub ColabBtnAgregarCliente_Click(sender As Object, e As EventArgs) Handles ColabBtnAgregarCliente.Click
        Using connection As New SqlConnection(connectionString2)
            connection.Open()
            Dim nombre As String = AgregarClientesTBNombre.Text
            Dim apellido As String = AgregarClientesTBApellido.Text
            Dim ced As String = AgregarClienteCedula.Text
            Dim residencia As String = AgregarClientesTBResidencia.Text
            Dim lugar As String = AgregarClientesTBTrabajo.Text
            Dim tel1 As Integer = AgregarClientesTBTel1.Text
            Dim tel2 As Integer = AgregarClientesTBTel2.Text
            Dim email As String = AgregarClientesTBemail.Text

            Dim insertQuery As String = "INSERT INTO CLIENTES (Nombre, Apellido, Cedula, Residencia, LugardeTrabajo, Telefono1, Telefono2, email) VALUES (@Nombre, @Apellido, @Cedula, @Residencia, @LugardeTrabajo, @Telefono1, @Telefono2, @email)"
            Dim insertCommand As New SqlCommand(insertQuery, connection)
            insertCommand.Parameters.AddWithValue("@Nombre", nombre)
            insertCommand.Parameters.AddWithValue("@Apellido", apellido)
            insertCommand.Parameters.AddWithValue("@Cedula", ced)
            insertCommand.Parameters.AddWithValue("@Residencia", residencia)
            insertCommand.Parameters.AddWithValue("@LugardeTrabajo", lugar)
            insertCommand.Parameters.AddWithValue("@Telefono1", tel1)
            insertCommand.Parameters.AddWithValue("@Telefono2", tel2)
            insertCommand.Parameters.AddWithValue("@email", email)

            insertCommand.ExecuteNonQuery()
            MessageBox.Show("INFORMACION DE CLIENTE AÑADIDA")
        End Using
        AgregarClientesTBNombre.Clear()
        AgregarClientesTBApellido.Clear()
        AgregarClienteCedula.Clear()
        AgregarClientesTBResidencia.Clear()
        AgregarClientesTBTrabajo.Clear()
        AgregarClientesTBTel1.Clear()
        AgregarClientesTBTel2.Clear()
        AgregarClientesTBemail.Clear()
    End Sub
    ' Actualizar CLientes 
    Private Sub cargarCbCLIENTES()
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True")
        con.Open()
        ' nombre de la tabla ordenar la columna en orden ascendente
        Dim cmd = New SqlCommand("select * from dbo.CLIENTES order by Nombre desc", con)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        ColabCBActualizarClienteID.DataSource = dt
        'Nombre de la tabla
        ColabCBActualizarClienteID.DisplayMember = "CLIENTES"
        'Nombre de la columna
        ColabCBActualizarClienteID.ValueMember = "Nombre"
    End Sub

    Private Sub cargartablaActualizarCliente()
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True")
        con.Open()
        Dim cmd = New SqlCommand("select * from dbo.CLIENTES", con)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        ColabDGActualizarClientes.DataSource = dt
    End Sub
    Private Sub ColabBtnActualizarCliente_Click(sender As Object, e As EventArgs) Handles ColabBtnActualizarCliente.Click
        Using connection As New SqlConnection(connectionString2)
            connection.Open()
            Dim nuevoValor As String = ColabTBActualizarCampo.Text
            Dim nombre As String = ColabCBActualizarClienteID.Text
            Dim infoCambiar As String = ColabCBActualizarClienteCampo.Text

            Dim updateQuery As String = "UPDATE CLIENTES SET " & infoCambiar & " = @nuevoValor WHERE Nombre = @nombre"

            Dim updateCommand As New SqlCommand(updateQuery, connection)
            updateCommand.Parameters.AddWithValue("@nuevoValor", nuevoValor)
            updateCommand.Parameters.AddWithValue("@nombre", nombre)

            Dim rowsAffected As Integer = updateCommand.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("INFORMACION DE CLIENTE ACTUALIZADA")
                cargartablaActualizarCliente()
                ColabTBActualizarCampo.Clear()
                cargarCbCLIENTES()
            Else
                MessageBox.Show("Error al actualizar la información del cliente.")
            End If

            connection.Close()
        End Using
    End Sub



    ' Eliminar Clientes
    Private Sub cargarCbEliminarCLIENTES()
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True")
        con.Open()
        ' nombre de la tabla ordenar la columna en orden ascendente
        Dim cmd = New SqlCommand("select * from dbo.CLIENTES order by Nombre desc", con)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        ColabCBEliminarCliente.DataSource = dt
        'Nombre de la tabla
        ColabCBEliminarCliente.DisplayMember = "CLIENTES"
        'Nombre de la columna
        ColabCBEliminarCliente.ValueMember = "Nombre"
    End Sub
    Private Sub cargartablaEliminarCliente()
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True")
        con.Open()
        Dim cmd = New SqlCommand("select * from dbo.CLIENTES", con)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        ColabDGEliminarCliente.DataSource = dt
        con.Close()
    End Sub
    Private Sub ColabBtnEliminarCliente_Click(sender As Object, e As EventArgs) Handles ColabBtnEliminarCliente.Click
        Dim nombre As String = ColabCBEliminarCliente.Text
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True")
        con.Open()
        Dim consulta = " delete from Clientes where Nombre= '" & nombre & "'"
        Dim cmd = New SqlCommand(consulta, con)
        Dim cant As Integer
        cant = cmd.ExecuteNonQuery
        If cant = 1 Then
            MessageBox.Show("El registro ha sido eliminado")
            cargartablaEliminarCliente()
        Else
            MessageBox.Show("1. El registro no ha sido encontrado")
        End If
    End Sub

    Private Sub FormColab_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormLogin.Show()
    End Sub
    Private Sub ReclutarBtnReclutarReclutar_Click(sender As Object, e As EventArgs) Handles ReclutarBtnReclutar.Click
        Using connection As New SqlConnection(connectionString2)
            connection.Open()
            ReclutarCBDescuento.Text = 0
            ReclutarCBCostoCarrera.Text = 0
            Dim nombre As String = ReclutarTBNombre.Text
            Dim apellido As String = ReclutarTBApellido.Text
            Dim ced As String = ReclutarTBCedula.Text
            Dim residencia As String = ReclutarTBResidencia.Text
            Dim lugar As String = ReclutarTBTrabajo.Text
            Dim tel1 As Integer = ReclutarTBTel1.Text
            Dim tel2 As Integer = ReclutarTBTel2.Text
            Dim email As String = ReclutarTBemail.Text
            Dim carrera As String = ReclutarCBCarrera.Text
            Dim descuento As Integer = ReclutarCBDescuento.Text

            Dim costoFinal As Decimal = Decimal.Parse(ReclutarTBCostoFinal.Text)

            Dim insertQuery As String = "INSERT INTO ESTUDIANTESRECLUTADOS (Nombre, Apellido, Cedula, Residencia, LugardeTrabajo, Telefono1, Telefono2, email, Carrera, Descuento, CostoCarrera) VALUES (@Nombre, @Apellido, @Cedula, @Residencia, @LugardeTrabajo, @Telefono1, @Telefono2, @email, @Carrera, @Descuento, @CostoCarrera)"
            Dim insertCommand As New SqlCommand(insertQuery, connection)
            insertCommand.Parameters.AddWithValue("@Nombre", nombre)
            insertCommand.Parameters.AddWithValue("@Apellido", apellido)
            insertCommand.Parameters.AddWithValue("@Cedula", ced)
            insertCommand.Parameters.AddWithValue("@Residencia", residencia)
            insertCommand.Parameters.AddWithValue("@LugardeTrabajo", lugar)
            insertCommand.Parameters.AddWithValue("@Telefono1", tel1)
            insertCommand.Parameters.AddWithValue("@Telefono2", tel2)
            insertCommand.Parameters.AddWithValue("@email", email)
            insertCommand.Parameters.AddWithValue("@Carrera", carrera)
            insertCommand.Parameters.AddWithValue("@Descuento", descuento)
            insertCommand.Parameters.AddWithValue("@CostoCarrera", costoFinal)

            insertCommand.ExecuteNonQuery()
            MessageBox.Show("INFORMACION DE ESTUDIANTE RECLUTADO")
        End Using
        ReclutarTBNombre.Clear()
        ReclutarTBApellido.Clear()
        ReclutarTBCedula.Clear()
        ReclutarTBResidencia.Clear()
        ReclutarTBTrabajo.Clear()
        ReclutarTBTel1.Clear()
        ReclutarTBTel2.Clear()
        ReclutarTBemail.Clear()
        ReclutarCBCostoCarrera.Text = " "
        ReclutarCBCarrera.Text = " "
        ReclutarCBDescuento.Text = " "

    End Sub
    Private Sub ReclutarCBCarrera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReclutarCBCarrera.SelectedIndexChanged
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB1;Integrated Security=True")
        con.Open()
        Dim carreras As String = ReclutarCBCarrera.Text
        Dim cmd = New SqlCommand("select CostoCarrera from dbo.CARRERAS Where Carrera = '" & carreras & "'", con)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        ReclutarCBCostoCarrera.DataSource = dt
        'Nombre de la tabla
        ReclutarCBCostoCarrera.DisplayMember = "CARRERAS"
        'Nombre de la columna
        ReclutarCBCostoCarrera.ValueMember = "CostoCarrera"
        If contador = 0 Then
            ReclutarCBDescuento.Text = 0
            ReclutarCBCostoCarrera.Text = 0
        End If
        Dim descuento As Decimal = (ReclutarCBDescuento.Text / 100)
        Dim costoCarrera As Decimal = ReclutarCBCostoCarrera.Text
        costoCarrera = costoCarrera - costoCarrera * descuento
        ReclutarTBCostoFinal.Text = costoCarrera
        contador += 1
    End Sub

    Private Sub cargarCbCarreras()
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB1;Integrated Security=True")
        con.Open()
        ' nombre de la tabla ordenar la columna en orden ascendente
        Dim cmd = New SqlCommand("select Carrera from dbo.CARRERAS order by Carrera desc", con)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        ReclutarCBCarrera.DataSource = dt
        'Nombre de la tabla
        ReclutarCBCarrera.DisplayMember = "CARRERAS"
        'Nombre de la columna
        ReclutarCBCarrera.ValueMember = "Carrera"


    End Sub

    Private Sub ReclutarEstudiantesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReclutarEstudiantesToolStripMenuItem.Click
        ColabPanelReclutarEst.Show()
        cargarCbCarreras()
        ReclutarCBDescuento.Text = 0
        ReclutarCBCostoCarrera.Text = 0
    End Sub

    Private Sub LoadCarreraData()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT * FROM CARRERAS"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ColabDGInforme.DataSource = dt
        End Using
    End Sub
End Class