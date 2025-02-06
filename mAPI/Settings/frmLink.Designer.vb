<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLink
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gcRS232 = New DevExpress.XtraEditors.GroupControl()
        Me.cboFlowControl = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cboDataBits = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.cboStopBits = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboBaudrate = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ComPortsBox = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.gcNetwork = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNetPort = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtHost = New DevExpress.XtraEditors.TextEdit()
        Me.RadioGroup = New DevExpress.XtraEditors.RadioGroup()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SeparatorControl1 = New DevExpress.XtraEditors.SeparatorControl()
        Me.gcMachine = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.txtLocation = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSection = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSerial = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMachine = New DevExpress.XtraEditors.TextEdit()
        Me.chkDirection = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.gcRS232, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcRS232.SuspendLayout()
        CType(Me.cboFlowControl.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDataBits.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboStopBits.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBaudrate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComPortsBox.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcNetwork, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcNetwork.SuspendLayout()
        CType(Me.txtNetPort.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadioGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcMachine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcMachine.SuspendLayout()
        CType(Me.txtLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMachine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDirection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gcRS232
        '
        Me.gcRS232.Controls.Add(Me.cboFlowControl)
        Me.gcRS232.Controls.Add(Me.LabelControl1)
        Me.gcRS232.Controls.Add(Me.cboDataBits)
        Me.gcRS232.Controls.Add(Me.LabelControl7)
        Me.gcRS232.Controls.Add(Me.LabelControl8)
        Me.gcRS232.Controls.Add(Me.LabelControl9)
        Me.gcRS232.Controls.Add(Me.LabelControl10)
        Me.gcRS232.Controls.Add(Me.cboStopBits)
        Me.gcRS232.Controls.Add(Me.cboBaudrate)
        Me.gcRS232.Controls.Add(Me.ComPortsBox)
        Me.gcRS232.Location = New System.Drawing.Point(12, 164)
        Me.gcRS232.Name = "gcRS232"
        Me.gcRS232.Size = New System.Drawing.Size(227, 168)
        Me.gcRS232.TabIndex = 0
        Me.gcRS232.Text = "RS232 Serial Port"
        '
        'cboFlowControl
        '
        Me.cboFlowControl.Location = New System.Drawing.Point(87, 135)
        Me.cboFlowControl.Name = "cboFlowControl"
        Me.cboFlowControl.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboFlowControl.Properties.Items.AddRange(New Object() {"NONE"})
        Me.cboFlowControl.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboFlowControl.Size = New System.Drawing.Size(120, 20)
        Me.cboFlowControl.TabIndex = 135
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Location = New System.Drawing.Point(13, 139)
        Me.LabelControl1.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl1.TabIndex = 134
        Me.LabelControl1.Text = "Flow Control:"
        '
        'cboDataBits
        '
        Me.cboDataBits.Location = New System.Drawing.Point(87, 109)
        Me.cboDataBits.Name = "cboDataBits"
        Me.cboDataBits.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboDataBits.Properties.Items.AddRange(New Object() {"5", "8"})
        Me.cboDataBits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboDataBits.Size = New System.Drawing.Size(120, 20)
        Me.cboDataBits.TabIndex = 133
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl7.Appearance.Options.UseForeColor = True
        Me.LabelControl7.Location = New System.Drawing.Point(13, 35)
        Me.LabelControl7.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl7.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl7.TabIndex = 129
        Me.LabelControl7.Text = "ComPort:"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl8.Appearance.Options.UseForeColor = True
        Me.LabelControl8.Location = New System.Drawing.Point(13, 61)
        Me.LabelControl8.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl8.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl8.TabIndex = 131
        Me.LabelControl8.Text = "Baudrate:"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl9.Appearance.Options.UseForeColor = True
        Me.LabelControl9.Location = New System.Drawing.Point(13, 113)
        Me.LabelControl9.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl9.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl9.TabIndex = 132
        Me.LabelControl9.Text = "Data Bits:"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl10.Appearance.Options.UseForeColor = True
        Me.LabelControl10.Location = New System.Drawing.Point(13, 87)
        Me.LabelControl10.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl10.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl10.TabIndex = 130
        Me.LabelControl10.Text = "Stop Bits:"
        '
        'cboStopBits
        '
        Me.cboStopBits.Location = New System.Drawing.Point(87, 83)
        Me.cboStopBits.Name = "cboStopBits"
        Me.cboStopBits.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboStopBits.Properties.Items.AddRange(New Object() {"1", "2"})
        Me.cboStopBits.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboStopBits.Size = New System.Drawing.Size(120, 20)
        Me.cboStopBits.TabIndex = 128
        '
        'cboBaudrate
        '
        Me.cboBaudrate.Location = New System.Drawing.Point(87, 57)
        Me.cboBaudrate.Name = "cboBaudrate"
        Me.cboBaudrate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboBaudrate.Properties.Items.AddRange(New Object() {"110", "300", "600", "1200", "1800", "2400", "4800", "7200", "9600", "14400", "19200", "38400", "57600", "115200", "230400", "460800", "921600"})
        Me.cboBaudrate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cboBaudrate.Size = New System.Drawing.Size(120, 20)
        Me.cboBaudrate.TabIndex = 127
        '
        'ComPortsBox
        '
        Me.ComPortsBox.Location = New System.Drawing.Point(87, 31)
        Me.ComPortsBox.Name = "ComPortsBox"
        Me.ComPortsBox.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ComPortsBox.Size = New System.Drawing.Size(120, 20)
        Me.ComPortsBox.TabIndex = 126
        '
        'gcNetwork
        '
        Me.gcNetwork.Controls.Add(Me.LabelControl3)
        Me.gcNetwork.Controls.Add(Me.txtNetPort)
        Me.gcNetwork.Controls.Add(Me.LabelControl2)
        Me.gcNetwork.Controls.Add(Me.txtHost)
        Me.gcNetwork.Enabled = False
        Me.gcNetwork.Location = New System.Drawing.Point(245, 164)
        Me.gcNetwork.Name = "gcNetwork"
        Me.gcNetwork.Size = New System.Drawing.Size(228, 168)
        Me.gcNetwork.TabIndex = 1
        Me.gcNetwork.Text = "Network"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl3.Appearance.Options.UseForeColor = True
        Me.LabelControl3.Location = New System.Drawing.Point(24, 61)
        Me.LabelControl3.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl3.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 137
        Me.LabelControl3.Text = "Port:"
        '
        'txtNetPort
        '
        Me.txtNetPort.Location = New System.Drawing.Point(73, 58)
        Me.txtNetPort.Name = "txtNetPort"
        Me.txtNetPort.Size = New System.Drawing.Size(64, 20)
        Me.txtNetPort.TabIndex = 136
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl2.Appearance.Options.UseForeColor = True
        Me.LabelControl2.Location = New System.Drawing.Point(24, 35)
        Me.LabelControl2.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl2.TabIndex = 135
        Me.LabelControl2.Text = "Server:"
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(73, 32)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(131, 20)
        Me.txtHost.TabIndex = 0
        '
        'RadioGroup
        '
        Me.RadioGroup.EditValue = True
        Me.RadioGroup.Location = New System.Drawing.Point(317, 38)
        Me.RadioGroup.Name = "RadioGroup"
        Me.RadioGroup.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.RadioGroup.Properties.Appearance.Options.UseBackColor = True
        Me.RadioGroup.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RadioGroup.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(True, "RS232", True, "RS232"), New DevExpress.XtraEditors.Controls.RadioGroupItem(False, "Network", True, "Network")})
        Me.RadioGroup.Size = New System.Drawing.Size(120, 65)
        Me.RadioGroup.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(399, 354)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(318, 354)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "&Save"
        '
        'SeparatorControl1
        '
        Me.SeparatorControl1.Location = New System.Drawing.Point(12, 326)
        Me.SeparatorControl1.Name = "SeparatorControl1"
        Me.SeparatorControl1.Size = New System.Drawing.Size(461, 28)
        Me.SeparatorControl1.TabIndex = 12
        '
        'gcMachine
        '
        Me.gcMachine.Controls.Add(Me.chkDirection)
        Me.gcMachine.Controls.Add(Me.LabelControl11)
        Me.gcMachine.Controls.Add(Me.txtLocation)
        Me.gcMachine.Controls.Add(Me.LabelControl6)
        Me.gcMachine.Controls.Add(Me.RadioGroup)
        Me.gcMachine.Controls.Add(Me.txtSection)
        Me.gcMachine.Controls.Add(Me.LabelControl4)
        Me.gcMachine.Controls.Add(Me.txtSerial)
        Me.gcMachine.Controls.Add(Me.LabelControl5)
        Me.gcMachine.Controls.Add(Me.txtMachine)
        Me.gcMachine.Location = New System.Drawing.Point(12, 12)
        Me.gcMachine.Name = "gcMachine"
        Me.gcMachine.Size = New System.Drawing.Size(461, 146)
        Me.gcMachine.TabIndex = 13
        Me.gcMachine.Text = "Machine Information"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl11.Appearance.Options.UseForeColor = True
        Me.LabelControl11.Location = New System.Drawing.Point(13, 115)
        Me.LabelControl11.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl11.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl11.TabIndex = 141
        Me.LabelControl11.Text = "Location:"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(87, 112)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(185, 20)
        Me.txtLocation.TabIndex = 140
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl6.Appearance.Options.UseForeColor = True
        Me.LabelControl6.Location = New System.Drawing.Point(13, 90)
        Me.LabelControl6.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl6.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl6.TabIndex = 139
        Me.LabelControl6.Text = "Section:"
        '
        'txtSection
        '
        Me.txtSection.Location = New System.Drawing.Point(87, 87)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(185, 20)
        Me.txtSection.TabIndex = 138
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl4.Appearance.Options.UseForeColor = True
        Me.LabelControl4.Location = New System.Drawing.Point(13, 64)
        Me.LabelControl4.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl4.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl4.TabIndex = 137
        Me.LabelControl4.Text = "Serial:"
        '
        'txtSerial
        '
        Me.txtSerial.Location = New System.Drawing.Point(87, 61)
        Me.txtSerial.Name = "txtSerial"
        Me.txtSerial.Size = New System.Drawing.Size(185, 20)
        Me.txtSerial.TabIndex = 136
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.LabelControl5.Appearance.Options.UseForeColor = True
        Me.LabelControl5.Location = New System.Drawing.Point(13, 38)
        Me.LabelControl5.LookAndFeel.SkinName = "Visual Studio 2013 Blue"
        Me.LabelControl5.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl5.TabIndex = 135
        Me.LabelControl5.Text = "Machine:"
        '
        'txtMachine
        '
        Me.txtMachine.Location = New System.Drawing.Point(87, 35)
        Me.txtMachine.Name = "txtMachine"
        Me.txtMachine.Size = New System.Drawing.Size(185, 20)
        Me.txtMachine.TabIndex = 0
        '
        'chkDirection
        '
        Me.chkDirection.Location = New System.Drawing.Point(321, 105)
        Me.chkDirection.Name = "chkDirection"
        Me.chkDirection.Properties.Caption = "Bi-Directional"
        Me.chkDirection.Size = New System.Drawing.Size(103, 19)
        Me.chkDirection.TabIndex = 142
        '
        'frmLink
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 388)
        Me.Controls.Add(Me.gcMachine)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gcNetwork)
        Me.Controls.Add(Me.gcRS232)
        Me.Controls.Add(Me.SeparatorControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLink"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Host Communication"
        CType(Me.gcRS232, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcRS232.ResumeLayout(False)
        Me.gcRS232.PerformLayout()
        CType(Me.cboFlowControl.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDataBits.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboStopBits.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBaudrate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComPortsBox.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcNetwork, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcNetwork.ResumeLayout(False)
        Me.gcNetwork.PerformLayout()
        CType(Me.txtNetPort.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadioGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SeparatorControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcMachine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcMachine.ResumeLayout(False)
        Me.gcMachine.PerformLayout()
        CType(Me.txtLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMachine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDirection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gcRS232 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gcNetwork As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cboFlowControl As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboDataBits As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboStopBits As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboBaudrate As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents ComPortsBox As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtHost As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNetPort As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RadioGroup As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SeparatorControl1 As DevExpress.XtraEditors.SeparatorControl
    Friend WithEvents gcMachine As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtLocation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSection As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSerial As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMachine As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkDirection As DevExpress.XtraEditors.CheckEdit
End Class
