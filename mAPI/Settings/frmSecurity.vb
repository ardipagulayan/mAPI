﻿Public Class frmSecurity
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtUsername.Text = "technician" And txtPassword.Text = "lis@sbsi.wisdom!2018" Then
            If MainForm._type = "Delete" Then
                MainForm.DeleteSerialPort()
            ElseIf MainForm._type = "Edit" Then
                MainForm.EditSerialPort()
            End If

            Me.Close()
            Me.Dispose()
        Else
            MessageBox.Show("Invalid Username or Password", "Error Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class