<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentForm
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
        btnBack = New Label()
        SuspendLayout()
        ' 
        ' btnBack
        ' 
        btnBack.AutoSize = True
        btnBack.Location = New Point(12, 9)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(38, 25)
        btnBack.TabIndex = 0
        btnBack.Text = "<--"
        ' 
        ' PaymentForm
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(btnBack)
        Name = "PaymentForm"
        Text = "PaymentForm"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnBack As Label
End Class
