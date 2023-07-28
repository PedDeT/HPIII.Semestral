Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports OfficeOpenXml
Public Class FormAdmin
    'Public connectionString As String = "Data Source=DESKTOP-910LQQK;Initial Catalog=SEMESTRALPEDRORENEDB1;Integrated Security=True; Encrypt=False"
    Public connectionString As String = "Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB1;Integrated Security=True"
    'Public connectionString2 As String = "Data Source=DESKTOP-910LQQK;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True; Encrypt=False"
    Public connectionString2 As String = "Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True"
    Dim contador = 0
    Public Sub FormAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AdminPanelAyuda.Visible = False
        AdminPanelVersion.Visible = False
        AdminPanelInformes.Visible = False
        AdminPanelDescargarInventario.Visible = False
        AdminPanelInventarioCarga.Visible = False
        AdminPanelAgregarFacultad.Visible = False
        AdminPanelAgregarCarreras.Visible = False
        AdminPanelEliminarProveedor.Visible = False
        AdminPanelAgregarProveedor.Visible = False
        AdminPanelCerrarServicio.Visible = False
        AdminPanelAgregarServicio.Visible = False
        AdminPanelReclutarEst.Visible = False
        AdminPanelEliminarCliente.Visible = False
        AdminPanelAgregarClientes.Visible = False
        AdminPanelActualizarClientes.Visible = False
        AdminPanelAgregarUsuarios.Visible = False
        AdminPanelEnviarCorreo.Visible = False
        AdminPanelCerrarServicio.Visible = False
        AdminPanelCambiarInfoEstudiante.Visible = False


        Dim coordinadores As List(Of String) = GetAvailableCoordinadores()
        AdminFacultadCBCoordinadorFacultad.DataSource = coordinadores

        FillDataGridView()

        ' Load data into the ComboBox
        FillComboBox()

    End Sub

    Private Function GetAvailableCoordinadores() As List(Of String)
        Dim coordinadores As New List(Of String)()

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Query to get "Usuario" values from LOGIN table where Rango is "Coordinador"
            Dim query As String = "SELECT Usuario FROM LOGIN WHERE Rango = 'Coordinador'"

            ' Exclude "Usuario" values that are already in the "Coordinador" column of FACULTADES table
            query += " AND Usuario NOT IN (SELECT Coordinador FROM FACULTADES)"

            Dim command As New SqlCommand(query, connection)
            Dim reader As SqlDataReader = command.ExecuteReader()

            While reader.Read()
                Dim usuario As String = reader("Usuario").ToString()
                coordinadores.Add(usuario)
            End While

            reader.Close()
        End Using

        Return coordinadores
    End Function

    Private Sub Showpanel(panel As Panel)
        Dim container As Control = panel.Parent
        For Each p As Panel In container.Controls.OfType(Of Panel)()
            p.Visible = False
        Next
        panel.Visible = True
    End Sub

    Private Sub CoordinadoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CoordinadoresToolStripMenuItem.Click
        Showpanel(AdminPanelAgregarUsuarios)
    End Sub

    Private Sub AgregarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem.Click
        Showpanel(AdminPanelAgregarClientes)
    End Sub

    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click
        Showpanel(AdminPanelActualizarClientes)
        cargarCbCLIENTES()
        cargartablaActualizarCliente()
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Showpanel(AdminPanelEliminarCliente)
        cargartablaEliminarCliente()
        cargarCbEliminarCLIENTES()
    End Sub

    Private Sub AgregarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem1.Click
        FillComboBoxesAgregarServicio()
        Showpanel(AdminPanelAgregarServicio)
    End Sub

    Private Sub EliminarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem1.Click
        FillComboBoxCerrarServicio()

        ' Load data into the DataGridView
        FillDataGridViewCerrarServicio()
        Showpanel(AdminPanelCerrarServicio)
    End Sub

    Private Sub AgregarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AgregarToolStripMenuItem2.Click
        Showpanel(AdminPanelAgregarProveedor)
    End Sub

    Private Sub EliminarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem2.Click
        Showpanel(AdminPanelEliminarProveedor)
    End Sub


    Private Sub FacultadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacultadesToolStripMenuItem.Click
        Showpanel(AdminPanelAgregarFacultad)
        GetAvailableCoordinadores()
    End Sub

    Private Sub CarrerasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CarrerasToolStripMenuItem1.Click
        Showpanel(AdminPanelAgregarCarreras)

    End Sub


    Private Sub CargarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarToolStripMenuItem.Click
        Showpanel(AdminPanelInventarioCarga)
        FillDataGridViewInventario()

        ' Load data into the ComboBox
        FillComboBoxInventario()

        FillComboBoxActualizarInventario()
    End Sub

    Private Sub DescargarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescargarToolStripMenuItem.Click
        FillComboBoxEliminarInventario()

        ' Load data into the DataGridView
        FillDataGridViewEliminarInventario()

        Showpanel(AdminPanelDescargarInventario)
    End Sub

    Private Sub InformeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformeToolStripMenuItem.Click
        Showpanel(AdminPanelInformes)
    End Sub

    Private Sub VersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersionToolStripMenuItem.Click
        Showpanel(AdminPanelVersion)
    End Sub

    Private Sub ManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualToolStripMenuItem.Click
        Showpanel(AdminPanelAyuda)
    End Sub

    Private Sub AgregarUsuariosBtnAgregar_Click(sender As Object, e As EventArgs) Handles AgregarUsuariosBtnAgregar.Click
        Dim nombre As String = AgregarUsuariosTBNombre.Text
        Dim apellido As String = AgregarUsuariosTBApellido.Text
        Dim residencia As String = AgregarUsuariosTBResidencia.Text
        Dim lugarTrabajo As String = AgregarUsuariosTBTrabajo.Text
        Dim telefono1 As String = AgregarUsuariosTBTel1.Text
        Dim telefono2 As String = AgregarUsuariosTBTel2.Text
        Dim email As String = AgregarUsuariosTBemail.Text
        Dim status As String = AgregarUsuariosTBStatus.Text
        Dim atencion As String = AgregarUsuariosTBAtencion.Text

        If String.IsNullOrEmpty(nombre) OrElse
       String.IsNullOrEmpty(apellido) OrElse
       String.IsNullOrEmpty(residencia) OrElse
       String.IsNullOrEmpty(lugarTrabajo) OrElse
       String.IsNullOrEmpty(telefono1) OrElse
       String.IsNullOrEmpty(email) OrElse
       String.IsNullOrEmpty(status) Then
            MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If


        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Determine the Rango for LOGIN table
            Dim rango As String = If(status = "Coordinador", "Coordinador", "Colaborador")

            ' Get the highest number for the specified Rango in the Usuario column of USUARIOS table
            Dim query As String = "SELECT TOP 1 Usuario FROM USUARIOS WHERE Usuario LIKE @Rango ORDER BY Usuario DESC"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Rango", "%" & rango & "%")

            Dim lastUser As String = CStr(command.ExecuteScalar())

            ' Extract the number from the lastUser
            Dim number As Integer = 1
            If Not String.IsNullOrEmpty(lastUser) AndAlso lastUser.Length > rango.Length Then
                Dim lastNumber As String = lastUser.Substring(rango.Length)
                Integer.TryParse(lastNumber, number)
                number += 1
            End If

            ' Generate the new Usuario value
            Dim newUsuario As String = rango & number.ToString()

            ' Insert into USUARIOS table
            Dim insertQuery As String = "INSERT INTO USUARIOS (Usuario, Nombre, Apellido, Residencia, LugardeTrabajo, Telefono1, Telefono2, email, Horario) VALUES (@Usuario, @Nombre, @Apellido, @Residencia, @LugardeTrabajo, @Telefono1, @Telefono2, @Email, @Horario)"
            Dim insertCommand As New SqlCommand(insertQuery, connection)
            insertCommand.Parameters.AddWithValue("@Usuario", newUsuario)
            insertCommand.Parameters.AddWithValue("@Nombre", nombre)
            insertCommand.Parameters.AddWithValue("@Apellido", apellido)
            insertCommand.Parameters.AddWithValue("@Residencia", residencia)
            insertCommand.Parameters.AddWithValue("@LugardeTrabajo", lugarTrabajo)
            insertCommand.Parameters.AddWithValue("@Telefono1", telefono1)
            insertCommand.Parameters.AddWithValue("@Telefono2", telefono2)
            insertCommand.Parameters.AddWithValue("@Email", email)
            insertCommand.Parameters.AddWithValue("@Horario", If(String.IsNullOrEmpty(atencion) Or Not AgregarUsuariosTBAtencion.Enabled, DBNull.Value, GetHorarioValue(atencion)))

            insertCommand.ExecuteNonQuery()

            ' Insert into LOGIN table
            Dim contrasena As String = newUsuario.ToLower() & "2023"
            Dim loginQuery As String = "INSERT INTO LOGIN (Usuario, Contrasena, Rango) VALUES (@Usuario, @Contrasena, @Rango)"
            Dim loginCommand As New SqlCommand(loginQuery, connection)
            loginCommand.Parameters.AddWithValue("@Usuario", newUsuario)
            loginCommand.Parameters.AddWithValue("@Contrasena", contrasena)
            loginCommand.Parameters.AddWithValue("@Rango", rango)

            loginCommand.ExecuteNonQuery()

            Dim successMessage As String = $"Usuario agregado correctamente.{Environment.NewLine}" &
                              $"Usuario: {newUsuario}{Environment.NewLine}" &
                              $"Contraseña: {contrasena}"

            MessageBox.Show(successMessage, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ResetForm()
        End Using
    End Sub

    Private Sub AgregarUsuariosTBStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AgregarUsuariosTBStatus.SelectedIndexChanged
        Dim selectedStatus As String = AgregarUsuariosTBStatus.Text
        Dim isColaborador As Boolean = (selectedStatus = "Colaborador")
        AgregarUsuariosTBAtencion.Enabled = isColaborador
        If Not isColaborador Then
            AgregarUsuariosTBAtencion.Text = String.Empty
        End If
    End Sub

    Private Function GetHorarioValue(ByVal horario As String) As Integer
        Select Case horario
            Case "Lunes/Martes"
                Return 1
            Case "Miercoles/Jueves"
                Return 2
            Case "Viernes/Sabado"
                Return 3
            Case Else
                Return 0 ' Or any other default value for NULL
        End Select
    End Function

    Private Sub ResetForm()
        AgregarUsuariosTBNombre.Text = ""
        AgregarUsuariosTBApellido.Text = ""
        AgregarUsuariosTBResidencia.Text = ""
        AgregarUsuariosTBTrabajo.Text = ""
        AgregarUsuariosTBTel1.Text = ""
        AgregarUsuariosTBTel2.Text = ""
        AgregarUsuariosTBemail.Text = ""
        AgregarUsuariosTBStatus.SelectedIndex = -1
        AgregarUsuariosTBAtencion.Text = ""
    End Sub

    Private Sub AdminFacultadBtnAgregarFacultad_Click(sender As Object, e As EventArgs) Handles AdminFacultadBtnAgregarFacultad.Click
        Dim facultad As String = AdminFacultadTBNombreFacultad.Text.Trim()
        Dim coordinador As String = AdminFacultadCBCoordinadorFacultad.Text

        If String.IsNullOrEmpty(facultad) OrElse String.IsNullOrEmpty(coordinador) Then
            MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Add a new row to the FACULTADES table with the values from the textbox and combobox
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim insertQuery As String = "INSERT INTO FACULTADES (NombreFacultad, Coordinador) VALUES (@NombreFacultad, @Coordinador)"
            Dim insertCommand As New SqlCommand(insertQuery, connection)
            insertCommand.Parameters.AddWithValue("@NombreFacultad", facultad)
            insertCommand.Parameters.AddWithValue("@Coordinador", coordinador)

            insertCommand.ExecuteNonQuery()
        End Using

        MessageBox.Show("Facultad agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        AdminFacultadTBNombreFacultad.Text = "" ' Clear the textbox after successful insertion
    End Sub

    Private Sub AdminBtnAgregarProveedor_Click(sender As Object, e As EventArgs) Handles AdminBtnAgregarProveedor.Click
        Dim nombreProveedor As String = AdminTBNombreProovedor.Text
        Dim rucProveedor As String = AdminTBRUCProveedor.Text
        Dim tipoProveedor As String = AdminTBTipoProveedor.Text

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
            AdminTBNombreProovedor.Text = ""
            AdminTBRUCProveedor.Text = ""
            AdminTBTipoProveedor.SelectedIndex = -1 ' Clear the combobox selection
        End Using
    End Sub

    Private Sub FillDataGridView()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT Nombre, RUC, Tipo FROM PROVEEDORES"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            AdminDGEliminarProveedor.DataSource = dt
        End Using
    End Sub

    Private Sub FillComboBox()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT Nombre FROM PROVEEDORES"
            Dim command As New SqlCommand(query, connection)

            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    AdminCBEliminarProveedor.Items.Add(reader("Nombre").ToString())
                End While
            End Using
        End Using
    End Sub

    Private Sub AdminBtnEliminarProovedor_Click(sender As Object, e As EventArgs) Handles AdminBtnEliminarProovedor.Click
        Dim selectedNombre As String = AdminCBEliminarProveedor.Text

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
            AdminCBEliminarProveedor.Items.Clear()
            AdminCBEliminarProveedor.SelectedIndex = -1
            FillComboBox()
        End Using
    End Sub

    Private Sub InventarioCargarBtnAgregar_Click(sender As Object, e As EventArgs) Handles InventarioCargarBtnAgregar.Click
        Dim nombreArticulo As String = InventarioCargarTBNombre.Text
        Dim proveedor As String = InventarioCargarCBProveedor.Text
        Dim cantidad As Integer = CInt(InventarioCargarNUDAgregar.Value)

        ' Check if any of the fields is blank or null
        If String.IsNullOrEmpty(nombreArticulo) OrElse
           String.IsNullOrEmpty(proveedor) OrElse
           cantidad <= 0 Then
            MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if the NombreArticulo already exists in the database
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim existsQuery As String = "SELECT COUNT(*) FROM INVENTARIOACTUAL WHERE NombreArticulo = @NombreArticulo"
            Dim existsCommand As New SqlCommand(existsQuery, connection)
            existsCommand.Parameters.AddWithValue("@NombreArticulo", nombreArticulo)

            Dim count As Integer = CInt(existsCommand.ExecuteScalar())

            If count > 0 Then
                MessageBox.Show("El artículo ya existe en el inventario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End Using

        ' Perform database insertion
        Dim currentDate As DateTime = DateTime.Now
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            ' Insert into INVENTARIOACTUAL table
            Dim insertQuery As String = "INSERT INTO INVENTARIOACTUAL (NombreArticulo, Proveedor, Cantidad) VALUES (@NombreArticulo, @Proveedor, @Cantidad)"
            Dim insertCommand As New SqlCommand(insertQuery, connection)
            insertCommand.Parameters.AddWithValue("@NombreArticulo", nombreArticulo)
            insertCommand.Parameters.AddWithValue("@Proveedor", proveedor)
            insertCommand.Parameters.AddWithValue("@Cantidad", cantidad)

            insertCommand.ExecuteNonQuery()

            ' Insert into MOVINVENTARIO table
            Dim movQuery As String = "INSERT INTO MOVINVENTARIO (NombreArticulo, Movimiento, FechaHora) VALUES (@NombreArticulo, @Movimiento, @FechaHora)"
            Dim movCommand As New SqlCommand(movQuery, connection)
            movCommand.Parameters.AddWithValue("@NombreArticulo", nombreArticulo)
            movCommand.Parameters.AddWithValue("@Movimiento", cantidad)
            movCommand.Parameters.AddWithValue("@FechaHora", currentDate)

            movCommand.ExecuteNonQuery()

            MessageBox.Show("Artículo agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear the input fields
            InventarioCargarTBNombre.Text = ""
            InventarioCargarCBProveedor.SelectedIndex = -1
            InventarioCargarNUDAgregar.Value = 0

            ' Refresh the DataGridView
            FillDataGridViewInventario()
        End Using
    End Sub
    Private Sub FillDataGridViewInventario()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT NombreArticulo, Proveedor, Cantidad FROM INVENTARIOACTUAL"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            AdminDGInventario.DataSource = dt
        End Using
    End Sub

    Private Sub FillComboBoxInventario()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT Nombre FROM PROVEEDORES"
            Dim command As New SqlCommand(query, connection)

            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    InventarioCargarCBProveedor.Items.Add(reader("Nombre").ToString())
                End While
            End Using
        End Using
    End Sub

    Private Sub InventarioCargarBtnCargar_Click(sender As Object, e As EventArgs) Handles InventarioCargarBtnCargar.Click
        Dim articuloNombre As String = CargarInventarioCBCargar.Text
        Dim cantidadCargar As Integer = CInt(InventarioCargarNUDCargar.Value)

        ' Check if any of the fields is blank or null
        If String.IsNullOrEmpty(articuloNombre) OrElse cantidadCargar <= 0 Then
            MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Perform database update and insertion
        Dim currentDate As DateTime = DateTime.Now
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            ' Update INVENTARIOACTUAL table
            Dim updateQuery As String = "UPDATE INVENTARIOACTUAL SET Cantidad = Cantidad + @CantidadCargar WHERE NombreArticulo = @ArticuloNombre"
            Dim updateCommand As New SqlCommand(updateQuery, connection)
            updateCommand.Parameters.AddWithValue("@CantidadCargar", cantidadCargar)
            updateCommand.Parameters.AddWithValue("@ArticuloNombre", articuloNombre)

            Dim rowsAffected As Integer = updateCommand.ExecuteNonQuery()

            If rowsAffected = 0 Then
                MessageBox.Show("No se encontró el artículo en el inventario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Insert into MOVINVENTARIO table
            Dim movQuery As String = "INSERT INTO MOVINVENTARIO (NombreArticulo, Movimiento, FechaHora) VALUES (@NombreArticulo, @Movimiento, @FechaHora)"
            Dim movCommand As New SqlCommand(movQuery, connection)
            movCommand.Parameters.AddWithValue("@NombreArticulo", articuloNombre)
            movCommand.Parameters.AddWithValue("@Movimiento", cantidadCargar)
            movCommand.Parameters.AddWithValue("@FechaHora", currentDate)

            movCommand.ExecuteNonQuery()

            MessageBox.Show("Inventario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear the input fields
            CargarInventarioCBCargar.SelectedIndex = -1
            InventarioCargarNUDCargar.Value = 0

            FillDataGridViewInventario()
        End Using
    End Sub

    Private Sub FillComboBoxActualizarInventario()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT NombreArticulo FROM INVENTARIOACTUAL"
            Dim command As New SqlCommand(query, connection)

            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    CargarInventarioCBCargar.Items.Add(reader("NombreArticulo").ToString())
                End While
            End Using
        End Using
    End Sub

    Private Sub InventarioDescargarBtnDescargar_Click(sender As Object, e As EventArgs) Handles InventarioDescargarBtnDescargar.Click
        Dim articuloNombre As String = InventarioDescargarCBArticulo.Text
        Dim cantidadDescargar As Integer = CInt(InventarioDescargarNUDCantidad.Value)

        ' Check if any of the fields is blank or null
        If String.IsNullOrEmpty(articuloNombre) OrElse cantidadDescargar <= 0 Then
            MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Perform database update and insertion
        Dim currentDate As DateTime = DateTime.Now
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            ' Check if there's enough quantity in the inventory
            Dim checkQuery As String = "SELECT Cantidad FROM INVENTARIOACTUAL WHERE NombreArticulo = @ArticuloNombre"
            Dim checkCommand As New SqlCommand(checkQuery, connection)
            checkCommand.Parameters.AddWithValue("@ArticuloNombre", articuloNombre)

            Dim currentQuantity As Integer = CInt(checkCommand.ExecuteScalar())

            If currentQuantity < cantidadDescargar Then
                MessageBox.Show("No hay suficiente cantidad en el inventario para descargar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Update INVENTARIOACTUAL table
            Dim updateQuery As String = "UPDATE INVENTARIOACTUAL SET Cantidad = Cantidad - @CantidadDescargar WHERE NombreArticulo = @ArticuloNombre"
            Dim updateCommand As New SqlCommand(updateQuery, connection)
            updateCommand.Parameters.AddWithValue("@CantidadDescargar", cantidadDescargar)
            updateCommand.Parameters.AddWithValue("@ArticuloNombre", articuloNombre)

            updateCommand.ExecuteNonQuery()

            ' Insert into MOVINVENTARIO table with negative Movimiento value
            Dim movQuery As String = "INSERT INTO MOVINVENTARIO (NombreArticulo, Movimiento, FechaHora) VALUES (@NombreArticulo, @Movimiento, @FechaHora)"
            Dim movCommand As New SqlCommand(movQuery, connection)
            movCommand.Parameters.AddWithValue("@NombreArticulo", articuloNombre)
            movCommand.Parameters.AddWithValue("@Movimiento", -cantidadDescargar) ' Negative value to represent the download
            movCommand.Parameters.AddWithValue("@FechaHora", currentDate)

            movCommand.ExecuteNonQuery()

            MessageBox.Show("Descarga de inventario realizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear the input fields
            InventarioDescargarCBArticulo.SelectedIndex = -1
            InventarioDescargarNUDCantidad.Value = 0

            ' Refresh the DataGridView
            FillDataGridViewEliminarInventario()
        End Using
    End Sub
    Private Sub FillComboBoxEliminarInventario()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT NombreArticulo FROM INVENTARIOACTUAL"
            Dim command As New SqlCommand(query, connection)

            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    InventarioDescargarCBArticulo.Items.Add(reader("NombreArticulo").ToString())
                End While
            End Using
        End Using
    End Sub

    Private Sub FillDataGridViewEliminarInventario()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT NombreArticulo, Cantidad FROM INVENTARIOACTUAL"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            AdminDGDescargarInventario.DataSource = dt
        End Using
    End Sub

    Private Sub AdminBtnAgregarServicio_Click(sender As Object, e As EventArgs)
        Dim cliente As String = AgregarServiciosCBCliente.Text
        Dim tipo As String = AgregarServicioCBTipo.Text
        Dim precio As Decimal = AgregarServiciosNUDPrecio.Value
        Dim fechaInicio As DateTime = AdminMCInicioServicio.SelectionStart.Date
        Dim fechaFin As DateTime = AdminMCFinServicio.SelectionStart.Date
        Dim col1 As String = AgregarServicioCBCol1.Text
        Dim col2 As String = AgregarServicioCBCol2.Text
        Dim col3 As String = AgregarServicioCBCol3.Text

        'Check If any of the fields Is null Or blank
        If String.IsNullOrEmpty(cliente) OrElse
        String.IsNullOrEmpty(tipo) OrElse
                precio <= 0 OrElse
               col1 = "" OrElse col2 = "" OrElse col3 = "" Then
            MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if any of the Col ComboBoxes have the same information
        If col1 = col2 OrElse col1 = col3 OrElse col2 = col3 Then
            MessageBox.Show("Los valores en los campos Col1, Col2 y Col3 no pueden ser iguales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Perform database insertion
        Dim estado As String = "Abierto"
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim insertQuery As String = "INSERT INTO SERVICIOS (IdServicios, Cliente, Tipo, Precio, FechaInicio, FechaFin, Col1, Col2, Col3, Estado) VALUES (@IdServicios, @Cliente, @Tipo, @Precio, @FechaInicio, @FechaFin, @Col1, @Col2, @Col3, @Estado)"
            Dim insertCommand As New SqlCommand(insertQuery, connection)
            insertCommand.Parameters.AddWithValue("@IdServicios", cliente & " " & fechaInicio.ToString("dd/MM"))
            insertCommand.Parameters.AddWithValue("@Cliente", cliente)
            insertCommand.Parameters.AddWithValue("@Tipo", tipo)
            insertCommand.Parameters.AddWithValue("@Precio", precio)
            insertCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio)
            insertCommand.Parameters.AddWithValue("@FechaFin", fechaFin)
            insertCommand.Parameters.AddWithValue("@Col1", col1)
            insertCommand.Parameters.AddWithValue("@Col2", col2)
            insertCommand.Parameters.AddWithValue("@Col3", col3)
            insertCommand.Parameters.AddWithValue("@Estado", estado)

            insertCommand.ExecuteNonQuery()

            MessageBox.Show("Servicio agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear the input fields
            AgregarServiciosCBCliente.SelectedIndex = -1
            AgregarServicioCBTipo.SelectedIndex = -1
            AgregarServiciosNUDPrecio.Value = 0
            AdminMCInicioServicio.SetDate(DateTime.Today)
            AdminMCFinServicio.SetDate(DateTime.Today)
            AgregarServicioCBCol1.SelectedIndex = -1
            AgregarServicioCBCol2.SelectedIndex = -1
            AgregarServicioCBCol3.SelectedIndex = -1
        End Using
    End Sub
    Private Sub FillComboBoxesAgregarServicio()
        ' Load data into AgregarServiciosCBCliente from the CLIENTES table
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT Nombre FROM CLIENTES"
            Dim command As New SqlCommand(query, connection)

            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    AgregarServiciosCBCliente.Items.Add(reader("Nombre").ToString())
                End While
            End Using
        End Using

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT Usuario, Horario FROM USUARIOS WHERE Usuario LIKE 'Colaborador%'"
            Dim command As New SqlCommand(query, connection)

            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim usuario As String = reader("Usuario").ToString()
                    Dim horario As Integer = Convert.ToInt32(reader("Horario"))

                    ' Add users to the ComboBoxes based on their Horario restrictions
                    If horario = 1 Then
                        If Not IsWeekendRestrictedDay() Then
                            AgregarServicioCBCol1.Items.Add(usuario)
                        End If
                    ElseIf horario = 2 Then
                        If Not IsMidweekRestrictedDay() Then
                            AgregarServicioCBCol2.Items.Add(usuario)
                        End If
                    ElseIf horario = 3 Then
                        If Not IsWeekdayRestrictedDay() Then
                            AgregarServicioCBCol3.Items.Add(usuario)
                        End If
                    End If
                End While
            End Using
        End Using
    End Sub

    Private Function IsWeekendRestrictedDay() As Boolean
        ' Check if the current date in the AdminMCInicioServicio calendar falls on a Saturday or Sunday
        Dim startDate As DateTime = AdminMCInicioServicio.SelectionStart.Date
        Return startDate.DayOfWeek = DayOfWeek.Saturday OrElse startDate.DayOfWeek = DayOfWeek.Sunday
    End Function

    Private Function IsMidweekRestrictedDay() As Boolean
        ' Check if the current date in the AdminMCInicioServicio calendar falls on a Wednesday or Thursday
        Dim startDate As DateTime = AdminMCInicioServicio.SelectionStart.Date
        Return startDate.DayOfWeek = DayOfWeek.Wednesday OrElse startDate.DayOfWeek = DayOfWeek.Thursday
    End Function

    Private Function IsWeekdayRestrictedDay() As Boolean
        ' Check if the current date in the AdminMCInicioServicio calendar falls on a Friday or Saturday
        Dim startDate As DateTime = AdminMCInicioServicio.SelectionStart.Date
        Return startDate.DayOfWeek = DayOfWeek.Friday OrElse startDate.DayOfWeek = DayOfWeek.Saturday
    End Function

    Private Sub CerrarServicioBtnCerrar_Click(sender As Object, e As EventArgs) Handles CerrarServicioBtnCerrar.Click
        Dim selectedIdServicio As String = CerrarServicioCBServicio.Text

        ' Check if a service is selected in the ComboBox
        If String.IsNullOrEmpty(selectedIdServicio) Then
            MessageBox.Show("Por favor, seleccione un servicio para cerrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Perform database update
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim updateQuery As String = "UPDATE SERVICIOS Set Estado = 'Cerrado' WHERE IdServicios = @IdServicio"
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
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT IdServicio FROM SERVICIOS WHERE Estado = 'Abierto'"
            Dim command As New SqlCommand(query, connection)

            Using reader As SqlDataReader = command.ExecuteReader()
                While reader.Read()
                    CerrarServicioCBServicio.Items.Add(reader("IdServicio").ToString())
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
            AdminDGCerrarServicio.DataSource = dt
        End Using
    End Sub

    Private Sub AdminCBInforme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AdminCBInforme.SelectedIndexChanged
        Dim selectedOption As String = AdminCBInforme.SelectedItem.ToString()

        Select Case selectedOption
            Case "Usuarios"
                LoadUsuariosData()
            Case "Servicios Realizados"
                LoadServiciosData()
            Case "Estudiantes Reclutados"
                LoadEstudiantesData()
            Case "Proveedores"
                LoadProveedoresData()
            Case "Inventario Actual"
                LoadInventarioActualData()
            Case "Inventario Movimientos"
                LoadInventarioMovimientosData()
            Case "Carreras"
                LoadCarreraData()

        End Select
    End Sub
    Private Sub LoadCarreraData()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT * FROM CARRERAS"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            AdminDGInforme.DataSource = dt
        End Using
    End Sub
    Private Sub LoadUsuariosData()
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT * FROM USUARIOS"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            AdminDGInforme.DataSource = dt
        End Using
    End Sub

    Private Sub LoadServiciosData()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT * FROM SERVICIOS WHERE Estado = 'Cerrado'"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            AdminDGInforme.DataSource = dt
        End Using
    End Sub

    Private Sub LoadEstudiantesData()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT * FROM ESTUDIANTESRECLUTADOS"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            AdminDGInforme.DataSource = dt
        End Using
    End Sub

    Private Sub LoadProveedoresData()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT * FROM PROVEEDORES"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            AdminDGInforme.DataSource = dt
        End Using
    End Sub

    Private Sub LoadInventarioActualData()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT * FROM INVENTARIOACTUAL"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            AdminDGInforme.DataSource = dt
        End Using
    End Sub

    Private Sub LoadInventarioMovimientosData()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT * FROM MOVINVENTARIO"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            AdminDGInforme.DataSource = dt
        End Using
    End Sub

    Private Sub AdminBtnExportarInforme_Click(sender As Object, e As EventArgs) Handles AdminBtnExportarInforme.Click
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
                For i As Integer = 0 To AdminDGInforme.Rows.Count - 1
                    For j As Integer = 0 To AdminDGInforme.Columns.Count - 1
                        worksheet.Cells(i + 1, j + 1).Value = If(AdminDGInforme.Rows(i).Cells(j).Value Is Nothing, "", AdminDGInforme.Rows(i).Cells(j).Value.ToString())
                    Next
                Next

                ' Save the Excel file
                package.SaveAs(New FileInfo(filePath))
            End Using

            MessageBox.Show("Informe exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles AgregarClienteCedula.TextChanged

    End Sub
    '-------------------------- SECCION CLIENTES -----------------------------------------------------
    ' --------------------------------------------------------------------------------Agregar Clientes 
    Private Sub AdminBtnAgregarCliente_Click(sender As Object, e As EventArgs) Handles AdminBtnAgregarCliente.Click
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

    Private Sub cargarCbCLIENTES()
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True")
        con.Open()
        ' nombre de la tabla ordenar la columna en orden ascendente
        Dim cmd = New SqlCommand("select * from dbo.CLIENTES order by Nombre desc", con)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        AdminCBActualizarClienteID.DataSource = dt
        'Nombre de la tabla
        AdminCBActualizarClienteID.DisplayMember = "CLIENTES"
        'Nombre de la columna
        AdminCBActualizarClienteID.ValueMember = "Nombre"
    End Sub

    Private Sub cargartablaActualizarCliente()
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True")
        con.Open()
        Dim cmd = New SqlCommand("select * from dbo.CLIENTES", con)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        AdminDGActualizarClientes.DataSource = dt
    End Sub
    ' ----------------------------------------------------------------------------Actualizar Clientes 
    Private Sub AdminBtnActualizarCliente_Click(sender As Object, e As EventArgs) Handles AdminBtnActualizarCliente.Click
        Using connection As New SqlConnection(connectionString2)
            connection.Open()
            Dim nuevoValor As String = AdminTBActualizarCampo.Text
            Dim nombre As String = AdminCBActualizarClienteID.Text
            Dim infoCambiar As String = AdminCBActualizarClienteCampo.Text

            Dim updateQuery As String = "UPDATE CLIENTES SET " & infoCambiar & " = @nuevoValor WHERE Nombre = @nombre"

            Dim updateCommand As New SqlCommand(updateQuery, connection)
            updateCommand.Parameters.AddWithValue("@nuevoValor", nuevoValor)
            updateCommand.Parameters.AddWithValue("@nombre", nombre)

            Dim rowsAffected As Integer = updateCommand.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("INFORMACION DE CLIENTE ACTUALIZADA")
                cargartablaActualizarCliente()
                AdminTBActualizarCampo.Clear()
                cargarCbCLIENTES()
            Else
                MessageBox.Show("Error al actualizar la información del cliente.")
            End If

            connection.Close()
        End Using
    End Sub
    ' ----------------------------------------------------------------------------Eliminar Clientes 
    Private Sub cargarCbEliminarCLIENTES()
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True")
        con.Open()
        ' nombre de la tabla ordenar la columna en orden ascendente
        Dim cmd = New SqlCommand("select * from dbo.CLIENTES order by Nombre desc", con)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        AdminCBEliminarCliente.DataSource = dt
        'Nombre de la tabla
        AdminCBEliminarCliente.DisplayMember = "CLIENTES"
        'Nombre de la columna
        AdminCBEliminarCliente.ValueMember = "Nombre"
    End Sub
    Private Sub cargartablaEliminarCliente()
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True")
        con.Open()
        Dim cmd = New SqlCommand("select * from dbo.CLIENTES", con)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        AdminDGEliminarCliente.DataSource = dt
        con.Close()
    End Sub
    Private Sub AdminBtnEliminarCliente_Click(sender As Object, e As EventArgs) Handles AdminBtnEliminarCliente.Click
        Dim nombre As String = AdminCBEliminarCliente.Text
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
    ' ---------------------  Modulo Atencio al cliente  ------------------------------------
    Private Sub EnviarCorreoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnviarCorreoToolStripMenuItem.Click
        AdminPanelEnviarCorreo.Show()
        AdminPanelEnviarCorreo.Enabled = True
    End Sub

    Dim correos As New MailMessage
    Dim smtp As New SmtpClient
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTNEnviarCorreo.Click
        Try
            Dim correoEnvio = TextBox4.Text
            Dim contraCorreo = TextBox5.Text
            Dim asunto = TextBox3.Text
            Dim mensaje = TextBox1.Text
            Dim destinatario = TextBox2.Text

            correos.To.Add(destinatario)
            correos.Body = mensaje
            correos.IsBodyHtml = True
            correos.Subject = asunto
            correos.From = New MailAddress(correoEnvio)
            smtp.Credentials = New NetworkCredential(correoEnvio, contraCorreo)

            smtp.Host = "smtp.gmail.com"
            smtp.EnableSsl = True
            smtp.Port = 587

            smtp.Send(correos)
            MessageBox.Show("Correo enviado")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
        Catch ex As Exception
            MessageBox.Show("No se pudo enviar el correo")
        End Try
    End Sub

    ' ----------------------------- Modulo Reclutar estudiante -------------------------------------------
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
        AdminPanelReclutarEst.Show()
        cargarCbCarreras()
        ReclutarCBDescuento.Text = 0
        ReclutarCBCostoCarrera.Text = 0
    End Sub

    Private Sub ReclutarBtnReclutar_Click(sender As Object, e As EventArgs) Handles ReclutarBtnReclutar.Click
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
    Private Sub CambiarInfoEstudianteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CambiarInfoEstudianteToolStripMenuItem1.Click
        AdminPanelCambiarInfoEstudiante.Show()
        cargarCbEstudiantes()
        cargartablaActualizarEstudiante()
    End Sub
    Private Sub FormAdmin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormLogin.Show()
    End Sub

    ' ------------------------ Cambiar InfoEstudiante'''''''''''''''''''''''''
    Private Sub cargarCbEstudiantes()
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True")
        con.Open()
        ' nombre de la tabla ordenar la columna en orden ascendente
        Dim cmd = New SqlCommand("select * from dbo.ESTUDIANTESRECLUTADOS order by Nombre desc", con)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        AdminCBActualizarEstudiante.DataSource = dt
        'Nombre de la tabla
        AdminCBActualizarEstudiante.DisplayMember = "ESTUDIANTESRECLUTADOS"
        'Nombre de la columna
        AdminCBActualizarEstudiante.ValueMember = "Nombre"
    End Sub


    Private Sub cargartablaActualizarEstudiante()
        Dim con = New SqlConnection("Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True")
        con.Open()
        Dim cmd = New SqlCommand("select * from dbo.ESTUDIANTESRECLUTADOS", con)
        Dim adaptador As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        adaptador.Fill(dt)
        AdminDGActualizarEstudiante.DataSource = dt
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Using connection As New SqlConnection(connectionString2)
            connection.Open()
            Dim nuevoValor As String = AdminTBActualizarEstudiante.Text
            Dim nombre As String = AdminCBActualizarEstudiante.Text
            Dim infoCambiar As String = AdminCBActualizarEstudianteCampo.Text

            Dim updateQuery As String = "UPDATE ESTUDIANTESRECLUTADOS SET " & infoCambiar & " = @nuevoValor WHERE Nombre = @nombre"

            Dim updateCommand As New SqlCommand(updateQuery, connection)
            updateCommand.Parameters.AddWithValue("@nuevoValor", nuevoValor)
            updateCommand.Parameters.AddWithValue("@nombre", nombre)

            Dim rowsAffected As Integer = updateCommand.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("INFORMACION DE CLIENTE ACTUALIZADA")
                cargartablaActualizarEstudiante()
                AdminTBActualizarEstudiante.Clear()
                cargarCbCLIENTES()
            Else
                MessageBox.Show("Error al actualizar la información del cliente.")
            End If

            connection.Close()
        End Using
    End Sub

    Private Sub AdminBtnAgregarServicio_Click_1(sender As Object, e As EventArgs) Handles AdminBtnAgregarServicio.Click
        Dim cliente As String = AgregarServiciosCBCliente.Text
        Dim tipo As String = AgregarServicioCBTipo.Text
        Dim precio As Decimal = AgregarServiciosNUDPrecio.Value
        Dim fechaInicio As DateTime = AdminMCInicioServicio.SelectionStart.Date
        Dim fechaFin As DateTime = AdminMCFinServicio.SelectionStart.Date
        Dim col1 As String = AgregarServicioCBCol1.Text
        Dim col2 As String = AgregarServicioCBCol2.Text
        Dim col3 As String = AgregarServicioCBCol3.Text

        'Check If any of the fields Is null Or blank
        If String.IsNullOrEmpty(cliente) OrElse
        String.IsNullOrEmpty(tipo) OrElse
                precio <= 0 OrElse
               col1 = "" OrElse col2 = "" OrElse col3 = "" Then
            MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if any of the Col ComboBoxes have the same information
        If col1 = col2 OrElse col1 = col3 OrElse col2 = col3 Then
            MessageBox.Show("Los valores en los campos Col1, Col2 y Col3 no pueden ser iguales.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Perform database insertion
        Dim estado As String = "Abierto"
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim insertQuery As String = "INSERT INTO SERVICIOS (IdServicio, Cliente, Tipo, Precio, FechaInicio, FechaFin, Col1, Col2, Col3, Estado) VALUES (@IdServicios, @Cliente, @Tipo, @Precio, @FechaInicio, @FechaFin, @Col1, @Col2, @Col3, @Estado)"
            Dim insertCommand As New SqlCommand(insertQuery, connection)
            insertCommand.Parameters.AddWithValue("@IdServicios", cliente & " " & fechaInicio.ToString("dd/MM"))
            insertCommand.Parameters.AddWithValue("@Cliente", cliente)
            insertCommand.Parameters.AddWithValue("@Tipo", tipo)
            insertCommand.Parameters.AddWithValue("@Precio", precio)
            insertCommand.Parameters.AddWithValue("@FechaInicio", fechaInicio)
            insertCommand.Parameters.AddWithValue("@FechaFin", fechaFin)
            insertCommand.Parameters.AddWithValue("@Col1", col1)
            insertCommand.Parameters.AddWithValue("@Col2", col2)
            insertCommand.Parameters.AddWithValue("@Col3", col3)
            insertCommand.Parameters.AddWithValue("@Estado", estado)

            insertCommand.ExecuteNonQuery()

            MessageBox.Show("Servicio agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear the input fields
            AgregarServiciosCBCliente.SelectedIndex = -1
            AgregarServicioCBTipo.SelectedIndex = -1
            AgregarServiciosNUDPrecio.Value = 0
            AdminMCInicioServicio.SetDate(DateTime.Today)
            AdminMCFinServicio.SetDate(DateTime.Today)
            AgregarServicioCBCol1.SelectedIndex = -1
            AgregarServicioCBCol2.SelectedIndex = -1
            AgregarServicioCBCol3.SelectedIndex = -1
        End Using
    End Sub
End Class