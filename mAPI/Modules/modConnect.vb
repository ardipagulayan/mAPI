Imports System.Data.SQLite
Imports MySql.Data.MySqlClient

Module modConnect
#Region "SQLite"
    Public conn As New SQLiteConnection
    Public rs As New SQLiteCommand
    Public reader As SQLiteDataReader

    Public appPath As String = Application.StartupPath & "\" & "mdb.db"
    Public connectionString As String = $"Data Source = {appPath}; Integrated Security = true"

    Public Sub Connect()
        conn.ConnectionString = $"Data Source = {appPath}; Integrated Security = true"
        conn.Open()
    End Sub

    Public Sub Disconnect()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub
#End Region

#Region "MySQL"
    Public my_conn As New MySqlConnection
    Public my_rs As New MySqlCommand
    Public my_reader As MySqlDataReader

    Public Sub my_Connect()
        my_conn.ConnectionString = My.Settings.ConnectionString
        my_conn.Open()
    End Sub

    Public Sub my_Disconnect()
        If my_conn.State = ConnectionState.Open Then
            my_conn.Close()
        End If
    End Sub
#End Region
End Module
