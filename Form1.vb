Imports System.Data.SqlClient

Public Class FormLogin

    'Public connectionString As String = "Data Source=DESKTOP-910LQQK;Initial Catalog=SEMESTRALPEDRORENEDB1;Integrated Security=True; Encrypt=False"
    Public connectionString As String = "Data Source=RENE_RUIZ\SQLEXPRESS;Initial Catalog=SEMESTRALPEDRORENEDB1;Integrated Security=True"
    Private Sub LoginBtnEntrar_Click(sender As Object, e As EventArgs) Handles LoginBtnIngresar.Click
        Dim username As String = LoginTBUsuario.Text
        Dim password As String = LoginTBContrasena.Text

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT Rango FROM LOGIN WHERE Usuario = @Usuario AND Contrasena = @Contrasena"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Usuario", username)
            command.Parameters.AddWithValue("@Contrasena", password)

            Dim reader As SqlDataReader = command.ExecuteReader()
            LoginTBUsuario.Clear()
            LoginTBContrasena.Clear()
            If reader.Read() Then
                Dim rango As String = reader("Rango").ToString()
                If rango = "Administracion" Then
                    FormAdmin.Show()
                ElseIf rango = "Coordinador" Then
                    FormCoordi.Show()
                    ' Add the username to the ENTRADAS table
                    AddEntrada(username)
                ElseIf rango = "Colaborador" Then
                    FormColab.Show()
                    ' Add the username to the ENTRADAS table
                    AddEntrada(username)
                Else
                    MessageBox.Show("Usuario o Contrasena Invalidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Hide()
            Else
                MessageBox.Show("Usuario o Contrasena Invalidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Using
    End Sub

    Private Sub AddEntrada(username As String)
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Fetch the current maximum Id from the ENTRADAS table
            Dim maxIdQuery As String = "SELECT MAX(Id) FROM ENTRADAS"
            Dim maxIdCommand As New SqlCommand(maxIdQuery, connection)
            Dim maxIdObj As Object = maxIdCommand.ExecuteScalar()

            Dim newId As Integer
            If maxIdObj IsNot DBNull.Value AndAlso Integer.TryParse(maxIdObj.ToString(), newId) Then
                ' Increment the newId for the next entry
                newId += 1
            Else
                ' Set the newId to 1 if there are no existing entries in the table
                newId = 1
            End If

            ' Insert a new row into the ENTRADAS table with the incremented Id
            Dim insertQuery As String = "INSERT INTO ENTRADAS (Id, Entrada) VALUES (@Id, @Entrada)"
            Dim insertCommand As New SqlCommand(insertQuery, connection)
            insertCommand.Parameters.AddWithValue("@Id", newId)
            insertCommand.Parameters.AddWithValue("@Entrada", username)

            insertCommand.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.BackColor = Color.FromArgb(100, 97, 99, 102)
        Panel2.BackColor = Color.FromArgb(100, 97, 99, 102)
    End Sub
End Class