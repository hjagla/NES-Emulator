<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Me.picScreen = New System.Windows.Forms.PictureBox()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFile_Open = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_File_Close = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_File_ROMInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Emulation = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Emulation_Pause = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Video = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Video_Enabled = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Video_RenderEngine = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Video_Render_Line = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Video_Render_Tile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Video_Scale = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Video_Scale_1X = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Video_Scale_2X = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Video_Scale_3X = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Video_ShowBG = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Video_ShowSprites = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Video_ShowGrid = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Debug = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Debug_Enabled = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Input = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Input_Keys = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Input_Keys_Up = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Input_Keys_Down = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Input_Keys_Left = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Input_Keys_Right = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Input_Keys_Start = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Input_Keys_Select = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Input_Keys_A = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain_Input_Keys_B = New System.Windows.Forms.ToolStripMenuItem()
        Me.dlgOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.tmrMonitor = New System.Windows.Forms.Timer(Me.components)
        Me.grp6502 = New System.Windows.Forms.GroupBox()
        Me.lblCPU_Cycle = New System.Windows.Forms.Label()
        Me.lblCPU_IRQ = New System.Windows.Forms.Label()
        Me.lblCPU_NMI = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl6500_FLBits = New System.Windows.Forms.Label()
        Me.lbl6500_FL = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl6500_PC = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl6500_SP = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl6500_Y = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl6500_X = New System.Windows.Forms.Label()
        Me.lbl6500_A = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grpMemory = New System.Windows.Forms.GroupBox()
        Me.cboMemoryType = New System.Windows.Forms.ComboBox()
        Me.cboMemory = New System.Windows.Forms.ComboBox()
        Me.cboMemorySec = New System.Windows.Forms.ComboBox()
        Me.lstMemory = New System.Windows.Forms.ListBox()
        Me.tmrSpeed = New System.Windows.Forms.Timer(Me.components)
        Me.grpPalette = New System.Windows.Forms.GroupBox()
        Me.lblPalette31 = New System.Windows.Forms.Label()
        Me.lblPalette30 = New System.Windows.Forms.Label()
        Me.lblPalette29 = New System.Windows.Forms.Label()
        Me.lblPalette28 = New System.Windows.Forms.Label()
        Me.lblPalette27 = New System.Windows.Forms.Label()
        Me.lblPalette26 = New System.Windows.Forms.Label()
        Me.lblPalette25 = New System.Windows.Forms.Label()
        Me.lblPalette24 = New System.Windows.Forms.Label()
        Me.lblPalette23 = New System.Windows.Forms.Label()
        Me.lblPalette22 = New System.Windows.Forms.Label()
        Me.lblPalette21 = New System.Windows.Forms.Label()
        Me.lblPalette20 = New System.Windows.Forms.Label()
        Me.lblPalette19 = New System.Windows.Forms.Label()
        Me.lblPalette18 = New System.Windows.Forms.Label()
        Me.lblPalette17 = New System.Windows.Forms.Label()
        Me.lblPalette16 = New System.Windows.Forms.Label()
        Me.lblPalette15 = New System.Windows.Forms.Label()
        Me.lblPalette14 = New System.Windows.Forms.Label()
        Me.lblPalette13 = New System.Windows.Forms.Label()
        Me.lblPalette12 = New System.Windows.Forms.Label()
        Me.lblPalette11 = New System.Windows.Forms.Label()
        Me.lblPalette10 = New System.Windows.Forms.Label()
        Me.lblPalette9 = New System.Windows.Forms.Label()
        Me.lblPalette8 = New System.Windows.Forms.Label()
        Me.lblPalette7 = New System.Windows.Forms.Label()
        Me.lblPalette6 = New System.Windows.Forms.Label()
        Me.lblPalette5 = New System.Windows.Forms.Label()
        Me.lblPalette4 = New System.Windows.Forms.Label()
        Me.lblPalette3 = New System.Windows.Forms.Label()
        Me.lblPalette2 = New System.Windows.Forms.Label()
        Me.lblPalette1 = New System.Windows.Forms.Label()
        Me.lblPalette0 = New System.Windows.Forms.Label()
        Me.lblPPUFPS = New System.Windows.Forms.Label()
        Me.lblRenderFPS = New System.Windows.Forms.Label()
        Me.tbcDebug = New System.Windows.Forms.TabControl()
        Me.tabCPU = New System.Windows.Forms.TabPage()
        Me.tabMemory = New System.Windows.Forms.TabPage()
        Me.tabPPU = New System.Windows.Forms.TabPage()
        Me.lvwSprites = New System.Windows.Forms.ListView()
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Tile = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Line = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Pixel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Attributes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tabAPU = New System.Windows.Forms.TabPage()
        Me.grpController2 = New System.Windows.Forms.GroupBox()
        Me.lblCTRL2_A = New System.Windows.Forms.Label()
        Me.lblCTRL2_B = New System.Windows.Forms.Label()
        Me.lblCTRL2_Start = New System.Windows.Forms.Label()
        Me.lblCTRL2_Select = New System.Windows.Forms.Label()
        Me.lblCTRL2_Down = New System.Windows.Forms.Label()
        Me.lblCTRL2_Right = New System.Windows.Forms.Label()
        Me.lblCTRL2_Left = New System.Windows.Forms.Label()
        Me.lblCTRL2_Up = New System.Windows.Forms.Label()
        Me.grpController1 = New System.Windows.Forms.GroupBox()
        Me.lblCTRL1_A = New System.Windows.Forms.Label()
        Me.lblCTRL1_B = New System.Windows.Forms.Label()
        Me.lblCTRL1_Start = New System.Windows.Forms.Label()
        Me.lblCTRL1_Select = New System.Windows.Forms.Label()
        Me.lblCTRL1_Down = New System.Windows.Forms.Label()
        Me.lblCTRL1_Right = New System.Windows.Forms.Label()
        Me.lblCTRL1_Left = New System.Windows.Forms.Label()
        Me.lblCTRL1_Up = New System.Windows.Forms.Label()
        Me.grpDebug = New System.Windows.Forms.GroupBox()
        CType(Me.picScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuMain.SuspendLayout()
        Me.grp6502.SuspendLayout()
        Me.grpMemory.SuspendLayout()
        Me.grpPalette.SuspendLayout()
        Me.tbcDebug.SuspendLayout()
        Me.tabCPU.SuspendLayout()
        Me.tabMemory.SuspendLayout()
        Me.tabPPU.SuspendLayout()
        Me.tabAPU.SuspendLayout()
        Me.grpController2.SuspendLayout()
        Me.grpController1.SuspendLayout()
        Me.grpDebug.SuspendLayout()
        Me.SuspendLayout()
        '
        'picScreen
        '
        Me.picScreen.BackColor = System.Drawing.Color.Black
        Me.picScreen.Location = New System.Drawing.Point(0, 27)
        Me.picScreen.Name = "picScreen"
        Me.picScreen.Size = New System.Drawing.Size(256, 240)
        Me.picScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picScreen.TabIndex = 0
        Me.picScreen.TabStop = False
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuMain_Emulation, Me.mnuMain_Video, Me.mnuMain_Debug, Me.mnuMain_Input})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(902, 24)
        Me.mnuMain.TabIndex = 1
        Me.mnuMain.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile_Open, Me.mnuMain_File_Close, Me.mnuMain_File_ROMInfo})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuFile_Open
        '
        Me.mnuFile_Open.Name = "mnuFile_Open"
        Me.mnuFile_Open.Size = New System.Drawing.Size(165, 22)
        Me.mnuFile_Open.Text = "&Open"
        '
        'mnuMain_File_Close
        '
        Me.mnuMain_File_Close.Name = "mnuMain_File_Close"
        Me.mnuMain_File_Close.Size = New System.Drawing.Size(165, 22)
        Me.mnuMain_File_Close.Text = "&Close"
        '
        'mnuMain_File_ROMInfo
        '
        Me.mnuMain_File_ROMInfo.Name = "mnuMain_File_ROMInfo"
        Me.mnuMain_File_ROMInfo.Size = New System.Drawing.Size(165, 22)
        Me.mnuMain_File_ROMInfo.Text = "Rom Information"
        '
        'mnuMain_Emulation
        '
        Me.mnuMain_Emulation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMain_Emulation_Pause})
        Me.mnuMain_Emulation.Name = "mnuMain_Emulation"
        Me.mnuMain_Emulation.Size = New System.Drawing.Size(73, 20)
        Me.mnuMain_Emulation.Text = "Emulation"
        '
        'mnuMain_Emulation_Pause
        '
        Me.mnuMain_Emulation_Pause.Name = "mnuMain_Emulation_Pause"
        Me.mnuMain_Emulation_Pause.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mnuMain_Emulation_Pause.Size = New System.Drawing.Size(131, 22)
        Me.mnuMain_Emulation_Pause.Text = "Paused"
        '
        'mnuMain_Video
        '
        Me.mnuMain_Video.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMain_Video_Enabled, Me.mnuMain_Video_RenderEngine, Me.mnuMain_Video_Scale, Me.mnuMain_Video_ShowBG, Me.mnuMain_Video_ShowSprites, Me.mnuMain_Video_ShowGrid})
        Me.mnuMain_Video.Name = "mnuMain_Video"
        Me.mnuMain_Video.Size = New System.Drawing.Size(49, 20)
        Me.mnuMain_Video.Text = "Video"
        '
        'mnuMain_Video_Enabled
        '
        Me.mnuMain_Video_Enabled.Name = "mnuMain_Video_Enabled"
        Me.mnuMain_Video_Enabled.Size = New System.Drawing.Size(170, 22)
        Me.mnuMain_Video_Enabled.Text = "Enabled"
        '
        'mnuMain_Video_RenderEngine
        '
        Me.mnuMain_Video_RenderEngine.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMain_Video_Render_Line, Me.mnuMain_Video_Render_Tile})
        Me.mnuMain_Video_RenderEngine.Name = "mnuMain_Video_RenderEngine"
        Me.mnuMain_Video_RenderEngine.Size = New System.Drawing.Size(170, 22)
        Me.mnuMain_Video_RenderEngine.Text = "Render Engine"
        '
        'mnuMain_Video_Render_Line
        '
        Me.mnuMain_Video_Render_Line.Name = "mnuMain_Video_Render_Line"
        Me.mnuMain_Video_Render_Line.Size = New System.Drawing.Size(130, 22)
        Me.mnuMain_Video_Render_Line.Text = "Line Based"
        '
        'mnuMain_Video_Render_Tile
        '
        Me.mnuMain_Video_Render_Tile.Name = "mnuMain_Video_Render_Tile"
        Me.mnuMain_Video_Render_Tile.Size = New System.Drawing.Size(130, 22)
        Me.mnuMain_Video_Render_Tile.Text = "Tile Based"
        '
        'mnuMain_Video_Scale
        '
        Me.mnuMain_Video_Scale.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMain_Video_Scale_1X, Me.mnuMain_Video_Scale_2X, Me.mnuMain_Video_Scale_3X})
        Me.mnuMain_Video_Scale.Name = "mnuMain_Video_Scale"
        Me.mnuMain_Video_Scale.Size = New System.Drawing.Size(170, 22)
        Me.mnuMain_Video_Scale.Text = "Scale"
        '
        'mnuMain_Video_Scale_1X
        '
        Me.mnuMain_Video_Scale_1X.Name = "mnuMain_Video_Scale_1X"
        Me.mnuMain_Video_Scale_1X.Size = New System.Drawing.Size(85, 22)
        Me.mnuMain_Video_Scale_1X.Text = "1x"
        '
        'mnuMain_Video_Scale_2X
        '
        Me.mnuMain_Video_Scale_2X.Name = "mnuMain_Video_Scale_2X"
        Me.mnuMain_Video_Scale_2X.Size = New System.Drawing.Size(85, 22)
        Me.mnuMain_Video_Scale_2X.Text = "2x"
        '
        'mnuMain_Video_Scale_3X
        '
        Me.mnuMain_Video_Scale_3X.Name = "mnuMain_Video_Scale_3X"
        Me.mnuMain_Video_Scale_3X.Size = New System.Drawing.Size(85, 22)
        Me.mnuMain_Video_Scale_3X.Text = "3x"
        '
        'mnuMain_Video_ShowBG
        '
        Me.mnuMain_Video_ShowBG.Name = "mnuMain_Video_ShowBG"
        Me.mnuMain_Video_ShowBG.Size = New System.Drawing.Size(170, 22)
        Me.mnuMain_Video_ShowBG.Text = "Show Background"
        '
        'mnuMain_Video_ShowSprites
        '
        Me.mnuMain_Video_ShowSprites.Name = "mnuMain_Video_ShowSprites"
        Me.mnuMain_Video_ShowSprites.Size = New System.Drawing.Size(170, 22)
        Me.mnuMain_Video_ShowSprites.Text = "Show Sprites"
        '
        'mnuMain_Video_ShowGrid
        '
        Me.mnuMain_Video_ShowGrid.Name = "mnuMain_Video_ShowGrid"
        Me.mnuMain_Video_ShowGrid.Size = New System.Drawing.Size(170, 22)
        Me.mnuMain_Video_ShowGrid.Text = "Show Gridlines"
        '
        'mnuMain_Debug
        '
        Me.mnuMain_Debug.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMain_Debug_Enabled})
        Me.mnuMain_Debug.Name = "mnuMain_Debug"
        Me.mnuMain_Debug.Size = New System.Drawing.Size(54, 20)
        Me.mnuMain_Debug.Text = "Debug"
        '
        'mnuMain_Debug_Enabled
        '
        Me.mnuMain_Debug_Enabled.Name = "mnuMain_Debug_Enabled"
        Me.mnuMain_Debug_Enabled.Size = New System.Drawing.Size(116, 22)
        Me.mnuMain_Debug_Enabled.Text = "Enabled"
        '
        'mnuMain_Input
        '
        Me.mnuMain_Input.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMain_Input_Keys})
        Me.mnuMain_Input.Name = "mnuMain_Input"
        Me.mnuMain_Input.Size = New System.Drawing.Size(47, 20)
        Me.mnuMain_Input.Text = "Input"
        '
        'mnuMain_Input_Keys
        '
        Me.mnuMain_Input_Keys.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMain_Input_Keys_Up, Me.mnuMain_Input_Keys_Down, Me.mnuMain_Input_Keys_Left, Me.mnuMain_Input_Keys_Right, Me.mnuMain_Input_Keys_Start, Me.mnuMain_Input_Keys_Select, Me.mnuMain_Input_Keys_A, Me.mnuMain_Input_Keys_B})
        Me.mnuMain_Input_Keys.Name = "mnuMain_Input_Keys"
        Me.mnuMain_Input_Keys.Size = New System.Drawing.Size(98, 22)
        Me.mnuMain_Input_Keys.Text = "Keys"
        '
        'mnuMain_Input_Keys_Up
        '
        Me.mnuMain_Input_Keys_Up.Name = "mnuMain_Input_Keys_Up"
        Me.mnuMain_Input_Keys_Up.Size = New System.Drawing.Size(105, 22)
        Me.mnuMain_Input_Keys_Up.Text = "Up"
        '
        'mnuMain_Input_Keys_Down
        '
        Me.mnuMain_Input_Keys_Down.Name = "mnuMain_Input_Keys_Down"
        Me.mnuMain_Input_Keys_Down.Size = New System.Drawing.Size(105, 22)
        Me.mnuMain_Input_Keys_Down.Text = "Down"
        '
        'mnuMain_Input_Keys_Left
        '
        Me.mnuMain_Input_Keys_Left.Name = "mnuMain_Input_Keys_Left"
        Me.mnuMain_Input_Keys_Left.Size = New System.Drawing.Size(105, 22)
        Me.mnuMain_Input_Keys_Left.Text = "Left"
        '
        'mnuMain_Input_Keys_Right
        '
        Me.mnuMain_Input_Keys_Right.Name = "mnuMain_Input_Keys_Right"
        Me.mnuMain_Input_Keys_Right.Size = New System.Drawing.Size(105, 22)
        Me.mnuMain_Input_Keys_Right.Text = "Right"
        '
        'mnuMain_Input_Keys_Start
        '
        Me.mnuMain_Input_Keys_Start.Name = "mnuMain_Input_Keys_Start"
        Me.mnuMain_Input_Keys_Start.Size = New System.Drawing.Size(105, 22)
        Me.mnuMain_Input_Keys_Start.Text = "Start"
        '
        'mnuMain_Input_Keys_Select
        '
        Me.mnuMain_Input_Keys_Select.Name = "mnuMain_Input_Keys_Select"
        Me.mnuMain_Input_Keys_Select.Size = New System.Drawing.Size(105, 22)
        Me.mnuMain_Input_Keys_Select.Text = "Select"
        '
        'mnuMain_Input_Keys_A
        '
        Me.mnuMain_Input_Keys_A.Name = "mnuMain_Input_Keys_A"
        Me.mnuMain_Input_Keys_A.Size = New System.Drawing.Size(105, 22)
        Me.mnuMain_Input_Keys_A.Text = "A"
        '
        'mnuMain_Input_Keys_B
        '
        Me.mnuMain_Input_Keys_B.Name = "mnuMain_Input_Keys_B"
        Me.mnuMain_Input_Keys_B.Size = New System.Drawing.Size(105, 22)
        Me.mnuMain_Input_Keys_B.Text = "B"
        '
        'dlgOpenFile
        '
        '
        'tmrMonitor
        '
        Me.tmrMonitor.Enabled = True
        Me.tmrMonitor.Interval = 10
        '
        'grp6502
        '
        Me.grp6502.Controls.Add(Me.lblCPU_Cycle)
        Me.grp6502.Controls.Add(Me.lblCPU_IRQ)
        Me.grp6502.Controls.Add(Me.lblCPU_NMI)
        Me.grp6502.Controls.Add(Me.Label4)
        Me.grp6502.Controls.Add(Me.lbl6500_FLBits)
        Me.grp6502.Controls.Add(Me.lbl6500_FL)
        Me.grp6502.Controls.Add(Me.Label1)
        Me.grp6502.Controls.Add(Me.lbl6500_PC)
        Me.grp6502.Controls.Add(Me.Label2)
        Me.grp6502.Controls.Add(Me.lbl6500_SP)
        Me.grp6502.Controls.Add(Me.Label3)
        Me.grp6502.Controls.Add(Me.lbl6500_Y)
        Me.grp6502.Controls.Add(Me.Label5)
        Me.grp6502.Controls.Add(Me.lbl6500_X)
        Me.grp6502.Controls.Add(Me.lbl6500_A)
        Me.grp6502.Controls.Add(Me.Label9)
        Me.grp6502.Controls.Add(Me.Label8)
        Me.grp6502.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp6502.Location = New System.Drawing.Point(6, 6)
        Me.grp6502.Name = "grp6502"
        Me.grp6502.Size = New System.Drawing.Size(286, 79)
        Me.grp6502.TabIndex = 75
        Me.grp6502.TabStop = False
        Me.grp6502.Text = "6502"
        '
        'lblCPU_Cycle
        '
        Me.lblCPU_Cycle.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCPU_Cycle.Location = New System.Drawing.Point(6, 52)
        Me.lblCPU_Cycle.Name = "lblCPU_Cycle"
        Me.lblCPU_Cycle.Size = New System.Drawing.Size(274, 20)
        Me.lblCPU_Cycle.TabIndex = 78
        Me.lblCPU_Cycle.Text = "CPU Cycle: 0/0"
        Me.lblCPU_Cycle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCPU_IRQ
        '
        Me.lblCPU_IRQ.BackColor = System.Drawing.Color.White
        Me.lblCPU_IRQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCPU_IRQ.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCPU_IRQ.Location = New System.Drawing.Point(241, 18)
        Me.lblCPU_IRQ.Name = "lblCPU_IRQ"
        Me.lblCPU_IRQ.Size = New System.Drawing.Size(39, 17)
        Me.lblCPU_IRQ.TabIndex = 76
        Me.lblCPU_IRQ.Text = "IRQ"
        Me.lblCPU_IRQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCPU_NMI
        '
        Me.lblCPU_NMI.BackColor = System.Drawing.Color.White
        Me.lblCPU_NMI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCPU_NMI.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCPU_NMI.Location = New System.Drawing.Point(241, 35)
        Me.lblCPU_NMI.Name = "lblCPU_NMI"
        Me.lblCPU_NMI.Size = New System.Drawing.Size(39, 17)
        Me.lblCPU_NMI.TabIndex = 77
        Me.lblCPU_NMI.Text = "NMI"
        Me.lblCPU_NMI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(91, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 17)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "YR"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6500_FLBits
        '
        Me.lbl6500_FLBits.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6500_FLBits.Location = New System.Drawing.Point(160, 35)
        Me.lbl6500_FLBits.Name = "lbl6500_FLBits"
        Me.lbl6500_FLBits.Size = New System.Drawing.Size(72, 17)
        Me.lbl6500_FLBits.TabIndex = 17
        Me.lbl6500_FLBits.Text = "00000000"
        Me.lbl6500_FLBits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6500_FL
        '
        Me.lbl6500_FL.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6500_FL.Location = New System.Drawing.Point(137, 35)
        Me.lbl6500_FL.Name = "lbl6500_FL"
        Me.lbl6500_FL.Size = New System.Drawing.Size(24, 17)
        Me.lbl6500_FL.TabIndex = 16
        Me.lbl6500_FL.Text = "00"
        Me.lbl6500_FL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PC"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6500_PC
        '
        Me.lbl6500_PC.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6500_PC.Location = New System.Drawing.Point(6, 35)
        Me.lbl6500_PC.Name = "lbl6500_PC"
        Me.lbl6500_PC.Size = New System.Drawing.Size(40, 17)
        Me.lbl6500_PC.TabIndex = 1
        Me.lbl6500_PC.Text = "0000"
        Me.lbl6500_PC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "AC"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6500_SP
        '
        Me.lbl6500_SP.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6500_SP.Location = New System.Drawing.Point(114, 35)
        Me.lbl6500_SP.Name = "lbl6500_SP"
        Me.lbl6500_SP.Size = New System.Drawing.Size(24, 17)
        Me.lbl6500_SP.TabIndex = 13
        Me.lbl6500_SP.Text = "00"
        Me.lbl6500_SP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(68, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "XR"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6500_Y
        '
        Me.lbl6500_Y.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6500_Y.Location = New System.Drawing.Point(91, 35)
        Me.lbl6500_Y.Name = "lbl6500_Y"
        Me.lbl6500_Y.Size = New System.Drawing.Size(24, 17)
        Me.lbl6500_Y.TabIndex = 12
        Me.lbl6500_Y.Text = "00"
        Me.lbl6500_Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(114, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "SP"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6500_X
        '
        Me.lbl6500_X.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6500_X.Location = New System.Drawing.Point(68, 35)
        Me.lbl6500_X.Name = "lbl6500_X"
        Me.lbl6500_X.Size = New System.Drawing.Size(24, 17)
        Me.lbl6500_X.TabIndex = 11
        Me.lbl6500_X.Text = "00"
        Me.lbl6500_X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl6500_A
        '
        Me.lbl6500_A.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl6500_A.Location = New System.Drawing.Point(45, 35)
        Me.lbl6500_A.Name = "lbl6500_A"
        Me.lbl6500_A.Size = New System.Drawing.Size(24, 17)
        Me.lbl6500_A.TabIndex = 10
        Me.lbl6500_A.Text = "00"
        Me.lbl6500_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(160, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 17)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "NV-BDIZC"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(137, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 17)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "FL"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpMemory
        '
        Me.grpMemory.Controls.Add(Me.cboMemoryType)
        Me.grpMemory.Controls.Add(Me.cboMemory)
        Me.grpMemory.Controls.Add(Me.cboMemorySec)
        Me.grpMemory.Controls.Add(Me.lstMemory)
        Me.grpMemory.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMemory.Location = New System.Drawing.Point(6, 6)
        Me.grpMemory.Name = "grpMemory"
        Me.grpMemory.Size = New System.Drawing.Size(514, 298)
        Me.grpMemory.TabIndex = 76
        Me.grpMemory.TabStop = False
        Me.grpMemory.Text = "Memory"
        '
        'cboMemoryType
        '
        Me.cboMemoryType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMemoryType.FormattingEnabled = True
        Me.cboMemoryType.Items.AddRange(New Object() {"RAM", "VRAM", "VBUFFER", "SPRITE", "SAVE"})
        Me.cboMemoryType.Location = New System.Drawing.Point(218, 19)
        Me.cboMemoryType.Name = "cboMemoryType"
        Me.cboMemoryType.Size = New System.Drawing.Size(77, 24)
        Me.cboMemoryType.TabIndex = 60
        Me.cboMemoryType.Text = "RAM"
        '
        'cboMemory
        '
        Me.cboMemory.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMemory.FormattingEnabled = True
        Me.cboMemory.Items.AddRange(New Object() {"0x00-0xFF", "1x00-1xFF", "2x00-2xFF", "3x00-3xFF", "4x00-4xFF", "5x00-5xFF", "6x00-6xFF", "7x00-7xFF", "8x00-8xFF", "9x00-9xFF", "Ax00-AxFF", "Bx00-BxFF", "Cx00-CxFF", "Dx00-DxFF", "E000-EFFF", "F000-FFFF"})
        Me.cboMemory.Location = New System.Drawing.Point(6, 19)
        Me.cboMemory.Name = "cboMemory"
        Me.cboMemory.Size = New System.Drawing.Size(100, 24)
        Me.cboMemory.TabIndex = 58
        Me.cboMemory.Text = "0x00-0xFF"
        '
        'cboMemorySec
        '
        Me.cboMemorySec.DisplayMember = "0"
        Me.cboMemorySec.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMemorySec.FormattingEnabled = True
        Me.cboMemorySec.Items.AddRange(New Object() {"x000-x0FF", "x100-x1FF", "x200-x2FF", "x300-x3FF", "x400-x4FF", "x500-x5FF", "x600-x6FF", "x700-x7FF", "x800-x8FF", "x900-x9FF", "xA00-xAFF", "xB00-xBFF", "xC00-xCFF", "xD00-xDFF", "xE00-xEFF", "xF00-xFFF"})
        Me.cboMemorySec.Location = New System.Drawing.Point(112, 19)
        Me.cboMemorySec.Name = "cboMemorySec"
        Me.cboMemorySec.Size = New System.Drawing.Size(100, 24)
        Me.cboMemorySec.TabIndex = 59
        Me.cboMemorySec.Text = "x000-x0FF"
        '
        'lstMemory
        '
        Me.lstMemory.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstMemory.FormattingEnabled = True
        Me.lstMemory.ItemHeight = 14
        Me.lstMemory.Location = New System.Drawing.Point(6, 49)
        Me.lstMemory.Name = "lstMemory"
        Me.lstMemory.Size = New System.Drawing.Size(499, 242)
        Me.lstMemory.TabIndex = 57
        '
        'tmrSpeed
        '
        Me.tmrSpeed.Interval = 1000
        '
        'grpPalette
        '
        Me.grpPalette.Controls.Add(Me.lblPalette31)
        Me.grpPalette.Controls.Add(Me.lblPalette30)
        Me.grpPalette.Controls.Add(Me.lblPalette29)
        Me.grpPalette.Controls.Add(Me.lblPalette28)
        Me.grpPalette.Controls.Add(Me.lblPalette27)
        Me.grpPalette.Controls.Add(Me.lblPalette26)
        Me.grpPalette.Controls.Add(Me.lblPalette25)
        Me.grpPalette.Controls.Add(Me.lblPalette24)
        Me.grpPalette.Controls.Add(Me.lblPalette23)
        Me.grpPalette.Controls.Add(Me.lblPalette22)
        Me.grpPalette.Controls.Add(Me.lblPalette21)
        Me.grpPalette.Controls.Add(Me.lblPalette20)
        Me.grpPalette.Controls.Add(Me.lblPalette19)
        Me.grpPalette.Controls.Add(Me.lblPalette18)
        Me.grpPalette.Controls.Add(Me.lblPalette17)
        Me.grpPalette.Controls.Add(Me.lblPalette16)
        Me.grpPalette.Controls.Add(Me.lblPalette15)
        Me.grpPalette.Controls.Add(Me.lblPalette14)
        Me.grpPalette.Controls.Add(Me.lblPalette13)
        Me.grpPalette.Controls.Add(Me.lblPalette12)
        Me.grpPalette.Controls.Add(Me.lblPalette11)
        Me.grpPalette.Controls.Add(Me.lblPalette10)
        Me.grpPalette.Controls.Add(Me.lblPalette9)
        Me.grpPalette.Controls.Add(Me.lblPalette8)
        Me.grpPalette.Controls.Add(Me.lblPalette7)
        Me.grpPalette.Controls.Add(Me.lblPalette6)
        Me.grpPalette.Controls.Add(Me.lblPalette5)
        Me.grpPalette.Controls.Add(Me.lblPalette4)
        Me.grpPalette.Controls.Add(Me.lblPalette3)
        Me.grpPalette.Controls.Add(Me.lblPalette2)
        Me.grpPalette.Controls.Add(Me.lblPalette1)
        Me.grpPalette.Controls.Add(Me.lblPalette0)
        Me.grpPalette.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPalette.Location = New System.Drawing.Point(3, 3)
        Me.grpPalette.Name = "grpPalette"
        Me.grpPalette.Size = New System.Drawing.Size(333, 67)
        Me.grpPalette.TabIndex = 77
        Me.grpPalette.TabStop = False
        Me.grpPalette.Text = "Palette"
        '
        'lblPalette31
        '
        Me.lblPalette31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette31.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette31.Location = New System.Drawing.Point(306, 38)
        Me.lblPalette31.Name = "lblPalette31"
        Me.lblPalette31.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette31.TabIndex = 100
        Me.lblPalette31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette30
        '
        Me.lblPalette30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette30.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette30.Location = New System.Drawing.Point(286, 38)
        Me.lblPalette30.Name = "lblPalette30"
        Me.lblPalette30.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette30.TabIndex = 99
        Me.lblPalette30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette29
        '
        Me.lblPalette29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette29.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette29.Location = New System.Drawing.Point(266, 38)
        Me.lblPalette29.Name = "lblPalette29"
        Me.lblPalette29.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette29.TabIndex = 98
        Me.lblPalette29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette28
        '
        Me.lblPalette28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette28.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette28.Location = New System.Drawing.Point(246, 38)
        Me.lblPalette28.Name = "lblPalette28"
        Me.lblPalette28.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette28.TabIndex = 97
        Me.lblPalette28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette27
        '
        Me.lblPalette27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette27.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette27.Location = New System.Drawing.Point(226, 38)
        Me.lblPalette27.Name = "lblPalette27"
        Me.lblPalette27.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette27.TabIndex = 96
        Me.lblPalette27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette26
        '
        Me.lblPalette26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette26.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette26.Location = New System.Drawing.Point(206, 38)
        Me.lblPalette26.Name = "lblPalette26"
        Me.lblPalette26.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette26.TabIndex = 95
        Me.lblPalette26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette25
        '
        Me.lblPalette25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette25.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette25.Location = New System.Drawing.Point(186, 38)
        Me.lblPalette25.Name = "lblPalette25"
        Me.lblPalette25.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette25.TabIndex = 94
        Me.lblPalette25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette24
        '
        Me.lblPalette24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette24.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette24.Location = New System.Drawing.Point(166, 38)
        Me.lblPalette24.Name = "lblPalette24"
        Me.lblPalette24.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette24.TabIndex = 93
        Me.lblPalette24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette23
        '
        Me.lblPalette23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette23.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette23.Location = New System.Drawing.Point(146, 38)
        Me.lblPalette23.Name = "lblPalette23"
        Me.lblPalette23.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette23.TabIndex = 92
        Me.lblPalette23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette22
        '
        Me.lblPalette22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette22.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette22.Location = New System.Drawing.Point(126, 38)
        Me.lblPalette22.Name = "lblPalette22"
        Me.lblPalette22.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette22.TabIndex = 91
        Me.lblPalette22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette21
        '
        Me.lblPalette21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette21.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette21.Location = New System.Drawing.Point(106, 38)
        Me.lblPalette21.Name = "lblPalette21"
        Me.lblPalette21.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette21.TabIndex = 90
        Me.lblPalette21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette20
        '
        Me.lblPalette20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette20.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette20.Location = New System.Drawing.Point(86, 38)
        Me.lblPalette20.Name = "lblPalette20"
        Me.lblPalette20.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette20.TabIndex = 89
        Me.lblPalette20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette19
        '
        Me.lblPalette19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette19.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette19.Location = New System.Drawing.Point(66, 38)
        Me.lblPalette19.Name = "lblPalette19"
        Me.lblPalette19.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette19.TabIndex = 88
        Me.lblPalette19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette18
        '
        Me.lblPalette18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette18.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette18.Location = New System.Drawing.Point(46, 38)
        Me.lblPalette18.Name = "lblPalette18"
        Me.lblPalette18.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette18.TabIndex = 87
        Me.lblPalette18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette17
        '
        Me.lblPalette17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette17.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette17.Location = New System.Drawing.Point(26, 38)
        Me.lblPalette17.Name = "lblPalette17"
        Me.lblPalette17.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette17.TabIndex = 86
        Me.lblPalette17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette16
        '
        Me.lblPalette16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette16.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette16.Location = New System.Drawing.Point(6, 38)
        Me.lblPalette16.Name = "lblPalette16"
        Me.lblPalette16.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette16.TabIndex = 85
        Me.lblPalette16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette15
        '
        Me.lblPalette15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette15.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette15.Location = New System.Drawing.Point(306, 18)
        Me.lblPalette15.Name = "lblPalette15"
        Me.lblPalette15.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette15.TabIndex = 84
        Me.lblPalette15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette14
        '
        Me.lblPalette14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette14.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette14.Location = New System.Drawing.Point(286, 18)
        Me.lblPalette14.Name = "lblPalette14"
        Me.lblPalette14.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette14.TabIndex = 83
        Me.lblPalette14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette13
        '
        Me.lblPalette13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette13.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette13.Location = New System.Drawing.Point(266, 18)
        Me.lblPalette13.Name = "lblPalette13"
        Me.lblPalette13.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette13.TabIndex = 82
        Me.lblPalette13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette12
        '
        Me.lblPalette12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette12.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette12.Location = New System.Drawing.Point(246, 18)
        Me.lblPalette12.Name = "lblPalette12"
        Me.lblPalette12.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette12.TabIndex = 81
        Me.lblPalette12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette11
        '
        Me.lblPalette11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette11.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette11.Location = New System.Drawing.Point(226, 18)
        Me.lblPalette11.Name = "lblPalette11"
        Me.lblPalette11.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette11.TabIndex = 80
        Me.lblPalette11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette10
        '
        Me.lblPalette10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette10.Location = New System.Drawing.Point(206, 18)
        Me.lblPalette10.Name = "lblPalette10"
        Me.lblPalette10.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette10.TabIndex = 79
        Me.lblPalette10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette9
        '
        Me.lblPalette9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette9.Location = New System.Drawing.Point(186, 18)
        Me.lblPalette9.Name = "lblPalette9"
        Me.lblPalette9.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette9.TabIndex = 78
        Me.lblPalette9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette8
        '
        Me.lblPalette8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette8.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette8.Location = New System.Drawing.Point(166, 18)
        Me.lblPalette8.Name = "lblPalette8"
        Me.lblPalette8.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette8.TabIndex = 77
        Me.lblPalette8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette7
        '
        Me.lblPalette7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette7.Location = New System.Drawing.Point(146, 18)
        Me.lblPalette7.Name = "lblPalette7"
        Me.lblPalette7.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette7.TabIndex = 76
        Me.lblPalette7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette6
        '
        Me.lblPalette6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette6.Location = New System.Drawing.Point(126, 18)
        Me.lblPalette6.Name = "lblPalette6"
        Me.lblPalette6.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette6.TabIndex = 75
        Me.lblPalette6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette5
        '
        Me.lblPalette5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette5.Location = New System.Drawing.Point(106, 18)
        Me.lblPalette5.Name = "lblPalette5"
        Me.lblPalette5.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette5.TabIndex = 74
        Me.lblPalette5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette4
        '
        Me.lblPalette4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette4.Location = New System.Drawing.Point(86, 18)
        Me.lblPalette4.Name = "lblPalette4"
        Me.lblPalette4.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette4.TabIndex = 73
        Me.lblPalette4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette3
        '
        Me.lblPalette3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette3.Location = New System.Drawing.Point(66, 18)
        Me.lblPalette3.Name = "lblPalette3"
        Me.lblPalette3.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette3.TabIndex = 72
        Me.lblPalette3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette2
        '
        Me.lblPalette2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette2.Location = New System.Drawing.Point(46, 18)
        Me.lblPalette2.Name = "lblPalette2"
        Me.lblPalette2.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette2.TabIndex = 71
        Me.lblPalette2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette1
        '
        Me.lblPalette1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette1.Location = New System.Drawing.Point(26, 18)
        Me.lblPalette1.Name = "lblPalette1"
        Me.lblPalette1.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette1.TabIndex = 70
        Me.lblPalette1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalette0
        '
        Me.lblPalette0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPalette0.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalette0.Location = New System.Drawing.Point(6, 18)
        Me.lblPalette0.Name = "lblPalette0"
        Me.lblPalette0.Size = New System.Drawing.Size(20, 20)
        Me.lblPalette0.TabIndex = 69
        Me.lblPalette0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPPUFPS
        '
        Me.lblPPUFPS.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPPUFPS.Location = New System.Drawing.Point(128, 267)
        Me.lblPPUFPS.Name = "lblPPUFPS"
        Me.lblPPUFPS.Size = New System.Drawing.Size(128, 20)
        Me.lblPPUFPS.TabIndex = 78
        Me.lblPPUFPS.Text = "0 PPU FPS"
        Me.lblPPUFPS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRenderFPS
        '
        Me.lblRenderFPS.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRenderFPS.Location = New System.Drawing.Point(-3, 267)
        Me.lblRenderFPS.Name = "lblRenderFPS"
        Me.lblRenderFPS.Size = New System.Drawing.Size(128, 20)
        Me.lblRenderFPS.TabIndex = 79
        Me.lblRenderFPS.Text = "0 Render FPS"
        Me.lblRenderFPS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbcDebug
        '
        Me.tbcDebug.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDebug.Controls.Add(Me.tabCPU)
        Me.tbcDebug.Controls.Add(Me.tabMemory)
        Me.tbcDebug.Controls.Add(Me.tabPPU)
        Me.tbcDebug.Controls.Add(Me.tabAPU)
        Me.tbcDebug.Location = New System.Drawing.Point(6, 21)
        Me.tbcDebug.Name = "tbcDebug"
        Me.tbcDebug.SelectedIndex = 0
        Me.tbcDebug.Size = New System.Drawing.Size(539, 463)
        Me.tbcDebug.TabIndex = 78
        '
        'tabCPU
        '
        Me.tabCPU.Controls.Add(Me.grp6502)
        Me.tabCPU.Location = New System.Drawing.Point(4, 25)
        Me.tabCPU.Name = "tabCPU"
        Me.tabCPU.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCPU.Size = New System.Drawing.Size(531, 434)
        Me.tabCPU.TabIndex = 0
        Me.tabCPU.Text = "CPU"
        Me.tabCPU.UseVisualStyleBackColor = True
        '
        'tabMemory
        '
        Me.tabMemory.Controls.Add(Me.grpMemory)
        Me.tabMemory.Location = New System.Drawing.Point(4, 25)
        Me.tabMemory.Name = "tabMemory"
        Me.tabMemory.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMemory.Size = New System.Drawing.Size(531, 434)
        Me.tabMemory.TabIndex = 1
        Me.tabMemory.Text = "Memory"
        Me.tabMemory.UseVisualStyleBackColor = True
        '
        'tabPPU
        '
        Me.tabPPU.Controls.Add(Me.lvwSprites)
        Me.tabPPU.Controls.Add(Me.grpPalette)
        Me.tabPPU.Location = New System.Drawing.Point(4, 25)
        Me.tabPPU.Name = "tabPPU"
        Me.tabPPU.Size = New System.Drawing.Size(531, 434)
        Me.tabPPU.TabIndex = 2
        Me.tabPPU.Text = "PPU"
        Me.tabPPU.UseVisualStyleBackColor = True
        '
        'lvwSprites
        '
        Me.lvwSprites.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvwSprites.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.Tile, Me.Line, Me.Pixel, Me.Attributes})
        Me.lvwSprites.GridLines = True
        Me.lvwSprites.Location = New System.Drawing.Point(9, 76)
        Me.lvwSprites.Name = "lvwSprites"
        Me.lvwSprites.Size = New System.Drawing.Size(327, 345)
        Me.lvwSprites.TabIndex = 78
        Me.lvwSprites.UseCompatibleStateImageBehavior = False
        Me.lvwSprites.View = System.Windows.Forms.View.Details
        '
        'ID
        '
        Me.ID.Text = "#"
        '
        'Tile
        '
        Me.Tile.Text = "Tile #"
        '
        'Line
        '
        Me.Line.Text = "Line"
        '
        'Pixel
        '
        Me.Pixel.Text = "Pixel"
        '
        'Attributes
        '
        Me.Attributes.Text = "Attrib."
        '
        'tabAPU
        '
        Me.tabAPU.Controls.Add(Me.grpController2)
        Me.tabAPU.Controls.Add(Me.grpController1)
        Me.tabAPU.Location = New System.Drawing.Point(4, 25)
        Me.tabAPU.Name = "tabAPU"
        Me.tabAPU.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAPU.Size = New System.Drawing.Size(531, 434)
        Me.tabAPU.TabIndex = 3
        Me.tabAPU.Text = "APU"
        Me.tabAPU.UseVisualStyleBackColor = True
        '
        'grpController2
        '
        Me.grpController2.Controls.Add(Me.lblCTRL2_A)
        Me.grpController2.Controls.Add(Me.lblCTRL2_B)
        Me.grpController2.Controls.Add(Me.lblCTRL2_Start)
        Me.grpController2.Controls.Add(Me.lblCTRL2_Select)
        Me.grpController2.Controls.Add(Me.lblCTRL2_Down)
        Me.grpController2.Controls.Add(Me.lblCTRL2_Right)
        Me.grpController2.Controls.Add(Me.lblCTRL2_Left)
        Me.grpController2.Controls.Add(Me.lblCTRL2_Up)
        Me.grpController2.Location = New System.Drawing.Point(6, 100)
        Me.grpController2.Name = "grpController2"
        Me.grpController2.Size = New System.Drawing.Size(425, 88)
        Me.grpController2.TabIndex = 1
        Me.grpController2.TabStop = False
        Me.grpController2.Text = "Controller 2"
        '
        'lblCTRL2_A
        '
        Me.lblCTRL2_A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL2_A.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL2_A.Location = New System.Drawing.Point(364, 38)
        Me.lblCTRL2_A.Name = "lblCTRL2_A"
        Me.lblCTRL2_A.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL2_A.TabIndex = 7
        Me.lblCTRL2_A.Text = "A"
        Me.lblCTRL2_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL2_B
        '
        Me.lblCTRL2_B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL2_B.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL2_B.Location = New System.Drawing.Point(308, 38)
        Me.lblCTRL2_B.Name = "lblCTRL2_B"
        Me.lblCTRL2_B.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL2_B.TabIndex = 6
        Me.lblCTRL2_B.Text = "B"
        Me.lblCTRL2_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL2_Start
        '
        Me.lblCTRL2_Start.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL2_Start.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL2_Start.Location = New System.Drawing.Point(243, 38)
        Me.lblCTRL2_Start.Name = "lblCTRL2_Start"
        Me.lblCTRL2_Start.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL2_Start.TabIndex = 5
        Me.lblCTRL2_Start.Text = "Start"
        Me.lblCTRL2_Start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL2_Select
        '
        Me.lblCTRL2_Select.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL2_Select.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL2_Select.Location = New System.Drawing.Point(187, 38)
        Me.lblCTRL2_Select.Name = "lblCTRL2_Select"
        Me.lblCTRL2_Select.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL2_Select.TabIndex = 4
        Me.lblCTRL2_Select.Text = "Select"
        Me.lblCTRL2_Select.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL2_Down
        '
        Me.lblCTRL2_Down.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL2_Down.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL2_Down.Location = New System.Drawing.Point(62, 58)
        Me.lblCTRL2_Down.Name = "lblCTRL2_Down"
        Me.lblCTRL2_Down.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL2_Down.TabIndex = 3
        Me.lblCTRL2_Down.Text = "Down"
        Me.lblCTRL2_Down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL2_Right
        '
        Me.lblCTRL2_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL2_Right.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL2_Right.Location = New System.Drawing.Point(120, 38)
        Me.lblCTRL2_Right.Name = "lblCTRL2_Right"
        Me.lblCTRL2_Right.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL2_Right.TabIndex = 2
        Me.lblCTRL2_Right.Text = "Right"
        Me.lblCTRL2_Right.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL2_Left
        '
        Me.lblCTRL2_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL2_Left.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL2_Left.Location = New System.Drawing.Point(6, 38)
        Me.lblCTRL2_Left.Name = "lblCTRL2_Left"
        Me.lblCTRL2_Left.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL2_Left.TabIndex = 1
        Me.lblCTRL2_Left.Text = "Left"
        Me.lblCTRL2_Left.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL2_Up
        '
        Me.lblCTRL2_Up.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL2_Up.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL2_Up.Location = New System.Drawing.Point(62, 18)
        Me.lblCTRL2_Up.Name = "lblCTRL2_Up"
        Me.lblCTRL2_Up.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL2_Up.TabIndex = 0
        Me.lblCTRL2_Up.Text = "Up"
        Me.lblCTRL2_Up.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpController1
        '
        Me.grpController1.Controls.Add(Me.lblCTRL1_A)
        Me.grpController1.Controls.Add(Me.lblCTRL1_B)
        Me.grpController1.Controls.Add(Me.lblCTRL1_Start)
        Me.grpController1.Controls.Add(Me.lblCTRL1_Select)
        Me.grpController1.Controls.Add(Me.lblCTRL1_Down)
        Me.grpController1.Controls.Add(Me.lblCTRL1_Right)
        Me.grpController1.Controls.Add(Me.lblCTRL1_Left)
        Me.grpController1.Controls.Add(Me.lblCTRL1_Up)
        Me.grpController1.Location = New System.Drawing.Point(6, 6)
        Me.grpController1.Name = "grpController1"
        Me.grpController1.Size = New System.Drawing.Size(425, 88)
        Me.grpController1.TabIndex = 0
        Me.grpController1.TabStop = False
        Me.grpController1.Text = "Controller 1"
        '
        'lblCTRL1_A
        '
        Me.lblCTRL1_A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL1_A.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL1_A.Location = New System.Drawing.Point(364, 38)
        Me.lblCTRL1_A.Name = "lblCTRL1_A"
        Me.lblCTRL1_A.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL1_A.TabIndex = 7
        Me.lblCTRL1_A.Text = "A"
        Me.lblCTRL1_A.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL1_B
        '
        Me.lblCTRL1_B.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL1_B.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL1_B.Location = New System.Drawing.Point(308, 38)
        Me.lblCTRL1_B.Name = "lblCTRL1_B"
        Me.lblCTRL1_B.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL1_B.TabIndex = 6
        Me.lblCTRL1_B.Text = "B"
        Me.lblCTRL1_B.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL1_Start
        '
        Me.lblCTRL1_Start.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL1_Start.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL1_Start.Location = New System.Drawing.Point(243, 38)
        Me.lblCTRL1_Start.Name = "lblCTRL1_Start"
        Me.lblCTRL1_Start.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL1_Start.TabIndex = 5
        Me.lblCTRL1_Start.Text = "Start"
        Me.lblCTRL1_Start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL1_Select
        '
        Me.lblCTRL1_Select.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL1_Select.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL1_Select.Location = New System.Drawing.Point(187, 38)
        Me.lblCTRL1_Select.Name = "lblCTRL1_Select"
        Me.lblCTRL1_Select.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL1_Select.TabIndex = 4
        Me.lblCTRL1_Select.Text = "Select"
        Me.lblCTRL1_Select.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL1_Down
        '
        Me.lblCTRL1_Down.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL1_Down.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL1_Down.Location = New System.Drawing.Point(62, 58)
        Me.lblCTRL1_Down.Name = "lblCTRL1_Down"
        Me.lblCTRL1_Down.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL1_Down.TabIndex = 3
        Me.lblCTRL1_Down.Text = "Down"
        Me.lblCTRL1_Down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL1_Right
        '
        Me.lblCTRL1_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL1_Right.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL1_Right.Location = New System.Drawing.Point(120, 38)
        Me.lblCTRL1_Right.Name = "lblCTRL1_Right"
        Me.lblCTRL1_Right.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL1_Right.TabIndex = 2
        Me.lblCTRL1_Right.Text = "Right"
        Me.lblCTRL1_Right.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL1_Left
        '
        Me.lblCTRL1_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL1_Left.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL1_Left.Location = New System.Drawing.Point(6, 38)
        Me.lblCTRL1_Left.Name = "lblCTRL1_Left"
        Me.lblCTRL1_Left.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL1_Left.TabIndex = 1
        Me.lblCTRL1_Left.Text = "Left"
        Me.lblCTRL1_Left.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCTRL1_Up
        '
        Me.lblCTRL1_Up.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCTRL1_Up.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCTRL1_Up.Location = New System.Drawing.Point(62, 18)
        Me.lblCTRL1_Up.Name = "lblCTRL1_Up"
        Me.lblCTRL1_Up.Size = New System.Drawing.Size(52, 20)
        Me.lblCTRL1_Up.TabIndex = 0
        Me.lblCTRL1_Up.Text = "Up"
        Me.lblCTRL1_Up.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpDebug
        '
        Me.grpDebug.Controls.Add(Me.tbcDebug)
        Me.grpDebug.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDebug.Location = New System.Drawing.Point(262, 27)
        Me.grpDebug.Name = "grpDebug"
        Me.grpDebug.Size = New System.Drawing.Size(551, 490)
        Me.grpDebug.TabIndex = 80
        Me.grpDebug.TabStop = False
        Me.grpDebug.Text = "Debug"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 629)
        Me.Controls.Add(Me.picScreen)
        Me.Controls.Add(Me.grpDebug)
        Me.Controls.Add(Me.lblRenderFPS)
        Me.Controls.Add(Me.lblPPUFPS)
        Me.Controls.Add(Me.mnuMain)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NES Emulator"
        CType(Me.picScreen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.grp6502.ResumeLayout(False)
        Me.grpMemory.ResumeLayout(False)
        Me.grpPalette.ResumeLayout(False)
        Me.tbcDebug.ResumeLayout(False)
        Me.tabCPU.ResumeLayout(False)
        Me.tabMemory.ResumeLayout(False)
        Me.tabPPU.ResumeLayout(False)
        Me.tabAPU.ResumeLayout(False)
        Me.grpController2.ResumeLayout(False)
        Me.grpController1.ResumeLayout(False)
        Me.grpDebug.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picScreen As System.Windows.Forms.PictureBox
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFile_Open As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlgOpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tmrMonitor As System.Windows.Forms.Timer
    Friend WithEvents grp6502 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCPU_Cycle As System.Windows.Forms.Label
    Friend WithEvents lblCPU_IRQ As System.Windows.Forms.Label
    Friend WithEvents lblCPU_NMI As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl6500_FLBits As System.Windows.Forms.Label
    Friend WithEvents lbl6500_FL As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl6500_PC As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl6500_SP As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl6500_Y As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl6500_X As System.Windows.Forms.Label
    Friend WithEvents lbl6500_A As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents grpMemory As System.Windows.Forms.GroupBox
    Friend WithEvents cboMemory As System.Windows.Forms.ComboBox
    Friend WithEvents cboMemorySec As System.Windows.Forms.ComboBox
    Friend WithEvents lstMemory As System.Windows.Forms.ListBox
    Friend WithEvents cboMemoryType As System.Windows.Forms.ComboBox
    Friend WithEvents tmrSpeed As System.Windows.Forms.Timer
    Friend WithEvents grpPalette As System.Windows.Forms.GroupBox
    Friend WithEvents lblPalette31 As System.Windows.Forms.Label
    Friend WithEvents lblPalette30 As System.Windows.Forms.Label
    Friend WithEvents lblPalette29 As System.Windows.Forms.Label
    Friend WithEvents lblPalette28 As System.Windows.Forms.Label
    Friend WithEvents lblPalette27 As System.Windows.Forms.Label
    Friend WithEvents lblPalette26 As System.Windows.Forms.Label
    Friend WithEvents lblPalette25 As System.Windows.Forms.Label
    Friend WithEvents lblPalette24 As System.Windows.Forms.Label
    Friend WithEvents lblPalette23 As System.Windows.Forms.Label
    Friend WithEvents lblPalette22 As System.Windows.Forms.Label
    Friend WithEvents lblPalette21 As System.Windows.Forms.Label
    Friend WithEvents lblPalette20 As System.Windows.Forms.Label
    Friend WithEvents lblPalette19 As System.Windows.Forms.Label
    Friend WithEvents lblPalette18 As System.Windows.Forms.Label
    Friend WithEvents lblPalette17 As System.Windows.Forms.Label
    Friend WithEvents lblPalette16 As System.Windows.Forms.Label
    Friend WithEvents lblPalette15 As System.Windows.Forms.Label
    Friend WithEvents lblPalette14 As System.Windows.Forms.Label
    Friend WithEvents lblPalette13 As System.Windows.Forms.Label
    Friend WithEvents lblPalette12 As System.Windows.Forms.Label
    Friend WithEvents lblPalette11 As System.Windows.Forms.Label
    Friend WithEvents lblPalette10 As System.Windows.Forms.Label
    Friend WithEvents lblPalette9 As System.Windows.Forms.Label
    Friend WithEvents lblPalette8 As System.Windows.Forms.Label
    Friend WithEvents lblPalette7 As System.Windows.Forms.Label
    Friend WithEvents lblPalette6 As System.Windows.Forms.Label
    Friend WithEvents lblPalette5 As System.Windows.Forms.Label
    Friend WithEvents lblPalette4 As System.Windows.Forms.Label
    Friend WithEvents lblPalette3 As System.Windows.Forms.Label
    Friend WithEvents lblPalette2 As System.Windows.Forms.Label
    Friend WithEvents lblPalette1 As System.Windows.Forms.Label
    Friend WithEvents lblPalette0 As System.Windows.Forms.Label
    Friend WithEvents lblPPUFPS As System.Windows.Forms.Label
    Friend WithEvents lblRenderFPS As System.Windows.Forms.Label
    Friend WithEvents mnuMain_Emulation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Video As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Video_RenderEngine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Video_Render_Line As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Video_Render_Tile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Video_Enabled As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Emulation_Pause As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Debug As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Debug_Enabled As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Video_Scale As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Video_Scale_1X As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Video_Scale_2X As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Video_Scale_3X As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Input As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Input_Keys As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Input_Keys_Up As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Input_Keys_Down As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Input_Keys_Left As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Input_Keys_Right As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Input_Keys_Start As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Input_Keys_Select As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Input_Keys_A As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Input_Keys_B As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbcDebug As System.Windows.Forms.TabControl
    Friend WithEvents tabCPU As System.Windows.Forms.TabPage
    Friend WithEvents tabMemory As System.Windows.Forms.TabPage
    Friend WithEvents tabPPU As System.Windows.Forms.TabPage
    Friend WithEvents grpDebug As System.Windows.Forms.GroupBox
    Friend WithEvents lvwSprites As System.Windows.Forms.ListView
    Friend WithEvents ID As System.Windows.Forms.ColumnHeader
    Friend WithEvents Tile As System.Windows.Forms.ColumnHeader
    Friend WithEvents Line As System.Windows.Forms.ColumnHeader
    Friend WithEvents Pixel As System.Windows.Forms.ColumnHeader
    Friend WithEvents Attributes As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuMain_Video_ShowBG As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Video_ShowSprites As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_Video_ShowGrid As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_File_Close As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMain_File_ROMInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabAPU As System.Windows.Forms.TabPage
    Friend WithEvents grpController1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCTRL1_A As System.Windows.Forms.Label
    Friend WithEvents lblCTRL1_B As System.Windows.Forms.Label
    Friend WithEvents lblCTRL1_Start As System.Windows.Forms.Label
    Friend WithEvents lblCTRL1_Select As System.Windows.Forms.Label
    Friend WithEvents lblCTRL1_Down As System.Windows.Forms.Label
    Friend WithEvents lblCTRL1_Right As System.Windows.Forms.Label
    Friend WithEvents lblCTRL1_Left As System.Windows.Forms.Label
    Friend WithEvents lblCTRL1_Up As System.Windows.Forms.Label
    Friend WithEvents grpController2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCTRL2_A As System.Windows.Forms.Label
    Friend WithEvents lblCTRL2_B As System.Windows.Forms.Label
    Friend WithEvents lblCTRL2_Start As System.Windows.Forms.Label
    Friend WithEvents lblCTRL2_Select As System.Windows.Forms.Label
    Friend WithEvents lblCTRL2_Down As System.Windows.Forms.Label
    Friend WithEvents lblCTRL2_Right As System.Windows.Forms.Label
    Friend WithEvents lblCTRL2_Left As System.Windows.Forms.Label
    Friend WithEvents lblCTRL2_Up As System.Windows.Forms.Label

End Class
