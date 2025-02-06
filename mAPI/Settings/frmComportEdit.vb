Imports System.Data.SQLite
Public Class frmComportEdit

    Public ID As String

    Private Sub frmComportEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetComPorts(ComPortsBox)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        UpdateMachine()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub UpdateMachine()
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()

            Dim query As String = $"UPDATE `comport` SET 
                                    `port_name` = @port_name, 
                                    `baud_rate` = @baud_rate, 
                                    `stop_bits` = @stop_bits, 
                                    `data_bits` = @data_bits, 
                                    `flow_control` = @flow_control, 
                                    `instrument` = @instrument, 
                                    `serial_no` = @serial_no, 
                                    `section` = @section, 
                                    `location` = @location,
                                    `bi_directional` = @BiDirectional
                                WHERE `id` = @id"

            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@id", ID)
                command.Parameters.AddWithValue("@port_name", ComPortsBox.Text)
                command.Parameters.AddWithValue("@baud_rate", cboBaudrate.Text)
                command.Parameters.AddWithValue("@stop_bits", cboStopBits.Text)
                command.Parameters.AddWithValue("@data_bits", cboDataBits.Text)
                command.Parameters.AddWithValue("@flow_control", cboFlowControl.Text)
                command.Parameters.AddWithValue("@instrument", txtMachine.Text)
                command.Parameters.AddWithValue("@serial_no", txtSerial.Text)
                command.Parameters.AddWithValue("@section", txtSection.Text)
                command.Parameters.AddWithValue("@location", txtLocation.Text)
                command.Parameters.AddWithValue("@BiDirectional", chkDirection.Checked.ToString)
                'command.Parameters.AddWithValue("@protocol", txtSerial.Text)
                'command.Parameters.AddWithValue("@config_path", txtSerial.Text)
                'command.Parameters.AddWithValue("@log_path", txtSerial.Text)
                command.ExecuteNonQuery()
            End Using
        End Using

        MainForm.LoadSerialPortsFromDatabase()
    End Sub
End Class