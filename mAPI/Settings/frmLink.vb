Imports System.Data.SQLite
Public Class frmLink

    Private Sub frmLink_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetComPorts(ComPortsBox)

        If RadioGroup.Properties.Items(RadioGroup.SelectedIndex).Tag = "RS232" Then
            gcNetwork.Enabled = False
            gcRS232.Enabled = True
        ElseIf RadioGroup.Properties.Items(RadioGroup.SelectedIndex).Tag = "Network" Then
            gcNetwork.Enabled = True
            gcRS232.Enabled = False
        End If
    End Sub

    Private Sub RadioGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioGroup.SelectedIndexChanged
        If RadioGroup.Properties.Items(RadioGroup.SelectedIndex).Tag = "RS232" Then
            gcNetwork.Enabled = False
            gcRS232.Enabled = True
        ElseIf RadioGroup.Properties.Items(RadioGroup.SelectedIndex).Tag = "Network" Then
            gcNetwork.Enabled = True
            gcRS232.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        AddMachine()

        If RadioGroup.Properties.Items(RadioGroup.SelectedIndex).Tag = "RS232" Then
            MainForm.LoadSerialPortsFromDatabase()
        ElseIf RadioGroup.Properties.Items(RadioGroup.SelectedIndex).Tag = "Network" Then
            MainForm.LoadNetworkFromDatabase()
        End If

        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub AddMachine()
        If RadioGroup.Properties.Items(RadioGroup.SelectedIndex).Tag = "RS232" Then
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Dim query As String = $"INSERT INTO `comport` (`port_name`, `baud_rate`, `stop_bits`, `data_bits`, `flow_control`, `instrument`, `serial_no`, `section`, `location`, `bi_directional`) VALUES
                                    (@port_name, @baud_rate, @stop_bits, @data_bits, @flow_control, @instrument, @serial_no, @section, @location, @BiDirectional)"

                Using command As New SQLiteCommand(query, connection)

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
                    'command.Parameters.AddWithValue("@config_path", txtSerial.Text)
                    'command.Parameters.AddWithValue("@log_path", txtSerial.Text)

                    command.ExecuteNonQuery()
                End Using
            End Using
        ElseIf RadioGroup.Properties.Items(RadioGroup.SelectedIndex).Tag = "Network" Then
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Dim query As String = $"INSERT INTO `network` (`ip_address`, `port`, `instrument`, `serial_no`, `section`, `location`) VALUES
                                    (@ip_address, @port, @instrument, @serial_no, @section, @location)"

                Using command As New SQLiteCommand(query, connection)

                    command.Parameters.AddWithValue("@ip_address", txtHost.Text)
                    command.Parameters.AddWithValue("@port", txtNetPort.Text)
                    command.Parameters.AddWithValue("@instrument", txtMachine.Text)
                    command.Parameters.AddWithValue("@serial_no", txtSerial.Text)
                    command.Parameters.AddWithValue("@section", txtSection.Text)
                    command.Parameters.AddWithValue("@location", txtLocation.Text)
                    'command.Parameters.AddWithValue("@protocol", txtSerial.Text)
                    'command.Parameters.AddWithValue("@config_path", txtSerial.Text)
                    'command.Parameters.AddWithValue("@log_path", txtSerial.Text)

                    command.ExecuteNonQuery()
                End Using
            End Using
        End If
    End Sub
End Class