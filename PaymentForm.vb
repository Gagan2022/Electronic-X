Imports Microsoft.Data.SqlClient

Public Class PaymentForm
    Private connectionString As String = "Server=GAGAN\SQLEXPRESS;Database=seproject;Integrated Security=True;TrustServerCertificate=True;"

    Private rdoCOD As RadioButton
    Private rdoCard As RadioButton
    Private txtCardNumber As TextBox
    Private txtCVV As TextBox
    Private dtpExpiry As DateTimePicker
    Private lblCardNumber As Label
    Private lblCVV As Label
    Private lblExpiry As Label

    Private Sub PaymentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Payment Options"
        Me.Size = New Size(400, 350)

        Dim lblTitle As New Label() With {.Text = "Choose Payment Method", .Font = New Font("Arial", 14, FontStyle.Bold), .Location = New Point(80, 20), .AutoSize = True}
        rdoCOD = New RadioButton() With {.Text = "Cash on Delivery", .Location = New Point(80, 70), .Checked = True}
        rdoCard = New RadioButton() With {.Text = "Card Payment", .Location = New Point(80, 100)}

        lblCardNumber = New Label() With {.Text = "Card Number:", .Location = New Point(80, 140), .AutoSize = True, .Visible = False}
        txtCardNumber = New TextBox() With {.Location = New Point(180, 140), .Width = 150, .Visible = False}

        lblCVV = New Label() With {.Text = "CVV:", .Location = New Point(80, 170), .AutoSize = True, .Visible = False}
        txtCVV = New TextBox() With {.Location = New Point(180, 170), .Width = 50, .Visible = False, .MaxLength = 3}

        lblExpiry = New Label() With {.Text = "Expiry Date:", .Location = New Point(80, 200), .AutoSize = True, .Visible = False}
        dtpExpiry = New DateTimePicker() With {.Location = New Point(180, 200), .Format = DateTimePickerFormat.Short, .Visible = False}

        Dim btnConfirm As New Button() With {.Text = "Confirm Order", .Size = New Size(120, 35), .Location = New Point(120, 250)}

        AddHandler rdoCOD.CheckedChanged, AddressOf TogglePaymentFields
        AddHandler rdoCard.CheckedChanged, AddressOf TogglePaymentFields
        AddHandler btnConfirm.Click, Sub() ConfirmOrder(rdoCOD.Checked)

        Me.Controls.Add(lblTitle)
        Me.Controls.Add(rdoCOD)
        Me.Controls.Add(rdoCard)
        Me.Controls.Add(lblCardNumber)
        Me.Controls.Add(txtCardNumber)
        Me.Controls.Add(lblCVV)
        Me.Controls.Add(txtCVV)
        Me.Controls.Add(lblExpiry)
        Me.Controls.Add(dtpExpiry)
        Me.Controls.Add(btnConfirm)
    End Sub

    Private Sub TogglePaymentFields(sender As Object, e As EventArgs)
        Dim showFields = rdoCard.Checked
        lblCardNumber.Visible = showFields
        txtCardNumber.Visible = showFields
        lblCVV.Visible = showFields
        txtCVV.Visible = showFields
        lblExpiry.Visible = showFields
        dtpExpiry.Visible = showFields
    End Sub



    Private Sub ConfirmOrder(isCOD As Boolean)
        ' 1. Check user profile exists
        If Not IsUserProfileComplete() Then
            MessageBox.Show("Please complete your profile before confirming the order.", "Profile Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Dim profileForm As New ProfileForm()
            profileForm.ShowDialog()
            If Not IsUserProfileComplete() Then Exit Sub
        End If

        ' 2. Load Cart Items
        Dim cartItems As New List(Of Tuple(Of Integer, Integer, Decimal)) ' (ProductID, Quantity, Price)
        Dim totalAmount As Decimal = 0

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "SELECT c.ProductID, c.Quantity, p.Price FROM Cart c JOIN Products p ON c.ProductID = p.ProductID WHERE c.UserID = @UserID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim productId = CInt(reader("ProductID"))
                        Dim qty = CInt(reader("Quantity"))
                        Dim price = CDec(reader("Price"))
                        cartItems.Add(Tuple.Create(productId, qty, price))
                        totalAmount += qty * price
                    End While
                End Using
            End Using
        End Using

        If cartItems.Count = 0 Then
            MessageBox.Show("Cart is empty!", "No Items", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If Not isCOD Then
            ' Validate card number (must be 16 digits)
            If Not System.Text.RegularExpressions.Regex.IsMatch(txtCardNumber.Text.Trim(), "^\d{16}$") Then
                MessageBox.Show("Invalid card number. It must be 16 digits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate CVV (3 digits)
            If Not System.Text.RegularExpressions.Regex.IsMatch(txtCVV.Text.Trim(), "^\d{3}$") Then
                MessageBox.Show("Invalid CVV. It must be 3 digits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate expiration date
            If dtpExpiry.Value.Date < DateTime.Today Then
                MessageBox.Show("Card has expired.", "Invalid Expiry Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If


        ' 3. Insert into Orders and OrderItems, update stock
        Dim orderId As Integer = -1

        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim transaction = conn.BeginTransaction()

            Try
                ' Insert into Orders
                Dim orderQuery As String = "INSERT INTO Orders (UserID, OrderDate, TotalAmount, Status) OUTPUT INSERTED.OrderID VALUES (@UserID, GETDATE(), @Total, 'Pending')"
                Using cmd As New SqlCommand(orderQuery, conn, transaction)
                    cmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                    cmd.Parameters.AddWithValue("@Total", totalAmount)
                    orderId = CInt(cmd.ExecuteScalar())
                End Using

                ' Insert into OrderItems and update stock
                For Each item In cartItems
                    Dim productId = item.Item1
                    Dim qty = item.Item2
                    Dim price = item.Item3
                    Dim totalPrice = qty * price

                    ' Insert OrderItem
                    Dim itemQuery As String = "INSERT INTO OrderItems (OrderID, ProductID, Quantity, Price, TotalPrice) VALUES (@OrderID, @ProductID, @Quantity, @Price, @TotalPrice)"
                    Using cmd As New SqlCommand(itemQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@OrderID", orderId)
                        cmd.Parameters.AddWithValue("@ProductID", productId)
                        cmd.Parameters.AddWithValue("@Quantity", qty)
                        cmd.Parameters.AddWithValue("@Price", price)
                        cmd.Parameters.AddWithValue("@TotalPrice", totalPrice)
                        cmd.ExecuteNonQuery()
                    End Using

                    ' Update stock
                    Dim updateStockQuery As String = "UPDATE Products SET Stock = Stock - @Quantity WHERE ProductID = @ProductID"
                    Using cmd As New SqlCommand(updateStockQuery, conn, transaction)
                        cmd.Parameters.AddWithValue("@Quantity", qty)
                        cmd.Parameters.AddWithValue("@ProductID", productId)
                        cmd.ExecuteNonQuery()
                    End Using
                Next

                ' Clear Cart
                Dim clearCartQuery As String = "DELETE FROM Cart WHERE UserID = @UserID"
                Using cmd As New SqlCommand(clearCartQuery, conn, transaction)
                    cmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                    cmd.ExecuteNonQuery()
                End Using

                transaction.Commit()
                MessageBox.Show("Order Confirmed! Your order ID is " & orderId, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error placing order: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Function IsUserProfileComplete() As Boolean
        Using conn As New SqlConnection(connectionString)
            conn.Open()
            Dim query As String = "SELECT COUNT(*) FROM UserProfiles WHERE ID = @UserID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@UserID", login.CurrentUserID)
                Dim count = CInt(cmd.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub
End Class
