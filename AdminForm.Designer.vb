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
        Label1 = New Label()
        pnlctrl.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblAdd
        ' 
        lblAdd.AutoSize = True
        lblAdd.BorderStyle = BorderStyle.Fixed3D
        lblAdd.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Italic)
        lblAdd.Location = New Point(472, 142)
        lblAdd.Name = "lblAdd"
        lblAdd.Size = New Size(132, 27)
        lblAdd.TabIndex = 0
        lblAdd.Text = "Add Products"
        ' 
        ' lblUpdDelete
        ' 
        lblUpdDelete.AutoSize = True
        lblUpdDelete.BorderStyle = BorderStyle.Fixed3D
        lblUpdDelete.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Italic)
        lblUpdDelete.Location = New Point(472, 255)
        lblUpdDelete.Name = "lblUpdDelete"
        lblUpdDelete.Size = New Size(221, 27)
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
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Algerian", 16F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(54, 188)
        Label1.Name = "Label1"
        Label1.Size = New Size(285, 35)
        Label1.TabIndex = 3
        Label1.Text = "Admin Controls"
        ' 
        ' AdminForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label1)
        Controls.Add(pnlctrl)
        Controls.Add(lblUpdDelete)
        Controls.Add(lblAdd)
        Name = "AdminForm"
        StartPosition = FormStartPosition.CenterScreen
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
    Friend WithEvents Label1 As Label
End Class
