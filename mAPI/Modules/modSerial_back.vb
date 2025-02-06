Imports System.Threading
Imports System.IO.Ports

Module modSerial
    Const SAMPLE As String = "H|\^&|||BLA||||||||V1.0|20141030110328" & vbCrLf &
                                "P|1" & vbCrLf &
                                "O|1|2280||^^^PLUSANF^449353738032|R||20141030110156|||||||20141030110156" & vbCrLf &
                                "R|1|^^^GND^449353738032|INST_ONGOING|||||P|||20141030110156|20141030111213|BACTECFX^93^5^2^D-C09" & vbCrLf &
                                "L|1|N"
    Const LOG_FILE As String = "\\srvfs1\general\groups\biologic\BD\log.txt"
    Const STX As String = Chr(2)
    Const ETX As String = Chr(3)
    Const EOT As String = Chr(4)
    Const ENQ As String = Chr(5)
    Const NAK As String = Chr(25)
    Const ETB As String = Chr(23)
    Const ACKNOWLEDGE_MESSAGE As String = Chr(&H0) + Chr(&H6)

    Private WithEvents _RS232 As Rs232

    Private WithEvents _RS232_01 As New SerialPort

    Dim messageDateTime, accessionNumber, testId, testSequence, collectedDateTime, receivedDateTime, resultFields() As String
    Dim resultTypeCode, vialNumber, testStatus, preliminaryFinalStatus, entryDateTime, classificationDateTime As String
    Dim instrumentFields(), instrumentType, mediaType, protocol, instrumentNumber, station As String
    Dim classificationId As Integer
    Dim resultReceived, orderReceived As Boolean
    Dim frameNumber As String

    Sub Main()
        'updateBiologicDatabase("449381999474", "B-K08", "1480", 2, "20140603032419", "20140617090442", 93, 5, "7171")
        'Dim test As Integer = getClassificationId("INST_NEGATIVE")
        'If 1 = 1 Then
        '    closeConnections()
        '    Return
        'End If
        _RS232_01.DtrEnable = True
        _RS232_01.RtsEnable = True

        _RS232 = New Rs232()
        Try
            '// Setup parameters
            With _RS232
                .BaudRate = 9600
                .DataBit = 8
                .StopBit = Rs232.DataStopBit.StopBit_1
                '.Parity = Rs232.DataParity.Parity_Even
                .Parity = Rs232.DataParity.Parity_None
                '.Timeout = Int32.Parse(txtTimeout.Text)
                .Timeout = 20000
                .UseXonXoff = False

            End With
            '// Initializes port
            _RS232.Open()
            '// Set state of RTS / DTS
            '_RS232.Dtr = (chkDTR.CheckState = CheckState.Checked)
            '_RS232.Rts = (chkRTS.CheckState = CheckState.Checked)
            _RS232.Dtr = True
            _RS232.Rts = True
            If Not _RS232.IsOpen Then
                UpdateLog("Port not opened")
            End If
            Console.WriteLine("Before read port")
            'Console.ReadLine()
            ReadFromPort()
            'Button1_Click_1(Nothing, Nothing)
        Catch Ex As Exception
            UpdateLog(Ex.Message)
        End Try
        'closeConnections()
    End Sub

    Sub ReadFromPort()
        '----------------------
        Dim buffer As String = ""
        Dim nextChar, checkSum, crlf As String
        '// Clear Tx/Rx Buffers
        _RS232.PurgeBuffer(Rs232.PurgeBuffers.TxClear Or Rs232.PurgeBuffers.RXClear)
        _RS232.Write(ACKNOWLEDGE_MESSAGE)


        UpdateLog("Before loop")
        Do While True
            Try
                _RS232.Read(1)
                nextChar = _RS232.InputStreamString
                Select Case nextChar
                    Case STX
                        UpdateLog("STX received")
                        _RS232.Read(1)
                        nextChar = _RS232.InputStreamString
                        frameNumber = nextChar
                    Case ETX
                        UpdateLog("ETX received")
                        _RS232.Read(2)
                        checkSum = _RS232.InputStreamString()
                        _RS232.Read(2)
                        crlf = _RS232.InputStreamString()
                        HandleBuffer(buffer)
                        buffer = ""
                        _RS232.Write(ACKNOWLEDGE_MESSAGE + frameNumber)
                        UpdateLog("Sent: <ACK>" + frameNumber)
                    'Thread.Sleep(500)
                    '_RS232.Write(ACKNOWLEDGE_MESSAGE)
                    'Thread.Sleep(500)
                    '_RS232.Write(ACKNOWLEDGE_MESSAGE)
                    Case ETB
                        UpdateLog("ETB received")
                        _RS232.Read(2)
                        checkSum = _RS232.InputStreamString()
                        'UpdateLog("Checksum after ETB = " & checkSum)
                        _RS232.Read(2)
                        crlf = _RS232.InputStreamString()
                        _RS232.Write(ACKNOWLEDGE_MESSAGE + frameNumber)
                        UpdateLog("Sent: <ACK>" + frameNumber)
                    'Thread.Sleep(500)
                    '_RS232.Write(ACKNOWLEDGE_MESSAGE)
                    'Thread.Sleep(500)
                    '_RS232.Write(ACKNOWLEDGE_MESSAGE)
                    Case EOT
                        UpdateLog("EOT received")
                        HandleBuffer(buffer)
                        buffer = ""
                        _RS232.Write(ACKNOWLEDGE_MESSAGE + frameNumber)
                        UpdateLog("Sent: <ACK>" + frameNumber)
                    'Thread.Sleep(500)
                    '_RS232.Write(ACKNOWLEDGE_MESSAGE)
                    'Thread.Sleep(500)
                    '_RS232.Write(ACKNOWLEDGE_MESSAGE)
                    Case ENQ
                        UpdateLog("ENQ received")
                        _RS232.Write(ACKNOWLEDGE_MESSAGE + frameNumber)
                        UpdateLog("Sent: " + ACKNOWLEDGE_MESSAGE + frameNumber)
                        'Thread.Sleep(500)
                        '_RS232.Write(ACKNOWLEDGE_MESSAGE)
                        'Thread.Sleep(500)
                        '_RS232.Write(ACKNOWLEDGE_MESSAGE)
                    Case Else
                        'If Asc(nextChar) = 13 Then
                        '    _RS232.Read(1)
                        '    nextChar = _RS232.InputStreamString
                        '    If Asc(nextChar) = 10 Then
                        '        buffer += vbCrLf
                        '        UpdateLog("CRLF after line")
                        '    Else
                        '        UpdateLog("0A did not appear after 0D")
                        '    End If
                        'Else
                        'UpdateLog("Regular Character: " & nextChar & " - " & Asc(nextChar))
                        buffer += nextChar
                        'End If
                End Select
            Catch Ex As Exception
                If String.IsNullOrEmpty(buffer) Then
                    Continue Do
                End If
                Console.WriteLine("Timeout")
                Continue Do
            End Try
        Loop
    End Sub
    ''' <summary>
    ''' Handle the buffer received from RS232
    ''' </summary>
    ''' <param name="aBuffer"></param>
    ''' <remarks></remarks>
    Sub HandleBuffer(aBuffer As String)
        ' From BD
        'H|\^&|||BLA||||||||V1.00|19981019184200
        'Q|1|^Acc123|||R
        'L|1|N
        ' Acknowledge
        'H|\^&||||||||||||19981019184200
        'P|1||PatId123||Doe^John^R^Jr.^Dr.||19651029|M||2 Main St.^Baltimore^ MD^21211^USA||(410) 316 - 4000|JSMITH||||||P\AM\AMX||||19981015120000||324|||||||ER|St. Josephs Hospital()
        'O|1|Acc123^ ^ ^Seq123|| ^ ^ ^MGIT_960_GND|||19981019023300|||SJB^MMF|A|||19981019045200|Blood^Arm|MJones|410)555–1234^410)555–9876^(410)555–7777|||||19981020053400|62||O||Nos
        'L|1|F
        ' Result
        'H|\^&|||BLA|||||||| V1.00 |19981019184200
        'P|1||PatId123
        'O|1|Acc123||^^^MGIT_960_GND^430100065178
        'R|1|^^^GND^430100065178|INST_POSITIVE^87|||||P|||19981019153400|19981020145000|MGIT960^^42^3^B/A12
        'L|1|F

        'Dim acknowledge As String
        Dim lines() As String
        Dim patientid As String = ""
        Dim patientName As String = ""
        Dim gender As String = ""
        Dim birthDate As DateTime = "1900-01-01"
        messageDateTime = ""

        Try
            ' Divide the buffer to different lines
            lines = aBuffer.Split(vbCrLf)
            If lines.Count < 2 Then
                Exit Sub
            End If
            For Each line In lines
                HandleLine(line)
            Next
            ' Update the Biologic database only when the 'R' (Result) line was received or the 'O' (Order) line was received
            If resultReceived Or orderReceived Then
                If String.IsNullOrEmpty(classificationDateTime) Then
                    classificationDateTime = entryDateTime
                End If
                updateBiologicDatabase(vialNumber, station, accessionNumber, classificationId, classificationDateTime, entryDateTime, mediaType, protocol, instrumentNumber)
                resultReceived = False
                orderReceived = False
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
        Const HEADER_PREFIX As String = "H"
        'Const PATIENT_PREFIX As String = "P"
        Const ORDER_PREFIX As String = "O"
        Const RESULT_PREFIX As String = "R"
        Const MESSAGE_DATE_TIME_POSITION As Integer = 13
        Const ACCESSION_NUMBER_POSITION As Integer = 2
        Const TEST_POSITION As Integer = 4
        Const TEST_ID_POSITION As Integer = 3
        Const TEST_SEQUENCE_POSITION As Integer = 4
        Const COLLECTED_DATE_TIME_POSITION As Integer = 7
        Const RECEIVED_DATE_TIME_POSITION As Integer = 14
        Const RESULT_POSITION As Integer = 2
        Const RESULT_TYPE_CODE_POSITION As Integer = 3
        Const RESULT_TYPE_SEQUENCE_POSITION As Integer = 4
        Const TEST_STATUS_POSITION As Integer = 3
        Const PRELIMINARY_FINAL_STATUS_POSITION As Integer = 8
        Const TEST_START_DATE_TIME_POSITION As Integer = 11
        Const RESULT_STATUS_DATE_TIME_POSITION As Integer = 12
        Const INSTRUMENT_POSITION As Integer = 13
        Const INSTRUMENT_TYPE_POSITION = 0
        Const MEDIA_TYPE_POSITION = 1
        Const PROTOCOL_POSITION = 2
        Const INSTRUMENT_NUMBER_POSITION = 3
        Const INSTRUMENT_LOCATION_POSITION = 4
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
                        orderReceived = False
                        resultReceived = False
                        'UpdateLog("Message Date Time: " & messageDateTime)
                    End If
                Case ORDER_PREFIX
                    UpdateLog(aLine)
                    accessionNumber = fields(ACCESSION_NUMBER_POSITION)
                    tests = fields(TEST_POSITION).Split("^")
                    testId = tests(TEST_ID_POSITION)
                    'UpdateLog("Test Id: " & testId)
                    vialNumber = tests(TEST_SEQUENCE_POSITION)
                    'UpdateLog("Test Sequence: " & testSequence)
                    collectedDateTime = fields(COLLECTED_DATE_TIME_POSITION)
                    'UpdateLog("Collected Date Time: " & collectedDateTime)
                    receivedDateTime = fields(RECEIVED_DATE_TIME_POSITION)
                    orderReceived = True
                Case RESULT_PREFIX
                    UpdateLog(aLine)
                    resultFields = fields(RESULT_POSITION).Split("^")
                    resultTypeCode = resultFields(RESULT_TYPE_CODE_POSITION)
                    vialNumber = resultFields(RESULT_TYPE_SEQUENCE_POSITION)
                    'UpdateLog("Result Test Sequence: " & vialNumber)
                    testStatus = fields(TEST_STATUS_POSITION)
                    'UpdateLog("Test Status / Classification: " & testStatus)
                    classificationId = getClassificationId(testStatus)
                    If classificationId < 1 Then
                        UpdateLog("Unknown Classification: " & testStatus)
                        Return
                    End If
                    preliminaryFinalStatus = fields(PRELIMINARY_FINAL_STATUS_POSITION)
                    entryDateTime = fields(TEST_START_DATE_TIME_POSITION)
                    classificationDateTime = fields(RESULT_STATUS_DATE_TIME_POSITION)
                    pos = classificationDateTime.IndexOf("\")
                    If pos > 0 Then
                        classificationDateTime = classificationDateTime.Substring(0, pos)
                    End If
                    'R|1|^^^GND^449238953154|INST_REMOVED|||||P|||20141102164617|20141127125123|BACTECFX^92^5^2
                    instrumentFields = fields(INSTRUMENT_POSITION).Split("^")
                    instrumentType = instrumentFields(INSTRUMENT_TYPE_POSITION)
                    mediaType = instrumentFields(MEDIA_TYPE_POSITION)
                    protocol = instrumentFields(PROTOCOL_POSITION)
                    instrumentNumber = instrumentFields(INSTRUMENT_NUMBER_POSITION)
                    If instrumentFields.Length > 4 Then
                        station = instrumentFields(INSTRUMENT_LOCATION_POSITION)
                    Else
                        station = ""
                    End If

                    resultReceived = True
                    'UpdateLog("result Received: ")

            End Select

        Catch ex As Exception
            UpdateLog(ex.Message)
        End Try

    End Sub
    Sub UpdateLog(ByVal aMessage As String)
        Try
            Console.WriteLine(aMessage)
            My.Computer.FileSystem.WriteAllText(LOG_FILE, Format(Now(), "dd-MM-yyyy hh:mm:ss") & ": " & aMessage & vbCrLf, True)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
    Sub Dispose()
        _RS232.Close()
    End Sub
End Module