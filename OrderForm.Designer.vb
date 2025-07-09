<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub




    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        lblHome = New Label()
        btnCart = New Button()
        btnOrderHistory = New Button()
        Panel2 = New Panel()
        pnlCart = New Panel()
        btnPlaceOrder = New Button()
        lblTotalPrice = New Label()
        flpCart = New FlowLayoutPanel()
        pnlOrderHistory = New Panel()
        flpOrderHistory = New FlowLayoutPanel()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        pnlCart.SuspendLayout()
        pnlOrderHistory.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblHome)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(613, 48)
        Panel1.TabIndex = 0
        ' 
        ' lblHome
        ' 
        lblHome.AutoSize = True
        lblHome.Location = New Point(537, 9)
        lblHome.Name = "lblHome"
        lblHome.Size = New Size(61, 25)
        lblHome.TabIndex = 0
        lblHome.Text = "Home"
        ' 
        ' btnCart
        ' 
        btnCart.Location = New Point(12, 15)
        btnCart.Name = "btnCart"
        btnCart.Size = New Size(112, 34)
        btnCart.TabIndex = 1
        btnCart.Text = "Cart"
        btnCart.UseVisualStyleBackColor = True
        ' 
        ' btnOrderHistory
        ' 
        btnOrderHistory.Location = New Point(12, 66)
        btnOrderHistory.Name = "btnOrderHistory"
        btnOrderHistory.Size = New Size(112, 34)
        btnOrderHistory.TabIndex = 2
        btnOrderHistory.Text = "Orders"
        btnOrderHistory.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(btnCart)
        Panel2.Controls.Add(btnOrderHistory)
        Panel2.Location = New Point(479, 57)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(136, 396)
        Panel2.TabIndex = 3
        ' 
        ' pnlCart
        ' 
        pnlCart.Controls.Add(btnPlaceOrder)
        pnlCart.Controls.Add(lblTotalPrice)
        pnlCart.Controls.Add(flpCart)
        pnlCart.Location = New Point(10, 60)
        pnlCart.Name = "pnlCart"
        pnlCart.Size = New Size(450, 400)
        pnlCart.TabIndex = 4
        ' 
        ' btnPlaceOrder
        ' 
        btnPlaceOrder.Location = New Point(300, 320)
        btnPlaceOrder.Name = "btnPlaceOrder"
        btnPlaceOrder.Size = New Size(120, 40)
        btnPlaceOrder.TabIndex = 1
        btnPlaceOrder.Text = "Place Order"
        btnPlaceOrder.UseVisualStyleBackColor = True
        ' 
        ' lblTotalPrice
        ' 
        lblTotalPrice.Location = New Point(10, 320)
        lblTotalPrice.Name = "lblTotalPrice"
        lblTotalPrice.Size = New Size(200, 30)
        lblTotalPrice.TabIndex = 0
        lblTotalPrice.Text = """Total Price: ₹0.00"""
        ' 
        ' flpCart
        ' 
        flpCart.AutoScroll = True
        flpCart.Location = New Point(10, 10)
        flpCart.Name = "flpCart"
        flpCart.Size = New Size(430, 300)
        flpCart.TabIndex = 0
        ' 
        ' pnlOrderHistory
        ' 
        pnlOrderHistory.Controls.Add(flpOrderHistory)
        pnlOrderHistory.Location = New Point(10, 60)
        pnlOrderHistory.Name = "pnlOrderHistory"
        pnlOrderHistory.Size = New Size(450, 400)
        pnlOrderHistory.TabIndex = 2
        pnlOrderHistory.Visible = False
        ' 
        ' flpOrderHistory
        ' 
        flpOrderHistory.AutoScroll = True
        flpOrderHistory.Location = New Point(10, 10)
        flpOrderHistory.Name = "flpOrderHistory"
        flpOrderHistory.Size = New Size(427, 365)
        flpOrderHistory.TabIndex = 0
        ' 
        ' OrderForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(627, 465)
        Controls.Add(pnlOrderHistory)
        Controls.Add(pnlCart)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "OrderForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "OrderForm"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        pnlCart.ResumeLayout(False)
        pnlOrderHistory.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnCart As Button
    Friend WithEvents lblHome As Label
    Friend WithEvents btnOrderHistory As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlCart As Panel
    Friend WithEvents lblTotalPrice As Label
    Friend WithEvents flpCart As FlowLayoutPanel
    Friend WithEvents btnPlaceOrder As Button
    Friend WithEvents pnlOrderHistory As Panel
    Friend WithEvents lblNoOrders As Label
    Friend WithEvents flpOrderHistory As FlowLayoutPanel
End Class
