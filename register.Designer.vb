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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(register))
        lblName = New Label()
        lblEmail = New Label()
        lblPassword = New Label()
        txtName = New TextBox()
        txtEmail = New TextBox()
        btnRegister = New Button()
        txtPassword = New TextBox()
        btnClose = New Button()
        lblRegister = New Label()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.BackColor = Color.Transparent
        lblName.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblName.ForeColor = Color.White
        lblName.Location = New Point(216, 156)
        lblName.Name = "lblName"
        lblName.Size = New Size(68, 28)
        lblName.TabIndex = 0
        lblName.Text = "Name"
        ' 
        ' lblEmail
        ' 
        lblEmail.AutoSize = True
        lblEmail.BackColor = Color.Transparent
        lblEmail.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblEmail.ForeColor = Color.White
        lblEmail.Location = New Point(216, 215)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(145, 28)
        lblEmail.TabIndex = 1
        lblEmail.Text = "Email Address"
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.BackColor = Color.Transparent
        lblPassword.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPassword.ForeColor = Color.White
        lblPassword.Location = New Point(216, 271)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(101, 28)
        lblPassword.TabIndex = 2
        lblPassword.Text = "Password"
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(437, 156)
        txtName.Name = "txtName"
        txtName.Size = New Size(150, 31)
        txtName.TabIndex = 4
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(437, 212)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(150, 31)
        txtEmail.TabIndex = 5
        ' 
        ' btnRegister
        ' 
        btnRegister.Location = New Point(216, 340)
        btnRegister.Name = "btnRegister"
        btnRegister.Size = New Size(112, 43)
        btnRegister.TabIndex = 6
        btnRegister.Text = "Register"
        btnRegister.UseVisualStyleBackColor = True
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(437, 268)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(150, 31)
        txtPassword.TabIndex = 7
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(511, 340)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(112, 43)
        btnClose.TabIndex = 8
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' lblRegister
        ' 
        lblRegister.BackColor = Color.Black
        lblRegister.Font = New Font("Segoe UI", 10F, FontStyle.Italic Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        lblRegister.ForeColor = Color.White
        lblRegister.Location = New Point(760, 25)
        lblRegister.Name = "lblRegister"
        lblRegister.Size = New Size(67, 36)
        lblRegister.TabIndex = 9
        lblRegister.Text = "Login"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Algerian", 22F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(199, 66)
        Label1.Name = "Label1"
        Label1.Size = New Size(455, 49)
        Label1.TabIndex = 10
        Label1.Text = "User Registration"
        ' 
        ' register
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(831, 446)
        Controls.Add(Label1)
        Controls.Add(lblRegister)
        Controls.Add(btnClose)
        Controls.Add(txtPassword)
        Controls.Add(lblName)
        Controls.Add(lblEmail)
        Controls.Add(lblPassword)
        Controls.Add(txtName)
        Controls.Add(txtEmail)
        Controls.Add(btnRegister)
        DoubleBuffered = True
        Name = "register"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents lblName As Label
    Friend WithEvents lblPassword As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnRegister As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnClose As Button
    Friend WithEvents lblRegister As Label
    Friend WithEvents Label1 As Label

End Class
