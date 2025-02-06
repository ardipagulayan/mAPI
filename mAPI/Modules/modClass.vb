Imports System.Environment
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Xml
Imports Bluegrams.Application

Module modClass
    Public Sub GetMachineSettings()
        Dim path As String = Application.StartupPath & "\" & Settings
        Dim reader = File.OpenText(path)
        Dim line As String = Nothing
        Dim lines As Integer = 0
        SettingsContent = reader.ReadLine()
    End Sub

    Public Sub SaveMachineSettings(Machine As String, SerialNo As String)
        CommLog = New FileStream(Settings, FileMode.Create, FileAccess.Write)
        CommWriter = New StreamWriter(CommLog)
        CommWriter.WriteLine(Machine & "_" & SerialNo)
        CommWriter.Close()
        CommLog.Close()

        SettingsContent = Machine & "_" & SerialNo
        LoadSettings()
    End Sub

    Public Sub GetComPorts(ComPortsBox As DevExpress.XtraEditors.ComboBoxEdit)
        For Each COMString As String In My.Computer.Ports.SerialPortNames ' Load all available COM ports.
            ComPortsBox.Properties.Items.Add(COMString)
        Next
    End Sub

    'Create PortableSettings
    Public Sub LoadSettings()
        GetMachineSettings()
        ' Get the path to the Application Data folder
        Dim FolderPath As String = GetFolderPath(SpecialFolder.LocalApplicationData) & "\AppSupport\"

        'Create Folder
        Directory.CreateDirectory(FolderPath)

        PortableSettingsProvider.SettingsFileName = SettingsContent & ".cs"
        PortableSettingsProvider.SettingsDirectory = FolderPath
    End Sub

    Public Function StringBetweenChars(ByVal fullText, ByVal start, ByVal ending) As String
        Dim x, j As Integer
        x = fullText.IndexOf(start) + 1
        j = fullText.IndexOf(ending)
        If (j <> -1) Then
            Return fullText.Substring(x, j - x)
        Else
            Return fullText.Substring(x, fullText.Length - x)
        End If
    End Function
End Module
