<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.chbShowPeriod = New System.Windows.Forms.CheckBox()
        Me.rdbManual = New System.Windows.Forms.RadioButton()
        Me.rdbEvent = New System.Windows.Forms.RadioButton()
        Me.lstMessages = New System.Windows.Forms.ListView()
        Me.clhType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clhID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clhLength = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clhData = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clhCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.clhRcvTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.nudLength = New System.Windows.Forms.NumericUpDown()
        Me.btnMsgClear = New System.Windows.Forms.Button()
        Me.lbxInfo = New System.Windows.Forms.ListBox()
        Me.btnInfoClear = New System.Windows.Forms.Button()
        Me.groupBox5 = New System.Windows.Forms.GroupBox()
        Me.rdbTimer = New System.Windows.Forms.RadioButton()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.btnGetVersions = New System.Windows.Forms.Button()
        Me.label11 = New System.Windows.Forms.Label()
        Me.btnWrite = New System.Windows.Forms.Button()
        Me.label12 = New System.Windows.Forms.Label()
        Me.groupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btnSA = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtALLDuty = New System.Windows.Forms.TextBox()
        Me.txtALLC = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CmbENABLE = New System.Windows.Forms.ComboBox()
        Me.cmdDIO = New System.Windows.Forms.Button()
        Me.cmdPWMDIO = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtIHDC = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmdSendIH = New System.Windows.Forms.Button()
        Me.CmbIHCHN = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CmBIond = New System.Windows.Forms.ComboBox()
        Me.cmdSendBHH = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBHHDC = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CmbBHHCHN = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CmBBond = New System.Windows.Forms.ComboBox()
        Me.chbRemote = New System.Windows.Forms.CheckBox()
        Me.chbExtended = New System.Windows.Forms.CheckBox()
        Me.label13 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtData7 = New System.Windows.Forms.TextBox()
        Me.txtData6 = New System.Windows.Forms.TextBox()
        Me.txtData5 = New System.Windows.Forms.TextBox()
        Me.txtData4 = New System.Windows.Forms.TextBox()
        Me.txtData3 = New System.Windows.Forms.TextBox()
        Me.txtData2 = New System.Windows.Forms.TextBox()
        Me.txtData1 = New System.Windows.Forms.TextBox()
        Me.txtData0 = New System.Windows.Forms.TextBox()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdIHFLTCON = New System.Windows.Forms.RadioButton()
        Me.rdBBHCON = New System.Windows.Forms.RadioButton()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnStatus = New System.Windows.Forms.Button()
        Me.cbbChannel = New System.Windows.Forms.ComboBox()
        Me.rdbParamInactive = New System.Windows.Forms.RadioButton()
        Me.btnHwRefresh = New System.Windows.Forms.Button()
        Me.cbbHwType = New System.Windows.Forms.ComboBox()
        Me.cbbInterrupt = New System.Windows.Forms.ComboBox()
        Me.btnFilterQuery = New System.Windows.Forms.Button()
        Me.label5 = New System.Windows.Forms.Label()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.chbFilterExt = New System.Windows.Forms.CheckBox()
        Me.nudIdTo = New System.Windows.Forms.NumericUpDown()
        Me.nudIdFrom = New System.Windows.Forms.NumericUpDown()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.rdbFilterOpen = New System.Windows.Forms.RadioButton()
        Me.rdbFilterCustom = New System.Windows.Forms.RadioButton()
        Me.rdbFilterClose = New System.Windows.Forms.RadioButton()
        Me.btnFilterApply = New System.Windows.Forms.Button()
        Me.cbbIO = New System.Windows.Forms.ComboBox()
        Me.tmrRead = New System.Windows.Forms.Timer(Me.components)
        Me.label4 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.cbbBaudrates = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btnInit = New System.Windows.Forms.Button()
        Me.btnRelease = New System.Windows.Forms.Button()
        Me.btnParameterGet = New System.Windows.Forms.Button()
        Me.label10 = New System.Windows.Forms.Label()
        Me.nudDeviceId = New System.Windows.Forms.NumericUpDown()
        Me.label9 = New System.Windows.Forms.Label()
        Me.cbbParameter = New System.Windows.Forms.ComboBox()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.rdbParamActive = New System.Windows.Forms.RadioButton()
        Me.btnParameterSet = New System.Windows.Forms.Button()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.tmrDisplay = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataAcquisitionSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BenchVueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OscilloscopeSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.nudLength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox5.SuspendLayout()
        Me.groupBox6.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        CType(Me.nudIdTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIdFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDeviceId, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chbShowPeriod
        '
        Me.chbShowPeriod.AutoSize = True
        Me.chbShowPeriod.Location = New System.Drawing.Point(486, 14)
        Me.chbShowPeriod.Name = "chbShowPeriod"
        Me.chbShowPeriod.Size = New System.Drawing.Size(161, 19)
        Me.chbShowPeriod.TabIndex = 75
        Me.chbShowPeriod.Text = "Timestamp as period"
        Me.chbShowPeriod.UseVisualStyleBackColor = True
        '
        'rdbManual
        '
        Me.rdbManual.AutoSize = True
        Me.rdbManual.Location = New System.Drawing.Point(358, 14)
        Me.rdbManual.Name = "rdbManual"
        Me.rdbManual.Size = New System.Drawing.Size(111, 19)
        Me.rdbManual.TabIndex = 74
        Me.rdbManual.Text = "Manual Read"
        Me.rdbManual.UseVisualStyleBackColor = True
        '
        'rdbEvent
        '
        Me.rdbEvent.AutoSize = True
        Me.rdbEvent.Location = New System.Drawing.Point(164, 14)
        Me.rdbEvent.Name = "rdbEvent"
        Me.rdbEvent.Size = New System.Drawing.Size(177, 19)
        Me.rdbEvent.TabIndex = 73
        Me.rdbEvent.Text = "Reading using an Event"
        Me.rdbEvent.UseVisualStyleBackColor = True
        '
        'lstMessages
        '
        Me.lstMessages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clhType, Me.clhID, Me.clhLength, Me.clhData, Me.clhCount, Me.clhRcvTime})
        Me.lstMessages.FullRowSelect = True
        Me.lstMessages.Location = New System.Drawing.Point(0, 72)
        Me.lstMessages.MultiSelect = False
        Me.lstMessages.Name = "lstMessages"
        Me.lstMessages.Size = New System.Drawing.Size(649, 96)
        Me.lstMessages.TabIndex = 28
        Me.ToolTip1.SetToolTip(Me.lstMessages, "Displays the CAN transmits/receives")
        Me.lstMessages.UseCompatibleStateImageBehavior = False
        Me.lstMessages.View = System.Windows.Forms.View.Details
        '
        'clhType
        '
        Me.clhType.Text = "Type"
        Me.clhType.Width = 69
        '
        'clhID
        '
        Me.clhID.Text = "ID"
        Me.clhID.Width = 90
        '
        'clhLength
        '
        Me.clhLength.Text = "Length"
        Me.clhLength.Width = 50
        '
        'clhData
        '
        Me.clhData.Text = "Data"
        Me.clhData.Width = 160
        '
        'clhCount
        '
        Me.clhCount.Text = "Count"
        Me.clhCount.Width = 49
        '
        'clhRcvTime
        '
        Me.clhRcvTime.Text = "Rcv Time"
        Me.clhRcvTime.Width = 97
        '
        'nudLength
        '
        Me.nudLength.BackColor = System.Drawing.Color.White
        Me.nudLength.Location = New System.Drawing.Point(185, 76)
        Me.nudLength.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.nudLength.Name = "nudLength"
        Me.nudLength.ReadOnly = True
        Me.nudLength.Size = New System.Drawing.Size(50, 21)
        Me.nudLength.TabIndex = 21
        Me.nudLength.Value = New Decimal(New Integer() {8, 0, 0, 0})
        Me.nudLength.Visible = False
        '
        'btnMsgClear
        '
        Me.btnMsgClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMsgClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnMsgClear.Location = New System.Drawing.Point(734, 37)
        Me.btnMsgClear.Name = "btnMsgClear"
        Me.btnMsgClear.Size = New System.Drawing.Size(65, 23)
        Me.btnMsgClear.TabIndex = 50
        Me.btnMsgClear.Text = "Clear"
        Me.btnMsgClear.UseVisualStyleBackColor = True
        '
        'lbxInfo
        '
        Me.lbxInfo.FormattingEnabled = True
        Me.lbxInfo.Items.AddRange(New Object() {"Select a Hardware and a configuration for it. Then click ""Initialize"" button", "When activated, the Debug-Log file will be found in the same directory as this ap" & _
                "plication", "When activated, the PCAN-Trace file will be found in the same directory as this a" & _
                "pplication"})
        Me.lbxInfo.Location = New System.Drawing.Point(5, 855)
        Me.lbxInfo.Name = "lbxInfo"
        Me.lbxInfo.ScrollAlwaysVisible = True
        Me.lbxInfo.Size = New System.Drawing.Size(734, 95)
        Me.lbxInfo.TabIndex = 56
        '
        'btnInfoClear
        '
        Me.btnInfoClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInfoClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnInfoClear.Location = New System.Drawing.Point(734, 19)
        Me.btnInfoClear.Name = "btnInfoClear"
        Me.btnInfoClear.Size = New System.Drawing.Size(65, 23)
        Me.btnInfoClear.TabIndex = 52
        Me.btnInfoClear.Text = "Clear"
        Me.btnInfoClear.UseVisualStyleBackColor = True
        '
        'groupBox5
        '
        Me.groupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox5.Controls.Add(Me.chbShowPeriod)
        Me.groupBox5.Controls.Add(Me.rdbManual)
        Me.groupBox5.Controls.Add(Me.rdbEvent)
        Me.groupBox5.Controls.Add(Me.lstMessages)
        Me.groupBox5.Controls.Add(Me.btnMsgClear)
        Me.groupBox5.Controls.Add(Me.rdbTimer)
        Me.groupBox5.Controls.Add(Me.btnRead)
        Me.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.groupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox5.Location = New System.Drawing.Point(5, 232)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(805, 140)
        Me.groupBox5.TabIndex = 56
        Me.groupBox5.TabStop = False
        Me.groupBox5.Text = " Messages Reading "
        '
        'rdbTimer
        '
        Me.rdbTimer.AutoSize = True
        Me.rdbTimer.Location = New System.Drawing.Point(8, 14)
        Me.rdbTimer.Name = "rdbTimer"
        Me.rdbTimer.Size = New System.Drawing.Size(151, 19)
        Me.rdbTimer.TabIndex = 72
        Me.rdbTimer.Text = "Read using a Timer"
        Me.rdbTimer.UseVisualStyleBackColor = True
        '
        'btnRead
        '
        Me.btnRead.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRead.Enabled = False
        Me.btnRead.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRead.Location = New System.Drawing.Point(663, 37)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(65, 23)
        Me.btnRead.TabIndex = 49
        Me.btnRead.Text = "Read"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'btnGetVersions
        '
        Me.btnGetVersions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetVersions.Enabled = False
        Me.btnGetVersions.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnGetVersions.Location = New System.Drawing.Point(663, 19)
        Me.btnGetVersions.Name = "btnGetVersions"
        Me.btnGetVersions.Size = New System.Drawing.Size(65, 23)
        Me.btnGetVersions.TabIndex = 53
        Me.btnGetVersions.Text = "Versions"
        Me.btnGetVersions.UseVisualStyleBackColor = True
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label11.Location = New System.Drawing.Point(355, 59)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(79, 15)
        Me.label11.TabIndex = 32
        Me.label11.Text = "Data (0..7):"
        '
        'btnWrite
        '
        Me.btnWrite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWrite.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnWrite.Enabled = False
        Me.btnWrite.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnWrite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWrite.Location = New System.Drawing.Point(733, 74)
        Me.btnWrite.Name = "btnWrite"
        Me.btnWrite.Size = New System.Drawing.Size(65, 23)
        Me.btnWrite.TabIndex = 36
        Me.btnWrite.Text = "WRITE"
        Me.ToolTip1.SetToolTip(Me.btnWrite, "Manual Data Send")
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label12.Location = New System.Drawing.Point(182, 59)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(55, 15)
        Me.label12.TabIndex = 31
        Me.label12.Text = "Length:"
        '
        'groupBox6
        '
        Me.groupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox6.Controls.Add(Me.Label23)
        Me.groupBox6.Controls.Add(Me.btnSA)
        Me.groupBox6.Controls.Add(Me.Label22)
        Me.groupBox6.Controls.Add(Me.txtALLDuty)
        Me.groupBox6.Controls.Add(Me.txtALLC)
        Me.groupBox6.Controls.Add(Me.Label21)
        Me.groupBox6.Controls.Add(Me.CmbENABLE)
        Me.groupBox6.Controls.Add(Me.cmdDIO)
        Me.groupBox6.Controls.Add(Me.cmdPWMDIO)
        Me.groupBox6.Controls.Add(Me.Label20)
        Me.groupBox6.Controls.Add(Me.txtIHDC)
        Me.groupBox6.Controls.Add(Me.Label19)
        Me.groupBox6.Controls.Add(Me.Label18)
        Me.groupBox6.Controls.Add(Me.cmdSendIH)
        Me.groupBox6.Controls.Add(Me.CmbIHCHN)
        Me.groupBox6.Controls.Add(Me.Label17)
        Me.groupBox6.Controls.Add(Me.CmBIond)
        Me.groupBox6.Controls.Add(Me.cmdSendBHH)
        Me.groupBox6.Controls.Add(Me.Label16)
        Me.groupBox6.Controls.Add(Me.txtBHHDC)
        Me.groupBox6.Controls.Add(Me.Label15)
        Me.groupBox6.Controls.Add(Me.CmbBHHCHN)
        Me.groupBox6.Controls.Add(Me.Label14)
        Me.groupBox6.Controls.Add(Me.CmBBond)
        Me.groupBox6.Controls.Add(Me.chbRemote)
        Me.groupBox6.Controls.Add(Me.chbExtended)
        Me.groupBox6.Controls.Add(Me.label11)
        Me.groupBox6.Controls.Add(Me.btnWrite)
        Me.groupBox6.Controls.Add(Me.label12)
        Me.groupBox6.Controls.Add(Me.label13)
        Me.groupBox6.Controls.Add(Me.txtID)
        Me.groupBox6.Controls.Add(Me.txtData7)
        Me.groupBox6.Controls.Add(Me.txtData6)
        Me.groupBox6.Controls.Add(Me.txtData5)
        Me.groupBox6.Controls.Add(Me.txtData4)
        Me.groupBox6.Controls.Add(Me.txtData3)
        Me.groupBox6.Controls.Add(Me.txtData2)
        Me.groupBox6.Controls.Add(Me.txtData1)
        Me.groupBox6.Controls.Add(Me.txtData0)
        Me.groupBox6.Controls.Add(Me.nudLength)
        Me.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.groupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox6.Location = New System.Drawing.Point(5, 378)
        Me.groupBox6.Name = "groupBox6"
        Me.groupBox6.Size = New System.Drawing.Size(805, 394)
        Me.groupBox6.TabIndex = 57
        Me.groupBox6.TabStop = False
        Me.groupBox6.Text = "PWM CONTROL"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(10, 303)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(203, 15)
        Me.Label23.TabIndex = 62
        Me.Label23.Text = "Enter CHN/CHNS (ex. 1+Enter)"
        '
        'btnSA
        '
        Me.btnSA.Location = New System.Drawing.Point(513, 317)
        Me.btnSA.Name = "btnSA"
        Me.btnSA.Size = New System.Drawing.Size(99, 23)
        Me.btnSA.TabIndex = 61
        Me.btnSA.Text = "SEND ALL"
        Me.ToolTip1.SetToolTip(Me.btnSA, "Multi Duty Cycle change.")
        Me.btnSA.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(352, 303)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(117, 13)
        Me.Label22.TabIndex = 60
        Me.Label22.Text = "Duty Cycle(0-100%)"
        '
        'txtALLDuty
        '
        Me.txtALLDuty.Location = New System.Drawing.Point(358, 319)
        Me.txtALLDuty.Name = "txtALLDuty"
        Me.txtALLDuty.Size = New System.Drawing.Size(100, 21)
        Me.txtALLDuty.TabIndex = 59
        Me.ToolTip1.SetToolTip(Me.txtALLDuty, "Enter Duty Cycle from 0 to 100%")
        '
        'txtALLC
        '
        Me.txtALLC.Location = New System.Drawing.Point(8, 321)
        Me.txtALLC.Multiline = True
        Me.txtALLC.Name = "txtALLC"
        Me.txtALLC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtALLC.Size = New System.Drawing.Size(205, 29)
        Me.txtALLC.TabIndex = 58
        Me.ToolTip1.SetToolTip(Me.txtALLC, "Enter multiple channels by typing its true number and pressing enter. Then enter " & _
        "the desired duty cycle and press send.")
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(220, 271)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(177, 15)
        Me.Label21.TabIndex = 57
        Me.Label21.Text = "Automatic Duty Cycle Send"
        '
        'CmbENABLE
        '
        Me.CmbENABLE.FormattingEnabled = True
        Me.CmbENABLE.Items.AddRange(New Object() {"Enable Index Heater", "Enable BBH 1", "Enable BBH 2", "Enable Heater Fault 1", "Enable Heater Fault 2"})
        Me.CmbENABLE.Location = New System.Drawing.Point(325, 366)
        Me.CmbENABLE.Name = "CmbENABLE"
        Me.CmbENABLE.Size = New System.Drawing.Size(149, 23)
        Me.CmbENABLE.TabIndex = 56
        Me.CmbENABLE.Text = "Select An Enable"
        Me.ToolTip1.SetToolTip(Me.CmbENABLE, "Select Heater or Fault Pin to Enable/Disable Then press Digital I/O")
        '
        'cmdDIO
        '
        Me.cmdDIO.Location = New System.Drawing.Point(486, 365)
        Me.cmdDIO.Name = "cmdDIO"
        Me.cmdDIO.Size = New System.Drawing.Size(212, 23)
        Me.cmdDIO.TabIndex = 55
        Me.cmdDIO.Text = "DIGITAL I/O"
        Me.cmdDIO.UseVisualStyleBackColor = True
        '
        'cmdPWMDIO
        '
        Me.cmdPWMDIO.Location = New System.Drawing.Point(70, 365)
        Me.cmdPWMDIO.Name = "cmdPWMDIO"
        Me.cmdPWMDIO.Size = New System.Drawing.Size(195, 23)
        Me.cmdPWMDIO.TabIndex = 54
        Me.cmdPWMDIO.Text = "PWM DIGITAL I/O"
        Me.cmdPWMDIO.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(7, 33)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(92, 13)
        Me.Label20.TabIndex = 52
        Me.Label20.Text = "Custom Control"
        Me.Label20.UseWaitCursor = True
        '
        'txtIHDC
        '
        Me.txtIHDC.Location = New System.Drawing.Point(358, 226)
        Me.txtIHDC.Name = "txtIHDC"
        Me.txtIHDC.Size = New System.Drawing.Size(100, 21)
        Me.txtIHDC.TabIndex = 51
        Me.ToolTip1.SetToolTip(Me.txtIHDC, "Enter Duty Cycle from 0 to 100%")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(352, 206)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(117, 13)
        Me.Label19.TabIndex = 50
        Me.Label19.Text = "Duty Cycle(0-100%)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(220, 207)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 13)
        Me.Label18.TabIndex = 49
        Me.Label18.Text = "INDEX CHN"
        '
        'cmdSendIH
        '
        Me.cmdSendIH.Location = New System.Drawing.Point(512, 224)
        Me.cmdSendIH.Name = "cmdSendIH"
        Me.cmdSendIH.Size = New System.Drawing.Size(94, 23)
        Me.cmdSendIH.TabIndex = 48
        Me.cmdSendIH.Text = "SEND IH"
        Me.ToolTip1.SetToolTip(Me.cmdSendIH, "Send manual Index Heater Data")
        Me.cmdSendIH.UseVisualStyleBackColor = True
        '
        'CmbIHCHN
        '
        Me.CmbIHCHN.FormattingEnabled = True
        Me.CmbIHCHN.Items.AddRange(New Object() {"Channel 1", "Channel 2", "Channel 3", "Channel 4", "Channel 5", "Channel 6", "Channel 7", "Channel 8", "Channel 9", "Channel 10", "Channel 11", "Channel 12", "Channel 13", "Channel 14", "Channel 15", "Channel 16"})
        Me.CmbIHCHN.Location = New System.Drawing.Point(164, 223)
        Me.CmbIHCHN.Name = "CmbIHCHN"
        Me.CmbIHCHN.Size = New System.Drawing.Size(177, 23)
        Me.CmbIHCHN.TabIndex = 46
        Me.ToolTip1.SetToolTip(Me.CmbIHCHN, "Select the Index Heater Channels (0 to 15) *Note channel 0 is labled as 1")
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(10, 208)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(124, 13)
        Me.Label17.TabIndex = 45
        Me.Label17.Text = "Index Heater Control"
        '
        'CmBIond
        '
        Me.CmBIond.FormattingEnabled = True
        Me.CmBIond.Items.AddRange(New Object() {"Duty Cycle Adjust", "CAN Reset", ""})
        Me.CmBIond.Location = New System.Drawing.Point(8, 224)
        Me.CmBIond.Name = "CmBIond"
        Me.CmBIond.Size = New System.Drawing.Size(137, 23)
        Me.CmBIond.TabIndex = 44
        Me.CmBIond.Text = "Select Option"
        '
        'cmdSendBHH
        '
        Me.cmdSendBHH.Location = New System.Drawing.Point(512, 148)
        Me.cmdSendBHH.Name = "cmdSendBHH"
        Me.cmdSendBHH.Size = New System.Drawing.Size(94, 23)
        Me.cmdSendBHH.TabIndex = 43
        Me.cmdSendBHH.Text = "SEND BHH"
        Me.ToolTip1.SetToolTip(Me.cmdSendBHH, "Send manual Bond Head Heater Data")
        Me.cmdSendBHH.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(352, 130)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(117, 13)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Duty Cycle(0-100%)"
        '
        'txtBHHDC
        '
        Me.txtBHHDC.Location = New System.Drawing.Point(358, 150)
        Me.txtBHHDC.Name = "txtBHHDC"
        Me.txtBHHDC.Size = New System.Drawing.Size(100, 21)
        Me.txtBHHDC.TabIndex = 41
        Me.ToolTip1.SetToolTip(Me.txtBHHDC, "Enter Duty Cycle from 0 to 100%")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(220, 130)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "BHH CHN"
        '
        'CmbBHHCHN
        '
        Me.CmbBHHCHN.FormattingEnabled = True
        Me.CmbBHHCHN.Items.AddRange(New Object() {"Channel 1=Output 1A", "Channel 2=Output 1B", "Channel 3=Output 2A", "Channel 4=Output 2B"})
        Me.CmbBHHCHN.Location = New System.Drawing.Point(164, 149)
        Me.CmbBHHCHN.Name = "CmbBHHCHN"
        Me.CmbBHHCHN.Size = New System.Drawing.Size(177, 23)
        Me.CmbBHHCHN.TabIndex = 39
        Me.ToolTip1.SetToolTip(Me.CmbBHHCHN, "Select the Bond Head Heater Channels")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(10, 130)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(156, 13)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Bond Head Heater Control"
        '
        'CmBBond
        '
        Me.CmBBond.FormattingEnabled = True
        Me.CmBBond.Items.AddRange(New Object() {"Duty Cycle Adjust", "CAN Reset", "", ""})
        Me.CmBBond.Location = New System.Drawing.Point(10, 149)
        Me.CmBBond.Name = "CmBBond"
        Me.CmBBond.Size = New System.Drawing.Size(135, 23)
        Me.CmBBond.TabIndex = 37
        Me.CmBBond.Text = "Select Option"
        '
        'chbRemote
        '
        Me.chbRemote.Cursor = System.Windows.Forms.Cursors.Default
        Me.chbRemote.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chbRemote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbRemote.Location = New System.Drawing.Point(269, 74)
        Me.chbRemote.Name = "chbRemote"
        Me.chbRemote.Size = New System.Drawing.Size(51, 24)
        Me.chbRemote.TabIndex = 33
        Me.chbRemote.Text = "RTR"
        '
        'chbExtended
        '
        Me.chbExtended.Cursor = System.Windows.Forms.Cursors.Default
        Me.chbExtended.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.chbExtended.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbExtended.Location = New System.Drawing.Point(93, 74)
        Me.chbExtended.Name = "chbExtended"
        Me.chbExtended.Size = New System.Drawing.Size(80, 24)
        Me.chbExtended.TabIndex = 34
        Me.chbExtended.Text = "Extended"
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label13.Location = New System.Drawing.Point(6, 59)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(64, 15)
        Me.label13.TabIndex = 30
        Me.label13.Text = "ID (Hex):"
        '
        'txtID
        '
        Me.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtID.Location = New System.Drawing.Point(7, 76)
        Me.txtID.MaxLength = 3
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(80, 21)
        Me.txtID.TabIndex = 20
        Me.txtID.Text = "00000000"
        '
        'txtData7
        '
        Me.txtData7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData7.Location = New System.Drawing.Point(582, 77)
        Me.txtData7.MaxLength = 2
        Me.txtData7.Name = "txtData7"
        Me.txtData7.Size = New System.Drawing.Size(24, 21)
        Me.txtData7.TabIndex = 29
        Me.txtData7.Text = "00"
        Me.txtData7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData6
        '
        Me.txtData6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData6.Location = New System.Drawing.Point(550, 77)
        Me.txtData6.MaxLength = 2
        Me.txtData6.Name = "txtData6"
        Me.txtData6.Size = New System.Drawing.Size(24, 21)
        Me.txtData6.TabIndex = 28
        Me.txtData6.Text = "00"
        Me.txtData6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData5
        '
        Me.txtData5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData5.Location = New System.Drawing.Point(518, 77)
        Me.txtData5.MaxLength = 2
        Me.txtData5.Name = "txtData5"
        Me.txtData5.Size = New System.Drawing.Size(24, 21)
        Me.txtData5.TabIndex = 27
        Me.txtData5.Text = "00"
        Me.txtData5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData4
        '
        Me.txtData4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData4.Location = New System.Drawing.Point(486, 77)
        Me.txtData4.MaxLength = 2
        Me.txtData4.Name = "txtData4"
        Me.txtData4.Size = New System.Drawing.Size(24, 21)
        Me.txtData4.TabIndex = 26
        Me.txtData4.Text = "00"
        Me.txtData4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData3
        '
        Me.txtData3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData3.Location = New System.Drawing.Point(454, 77)
        Me.txtData3.MaxLength = 2
        Me.txtData3.Name = "txtData3"
        Me.txtData3.Size = New System.Drawing.Size(24, 21)
        Me.txtData3.TabIndex = 25
        Me.txtData3.Text = "00"
        Me.txtData3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData2
        '
        Me.txtData2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData2.Location = New System.Drawing.Point(422, 77)
        Me.txtData2.MaxLength = 2
        Me.txtData2.Name = "txtData2"
        Me.txtData2.Size = New System.Drawing.Size(24, 21)
        Me.txtData2.TabIndex = 24
        Me.txtData2.Text = "00"
        Me.txtData2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData1
        '
        Me.txtData1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData1.Location = New System.Drawing.Point(390, 77)
        Me.txtData1.MaxLength = 2
        Me.txtData1.Name = "txtData1"
        Me.txtData1.Size = New System.Drawing.Size(24, 21)
        Me.txtData1.TabIndex = 23
        Me.txtData1.Text = "00"
        Me.txtData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtData0
        '
        Me.txtData0.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtData0.Location = New System.Drawing.Point(358, 77)
        Me.txtData0.MaxLength = 2
        Me.txtData0.Name = "txtData0"
        Me.txtData0.Size = New System.Drawing.Size(24, 21)
        Me.txtData0.TabIndex = 22
        Me.txtData0.Text = "00"
        Me.txtData0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'groupBox4
        '
        Me.groupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox4.Controls.Add(Me.rdIHFLTCON)
        Me.groupBox4.Controls.Add(Me.rdBBHCON)
        Me.groupBox4.Controls.Add(Me.btnReset)
        Me.groupBox4.Controls.Add(Me.btnStatus)
        Me.groupBox4.Controls.Add(Me.btnGetVersions)
        Me.groupBox4.Controls.Add(Me.btnInfoClear)
        Me.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.groupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox4.Location = New System.Drawing.Point(5, 778)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(805, 80)
        Me.groupBox4.TabIndex = 55
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Information"
        '
        'rdIHFLTCON
        '
        Me.rdIHFLTCON.AutoCheck = False
        Me.rdIHFLTCON.AutoSize = True
        Me.rdIHFLTCON.ForeColor = System.Drawing.Color.MediumSpringGreen
        Me.rdIHFLTCON.Location = New System.Drawing.Point(291, 24)
        Me.rdIHFLTCON.Name = "rdIHFLTCON"
        Me.rdIHFLTCON.Size = New System.Drawing.Size(143, 19)
        Me.rdIHFLTCON.TabIndex = 62
        Me.rdIHFLTCON.Text = "Index Heater Fault"
        Me.ToolTip1.SetToolTip(Me.rdIHFLTCON, "Index Heater Fault is detected when RED")
        Me.rdIHFLTCON.UseVisualStyleBackColor = True
        '
        'rdBBHCON
        '
        Me.rdBBHCON.AutoSize = True
        Me.rdBBHCON.ForeColor = System.Drawing.Color.MediumSpringGreen
        Me.rdBBHCON.Location = New System.Drawing.Point(44, 24)
        Me.rdBBHCON.Name = "rdBBHCON"
        Me.rdBBHCON.Size = New System.Drawing.Size(179, 19)
        Me.rdBBHCON.TabIndex = 61
        Me.rdBBHCON.Text = "Bond Head Heater Fault"
        Me.ToolTip1.SetToolTip(Me.rdBBHCON, "Bond Head Heater1/2 Fault Deyected when RED. See below for more information.")
        Me.rdBBHCON.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReset.Enabled = False
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnReset.Location = New System.Drawing.Point(734, 48)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(65, 23)
        Me.btnReset.TabIndex = 60
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnStatus
        '
        Me.btnStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStatus.Enabled = False
        Me.btnStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnStatus.Location = New System.Drawing.Point(663, 48)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Size = New System.Drawing.Size(65, 23)
        Me.btnStatus.TabIndex = 59
        Me.btnStatus.Text = "Status"
        Me.btnStatus.UseVisualStyleBackColor = True
        '
        'cbbChannel
        '
        Me.cbbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbChannel.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbbChannel.Items.AddRange(New Object() {"None", "DNG-Channel 1", "ISA-Channel 1", "ISA-Channel 2", "ISA-Channel 3", "ISA-Channel 4", "ISA-Channel 5", "ISA-Channel 6", "ISA-Channel 7", "ISA-Channel 8", "PCC-Channel 1", "PCC-Channel 2", "PCI-Channel 1", "PCI-Channel 2", "PCI-Channel 3", "PCI-Channel 4", "PCI-Channel 5", "PCI-Channel 6", "PCI-Channel 7", "PCI-Channel 8", "USB-Channel 1", "USB-Channel 2", "USB-Channel 3", "USB-Channel 4", "USB-Channel 5", "USB-Channel 6", "USB-Channel 7", "USB-Channel 8"})
        Me.cbbChannel.Location = New System.Drawing.Point(8, 31)
        Me.cbbChannel.Name = "cbbChannel"
        Me.cbbChannel.Size = New System.Drawing.Size(119, 21)
        Me.cbbChannel.TabIndex = 32
        Me.ToolTip1.SetToolTip(Me.cbbChannel, "Hardware Type is automaticlly set for gridconnect USB/Can device but Select relea" & _
        "se to  change")
        '
        'rdbParamInactive
        '
        Me.rdbParamInactive.Location = New System.Drawing.Point(317, 31)
        Me.rdbParamInactive.Name = "rdbParamInactive"
        Me.rdbParamInactive.Size = New System.Drawing.Size(82, 17)
        Me.rdbParamInactive.TabIndex = 0
        Me.rdbParamInactive.Text = "Inactive"
        Me.rdbParamInactive.UseVisualStyleBackColor = True
        '
        'btnHwRefresh
        '
        Me.btnHwRefresh.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnHwRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnHwRefresh.Location = New System.Drawing.Point(133, 30)
        Me.btnHwRefresh.Name = "btnHwRefresh"
        Me.btnHwRefresh.Size = New System.Drawing.Size(65, 23)
        Me.btnHwRefresh.TabIndex = 45
        Me.btnHwRefresh.Text = "Refresh"
        '
        'cbbHwType
        '
        Me.cbbHwType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbHwType.Items.AddRange(New Object() {"ISA-82C200", "ISA-SJA1000", "ISA-PHYTEC", "DNG-82C200", "DNG-82C200 EPP", "DNG-SJA1000", "DNG-SJA1000 EPP"})
        Me.cbbHwType.Location = New System.Drawing.Point(326, 31)
        Me.cbbHwType.Name = "cbbHwType"
        Me.cbbHwType.Size = New System.Drawing.Size(120, 23)
        Me.cbbHwType.TabIndex = 37
        '
        'cbbInterrupt
        '
        Me.cbbInterrupt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbInterrupt.Items.AddRange(New Object() {"3", "4", "5", "7", "9", "10", "11", "12", "15"})
        Me.cbbInterrupt.Location = New System.Drawing.Point(513, 31)
        Me.cbbInterrupt.Name = "cbbInterrupt"
        Me.cbbInterrupt.Size = New System.Drawing.Size(55, 23)
        Me.cbbInterrupt.TabIndex = 39
        '
        'btnFilterQuery
        '
        Me.btnFilterQuery.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilterQuery.Enabled = False
        Me.btnFilterQuery.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFilterQuery.Location = New System.Drawing.Point(734, 26)
        Me.btnFilterQuery.Name = "btnFilterQuery"
        Me.btnFilterQuery.Size = New System.Drawing.Size(65, 23)
        Me.btnFilterQuery.TabIndex = 55
        Me.btnFilterQuery.Text = "Query"
        Me.btnFilterQuery.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(515, 15)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(80, 23)
        Me.label5.TabIndex = 44
        Me.label5.Text = "Interrupt:"
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.Controls.Add(Me.btnFilterQuery)
        Me.groupBox3.Controls.Add(Me.chbFilterExt)
        Me.groupBox3.Controls.Add(Me.nudIdTo)
        Me.groupBox3.Controls.Add(Me.nudIdFrom)
        Me.groupBox3.Controls.Add(Me.label8)
        Me.groupBox3.Controls.Add(Me.label7)
        Me.groupBox3.Controls.Add(Me.rdbFilterOpen)
        Me.groupBox3.Controls.Add(Me.rdbFilterCustom)
        Me.groupBox3.Controls.Add(Me.rdbFilterClose)
        Me.groupBox3.Controls.Add(Me.btnFilterApply)
        Me.groupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox3.Location = New System.Drawing.Point(5, 104)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(805, 58)
        Me.groupBox3.TabIndex = 53
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = " Message Filtering "
        '
        'chbFilterExt
        '
        Me.chbFilterExt.AutoSize = True
        Me.chbFilterExt.Checked = True
        Me.chbFilterExt.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbFilterExt.Location = New System.Drawing.Point(10, 33)
        Me.chbFilterExt.Name = "chbFilterExt"
        Me.chbFilterExt.Size = New System.Drawing.Size(131, 19)
        Me.chbFilterExt.TabIndex = 44
        Me.chbFilterExt.Text = "Extended Frame"
        Me.chbFilterExt.UseVisualStyleBackColor = True
        '
        'nudIdTo
        '
        Me.nudIdTo.Hexadecimal = True
        Me.nudIdTo.Location = New System.Drawing.Point(537, 29)
        Me.nudIdTo.Maximum = New Decimal(New Integer() {2047, 0, 0, 0})
        Me.nudIdTo.Name = "nudIdTo"
        Me.nudIdTo.Size = New System.Drawing.Size(69, 21)
        Me.nudIdTo.TabIndex = 6
        Me.nudIdTo.Value = New Decimal(New Integer() {2047, 0, 0, 0})
        '
        'nudIdFrom
        '
        Me.nudIdFrom.Hexadecimal = True
        Me.nudIdFrom.Location = New System.Drawing.Point(438, 29)
        Me.nudIdFrom.Maximum = New Decimal(New Integer() {536870911, 0, 0, 0})
        Me.nudIdFrom.Name = "nudIdFrom"
        Me.nudIdFrom.Size = New System.Drawing.Size(69, 21)
        Me.nudIdFrom.TabIndex = 5
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(534, 12)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(28, 23)
        Me.label8.TabIndex = 43
        Me.label8.Text = "To:"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(435, 12)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(53, 23)
        Me.label7.TabIndex = 42
        Me.label7.Text = "From:"
        '
        'rdbFilterOpen
        '
        Me.rdbFilterOpen.Location = New System.Drawing.Point(164, 26)
        Me.rdbFilterOpen.Name = "rdbFilterOpen"
        Me.rdbFilterOpen.Size = New System.Drawing.Size(68, 17)
        Me.rdbFilterOpen.TabIndex = 2
        Me.rdbFilterOpen.Text = "Open"
        Me.rdbFilterOpen.UseVisualStyleBackColor = True
        '
        'rdbFilterCustom
        '
        Me.rdbFilterCustom.Location = New System.Drawing.Point(328, 30)
        Me.rdbFilterCustom.Name = "rdbFilterCustom"
        Me.rdbFilterCustom.Size = New System.Drawing.Size(86, 17)
        Me.rdbFilterCustom.TabIndex = 1
        Me.rdbFilterCustom.Text = "Custom (expand)"
        Me.rdbFilterCustom.UseVisualStyleBackColor = True
        '
        'rdbFilterClose
        '
        Me.rdbFilterClose.Location = New System.Drawing.Point(244, 30)
        Me.rdbFilterClose.Name = "rdbFilterClose"
        Me.rdbFilterClose.Size = New System.Drawing.Size(68, 17)
        Me.rdbFilterClose.TabIndex = 0
        Me.rdbFilterClose.Text = "Close"
        Me.rdbFilterClose.UseVisualStyleBackColor = True
        '
        'btnFilterApply
        '
        Me.btnFilterApply.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilterApply.Enabled = False
        Me.btnFilterApply.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnFilterApply.Location = New System.Drawing.Point(663, 26)
        Me.btnFilterApply.Name = "btnFilterApply"
        Me.btnFilterApply.Size = New System.Drawing.Size(65, 23)
        Me.btnFilterApply.TabIndex = 44
        Me.btnFilterApply.Text = "Apply"
        Me.btnFilterApply.UseVisualStyleBackColor = True
        '
        'cbbIO
        '
        Me.cbbIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbIO.Items.AddRange(New Object() {"0100", "0120", "0140", "0200", "0220", "0240", "0260", "0278", "0280", "02A0", "02C0", "02E0", "02E8", "02F8", "0300", "0320", "0340", "0360", "0378", "0380", "03BC", "03E0", "03E8", "03F8"})
        Me.cbbIO.Location = New System.Drawing.Point(452, 31)
        Me.cbbIO.Name = "cbbIO"
        Me.cbbIO.Size = New System.Drawing.Size(55, 23)
        Me.cbbIO.TabIndex = 38
        '
        'tmrRead
        '
        Me.tmrRead.Interval = 50
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(452, 15)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(55, 23)
        Me.label4.TabIndex = 43
        Me.label4.Text = "I/O Port:"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(327, 15)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(90, 23)
        Me.label3.TabIndex = 42
        Me.label3.Text = "Hardware Type:"
        '
        'cbbBaudrates
        '
        Me.cbbBaudrates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbBaudrates.Items.AddRange(New Object() {"1 MBit/sec", "800 kBit/sec", "500 kBit/sec", "250 kBit/sec", "125 kKBit/sec", "100 kBit/sec", "95,238 kBit/sec", "83,333 kBit/sec", "50 kBit/sec", "47,619 kBit/sec", "33,333 kBit/sec", "20 kBit/sec", "10 kBit/sec", "5 kBit/sec"})
        Me.cbbBaudrates.Location = New System.Drawing.Point(204, 31)
        Me.cbbBaudrates.Name = "cbbBaudrates"
        Me.cbbBaudrates.Size = New System.Drawing.Size(116, 23)
        Me.cbbBaudrates.TabIndex = 36
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(204, 15)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(79, 23)
        Me.label2.TabIndex = 41
        Me.label2.Text = "Baudrate:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(7, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(92, 23)
        Me.label1.TabIndex = 40
        Me.label1.Text = "Hardware:"
        '
        'btnInit
        '
        Me.btnInit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInit.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnInit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnInit.Location = New System.Drawing.Point(663, 30)
        Me.btnInit.Name = "btnInit"
        Me.btnInit.Size = New System.Drawing.Size(65, 23)
        Me.btnInit.TabIndex = 34
        Me.btnInit.Text = "Initialize"
        '
        'btnRelease
        '
        Me.btnRelease.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRelease.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnRelease.Enabled = False
        Me.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRelease.Location = New System.Drawing.Point(734, 30)
        Me.btnRelease.Name = "btnRelease"
        Me.btnRelease.Size = New System.Drawing.Size(65, 23)
        Me.btnRelease.TabIndex = 35
        Me.btnRelease.Text = "Release"
        '
        'btnParameterGet
        '
        Me.btnParameterGet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnParameterGet.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnParameterGet.Location = New System.Drawing.Point(734, 26)
        Me.btnParameterGet.Name = "btnParameterGet"
        Me.btnParameterGet.Size = New System.Drawing.Size(65, 23)
        Me.btnParameterGet.TabIndex = 54
        Me.btnParameterGet.Text = "Get"
        Me.btnParameterGet.UseVisualStyleBackColor = True
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(241, 11)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(79, 23)
        Me.label10.TabIndex = 46
        Me.label10.Text = "Activation:"
        '
        'nudDeviceId
        '
        Me.nudDeviceId.Enabled = False
        Me.nudDeviceId.Location = New System.Drawing.Point(408, 29)
        Me.nudDeviceId.Maximum = New Decimal(New Integer() {-1, 0, 0, 0})
        Me.nudDeviceId.Name = "nudDeviceId"
        Me.nudDeviceId.Size = New System.Drawing.Size(99, 21)
        Me.nudDeviceId.TabIndex = 6
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(405, 12)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(59, 23)
        Me.label9.TabIndex = 45
        Me.label9.Text = "Device ID:"
        '
        'cbbParameter
        '
        Me.cbbParameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbbParameter.FormattingEnabled = True
        Me.cbbParameter.Items.AddRange(New Object() {"USB's Device Number", "USB/PC-Card's 5V Power", "Auto-reset on BUS-OFF", "CAN Listen-Only", "Debug's Log", "Receive Status", "CAN Controller Number", "Trace File", "Channel Identification (USB)"})
        Me.cbbParameter.Location = New System.Drawing.Point(10, 31)
        Me.cbbParameter.Name = "cbbParameter"
        Me.cbbParameter.Size = New System.Drawing.Size(217, 23)
        Me.cbbParameter.TabIndex = 44
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox2.Controls.Add(Me.btnParameterGet)
        Me.groupBox2.Controls.Add(Me.label10)
        Me.groupBox2.Controls.Add(Me.nudDeviceId)
        Me.groupBox2.Controls.Add(Me.label9)
        Me.groupBox2.Controls.Add(Me.cbbParameter)
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Controls.Add(Me.rdbParamActive)
        Me.groupBox2.Controls.Add(Me.rdbParamInactive)
        Me.groupBox2.Controls.Add(Me.btnParameterSet)
        Me.groupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox2.Location = New System.Drawing.Point(5, 168)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(805, 58)
        Me.groupBox2.TabIndex = 54
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = " Configuration Parameters "
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(7, 14)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(80, 23)
        Me.label6.TabIndex = 43
        Me.label6.Text = "Parameter:"
        '
        'rdbParamActive
        '
        Me.rdbParamActive.Location = New System.Drawing.Point(238, 32)
        Me.rdbParamActive.Name = "rdbParamActive"
        Me.rdbParamActive.Size = New System.Drawing.Size(73, 17)
        Me.rdbParamActive.TabIndex = 2
        Me.rdbParamActive.Text = "Active"
        Me.rdbParamActive.UseVisualStyleBackColor = True
        '
        'btnParameterSet
        '
        Me.btnParameterSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnParameterSet.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnParameterSet.Location = New System.Drawing.Point(663, 26)
        Me.btnParameterSet.Name = "btnParameterSet"
        Me.btnParameterSet.Size = New System.Drawing.Size(65, 23)
        Me.btnParameterSet.TabIndex = 46
        Me.btnParameterSet.Text = "Set"
        Me.btnParameterSet.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.btnHwRefresh)
        Me.groupBox1.Controls.Add(Me.cbbChannel)
        Me.groupBox1.Controls.Add(Me.cbbHwType)
        Me.groupBox1.Controls.Add(Me.cbbInterrupt)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.cbbIO)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.cbbBaudrates)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.btnInit)
        Me.groupBox1.Controls.Add(Me.btnRelease)
        Me.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.groupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupBox1.Location = New System.Drawing.Point(5, 33)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(805, 65)
        Me.groupBox1.TabIndex = 52
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = " Connection "
        '
        'tmrDisplay
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(815, 24)
        Me.MenuStrip1.TabIndex = 58
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.toolStripSeparator, Me.toolStripSeparator1, Me.toolStripSeparator2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.OpenToolStripMenuItem.Text = "&Open Recipe"
        Me.OpenToolStripMenuItem.ToolTipText = "Opens the recipe file for editing"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(181, 6)
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(181, 6)
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(181, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomizeToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.DataAcquisitionSetupToolStripMenuItem, Me.OscilloscopeSetupToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        Me.ToolsToolStripMenuItem.ToolTipText = "Starts the run of the current recipe file"
        '
        'CustomizeToolStripMenuItem
        '
        Me.CustomizeToolStripMenuItem.Name = "CustomizeToolStripMenuItem"
        Me.CustomizeToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.CustomizeToolStripMenuItem.Text = "&Run Recipe"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.OptionsToolStripMenuItem.Text = "&End Recipe"
        Me.OptionsToolStripMenuItem.ToolTipText = "Ends current recipe running"
        '
        'DataAcquisitionSetupToolStripMenuItem
        '
        Me.DataAcquisitionSetupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BenchVueToolStripMenuItem})
        Me.DataAcquisitionSetupToolStripMenuItem.Name = "DataAcquisitionSetupToolStripMenuItem"
        Me.DataAcquisitionSetupToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.DataAcquisitionSetupToolStripMenuItem.Text = "Data Acquisition Setup"
        Me.DataAcquisitionSetupToolStripMenuItem.ToolTipText = "Opens program to record DAQ measurments if installed"
        '
        'BenchVueToolStripMenuItem
        '
        Me.BenchVueToolStripMenuItem.Name = "BenchVueToolStripMenuItem"
        Me.BenchVueToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.BenchVueToolStripMenuItem.Text = "KeySight BenchVue"
        '
        'OscilloscopeSetupToolStripMenuItem
        '
        Me.OscilloscopeSetupToolStripMenuItem.Name = "OscilloscopeSetupToolStripMenuItem"
        Me.OscilloscopeSetupToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.OscilloscopeSetupToolStripMenuItem.Text = "Oscilloscope Setup"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.toolStripSeparator5, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ContentsToolStripMenuItem.Text = "&Contents"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.IndexToolStripMenuItem.Text = "&Index"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SearchToolStripMenuItem.Text = "&Search"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(149, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 952)
        Me.Controls.Add(Me.groupBox5)
        Me.Controls.Add(Me.groupBox6)
        Me.Controls.Add(Me.groupBox4)
        Me.Controls.Add(Me.lbxInfo)
        Me.Controls.Add(Me.groupBox3)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "K&S PWM Controller"
        CType(Me.nudLength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        Me.groupBox6.ResumeLayout(False)
        Me.groupBox6.PerformLayout()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        CType(Me.nudIdTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIdFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDeviceId, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents chbShowPeriod As System.Windows.Forms.CheckBox
    Private WithEvents rdbManual As System.Windows.Forms.RadioButton
    Private WithEvents rdbEvent As System.Windows.Forms.RadioButton
    Private WithEvents lstMessages As System.Windows.Forms.ListView
    Private WithEvents clhType As System.Windows.Forms.ColumnHeader
    Private WithEvents clhID As System.Windows.Forms.ColumnHeader
    Private WithEvents clhLength As System.Windows.Forms.ColumnHeader
    Private WithEvents clhData As System.Windows.Forms.ColumnHeader
    Private WithEvents clhCount As System.Windows.Forms.ColumnHeader
    Private WithEvents clhRcvTime As System.Windows.Forms.ColumnHeader
    Private WithEvents nudLength As System.Windows.Forms.NumericUpDown
    Private WithEvents btnMsgClear As System.Windows.Forms.Button
    Private WithEvents lbxInfo As System.Windows.Forms.ListBox
    Private WithEvents btnInfoClear As System.Windows.Forms.Button
    Private WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents rdbTimer As System.Windows.Forms.RadioButton
    Private WithEvents btnRead As System.Windows.Forms.Button
    Private WithEvents btnGetVersions As System.Windows.Forms.Button
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents btnWrite As System.Windows.Forms.Button
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents groupBox6 As System.Windows.Forms.GroupBox
    Private WithEvents chbRemote As System.Windows.Forms.CheckBox
    Private WithEvents chbExtended As System.Windows.Forms.CheckBox
    Private WithEvents label13 As System.Windows.Forms.Label
    Public WithEvents txtID As System.Windows.Forms.TextBox
    Public WithEvents txtData7 As System.Windows.Forms.TextBox
    Public WithEvents txtData6 As System.Windows.Forms.TextBox
    Public WithEvents txtData5 As System.Windows.Forms.TextBox
    Public WithEvents txtData4 As System.Windows.Forms.TextBox
    Public WithEvents txtData3 As System.Windows.Forms.TextBox
    Public WithEvents txtData2 As System.Windows.Forms.TextBox
    Public WithEvents txtData1 As System.Windows.Forms.TextBox
    Public WithEvents txtData0 As System.Windows.Forms.TextBox
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents cbbChannel As System.Windows.Forms.ComboBox
    Private WithEvents rdbParamInactive As System.Windows.Forms.RadioButton
    Private WithEvents btnHwRefresh As System.Windows.Forms.Button
    Private WithEvents cbbHwType As System.Windows.Forms.ComboBox
    Private WithEvents cbbInterrupt As System.Windows.Forms.ComboBox
    Private WithEvents btnFilterQuery As System.Windows.Forms.Button
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents chbFilterExt As System.Windows.Forms.CheckBox
    Private WithEvents nudIdTo As System.Windows.Forms.NumericUpDown
    Private WithEvents nudIdFrom As System.Windows.Forms.NumericUpDown
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents rdbFilterOpen As System.Windows.Forms.RadioButton
    Private WithEvents rdbFilterCustom As System.Windows.Forms.RadioButton
    Private WithEvents rdbFilterClose As System.Windows.Forms.RadioButton
    Private WithEvents btnFilterApply As System.Windows.Forms.Button
    Private WithEvents cbbIO As System.Windows.Forms.ComboBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents cbbBaudrates As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnInit As System.Windows.Forms.Button
    Private WithEvents btnRelease As System.Windows.Forms.Button
    Private WithEvents btnParameterGet As System.Windows.Forms.Button
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents nudDeviceId As System.Windows.Forms.NumericUpDown
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents cbbParameter As System.Windows.Forms.ComboBox
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents rdbParamActive As System.Windows.Forms.RadioButton
    Private WithEvents btnParameterSet As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents tmrRead As System.Windows.Forms.Timer
    Private WithEvents btnReset As System.Windows.Forms.Button
    Private WithEvents btnStatus As System.Windows.Forms.Button
    Private WithEvents tmrDisplay As System.Windows.Forms.Timer
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CmBBond As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBHHDC As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CmbBHHCHN As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSendBHH As System.Windows.Forms.Button
    Friend WithEvents cmdSendIH As System.Windows.Forms.Button
    Friend WithEvents CmbIHCHN As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CmBIond As System.Windows.Forms.ComboBox
    Friend WithEvents txtIHDC As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmdDIO As System.Windows.Forms.Button
    Friend WithEvents cmdPWMDIO As System.Windows.Forms.Button
    Friend WithEvents rdIHFLTCON As System.Windows.Forms.RadioButton
    Friend WithEvents rdBBHCON As System.Windows.Forms.RadioButton
    Friend WithEvents CmbENABLE As System.Windows.Forms.ComboBox
    Friend WithEvents txtALLC As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtALLDuty As System.Windows.Forms.TextBox
    Friend WithEvents btnSA As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataAcquisitionSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OscilloscopeSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BenchVueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
