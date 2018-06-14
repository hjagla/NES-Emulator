Imports System.IO
Public Class frmMain
    Private bmpVideo As Bitmap
    Dim intFrames As Integer
    Dim RenderMode As Byte
    Dim VideoScale As Byte
    Dim EmulationEnabled As Boolean
    Dim VideoEnabled As Boolean
    Dim ShowGrid As Boolean
    Private VideoThread As System.Threading.Thread
    Dim WriteConfig As Microsoft.Win32.RegistryKey
    Dim ReadConfig As Microsoft.Win32.RegistryKey

#Region "Form Functions"
    Private Sub frmMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        WriteConfig = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(strRegistryPath)
        ReadConfig = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strRegistryPath)
        Me.Top = ReadConfig.GetValue("Screen Top")
        Me.Left = ReadConfig.GetValue("Screen Left")
        AdjustWindowSize(ReadConfig.GetValue("Video Scale"))
        SelectRenderMode(ReadConfig.GetValue("Render Mode"))
        SelectDebug(ReadConfig.GetValue("Debug"))

        ToggleBG()
        ToggleSprites()

        For Sprite = 0 To 63
            lvwSprites.Items.Add(Sprite)
            lvwSprites.Items.Item(Sprite).SubItems.Add("")
            lvwSprites.Items.Item(Sprite).SubItems.Add("")
            lvwSprites.Items.Item(Sprite).SubItems.Add("")
            lvwSprites.Items.Item(Sprite).SubItems.Add("")
        Next

    End Sub
    Private Sub frmMain_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        WriteConfig.SetValue("Screen Top", Me.Top)
        WriteConfig.SetValue("Screen Left", Me.Left)
        WriteConfig.SetValue("Video Scale", VideoScale)
        WriteConfig.SetValue("Render Mode", RenderMode)
        WriteConfig.SetValue("Debug", mnuMain_Debug_Enabled.Checked)
    End Sub
    Private Sub tmrMonitor_Tick(sender As System.Object, e As System.EventArgs) Handles tmrMonitor.Tick
        UpdateCPURegisters()
        UpdateMemory()
        UpdatePalette()
        'UpdateSprites()
        UpdateInput()
    End Sub
    Private Sub tmrSpeed_Tick(sender As System.Object, e As System.EventArgs) Handles tmrSpeed.Tick
        lblPPUFPS.Text = PPU.PPUFrames & " PPU FPS"
        lblRenderFPS.Text = intFrames & " Render FPS"
        PPU.PPUFrames = 0
        intFrames = 0
    End Sub
#Region "   Input"
    Private Sub frmMain_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case 76 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) Or &H80
            Case 75 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) Or &H40
            Case 72 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) Or &H20
            Case 74 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) Or &H10
            Case 87 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) Or &H8
            Case 83 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) Or &H4
            Case 65 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) Or &H2
            Case 68 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) Or &H1

            Case 97 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) Or &H80
            Case 99 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) Or &H40
            Case 103 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) Or &H20
            Case 105 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) Or &H10
            Case 104 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) Or &H8
            Case 98 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) Or &H4
            Case 100 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) Or &H2
            Case 102 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) Or &H1
        End Select
    End Sub
    Private Sub frmMain_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case 76 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) And Not &H80
            Case 75 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) And Not &H40
            Case 72 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) And Not &H20
            Case 74 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) And Not &H10
            Case 87 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) And Not &H8
            Case 83 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) And Not &H4
            Case 65 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) And Not &H2
            Case 68 : APU.CONTROLLERBYTE(0) = APU.CONTROLLERBYTE(0) And Not &H1

            Case 97 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) And Not &H80
            Case 99 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) And Not &H40
            Case 103 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) And Not &H20
            Case 105 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) And Not &H10
            Case 104 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) And Not &H8
            Case 98 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) And Not &H4
            Case 100 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) And Not &H2
            Case 102 : APU.CONTROLLERBYTE(1) = APU.CONTROLLERBYTE(1) And Not &H1
        End Select
    End Sub
#End Region
#End Region

#Region "Update Debugging"
    Private Sub UpdateCPURegisters()
        lblCPU_Cycle.Text = "CPU Cycle: " & CPU.Cycle & "/" & CPU.Cycles
        If SYS.IRQ = True Then lblCPU_IRQ.BackColor = Color.LightGreen Else lblCPU_IRQ.BackColor = Color.White
        If SYS.NMI = True Then lblCPU_NMI.BackColor = Color.LightGreen Else lblCPU_NMI.BackColor = Color.White
        lbl6500_PC.Text = Hexed(CPU.tempPC, 4)
        lbl6500_A.Text = Hexed(CPU.A, 2)
        lbl6500_X.Text = Hexed(CPU.X, 2)
        lbl6500_Y.Text = Hexed(CPU.Y, 2)
        lbl6500_SP.Text = Hexed(CPU.S, 2)
        lbl6500_FL.Text = Hexed(CPU.P, 2)
        lbl6500_FLBits.Text = BinaryString(Str(CPU.P), 8)
    End Sub
    Private Sub UpdateMemory()
        Dim bytTemp As Byte
        Dim strTemp As String = ""
        Dim intStartAddress As Integer
        Dim intAddress As Integer
        Dim strData As String
        Dim intLine As Integer = 0

        If cboMemory.SelectedIndex = -1 And cboMemory.Items.Count > 0 Then cboMemory.SelectedIndex = 0
        If cboMemorySec.SelectedIndex = -1 And cboMemorySec.Items.Count > 0 Then cboMemorySec.SelectedIndex = 0

        If cboMemory.SelectedIndex > -1 And cboMemorySec.SelectedIndex > -1 Then
            intStartAddress = 4096 * cboMemory.SelectedIndex
            intStartAddress += 256 * cboMemorySec.SelectedIndex
            If lstMemory.Items.Count Then
                For intAddress = intStartAddress To intStartAddress + 255 Step 16
                    strTemp = ""
                    strData = Hexed(intAddress, 4) & ":"
                    intLine += 1
                    For intTemp = 0 To 15
                        Select Case cboMemoryType.SelectedItem
                            Case "RAM" : bytTemp = RAM.Data((intAddress + intTemp) And RAM.Data.Length - 1)
                            Case "VRAM" : bytTemp = VRAM.Data((intAddress + intTemp) And VRAM.Data.Length - 1)
                            Case "VBUFFER" : bytTemp = PPU.vBuffer((intAddress + intTemp) And &HFFFF)
                            Case "SPRITE" : bytTemp = SPRITERAM.Data((intAddress + intTemp) And SPRITERAM.Data.Length - 1)
                            Case "SAVE" : bytTemp = SAVERAM.Data((intAddress + intTemp) And SAVERAM.Data.Length - 1)
                        End Select
                        strData = strData & " " & Hexed(bytTemp, 2)
                        Select Case bytTemp
                            Case &H1 To &H26 : strTemp = strTemp & Chr(bytTemp + &H40)
                            Case &H2A To &H7A : strTemp = strTemp & Chr(bytTemp)
                            Case Else : strTemp = strTemp & "-"
                        End Select
                    Next
                    lstMemory.Items.Item(intLine) = strData & " " & strTemp
                Next
            Else
                lstMemory.Items.Clear()
                lstMemory.Items.Add("      00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F")
                For intAddress = intStartAddress To intStartAddress + 255 Step 16
                    strTemp = ""
                    strData = Hexed(intAddress, 4) & ":"
                    For intTemp = 0 To 15
                        Select Case cboMemoryType.SelectedItem
                            Case "RAM" : bytTemp = RAM.Data((intAddress + intTemp) And RAM.Data.Length - 1)
                            Case "VRAM" : bytTemp = VRAM.Data((intAddress + intTemp) And VRAM.Data.Length - 1)
                            Case "VBUFFER" : bytTemp = PPU.vBuffer((intAddress + intTemp) And &HFFFF)
                            Case "SPRITE" : bytTemp = SPRITERAM.Data((intAddress + intTemp) And SPRITERAM.Data.Length - 1)
                            Case "SAVE" : bytTemp = SAVERAM.Data((intAddress + intTemp) And SAVERAM.Data.Length - 1)
                        End Select
                        strData = strData & " " & Hexed(bytTemp, 2)
                        Select Case bytTemp
                            Case &H1 To &H26 : strTemp = strTemp & Chr(bytTemp + &H40)
                            Case &H2A To &H7A : strTemp = strTemp & Chr(bytTemp)
                            Case Else : strTemp = strTemp & "-"
                        End Select
                    Next
                    lstMemory.Items.Add(strData & " " & strTemp)
                Next
            End If
        End If
    End Sub
    Private Sub UpdatePalette()
        lblPalette0.BackColor = SYS.NESColor(VRAM.Read(&H3F00))
        lblPalette1.BackColor = SYS.NESColor(VRAM.Read(&H3F01))
        lblPalette2.BackColor = SYS.NESColor(VRAM.Read(&H3F02))
        lblPalette3.BackColor = SYS.NESColor(VRAM.Read(&H3F03))
        lblPalette4.BackColor = SYS.NESColor(VRAM.Read(&H3F04))
        lblPalette5.BackColor = SYS.NESColor(VRAM.Read(&H3F05))
        lblPalette6.BackColor = SYS.NESColor(VRAM.Read(&H3F06))
        lblPalette7.BackColor = SYS.NESColor(VRAM.Read(&H3F07))
        lblPalette8.BackColor = SYS.NESColor(VRAM.Read(&H3F08))
        lblPalette9.BackColor = SYS.NESColor(VRAM.Read(&H3F09))
        lblPalette10.BackColor = SYS.NESColor(VRAM.Read(&H3F0A))
        lblPalette11.BackColor = SYS.NESColor(VRAM.Read(&H3F0B))
        lblPalette12.BackColor = SYS.NESColor(VRAM.Read(&H3F0C))
        lblPalette13.BackColor = SYS.NESColor(VRAM.Read(&H3F0D))
        lblPalette14.BackColor = SYS.NESColor(VRAM.Read(&H3F0E))
        lblPalette15.BackColor = SYS.NESColor(VRAM.Read(&H3F0F))
        lblPalette16.BackColor = SYS.NESColor(VRAM.Read(&H3F10))
        lblPalette17.BackColor = SYS.NESColor(VRAM.Read(&H3F11))
        lblPalette18.BackColor = SYS.NESColor(VRAM.Read(&H3F12))
        lblPalette19.BackColor = SYS.NESColor(VRAM.Read(&H3F13))
        lblPalette20.BackColor = SYS.NESColor(VRAM.Read(&H3F14))
        lblPalette21.BackColor = SYS.NESColor(VRAM.Read(&H3F15))
        lblPalette22.BackColor = SYS.NESColor(VRAM.Read(&H3F16))
        lblPalette23.BackColor = SYS.NESColor(VRAM.Read(&H3F17))
        lblPalette24.BackColor = SYS.NESColor(VRAM.Read(&H3F18))
        lblPalette25.BackColor = SYS.NESColor(VRAM.Read(&H3F19))
        lblPalette26.BackColor = SYS.NESColor(VRAM.Read(&H3F1A))
        lblPalette27.BackColor = SYS.NESColor(VRAM.Read(&H3F1B))
        lblPalette28.BackColor = SYS.NESColor(VRAM.Read(&H3F1C))
        lblPalette29.BackColor = SYS.NESColor(VRAM.Read(&H3F1D))
        lblPalette30.BackColor = SYS.NESColor(VRAM.Read(&H3F1E))
        lblPalette31.BackColor = SYS.NESColor(VRAM.Read(&H3F1F))
    End Sub
    Private Sub UpdateSprites()
        For Sprite = 0 To 63
            lvwSprites.Items.Item(Sprite).SubItems(1).Text = SPRITERAM.Data((Sprite * 4) + 1)
            lvwSprites.Items.Item(Sprite).SubItems(2).Text = SPRITERAM.Data((Sprite * 4) + 0)
            lvwSprites.Items.Item(Sprite).SubItems(3).Text = SPRITERAM.Data((Sprite * 4) + 3)
            lvwSprites.Items.Item(Sprite).SubItems(4).Text = SPRITERAM.Data((Sprite * 4) + 2)
        Next
    End Sub
    Private Sub UpdateInput()
        ' Controller 1
        If APU.CONTROLLERBYTE(0) And &H80 Then lblCTRL1_A.BackColor = Color.Green Else lblCTRL1_A.BackColor = Color.White
        If APU.CONTROLLERBYTE(0) And &H40 Then lblCTRL1_B.BackColor = Color.Green Else lblCTRL1_B.BackColor = Color.White
        If APU.CONTROLLERBYTE(0) And &H20 Then lblCTRL1_Select.BackColor = Color.Green Else lblCTRL1_Select.BackColor = Color.White
        If APU.CONTROLLERBYTE(0) And &H10 Then lblCTRL1_Start.BackColor = Color.Green Else lblCTRL1_Start.BackColor = Color.White
        If APU.CONTROLLERBYTE(0) And &H8 Then lblCTRL1_Up.BackColor = Color.Green Else lblCTRL1_Up.BackColor = Color.White
        If APU.CONTROLLERBYTE(0) And &H4 Then lblCTRL1_Down.BackColor = Color.Green Else lblCTRL1_Down.BackColor = Color.White
        If APU.CONTROLLERBYTE(0) And &H2 Then lblCTRL1_Left.BackColor = Color.Green Else lblCTRL1_Left.BackColor = Color.White
        If APU.CONTROLLERBYTE(0) And &H1 Then lblCTRL1_Right.BackColor = Color.Green Else lblCTRL1_Right.BackColor = Color.White
        ' Controller 2
        If APU.CONTROLLERBYTE(1) And &H80 Then lblCTRL2_A.BackColor = Color.Green Else lblCTRL2_A.BackColor = Color.White
        If APU.CONTROLLERBYTE(1) And &H40 Then lblCTRL2_B.BackColor = Color.Green Else lblCTRL2_B.BackColor = Color.White
        If APU.CONTROLLERBYTE(1) And &H20 Then lblCTRL2_Select.BackColor = Color.Green Else lblCTRL2_Select.BackColor = Color.White
        If APU.CONTROLLERBYTE(1) And &H10 Then lblCTRL2_Start.BackColor = Color.Green Else lblCTRL2_Start.BackColor = Color.White
        If APU.CONTROLLERBYTE(1) And &H8 Then lblCTRL2_Up.BackColor = Color.Green Else lblCTRL2_Up.BackColor = Color.White
        If APU.CONTROLLERBYTE(1) And &H4 Then lblCTRL2_Down.BackColor = Color.Green Else lblCTRL2_Down.BackColor = Color.White
        If APU.CONTROLLERBYTE(1) And &H2 Then lblCTRL2_Left.BackColor = Color.Green Else lblCTRL2_Left.BackColor = Color.White
        If APU.CONTROLLERBYTE(1) And &H1 Then lblCTRL2_Right.BackColor = Color.Green Else lblCTRL2_Right.BackColor = Color.White
    End Sub
#End Region

#Region "Menu Functions"
#Region "   File Menu"
    Private Sub mnuFile_Open_Click(sender As System.Object, e As System.EventArgs) Handles mnuFile_Open.Click
        CloseFile()

        WriteConfig = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(strRegistryPath)
        ReadConfig = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(strRegistryPath)

        dlgOpenFile.InitialDirectory = ReadConfig.GetValue("LastDirectory")
        dlgOpenFile.Filter = "NES Files (*.nes)|*.nes|All files (*.*)|*.*"
        dlgOpenFile.FilterIndex = 0

        If dlgOpenFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
            strFilename = Path.GetFileName(dlgOpenFile.FileName)
            strFilepath = Path.GetDirectoryName(dlgOpenFile.FileName)
            WriteConfig.SetValue("LastDirectory", strFilepath)
            Me.Text = strProgramTitle & " - " & strFilename
            LoadNESROM(dlgOpenFile.FileName)
            SYS.Reset()
            PPU.PPUFrames = 0 : intFrames = 0
            tmrSpeed.Enabled = True
            StartEmulation()
            StartVideo()
        End If
    End Sub
    Private Sub mnuMain_File_Close_Click(sender As System.Object, e As System.EventArgs) Handles mnuMain_File_Close.Click
        SYS.StopClock()
        CloseFile()
    End Sub
#End Region
#Region "   Emulation Menu"
    Private Sub mnuMain_Emulation_Pause_Click(sender As System.Object, e As System.EventArgs) Handles mnuMain_Emulation_Pause.Click
        If EmulationEnabled Then
            StopEmulation()
            StopVideo()
        Else
            StartEmulation()
            StartVideo()
        End If
    End Sub
#End Region
#Region "   Video Menu"
    Private Sub mnuMain_Video_Enabled_Click(sender As System.Object, e As System.EventArgs) Handles mnuMain_Video_Enabled.Click
        If VideoEnabled Then StopVideo() Else StartVideo()
    End Sub
    Private Sub mnuMain_Video_Render_Line_Click(sender As System.Object, e As System.EventArgs) Handles mnuMain_Video_Render_Line.Click
        SelectRenderMode(0)
    End Sub
    Private Sub mnuMain_Video_Render_Tile_Click(sender As System.Object, e As System.EventArgs) Handles mnuMain_Video_Render_Tile.Click
        SelectRenderMode(1)
    End Sub
    Private Sub mnuMain_Video_Scale_1X_Click(sender As System.Object, e As System.EventArgs) Handles mnuMain_Video_Scale_1X.Click
        AdjustWindowSize(1)
    End Sub
    Private Sub mnuMain_Video_Scale_2X_Click(sender As System.Object, e As System.EventArgs) Handles mnuMain_Video_Scale_2X.Click
        AdjustWindowSize(2)
    End Sub
    Private Sub mnuMain_Video_Scale_3X_Click(sender As System.Object, e As System.EventArgs) Handles mnuMain_Video_Scale_3X.Click
        AdjustWindowSize(3)
    End Sub
    Private Sub mnuMain_Video_DrawBG_Click(sender As System.Object, e As System.EventArgs) Handles mnuMain_Video_ShowBG.Click
        ToggleBG()
    End Sub
    Private Sub mnuMain_Video_DrawSprites_Click(sender As System.Object, e As System.EventArgs) Handles mnuMain_Video_ShowSprites.Click
        ToggleSprites()
    End Sub
    Private Sub mnuMain_Video_ShowGrid_Click(sender As System.Object, e As System.EventArgs) Handles mnuMain_Video_ShowGrid.Click
        ToggleGrid()
    End Sub
#End Region
#Region "   Debug Menu"
    Private Sub mnuMain_Debug_Enabled_Click(sender As System.Object, e As System.EventArgs) Handles mnuMain_Debug_Enabled.Click
        If mnuMain_Debug_Enabled.Checked Then SelectDebug(False) Else SelectDebug(True)
    End Sub
#End Region
#End Region

#Region "Emulation Functions"
    Private Sub StartEmulation()
        mnuMain_Emulation_Pause.Checked = False
        EmulationEnabled = True
        SYS.StartClock()
    End Sub
    Private Sub StopEmulation()
        mnuMain_Emulation_Pause.Checked = True
        EmulationEnabled = False
        SYS.Running = False
    End Sub
#End Region

#Region "Video Functions"
    Public Sub StartVideo()
        VideoEnabled = True
        mnuMain_Video_Enabled.Checked = True
        VideoThread = New System.Threading.Thread(AddressOf UpdateVideo)
        VideoThread.IsBackground = True
        VideoThread.Start()
    End Sub
    Private Sub StopVideo()
        VideoEnabled = False
        mnuMain_Video_Enabled.Checked = False
    End Sub
    Private Sub UpdateVideo()
        Do While VideoEnabled
            Select Case RenderMode
                Case 0 : NESVIDEO_LINE()
                Case 1 : NESVIDEO_TILE()
            End Select
            intFrames += 1
            picScreen.Image = bmpVideo
        Loop
    End Sub
    Private Sub AdjustWindowSize(Scale As Byte)
        If Scale = 0 Then Scale = 1
        VideoScale = Scale
        mnuMain_Video_Scale_1X.Checked = False
        mnuMain_Video_Scale_2X.Checked = False
        mnuMain_Video_Scale_3X.Checked = False
        Select Case Scale
            Case 1 : mnuMain_Video_Scale_1X.Checked = True
            Case 2 : mnuMain_Video_Scale_2X.Checked = True
            Case 3 : mnuMain_Video_Scale_3X.Checked = True
        End Select
        picScreen.Width = 256 * Scale
        picScreen.Height = 240 * Scale
        Me.Width = picScreen.Width + 6
        Me.Height = picScreen.Height + 56 + 20
        If mnuMain_Debug_Enabled.Checked Then
            grpDebug.Visible = True
            Me.Width += grpDebug.Width + 16
            grpDebug.Left = picScreen.Width + 8
            If picScreen.Height < 480 Then Me.Height = 550
        Else
            grpDebug.Visible = False
        End If
        lblPPUFPS.Top = picScreen.Height + 27
        lblRenderFPS.Top = picScreen.Height + 27
        lblPPUFPS.Left = picScreen.Width - lblPPUFPS.Width
        lblRenderFPS.Left = lblPPUFPS.Left - lblRenderFPS.Width
    End Sub
#Region "   Render Engines"
    Private Sub SelectRenderMode(Value As Byte)
        RenderMode = Value
        Select Case RenderMode
            Case 0
                mnuMain_Video_Render_Line.Checked = True
                mnuMain_Video_Render_Tile.Checked = False
            Case 1
                mnuMain_Video_Render_Line.Checked = False
                mnuMain_Video_Render_Tile.Checked = True
        End Select
    End Sub
    Private Sub NESVIDEO_LINE()
        bmpVideo = New Bitmap(256, 240)
        Dim VideoLine As Integer
        Dim LinePixel As Integer
        For VideoLine = 0 To 239
            For LinePixel = 0 To 255
                Dim Value As Byte = PPU.vBuffer(VideoLine * 256 + LinePixel)
                Select Case Value
                    Case &H4, &H8, &HC, &H10, &H14, &H18, &H1C : Value = 0
                End Select
                bmpVideo.SetPixel(LinePixel, VideoLine, SYS.NESColor(VRAM.Read(&H3F00 + Value)))
                If ShowGrid Then
                    If VideoLine Mod 8 = 0 And LinePixel Mod 2 = 0 Then bmpVideo.SetPixel(LinePixel, VideoLine, Color.White)
                    If VideoLine Mod 2 = 0 And LinePixel Mod 8 = 0 Then bmpVideo.SetPixel(LinePixel, VideoLine, Color.White)
                    If VideoLine Mod 32 = 0 Or LinePixel Mod 32 = 0 Then bmpVideo.SetPixel(LinePixel, VideoLine, Color.White)
                End If
            Next
        Next
    End Sub
    Private Sub GetColor(Value As Byte)
        Select Case Value
            Case &H4, &H8, &HC
        End Select
    End Sub
    Private Sub NESVIDEO_TILE()
        Dim TileID As Byte
        Dim TileData(15) As Byte
        Dim Table As Integer
        Dim bytPixel As Byte
        Dim intBit2 As Byte
        Dim bytAttr As Integer

        bmpVideo = New Bitmap(256, 240)

        Dim booTop As Boolean = True
        Dim booLeft As Boolean = True
        Dim intColorOffset As Byte

        For BlockY = 0 To 29
            For BlockX = 0 To 31
                bytAttr = VRAM.Data(&H23C0 + (Math.Floor(BlockX / 4) + (Math.Floor(BlockY / 4) * 8)))
                If booTop Then bytAttr = (bytAttr >> 4)
                If booLeft Then bytAttr = (bytAttr >> 2)
                bytAttr = bytAttr And &H3
                intColorOffset = bytAttr * 4
                TileID = VRAM.Data(&H2000 + (BlockY * 32 + BlockX))
                If (PPU.PPUCTRL And &H10) Then Table = 256
                TileData = GetTile(Table + TileID)
                For intLine = 0 To 7
                    intBit2 = 0
                    For intBIT = 7 To 0 Step -1
                        If ((TileData(intLine) >> intBIT) And &H1) Then bytPixel = 1 Else bytPixel = 0
                        If ((TileData(intLine + 8) >> intBIT) And &H1) Then bytPixel += 2
                        If bytPixel > 0 Then bmpVideo.SetPixel(BlockX * 8 + intBit2, BlockY * 8 + intLine, SYS.NESColor(VRAM.Read(&H3F00 + intColorOffset + bytPixel)))
                        intBit2 += 1
                    Next
                Next
                If booLeft = True Then booLeft = False Else booLeft = True
            Next
            If booTop = True Then booTop = False Else booTop = True
        Next

        For intY = 0 To 239 Step 8
            For intX = 0 To 255 Step 8
                'bmpVideo.SetPixel(intX, intY, Color.White)
            Next
        Next
    End Sub
    Private Function GetTile(ID) As Byte()
        Dim bytArray(15) As Byte
        For intByte = 0 To 15
            If CHRBANKS Then
                bytArray(intByte) = CHRDATA(0).Data(ID * 16 + intByte)
            Else
                bytArray(intByte) = CHRRAM.Data(ID * 16 + intByte)
            End If
        Next
        Return bytArray
    End Function
#End Region
    Private Sub DrawSprites()
        Dim SpriteOffset As Integer
        Dim SpriteY, SpriteX As Byte
        Dim SpriteIndex As Byte
        Dim SpriteAttribute As Byte
        Dim TileByte(1) As Byte
        Dim tempcolor As Byte
        For Sprite = 0 To 63
            SpriteOffset = Sprite * 4
            SpriteY = SPRITERAM.Data(SpriteOffset)
            SpriteIndex = SPRITERAM.Data(SpriteOffset + 1)
            SpriteAttribute = SPRITERAM.Data(SpriteOffset + 2)
            SpriteX = SPRITERAM.Data(SpriteOffset + 3)
            If SpriteX > -1 And SpriteX < 247 And SpriteY > 0 And SpriteY < 233 Then
                For SpriteLine = 0 To 7
                    ' Vertical Flipping
                    If SpriteAttribute And &H80 Then
                        TileByte(0) = CHRDATA(0).Data((SpriteIndex * 16) + (Not SpriteLine And &H7))
                        TileByte(1) = CHRDATA(0).Data((SpriteIndex * 16) + (Not SpriteLine And &H7) + 8)
                    Else
                        TileByte(0) = CHRDATA(0).Data((SpriteIndex * 16) + SpriteLine)
                        TileByte(1) = CHRDATA(0).Data((SpriteIndex * 16) + SpriteLine + 8)
                    End If
                    Dim temp As Byte
                    Dim temp2 As Byte
                    Dim PixelColor As Byte
                    For SpritePixel = 0 To 7
                        ' Horizontal Flipping
                        If SpriteAttribute And &H40 Then
                            temp = TileByte(0) >> SpritePixel
                            temp2 = TileByte(1) >> SpritePixel
                        Else
                            temp = (TileByte(0) << SpritePixel) \ &H80
                            temp2 = (TileByte(1) << SpritePixel) \ &H80
                        End If
                        If temp And &H1 Then tempcolor = 1 Else tempcolor = 0
                        If temp2 And &H1 Then tempcolor += 2
                        PixelColor = 16 + ((SpriteAttribute And &H3) * 4) + tempcolor
                        bmpVideo.SetPixel(SpriteX + SpritePixel, SpriteY + SpriteLine, SYS.NESColor(VRAM.Read(&H3F00 + PixelColor)))
                    Next
                Next
            End If
        Next
    End Sub
#End Region

#Region "Debug Functions"
    Private Sub SelectDebug(Value As Boolean)
        If Value Then
            mnuMain_Debug_Enabled.Checked = True
            AdjustWindowSize(VideoScale)
            tmrMonitor.Enabled = True
        Else
            mnuMain_Debug_Enabled.Checked = False
            AdjustWindowSize(VideoScale)
            tmrMonitor.Enabled = False
        End If
    End Sub
    Private Sub ToggleBG()
        If PPU.Draw_BG = True Then
            PPU.Draw_BG = False
            mnuMain_Video_ShowBG.Checked = False
        Else
            PPU.Draw_BG = True
            mnuMain_Video_ShowBG.Checked = True
        End If
    End Sub
    Private Sub ToggleSprites()
        If PPU.Draw_SPR = True Then
            PPU.Draw_SPR = False
            mnuMain_Video_ShowSprites.Checked = False
        Else
            PPU.Draw_SPR = True
            mnuMain_Video_ShowSprites.Checked = True
        End If
    End Sub
    Private Sub ToggleGrid()
        If ShowGrid Then
            ShowGrid = False
            mnuMain_Video_ShowGrid.Checked = False
        Else
            ShowGrid = True
            mnuMain_Video_ShowGrid.Checked = True
        End If
    End Sub
#End Region

End Class
