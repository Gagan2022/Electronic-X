Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.Data.SqlClient

Public Class ProductDetailsForm
    Inherits Form

    Private lblProductName As New Label()
    Private lblPrice As New Label()
    Private lblStock As New Label()
    Private lblDescription As New Label()
    Private picProductImage As New PictureBox()
    Private btnAddToCart As New Button()
    Private productID As Integer
    Private price As Decimal
    Private stock As Integer
    Private connectionString As String = "Server=GAGAN\SQLEXPRESS;Database=seproject;Integrated Security=True;TrustServerCertificate=True;"

    Public Sub New()
        ' Form properties
        Me.Text = "Product Details"
        Me.Size = New Size(400, 600)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Product Image
        picProductImage.Size = New Size(150, 150)
        picProductImage.Location = New Point(125, 20)
        picProductImage.SizeMode = PictureBoxSizeMode.Zoom
        Me.Controls.Add(picProductImage)

        ' Product Name
        lblProductName.AutoSize = True
        lblProductName.Font = New Font("Arial", 14, FontStyle.Bold)
        lblProductName.Location = New Point(20, 180)
        Me.Controls.Add(lblProductName)

        ' Price
        lblPrice.AutoSize = True
        lblPrice.Font = New Font("Arial", 12, FontStyle.Regular)
        lblPrice.ForeColor = Color.Green
        lblPrice.Location = New Point(20, 220)
        Me.Controls.Add(lblPrice)

        ' Stock
        lblStock.AutoSize = True
        lblStock.Font = New Font("Arial", 10, FontStyle.Regular)
        lblStock.Location = New Point(20, 260)
        Me.Controls.Add(lblStock)

        ' Description
        lblDescription.AutoSize = True
        lblDescription.Location = New Point(20, 290)
        Me.Controls.Add(lblDescription)

        ' Add to Cart Button
        btnAddToCart.Text = "Add to Cart"
        btnAddToCart.Size = New Size(150, 40)
        btnAddToCart.Location = New Point(125, 510)
        AddHandler btnAddToCart.Click, AddressOf AddToCart_Click
        Me.Controls.Add(btnAddToCart)
    End Sub

    Public Sub SetProductDetails(prodID As Integer, prodName As String, prodPrice As Decimal, prodStock As Integer, description As String, imageBytes() As Byte)
        productID = prodID
        price = prodPrice
        stock = prodStock
        lblProductName.Text = prodName
        lblPrice.Text = "₹" & price.ToString("N2")
        lblStock.Text = "Stock: " & stock.ToString()
        lblDescription.Text = description

        ' Convert byte array to image if available
        If imageBytes IsNot Nothing Then
            Using ms As New MemoryStream(imageBytes)
                picProductImage.Image = Image.FromStream(ms)
            End Using
        Else
            picProductImage.Image = Nothing
        End If
    End Sub

    ' Function to add product to cart
    Private Sub AddToCart_Click(sender As Object, e As EventArgs)
        Using conn As New SqlConnection(connectionString)
            conn.Open()

            ' Check if item already exists in the cart
            Dim checkQuery As String = "SELECT Quantity FROM Cart WHERE UserID = @UserID AND ProductID = @ProductID"
            Using checkCmd As New SqlCommand(checkQuery, conn)
                checkCmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                checkCmd.Parameters.AddWithValue("@ProductID", productID)

                Dim existingQuantity As Object = checkCmd.ExecuteScalar()

                If existingQuantity IsNot Nothing Then
                    ' Update existing cart quantity
                    Dim newQuantity As Integer = CInt(existingQuantity) + 1

                    ' Prevent exceeding stock
                    If newQuantity > stock Then
                        MessageBox.Show("Cannot add more than available stock!", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If

                    Dim updateQuery As String = "UPDATE Cart SET Quantity = @Quantity WHERE UserID = @UserID AND ProductID = @ProductID"
                    Using updateCmd As New SqlCommand(updateQuery, conn)
                        updateCmd.Parameters.AddWithValue("@Quantity", newQuantity)
                        updateCmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                        updateCmd.Parameters.AddWithValue("@ProductID", productID)
                        updateCmd.ExecuteNonQuery()
                    End Using
                Else
                    ' Insert new item into cart
                    Dim insertQuery As String = "INSERT INTO Cart (UserID, ProductID, Quantity) VALUES (@UserID, @ProductID, 1)"
                    Using insertCmd As New SqlCommand(insertQuery, conn)
                        insertCmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                        insertCmd.Parameters.AddWithValue("@ProductID", productID)
                        insertCmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
        End Using

        MessageBox.Show("Product added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ProductDetailsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AutoScroll = True
    End Sub
End Class
