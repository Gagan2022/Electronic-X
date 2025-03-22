Public Class AdminForm
    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub lblAdd_Click(sender As Object, e As EventArgs) Handles lblAdd.Click
        AddProduct.Show()
        Me.Hide()

    End Sub
    Private Sub lblUpdDelete_Click(sender As Object, e As EventArgs) Handles lblUpdDelete.Click
        UpdDeleteForm.Show()
        Me.Hide()
    End Sub
    Private Sub lblHome_Click(sender As Object, e As EventArgs) Handles lblHome.Click
        Me.Close()
        MainForm.Show()
    End Sub

End Class