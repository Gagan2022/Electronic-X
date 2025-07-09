Imports Microsoft.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Drawing.Text  ' Required for SQL Server connection

Public Class register
    ' Define the connection
    Dim connString As New String("Server=GAGAN\SQLEXPRESS;Database=seproject;Integrated Security=True;TrustServerCertificate=True;")
    Private Function HashPassword(password As String) As String
        Dim salt As Byte() = New Byte(15) {}
        RandomNumberGenerator.Fill(salt)

        Using pbkdf2 As New Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA512)
            Dim hash As Byte() = pbkdf2.GetBytes(32)
            Return Convert.ToBase64String(salt) & ":" & Convert.ToBase64String(hash)
        End Using
    End Function

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ' Insert User Data into SQL Server
        Dim conn As New SqlConnection(connString)
        Dim query As String = "INSERT INTO Users (FullName, Email, Password, Role) VALUES (@name, @email, @password, @role)"

        Try
            conn.Open()
            Dim cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@name", txtName.Text)
            cmd.Parameters.AddWithValue("@email", txtEmail.Text)
            cmd.Parameters.AddWithValue("@role", "user")
            cmd.Parameters.AddWithValue("@password", HashPassword(txtPassword.Text)) ' Store hashed password

            cmd.ExecuteNonQuery()
            MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            login.Show()

            ' Clear Textboxes
            txtName.Clear()
            txtEmail.Clear()
            txtPassword.Clear()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub
    Private Sub lblRegister_Click(sender As Object, e As EventArgs) Handles lblRegister.Click
        ' Hide the LoginForm and show the RegistrationForm
        Me.Hide()
        login.Show()
    End Sub

    Private Sub register_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

