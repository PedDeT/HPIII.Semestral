<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogin
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
        Label1 = New Label()
        Label2 = New Label()
        LoginTBUsuario = New TextBox()
        LoginTBContrasena = New TextBox()
        LoginBtnIngresar = New Button()
        Label3 = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        PictureBox2 = New PictureBox()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.ForeColor = Color.White
        Label1.Location = New Point(217, 218)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(75, 24)
        Label1.TabIndex = 0
        Label1.Text = "Usuario"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.ForeColor = Color.White
        Label2.Location = New Point(203, 308)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(105, 24)
        Label2.TabIndex = 1
        Label2.Text = "Contraseña"
        ' 
        ' LoginTBUsuario
        ' 
        LoginTBUsuario.Location = New Point(126, 246)
        LoginTBUsuario.Margin = New Padding(4)
        LoginTBUsuario.Name = "LoginTBUsuario"
        LoginTBUsuario.Size = New Size(255, 31)
        LoginTBUsuario.TabIndex = 2
        ' 
        ' LoginTBContrasena
        ' 
        LoginTBContrasena.Location = New Point(126, 336)
        LoginTBContrasena.Margin = New Padding(4)
        LoginTBContrasena.Name = "LoginTBContrasena"
        LoginTBContrasena.PasswordChar = "*"c
        LoginTBContrasena.Size = New Size(255, 31)
        LoginTBContrasena.TabIndex = 3
        LoginTBContrasena.UseSystemPasswordChar = True
        ' 
        ' LoginBtnIngresar
        ' 
        LoginBtnIngresar.BackColor = SystemColors.ActiveBorder
        LoginBtnIngresar.FlatAppearance.BorderSize = 0
        LoginBtnIngresar.FlatStyle = FlatStyle.System
        LoginBtnIngresar.Font = New Font("Segoe UI Variable Small", 13.8F, FontStyle.Bold, GraphicsUnit.Point)
        LoginBtnIngresar.Location = New Point(126, 405)
        LoginBtnIngresar.Margin = New Padding(4)
        LoginBtnIngresar.Name = "LoginBtnIngresar"
        LoginBtnIngresar.Size = New Size(255, 65)
        LoginBtnIngresar.TabIndex = 4
        LoginBtnIngresar.Text = "INGRESAR"
        LoginBtnIngresar.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Variable Display", 22.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = Color.White
        Label3.Location = New Point(113, 87)
        Label3.Name = "Label3"
        Label3.Size = New Size(301, 49)
        Label3.TabIndex = 5
        Label3.Text = "INICIAR SESIÓN"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.Fuchsia
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(LoginBtnIngresar)
        Panel1.Controls.Add(LoginTBContrasena)
        Panel1.Controls.Add(LoginTBUsuario)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(431, 67)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(503, 581)
        Panel1.TabIndex = 6
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(PictureBox2)
        Panel2.Dock = DockStyle.Left
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(351, 703)
        Panel2.TabIndex = 7
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.BackgroundImage = My.Resources.Resources.icone_utilisateur_gris1
        PictureBox2.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox2.Location = New Point(30, 242)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(261, 192)
        PictureBox2.TabIndex = 0
        PictureBox2.TabStop = False
        ' 
        ' FormLogin
        ' 
        AutoScaleDimensions = New SizeF(10F, 24F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.pexels_adrien_olichon_2387793
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1007, 703)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Font = New Font("Segoe UI Variable Small", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        Margin = New Padding(4)
        Name = "FormLogin"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "LOGIN"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LoginTBUsuario As TextBox
    Friend WithEvents LoginTBContrasena As TextBox
    Friend WithEvents LoginBtnIngresar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox2 As PictureBox
End Class
