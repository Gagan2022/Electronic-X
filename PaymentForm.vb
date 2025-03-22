Public Class PaymentForm
    Private Sub PaymentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        OrderForm.Show()
        Me.Close()
    End Sub
End Class