<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminForm
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
        lblAdd = New Label()
        lblUpdDelete = New Label()
        pnlctrl = New Panel()
        lblHome = New Label()
        pnlctrl.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblAdd
        ' 
        lblAdd.AutoSize = True
        lblAdd.Location = New Point(360, 105)
        lblAdd.Name = "lblAdd"
        lblAdd.Size = New Size(121, 25)
        lblAdd.TabIndex = 0
        lblAdd.Text = "Add Products"
        ' 
        ' lblUpdDelete
        ' 
        lblUpdDelete.AutoSize = True
        lblUpdDelete.Location = New Point(360, 177)
        lblUpdDelete.Name = "lblUpdDelete"
        lblUpdDelete.Size = New Size(202, 25)
        lblUpdDelete.TabIndex = 1
        lblUpdDelete.Text = "Update/Delete Products"
        ' 
        ' pnlctrl
        ' 
        pnlctrl.Controls.Add(lblHome)
        pnlctrl.Location = New Point(12, 0)
        pnlctrl.Name = "pnlctrl"
        pnlctrl.Size = New Size(776, 50)
        pnlctrl.TabIndex = 2
        ' 
        ' lblHome
        ' 
        lblHome.AutoSize = True
        lblHome.Location = New Point(694, 9)
        lblHome.Name = "lblHome"
        lblHome.Size = New Size(61, 25)
        lblHome.TabIndex = 0
        lblHome.Text = "Home"
        ' 
        ' AdminForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(pnlctrl)
        Controls.Add(lblUpdDelete)
        Controls.Add(lblAdd)
        Name = "AdminForm"
        Text = "AdminForm"
        pnlctrl.ResumeLayout(False)
        pnlctrl.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblAdd As Label
    Friend WithEvents lblUpdDelete As Label
    Friend WithEvents pnlctrl As Panel
    Friend WithEvents lblHome As Label
End Class
