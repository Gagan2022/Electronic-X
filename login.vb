Imports Microsoft.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading

Public Class login
    ' Define the connection string (adjust for your server)
    Dim connString As String = "Server=GAGAN\SQLEXPRESS;Database=seproject;Integrated Security=True;TrustServerCertificate=True;"
    Public Shared CurrentUserID As Integer ' Global variable to store logged-in User ID

    ' Hash Password for comparison (Same method used in registration)
    Private Function HashPassword(password As String, salt As String) As String
        ' Convert the Base64 salt to a byte array
        Using pbkdf2 As New Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 100000, HashAlgorithmName.SHA512)
            Dim hash As Byte() = pbkdf2.GetBytes(32)
            Return Convert.ToBase64String(hash) ' Return hash as Base64 string
        End Using
    End Function

    ' Login button click event
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Get email and password from textboxes
        Dim email As String = txtEmail.Text ' Email field
        Dim password As String = txtPassword.Text ' Password field

        ' Check if email and password are entered
        If String.IsNullOrEmpty(email) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both email and password.", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Query to find the user by email (username)
        Dim query As String = "SELECT ID, FullName, Email, Password, Role FROM Users WHERE Email = @username"


        Using conn As New SqlConnection(connString)
            Try
                conn.Open()

                ' Create SQL command with parameterized query to avoid SQL injection
                Dim cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@username", email) ' Use the email (username)

                ' Execute the command and read the results
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    CurrentUserID = Convert.ToInt32(reader("ID"))

                    Dim storedPassword As String = reader("Password").ToString()
                    Dim passwordParts As String() = storedPassword.Split(":"c)

                    Dim storedSalt As String = passwordParts(0)
                    Dim storedHash As String = passwordParts(1)

                    If HashPassword(password, storedSalt) = storedHash Then
                        Dim role As String = reader("Role").ToString().ToLower()

                        Me.Hide()
                        If role = "admin" Then
                            AdminForm.Show()
                        Else
                            MainForm.Show()
                        End If
                    Else
                        MessageBox.Show("Invalid password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        txtEmail.Clear()
        txtPassword.Clear()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub lblRegister_Click(sender As Object, e As EventArgs) Handles lblRegister.Click
        ' Hide the LoginForm and show the RegistrationForm
        Me.Hide()
        register.Show()
    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
