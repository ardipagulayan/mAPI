<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGeneral
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
        Me.gcMachine = New DevExpress.XtraEditors.GroupControl()
        Me.txtSerialNo = New DevExpress.XtraEditors.TextEdit()
        Me.txtMachine = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.chkAutoFetch = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.gcMachine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcMachine.SuspendLayout()
        CType(Me.txtSerialNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMachine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAutoFetch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gcMachine
        '
        Me.gcMachine.Controls.Add(Me.txtSerialNo)
        Me.gcMachine.Controls.Add(Me.txtMachine)
        Me.gcMachine.Controls.Add(Me.LabelControl2)
        Me.gcMachine.Controls.Add(Me.LabelControl1)
        Me.gcMachine.Location = New System.Drawing.Point(12, 12)
        Me.gcMachine.Name = "gcMachine"
        Me.gcMachine.Size = New System.Drawing.Size(305, 96)
        Me.gcMachine.TabIndex = 0
        Me.gcMachine.Text = "Machine Details"
        '
        'txtSerialNo
        '
        Me.txtSerialNo.Location = New System.Drawing.Point(84, 61)
        Me.txtSerialNo.Name = "txtSerialNo"
        Me.txtSerialNo.Size = New System.Drawing.Size(213, 20)
        Me.txtSerialNo.TabIndex = 9
        '
        'txtMachine
        '
        Me.txtMachine.Location = New System.Drawing.Point(84, 35)
        Me.txtMachine.Name = "txtMachine"
        Me.txtMachine.Size = New System.Drawing.Size(213, 20)
        Me.txtMachine.TabIndex = 8
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(5, 68)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl2.TabIndex = 7
        Me.LabelControl2.Text = "Serial No.:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(5, 42)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl1.TabIndex = 6
        Me.LabelControl1.Text = "Machine Name:"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(242, 114)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(161, 114)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "&Save"
        '
        'chkAutoFetch
        '
        Me.chkAutoFetch.Location = New System.Drawing.Point(12, 165)
        Me.chkAutoFetch.Name = "chkAutoFetch"
        Me.chkAutoFetch.Properties.Caption = "Auto Fetch Orders"
        Me.chkAutoFetch.Size = New System.Drawing.Size(148, 19)
        Me.chkAutoFetch.TabIndex = 15
        '
        'frmGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(327, 236)
        Me.Controls.Add(Me.chkAutoFetch)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gcMachine)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGeneral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "General Configuration"
        CType(Me.gcMachine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcMachine.ResumeLayout(False)
        Me.gcMachine.PerformLayout()
        CType(Me.txtSerialNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMachine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAutoFetch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gcMachine As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtSerialNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMachine As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkAutoFetch As DevExpress.XtraEditors.CheckEdit
End Class
