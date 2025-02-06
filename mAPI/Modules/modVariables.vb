Imports System.IO

Module modVariables
    'Write to TraceComm.log FIle
    Public CommLog As FileStream
    Public CommWriter As StreamWriter
    Public TraceComm As String = "TraceComm.log"
    'END
    Public Settings As String = "Settings.config"
    Public SettingsContent As String = ""
    Public CharControl As String
    Public nextChar As String
    Public RxTxString As String
    Public Segment As String
    Public Packet As String
    Public EndofText As Boolean = False

    'Parsed Data send by the Instrument
    'Header
    Public messageProcessingID As String
    Public messageDateTime As String
    'Patient
    Public messagePatientID As String
    Public messagePatientName As String
    Public messagePatientSex As String
    Public messagePatientDOB As String
    'Order
    Public messageAccessionNo As String
    Public messageMeasurePos As String
    Public messagePriority As String
    Public messageRequestedDT As String
    Public messageCollectionDT As String
    Public messageActionCode As String
    Public messageSpecimenType As String
    Public messageReportType As String
    'Comment
    Public messageCommentText As String
    Public messageCommentType As String
    'Result
    Public messageTestCode As String
    Public messageTestResult As String
    Public messageUnits As String
    Public messageReferenceRange As String
    Public messageFlags As String
    Public messageResultStatus As String
    Public messageResultDT As String
    'Query
    Public messageQueryDI() As String

    'Histogram
    Public messageBase64 As String
    'END

End Module
