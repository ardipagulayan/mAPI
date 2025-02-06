Imports System.Text
Imports System.Threading
Imports System.IO.Ports

Module modSerial

    Public LOG_FILE As String = Application.StartupPath & "\Logs\" & "Logs" & Now.ToString("yyyyMMdd") & ".txt"

    Sub OpenComPort(_RS232 As SerialPort)
        Try
            '// Setup parameters
            With My.Settings
                _RS232.PortName = .ComPort
                _RS232.BaudRate = .Baudrate
                _RS232.DataBits = .DataBits
                _RS232.StopBits = .StopBits
                _RS232.Handshake = Handshake.None
                _RS232.Parity = Parity.None
            End With
            '// Initializes port
            _RS232.Open()
            '// Set state of RTS / DTS

            _RS232.DtrEnable = True
            _RS232.RtsEnable = True

            If Not _RS232.IsOpen Then
                UpdateLog("Port not opened")
            End If
        Catch Ex As Exception
            UpdateLog(Ex.Message)
        End Try
    End Sub

    Sub ReadFromPort(_RS232 As SerialPort)
        '----------------------
        Dim buffer As String = ""
        RxTxString = _RS232.ReadExisting
        Packet = RxTxString
        Segment = RxTxString

        Try
            '// Clear Tx/Rx Buffers
            If Not Packet = "" Then
                Select Case Packet(0)
                    Case ENQ
                        _RS232.Write(ACK)
                        UpdateLog("Rx: ENQ")
                        UpdateLog("Tx: ACK")
                    Case EOT
                        UpdateLog("Rx: EOT")
                    Case NACK
                        UpdateLog("Rx: NACK")
                    Case Else
                        _RS232.Write(ACK)
                        UpdateLog("Tx: ACK")
                        buffer &= Segment
                End Select
                Thread.Sleep(2000)
                HandleBuffer(buffer)
            End If

        Catch Ex As Exception
            UpdateLog(Ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Handle the buffer received from RS232
    ''' </summary>
    ''' <param name="aBuffer"></param>
    ''' <remarks></remarks>
    Sub HandleBuffer(aBuffer As String)
        Try
            'Dim parseMsg As String = ""
            'Dim records As String = ""
            'If aBuffer.Length > 0 Then
            '    If aBuffer.Contains(ETB) Then
            '        EndofText = False
            '        nextChar &= StringBetweenChars(aBuffer, STX, ETB)
            '    ElseIf aBuffer.Contains(ETX) Then
            '        EndofText = True
            '        nextChar &= StringBetweenChars(aBuffer, STX, ETB)
            '    End If

            '    If EndofText = True Then
            '        parseMsg = nextChar.Substring(1)
            '        For i = 0 To parseMsg.Split(CR).Length - 1
            '            records = parseMsg.Split(CR).GetValue(i)
            '            HandleLine(records)
            '        Next
            '        nextChar = ""
            '    End If
            'End If

            ' Handle ETB and ETX
            Dim etbDetected As Boolean = False
            Dim etxDetected As Boolean = False
            Dim messageBuffer As New StringBuilder()

            ' Sample data with ETB and ETX
            For Each c As Char In aBuffer
                'If c = ChrW(&H17) Or c = ETB Then ' ETB
                '    etbDetected = True
                '    Continue For
                'Else
                If c = ChrW(&H3) Or c = ETX Then ' ETX
                    etxDetected = True
                    Exit For
                End If

                ' Append character to message buffer
                messageBuffer.Append(c)
            Next

            ' If both ETB and ETX were detected, process the complete message
            If etxDetected Then
                Dim completeMessage As String = messageBuffer.ToString()
                Console.WriteLine($"Complete Message: {completeMessage}")
                UpdateLog(completeMessage)
            End If

        Catch ex As Exception
            UpdateLog(ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Habdle each line separately
    ''' </summary>
    ''' <param name="aLine"></param>
    ''' <remarks></remarks>
    Sub HandleLine(aLine As String)
        'Record Identifier
        Const HEADER_PREFIX As String = "H"
        Const PATIENT_PREFIX As String = "P"
        Const ORDER_PREFIX As String = "O"
        Const RESULT_PREFIX As String = "R"
        Const COMMENT_PREFIX As String = "C"
        Const MATRIX_PREFIX As String = "M"
        Const QUERY_PREFIX As String = "Q"
        Const TERMINATOR_PREFIX As String = "L"
        'End

        'FIELDS DECLARATION
        'Header Positions
        Const MESSAGE_DATE_TIME_POSITION As Integer = 13
        'End
        'Patient Position
        Const PATIENT_ID_POSITION As Integer = 0
        Const PATIENT_NAME_POSITION As Integer = 0
        Const PATIENT_SEX_POSITION As Integer = 0
        Const PATIENT_DOB_POSITION As Integer = 0
        'End
        'Order Position
        Const ACCESSION_NUMBER_POSITION As Integer = 2
        Const TEST_POSITION As Integer = 4
        Const TEST_ID_POSITION As Integer = 3
        Const TEST_SEQUENCE_POSITION As Integer = 4
        Const COLLECTED_DATE_TIME_POSITION As Integer = 7
        Const RECEIVED_DATE_TIME_POSITION As Integer = 14
        'Result Position
        Const RESULT_POSITION As Integer = 2
        Const RESULT_TYPE_CODE_POSITION As Integer = 3
        Const RESULT_TYPE_SEQUENCE_POSITION As Integer = 4
        Const TEST_STATUS_POSITION As Integer = 3
        Const PRELIMINARY_FINAL_STATUS_POSITION As Integer = 8
        Const TEST_START_DATE_TIME_POSITION As Integer = 11
        Const RESULT_STATUS_DATE_TIME_POSITION As Integer = 12
        Const INSTRUMENT_POSITION As Integer = 13
        'End
        'Unknown
        Const INSTRUMENT_TYPE_POSITION = 0
        Const MEDIA_TYPE_POSITION = 1
        Const PROTOCOL_POSITION = 2
        Const INSTRUMENT_NUMBER_POSITION = 3
        Const INSTRUMENT_LOCATION_POSITION = 4
        'END
        'Comment Position
        'End


        Dim fields(), tests() As String
        Dim pos As Integer

        Try
            If String.IsNullOrEmpty(aLine) Then
                Return
            End If
            If aLine.Length < 10 Then
                Return
            End If
            fields = aLine.Split("|")
            If Asc(fields(0)) = Asc(vbLf) Then
                fields(0) = fields(0).Substring(1, 1)
            End If
        Catch ex As Exception
            UpdateLog(ex.Message)
            Return
        End Try
        Try
            Select Case fields(0)
                Case HEADER_PREFIX
                    UpdateLog(aLine)
                    If aLine.Length > 10 Then
                        messageDateTime = fields(MESSAGE_DATE_TIME_POSITION)
                        'orderReceived = False
                        'resultReceived = False
                        UpdateLog("Message Date Time: " & messageDateTime)
                    End If
                Case PATIENT_PREFIX
                    UpdateLog(aLine)
                    If aLine.Length > 10 Then
                        messageDateTime = fields(MESSAGE_DATE_TIME_POSITION)
                        'orderReceived = False
                        'resultReceived = False
                        UpdateLog("Message Date Time: " & messageDateTime)
                    End If

                Case ORDER_PREFIX
                    UpdateLog(aLine)
                    'accessionNumber = fields(ACCESSION_NUMBER_POSITION)
                    'tests = fields(TEST_POSITION).Split("^")
                    'testId = tests(TEST_ID_POSITION)
                    ''UpdateLog("Test Id: " & testId)
                    'vialNumber = tests(TEST_SEQUENCE_POSITION)
                    ''UpdateLog("Test Sequence: " & testSequence)
                    'collectedDateTime = fields(COLLECTED_DATE_TIME_POSITION)
                    ''UpdateLog("Collected Date Time: " & collectedDateTime)
                    'receivedDateTime = fields(RECEIVED_DATE_TIME_POSITION)
                    'orderReceived = True
                Case RESULT_PREFIX
                    UpdateLog(aLine)
                Case COMMENT_PREFIX
                    UpdateLog(aLine)
                Case MATRIX_PREFIX
                    UpdateLog(aLine)
                Case QUERY_PREFIX
                    UpdateLog(aLine)
                Case TERMINATOR_PREFIX
                    UpdateLog(aLine)
                    'resultFields = fields(RESULT_POSITION).Split("^")
                    'resultTypeCode = resultFields(RESULT_TYPE_CODE_POSITION)
                    'vialNumber = resultFields(RESULT_TYPE_SEQUENCE_POSITION)
                    ''UpdateLog("Result Test Sequence: " & vialNumber)
                    'testStatus = fields(TEST_STATUS_POSITION)
                    ''UpdateLog("Test Status / Classification: " & testStatus)
                    'classificationId = getClassificationId(testStatus)
                    'If classificationId < 1 Then
                    '    UpdateLog("Unknown Classification: " & testStatus)
                    '    Return
                    'End If
                    'preliminaryFinalStatus = fields(PRELIMINARY_FINAL_STATUS_POSITION)
                    'entryDateTime = fields(TEST_START_DATE_TIME_POSITION)
                    'classificationDateTime = fields(RESULT_STATUS_DATE_TIME_POSITION)
                    'pos = classificationDateTime.IndexOf("\")
                    'If pos > 0 Then
                    '    classificationDateTime = classificationDateTime.Substring(0, pos)
                    'End If
                    ''R|1|^^^GND^449238953154|INST_REMOVED|||||P|||20141102164617|20141127125123|BACTECFX^92^5^2
                    'instrumentFields = fields(INSTRUMENT_POSITION).Split("^")
                    'instrumentType = instrumentFields(INSTRUMENT_TYPE_POSITION)
                    'mediaType = instrumentFields(MEDIA_TYPE_POSITION)
                    'protocol = instrumentFields(PROTOCOL_POSITION)
                    'instrumentNumber = instrumentFields(INSTRUMENT_NUMBER_POSITION)
                    'If instrumentFields.Length > 4 Then
                    '    station = instrumentFields(INSTRUMENT_LOCATION_POSITION)
                    'Else
                    '    station = ""
                    'End If

                    'resultReceived = True
                    ''UpdateLog("result Received: ")

            End Select

        Catch ex As Exception
            UpdateLog(ex.Message)
        End Try

    End Sub

    Private Sub StartSerialPortThread(portName As String, baudRate As String)
        Dim serialPort As New SerialPort(portName)

        Dim buffer As String = ""

        ' Handle ETB and ETX
        Dim etbDetected As Boolean = False
        Dim etxDetected As Boolean = False
        Dim messageBuffer As New StringBuilder()

        Try
            serialPort.PortName = portName
            serialPort.BaudRate = baudRate
            serialPort.StopBits = StopBits.One
            serialPort.DataBits = 8
            serialPort.Parity = Parity.None
            serialPort.Handshake = Handshake.None
            serialPort.Open()
            UpdateLog($"{serialPort.PortName} Open")
            While serialPort.IsOpen
                RxTxString = serialPort.ReadExisting()
                If Not RxTxString = "" Then
                    Select Case RxTxString(0)
                        Case ENQ
                            serialPort.Write(ACK)
                            UpdateLog("Rx: ENQ")
                            UpdateLog("Tx: ACK")
                        Case EOT
                            UpdateLog("Rx: EOT")
                        Case NACK
                            UpdateLog("Rx: NACK")
                        Case STX
                            ' Sample data with ETB and ETX
                            For Each c As Char In RxTxString
                                If c = ChrW(&H17) Or c = ETB Then ' ETB
                                    etbDetected = True
                                    Continue For
                                ElseIf c = ChrW(&H3) Or c = ETX Then ' ETX
                                    etxDetected = True
                                    Exit For
                                End If
                                ' Append character to message buffer
                                messageBuffer.Append(c)
                            Next
                            ' If both ETB and ETX were detected, process the complete message
                            If etxDetected Then
                                Dim completeMessage As String = messageBuffer.ToString()
                                UpdateLog(completeMessage)
                            End If

                            serialPort.Write(ACK)
                            UpdateLog("Tx: ACK")
                    End Select
                End If
                Thread.Sleep(2000)
                'HandleBuffer(buffer)
            End While
        Catch ex As Exception
            Debug.Write($"Error opening port {portName}: {ex.Message}", "Error")
        Finally
            serialPort.Close()
        End Try
    End Sub

    Sub UpdateLog(ByVal aMessage As String)
        Dim LOG_FILE As String = Application.StartupPath & "\Logs\" & "Logs" & Now.ToString("yyyyMMdd") & ".txt"

        Try
            Console.WriteLine(aMessage)
            My.Computer.FileSystem.WriteAllText(LOG_FILE, Format(Now(), "dd-MM-yyyy hh:mm:ss") & ": " & aMessage & vbCrLf, True)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub UpdateLogs(ByVal aMessage As String, _fileName As String)
        Dim LOG_FILE As String = Application.StartupPath & "\Logs\" & _fileName & Now.ToString("yyyyMMdd") & ".txt"

        Try
            Console.WriteLine(aMessage)
            My.Computer.FileSystem.WriteAllText(LOG_FILE, Format(Now(), "dd-MM-yyyy hh:mm:ss") & ": " & aMessage & vbCrLf, True)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Public Sub DisplayData(receivedText As RichTextBox, data As String)
        receivedText.AppendText(New String(data))
    End Sub

    Sub Dispose(_RS232 As SerialPort)
        _RS232.Close()
    End Sub
End Module