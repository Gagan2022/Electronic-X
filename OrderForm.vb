Imports Microsoft.Data.SqlClient
Imports System.IO

Public Class OrderForm
    Private connectionString As String = "Server=GAGAN\SQLEXPRESS;Database=seproject;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True"



    Private Sub OrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowCart() ' Default view is Cart
        RefreshTotalPrice()
    End Sub

    ' 🔘 Show Cart
    Private Sub ShowCart()
        pnlCart.Visible = True
        pnlOrderHistory.Visible = False
        btnCart.BackColor = Color.LightBlue
        btnOrderHistory.BackColor = SystemColors.Control
        LoadCartItems()
    End Sub

    ' 📜 Show Order History
    Private Sub ShowOrderHistory()
        pnlCart.Visible = False
        pnlOrderHistory.Visible = True
        pnlOrderHistory.BringToFront() ' Ensure it appears on top
        btnCart.BackColor = SystemColors.Control
        btnOrderHistory.BackColor = Color.LightBlue
        LoadOrderHistory()
    End Sub

    ' 🛒 Load Cart Items (Already in Your Code)
    Protected Friend Sub LoadCartItems()
        flpCart.Controls.Clear()
        Dim totalPrice As Decimal = 0

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "SELECT c.ProductID, p.ProductName, p.Price, c.Quantity, p.ImageData, p.Stock 
                                   FROM Cart c
                                   INNER JOIN Products p ON c.ProductID = p.ProductID
                                   WHERE c.UserID = @UserID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Extract product details
                        Dim productID As Integer = reader("ProductID")
                        Dim productName As String = reader("ProductName").ToString()
                        Dim price As Decimal = Convert.ToDecimal(reader("Price"))
                        Dim quantity As Integer = Convert.ToInt32(reader("Quantity"))
                        Dim stock As Integer = Convert.ToInt32(reader("Stock"))
                        Dim imageBytes() As Byte = If(reader("ImageData") IsNot DBNull.Value, CType(reader("ImageData"), Byte()), Nothing)

                        totalPrice += price * quantity

                        ' Create Cart Item Panel
                        Dim cartItemPanel As New Panel With {
                            .Size = New Size(400, 100),
                            .BorderStyle = BorderStyle.FixedSingle
                        }

                        ' Picture Box for Product Image
                        Dim pic As New PictureBox With {
                            .Size = New Size(80, 80),
                            .Location = New Point(10, 10),
                            .SizeMode = PictureBoxSizeMode.StretchImage
                        }

                        If imageBytes IsNot Nothing Then
                            Using ms As New MemoryStream(imageBytes)
                                pic.Image = Image.FromStream(ms)
                            End Using
                        Else
                            pic.Image = New Bitmap(80, 80) ' Default gray image
                        End If

                        ' Label for Product Name
                        Dim lblName As New Label With {
                            .Text = productName,
                            .Font = New Font("Arial", 10, FontStyle.Bold),
                            .Location = New Point(100, 10),
                            .AutoSize = True
                        }

                        ' Label for Price
                        Dim lblPrice As New Label With {
                            .Text = "₹" & price.ToString("N2"),
                            .Font = New Font("Arial", 9, FontStyle.Bold),
                            .ForeColor = Color.Green,
                            .Location = New Point(100, 40),
                            .AutoSize = True
                        }

                        ' Quantity Controls
                        Dim btnMinus As New Button With {.Text = "-", .Size = New Size(30, 30), .Location = New Point(100, 70)}
                        Dim lblQuantity As New Label With {.Text = quantity.ToString(), .Location = New Point(140, 75), .AutoSize = True}
                        Dim btnPlus As New Button With {.Text = "+", .Size = New Size(30, 30), .Location = New Point(170, 70)}
                        Dim btnRemove As New Button With {.Text = "Remove", .Size = New Size(70, 30), .Location = New Point(210, 70), .BackColor = Color.Red, .ForeColor = Color.White}

                        ' Button Handlers
                        AddHandler btnPlus.Click, Sub()
                                                      If GetCurrentQuantity(productID) < stock Then
                                                          UpdateCartQuantity(productID, GetCurrentQuantity(productID) + 1, lblQuantity)
                                                      Else
                                                          MessageBox.Show("Stock limit reached!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                      End If
                                                  End Sub

                        AddHandler btnMinus.Click, Sub()
                                                       If GetCurrentQuantity(productID) > 1 Then
                                                           UpdateCartQuantity(productID, GetCurrentQuantity(productID) - 1, lblQuantity)
                                                       Else
                                                           RemoveFromCart(productID)
                                                       End If
                                                   End Sub

                        AddHandler btnRemove.Click, Sub() RemoveFromCart(productID)

                        ' Add Controls to Panel
                        cartItemPanel.Controls.Add(pic)
                        cartItemPanel.Controls.Add(lblName)
                        cartItemPanel.Controls.Add(lblPrice)
                        cartItemPanel.Controls.Add(btnMinus)
                        cartItemPanel.Controls.Add(lblQuantity)
                        cartItemPanel.Controls.Add(btnPlus)
                        cartItemPanel.Controls.Add(btnRemove)

                        ' Add Panel to FlowLayoutPanel
                        flpCart.Controls.Add(cartItemPanel)
                    End While
                End Using
            End Using
        End Using

        RefreshTotalPrice()
    End Sub

    ' 📦 Load Order History
    Private Sub LoadOrderHistory()
        flpOrderHistory.Controls.Clear()

        Using conn As New SqlConnection(connectionString)
            conn.Open()

            Dim queryOrders As String = "SELECT OrderID, OrderDate, TotalAmount FROM Orders WHERE UserID = @UserID ORDER BY OrderDate DESC"
            Using cmdOrders As New SqlCommand(queryOrders, conn)
                cmdOrders.Parameters.AddWithValue("@UserID", login.CurrentUserID)

                Using readerOrders As SqlDataReader = cmdOrders.ExecuteReader()
                    If readerOrders.HasRows Then
                        While readerOrders.Read()
                            Dim orderId As Integer = readerOrders("OrderID")
                            Dim orderPanel As New Panel With {.Size = New Size(400, 120), .BorderStyle = BorderStyle.FixedSingle}
                            Dim lblOrderInfo As New Label With {
                            .Text = $"Order #{orderId} - ₹{readerOrders("TotalAmount")} on {CDate(readerOrders("OrderDate")).ToShortDateString()}",
                            .Font = New Font("Arial", 10, FontStyle.Bold),
                            .Location = New Point(10, 10),
                            .AutoSize = True
                        }

                            orderPanel.Controls.Add(lblOrderInfo)

                            ' Fetch order items using a new connection
                            Using connItems As New SqlConnection(connectionString)
                                connItems.Open()

                                Dim queryItems As String = "SELECT p.ProductName, oi.Quantity, p.Price
                                                        FROM OrderItems oi 
                                                        INNER JOIN Products p ON oi.ProductID = p.ProductID 
                                                        WHERE oi.OrderID = @OrderID"
                                Using cmdItems As New SqlCommand(queryItems, connItems)
                                    cmdItems.Parameters.AddWithValue("@OrderID", orderId)

                                    Using readerItems As SqlDataReader = cmdItems.ExecuteReader()
                                        Dim yPos As Integer = 30
                                        While readerItems.Read()
                                            Dim productName As String = readerItems("ProductName").ToString()
                                            Dim quantity As Integer = Convert.ToInt32(readerItems("Quantity"))
                                            Dim price As Decimal = Convert.ToDecimal(readerItems("Price"))

                                            Dim lblItem As New Label With {
                                            .Text = $"• {productName} x{quantity} @ ₹{price.ToString("N2")}",
                                            .Location = New Point(20, yPos),
                                            .Font = New Font("Arial", 9),
                                            .AutoSize = True
                                        }
                                            orderPanel.Controls.Add(lblItem)
                                            yPos += 20
                                        End While
                                    End Using
                                End Using
                            End Using

                            flpOrderHistory.Controls.Add(orderPanel)
                        End While
                    Else
                        Dim lblNoOrders As New Label With {
                        .Text = "Place your first order",
                        .ForeColor = Color.Blue,
                        .Font = New Font("Arial", 12, FontStyle.Bold),
                        .Location = New Point(10, 10),
                        .AutoSize = True
                    }
                        AddHandler lblNoOrders.Click, Sub()
                                                          MainForm.Show()
                                                          Me.Close()
                                                      End Sub
                        flpOrderHistory.Controls.Add(lblNoOrders)
                    End If
                End Using
            End Using
        End Using
    End Sub



    ' 🛒 Place Order Button (Moves Cart Items to Order Table)
    Private Sub btnPlaceOrder_Click(sender As Object, e As EventArgs) Handles btnPlaceOrder.Click
        Dim payForm As New PaymentForm()
        payForm.ShowDialog()

        ' 🔁 After order placed:
        LoadOrderHistory()
        ShowOrderHistory() ' Switch to the Order History tab
    End Sub


    Private Function GetCurrentQuantity(productID As Integer) As Integer
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "SELECT Quantity FROM Cart WHERE UserID = @UserID AND ProductID = @ProductID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                cmd.Parameters.AddWithValue("@ProductID", productID)

                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    Return Convert.ToInt32(result)
                End If
            End Using
        End Using
        Return 0
    End Function
    Private Sub UpdateCartQuantity(productID As Integer, newQuantity As Integer, lblQuantity As Label)
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

        lblQuantity.Text = newQuantity.ToString()
        RefreshTotalPrice()
    End Sub
    Private Sub RemoveFromCart(productID As Integer)
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "DELETE FROM Cart WHERE UserID = @UserID AND ProductID = @ProductID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                cmd.Parameters.AddWithValue("@ProductID", productID)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        ' Refresh the cart display after removing an item
        LoadCartItems()
    End Sub
    Private Sub RefreshTotalPrice()
        If lblTotalPrice Is Nothing Then Exit Sub ' Prevent null reference error

        Dim totalPrice As Decimal = 0
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "SELECT p.Price, c.Quantity FROM Cart c 
                               INNER JOIN Products p ON c.ProductID = p.ProductID 
                               WHERE c.UserID = @UserID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        totalPrice += Convert.ToDecimal(reader("Price")) * Convert.ToInt32(reader("Quantity"))
                    End While
                End Using
            End Using
        End Using

        lblTotalPrice.Text = "Total Price: ₹" & totalPrice.ToString("N2")
    End Sub


    Private Sub lblHome_Click(sender As Object, e As EventArgs) Handles lblHome.Click
        Me.Close()
        MainForm.Show()
    End Sub

    Private Sub btnOrderHistory_Click(sender As Object, e As EventArgs) Handles btnOrderHistory.Click
        ShowOrderHistory()
        RefreshTotalPrice()
        Debug.WriteLine("Order History button clicked")
    End Sub
    Private Sub btnCart_Click(sender As Object, e As EventArgs) Handles btnCart.Click
        ShowCart()
        RefreshTotalPrice()
    End Sub

    Private Sub lblNoOrders_Click(sender As Object, e As EventArgs) Handles lblNoOrders.Click
        MainForm.Show()
        Me.Close()
    End Sub
End Class
