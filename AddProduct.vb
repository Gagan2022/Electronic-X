Imports Microsoft.Data.SqlClient
Imports System.IO
Imports System.Drawing

Public Class AddProduct
    Private imageBytes() As Byte = Nothing  ' To store image data

    Private Sub AddProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Enable drag & drop for PictureBox
        PictureBox1.AllowDrop = True
    End Sub

    ' 🖼 Drag & Drop Image Upload
    Private Sub PictureBox1_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    Private Sub PictureBox1_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox1.DragDrop
        Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If files.Length > 0 Then
            Dim imagePath As String = files(0)  ' Get the first dragged file
            PictureBox1.Image = Image.FromFile(imagePath)

            ' Convert image to byte array
            imageBytes = File.ReadAllBytes(imagePath)
        End If
    End Sub

    ' 📂 Browse Image Upload
    ' 📂 Browse Image Upload
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Try
                    Dim imagePath As String = openFileDialog.FileName
                    PictureBox1.Image = Image.FromFile(imagePath)

                    ' Convert image to byte array
                    Using ms As New MemoryStream()
                        PictureBox1.Image.Save(ms, Imaging.ImageFormat.Png)
                        imageBytes = ms.ToArray()
                    End Using

                Catch ex As Exception
                    MessageBox.Show("Error loading image: " & ex.Message, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub


    ' 💾 Save Product to Database
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim connString As String = "Server=GAGAN\SQLEXPRESS;Database=seproject;Integrated Security=True;TrustServerCertificate=True;"
        Dim query As String = "INSERT INTO Products (ProductName, Price, Description, Category, Stock, ImageData) VALUES (@name, @price, @desc, @cat, @stock, @img)"

        Try
            ' Check if image is uploaded
            If imageBytes Is Nothing OrElse imageBytes.Length = 0 Then
                MessageBox.Show("Please upload an image to add the product.", "Missing Image", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Using conn As New SqlConnection(connString)
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@name", txtProductName.Text)
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text))
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text)
                    cmd.Parameters.AddWithValue("@cat", txtCategory.Text)
                    cmd.Parameters.AddWithValue("@stock", Convert.ToInt32(txtStock.Text))
                    cmd.Parameters.AddWithValue("@img", imageBytes)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Product saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtProductName.Clear()
            txtPrice.Clear()
            txtDescription.Clear()
            txtCategory.Clear()
            txtStock.Clear()
            PictureBox1.Image = Nothing
            imageBytes = Nothing


        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub lblBack_Click(sender As Object, e As EventArgs) Handles lblBack.Click
        Me.Close()
        AdminForm.Show()
    End Sub
End Class
