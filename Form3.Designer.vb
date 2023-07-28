<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCoordi
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(FormCoordi))
        MenuStrip1 = New MenuStrip()
        CarrerasToolStripMenuItem = New ToolStripMenuItem()
        InventarioToolStripMenuItem = New ToolStripMenuItem()
        CargarToolStripMenuItem = New ToolStripMenuItem()
        DescargarToolStripMenuItem = New ToolStripMenuItem()
        InformeToolStripMenuItem = New ToolStripMenuItem()
        AcercaDeToolStripMenuItem = New ToolStripMenuItem()
        VersionToolStripMenuItem = New ToolStripMenuItem()
        AyudaToolStripMenuItem = New ToolStripMenuItem()
        CoordiPanelAyuda = New Panel()
        Panel32 = New Panel()
        Label67 = New Label()
        Panel31 = New Panel()
        Label98 = New Label()
        Label97 = New Label()
        Label1 = New Label()
        CoordiPanelVersion = New Panel()
        PictureBox1 = New PictureBox()
        Label106 = New Label()
        Label105 = New Label()
        Label104 = New Label()
        Label103 = New Label()
        Label3 = New Label()
        CoordiPanelAgregarCarreras = New Panel()
        Panel2 = New Panel()
        Label52 = New Label()
        Panel1 = New Panel()
        Label5 = New Label()
        AgregarCarrerasCBCostoCarrera = New TextBox()
        Label4 = New Label()
        AgregarCarrerasCBCarrera = New TextBox()
        Label51 = New Label()
        CoordiBtnAgregarCarrera = New Button()
        CoordiPanelInformes = New Panel()
        CoordiBtnExportarInforme = New Button()
        CoordiCBInforme = New ComboBox()
        Label65 = New Label()
        CoordiDGInforme = New DataGridView()
        CoordiPanelInventarioCarga = New Panel()
        Panel6 = New Panel()
        Label63 = New Label()
        Panel5 = New Panel()
        InventarioCargarBtnAgregar = New Button()
        InventarioCargarCBProveedor = New ComboBox()
        Label62 = New Label()
        InventarioCargarTBNombre = New TextBox()
        InventarioCargarNUDAgregar = New NumericUpDown()
        Label61 = New Label()
        Label60 = New Label()
        InventarioCargarBtnCargar = New Button()
        InventarioCargarNUDCargar = New NumericUpDown()
        Label59 = New Label()
        CargarInventarioCBCargar = New ComboBox()
        Label58 = New Label()
        Label57 = New Label()
        Label56 = New Label()
        CoordiDGInventario = New DataGridView()
        CoordiPanelDescargarInventario = New Panel()
        Panel4 = New Panel()
        Label64 = New Label()
        Panel3 = New Panel()
        InventarioDescargarBtnDescargar = New Button()
        InventarioDescargarNUDCantidad = New NumericUpDown()
        Label68 = New Label()
        InventarioDescargarCBArticulo = New ComboBox()
        Label69 = New Label()
        Label70 = New Label()
        CoordiDGDescargarInventario = New DataGridView()
        MenuStrip1.SuspendLayout()
        CoordiPanelAyuda.SuspendLayout()
        Panel32.SuspendLayout()
        Panel31.SuspendLayout()
        CoordiPanelVersion.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CoordiPanelAgregarCarreras.SuspendLayout()
        Panel2.SuspendLayout()
        Panel1.SuspendLayout()
        CoordiPanelInformes.SuspendLayout()
        CType(CoordiDGInforme, ComponentModel.ISupportInitialize).BeginInit()
        CoordiPanelInventarioCarga.SuspendLayout()
        Panel6.SuspendLayout()
        Panel5.SuspendLayout()
        CType(InventarioCargarNUDAgregar, ComponentModel.ISupportInitialize).BeginInit()
        CType(InventarioCargarNUDCargar, ComponentModel.ISupportInitialize).BeginInit()
        CType(CoordiDGInventario, ComponentModel.ISupportInitialize).BeginInit()
        CoordiPanelDescargarInventario.SuspendLayout()
        Panel4.SuspendLayout()
        Panel3.SuspendLayout()
        CType(InventarioDescargarNUDCantidad, ComponentModel.ISupportInitialize).BeginInit()
        CType(CoordiDGDescargarInventario, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.FromArgb(CByte(0), CByte(64), CByte(44))
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {CarrerasToolStripMenuItem, InventarioToolStripMenuItem, InformeToolStripMenuItem, AcercaDeToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Padding = New Padding(8, 3, 0, 3)
        MenuStrip1.Size = New Size(1100, 34)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' CarrerasToolStripMenuItem
        ' 
        CarrerasToolStripMenuItem.Font = New Font("Segoe UI Variable Small", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        CarrerasToolStripMenuItem.ForeColor = Color.White
        CarrerasToolStripMenuItem.Name = "CarrerasToolStripMenuItem"
        CarrerasToolStripMenuItem.Size = New Size(94, 28)
        CarrerasToolStripMenuItem.Text = "Carreras"
        ' 
        ' InventarioToolStripMenuItem
        ' 
        InventarioToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {CargarToolStripMenuItem, DescargarToolStripMenuItem})
        InventarioToolStripMenuItem.Font = New Font("Segoe UI Variable Small", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        InventarioToolStripMenuItem.ForeColor = Color.White
        InventarioToolStripMenuItem.Name = "InventarioToolStripMenuItem"
        InventarioToolStripMenuItem.Size = New Size(109, 28)
        InventarioToolStripMenuItem.Text = "Inventario"
        ' 
        ' CargarToolStripMenuItem
        ' 
        CargarToolStripMenuItem.Name = "CargarToolStripMenuItem"
        CargarToolStripMenuItem.Size = New Size(179, 28)
        CargarToolStripMenuItem.Text = "Cargar"
        ' 
        ' DescargarToolStripMenuItem
        ' 
        DescargarToolStripMenuItem.Name = "DescargarToolStripMenuItem"
        DescargarToolStripMenuItem.Size = New Size(179, 28)
        DescargarToolStripMenuItem.Text = "Descargar"
        ' 
        ' InformeToolStripMenuItem
        ' 
        InformeToolStripMenuItem.Font = New Font("Segoe UI Variable Small", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        InformeToolStripMenuItem.ForeColor = Color.White
        InformeToolStripMenuItem.Name = "InformeToolStripMenuItem"
        InformeToolStripMenuItem.Size = New Size(90, 28)
        InformeToolStripMenuItem.Text = "Informe"
        ' 
        ' AcercaDeToolStripMenuItem
        ' 
        AcercaDeToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {VersionToolStripMenuItem, AyudaToolStripMenuItem})
        AcercaDeToolStripMenuItem.Font = New Font("Segoe UI Variable Small", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        AcercaDeToolStripMenuItem.ForeColor = Color.White
        AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        AcercaDeToolStripMenuItem.Size = New Size(107, 28)
        AcercaDeToolStripMenuItem.Text = "Acerca de"
        ' 
        ' VersionToolStripMenuItem
        ' 
        VersionToolStripMenuItem.Name = "VersionToolStripMenuItem"
        VersionToolStripMenuItem.Size = New Size(156, 28)
        VersionToolStripMenuItem.Text = "Version"
        ' 
        ' AyudaToolStripMenuItem
        ' 
        AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        AyudaToolStripMenuItem.Size = New Size(156, 28)
        AyudaToolStripMenuItem.Text = "Ayuda"
        ' 
        ' CoordiPanelAyuda
        ' 
        CoordiPanelAyuda.Controls.Add(Panel32)
        CoordiPanelAyuda.Controls.Add(Panel31)
        CoordiPanelAyuda.Dock = DockStyle.Fill
        CoordiPanelAyuda.Location = New Point(0, 34)
        CoordiPanelAyuda.Margin = New Padding(4)
        CoordiPanelAyuda.Name = "CoordiPanelAyuda"
        CoordiPanelAyuda.Size = New Size(1100, 574)
        CoordiPanelAyuda.TabIndex = 2
        ' 
        ' Panel32
        ' 
        Panel32.BackColor = Color.FromArgb(CByte(41), CByte(125), CByte(60))
        Panel32.Controls.Add(Label67)
        Panel32.Location = New Point(35, 34)
        Panel32.Name = "Panel32"
        Panel32.Size = New Size(1041, 78)
        Panel32.TabIndex = 5
        ' 
        ' Label67
        ' 
        Label67.AutoSize = True
        Label67.Font = New Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Label67.ForeColor = Color.White
        Label67.Location = New Point(23, 17)
        Label67.Margin = New Padding(4, 0, 4, 0)
        Label67.Name = "Label67"
        Label67.Size = New Size(329, 40)
        Label67.TabIndex = 0
        Label67.Text = "MANUAL DE USUARIO"
        ' 
        ' Panel31
        ' 
        Panel31.BackColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        Panel31.Controls.Add(Label98)
        Panel31.Controls.Add(Label97)
        Panel31.Location = New Point(33, 148)
        Panel31.Name = "Panel31"
        Panel31.Size = New Size(1043, 375)
        Panel31.TabIndex = 4
        ' 
        ' Label98
        ' 
        Label98.AutoSize = True
        Label98.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label98.Location = New Point(24, 207)
        Label98.Name = "Label98"
        Label98.Size = New Size(881, 135)
        Label98.TabIndex = 2
        Label98.Text = resources.GetString("Label98.Text")
        ' 
        ' Label97
        ' 
        Label97.AutoSize = True
        Label97.Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label97.Location = New Point(21, 28)
        Label97.Name = "Label97"
        Label97.Size = New Size(881, 135)
        Label97.TabIndex = 1
        Label97.Text = resources.GetString("Label97.Text")
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(32, 62)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(239, 27)
        Label1.TabIndex = 3
        Label1.Text = "Bienvenido, Coordinador"
        ' 
        ' CoordiPanelVersion
        ' 
        CoordiPanelVersion.Controls.Add(Label106)
        CoordiPanelVersion.Controls.Add(Label105)
        CoordiPanelVersion.Controls.Add(Label104)
        CoordiPanelVersion.Controls.Add(Label103)
        CoordiPanelVersion.Controls.Add(Label3)
        CoordiPanelVersion.Controls.Add(PictureBox1)
        CoordiPanelVersion.Dock = DockStyle.Fill
        CoordiPanelVersion.Location = New Point(0, 34)
        CoordiPanelVersion.Margin = New Padding(4)
        CoordiPanelVersion.Name = "CoordiPanelVersion"
        CoordiPanelVersion.Size = New Size(1100, 574)
        CoordiPanelVersion.TabIndex = 4
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.None
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.BackgroundImage = My.Resources.Resources.LOGO_removebg
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(275, 66)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(529, 350)
        PictureBox1.TabIndex = 8
        PictureBox1.TabStop = False
        ' 
        ' Label106
        ' 
        Label106.Anchor = AnchorStyles.None
        Label106.AutoSize = True
        Label106.Font = New Font("Segoe UI Variable Small Semibol", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label106.Location = New Point(490, 104)
        Label106.Name = "Label106"
        Label106.Size = New Size(92, 37)
        Label106.TabIndex = 7
        Label106.Text = "LOGO"
        ' 
        ' Label105
        ' 
        Label105.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label105.AutoSize = True
        Label105.Font = New Font("Segoe UI Variable Small", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label105.Location = New Point(32, 510)
        Label105.Name = "Label105"
        Label105.Size = New Size(118, 31)
        Label105.TabIndex = 6
        Label105.Text = "René Ruíz"
        ' 
        ' Label104
        ' 
        Label104.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label104.AutoSize = True
        Label104.Font = New Font("Segoe UI Variable Small", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label104.Location = New Point(32, 468)
        Label104.Name = "Label104"
        Label104.Size = New Size(198, 31)
        Label104.TabIndex = 5
        Label104.Text = "Pedro De La Torre"
        ' 
        ' Label103
        ' 
        Label103.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Label103.AutoSize = True
        Label103.Font = New Font("Segoe UI Variable Small Semibol", 16.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label103.Location = New Point(23, 412)
        Label103.Name = "Label103"
        Label103.Size = New Size(283, 37)
        Label103.TabIndex = 4
        Label103.Text = "DESARROLLADORES"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Variable Small", 16.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(905, 503)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(154, 37)
        Label3.TabIndex = 0
        Label3.Text = "Version 4.5"
        ' 
        ' CoordiPanelAgregarCarreras
        ' 
        CoordiPanelAgregarCarreras.Controls.Add(Panel2)
        CoordiPanelAgregarCarreras.Controls.Add(Panel1)
        CoordiPanelAgregarCarreras.Dock = DockStyle.Fill
        CoordiPanelAgregarCarreras.Location = New Point(0, 34)
        CoordiPanelAgregarCarreras.Margin = New Padding(4)
        CoordiPanelAgregarCarreras.Name = "CoordiPanelAgregarCarreras"
        CoordiPanelAgregarCarreras.Size = New Size(1100, 574)
        CoordiPanelAgregarCarreras.TabIndex = 6
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(41), CByte(125), CByte(60))
        Panel2.Controls.Add(Label52)
        Panel2.Location = New Point(23, 15)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1046, 71)
        Panel2.TabIndex = 9
        ' 
        ' Label52
        ' 
        Label52.AutoSize = True
        Label52.BackColor = Color.Transparent
        Label52.Font = New Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Label52.ForeColor = Color.White
        Label52.Location = New Point(28, 15)
        Label52.Margin = New Padding(4, 0, 4, 0)
        Label52.Name = "Label52"
        Label52.Size = New Size(321, 40)
        Label52.TabIndex = 4
        Label52.Text = "AGREGAR CARRERAS"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(AgregarCarrerasCBCostoCarrera)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(AgregarCarrerasCBCarrera)
        Panel1.Controls.Add(Label51)
        Panel1.Controls.Add(CoordiBtnAgregarCarrera)
        Panel1.Location = New Point(23, 107)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1046, 411)
        Panel1.TabIndex = 8
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(399, 46)
        Label5.Name = "Label5"
        Label5.Size = New Size(242, 27)
        Label5.TabIndex = 8
        Label5.Text = "Información de la carrera"
        ' 
        ' AgregarCarrerasCBCostoCarrera
        ' 
        AgregarCarrerasCBCostoCarrera.Location = New Point(525, 174)
        AgregarCarrerasCBCostoCarrera.Margin = New Padding(4)
        AgregarCarrerasCBCostoCarrera.Name = "AgregarCarrerasCBCostoCarrera"
        AgregarCarrerasCBCostoCarrera.Size = New Size(243, 34)
        AgregarCarrerasCBCostoCarrera.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(261, 177)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(165, 27)
        Label4.TabIndex = 6
        Label4.Text = "Costo de Carrera"
        ' 
        ' AgregarCarrerasCBCarrera
        ' 
        AgregarCarrerasCBCarrera.Location = New Point(525, 109)
        AgregarCarrerasCBCarrera.Margin = New Padding(4)
        AgregarCarrerasCBCarrera.Name = "AgregarCarrerasCBCarrera"
        AgregarCarrerasCBCarrera.Size = New Size(243, 34)
        AgregarCarrerasCBCarrera.TabIndex = 5
        ' 
        ' Label51
        ' 
        Label51.AutoSize = True
        Label51.Location = New Point(261, 109)
        Label51.Margin = New Padding(4, 0, 4, 0)
        Label51.Name = "Label51"
        Label51.Size = New Size(187, 27)
        Label51.TabIndex = 2
        Label51.Text = "Nombre de Carrera"
        ' 
        ' CoordiBtnAgregarCarrera
        ' 
        CoordiBtnAgregarCarrera.BackColor = Color.FromArgb(CByte(0), CByte(64), CByte(44))
        CoordiBtnAgregarCarrera.FlatStyle = FlatStyle.Flat
        CoordiBtnAgregarCarrera.ForeColor = Color.White
        CoordiBtnAgregarCarrera.Location = New Point(437, 265)
        CoordiBtnAgregarCarrera.Margin = New Padding(4)
        CoordiBtnAgregarCarrera.Name = "CoordiBtnAgregarCarrera"
        CoordiBtnAgregarCarrera.Size = New Size(255, 66)
        CoordiBtnAgregarCarrera.TabIndex = 0
        CoordiBtnAgregarCarrera.Text = "Agregar"
        CoordiBtnAgregarCarrera.UseVisualStyleBackColor = False
        ' 
        ' CoordiPanelInformes
        ' 
        CoordiPanelInformes.Controls.Add(CoordiBtnExportarInforme)
        CoordiPanelInformes.Controls.Add(CoordiCBInforme)
        CoordiPanelInformes.Controls.Add(Label65)
        CoordiPanelInformes.Controls.Add(CoordiDGInforme)
        CoordiPanelInformes.Location = New Point(0, 42)
        CoordiPanelInformes.Margin = New Padding(4)
        CoordiPanelInformes.Name = "CoordiPanelInformes"
        CoordiPanelInformes.Size = New Size(1100, 567)
        CoordiPanelInformes.TabIndex = 33
        ' 
        ' CoordiBtnExportarInforme
        ' 
        CoordiBtnExportarInforme.Location = New Point(18, 420)
        CoordiBtnExportarInforme.Margin = New Padding(4)
        CoordiBtnExportarInforme.Name = "CoordiBtnExportarInforme"
        CoordiBtnExportarInforme.Size = New Size(129, 39)
        CoordiBtnExportarInforme.TabIndex = 3
        CoordiBtnExportarInforme.Text = "Exportar"
        CoordiBtnExportarInforme.UseVisualStyleBackColor = True
        ' 
        ' CoordiCBInforme
        ' 
        CoordiCBInforme.FormattingEnabled = True
        CoordiCBInforme.Items.AddRange(New Object() {"Carreras", "Inventario Actual", "Inventario Movimientos"})
        CoordiCBInforme.Location = New Point(22, 63)
        CoordiCBInforme.Margin = New Padding(4)
        CoordiCBInforme.Name = "CoordiCBInforme"
        CoordiCBInforme.Size = New Size(206, 35)
        CoordiCBInforme.TabIndex = 2
        ' 
        ' Label65
        ' 
        Label65.AutoSize = True
        Label65.Location = New Point(32, 18)
        Label65.Margin = New Padding(4, 0, 4, 0)
        Label65.Name = "Label65"
        Label65.Size = New Size(85, 27)
        Label65.TabIndex = 1
        Label65.Text = "Informe"
        ' 
        ' CoordiDGInforme
        ' 
        CoordiDGInforme.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        CoordiDGInforme.Location = New Point(23, 120)
        CoordiDGInforme.Margin = New Padding(4)
        CoordiDGInforme.Name = "CoordiDGInforme"
        CoordiDGInforme.RowHeadersWidth = 51
        CoordiDGInforme.RowTemplate.Height = 29
        CoordiDGInforme.Size = New Size(1019, 254)
        CoordiDGInforme.TabIndex = 0
        ' 
        ' CoordiPanelInventarioCarga
        ' 
        CoordiPanelInventarioCarga.Controls.Add(Panel6)
        CoordiPanelInventarioCarga.Controls.Add(Panel5)
        CoordiPanelInventarioCarga.Dock = DockStyle.Fill
        CoordiPanelInventarioCarga.Location = New Point(0, 34)
        CoordiPanelInventarioCarga.Margin = New Padding(4)
        CoordiPanelInventarioCarga.Name = "CoordiPanelInventarioCarga"
        CoordiPanelInventarioCarga.Size = New Size(1100, 574)
        CoordiPanelInventarioCarga.TabIndex = 34
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.FromArgb(CByte(41), CByte(125), CByte(60))
        Panel6.Controls.Add(Label63)
        Panel6.Location = New Point(18, 8)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(1069, 75)
        Panel6.TabIndex = 17
        ' 
        ' Label63
        ' 
        Label63.AutoSize = True
        Label63.Font = New Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Label63.ForeColor = Color.White
        Label63.Location = New Point(44, 18)
        Label63.Margin = New Padding(4, 0, 4, 0)
        Label63.Name = "Label63"
        Label63.Size = New Size(283, 40)
        Label63.TabIndex = 15
        Label63.Text = "Agregar Inventario"
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        Panel5.Controls.Add(InventarioCargarBtnAgregar)
        Panel5.Controls.Add(InventarioCargarCBProveedor)
        Panel5.Controls.Add(Label62)
        Panel5.Controls.Add(InventarioCargarTBNombre)
        Panel5.Controls.Add(InventarioCargarNUDAgregar)
        Panel5.Controls.Add(Label61)
        Panel5.Controls.Add(Label60)
        Panel5.Controls.Add(InventarioCargarBtnCargar)
        Panel5.Controls.Add(InventarioCargarNUDCargar)
        Panel5.Controls.Add(Label59)
        Panel5.Controls.Add(CargarInventarioCBCargar)
        Panel5.Controls.Add(Label58)
        Panel5.Controls.Add(Label57)
        Panel5.Controls.Add(Label56)
        Panel5.Controls.Add(CoordiDGInventario)
        Panel5.Location = New Point(19, 89)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(1068, 473)
        Panel5.TabIndex = 16
        ' 
        ' InventarioCargarBtnAgregar
        ' 
        InventarioCargarBtnAgregar.BackColor = Color.FromArgb(CByte(0), CByte(64), CByte(44))
        InventarioCargarBtnAgregar.ForeColor = Color.White
        InventarioCargarBtnAgregar.Location = New Point(96, 410)
        InventarioCargarBtnAgregar.Margin = New Padding(4)
        InventarioCargarBtnAgregar.Name = "InventarioCargarBtnAgregar"
        InventarioCargarBtnAgregar.Size = New Size(274, 49)
        InventarioCargarBtnAgregar.TabIndex = 14
        InventarioCargarBtnAgregar.Text = "Agregar"
        InventarioCargarBtnAgregar.UseVisualStyleBackColor = False
        ' 
        ' InventarioCargarCBProveedor
        ' 
        InventarioCargarCBProveedor.FormattingEnabled = True
        InventarioCargarCBProveedor.Location = New Point(152, 327)
        InventarioCargarCBProveedor.Margin = New Padding(4)
        InventarioCargarCBProveedor.Name = "InventarioCargarCBProveedor"
        InventarioCargarCBProveedor.Size = New Size(272, 35)
        InventarioCargarCBProveedor.TabIndex = 13
        ' 
        ' Label62
        ' 
        Label62.AutoSize = True
        Label62.Location = New Point(48, 327)
        Label62.Margin = New Padding(4, 0, 4, 0)
        Label62.Name = "Label62"
        Label62.Size = New Size(105, 27)
        Label62.TabIndex = 12
        Label62.Text = "Proveedor"
        ' 
        ' InventarioCargarTBNombre
        ' 
        InventarioCargarTBNombre.Location = New Point(156, 285)
        InventarioCargarTBNombre.Margin = New Padding(4)
        InventarioCargarTBNombre.Name = "InventarioCargarTBNombre"
        InventarioCargarTBNombre.Size = New Size(268, 34)
        InventarioCargarTBNombre.TabIndex = 11
        ' 
        ' InventarioCargarNUDAgregar
        ' 
        InventarioCargarNUDAgregar.Location = New Point(153, 370)
        InventarioCargarNUDAgregar.Margin = New Padding(4)
        InventarioCargarNUDAgregar.Name = "InventarioCargarNUDAgregar"
        InventarioCargarNUDAgregar.Size = New Size(274, 34)
        InventarioCargarNUDAgregar.TabIndex = 10
        ' 
        ' Label61
        ' 
        Label61.AutoSize = True
        Label61.Location = New Point(43, 373)
        Label61.Margin = New Padding(4, 0, 4, 0)
        Label61.Name = "Label61"
        Label61.Size = New Size(95, 27)
        Label61.TabIndex = 9
        Label61.Text = "Cantidad"
        ' 
        ' Label60
        ' 
        Label60.AutoSize = True
        Label60.Location = New Point(48, 284)
        Label60.Margin = New Padding(4, 0, 4, 0)
        Label60.Name = "Label60"
        Label60.Size = New Size(87, 27)
        Label60.TabIndex = 8
        Label60.Text = "Nombre"
        ' 
        ' InventarioCargarBtnCargar
        ' 
        InventarioCargarBtnCargar.BackColor = Color.FromArgb(CByte(0), CByte(64), CByte(44))
        InventarioCargarBtnCargar.ForeColor = Color.White
        InventarioCargarBtnCargar.Location = New Point(736, 410)
        InventarioCargarBtnCargar.Margin = New Padding(4)
        InventarioCargarBtnCargar.Name = "InventarioCargarBtnCargar"
        InventarioCargarBtnCargar.Size = New Size(274, 49)
        InventarioCargarBtnCargar.TabIndex = 7
        InventarioCargarBtnCargar.Text = "Cargar"
        InventarioCargarBtnCargar.UseVisualStyleBackColor = False
        ' 
        ' InventarioCargarNUDCargar
        ' 
        InventarioCargarNUDCargar.Location = New Point(738, 339)
        InventarioCargarNUDCargar.Margin = New Padding(4)
        InventarioCargarNUDCargar.Name = "InventarioCargarNUDCargar"
        InventarioCargarNUDCargar.Size = New Size(274, 34)
        InventarioCargarNUDCargar.TabIndex = 6
        ' 
        ' Label59
        ' 
        Label59.AutoSize = True
        Label59.Location = New Point(618, 341)
        Label59.Margin = New Padding(4, 0, 4, 0)
        Label59.Name = "Label59"
        Label59.Size = New Size(95, 27)
        Label59.TabIndex = 5
        Label59.Text = "Cantidad"
        ' 
        ' CargarInventarioCBCargar
        ' 
        CargarInventarioCBCargar.FormattingEnabled = True
        CargarInventarioCBCargar.Location = New Point(738, 296)
        CargarInventarioCBCargar.Margin = New Padding(4)
        CargarInventarioCBCargar.Name = "CargarInventarioCBCargar"
        CargarInventarioCBCargar.Size = New Size(272, 35)
        CargarInventarioCBCargar.TabIndex = 4
        ' 
        ' Label58
        ' 
        Label58.AutoSize = True
        Label58.Location = New Point(624, 300)
        Label58.Margin = New Padding(4, 0, 4, 0)
        Label58.Name = "Label58"
        Label58.Size = New Size(83, 27)
        Label58.TabIndex = 3
        Label58.Text = "Articulo"
        ' 
        ' Label57
        ' 
        Label57.AutoSize = True
        Label57.Location = New Point(768, 250)
        Label57.Margin = New Padding(4, 0, 4, 0)
        Label57.Name = "Label57"
        Label57.Size = New Size(73, 27)
        Label57.TabIndex = 2
        Label57.Text = "Cargar"
        ' 
        ' Label56
        ' 
        Label56.AutoSize = True
        Label56.Location = New Point(206, 254)
        Label56.Margin = New Padding(4, 0, 4, 0)
        Label56.Name = "Label56"
        Label56.Size = New Size(85, 27)
        Label56.TabIndex = 1
        Label56.Text = "Agregar"
        ' 
        ' CoordiDGInventario
        ' 
        CoordiDGInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        CoordiDGInventario.Location = New Point(31, 30)
        CoordiDGInventario.Margin = New Padding(4)
        CoordiDGInventario.Name = "CoordiDGInventario"
        CoordiDGInventario.RowHeadersWidth = 51
        CoordiDGInventario.RowTemplate.Height = 29
        CoordiDGInventario.Size = New Size(1009, 204)
        CoordiDGInventario.TabIndex = 0
        ' 
        ' CoordiPanelDescargarInventario
        ' 
        CoordiPanelDescargarInventario.Controls.Add(Panel4)
        CoordiPanelDescargarInventario.Controls.Add(Panel3)
        CoordiPanelDescargarInventario.Dock = DockStyle.Fill
        CoordiPanelDescargarInventario.Location = New Point(0, 34)
        CoordiPanelDescargarInventario.Margin = New Padding(4)
        CoordiPanelDescargarInventario.Name = "CoordiPanelDescargarInventario"
        CoordiPanelDescargarInventario.Size = New Size(1100, 574)
        CoordiPanelDescargarInventario.TabIndex = 35
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.FromArgb(CByte(41), CByte(125), CByte(60))
        Panel4.Controls.Add(Label64)
        Panel4.Location = New Point(32, 15)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1044, 68)
        Panel4.TabIndex = 33
        ' 
        ' Label64
        ' 
        Label64.AutoSize = True
        Label64.Font = New Font("Segoe UI Variable Display", 18F, FontStyle.Bold, GraphicsUnit.Point)
        Label64.ForeColor = Color.White
        Label64.Location = New Point(19, 13)
        Label64.Margin = New Padding(4, 0, 4, 0)
        Label64.Name = "Label64"
        Label64.Size = New Size(384, 40)
        Label64.TabIndex = 31
        Label64.Text = "DESCARGAR INVENTARIO"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        Panel3.Controls.Add(InventarioDescargarBtnDescargar)
        Panel3.Controls.Add(InventarioDescargarNUDCantidad)
        Panel3.Controls.Add(Label68)
        Panel3.Controls.Add(InventarioDescargarCBArticulo)
        Panel3.Controls.Add(Label69)
        Panel3.Controls.Add(Label70)
        Panel3.Controls.Add(CoordiDGDescargarInventario)
        Panel3.Location = New Point(32, 92)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1044, 470)
        Panel3.TabIndex = 32
        ' 
        ' InventarioDescargarBtnDescargar
        ' 
        InventarioDescargarBtnDescargar.BackColor = Color.FromArgb(CByte(0), CByte(64), CByte(44))
        InventarioDescargarBtnDescargar.ForeColor = Color.White
        InventarioDescargarBtnDescargar.Location = New Point(681, 407)
        InventarioDescargarBtnDescargar.Margin = New Padding(4)
        InventarioDescargarBtnDescargar.Name = "InventarioDescargarBtnDescargar"
        InventarioDescargarBtnDescargar.Size = New Size(346, 61)
        InventarioDescargarBtnDescargar.TabIndex = 23
        InventarioDescargarBtnDescargar.Text = "Descargar"
        InventarioDescargarBtnDescargar.UseVisualStyleBackColor = False
        ' 
        ' InventarioDescargarNUDCantidad
        ' 
        InventarioDescargarNUDCantidad.Location = New Point(755, 347)
        InventarioDescargarNUDCantidad.Margin = New Padding(4)
        InventarioDescargarNUDCantidad.Name = "InventarioDescargarNUDCantidad"
        InventarioDescargarNUDCantidad.Size = New Size(274, 34)
        InventarioDescargarNUDCantidad.TabIndex = 22
        ' 
        ' Label68
        ' 
        Label68.AutoSize = True
        Label68.Location = New Point(635, 349)
        Label68.Margin = New Padding(4, 0, 4, 0)
        Label68.Name = "Label68"
        Label68.Size = New Size(95, 27)
        Label68.TabIndex = 21
        Label68.Text = "Cantidad"
        ' 
        ' InventarioDescargarCBArticulo
        ' 
        InventarioDescargarCBArticulo.FormattingEnabled = True
        InventarioDescargarCBArticulo.Location = New Point(755, 304)
        InventarioDescargarCBArticulo.Margin = New Padding(4)
        InventarioDescargarCBArticulo.Name = "InventarioDescargarCBArticulo"
        InventarioDescargarCBArticulo.Size = New Size(272, 35)
        InventarioDescargarCBArticulo.TabIndex = 20
        ' 
        ' Label69
        ' 
        Label69.AutoSize = True
        Label69.Location = New Point(641, 308)
        Label69.Margin = New Padding(4, 0, 4, 0)
        Label69.Name = "Label69"
        Label69.Size = New Size(83, 27)
        Label69.TabIndex = 19
        Label69.Text = "Articulo"
        ' 
        ' Label70
        ' 
        Label70.AutoSize = True
        Label70.Location = New Point(809, 273)
        Label70.Margin = New Padding(4, 0, 4, 0)
        Label70.Name = "Label70"
        Label70.Size = New Size(104, 27)
        Label70.TabIndex = 18
        Label70.Text = "Descargar"
        ' 
        ' CoordiDGDescargarInventario
        ' 
        CoordiDGDescargarInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        CoordiDGDescargarInventario.Location = New Point(18, 53)
        CoordiDGDescargarInventario.Margin = New Padding(4)
        CoordiDGDescargarInventario.Name = "CoordiDGDescargarInventario"
        CoordiDGDescargarInventario.RowHeadersWidth = 51
        CoordiDGDescargarInventario.RowTemplate.Height = 29
        CoordiDGDescargarInventario.Size = New Size(1009, 205)
        CoordiDGDescargarInventario.TabIndex = 16
        ' 
        ' FormCoordi
        ' 
        AutoScaleDimensions = New SizeF(11F, 27F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1100, 608)
        Controls.Add(CoordiPanelVersion)
        Controls.Add(CoordiPanelInventarioCarga)
        Controls.Add(CoordiPanelAyuda)
        Controls.Add(CoordiPanelDescargarInventario)
        Controls.Add(CoordiPanelAgregarCarreras)
        Controls.Add(CoordiPanelInformes)
        Controls.Add(MenuStrip1)
        Controls.Add(Label1)
        Font = New Font("Segoe UI Variable Small", 12F, FontStyle.Regular, GraphicsUnit.Point)
        MainMenuStrip = MenuStrip1
        Margin = New Padding(4)
        Name = "FormCoordi"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Bienvenido, Coordinador"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        CoordiPanelAyuda.ResumeLayout(False)
        Panel32.ResumeLayout(False)
        Panel32.PerformLayout()
        Panel31.ResumeLayout(False)
        Panel31.PerformLayout()
        CoordiPanelVersion.ResumeLayout(False)
        CoordiPanelVersion.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CoordiPanelAgregarCarreras.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CoordiPanelInformes.ResumeLayout(False)
        CoordiPanelInformes.PerformLayout()
        CType(CoordiDGInforme, ComponentModel.ISupportInitialize).EndInit()
        CoordiPanelInventarioCarga.ResumeLayout(False)
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        CType(InventarioCargarNUDAgregar, ComponentModel.ISupportInitialize).EndInit()
        CType(InventarioCargarNUDCargar, ComponentModel.ISupportInitialize).EndInit()
        CType(CoordiDGInventario, ComponentModel.ISupportInitialize).EndInit()
        CoordiPanelDescargarInventario.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(InventarioDescargarNUDCantidad, ComponentModel.ISupportInitialize).EndInit()
        CType(CoordiDGDescargarInventario, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CarrerasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CargarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DescargarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VersionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CoordiPanelAyuda As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents CoordiPanelVersion As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents CoordiPanelAgregarCarreras As Panel
    Friend WithEvents AgregarCarrerasCBCarrera As TextBox
    Friend WithEvents Label52 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents CoordiBtnAgregarCarrera As Button
    Friend WithEvents CoordiPanelInformes As Panel
    Friend WithEvents CoordiBtnExportarInforme As Button
    Friend WithEvents CoordiCBInforme As ComboBox
    Friend WithEvents Label65 As Label
    Friend WithEvents CoordiDGInforme As DataGridView
    Friend WithEvents CoordiPanelInventarioCarga As Panel
    Friend WithEvents Label63 As Label
    Friend WithEvents InventarioCargarBtnAgregar As Button
    Friend WithEvents InventarioCargarCBProveedor As ComboBox
    Friend WithEvents Label62 As Label
    Friend WithEvents InventarioCargarTBNombre As TextBox
    Friend WithEvents InventarioCargarNUDAgregar As NumericUpDown
    Friend WithEvents Label61 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents InventarioCargarBtnCargar As Button
    Friend WithEvents InventarioCargarNUDCargar As NumericUpDown
    Friend WithEvents Label59 As Label
    Friend WithEvents CargarInventarioCBCargar As ComboBox
    Friend WithEvents Label58 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents Label56 As Label
    Friend WithEvents CoordiDGInventario As DataGridView
    Friend WithEvents CoordiPanelDescargarInventario As Panel
    Friend WithEvents Label64 As Label
    Friend WithEvents InventarioDescargarBtnDescargar As Button
    Friend WithEvents InventarioDescargarNUDCantidad As NumericUpDown
    Friend WithEvents Label68 As Label
    Friend WithEvents InventarioDescargarCBArticulo As ComboBox
    Friend WithEvents Label69 As Label
    Friend WithEvents Label70 As Label
    Friend WithEvents CoordiDGDescargarInventario As DataGridView
    Friend WithEvents AgregarCarrerasCBCostoCarrera As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label105 As Label
    Friend WithEvents Label104 As Label
    Friend WithEvents Label103 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label106 As Label
    Friend WithEvents Panel32 As Panel
    Friend WithEvents Label67 As Label
    Friend WithEvents Panel31 As Panel
    Friend WithEvents Label98 As Label
    Friend WithEvents Label97 As Label
End Class
