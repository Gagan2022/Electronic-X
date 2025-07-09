Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox
Imports Microsoft.Data.SqlClient

Public Class MainForm
    Private connectionString As String = "Server=GAGAN\SQLEXPRESS;Database=seproject;Integrated Security=True;TrustServerCertificate=True;"

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        Me.Text = "Electronic X - Dashboard"

        ' Load user details from database
        LoadUserDetails()

        ' Start the timer to update time
        Timer1.Interval = 1000 ' Set to update every second
        Timer1.Start()
        LoadProducts()

    End Sub
    Protected Friend Sub LoadProducts()
        flpProducts.Controls.Clear()
        flpProducts.Dock = DockStyle.Fill
        flpProducts.AutoScroll = True
        flpProducts.WrapContents = False
        flpProducts.FlowDirection = FlowDirection.TopDown

        Dim query As String = "SELECT ProductID, ProductName, Price, Stock, ImageData, Description, Category FROM Products"

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        Dim categoryPanels As New Dictionary(Of String, FlowLayoutPanel)()

                        While reader.Read()
                            Dim productID As Integer = Convert.ToInt32(reader("ProductID"))
                            Dim productName As String = reader("ProductName").ToString()
                            Dim price As Decimal = Convert.ToDecimal(reader("Price"))
                            Dim stock As Integer = Convert.ToInt32(reader("Stock"))
                            Dim description As String = reader("Description").ToString()
                            Dim category As String = reader("Category").ToString()
                            Dim imageBytes() As Byte = If(reader("ImageData") IsNot DBNull.Value, CType(reader("ImageData"), Byte()), Nothing)

                            If Not categoryPanels.ContainsKey(category) Then
                                ' Category Label
                                Dim lblCategory As New Label()
                                lblCategory.Text = category
                                lblCategory.Font = New Font("Arial", 12, FontStyle.Bold)
                                lblCategory.AutoSize = True
                                lblCategory.Margin = New Padding(10, 20, 0, 5)
                                flpProducts.Controls.Add(lblCategory)

                                ' Category FlowLayoutPanel
                                Dim catPanel As New FlowLayoutPanel()
                                catPanel.FlowDirection = FlowDirection.LeftToRight
                                catPanel.WrapContents = True
                                catPanel.AutoSize = True
                                catPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink
                                catPanel.Dock = DockStyle.Top
                                catPanel.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                                catPanel.Margin = New Padding(10, 0, 10, 10)

                                flpProducts.Controls.Add(catPanel)
                                categoryPanels(category) = catPanel
                            End If

                            ' Product Image
                            Dim pic As New PictureBox()
                            pic.SizeMode = PictureBoxSizeMode.StretchImage
                            pic.Size = New Size(140, 100)
                            pic.Location = New Point(10, 10)

                            If imageBytes IsNot Nothing Then
                                Using ms As New MemoryStream(imageBytes)
                                    pic.Image = Image.FromStream(ms)
                                End Using
                            Else
                                Dim defaultImage As New Bitmap(100, 100)
                                Using g As Graphics = Graphics.FromImage(defaultImage)
                                    g.Clear(Color.Gray)
                                End Using
                                pic.Image = defaultImage
                            End If

                            ' Product Name
                            Dim lblName As New Label()
                            lblName.Text = productName
                            lblName.AutoSize = True
                            lblName.Font = New Font("Arial", 10, FontStyle.Bold)
                            lblName.Location = New Point(10, 120)

                            ' Price
                            Dim lblPrice As New Label()
                            lblPrice.Text = "₹" & price.ToString("N2")
                            lblPrice.AutoSize = True
                            lblPrice.Font = New Font("Arial", 9, FontStyle.Bold)
                            lblPrice.ForeColor = Color.Green
                            lblPrice.Location = New Point(10, 150)

                            ' Stock Label
                            Dim lblStock As New Label()
                            lblStock.AutoSize = True
                            lblStock.Font = New Font("Arial", 9, FontStyle.Bold)
                            lblStock.Location = New Point(10, 180)

                            If stock > 0 Then
                                lblStock.Text = "Stock: " & stock.ToString()
                                lblStock.ForeColor = Color.Blue
                            Else
                                lblStock.Text = "Out of Stock"
                                lblStock.ForeColor = Color.Red
                            End If

                            ' ✅ Check if product is already in the cart
                            Dim existingCartQty As Integer = 0
                            If stock > 0 Then
                                Using connQty As New SqlConnection(connectionString)
                                    connQty.Open()
                                    Dim qtyQuery As String = "SELECT Quantity FROM Cart WHERE UserID = @UserID AND ProductID = @ProductID"
                                    Using cmdQty As New SqlCommand(qtyQuery, connQty)
                                        cmdQty.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                                        cmdQty.Parameters.AddWithValue("@ProductID", productID)
                                        Dim result As Object = cmdQty.ExecuteScalar()
                                        If result IsNot Nothing Then
                                            existingCartQty = CInt(result)
                                        End If
                                    End Using
                                End Using
                            End If

                            ' Quantity Selector
                            Dim numQuantity As New NumericUpDown()
                            numQuantity.Minimum = 1
                            numQuantity.Maximum = If(stock > 0, stock, 1)
                            numQuantity.Value = If(existingCartQty > 0, existingCartQty, 1)
                            numQuantity.Location = New Point(10, 200)
                            numQuantity.Width = 50
                            numQuantity.Enabled = stock > 0

                            ' Add to Cart / Update Button
                            Dim btnAddToCart As New Button()
                            btnAddToCart.Text = If(existingCartQty > 0, "Update Cart", "Add to Cart")
                            btnAddToCart.Size = New Size(100, 30)
                            btnAddToCart.Location = New Point(70, 200)
                            btnAddToCart.Enabled = stock > 0

                            AddHandler btnAddToCart.Click, Sub(sender, e)
                                                               Dim selectedQuantity As Integer = CInt(numQuantity.Value)
                                                               AddToCart(productID, productName, price, selectedQuantity, stock)
                                                               btnAddToCart.Text = "Update Cart"
                                                           End Sub

                            ' Open product details on image or name click
                            AddHandler pic.Click, Sub(sender, e)
                                                      Dim detailsForm As New ProductDetailsForm()
                                                      detailsForm.SetProductDetails(productID, productName, price, stock, description, imageBytes)
                                                      detailsForm.ShowDialog()
                                                  End Sub

                            AddHandler lblName.Click, Sub(sender, e)
                                                          Dim detailsForm As New ProductDetailsForm()
                                                          detailsForm.SetProductDetails(productID, productName, price, stock, description, imageBytes)
                                                          detailsForm.ShowDialog()
                                                      End Sub

                            ' Product Panel
                            Dim productPanel As New Panel()
                            productPanel.Size = New Size(180, 270)
                            productPanel.BorderStyle = BorderStyle.FixedSingle
                            productPanel.Margin = New Padding(10)
                            productPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Left

                            productPanel.Controls.Add(pic)
                            productPanel.Controls.Add(lblName)
                            productPanel.Controls.Add(lblPrice)
                            productPanel.Controls.Add(lblStock)
                            productPanel.Controls.Add(numQuantity)
                            productPanel.Controls.Add(btnAddToCart)

                            ' Add to category panel
                            categoryPanels(category).Controls.Add(productPanel)

                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub OpenProductDetails(productID As Integer, productName As String, price As Decimal, stock As Integer, description As String, imageBytes() As Byte)
        ' Create an instance of ProductDetailsForm
        Dim detailsForm As New ProductDetailsForm()

        ' Pass data to ProductDetailsForm (Ensure ProductDetailsForm has these properties/methods)
        detailsForm.SetProductDetails(productID, productName, price, stock, description, imageBytes)

        ' Show the form as a dialog
        detailsForm.ShowDialog()
    End Sub


    Public Sub AddToCart(productID As Integer, productName As String, price As Decimal, quantity As Integer, stock As Integer)
        Using conn As New SqlConnection(connectionString)
            conn.Open()

            ' Check if item already exists in the cart
            Dim checkQuery As String = "SELECT Quantity FROM Cart WHERE UserID = @UserID AND ProductID = @ProductID"
            Using checkCmd As New SqlCommand(checkQuery, conn)
                checkCmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                checkCmd.Parameters.AddWithValue("@ProductID", productID)

                Dim existingQuantity As Object = checkCmd.ExecuteScalar()

                ' Prevent exceeding stock
                If quantity > stock Then
                    MessageBox.Show("Cannot add more than available stock!", "Stock Limit", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                If existingQuantity IsNot Nothing Then
                    ' Replace quantity in the cart (not add)
                    Dim updateQuery As String = "UPDATE Cart SET Quantity = @Quantity WHERE UserID = @UserID AND ProductID = @ProductID"
                    Using updateCmd As New SqlCommand(updateQuery, conn)
                        updateCmd.Parameters.AddWithValue("@Quantity", quantity)
                        updateCmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                        updateCmd.Parameters.AddWithValue("@ProductID", productID)
                        updateCmd.ExecuteNonQuery()
                    End Using
                Else
                    ' Insert new item into cart
                    Dim insertQuery As String = "INSERT INTO Cart (UserID, ProductID, Quantity) VALUES (@UserID, @ProductID, @Quantity)"
                    Using insertCmd As New SqlCommand(insertQuery, conn)
                        insertCmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                        insertCmd.Parameters.AddWithValue("@ProductID", productID)
                        insertCmd.Parameters.AddWithValue("@Quantity", quantity)
                        insertCmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
        End Using

        ' Update Order Form with correct parameters
        Dim updatedQuantityQuery As String = "SELECT Quantity FROM Cart WHERE UserID = @UserID AND ProductID = @ProductID"
        Using conn2 As New SqlConnection(connectionString)
            conn2.Open()
            Using cmd2 As New SqlCommand(updatedQuantityQuery, conn2)
                cmd2.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                cmd2.Parameters.AddWithValue("@ProductID", productID)

                Dim finalQty As Object = cmd2.ExecuteScalar()
                If finalQty IsNot Nothing Then
                    UpdateCartQuantity(productID, CInt(finalQty))
                End If
            End Using
        End Using
    End Sub



    Protected Friend Sub UpdateCartQuantity(productID As Integer, newQuantity As Integer)
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "UPDATE Cart SET Quantity = @Quantity WHERE UserID = @UserID AND ProductID = @ProductID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Quantity", newQuantity)
                cmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                cmd.Parameters.AddWithValue("@ProductID", productID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
        OrderForm.LoadCartItems() ' Refresh using LoadCartItems
    End Sub







    Private Sub LoadUserDetails()
        If login.CurrentUserID = 0 Then
            MessageBox.Show("Error: No user logged in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            login.Show()
            Return
        End If

        Try
            Using conn As New SqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT FullName, Email FROM Users WHERE ID = @ID"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ID", login.CurrentUserID)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lbluser.Text = "Hi! " & reader("FullName").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading user details: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub lblProfile_Click(sender As Object, e As EventArgs) Handles lblProfile.Click
        Dim ProfileForm As New ProfileForm()
        ProfileForm.Show()
        Me.Close()
    End Sub

    Private Sub lblMyOrder_Click(sender As Object, e As EventArgs) Handles lblMyOrders.Click
        Dim MyOrderForm As New OrderForm
        MyOrderForm.Show()
        Me.Close()
    End Sub


    Private Sub lblLogout_Click(sender As Object, e As EventArgs) Handles lblLogOut.Click
        ' Reset user session
        login.CurrentUserID = 0
        Close()
        login.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTime.Text = "Time: " & DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

End Class

