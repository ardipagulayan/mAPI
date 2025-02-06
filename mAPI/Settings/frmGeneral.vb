Public Class frmGeneral
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With My.Settings
            .ActivationKey = txtMachine.Text
            .SerialNo = txtSerialNo.Text
            .Save()
            .Reload()
        End With
    End Sub

    Private Sub frmGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With My.Settings
            txtMachine.Text = .ActivationKey
            txtSerialNo.Text = .SerialNo
        End With
    End Sub
End Class