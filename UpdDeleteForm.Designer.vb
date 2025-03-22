<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UpdDeleteForm
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        dgvProducts = New DataGridView()
        ProductID = New DataGridViewTextBoxColumn()
        colProductName = New DataGridViewTextBoxColumn() ' Renamed from ProductName
        Price = New DataGridViewTextBoxColumn()
        Stock = New DataGridViewTextBoxColumn()
        txtProductName = New TextBox()
        txtProductID = New TextBox()
        txtStock = New TextBox()
        txtPrice = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        btnUpdateProduct = New Button()
        btnDeleteProduct = New Button()
        lblBack = New Label()
        CType(dgvProducts, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()

        ' dgvProducts
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvProducts.Columns.AddRange(New DataGridViewColumn() {ProductID, colProductName, Price, Stock}) ' Updated column name
        dgvProducts.Location = New Point(42, 40)
        dgvProducts.Name = "dgvProducts"
        dgvProducts.RowHeadersWidth = 62
        dgvProducts.Size = New Size(940, 225)
        dgvProducts.TabIndex = 0

        ' ProductID
        ProductID.HeaderText = "Product ID"
        ProductID.MinimumWidth = 8
        ProductID.Name = "ProductID"
        ProductID.Width = 150

        ' colProductName (Renamed to avoid conflict)
        colProductName.HeaderText = "Product Name"
        colProductName.MinimumWidth = 8
        colProductName.Name = "colProductName"
        colProductName.Width = 150

        ' Price
        Price.HeaderText = "Price"
        Price.MinimumWidth = 8
        Price.Name = "Price"
        Price.Width = 150

        ' Stock
        Stock.HeaderText = "Stock"
        Stock.MinimumWidth = 8
        Stock.Name = "Stock"
        Stock.Width = 150

        ' txtProductName
        txtProductName.Location = New Point(411, 322)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(150, 31)
        txtProductName.TabIndex = 1

        ' txtProductID
        txtProductID.Location = New Point(411, 285)
        txtProductID.Name = "txtProductID"
        txtProductID.ReadOnly = True
        txtProductID.Size = New Size(150, 31)
        txtProductID.TabIndex = 2

        ' txtStock
        txtStock.Location = New Point(411, 415)
        txtStock.Name = "txtStock"
        txtStock.Size = New Size(150, 31)
        txtStock.TabIndex = 3

        ' txtPrice
        txtPrice.Location = New Point(411, 369)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(150, 31)
        txtPrice.TabIndex = 4

        ' Label1
        Label1.AutoSize = True
        Label1.Location = New Point(233, 285)
        Label1.Name = "Label1"
        Label1.Size = New Size(97, 25)
        Label1.TabIndex = 5
        Label1.Text = "Product ID"

        ' Label2
        Label2.AutoSize = True
        Label2.Location = New Point(233, 322)
        Label2.Name = "Label2"
        Label2.Size = New Size(126, 25)
        Label2.TabIndex = 6
        Label2.Text = "Product Name"

        ' Label3
        Label3.AutoSize = True
        Label3.Location = New Point(233, 369)
        Label3.Name = "Label3"
        Label3.Size = New Size(49, 25)
        Label3.TabIndex = 7
        Label3.Text = "Price"

        ' Label4
        Label4.AutoSize = True
        Label4.Location = New Point(233, 421)
        Label4.Name = "Label4"
        Label4.Size = New Size(55, 25)
        Label4.TabIndex = 8
        Label4.Text = "Stock"

        ' btnUpdateProduct
        btnUpdateProduct.Location = New Point(218, 465)
        btnUpdateProduct.Name = "btnUpdateProduct"
        btnUpdateProduct.Size = New Size(112, 34)
        btnUpdateProduct.TabIndex = 9
        btnUpdateProduct.Text = "Update"
        btnUpdateProduct.UseVisualStyleBackColor = True

        ' btnDeleteProduct
        btnDeleteProduct.Location = New Point(554, 465)
        btnDeleteProduct.Name = "btnDeleteProduct"
        btnDeleteProduct.Size = New Size(112, 34)
        btnDeleteProduct.TabIndex = 10
        btnDeleteProduct.Text = "Delete"
        btnDeleteProduct.UseVisualStyleBackColor = True

        ' lblBack
        lblBack.AutoSize = True
        lblBack.Location = New Point(12, 9)
        lblBack.Name = "lblBack"
        lblBack.Size = New Size(38, 25)
        lblBack.TabIndex = 11
        lblBack.Text = "<--"

        ' UpdDeleteForm
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1007, 522)
        Controls.Add(lblBack)
        Controls.Add(btnDeleteProduct)
        Controls.Add(btnUpdateProduct)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtPrice)
        Controls.Add(txtStock)
        Controls.Add(txtProductID)
        Controls.Add(txtProductName)
        Controls.Add(dgvProducts)
        Name = "UpdDeleteForm"
        Text = "UpdDeleteForm"
        CType(dgvProducts, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents txtProductID As TextBox
    Friend WithEvents txtStock As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnUpdateProduct As Button
    Friend WithEvents btnDeleteProduct As Button
    Friend WithEvents ProductID As DataGridViewTextBoxColumn
    Friend WithEvents colProductName As DataGridViewTextBoxColumn ' Renamed to avoid conflict
    Friend WithEvents Price As DataGridViewTextBoxColumn
    Friend WithEvents Stock As DataGridViewTextBoxColumn
    Friend WithEvents lblBack As Label
End Class
