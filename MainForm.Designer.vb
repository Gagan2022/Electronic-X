<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        components = New ComponentModel.Container()
        pnlMenu = New Panel()
        lblLogOut = New Label()
        lblMyOrders = New Label()
        lblProfile = New Label()
        lbluser = New Label()
        lblTime = New Label()
        Timer1 = New Timer(components)
        flpProducts = New FlowLayoutPanel()
        pnlMenu.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlMenu
        ' 
        pnlMenu.Controls.Add(lblLogOut)
        pnlMenu.Controls.Add(lblMyOrders)
        pnlMenu.Controls.Add(lblProfile)
        pnlMenu.Controls.Add(lbluser)
        pnlMenu.Dock = DockStyle.Top
        pnlMenu.Location = New Point(0, 0)
        pnlMenu.Name = "pnlMenu"
        pnlMenu.Size = New Size(1024, 60)
        pnlMenu.TabIndex = 0
        ' 
        ' lblLogOut
        ' 
        lblLogOut.AutoSize = True
        lblLogOut.Location = New Point(920, 18)
        lblLogOut.Name = "lblLogOut"
        lblLogOut.Size = New Size(72, 25)
        lblLogOut.TabIndex = 4
        lblLogOut.Text = "LogOut"
        ' 
        ' lblMyOrders
        ' 
        lblMyOrders.AutoSize = True
        lblMyOrders.Location = New Point(813, 18)
        lblMyOrders.Name = "lblMyOrders"
        lblMyOrders.Size = New Size(91, 25)
        lblMyOrders.TabIndex = 6
        lblMyOrders.Text = "MyOrders"
        ' 
        ' lblProfile
        ' 
        lblProfile.AutoSize = True
        lblProfile.Location = New Point(735, 18)
        lblProfile.Name = "lblProfile"
        lblProfile.Size = New Size(62, 25)
        lblProfile.TabIndex = 7
        lblProfile.Text = "Profile"
        ' 
        ' lbluser
        ' 
        lbluser.AutoSize = True
        lbluser.Location = New Point(12, 18)
        lbluser.Name = "lbluser"
        lbluser.Size = New Size(89, 25)
        lbluser.TabIndex = 0
        lbluser.Text = "username"
        ' 
        ' lblTime
        ' 
        lblTime.AutoSize = True
        lblTime.Location = New Point(12, 457)
        lblTime.Name = "lblTime"
        lblTime.Size = New Size(50, 25)
        lblTime.TabIndex = 1
        lblTime.Text = "Time"
        ' 
        ' Timer1
        ' 
        ' 
        ' flpProducts
        ' 
        flpProducts.AutoScroll = True
        flpProducts.Location = New Point(12, 80)
        flpProducts.Name = "flpProducts"
        flpProducts.Size = New Size(1000, 374)
        flpProducts.TabIndex = 2
        ' 
        ' MainForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1024, 491)
        Controls.Add(flpProducts)
        Controls.Add(lblTime)
        Controls.Add(pnlMenu)
        Name = "MainForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "MainForm"
        pnlMenu.ResumeLayout(False)
        pnlMenu.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pnlMenu As Panel
    Friend WithEvents lbluser As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblLogOut As Label
    Friend WithEvents lblMyOrders As Label
    Friend WithEvents lblProfile As Label
    Friend WithEvents flpProducts As FlowLayoutPanel
End Class
