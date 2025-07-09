Imports Microsoft.Data.SqlClient

Public Class ProfileForm
    Private connectionString As String = "Server=GAGAN\SQLEXPRESS;Database=seproject;Integrated Security=True;TrustServerCertificate=True;"

    Private Sub ProfileForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadUserProfile()
    End Sub

    Private Sub LoadUserProfile()
        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT FirstName, LastName, Address, Gender, phone_no FROM UserProfiles WHERE ID = @ID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", login.CurrentUserID)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtFirstName.Text = reader("FirstName").ToString()
                            txtLastName.Text = reader("LastName").ToString()
                            txtAddress.Text = reader("Address").ToString()
                            txtPhone_No.Text = reader("Phone_no").ToString()
                            cmbGender.SelectedItem = reader("Gender").ToString()

                            ' Disable fields if user details are already entered
                            If Not String.IsNullOrEmpty(txtFirstName.Text) Then
                                txtFirstName.Enabled = False
                                txtLastName.Enabled = False
                                txtAddress.Enabled = False
                                cmbGender.Enabled = False
                                txtPhone_No.Enabled = False
                                btnSave.Enabled = False
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading profile: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtFirstName.Text) OrElse String.IsNullOrEmpty(txtLastName.Text) OrElse
           String.IsNullOrEmpty(txtAddress.Text) OrElse cmbGender.SelectedIndex = -1 Then
            MessageBox.Show("Please fill in all the details before saving.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()

                ' Check if profile exists
                Dim checkQuery As String = "SELECT COUNT(*) FROM UserProfiles WHERE ID = @ID"
                Using checkCmd As New SqlCommand(checkQuery, conn)
                    checkCmd.Parameters.AddWithValue("@ID", login.CurrentUserID)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count = 0 Then
                        ' Insert new profile
                        Dim insertQuery As String = "INSERT INTO UserProfiles (ID, FirstName, LastName, Address,Phone_No , Gender) VALUES (@ID, @FirstName, @LastName, @Address, @Phone_No, @Gender)"
                        Using insertCmd As New SqlCommand(insertQuery, conn)
                            insertCmd.Parameters.AddWithValue("@ID", login.CurrentUserID)
                            insertCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                            insertCmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                            insertCmd.Parameters.AddWithValue("@Address", txtAddress.Text)
                            insertCmd.Parameters.AddWithValue("@Phone_No", txtPhone_No.Text)
                            insertCmd.Parameters.AddWithValue("@Gender", cmbGender.SelectedItem.ToString())
                            insertCmd.ExecuteNonQuery()
                        End Using
                    Else
                        ' Update existing profile
                        Dim updateQuery As String = "UPDATE UserProfiles SET FirstName = @FirstName, LastName = @LastName, Address = @Address, Gender = @Gender WHERE ID = @ID"
                        Using updateCmd As New SqlCommand(updateQuery, conn)
                            updateCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text)
                            updateCmd.Parameters.AddWithValue("@LastName", txtLastName.Text)
                            updateCmd.Parameters.AddWithValue("@Address", txtAddress.Text)
                            updateCmd.Parameters.AddWithValue("@Phone_No", txtPhone_No.Text)
                            updateCmd.Parameters.AddWithValue("@Gender", cmbGender.SelectedItem.ToString())
                            updateCmd.Parameters.AddWithValue("@ID", login.CurrentUserID)
                            updateCmd.ExecuteNonQuery()
                        End Using
                    End If
                End Using
            End Using

            ' Disable fields after saving
            txtFirstName.Enabled = False
            txtLastName.Enabled = False
            txtAddress.Enabled = False
            cmbGender.Enabled = False
            btnSave.Enabled = False

            MessageBox.Show("Profile details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error saving profile: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub lblEditAddress_Click(sender As Object, e As EventArgs) Handles lblEditAddress.Click
        btnSave.Enabled = True
        txtAddress.Enabled = True
    End Sub
    Private Sub lblHome_Click(sender As Object, e As EventArgs) Handles lblHome.Click
        Me.Close()
        MainForm.Show()
    End Sub


End Class
