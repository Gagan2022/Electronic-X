<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        txtEmail = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        btnLogin = New Button()
        btnClose = New Button()
        lblRegister = New Label()
        Label3 = New Label()
        txtPassword = New MaskedTextBox()
        SuspendLayout()
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(593, 177)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(150, 31)
        txtEmail.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.White
        Label1.Location = New Point(402, 183)
        Label1.Name = "Label1"
        Label1.Size = New Size(54, 25)
        Label1.TabIndex = 2
        Label1.Text = "Email"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.White
        Label2.Location = New Point(402, 239)
        Label2.Name = "Label2"
        Label2.Size = New Size(87, 25)
        Label2.TabIndex = 3
        Label2.Text = "Password"
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(402, 311)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(112, 43)
        btnLogin.TabIndex = 4
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(593, 311)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(112, 43)
        btnClose.TabIndex = 5
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' lblRegister
        ' 
        lblRegister.AutoSize = True
        lblRegister.BackColor = Color.Transparent
        lblRegister.Font = New Font("Segoe UI", 9F, FontStyle.Italic Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        lblRegister.Location = New Point(701, 23)
        lblRegister.Name = "lblRegister"
        lblRegister.Size = New Size(71, 25)
        lblRegister.TabIndex = 6
        lblRegister.Text = "Sign up"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Algerian", 20F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(487, 82)
        Label3.Name = "Label3"
        Label3.Size = New Size(135, 45)
        Label3.TabIndex = 7
        Label3.Text = "Login"
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(593, 233)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(150, 31)
        txtPassword.TabIndex = 8
        ' 
        ' login
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(800, 450)
        Controls.Add(txtPassword)
        Controls.Add(Label3)
        Controls.Add(lblRegister)
        Controls.Add(btnClose)
        Controls.Add(btnLogin)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtEmail)
        DoubleBuffered = True
        Name = "login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents lblRegister As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPassword As MaskedTextBox
End Class
