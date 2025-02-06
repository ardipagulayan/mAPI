<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.btnFile = New DevExpress.XtraBars.BarSubItem()
        Me.mnuResult = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuWorklist = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuExit = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuLog = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarSubItem3 = New DevExpress.XtraBars.BarSubItem()
        Me.mnuGeneral = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuData = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuLink = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMapping = New DevExpress.XtraBars.BarButtonItem()
        Me.Bar3 = New DevExpress.XtraBars.Bar()
        Me.btnLabel = New DevExpress.XtraBars.BarStaticItem()
        Me.btnStart = New DevExpress.XtraBars.BarButtonItem()
        Me.btnStop = New DevExpress.XtraBars.BarButtonItem()
        Me.txtMachine = New DevExpress.XtraBars.BarStaticItem()
        Me.txtSerial = New DevExpress.XtraBars.BarStaticItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarSubItem2 = New DevExpress.XtraBars.BarSubItem()
        Me.GroupControl = New DevExpress.XtraEditors.GroupControl()
        Me.GridControl = New DevExpress.XtraGrid.GridControl()
        Me.GridView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GridControlNetwork = New DevExpress.XtraGrid.GridControl()
        Me.GridViewNetwork = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl.SuspendLayout()
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GridControlNetwork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewNetwork, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2, Me.Bar3})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnFile, Me.BarSubItem2, Me.mnuResult, Me.mnuWorklist, Me.mnuExit, Me.btnLabel, Me.btnStart, Me.btnStop, Me.mnuLog, Me.BarSubItem3, Me.BarButtonItem3, Me.mnuGeneral, Me.mnuData, Me.mnuLink, Me.txtMachine, Me.txtSerial, Me.btnMapping})
        Me.BarManager.MainMenu = Me.Bar2
        Me.BarManager.MaxItemId = 26
        Me.BarManager.StatusBar = Me.Bar3
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.FloatLocation = New System.Drawing.Point(388, 145)
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnFile), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuLog), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem3)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'btnFile
        '
        Me.btnFile.Caption = "File"
        Me.btnFile.Id = 0
        Me.btnFile.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.mnuResult), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuWorklist), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.mnuExit, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.btnFile.Name = "btnFile"
        '
        'mnuResult
        '
        Me.mnuResult.Caption = "Result"
        Me.mnuResult.Id = 8
        Me.mnuResult.Name = "mnuResult"
        '
        'mnuWorklist
        '
        Me.mnuWorklist.Caption = "Worklist"
        Me.mnuWorklist.Id = 9
        Me.mnuWorklist.Name = "mnuWorklist"
        '
        'mnuExit
        '
        Me.mnuExit.Caption = "Exit"
        Me.mnuExit.Id = 10
        Me.mnuExit.ImageOptions.Image = CType(resources.GetObject("mnuExit.ImageOptions.Image"), System.Drawing.Image)
        Me.mnuExit.ImageOptions.LargeImage = CType(resources.GetObject("mnuExit.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.mnuExit.Name = "mnuExit"
        '
        'mnuLog
        '
        Me.mnuLog.Caption = "View"
        Me.mnuLog.Id = 17
        Me.mnuLog.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem3)})
        Me.mnuLog.Name = "mnuLog"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Log File"
        Me.BarButtonItem3.Id = 19
        Me.BarButtonItem3.ImageOptions.Image = CType(resources.GetObject("BarButtonItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.BarButtonItem3.ImageOptions.LargeImage = CType(resources.GetObject("BarButtonItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarSubItem3
        '
        Me.BarSubItem3.Caption = "Settings"
        Me.BarSubItem3.Id = 18
        Me.BarSubItem3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.mnuGeneral), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuData), New DevExpress.XtraBars.LinkPersistInfo(Me.mnuLink), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.btnMapping, "", True, True, True, 0, Nothing, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.BarSubItem3.Name = "BarSubItem3"
        '
        'mnuGeneral
        '
        Me.mnuGeneral.Caption = "Configuration"
        Me.mnuGeneral.Id = 20
        Me.mnuGeneral.ImageOptions.Image = CType(resources.GetObject("mnuGeneral.ImageOptions.Image"), System.Drawing.Image)
        Me.mnuGeneral.ImageOptions.LargeImage = CType(resources.GetObject("mnuGeneral.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.mnuGeneral.Name = "mnuGeneral"
        '
        'mnuData
        '
        Me.mnuData.Caption = "Data Link"
        Me.mnuData.Id = 21
        Me.mnuData.ImageOptions.Image = CType(resources.GetObject("mnuData.ImageOptions.Image"), System.Drawing.Image)
        Me.mnuData.ImageOptions.LargeImage = CType(resources.GetObject("mnuData.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.mnuData.Name = "mnuData"
        '
        'mnuLink
        '
        Me.mnuLink.Caption = "Host Communication"
        Me.mnuLink.Id = 22
        Me.mnuLink.ImageOptions.Image = CType(resources.GetObject("mnuLink.ImageOptions.Image"), System.Drawing.Image)
        Me.mnuLink.ImageOptions.LargeImage = CType(resources.GetObject("mnuLink.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.mnuLink.Name = "mnuLink"
        '
        'btnMapping
        '
        Me.btnMapping.Caption = "Test Mapping"
        Me.btnMapping.Id = 25
        Me.btnMapping.ImageOptions.Image = CType(resources.GetObject("btnMapping.ImageOptions.Image"), System.Drawing.Image)
        Me.btnMapping.ImageOptions.LargeImage = CType(resources.GetObject("btnMapping.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnMapping.Name = "btnMapping"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnLabel), New DevExpress.XtraBars.LinkPersistInfo(Me.btnStart), New DevExpress.XtraBars.LinkPersistInfo(Me.btnStop, True), New DevExpress.XtraBars.LinkPersistInfo(Me.txtMachine), New DevExpress.XtraBars.LinkPersistInfo(Me.txtSerial)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'btnLabel
        '
        Me.btnLabel.Caption = "Listening..."
        Me.btnLabel.Id = 12
        Me.btnLabel.Name = "btnLabel"
        '
        'btnStart
        '
        Me.btnStart.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.btnStart.Caption = "Start"
        Me.btnStart.Id = 13
        Me.btnStart.ImageOptions.SvgImage = CType(resources.GetObject("btnStart.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnStart.Name = "btnStart"
        '
        'btnStop
        '
        Me.btnStop.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.btnStop.Caption = "Stop"
        Me.btnStop.Id = 14
        Me.btnStop.ImageOptions.SvgImage = CType(resources.GetObject("btnStop.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnStop.Name = "btnStop"
        '
        'txtMachine
        '
        Me.txtMachine.Caption = "G800"
        Me.txtMachine.Id = 23
        Me.txtMachine.Name = "txtMachine"
        '
        'txtSerial
        '
        Me.txtSerial.Caption = "000000"
        Me.txtSerial.Id = 24
        Me.txtSerial.Name = "txtSerial"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager
        Me.barDockControlTop.Size = New System.Drawing.Size(878, 20)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 508)
        Me.barDockControlBottom.Manager = Me.BarManager
        Me.barDockControlBottom.Size = New System.Drawing.Size(878, 27)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 20)
        Me.barDockControlLeft.Manager = Me.BarManager
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 488)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(878, 20)
        Me.barDockControlRight.Manager = Me.BarManager
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 488)
        '
        'BarSubItem2
        '
        Me.BarSubItem2.Caption = "BarSubItem2"
        Me.BarSubItem2.Id = 1
        Me.BarSubItem2.Name = "BarSubItem2"
        '
        'GroupControl
        '
        Me.GroupControl.Controls.Add(Me.GridControl)
        Me.GroupControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl.Location = New System.Drawing.Point(0, 20)
        Me.GroupControl.Name = "GroupControl"
        Me.GroupControl.Size = New System.Drawing.Size(878, 229)
        Me.GroupControl.TabIndex = 4
        Me.GroupControl.Text = "Serial Port List"
        '
        'GridControl
        '
        Me.GridControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl.Location = New System.Drawing.Point(2, 20)
        Me.GridControl.MainView = Me.GridView
        Me.GridControl.MenuManager = Me.BarManager
        Me.GridControl.Name = "GridControl"
        Me.GridControl.Size = New System.Drawing.Size(874, 207)
        Me.GridControl.TabIndex = 0
        Me.GridControl.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView})
        '
        'GridView
        '
        Me.GridView.GridControl = Me.GridControl
        Me.GridView.Name = "GridView"
        Me.GridView.OptionsView.ShowGroupPanel = False
        '
        'PopupMenu1
        '
        Me.PopupMenu1.Manager = Me.BarManager
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GridControlNetwork)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 249)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(878, 259)
        Me.GroupControl1.TabIndex = 9
        Me.GroupControl1.Text = "Network List"
        '
        'GridControlNetwork
        '
        Me.GridControlNetwork.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlNetwork.Location = New System.Drawing.Point(2, 20)
        Me.GridControlNetwork.MainView = Me.GridViewNetwork
        Me.GridControlNetwork.MenuManager = Me.BarManager
        Me.GridControlNetwork.Name = "GridControlNetwork"
        Me.GridControlNetwork.Size = New System.Drawing.Size(874, 237)
        Me.GridControlNetwork.TabIndex = 0
        Me.GridControlNetwork.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewNetwork})
        '
        'GridViewNetwork
        '
        Me.GridViewNetwork.GridControl = Me.GridControlNetwork
        Me.GridViewNetwork.Name = "GridViewNetwork"
        Me.GridViewNetwork.OptionsView.ShowGroupPanel = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 535)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GroupControl)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Machine Manager"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl.ResumeLayout(False)
        CType(Me.GridControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GridControlNetwork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewNetwork, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents BarSubItem2 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents btnFile As DevExpress.XtraBars.BarSubItem
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents mnuResult As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuWorklist As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuExit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnLabel As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents btnStart As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnStop As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GroupControl As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents mnuLog As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarSubItem3 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuGeneral As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuData As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuLink As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txtMachine As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents txtSerial As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents GridControl As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridControlNetwork As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewNetwork As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnMapping As DevExpress.XtraBars.BarButtonItem
End Class
