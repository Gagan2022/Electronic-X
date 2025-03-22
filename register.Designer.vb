<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class register
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblName = New Label()
        lblEmail = New Label()
        lblPassword = New Label()
        txtName = New TextBox()
        txtEmail = New TextBox()
        btnRegister = New Button()
        txtPassword = New TextBox()
        btnClose = New Button()
        lblRegister = New Label()
        pnlHeader.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlHeader
        ' 
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Location = New Point(0, 0)
        pnlHeader.Name = "pnlHeader"
        pnlHeader.Size = New Size(800, 96)
        pnlHeader.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(345, 33)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(146, 25)
        lblTitle.TabIndex = 3
        lblTitle.Text = "User Registration"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(183, 129)
        lblName.Name = "lblName"
        lblName.Size = New Size(59, 25)
        lblName.TabIndex = 0
        lblName.Text = "Name"
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.Location = New Point(183, 174)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(124, 25)
        lblEmail.TabIndex = 1
        lblEmail.Text = "Email Address"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Location = New Point(183, 230)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(87, 25)
        lblPassword.TabIndex = 2
        lblPassword.Text = "Password"
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(345, 123)
        txtName.Name = "txtName"
        txtName.Size = New Size(150, 31)
        txtName.TabIndex = 4
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(345, 171)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(150, 31)
        txtEmail.TabIndex = 5
        ' 
        ' btnRegister
        ' 
        btnRegister.Location = New Point(256, 322)
        btnRegister.Name = "btnRegister"
        btnRegister.Size = New Size(112, 43)
        btnRegister.TabIndex = 6
        btnRegister.Text = "Register"
        btnRegister.UseVisualStyleBackColor = True
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(345, 227)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(150, 31)
        txtPassword.TabIndex = 7
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(453, 322)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(112, 43)
        btnClose.TabIndex = 8
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' lblRegister
        ' 
        lblRegister.AutoSize = True
        lblRegister.Location = New Point(280, 368)
        lblRegister.Name = "lblRegister"
        lblRegister.Size = New Size(56, 25)
        lblRegister.TabIndex = 9
        lblRegister.Text = "Login"
        ' 
        ' register
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lblRegister)
        Controls.Add(btnClose)
        Controls.Add(txtPassword)
        Controls.Add(lblName)
        Controls.Add(lblEmail)
        Controls.Add(lblPassword)
        Controls.Add(txtName)
        Controls.Add(txtEmail)
        Controls.Add(btnRegister)
        Controls.Add(pnlHeader)
        Name = "register"
        Text = "Form1"
        pnlHeader.ResumeLayout(False)
        pnlHeader.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblName As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnRegister As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents lblRegister As Label

End Class
