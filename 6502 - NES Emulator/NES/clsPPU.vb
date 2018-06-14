Public Class clsPPU
#Region "Registers"
    Public PPUCTRL As Byte      ' 0
    Public PPUMASK As Byte      ' 1
    Public PPUSTATUS As Byte    ' 2
    Public OAMADDR As Byte      ' 3
    Public SPRRAMIO As Byte     ' 4
    Public PPUSCROLL As Integer ' 5
    Public PPUADDR As Integer   ' 6
    Public PPUDATA As Byte      ' 7
#End Region

#Region "Scrolling"
    Private PPUSCROLL_HI As Boolean
    Private PPUSCROLL_X As Byte
    Private PPUSCROLL_Y As Byte
#End Region

    Private PPUADDR_HI As Boolean
    Public Cycle As Integer
    Public Cycles As Integer = 3
    Public PPUPixel As Integer
    Public PPULine As Integer
    Public PPUFrames As Integer
    Private PPUPixels As Integer = 341
    Private PPULines As Integer = 262
    Public vBuffer(61440) As Byte
    Public SOAMID(7), SOAM_Y(7), SOAM_ID(7), SOAM_Attr(7), SOAM_X(7) As Byte
    Dim COLOROFFSET As Byte
    Public Draw_BG As Boolean
    Public Draw_SPR As Boolean

#Region "Public Functions"
    Public Sub New()
    End Sub
    Public Sub Reset()
        PPUADDR_HI = True
        PPUSCROLL_HI = True
        PPUCTRL = &H0
        PPUMASK = &H0
        PPUSTATUS = &H0
        OAMADDR = &H0
        SPRRAMIO = &H0
        PPUSCROLL = &H0
        PPUADDR = &H0
        PPUDATA = &H0
    End Sub
    Public Sub Tick()
        Cycle += 1
        If Cycle = Cycles Then
            CPU.Tick()
            Cycle = 0
        End If

        Select Case PPULine
            Case 0 To 239
                If PPUPixel < 256 Then
                    PPU.vBuffer(PPULine * 256 + PPUPixel) = 0
                    If Draw_BG Then
                        Dim NTOffset As Integer = (PPUPixel \ 8) + (PPULine \ 8) * 32

                        'Select Case MIRRORING
                        '    Case 0 : Mirror()
                        'End Select


                        Dim TileID As Integer = VRAM.Data(&H2000 + NTOffset)

                        If PPU.PPUCTRL And &H10 Then TileID += 256

                        Dim TileByte(1) As Byte
                        If CHRBANKS Then
                            TileByte(0) = CHRDATA(0).Data(TileID * 16 + (PPULine Mod 8))
                            TileByte(1) = CHRDATA(0).Data(TileID * 16 + (PPULine Mod 8) + 8)
                        Else
                            TileByte(0) = CHRRAM.Data(TileID * 16 + (PPULine Mod 8))
                            TileByte(1) = CHRRAM.Data(TileID * 16 + (PPULine Mod 8) + 8)
                        End If

                        If ((TileByte(0) << PPUPixel Mod 8) \ &H80) Then COLOROFFSET = 1 Else COLOROFFSET = 0
                        If ((TileByte(1) << PPUPixel Mod 8) \ &H80) Then COLOROFFSET += 2

                        ' Get our Color Bank
                        Dim ATTBITS As Byte = 0
                        If (PPUPixel And 31) \ 16 Then ATTBITS = 1
                        If (PPULine And 31) \ 16 Then ATTBITS += 2
                        Dim COLORBANK As Integer = (VRAM.Data(&H23C0 + ((PPUPixel \ 32) + (PPULine \ 32) * 8)) >> (ATTBITS * 2)) And &H3

                        PPU.vBuffer(PPULine * 256 + PPUPixel) = COLORBANK * 4 + COLOROFFSET
                    End If
                End If

                If PPULine > 0 And PPUPixel = 256 Then
                    If Draw_SPR Then
                        SpriteEvaluation()
                        ' We are going to do sprites after the background is drawn just for shits and giggles right now.
                        ' We will move this code into line generation once everything is working.
                        For Sprite = 7 To 0 Step -1
                            ' Do not process any Sprites on line 0
                            If SOAM_Y(Sprite) > 0 Then
                                Dim TileByte(1) As Byte

                                ' Vertical Flipping?
                                If SOAM_Attr(Sprite) And &H80 Then
                                    If CHRBANKS Then
                                        TileByte(0) = CHRDATA(0).Data((SOAM_ID(Sprite) * 16) + (Not (PPULine Mod SOAM_Y(Sprite)) And &H7))
                                        TileByte(1) = CHRDATA(0).Data((SOAM_ID(Sprite) * 16) + (Not (PPULine Mod SOAM_Y(Sprite)) And &H7) + 8)
                                    Else
                                        TileByte(0) = CHRRAM.Data((SOAM_ID(Sprite) * 16) + (Not (PPULine Mod SOAM_Y(Sprite)) And &H7))
                                        TileByte(1) = CHRRAM.Data((SOAM_ID(Sprite) * 16) + (Not (PPULine Mod SOAM_Y(Sprite)) And &H7) + 8)
                                    End If
                                Else
                                    If CHRBANKS Then
                                        TileByte(0) = CHRDATA(0).Data((SOAM_ID(Sprite) * 16) + (PPULine Mod SOAM_Y(Sprite)))
                                        TileByte(1) = CHRDATA(0).Data((SOAM_ID(Sprite) * 16) + (PPULine Mod SOAM_Y(Sprite)) + 8)
                                    Else
                                        TileByte(0) = CHRRAM.Data((SOAM_ID(Sprite) * 16) + (PPULine Mod SOAM_Y(Sprite)))
                                        TileByte(1) = CHRRAM.Data((SOAM_ID(Sprite) * 16) + (PPULine Mod SOAM_Y(Sprite)) + 8)
                                    End If
                                End If

                                For SPRITEPIXEL = 0 To 7
                                    ' Horizontal Flipping?
                                    If SOAM_Attr(Sprite) And &H40 Then
                                        COLOROFFSET = ((TileByte(0) >> SPRITEPIXEL) And &H1)
                                        COLOROFFSET += ((TileByte(1) >> SPRITEPIXEL) And &H1) * 2
                                    Else
                                        COLOROFFSET = ((TileByte(0) << SPRITEPIXEL) \ &H80)
                                        COLOROFFSET += ((TileByte(1) << SPRITEPIXEL) \ &H80) * 2
                                    End If
                                    If COLOROFFSET > 0 Then PPU.vBuffer(PPULine * 256 + SOAM_X(Sprite) + SPRITEPIXEL) = 16 + ((SOAM_Attr(Sprite) And &H3) * 4) + COLOROFFSET
                                Next
                            End If
                        Next
                    End If
                End If
            Case 241
                If PPUPixel = 1 Then
                    PPUSTATUS = PPUSTATUS Or &H80
                    If (PPUCTRL And &H80) Then SYS.NMI = True
                End If
            Case 261
                If PPUPixel = 1 Then PPUSTATUS = PPUSTATUS And Not &H80
        End Select


        If PPUPixel = PPUPixels - 1 Then
            PPUPixel = 0
            If PPULine = PPULines - 1 Then
                PPULine = 0
                PPUFrames += 1
            Else
                PPULine += 1
            End If
        Else
            PPUPixel += 1
        End If
    End Sub
#End Region

    Private Sub SpriteEvaluation()
        Dim SOAM As Byte
        ' Clear the Secondary OAM
        For SOAM = 0 To 7 : SOAM_Y(SOAM) = 0 : SOAM_ID(SOAM) = 0 : SOAM_Attr(SOAM) = 0 : SOAM_X(SOAM) = 0 : Next
        SOAM = 0
        ' Search the OAM for Sprites in our PPULine and place the first 8 of them in the Secondary OAM.
        For Sprite = 0 To 63
            If SPRITERAM.Data(Sprite * 4) > 0 And SPRITERAM.Data(Sprite * 4) < 240 And SPRITERAM.Data(Sprite * 4) > PPULine - 8 And SPRITERAM.Data(Sprite * 4) <= PPULine Then
                'SOAMID(SOAM) = Sprite
                SOAM_Y(SOAM) = SPRITERAM.Data(Sprite * 4 + 0)
                SOAM_ID(SOAM) = SPRITERAM.Data(Sprite * 4 + 1)
                SOAM_Attr(SOAM) = SPRITERAM.Data(Sprite * 4 + 2)
                SOAM_X(SOAM) = SPRITERAM.Data(Sprite * 4 + 3)
                SOAM += 1
                If SOAM = 8 Then
                    ' NEED TO SET SPRITE OVERFLOW FLAG IF MORE SPRITES ARE ON THE LINE!!
                    'For temp = 0 To 7 : Debug.Print("PPULine: " & PPULine & " SPRITE: " & SOAMID(temp) & " TILE: " & SOAM_ID(temp) & " Y: " & SOAM_Y(temp) & " X: " & SOAM_X(temp)) : Next
                    'SYS.Running = False
                    'frmMain.tmrMonitor.Enabled = False
                    Exit For
                End If
            End If
        Next
    End Sub

#Region "Memory Functions"
    Public Function Read(Address As Integer) As Byte
        Select Case Address And &H7
            Case &H0 : Read = &H0
            Case &H1 : Read = &H0
            Case &H2 : Read = PPUSTATUS : PPUSTATUS = PPUSTATUS And Not &H80
            Case &H3 : Read = &H0
            Case &H4 : Read = SPRITERAM.Read(OAMADDR) : OAMADDR += 1
            Case &H5 : Read = &H0
            Case &H6 : Read = &H0
            Case &H7 : Read = ReadMem()
            Case Else : Read = &H0
        End Select
    End Function
    Public Sub Write(Address As Integer, Value As Byte)
        Select Case (Address And &H7)
            Case &H0 : PPUCTRL = Value '
            Case &H1 : PPUMASK = Value '
            Case &H2
            Case &H3 : OAMADDR = Value
            Case &H4 : SPRITERAM.Write(OAMADDR, Value) : OAMADDR += 1 ' Does not always increment?
            Case &H5 : SetXY(Value)
            Case &H6 : SetMem(Value)
            Case &H7 : WriteMem(Value)
        End Select
    End Sub
    Private Sub SetXY(Value As Byte)
        If PPUADDR_HI Then
            PPUSCROLL_X = Value
            PPUADDR_HI = False
        Else
            PPUADDR_HI = True
        End If
    End Sub
    Private Sub SetMem(Value As Byte)
        If PPUADDR_HI Then PPUADDR = Value * &H100 : PPUADDR_HI = False Else PPUADDR += Value : PPUADDR_HI = True
    End Sub
    Private Function ReadMem()
        Select Case PPUADDR
            Case &H0 To &H1FFF
                If CHRBANKS Then
                    ReadMem = CHRRAM.Read(PPUADDR)                  ' Pattern table 0 - 1
                Else
                    ReadMem = VRAM.Read(PPUADDR)
                End If
            Case &H2000 To &H2FFF : ReadMem = VRAM.Read(PPUADDR)               ' Nametable 0 - 3
            Case &H3000 To &H3EFF : ReadMem = 0                                                     ' Mirrors of $2000 - $2EFF
            Case &H3F00 To &H3F1F : ReadMem = ReadPalette(PPUADDR)             ' Palette RAM Indexes
            Case &H3F20 To &H3FFF : ReadMem = 0                                                     ' Mirrors of $3F00 - $3F1F
            Case Else : ReadMem = 0
        End Select
        If (PPUCTRL And &H4) Then PPUADDR += 32 Else PPUADDR += 1
    End Function
    Private Sub WriteMem(Value As Byte)
        Select Case PPUADDR
            Case &H0 To &H1FFF : CHRRAM.Write(PPUADDR, Value)              ' Pattern table 0 - 1
            Case &H2000 To &H2FFF : VRAM.Write(PPUADDR, Value)             ' Nametable 0 - 3
            Case &H3000 To &H3EFF                                          ' Mirrors of $2000 - $2EFF
            Case &H3F00 To &H3F1F : WritePalette(PPUADDR, Value) 'VRAM.Write(PPUADDR, Value)             ' Palette RAM Indexes
            Case &H3F20 To &H3FFF                                                               ' Mirrors of $3F00 - $3F1F
        End Select
        PPUADDR_HI = True
        If (PPUCTRL And &H4) Then PPUADDR += 32 Else PPUADDR += 1
    End Sub
    Private Function ReadPalette(Address As Integer) As Byte
        Select Case Address
            Case &H3F10 : ReadPalette = VRAM.Read(&H3F00)
            Case &H3F14 : ReadPalette = VRAM.Read(&H3F04)
            Case &H3F18 : ReadPalette = VRAM.Read(&H3F08)
            Case &H3F1C : ReadPalette = VRAM.Read(&H3F0C)
            Case Else : ReadPalette = VRAM.Read(Address)
        End Select
    End Function
    Private Sub WritePalette(Address As Integer, Value As Byte)
        Select Case Address
            Case &H3F10 : VRAM.Write(&H3F00, Value)
            Case &H3F14 : VRAM.Write(&H3F04, Value)
            Case &H3F18 : VRAM.Write(&H3F08, Value)
            Case &H3F1C : VRAM.Write(&H3F0C, Value)
            Case Else : VRAM.Write(Address, Value)
        End Select
    End Sub
    Public Sub OAMDMA(Value As Byte)
        'This port is located on the CPU. Writing $XX will upload 256 bytes of data from CPU page $XX00-$XXFF
        ' to the internal PPU OAM. This page is typically located in internal RAM, commonly $0200-$02FF,
        ' but cartridge RAM or ROM can be used as well. 
        'The CPU is suspended during the transfer, which will take 513 or 514 cycles after the $4014 write tick.
        ' (1 dummy read cycle while waiting for writes to complete, +1 if on an odd CPU cycle, then 256 alternating
        ' read/write cycles.)
        'The OAM DMA is the only effective method for initializing all 256 bytes of OAM. Because of the decay of OAM's
        ' dynamic RAM when rendering is disabled, the initialization should take place within vblank. Writes through
        ' OAMDATA are generally too slow for this task.
        'The DMA transfer will begin at the current OAM write address. It is common practice to initialize it to 0 with
        ' a write to OAMADDR before the DMA transfer. Different starting addresses can be used for a simple OAM cycling
        ' technique, to alleviate sprite priority conflicts by flickering. If using this technique, after the DMA OAMADDR
        ' should be set to 0 before the end of vblank to prevent potential OAM corruption (See: Errata). However, due to
        ' OAMADDR writes also having a "corruption" effect[5] this technique is not recommended.

        ' For now:
        For Offset = 0 To 255
            SPRITERAM.Write(Offset, RAM.Read(Value * &H100 + Offset))
        Next
    End Sub
#End Region
End Class
