Imports System.Environment
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports Bluegrams.Application

Module modLoadComSettings

    Dim Port As New SerialPort

    Public Sub GetComPorts(ComPortBox As DevExpress.XtraEditors.ComboBoxEdit)
        For Each COMString As String In My.Computer.Ports.SerialPortNames ' Load all available COM ports.
            ComPortBox.Properties.Items.Add(COMString)
        Next
    End Sub

    Private Sub LoadComSettings()
        Try
            'List down all available port
            GetComPorts()

            'Retrieve saved settings for default use
            With My.Settings
                'Display ComPort and Machine Settings in textbox
                ComPortsBox.Text = .COMPort
                cboBaudrate.Text = .Baudrate
                cboStopBits.Text = .Stopbits
                cboDataBits.Text = .Databits
                txtMachine.Text = "PentraC400"
                txtSerial.Text = .SerialNo
                txtSection.Text = .Section
                cboLocation.Text = .Location

                'Server Setting
                txtServerName.Text = .HostName
                txtRoot.Text = .UID
                txtPassword.Text = .PWD
                txtDBName.Text = .DBName

                'Machine Settings
                Instrument = .Machine
                Serial = .SerialNo
                Section = .Section

                'For Two Way Process
                If .ReceivingStatus = 1 Then
                    chkReceiving.CheckState = CheckState.Checked
                Else
                    chkReceiving.CheckState = CheckState.Unchecked
                End If

                'Set ComPort Settings
                Port.PortName = ComPortsBox.Text
                Port.BaudRate = cboBaudrate.Text
                Port.DataBits = 8
                Port.StopBits = 1
                Port.Open()

                'Create text file for TraceComm.log
                CreateFile(TraceComm, ComPortsBox.Text)

                'Check if Registry Setting Exist
                If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\KeyString\CS 1.0.0", "ConnectionString", Nothing) Is Nothing Then
                    Exit Sub
                Else
                    'Get Connection String value from Registry
                    Dim TXTConnectionString As String = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\KeyString\CS 1.0.0", "ConnectionString", Nothing)
                    '#########################################################################################################################################################

                    'Update Machine Status
                    conn.ConnectionString = TXTConnectionString
                    conn.Open()
                    rs.Connection = conn
                    rs.CommandText = "SELECT * FROM `machines` WHERE `name` = '" & txtMachine.Text & "' AND `serial_no` = '" & txtSerial.Text & "'"
                    reader = rs.ExecuteReader
                    reader.Read()
                    If reader.HasRows Then
                        conn.Close()
                        conn.ConnectionString = TXTConnectionString
                        conn.Open()
                        rs.Connection = conn
                        rs.CommandText = "UPDATE `machines` SET `status` = 'Connected' WHERE `name` = '" & txtMachine.Text & "' AND `serial_no` = '" & txtSerial.Text & "'"
                        rs.ExecuteNonQuery()
                        conn.Close()
                    End If
                    conn.Close()
                    '############################################################################################################################################################
                End If
                '###############################################################################################################################################################
                Me.Text = "Communication Protocol " & .Machine & "(" & .COMPort & ")"
            End With

            GetDefaultUnit()

            If Port.IsOpen Then
                lblConnection.Text = "Connection Status: Connected"
            Else
                lblConnection.Text = "Connection Status: Disconnected"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

End Module
