<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfileForm
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
        txtFirstName = New TextBox()
        txtLastName = New TextBox()
        txtAddress = New TextBox()
        cmbGender = New ComboBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        btnSave = New Button()
        lblEditAddress = New Label()
        Panel1 = New Panel()
        lblHome = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Location = New Point(374, 100)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(150, 31)
        txtFirstName.TabIndex = 0
        ' 
        ' txtLastName
        ' 
        txtLastName.Location = New Point(374, 155)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(150, 31)
        txtLastName.TabIndex = 1
        ' 
        ' txtAddress
        ' 
        txtAddress.Location = New Point(374, 211)
        txtAddress.Name = "txtAddress"
        txtAddress.Size = New Size(150, 31)
        txtAddress.TabIndex = 2
        ' 
        ' cmbGender
        ' 
        cmbGender.FormattingEnabled = True
        cmbGender.Items.AddRange(New Object() {"Male", "Female", "Mentally ill"})
        cmbGender.Location = New Point(374, 291)
        cmbGender.Name = "cmbGender"
        cmbGender.Size = New Size(182, 33)
        cmbGender.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(183, 106)
        Label1.Name = "Label1"
        Label1.Size = New Size(97, 25)
        Label1.TabIndex = 4
        Label1.Text = "First Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(183, 161)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 25)
        Label2.TabIndex = 5
        Label2.Text = "Last Name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(183, 217)
        Label3.Name = "Label3"
        Label3.Size = New Size(77, 25)
        Label3.TabIndex = 6
        Label3.Text = "Address"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(183, 291)
        Label4.Name = "Label4"
        Label4.Size = New Size(69, 25)
        Label4.TabIndex = 7
        Label4.Text = "Gender"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(353, 360)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(112, 34)
        btnSave.TabIndex = 8
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' lblEditAddress
        ' 
        lblEditAddress.AutoSize = True
        lblEditAddress.Location = New Point(374, 245)
        lblEditAddress.Name = "lblEditAddress"
        lblEditAddress.Size = New Size(112, 25)
        lblEditAddress.TabIndex = 9
        lblEditAddress.Text = "Edit Address"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(lblHome)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(788, 63)
        Panel1.TabIndex = 10
        ' 
        ' lblHome
        ' 
        lblHome.AutoSize = True
        lblHome.Location = New Point(710, 22)
        lblHome.Name = "lblHome"
        lblHome.Size = New Size(61, 25)
        lblHome.TabIndex = 0
        lblHome.Text = "Home"
        ' 
        ' ProfileForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Panel1)
        Controls.Add(lblEditAddress)
        Controls.Add(btnSave)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(cmbGender)
        Controls.Add(txtAddress)
        Controls.Add(txtLastName)
        Controls.Add(txtFirstName)
        Name = "ProfileForm"
        Text = "ProfileForm"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents cmbGender As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents lblEditAddress As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblHome As Label
End Class
