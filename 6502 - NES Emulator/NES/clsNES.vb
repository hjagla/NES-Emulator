Imports System.Text.Encoding
Public Class clsNES
    Public Running As Boolean
    Private Thread As System.Threading.Thread
    Public MaxCPI As Long
    Public Cycles As Long = 0

    Public IRQ As Boolean
    Public NMI As Boolean

    Dim PALData() As Byte
    Public NESColor(63) As Color

#Region "Mapper 1 Declarations"
    Private MMC1_REG(4) As Byte
    Private MMC1_CNT As Byte        ' Write Count
    Private MMC1_ACC As Byte        ' Bit Shifting Accumulator
    ' MMC1 Control
    Private MMC1_MIRROR As Byte
    Private MMC1_PRGMODE As Byte
    Private MMC1_CHRMODE As Byte
    ' MMC1 CHR $0000 Bank
    Private MMC1_CHR0 As Byte
    ' MMC1 CHR $1000 Bank
    Private MMC1_CHR1 As Byte
    ' MMC1 PRG Bank
    Private MMC1_BANK
    Private MMC1_RAMENABLE
#End Region

#Region "Public Functions"
    Public Sub New()
        LoadPalette("palettes\FCEUX.pal")
        MaxCPI = 5.369318 * (1111111 / (1000 / 100))
    End Sub
    Public Sub Reset()
        PPU.Reset()
        APU.Reset()
        CPU.Reset()
    End Sub
    Public Sub Tick()
        PPU.Tick()
    End Sub
#End Region

    Public Sub StartClock()
        Running = True
        Thread = New System.Threading.Thread(AddressOf Run)
        Thread.IsBackground = True
        Thread.Start()
    End Sub
    Public Sub StopClock()
        Running = False
    End Sub
    Private Sub Run()
        Do While Running
            If Cycles < MaxCPI Then
                Tick()
                Cycles += 1
            Else
                My.Application.DoEvents()
                Cycles = 0
            End If
        Loop
    End Sub

#Region "Memory Functions"
    Public Function Read(Address As Integer) As Byte
        Select Case Address
            Case &H0 To &H1FFF : Read = RAM.Read(Address)      ' NES ram 0-7FF mirrored at 800 1000 1800
            Case &H2000 To &H3FFF : Read = PPU.Read(Address)                             ' PPU Registers
            Case &H4000 To &H401F : Read = APU.Read(Address)                             ' APU Registers
            Case &H4120 To &H5FFF : Read = &H0                                              ' APU and I/O functionality that is normally disabled
            Case &H6000 To &H7FFF : Read = SAVERAM.Read(Address)   ' Save/Work RAM
            Case &H8000 To &HBFFF : Read = ReadMapper(Address)                              ' ROM
            Case &HC000 To &HFFFF : Read = ReadMapper(Address)                              ' ROM
            Case Else : Read = &H0                                                          ' Should not Happen
        End Select
    End Function
    Public Sub Write(Address As Integer, Value As Byte)
        Select Case Address
            Case &H0 To &H1FFF : RAM.Write(Address, Value)
            Case &H2000 To &H3FFF : PPU.Write(Address, Value)
            Case &H4000 To &H4013
            Case &H4014 : PPU.OAMDMA(Value)
            Case &H4015 To &H4017
            Case &H4120 To &H5FFF
            Case &H6000 To &H7FFF : SAVERAM.Write(Address, Value)
            Case &H8000 To &HFFFF : WriteMapper(Address, Value)
        End Select
    End Sub
    Private Function ReadMapper(Address As Integer)
        Select Case MAPPER
            Case 0
                If PRGBANKS > 1 Then
                    Select Case Address
                        Case &H8000 To &HBFFF : ReadMapper = PRGDATA(0).Read(Address)
                        Case &HC000 To &HFFFF : ReadMapper = PRGDATA(1).Read(Address)
                    End Select
                Else
                    ReadMapper = PRGDATA(0).Read(Address)
                End If
            Case 1 : ReadMapper = Read_Mapper1(Address, MMC1_PRGMODE)
            Case Else
                Select Case Address
                    Case &H8000 To &HBFFF : ReadMapper = PRGDATA(0).Read(Address)
                    Case &HC000 To &HFFFF : ReadMapper = PRGDATA(1).Read(Address)
                End Select
        End Select
    End Function
    Private Sub WriteMapper(Address As Integer, Value As Byte)
        Select Case MAPPER
            Case 0
            Case 1 : Write_Mapper1(Address, Value)
        End Select
    End Sub
#End Region

#Region "Mappers"
#Region "   Mapper 1"
    Private Function Read_Mapper1(Address As Integer, Mode As Byte)
        Select Case Mode
            Case 0, 1
                ' TESTING NEEDED
                Select Case Address
                    Case &H8000 To &HBFFF : Read_Mapper1 = PRGDATA(0).Read(Address)
                    Case &HC000 To &HFFFF : Read_Mapper1 = PRGDATA(PRGBANKS - 1).Read(Address)
                End Select
            Case 2
                ' TESTING NEEDED
                Select Case Address
                    Case &H8000 To &HBFFF : Read_Mapper1 = PRGDATA(0).Read(Address)
                    Case &HC000 To &HFFFF : Read_Mapper1 = PRGDATA(MMC1_BANK).Read(Address)
                End Select
            Case 3
                ' Tested with Zelda
                Select Case Address
                    Case &H8000 To &HBFFF : Read_Mapper1 = PRGDATA(MMC1_BANK).Read(Address)
                    Case &HC000 To &HFFFF : Read_Mapper1 = PRGDATA(PRGBANKS - 1).Read(Address)
                End Select
        End Select
    End Function
    Private Sub Write_Mapper1(Address As Integer, Value As Byte)
        If (Value And &H80) Then        ' Reset Mapper
            MMC1_REG(0) = MMC1_REG(0) Or &HC
            MMC1_CNT = 0
            MMC1_ACC = 0
        Else
            MMC1_ACC += (Value And &H1) << MMC1_CNT ' Add Bit Shifted Value
            MMC1_CNT += 1                           ' Increment Write Count
            If MMC1_CNT = 5 Then                    ' Write Count = 5 - Set Register Value
                Select Case Address
                    Case &H8000 To &H9FFF
                        MMC1_REG(0) = MMC1_ACC And &H1F
                        MMC1_MIRROR = MMC1_ACC And &H3
                        MMC1_PRGMODE = (MMC1_ACC And &HC) >> 2
                        MMC1_CHRMODE = (MMC1_ACC And &H10) >> 4
                    Case &HA000 To &HBFFF
                        MMC1_REG(1) = MMC1_ACC And &H1F
                        MMC1_CHR0 = MMC1_ACC And &H1F
                    Case &HC000 To &HDFFF
                        MMC1_REG(2) = MMC1_ACC And &H1F
                        MMC1_CHR1 = MMC1_ACC And &H1F
                    Case &HE000 To &HFFFF
                        MMC1_REG(3) = MMC1_ACC And &H1F
                        MMC1_BANK = MMC1_ACC And &HF
                        MMC1_RAMENABLE = (MMC1_ACC And &H10) >> 4
                End Select
                MMC1_CNT = 0
                MMC1_ACC = 0
            End If
        End If
    End Sub
#End Region
#End Region

    Private Sub LoadPalette(File)
        PALData = My.Computer.FileSystem.ReadAllBytes(File)
        For PALColor = 0 To 63
            NESColor(PALColor) = Color.FromArgb(PALData(PALColor * 3), PALData(PALColor * 3 + 1), PALData(PALColor * 3 + 2))
        Next
    End Sub
End Class
