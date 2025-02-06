Imports System.Environment
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Xml
Imports Bluegrams.Application
Imports System.Data.SQLite
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Repository
Imports System.Reflection

Public Class MainForm
    Private newThread As Thread
    Private newThreadID As Object

    Private WithEvents riButtonEdit As New RepositoryItemButtonEdit
    Private WithEvents riTextLabel As New RepositoryItemComboBox
    Private _hRef As String
    Private _portName As String
    Private _baudRate As String
    Private _machineName As String
    Private _serialNo As String
    Private _section As String
    Private _location As String
    Private _machineDetails As String
    'Private fileName As String
    Private _dllPath As String
    Private _fullPath As String
    Private _isActive As Integer
    Private _resultPath As String
    Private _orderPath As String
    Private _localDB As String
    Public _type As String
    Public _isBiDirectional As Boolean

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Load serial ports from database
        LoadSerialPortsFromDatabase()
        LoadNetworkFromDatabase()

        Dim path As String = Application.StartupPath & "\" & Settings
        ' This text is added only once to the file.
        If File.Exists(path) = True Then
            LoadSettings()
        End If

        If My.Settings.AutoFetch Then

        End If
    End Sub

#Region "SERIAL PORT COMMUNICATION"
    Public Sub LoadSerialPortsFromDatabase()
        Try
            GridView.Columns.Clear()

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT 
                                        `id` AS ID, 
                                        `port_name` AS PortName, 
                                        `baud_rate` AS BaudRate, 
                                        `stop_bits` AS StopBits, 
                                        `data_bits` AS DataBits, 
                                        `flow_control` AS FlowControl, 
                                        `instrument` AS Instrument, 
                                        `serial_no` AS SerialNo,
                                        `section` AS Section,
                                        `location` AS Location,
                                        `protocol` AS Protocol,
                                        `config_path` AS ConfigPath,
                                        `build_no` AS BuildNo,
                                        `bi_directional` AS BiDirectional,
                                        `isActive` 
                                      FROM `comport`"

                Using command As New SQLiteCommand(query, connection)
                    Dim adapter As New SQLiteDataAdapter(command)
                    Dim myTable As DataTable = New DataTable
                    adapter.Fill(myTable)
                    GridControl.DataSource = myTable
                End Using

                GridView.Columns("StopBits").Visible = False
                GridView.Columns("DataBits").Visible = False
                GridView.Columns("FlowControl").Visible = False
                GridView.Columns("Protocol").Visible = False
                GridView.Columns("ConfigPath").Visible = False
                'GridView.Columns("BuildNo").Visible = False
                GridView.Columns("isActive").Visible = False
                GridView.Columns("ID").Visible = False

                Dim repositoryCheckEdit1 As RepositoryItemCheckEdit = GridControl.RepositoryItems.Add("CheckEdit")
                repositoryCheckEdit1.ValueChecked = "True"
                repositoryCheckEdit1.ValueUnchecked = "False"
                GridView.Columns("BiDirectional").ColumnEdit = repositoryCheckEdit1

                ' Make the grid read-only. 
                'GridView.OptionsBehavior.Editable = False
                ' Prevent the focused cell from being highlighted. 
                GridView.OptionsSelection.EnableAppearanceFocusedCell = False
                ' Draw a dotted focus rectangle around the entire row. 
                GridView.FocusRectStyle = DrawFocusRectStyle.RowFullFocus
                ' Make columns with fixed width
                'GridView.OptionsView.ColumnAutoWidth = False

                For x As Integer = 0 To GridView.Columns.Count - 1 Step 1
                    'GridView.Columns(x).OptionsColumn.ReadOnly = True
                    GridView.Columns(x).OptionsColumn.AllowEdit = False
                Next
                connection.Close()
            End Using

            CreateRepositoryButton()

        Catch ex As Exception
            MessageBox.Show($"Error loading serial ports from database: /n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateRepositoryButton()
        Try
            Dim unboundColumn = GridView.Columns.AddVisible("Commands")
            AddHandler GridView.CustomRowCellEdit, Sub(sender As Object, e As CustomRowCellEditEventArgs)
                                                       If (e.Column.FieldName <> "Commands") Then
                                                           Return
                                                       Else
                                                           e.RepositoryItem = CreateRepositoryItemButon()
                                                       End If
                                                   End Sub
            With unboundColumn
                .AbsoluteIndex = 1
                .ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
                .UnboundType = DevExpress.Data.UnboundColumnType.Object
                .Visible = True
                .OptionsColumn.ReadOnly = False
            End With

        Catch ex As Exception
            MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function CreateRepositoryItemButon() As RepositoryItem

        riButtonEdit = New RepositoryItemButtonEdit()
        riButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        riButtonEdit.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        riButtonEdit.Buttons(0).Image = Image.FromFile($"{Application.StartupPath}\icons\icons8-play-16.png")
        riButtonEdit.Buttons(0).ToolTip = "Start"

        riButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton())
        riButtonEdit.Buttons(1).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        riButtonEdit.Buttons(1).Image = Image.FromFile($"{Application.StartupPath}\icons\icons8-cancel-16.png")
        riButtonEdit.Buttons(1).ToolTip = "Stop"

        riButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton())
        riButtonEdit.Buttons(2).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        riButtonEdit.Buttons(2).Image = Image.FromFile($"{Application.StartupPath}\icons\icons8-import-16.png")
        riButtonEdit.Buttons(2).ToolTip = "Import"

        riButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton())
        riButtonEdit.Buttons(3).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        riButtonEdit.Buttons(3).Image = Image.FromFile($"{Application.StartupPath}\icons\icons8-edit-16.png")
        riButtonEdit.Buttons(3).ToolTip = "Edit"

        riButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton())
        riButtonEdit.Buttons(4).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        riButtonEdit.Buttons(4).Image = Image.FromFile($"{Application.StartupPath}\icons\icons8-delete-16.png")
        riButtonEdit.Buttons(4).ToolTip = "Delete"

        AddHandler riButtonEdit.ButtonClick, Sub(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
                                                 If (e.Button.Index = 0) Then
                                                     If _isActive = 1 Then
                                                         MessageBox.Show("Com Port is already running")
                                                         Exit Sub
                                                     End If
                                                     StartSerialPort()
                                                 ElseIf (e.Button.Index = 1) Then
                                                     StopSerialPort(newThreadID)
                                                 ElseIf (e.Button.Index = 2) Then
                                                     If _isActive = 1 Then
                                                         MessageBox.Show("Unable to import file while the process is currently running.")
                                                         Exit Sub
                                                     End If
                                                     ImportDllFile(_machineName, _serialNo)
                                                 ElseIf (e.Button.Index = 3) Then
                                                     If _isActive = 1 Then
                                                         MessageBox.Show("Unable to edit file while the process is currently running.")
                                                         Exit Sub
                                                     End If
                                                     _type = "Edit"
                                                     frmSecurity.ShowDialog()
                                                 ElseIf (e.Button.Index = 4) Then
                                                     If _isActive = 1 Then
                                                         MessageBox.Show("Unable to delete file while the process is currently running.")
                                                         Exit Sub
                                                     End If
                                                     _type = "Delete"
                                                     frmSecurity.ShowDialog()
                                                 End If
                                             End Sub
        Return riButtonEdit
    End Function

    Private Sub StartSerialPort()
        Try
            ' Start receiving thread for each saved port
            newThread = New Thread(Sub() StartSerialPortThread())
            newThread.Name = $"{_machineName}_{_serialNo}"
            newThread.Start()
            newThreadID = newThread.ManagedThreadId

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Dim query As String = $"UPDATE `comport` SET isActive = 1 WHERE `ID` = @ID"
                Using command As New SQLiteCommand(query, connection)
                    command.Parameters.AddWithValue("@ID", _hRef)
                    command.ExecuteNonQuery()
                End Using
            End Using

            LoadSerialPortsFromDatabase()
        Catch ex As Exception
            MessageBox.Show($"{ex.Message}")
            Exit Sub
        End Try
    End Sub

    Private Sub StartSerialPortThread()
        Try
            Dim dllFile As String = _dllPath

            If dllFile.Length > 0 Then
                If File.Exists(_dllPath) Then
                    Dim className As String = "MainClass"
                    Dim methodName As String = "MainMethod"
                    Dim ass = Assembly.Load(File.ReadAllBytes(_dllPath))
                    Dim type = ass.GetType($"{_machineName}.{className}")
                    Dim obj = Activator.CreateInstance(type)
                    Dim method = type.GetMethod(methodName)
                    method.Invoke(obj, New Object() {_portName, _baudRate, _fullPath, _machineName, _serialNo, _location, _section, My.Settings.ResultPath, _isBiDirectional})
                Else
                    MessageBox.Show("The the machine script is missing", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("The Script not yet uploaded", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show($"{ex.Message}")
            Exit Sub
        End Try
    End Sub

    Private Sub StopSerialPort(newThreadID As Object)
        If Not newThreadID = Nothing Then
            newThread.Abort(newThreadID)

            Using connection As New SQLiteConnection(connectionString)
                connection.Open()
                Dim query As String = $"UPDATE `comport` SET isActive = 0 WHERE `ID` = @ID"
                Using command As New SQLiteCommand(query, connection)
                    command.Parameters.AddWithValue("@ID", _hRef)
                    command.ExecuteNonQuery()
                End Using
            End Using
            LoadSerialPortsFromDatabase()
        End If
    End Sub

    Public Sub DeleteSerialPort()
        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Dim query As String = $"DELETE FROM `comport` WHERE `ID` = @ID"
            Using command As New SQLiteCommand(query, connection)
                command.Parameters.AddWithValue("@ID", _hRef)
                command.ExecuteNonQuery()
            End Using
        End Using
        LoadSerialPortsFromDatabase()
    End Sub

    Public Sub EditSerialPort()
        frmComportEdit.ID = _hRef
        frmComportEdit.txtMachine.Text = _machineName
        frmComportEdit.txtSerial.Text = _serialNo
        frmComportEdit.txtSection.Text = _section
        frmComportEdit.txtLocation.Text = _location
        frmComportEdit.ComPortsBox.Text = _portName
        frmComportEdit.cboBaudrate.Text = _baudRate
        frmComportEdit.chkDirection.Checked = _isBiDirectional
        frmComportEdit.ShowDialog()
    End Sub

    Private Sub GridView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView.FocusedRowChanged
        Try
            If e.FocusedRowHandle < 0 Then
                Disconnect()
            Else
                _hRef = GridView.GetRowCellValue(e.FocusedRowHandle, GridView.Columns("ID")).ToString
                _portName = GridView.GetRowCellValue(e.FocusedRowHandle, GridView.Columns("PortName")).ToString
                _baudRate = GridView.GetRowCellValue(e.FocusedRowHandle, GridView.Columns("BaudRate")).ToString
                _machineName = GridView.GetRowCellValue(e.FocusedRowHandle, GridView.Columns("Instrument")).ToString
                _serialNo = GridView.GetRowCellValue(e.FocusedRowHandle, GridView.Columns("SerialNo")).ToString
                _location = GridView.GetRowCellValue(e.FocusedRowHandle, GridView.Columns("Location")).ToString
                _section = GridView.GetRowCellValue(e.FocusedRowHandle, GridView.Columns("Section")).ToString
                _fullPath = GridView.GetRowCellValue(e.FocusedRowHandle, GridView.Columns("ConfigPath")).ToString
                _machineDetails = $"{_machineName}_{_serialNo}"
                _dllPath = $"{GridView.GetRowCellValue(e.FocusedRowHandle, GridView.Columns("ConfigPath")).ToString}{_machineDetails}.dll"
                _isActive = GridView.GetRowCellValue(e.FocusedRowHandle, GridView.Columns("isActive")).ToString
                _isBiDirectional = GridView.GetRowCellValue(e.FocusedRowHandle, GridView.Columns("BiDirectional")).ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridView_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView.RowCellStyle
        Dim view As GridView = TryCast(sender, GridView)
        If (e.Column.FieldName = "PortName") Then
            If view.GetRowCellValue(e.RowHandle, "isActive") = 1 Then
                e.Appearance.BackColor = Color.ForestGreen
                e.Appearance.BackColor2 = Color.ForestGreen
                e.Appearance.ForeColor = Color.White
            Else
                e.Appearance.BackColor = Color.Crimson
                e.Appearance.BackColor2 = Color.Crimson
                e.Appearance.ForeColor = Color.White
            End If
        End If
    End Sub

    Private Sub ImportDllFile(machineName As String, serialNo As String)
        Dim ofd As New OpenFileDialog
        ofd.Title = "Import Machine Script"
        ofd.Multiselect = False
        ofd.Filter = $"dll files {"(*.dll),(*.DLL)"}|*.dll"

        ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        If ofd.ShowDialog = DialogResult.OK Then
            Dim sourceFilepath As String = ofd.FileName
            Dim newFileName As String = $"{Path.GetFileNameWithoutExtension(sourceFilepath)}_{serialNo}{Path.GetExtension(sourceFilepath)}"
            Dim destinationFolder As String = $"{Application.StartupPath}\{machineName}_{serialNo}\"
            Dim destinationFilepath = $"{destinationFolder}{newFileName}"
            Dim destinationFilepath2 = $"{destinationFolder}{sourceFilepath}"
            Dim assemblyVersion = Assembly.LoadFile(ofd.FileName).GetName().Version.ToString()

            Try
                If ofd.FileName.EndsWith(".dll") Or ofd.FileName.EndsWith(".DLL") Then
                    If Not Directory.Exists(destinationFolder) Then
                        Directory.CreateDirectory(destinationFolder)
                    End If
                    File.Copy(sourceFilepath, destinationFilepath, True)
                    Debug.Write(destinationFilepath)
                    Using connection As New SQLiteConnection(connectionString)
                        connection.Open()
                        Dim SQL As String = $"UPDATE `comport` SET
                                        `config_path` = @dllFile, `build_no` = @assemblyVersion WHERE `id` = {_hRef}"
                        Using command As New SQLiteCommand(SQL, connection)
                            command.Parameters.Clear()
                            command.Parameters.AddWithValue("@dllFile", destinationFolder)
                            command.Parameters.AddWithValue("@assemblyVersion", assemblyVersion)
                            command.ExecuteNonQuery()
                        End Using
                        connection.Close()
                    End Using
                End If
                MessageBox.Show("Succesfully import DLL File.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception

                MessageBox.Show(ex.Message)
                'Finally
                '    File.Copy(sourceFilepath, destinationFilepath, True)
            End Try
        End If
    End Sub
#End Region

#Region "NETWORK COMMUNICATION"
    Public Sub LoadNetworkFromDatabase()
        Try
            Using connection As New SQLiteConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT 
                                        `id` AS ID, 
                                        `ip_address` AS IPAddress, 
                                        `port` AS Port, 
                                        `instrument` AS Instrument, 
                                        `serial_no` AS SerialNo,
                                        `location` AS Location,
                                        `protocol` AS Protocol,
                                        `config_path` AS ConfigPath,
                                        `log_path` AS LogPath,
                                        `isActive` 
                                      FROM `network`"

                Using command As New SQLiteCommand(query, connection)
                    Dim adapter As New SQLiteDataAdapter(command)
                    Dim myTable As DataTable = New DataTable
                    adapter.Fill(myTable)
                    GridControlNetwork.DataSource = myTable
                End Using

                GridViewNetwork.Columns("Protocol").Visible = False
                GridViewNetwork.Columns("ConfigPath").Visible = False
                GridViewNetwork.Columns("LogPath").Visible = False
                ' Make the grid read-only. 
                'GridView.OptionsBehavior.Editable = False
                ' Prevent the focused cell from being highlighted. 
                GridViewNetwork.OptionsSelection.EnableAppearanceFocusedCell = False
                ' Draw a dotted focus rectangle around the entire row. 
                GridViewNetwork.FocusRectStyle = DrawFocusRectStyle.RowFullFocus
                ' Make columns with fixed width
                'GridView.OptionsView.ColumnAutoWidth = False
                connection.Close()
            End Using

            CreateRepositoryButtonNetwork()

        Catch ex As Exception
            MessageBox.Show($"Error loading serial ports from database: /n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateRepositoryButtonNetwork()
        Try
            Dim unboundColumn = GridViewNetwork.Columns.AddVisible("Commands")

            AddHandler GridViewNetwork.CustomRowCellEdit, Sub(sender As Object, e As CustomRowCellEditEventArgs)
                                                              If (e.Column.FieldName <> "Commands") Then
                                                                  Return
                                                              Else
                                                                  e.RepositoryItem = CreateRepositoryItemButonNetwork()
                                                              End If
                                                          End Sub
            With unboundColumn
                .AbsoluteIndex = 1
                .ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways
                .UnboundType = DevExpress.Data.UnboundColumnType.Object
                .Visible = True
                .OptionsColumn.ReadOnly = False
            End With

        Catch ex As Exception
            MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function CreateRepositoryItemButonNetwork() As RepositoryItem
        riButtonEdit = New RepositoryItemButtonEdit()

        riButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton())
        riButtonEdit.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.SpinRight
        'riButtonEdit.Buttons(1).Image = Image.FromFile(Application.StartupPath & "\res\view.png")
        riButtonEdit.Buttons(0).ToolTip = "Start"

        riButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton())
        riButtonEdit.Buttons(1).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.OK
        'riButtonEdit.Buttons(2).Image = Image.FromFile(Application.StartupPath & "\res\reject.png")
        riButtonEdit.Buttons(1).ToolTip = "Validate"

        riButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton())
        riButtonEdit.Buttons(2).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Down
        'riButtonEdit.Buttons(2).Image = Image.FromFile(Application.StartupPath & "\res\reject.png")
        riButtonEdit.Buttons(2).ToolTip = "Import"

        riButtonEdit.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton())
        riButtonEdit.Buttons(3).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis
        'riButtonEdit.Buttons(2).Image = Image.FromFile(Application.StartupPath & "\res\reject.png")
        riButtonEdit.Buttons(3).ToolTip = "Logs"


        AddHandler riButtonEdit.ButtonClick, Sub(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
                                                 If (e.Button.Index = 0) Then
                                                     'StartSerialPort()
                                                 ElseIf (e.Button.Index = 1) Then
                                                     'ValidateTicket(_hRef)
                                                 ElseIf (e.Button.Index = 2) Then
                                                     'ValidateTicket(_hRef)
                                                 ElseIf (e.Button.Index = 3) Then
                                                     'ValidateTicket(_hRef)
                                                 End If
                                             End Sub
        Return riButtonEdit
    End Function

    Private Sub GridViewNetwork_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewNetwork.FocusedRowChanged
        Try
            If e.FocusedRowHandle < 0 Then
                Disconnect()
            Else
                _hRef = GridViewNetwork.GetRowCellValue(e.FocusedRowHandle, GridViewNetwork.Columns("ID")).ToString
                _portName = GridViewNetwork.GetRowCellValue(e.FocusedRowHandle, GridViewNetwork.Columns("IPAddress")).ToString
                _baudRate = GridViewNetwork.GetRowCellValue(e.FocusedRowHandle, GridViewNetwork.Columns("Port")).ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Query Fetcher"

    Dim rtxRead As New RichTextBox

    'Parsed Data send by the Instrument
    'Header
    Public messageProcessingID As String
    Public messageType As String
    Public messageDateTime As String
    'Patient
    Public messagePatientID As String
    Public messagePatientName() As String
    Public messagePatientSex As String
    Public messagePatientDOB As String
    'Order
    Public messageSampleID() As String
    Public messageSampleIDPos As String
    Public messageTestID() As String
    Public messageTestIDPos As String
    Public messageTestSource() As String
    Public messageTestSourcePos As String
    Public messageMeasurePos As String
    Public messagePriority As String
    Public messageRequestedDT As String
    Public messageCollectionDT As String
    Public messageActionCode As String
    Public messageSpecimenType As String
    Public messageReportType As String
    'Comment
    Public messageCommentPos() As String
    Public messageCommentCode As String
    Public messageCommentType As String
    'Result
    Public messageTestCode() As String
    Public messageTestCodePos As String
    Public messageTestResult() As String
    Public messageTestResultPos As String
    Public messageUnits As String
    Public messageReferenceRange As String
    Public messageFlags As String
    Public messageResultStatus As String
    Public messageResultDT As String
    'Query
    Public messageQueryID As String

    'RECORD IDENTIFIER**********************************************************
    Const MSH_PREFIX As String = "MSH"
    Const PID_PREFIX As String = "PID"
    Const PV1_PREFIX As String = "PV1"
    Const ORC_PREFIX As String = "ORC"
    Const OBR_PREFIX As String = "OBR"
    'End

    'FIELDS DECLARATION*********************************************************
    'Header Positions
    Const MESSAGE_DATE_TIME_POSITION As Integer = 13
    Const MESSAGE_TYPE_POSITION As Integer = 11
    'End
    'Patient Position
    Const PATIENT_ID_POSITION As Integer = 2
    Const PATIENT_NAME_POSITION As Integer = 5
    Const PATIENT_SEX_POSITION As Integer = 8
    Const PATIENT_DOB_POSITION As Integer = 0
    'End
    'Order Position
    Const SAMPLE_ID As Integer = 2
    Const SAMPLE_ID_POSITION As Integer = 0
    Const TEST_POSITION As Integer = 4
    Const TEST_ID_POSITION As Integer = 3
    Const TEST_SOURCE As Integer = 15
    Const TEST_SOURCE_POSITION As Integer = 0
    Const COLLECTED_DATE_TIME_POSITION As Integer = 14
    Const RECEIVED_DATE_TIME_POSITION As Integer = 0
    'End
    'Result Position
    Const RESULT_TEST_CODE As Integer = 2
    Const RESULT_TEST_CODE_POSITION As Integer = 3
    Const RESULT_TEST_CODE_POSITION_IDEN As Integer = 6
    Const RESULT_TEST_RESULT As Integer = 3
    Const RESULT_TEST_RESULT_POSITION As Integer = 0
    'End
    'Query Position
    Const QUERY_ID_POSITION As Integer = 2
    'End
    'Comment Position
    Const COMMENT_POSITION As Integer = 3
    Const COMMENT_TYPE As Integer = 0
    Const COMMENT_CODE As Integer = 1
    'End

    Private Sub StartFetch()
        Dim fileName As String
        Dim fcopy As String

        Try
            Dim data As String = ""
            Dim files() As String = IO.Directory.GetFiles(My.Settings.OrderPath, "*.hl7")

            For Each sFile As String In files
                fileName = sFile
                data = IO.File.ReadAllText(sFile)

                rtxRead.Text = data
                'ReadHL7()

                Dim file As New IO.FileInfo(fileName)
                fcopy = file.Name

                My.Computer.FileSystem.DeleteFile(fileName)
            Next
        Catch EX As Exception
            Disconnect()
            MessageBox.Show(EX.Message, "Existing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
    End Sub

    'Private Sub ReadHL7()
    '    'On Error Resume Next
    '    With My.Settings
    '        For i = 0 To rtxRead.Lines.Count - 1
    '            rtxRead.Lines(i)
    '            Dim stElement As String = rtxRead.Lines(i).Split("|").GetValue(0).ToString
    '            Select Case (stElement)
    '                Case "MSH"

    '                Case "PID"
    '                    PatientID = rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.PID_PID)).ToString
    '                    PatientName = rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.PID_Name)).ToString

    '                    PatientName = Regex.Replace(rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.PID_Name)).ToString, "Ñ", "N")

    '                    'Original code from DEDVMH BIZBOX Integration
    '                    PatientLName = PatientName.Split("^").GetValue(0).ToString
    '                    PatientFName = PatientName.Split("^").GetValue(1).ToString
    '                    PatientMName = PatientName.Split("^").GetValue(2).ToString
    '                    PatientSuffix = PatientName.Split("^").GetValue(3).ToString
    '                    PatientDetails = PatientLName & ", " & PatientFName & " " & PatientMName & " " & PatientSuffix

    '                    PatientBDay = DateTime.ParseExact(rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.PID_BDate)).ToString, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).ToString("MM/dd/yyyy")

    '                    If rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.PID_Gender)).ToString = "F" Then
    '                        PatientGender = "Female"
    '                    ElseIf rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.PID_Gender)).ToString = "M" Then
    '                        PatientGender = "Male"
    '                    Else
    '                        PatientGender = ""
    '                    End If

    '                    SMSEmail = rtxRead.Lines(i).Split("|").GetValue(13).ToString

    '                    If SMSEmail = "" Then
    '                        Email = ""
    '                        Mobile = ""
    '                    Else
    '                        Email = SMSEmail.Split("^").GetValue(1).ToString
    '                        Mobile = SMSEmail.Split("^").GetValue(0).ToString
    '                    End If

    '                    Address = Replace(rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.PID_Address)).ToString, "^", ", ")

    '                Case "PV1"
    '                    RoomWard = rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.OBR_Location)).ToString

    '                    RoomWard = RoomWard.Trim(New Char() {"^"c})

    '                    If rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.PVI_PType)).ToString = "I" Then
    '                        PatientType = "In Patient"
    '                    ElseIf rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.PVI_PType)).ToString = "O" Then
    '                        PatientType = "Out Patient"
    '                    ElseIf rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.PVI_PType)).ToString = "E" Then
    '                        PatientType = "ER Patient"
    '                    End If

    '                    CaseNo = rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.PVI_CaseNo)).ToString
    '                    CaseNo = CaseNo.Split("<").GetValue(0).ToString

    '                    AdmissionNo = rtxRead.Lines(i).Split("|").GetValue(19).ToString
    '                    ChargeSlip = rtxRead.Lines(i).Split("|").GetValue(24).ToString
    '                Case "SPM"
    '                    SampleID = rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.SPM_SID)).ToString
    '                Case "ORC"
    '                    SampleID = rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.ORC_SID)).ToString
    '                Case "OBR"

    '                    SampleID = rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.OBR_SID)).ToString
    '                    Specimen = rtxRead.Lines(i).Split("|").GetValue(Convert.ToInt32(.OBR_Test)).ToString
    '                    Orders = Specimen.Split("~"c)

    '                    If Specimen = "" Then

    '                    Else

    '                        'Split Specimen Segment to get HIS Code
    '                        For x As Integer = 0 To Orders.Length - 1
    '                            Dim elements() As String = Orders(x).Split("^"c)
    '                            If elements.Length > 0 Then
    '                                GetSection(elements(0).Trim)

    '                                iItem = New ListViewItem(elements(0).Trim, 0)
    '                                iItem.SubItems.Add(elements(1).Trim)
    '                                iItem.SubItems.Add(section)
    '                                iItem.SubItems.Add(sub_section)
    '                                ListB.Items.Add(iItem)
    '                            Else
    '                                ListB.Items.Add("")
    '                            End If
    '                        Next
    '                        '#######################################

    '                        RPhysician = rtxRead.Lines(i).Split("|").GetValue(16).ToString

    '                        If RPhysician = "" Then
    '                            RPhysician = ""
    '                        Else
    '                            RPhysician = RPhysician.Split("^").GetValue(1).ToString
    '                        End If

    '                        SMSEmail_Doc = rtxRead.Lines(i).Split("|").GetValue(16).ToString

    '                        If SMSEmail_Doc = "" Then
    '                            Email_Doc = ""
    '                            Mobile_Doc = ""
    '                        Else
    '                            Email_Doc = SMSEmail_Doc.Split("^").GetValue(1).ToString
    '                            Mobile_Doc = SMSEmail_Doc.Split("^").GetValue(0).ToString
    '                        End If

    '                        OrderDT = rtxRead.Lines(i).Split("|").GetValue(6).ToString
    '                        OrderDT = DateTime.ParseExact(OrderDT, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture).ToString("yyyy-MM-dd HH:mm:ss")

    '                        'Loop through default_specimen and save to tmpresult based on test code above
    '                        For y As Integer = 0 To ListB.Items.Count - 1
    '                            If ListB.Items(y).SubItems(2).Text = "" Or ListB.Items(y).SubItems(3).Text = "" Then

    '                            Else
    '                                GetOrder(SampleID, PatientID, PatientDetails, "Other", "Test", ListB.Items(y).SubItems(2).Text, SampleID, PatientGender, PatientBDay, RoomWard, RPhysician, PatientType, ListB.Items(y).SubItems(3).Text, OrderDT)
    '                                GetPatientOrder(SampleID, ListB.Items(y).SubItems(0).Text, ListB.Items(y).SubItems(1).Text, PatientID, PatientType, ListB.Items(y).SubItems(2).Text, ListB.Items(y).SubItems(3).Text)
    '                                GetAdditionalInfo(SampleID, AdmissionNo, ChargeSlip, SampleID, ListB.Items(y).SubItems(2).Text, ListB.Items(y).SubItems(3).Text)
    '                                GetTimeReceived(SampleID, OrderDT, ListB.Items(y).SubItems(2).Text, ListB.Items(y).SubItems(3).Text)
    '                                getHIS_test(SampleID, ListB.Items(y).SubItems(0).Text, AdmissionNo, ChargeSlip)
    '                            End If
    '                        Next
    '                        '#########################################################################

    '                        GetPatient(PatientID, PatientDetails, PatientGender, PatientBDay, Email, Mobile, Address)
    '                        GetAServices()
    '                        GetDocServices()

    '                    End If

    '                Case "FS"
    '                    'LoadRecords()
    '            End Select
    '        Next
    '    End With
    'End Sub
#End Region

#Region "Toolbox Functions"
    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Close all serial ports and join all threads before closing the application

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()
            Dim query As String = $"UPDATE `comport` SET isActive = 0"
            Using command As New SQLiteCommand(query, connection)
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub mnuResult_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuResult.ItemClick
        frmResult.ShowDialog()
    End Sub

    Private Sub mnuData_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuData.ItemClick
        frmData.ShowDialog()
    End Sub

    Private Sub mnuLink_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuLink.ItemClick
        frmLink.ShowDialog()
    End Sub

    Private Sub mnuGeneral_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnuGeneral.ItemClick
        frmGeneral.ShowDialog()
    End Sub

    Private Sub btnMapping_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMapping.ItemClick
        frmSecurity.Show()
    End Sub
#End Region

End Class
