Imports System.Data.SQLite
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmResult
    Private Sub frmResult_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim SQL As String = "SELECT * FROM `result`"
        Connect()
        Dim command As New SQLiteCommand(SQL, conn)

        Dim adapter As New SQLiteDataAdapter(command)

        Dim myTable As DataTable = New DataTable
        adapter.Fill(myTable)

        dtResult.DataSource = myTable

        ' Make the grid read-only. 
        GridView.OptionsBehavior.Editable = False
        ' Prevent the focused cell from being highlighted. 
        GridView.OptionsSelection.EnableAppearanceFocusedCell = False
        ' Draw a dotted focus rectangle around the entire row. 
        GridView.FocusRectStyle = DrawFocusRectStyle.RowFullFocus

        Disconnect()
    End Sub

End Class