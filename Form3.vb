Imports System.Data.SqlClient
Imports OfficeOpenXml
Imports System.IO

Public Class FormCoordi
    Public connectionString As String = "Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB1;Integrated Security=True"
    Public connectionString2 As String = "Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB2;Integrated Security=True"
    'Public connectionString As String = "Data Source=DESKTOP-910LQQK;Initial Catalog=SEMESTRALPEDRORENEDB1;Integrated Security=True; Encrypt=False"
    Public Sub FormCoordi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CoordiPanelAgregarCarreras.Visible = False
        CoordiPanelInventarioCarga.Visible = False
        CoordiPanelInformes.Visible = False
        CoordiPanelDescargarInventario.Visible = False
        CoordiPanelVersion.Visible = False
        CoordiPanelAyuda.Visible = False
    End Sub

    Private Sub ShowPanel(panel As Panel)
        Dim container As Control = panel.Parent
        For Each p As Panel In container.Controls.OfType(Of Panel)()
            p.Visible = False
        Next
        panel.Visible = True
    End Sub

    Private Sub CarrerasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CarrerasToolStripMenuItem.Click
        ShowPanel(CoordiPanelAgregarCarreras)
    End Sub
    ' ----------------- Inventario Carga 
    Private Sub CargarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarToolStripMenuItem.Click
        ShowPanel(CoordiPanelInventarioCarga)
        ' Load data into the ComboBox
        FillComboBoxInventario()
        FillDataGridViewInventario()
        FillComboBoxActualizarInventario()
    End Sub

    Private Sub DescargarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DescargarToolStripMenuItem.Click
        ShowPanel(CoordiPanelDescargarInventario)
    End Sub

    Private Sub InformeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformeToolStripMenuItem.Click
        ShowPanel(CoordiPanelInformes)
    End Sub

    Private Sub VersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VersionToolStripMenuItem.Click
        ShowPanel(CoordiPanelVersion)
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem.Click
        ShowPanel(CoordiPanelAyuda)
    End Sub

    Private Sub CoordiBtnAgregarCarrera_Click(sender As Object, e As EventArgs) Handles CoordiBtnAgregarCarrera.Click
        Dim facultad As String = GetLastCoordinadorFacultad()

        If String.IsNullOrEmpty(facultad) Then
            MessageBox.Show("No se encontró un Coordinador en la tabla FACULTADES.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim carrera As String = AgregarCarrerasCBCarrera.Text.Trim()
        Dim costoCarrera As String = AgregarCarrerasCBCostoCarrera.Text.Trim()
        If String.IsNullOrEmpty(carrera) Then
            MessageBox.Show("Por favor, ingrese el nombre de la carrera.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Add a new row to the CARRERAS table with the Facultad and Carrera values
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim insertQuery As String = "INSERT INTO CARRERAS (Facultad, Carrera, CostoCarrera) VALUES (@Facultad, @Carrera, @CostoCarrera)"
            Dim insertCommand As New SqlCommand(insertQuery, connection)
            insertCommand.Parameters.AddWithValue("@Facultad", facultad)
            insertCommand.Parameters.AddWithValue("@Carrera", carrera)
            insertCommand.Parameters.AddWithValue("@CostoCarrera", costoCarrera)
            insertCommand.ExecuteNonQuery()
        End Using

        MessageBox.Show("Carrera agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        AgregarCarrerasCBCarrera.Text = "" ' Clear the textbox after successful insertion
        AgregarCarrerasCBCostoCarrera.Clear()
    End Sub

    Private Function GetLastCoordinadorFacultad() As String
        Dim lastCoordinador As String = ""

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Fetch the last entry from the ENTRADAS table
            Dim query As String = "SELECT TOP 1 Entrada FROM ENTRADAS ORDER BY Id DESC"
            Dim command As New SqlCommand(query, connection)

            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.Read() Then
                Dim coordinador As String = reader("Entrada").ToString()
                ' Fetch the Facultad of the Coordinador from the FACULTADES table
                lastCoordinador = GetCoordinadorFacultadFromFACULTADES(coordinador)
            End If

            reader.Close()
        End Using

        Return lastCoordinador
    End Function

    Private Function GetCoordinadorFacultadFromFACULTADES(coordinador As String) As String
        Dim facultad As String = ""

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Fetch the Facultad of the Coordinador from the FACULTADES table
            Dim query As String = "SELECT NombreFacultad FROM FACULTADES WHERE Coordinador = @Coordinador"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Coordinador", coordinador)

            Dim reader As SqlDataReader = command.ExecuteReader()

            If reader.Read() Then
                facultad = reader("NombreFacultad").ToString()
            End If

            reader.Close()
        End Using

        Return facultad
    End Function
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

            CoordiDGInventario.DataSource = dt
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

            CoordiDGDescargarInventario.DataSource = dt
        End Using
    End Sub

    Private Sub CoordiCBInforme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CoordiCBInforme.SelectedIndexChanged
        Dim selectedOption As String = CoordiCBInforme.SelectedItem.ToString()

        Select Case selectedOption
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

            CoordiDGInforme.DataSource = dt
        End Using
    End Sub

    Private Sub LoadInventarioMovimientosData()
        Using connection As New SqlConnection(connectionString2)
            connection.Open()

            Dim query As String = "SELECT * FROM MOVINVENTARIO"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            CoordiDGInforme.DataSource = dt
        End Using
    End Sub
    Private Sub CoordiBtnExportarInforme_Click(sender As Object, e As EventArgs) Handles CoordiBtnExportarInforme.Click
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
                For i As Integer = 0 To CoordiDGInforme.Rows.Count - 1
                    For j As Integer = 0 To CoordiDGInforme.Columns.Count - 1
                        worksheet.Cells(i + 1, j + 1).Value = If(CoordiDGInforme.Rows(i).Cells(j).Value Is Nothing, "", CoordiDGInforme.Rows(i).Cells(j).Value.ToString())
                    Next
                Next

                ' Save the Excel file
                package.SaveAs(New FileInfo(filePath))
            End Using

            MessageBox.Show("Informe exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub FormCoordi_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        FormLogin.Show()
    End Sub


End Class