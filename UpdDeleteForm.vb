Imports Microsoft.Data.SqlClient

Public Class UpdDeleteForm
    Private connectionString As String = "Server=GAGAN\SQLEXPRESS;Database=seproject;Integrated Security=True;TrustServerCertificate=True;"

    ' Load Products into DataGridView on Form Load
    Private Sub UpdDeleteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetProducts()
    End Sub

    ' 🚀 Load Products into DataGridView
    Private Sub GetProducts()
        dgvProducts.Rows.Clear()

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "SELECT ProductID, ProductName, Price, Stock FROM Products"
            Using cmd As New SqlCommand(query, conn)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        dgvProducts.Rows.Add(reader("ProductID"), reader("ProductName"), reader("Price"), reader("Stock"))
                    End While
                End Using
            End Using
        End Using
    End Sub

    ' 📌 Select Product from DataGridView (Fills Textboxes)
    Private Sub dgvProducts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvProducts.Rows(e.RowIndex)
            txtProductID.Text = row.Cells(0).Value.ToString() ' ProductID (Read-Only)
            txtProductName.Text = row.Cells(1).Value.ToString()
            txtPrice.Text = row.Cells(2).Value.ToString()
            txtStock.Text = row.Cells(3).Value.ToString()
        End If
    End Sub

    ' 🔄 Update Product Details
    Private Sub btnUpdateProduct_Click(sender As Object, e As EventArgs) Handles btnUpdateProduct.Click
        If txtProductID.Text = "" Then
            MessageBox.Show("Please select a product to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "UPDATE Products SET ProductName = @ProductName, Price = @Price, Stock = @Stock WHERE ProductID = @ProductID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text)
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text)
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text))
                cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtStock.Text))

                cmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Product details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GetProducts() ' Refresh DataGridView
        MainForm.LoadProducts()
    End Sub

    ' ❌ Delete Product
    ' ❌ Delete Product
    Private Sub btnDeleteProduct_Click(sender As Object, e As EventArgs) Handles btnDeleteProduct.Click
        If txtProductID.Text = "" Then
            MessageBox.Show("Please select a product to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Confirmation before deleting
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If result = DialogResult.No Then Return

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            ' 🛑 Step 1: Delete related Cart items first
            Dim deleteCartQuery As String = "DELETE FROM Cart WHERE ProductID = @ProductID"
            Using deleteCartCmd As New SqlCommand(deleteCartQuery, conn)
                deleteCartCmd.Parameters.AddWithValue("@ProductID", txtProductID.Text)
                deleteCartCmd.ExecuteNonQuery()
            End Using

            ' ✅ Step 2: Now delete the product from Products table
            Dim deleteProductQuery As String = "DELETE FROM Products WHERE ProductID = @ProductID"
            Using deleteProductCmd As New SqlCommand(deleteProductQuery, conn)
                deleteProductCmd.Parameters.AddWithValue("@ProductID", txtProductID.Text)
                deleteProductCmd.ExecuteNonQuery()
            End Using
        End Using

        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        GetProducts() ' Refresh DataGridView
        MainForm.LoadProducts()
    End Sub
    Private Sub lblBack_Click(sender As Object, e As EventArgs) Handles lblBack.Click
        Me.Close()
        AdminForm.Show()
    End Sub

End Class
