Public Class frmData

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        With My.Settings
            .ResultPath = txtResult.Text
            .OrderPath = txtOrder.Text
            .LocalDB = txtLocal.Text
            .Save()
            .Reload()
        End With

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmData_Load(sender As Object, e As EventArgs) Handles Me.Load
        With My.Settings
            txtResult.Text = .ResultPath
            txtOrder.Text = .OrderPath
            txtLocal.Text = .LocalDB
        End With
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class