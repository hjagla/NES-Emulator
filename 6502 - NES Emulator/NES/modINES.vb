Module modINES
    Dim FILEBYTES() As Byte
    Dim ROMHEADER(15) As Byte
    Public PRGBANKS As Byte
    Public CHRBANKS As Byte
    Dim ROMOFFSET As Integer
    Public MAPPER As Byte
    Public SRAM As Boolean
    Public TRAINER As Boolean
    Public MIRRORING As Byte
    Public ROMSIZE As Integer
    Public PRGSIZE As Integer
    Public CHRSIZE As Integer
    Public ROMBYTES() As Byte
    Public PRGBYTES() As Byte
    Public CHRBYTES() As Byte
    Public TRAINERBYTES As clsMemory
    Public PRGDATA(15) As clsMemory
    Public CHRDATA(15) As clsMemory
    Public booFileLoaded As Boolean
    Public strFilename As String
    Public strFilepath As String

    Public Sub LoadNESROM(FileName As String)
        ' Load ROM into Byte Array
        FILEBYTES = My.Computer.FileSystem.ReadAllBytes(FileName)

        ' Put iNES Header into Byte Array
        For Offset = 0 To 15 : ROMHEADER(Offset) = FILEBYTES(Offset) : Next

        PRGBANKS = ROMHEADER(4) ' # of PRG Banks
        CHRBANKS = ROMHEADER(5) ' # of CHR Banks

        ROMOFFSET = 16                                                                   ' Starting Offset (iNES Header)
        MAPPER = ((ROMHEADER(6) And &HF0) \ 16) + (ROMHEADER(7) And &HF0)                ' ROM Mapper Detection
        SRAM = ROMHEADER(6) And &H2                                                      ' Does this ROM have SRAM?
        TRAINER = ROMHEADER(6) And &H4                                                   ' Does this ROM have a Trainer?
        If ROMHEADER(6) And &H8 Then MIRRORING = 2 Else MIRRORING = ROMHEADER(6) And &H1 ' Mirroring

        ' Calculate ROM Sizes
        PRGSIZE = PRGBANKS * 16384  ' Total PRG Size
        CHRSIZE = CHRBANKS * 8192   ' Total CHR Size
        ROMSIZE = PRGSIZE + CHRSIZE ' Total ROM Size
        ReDim PRGBYTES(PRGSIZE - 1)
        ReDim CHRBYTES(CHRSIZE - 1)
        ReDim ROMBYTES(ROMSIZE - 1)

        ' Put Trainer into Byte Array
        If TRAINER Then
            TRAINERBYTES = New clsMemory(512, False)
            For Offset = 0 To 511 : TRAINERBYTES.Data(Offset) = FILEBYTES(Offset + ROMOFFSET) : Next
            ROMOFFSET += 512
        End If

        ' Put all PRG ROMs in Byte Array
        For Offset = 0 To PRGSIZE - 1
            ROMBYTES(Offset) = FILEBYTES(ROMOFFSET + Offset)
            PRGBYTES(Offset) = FILEBYTES(ROMOFFSET + Offset)
        Next

        ' Put all CHR ROMs in Byte Array
        For Offset = 0 To CHRSIZE - 1
            ROMBYTES(PRGSIZE + Offset) = FILEBYTES(ROMOFFSET + PRGSIZE + Offset)
            CHRBYTES(Offset) = FILEBYTES(ROMOFFSET + PRGSIZE + Offset)
        Next

        ' Put PRG Banks into Byte Arrays
        For BANK = 0 To PRGBANKS - 1
            PRGDATA(BANK) = New clsMemory(16384, False)
            For Offset = 0 To 16383 : PRGDATA(BANK).Data(Offset) = PRGBYTES((BANK * 16384) + Offset) : Next
        Next

        ' Put CHR Banks into Byte Arrays
        For BANK = 0 To CHRBANKS - 1
            CHRDATA(BANK) = New clsMemory(8192, False)
            For Offset = 0 To 8191 : CHRDATA(BANK).Data(Offset) = CHRBYTES((BANK * 8192) + Offset) : Next
        Next
        booFileLoaded = True
    End Sub
    Public Sub CloseFile()
        frmMain.Text = strProgramTitle
        strFilename = ""
        strFilepath = ""
        booFileLoaded = False
        For BANK = 0 To PRGBANKS : PRGDATA(BANK) = Nothing : Next
        For BANK = 0 To CHRBANKS : CHRDATA(BANK) = Nothing : Next
        For OFFSET = 0 To 15 : ROMHEADER(OFFSET) = 0 : Next
        FILEBYTES = Nothing
        ROMBYTES = Nothing
        PRGBYTES = Nothing
        CHRBYTES = Nothing
        TRAINERBYTES = Nothing

        ROMSIZE = 0
        PRGSIZE = 0
        CHRSIZE = 0
        PRGBANKS = 0
        CHRBANKS = 0
        ROMOFFSET = 0
        MAPPER = 0
        MIRRORING = 0
        SRAM = False
        TRAINER = False
    End Sub
End Module
