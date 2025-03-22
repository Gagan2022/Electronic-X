<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddProduct
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        PictureBox1 = New PictureBox()
        txtProductName = New TextBox()
        txtPrice = New TextBox()
        txtDescription = New TextBox()
        txtStock = New TextBox()
        txtCategory = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        btnSave = New Button()
        lblBack = New Label()
        btnBrowse = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.Location = New Point(374, 334)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(150, 75)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' txtProductName
        ' 
        txtProductName.Location = New Point(374, 44)
        txtProductName.Name = "txtProductName"
        txtProductName.Size = New Size(150, 31)
        txtProductName.TabIndex = 1
        ' 
        ' txtPrice
        ' 
        txtPrice.Location = New Point(374, 105)
        txtPrice.Name = "txtPrice"
        txtPrice.Size = New Size(150, 31)
        txtPrice.TabIndex = 2
        ' 
        ' txtDescription
        ' 
        txtDescription.Location = New Point(374, 154)
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(150, 31)
        txtDescription.TabIndex = 3
        ' 
        ' txtStock
        ' 
        txtStock.Location = New Point(374, 220)
        txtStock.Name = "txtStock"
        txtStock.Size = New Size(150, 31)
        txtStock.TabIndex = 4
        ' 
        ' txtCategory
        ' 
        txtCategory.Location = New Point(374, 269)
        txtCategory.Name = "txtCategory"
        txtCategory.Size = New Size(150, 31)
        txtCategory.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(215, 50)
        Label1.Name = "Label1"
        Label1.Size = New Size(126, 25)
        Label1.TabIndex = 6
        Label1.Text = "Product Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(215, 105)
        Label2.Name = "Label2"
        Label2.Size = New Size(49, 25)
        Label2.TabIndex = 7
        Label2.Text = "Price"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(215, 160)
        Label3.Name = "Label3"
        Label3.Size = New Size(102, 25)
        Label3.TabIndex = 8
        Label3.Text = "Description"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(215, 220)
        Label4.Name = "Label4"
        Label4.Size = New Size(55, 25)
        Label4.TabIndex = 9
        Label4.Text = "Stock"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(215, 269)
        Label5.Name = "Label5"
        Label5.Size = New Size(84, 25)
        Label5.TabIndex = 10
        Label5.Text = "Category"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(215, 320)
        Label6.Name = "Label6"
        Label6.Size = New Size(62, 25)
        Label6.TabIndex = 11
        Label6.Text = "Image"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(374, 443)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(112, 34)
        btnSave.TabIndex = 12
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' lblBack
        ' 
        lblBack.AutoSize = True
        lblBack.Location = New Point(12, 9)
        lblBack.Name = "lblBack"
        lblBack.Size = New Size(38, 25)
        lblBack.TabIndex = 13
        lblBack.Text = "<--"
        ' 
        ' btnBrowse
        ' 
        btnBrowse.Location = New Point(554, 351)
        btnBrowse.Name = "btnBrowse"
        btnBrowse.Size = New Size(112, 34)
        btnBrowse.TabIndex = 14
        btnBrowse.Text = "Browse"
        btnBrowse.UseVisualStyleBackColor = True
        ' 
        ' AddProduct
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(872, 503)
        Controls.Add(btnBrowse)
        Controls.Add(lblBack)
        Controls.Add(btnSave)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtCategory)
        Controls.Add(txtStock)
        Controls.Add(txtDescription)
        Controls.Add(txtPrice)
        Controls.Add(txtProductName)
        Controls.Add(PictureBox1)
        Name = "AddProduct"
        Text = "AddProduct"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtProductName As TextBox
    Friend WithEvents txtPrice As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtStock As TextBox
    Friend WithEvents txtCategory As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents lblBack As Label
    Friend WithEvents btnBrowse As Button
End Class
