Public Class cls6502
    Dim OpCode As Integer
#Region "Address Modes"
    Public Const ADR_ABS As Byte = 0
    Public Const ADR_ABSX As Byte = 1
    Public Const ADR_ABSY As Byte = 2
    Public Const ADR_IMM As Byte = 3
    Public Const ADR_IMP As Byte = 4
    Public Const ADR_INDABSX As Byte = 5
    Public Const ADR_IND As Byte = 6
    Public Const ADR_INDX As Byte = 7
    Public Const ADR_INDY As Byte = 8
    Public Const ADR_INDZP As Byte = 9
    Public Const ADR_REL As Byte = 10
    Public Const ADR_ZP As Byte = 11
    Public Const ADR_ZPX As Byte = 12
    Public Const ADR_ZPY As Byte = 13
#End Region
#Region "OpCodes"
    Private Const INS_ADC As Integer = 0
    Private Const INS_AND As Integer = 1
    Private Const INS_ASL As Integer = 2
    Private Const INS_ASLA As Integer = 3
    Private Const INS_BCC As Integer = 4
    Private Const INS_BCS As Integer = 5
    Private Const INS_BEQ As Integer = 6
    Private Const INS_BIT As Integer = 7
    Private Const INS_BMI As Integer = 8
    Private Const INS_BNE As Integer = 9
    Private Const INS_BPL As Integer = 10
    Private Const INS_BRK As Integer = 11
    Private Const INS_BVC As Integer = 12
    Private Const INS_BVS As Integer = 13
    Private Const INS_CLC As Integer = 14
    Private Const INS_CLD As Integer = 15
    Private Const INS_CLI As Integer = 16
    Private Const INS_CLV As Integer = 17
    Private Const INS_CMP As Integer = 18
    Private Const INS_CPX As Integer = 19
    Private Const INS_CPY As Integer = 20
    Private Const INS_DEC As Integer = 21
    Private Const INS_DEA As Integer = 22
    Private Const INS_DEX As Integer = 23
    Private Const INS_DEY As Integer = 24
    Private Const INS_EOR As Integer = 25
    Private Const INS_INC As Integer = 26
    Private Const INS_INX As Integer = 27
    Private Const INS_INY As Integer = 28
    Private Const INS_JMP As Integer = 29
    Private Const INS_JSR As Integer = 30
    Private Const INS_LDA As Integer = 31
    Private Const INS_LDX As Integer = 32
    Private Const INS_LDY As Integer = 33
    Private Const INS_LSR As Integer = 34
    Private Const INS_LSRA As Integer = 35
    Private Const INS_NOP As Integer = 36
    Private Const INS_ORA As Integer = 37
    Private Const INS_PHA As Integer = 38
    Private Const INS_PHP As Integer = 39
    Private Const INS_PLA As Integer = 40
    Private Const INS_PLP As Integer = 41
    Private Const INS_ROL As Integer = 42
    Private Const INS_ROLA As Integer = 43
    Private Const INS_ROR As Integer = 44
    Private Const INS_RORA As Integer = 45
    Private Const INS_RTI As Integer = 46
    Private Const INS_RTS As Integer = 47
    Private Const INS_SBC As Integer = 48
    Private Const INS_SEC As Integer = 49
    Private Const INS_SED As Integer = 50
    Private Const INS_SEI As Integer = 51
    Private Const INS_STA As Integer = 52
    Private Const INS_STX As Integer = 53
    Private Const INS_STY As Integer = 54
    Private Const INS_TAX As Integer = 55
    Private Const INS_TAY As Integer = 56
    Private Const INS_TSX As Integer = 57
    Private Const INS_TXA As Integer = 58
    Private Const INS_TXS As Integer = 59
    Private Const INS_TYA As Integer = 60
    Private Const INS_BRA As Integer = 61
    Private Const INS_INA As Integer = 62
    Private Const INS_PHX As Integer = 63
    Private Const INS_PLX As Integer = 64
    Private Const INS_PHY As Integer = 65
    Private Const INS_PLY As Integer = 66
    Private Const INS_IRQ As Integer = &H100
    Private Const INS_NMI As Integer = &H101
#End Region
#Region "Registers"
    Public PC As Integer
    Public A As Byte
    Public X As Byte
    Public Y As Byte
    Public S As Byte
    Public P As Byte
#End Region
#Region "Status Bits"
    Public Const P_CARRY = &H1
    Public Const P_ZERO = &H2
    Public Const P_INTERUPT = &H4
    Public Const P_DECIMAL = &H8
    Public Const P_BREAK = &H10
    Public Const P_UNUSED = &H20
    Public Const P_OVERFLOW = &H40
    Public Const P_SIGN = &H80
#End Region
#Region "Models"
    ' 6502 = 64k    
    ' 6503 =  4k
    ' 6504 =  8k
    ' 6505 =  4k
    ' 6506 =  4k
    ' 6507 =  8k
    ' 6508 = 64k w/ Internal 256bytes and I/O
    ' 6509 = 64k w/ MMU
    ' 6510 = 64k w/ 02 Clock and I/O
    ' 6512 = 64k w/ 02 Clock
    ' 6513 =  4k w/ 02 Clock
    ' 6514 =  8k w/ 02 Clock
    ' 6515 =  4k w/ 02 Clock
    Public Model As String = "02"
#End Region
#Region "6510 IO/DDR"
    Public DDR As Byte  ' $00
    Public IO As Byte   ' $01
#End Region
#Region "Instruction Declarations"
    Public INS_ADR(&H101) As Byte
    Public INS_TICKS(&H101) As Byte
    Public INS_INST(&H101) As Integer
    Public INS_BYTES(&H101) As Integer
    Public INS_TEXT(&H101) As String
#End Region
#Region "Instruction Cycle"
    Public Cycle As Byte
    Public Cycles As Byte
#End Region
#Region "ADR/INS Tick"
    Private ADR_TICK As Byte
    Private INS_TICK As Byte
#End Region
#Region "Benchmarking"
    Public OPs As Integer
#End Region
#Region "Helper Variables"
    Public tempPC As Integer
    Private savepc As Integer
    Private help As Integer
    Private value As Integer
    Private sum As Integer
    Private saveflags As Integer
#End Region
#Region "CPU Init/Reset"
    Public Sub New()
        Init()
    End Sub
    Public Sub Reset()
        A = &H0 : X = &H0 : Y = &H0 : P = &H20 : S = &HFF
        DDR = 0 : IO = 0

        PC = Read(&HFFFC) + (Read(&HFFFD) * &H100)
        Cycles = 1 : Cycle = 1
        LogText("CPU 65" & Model & ": Reset to " & PC & " (" & Hex(PC) & ")")
        tempPC = PC
    End Sub
#End Region
#Region "Tick Functions"
    Public Sub Tick()
        If SYS.Running = False Then LogText("CPU 65" & Model & " Cycle: " & Cycle & "/" & Cycles & " ADR_TICK: " & ADR_TICK & " INS_TICK: " & INS_TICK & " Addr: " & Hex(tempPC) & " OpCode: " & Hex(Read(tempPC)) & " (" & INS_TEXT(Read(tempPC)) & ")")

        If Cycle = 1 Then
            If SYS.NMI = True Then
                OpCode = &H101
                SYS.NMI = False
            ElseIf SYS.IRQ = True And (P And &H4) = 0 Then
                OpCode = &H100
            Else
                OpCode = Read(PC)
            End If
            ADR_TICK = 0
            INS_TICK = 0
            PC += 1
            OPs += 1
            Cycles = 2
        Else
            If INS_TICK = 0 Then Tick_ADR(OpCode)
            If INS_TICK > 0 Then Tick_INS(OpCode)
        End If

        If Cycle = 0 Then tempPC = PC
        If Cycle = 255 Then Cycle = 0 Else Cycle += 1
    End Sub
    Private Sub Tick_INS(OpCode As Integer)
        Select Case INS_INST(OpCode)
            Case INS_ADC : INST_ADC()
            Case INS_AND : INST_AND()
            Case INS_ASL : INST_ASL()
            Case INS_ASLA : INST_ASLA()
            Case INS_BCC : INST_BCC()
            Case INS_BCS : INST_BCS()
            Case INS_BEQ : INST_BEQ()
            Case INS_BIT : INST_BIT()
            Case INS_BMI : INST_BMI()
            Case INS_BNE : INST_BNE()
            Case INS_BPL : INST_BPL()
            Case INS_BRK : INST_BRK()
            Case INS_BVC : INST_BVC()
            Case INS_BVS : INST_BVS()
            Case INS_CLC : INST_CLC()
            Case INS_CLD : INST_CLD()
            Case INS_CLI : INST_CLI()
            Case INS_CLV : INST_CLV()
            Case INS_EOR : INST_EOR()
            Case INS_LDA : INST_LDA()
            Case INS_LDX : INST_LDX()
            Case INS_LDY : INST_LDY()
            Case INS_JMP : INST_JMP()
            Case INS_JSR : INST_JSR()
            Case INS_NOP : INST_NOP()
            Case INS_PHA : INST_PHA()
            Case INS_PHP : INST_PHP()
            Case INS_PHX : INST_PHX()
            Case INS_PHY : INST_PHY()
            Case INS_PLA : INST_PLA()
            Case INS_PLP : INST_PLP()
            Case INS_PLX : INST_PLX()
            Case INS_PLY : INST_PLY()
            Case INS_ORA : INST_ORA()
            Case INS_RTI : INST_RTI()
            Case INS_RTS : INST_RTS()
            Case INS_TAX : INST_TAX()
            Case INS_TAY : INST_TAY()
            Case INS_TXA : INST_TXA()
            Case INS_TYA : INST_TYA()
            Case INS_TSX : INST_TSX()
            Case INS_TXS : INST_TXS()
            Case INS_CMP : INST_CMP()
            Case INS_CPX : INST_CPX()
            Case INS_CPY : INST_CPY()
            Case INS_DEC : INST_DEC()
            Case INS_DEX : INST_DEX()
            Case INS_DEY : INST_DEY()
            Case INS_INC : INST_INC()
            Case INS_INY : INST_INY()
            Case INS_INX : INST_INX()
            Case INS_LSR : INST_LSR()
            Case INS_LSRA : INST_LSRA()
            Case INS_ROL : INST_ROL()
            Case INS_ROLA : INST_ROLA()
            Case INS_ROR : INST_ROR()
            Case INS_RORA : INST_RORA()
            Case INS_SBC : INST_SBC()
            Case INS_SEC : INST_SEC()
            Case INS_SED : INST_SED()
            Case INS_SEI : INST_SEI()
            Case INS_STA : INST_STA()
            Case INS_STX : INST_STX()
            Case INS_STY : INST_STY()
                ' IRQ's
            Case INS_IRQ : INST_IRQ()
            Case INS_NMI : INST_NMI()
                ' Bad Ops
            Case INS_BRA : INST_BRA()
            Case INS_DEA : INST_DEA()
            Case INS_INA : INST_INA()
            Case Else : MsgBox("Invalid OpCode - " & Hexed(OpCode, 2))
        End Select
        INS_TICK += 1
    End Sub
    Private Sub Tick_ADR(OpCode As Integer)
        Select Case INS_ADR(OpCode)
            Case ADR_ABS : ADRMODE_ABS()
            Case ADR_ABSX : ADRMODE_ABSX()
            Case ADR_ABSY : ADRMODE_ABSY()
            Case ADR_IMM : savepc = PC : PC += 1 : INS_TICK += 1
            Case ADR_IMP : INS_TICK += 1
            Case ADR_IND : ADRMODE_IND()
            Case ADR_INDX : ADRMODE_INDX()
            Case ADR_INDY : ADRMODE_INDY()
            Case ADR_REL : ADRMODE_REL()
            Case ADR_ZP : Cycles += 1 : savepc = Read(PC) : PC += 1 : INS_TICK += 1
            Case ADR_ZPX : ADRMODE_ZPX()
            Case ADR_ZPY : ADRMODE_ZPY()
        End Select
        ADR_TICK += 1
    End Sub
#End Region
#Region "CPU Initialization Functions"
    Private Sub Init()
        INIT_ADR()
        INIT_BYTES()
        INIT_INST()
        INIT_TEXT()
        INIT_TICKS()

        ' Special OpCodes to handle IRQ/NMI
        INS_TICKS(&H100) = 7 : INS_INST(&H100) = INS_IRQ : INS_ADR(&H100) = ADR_IMP
        INS_TICKS(&H101) = 7 : INS_INST(&H101) = INS_NMI : INS_ADR(&H101) = ADR_IMP

        LogText("CPU 65" & Model & ": Initialized")
    End Sub
    Private Sub INIT_ADR()
        INS_ADR(&H0) = ADR_IMP
        INS_ADR(&H1) = ADR_INDX
        INS_ADR(&H2) = ADR_IMP
        INS_ADR(&H3) = ADR_IMP
        INS_ADR(&H4) = ADR_ZP
        INS_ADR(&H5) = ADR_ZP
        INS_ADR(&H6) = ADR_ZP
        INS_ADR(&H7) = ADR_IMP
        INS_ADR(&H8) = ADR_IMP
        INS_ADR(&H9) = ADR_IMM
        INS_ADR(&HA) = ADR_IMP
        INS_ADR(&HB) = ADR_IMP
        INS_ADR(&HC) = ADR_ABS
        INS_ADR(&HD) = ADR_ABS
        INS_ADR(&HE) = ADR_ABS
        INS_ADR(&HF) = ADR_IMP
        INS_ADR(&H10) = ADR_REL
        INS_ADR(&H11) = ADR_INDY
        INS_ADR(&H12) = ADR_INDZP
        INS_ADR(&H13) = ADR_IMP
        INS_ADR(&H14) = ADR_ZP
        INS_ADR(&H15) = ADR_ZPX
        INS_ADR(&H16) = ADR_ZPX
        INS_ADR(&H17) = ADR_IMP
        INS_ADR(&H18) = ADR_IMP
        INS_ADR(&H19) = ADR_ABSY
        INS_ADR(&H1A) = ADR_IMP
        INS_ADR(&H1B) = ADR_IMP
        INS_ADR(&H1C) = ADR_ABS
        INS_ADR(&H1D) = ADR_ABSX
        INS_ADR(&H1E) = ADR_ABSX
        INS_ADR(&H1F) = ADR_IMP
        INS_ADR(&H20) = ADR_ABS
        INS_ADR(&H21) = ADR_INDX
        INS_ADR(&H22) = ADR_IMP
        INS_ADR(&H23) = ADR_IMP
        INS_ADR(&H24) = ADR_ZP
        INS_ADR(&H25) = ADR_ZP
        INS_ADR(&H26) = ADR_ZP
        INS_ADR(&H27) = ADR_IMP
        INS_ADR(&H28) = ADR_IMP
        INS_ADR(&H29) = ADR_IMM
        INS_ADR(&H2A) = ADR_IMP
        INS_ADR(&H2B) = ADR_IMP
        INS_ADR(&H2C) = ADR_ABS
        INS_ADR(&H2D) = ADR_ABS
        INS_ADR(&H2E) = ADR_ABS
        INS_ADR(&H2F) = ADR_IMP
        INS_ADR(&H30) = ADR_REL
        INS_ADR(&H31) = ADR_INDY
        INS_ADR(&H32) = ADR_INDZP
        INS_ADR(&H33) = ADR_IMP
        INS_ADR(&H34) = ADR_ZPX
        INS_ADR(&H35) = ADR_ZPX
        INS_ADR(&H36) = ADR_ZPX
        INS_ADR(&H37) = ADR_IMP
        INS_ADR(&H38) = ADR_IMP
        INS_ADR(&H39) = ADR_ABSY
        INS_ADR(&H3A) = ADR_IMP
        INS_ADR(&H3B) = ADR_IMP
        INS_ADR(&H3C) = ADR_ABSX
        INS_ADR(&H3D) = ADR_ABSX
        INS_ADR(&H3E) = ADR_ABSX
        INS_ADR(&H3F) = ADR_IMP
        INS_ADR(&H40) = ADR_IMP
        INS_ADR(&H41) = ADR_INDX
        INS_ADR(&H42) = ADR_IMP
        INS_ADR(&H43) = ADR_IMP
        INS_ADR(&H44) = ADR_IMP
        INS_ADR(&H45) = ADR_ZP
        INS_ADR(&H46) = ADR_ZP
        INS_ADR(&H47) = ADR_IMP
        INS_ADR(&H48) = ADR_IMP
        INS_ADR(&H49) = ADR_IMM
        INS_ADR(&H4A) = ADR_IMP
        INS_ADR(&H4B) = ADR_IMP
        INS_ADR(&H4C) = ADR_ABS
        INS_ADR(&H4D) = ADR_ABS
        INS_ADR(&H4E) = ADR_ABS
        INS_ADR(&H4F) = ADR_IMP
        INS_ADR(&H50) = ADR_REL
        INS_ADR(&H51) = ADR_INDY
        INS_ADR(&H52) = ADR_INDZP
        INS_ADR(&H53) = ADR_IMP
        INS_ADR(&H54) = ADR_IMP
        INS_ADR(&H55) = ADR_ZPX
        INS_ADR(&H56) = ADR_ZPX
        INS_ADR(&H57) = ADR_IMP
        INS_ADR(&H58) = ADR_IMP
        INS_ADR(&H59) = ADR_ABSY
        INS_ADR(&H5A) = ADR_IMP
        INS_ADR(&H5B) = ADR_IMP
        INS_ADR(&H5C) = ADR_IMP
        INS_ADR(&H5D) = ADR_ABSX
        INS_ADR(&H5E) = ADR_ABSX
        INS_ADR(&H5F) = ADR_IMP
        INS_ADR(&H60) = ADR_IMP
        INS_ADR(&H61) = ADR_INDX
        INS_ADR(&H62) = ADR_IMP
        INS_ADR(&H63) = ADR_IMP
        INS_ADR(&H64) = ADR_ZP
        INS_ADR(&H65) = ADR_ZP
        INS_ADR(&H66) = ADR_ZP
        INS_ADR(&H67) = ADR_IMP
        INS_ADR(&H68) = ADR_IMP
        INS_ADR(&H69) = ADR_IMM
        INS_ADR(&H6A) = ADR_IMP
        INS_ADR(&H6B) = ADR_IMP
        INS_ADR(&H6C) = ADR_IND
        INS_ADR(&H6D) = ADR_ABS
        INS_ADR(&H6E) = ADR_ABS
        INS_ADR(&H6F) = ADR_IMP
        INS_ADR(&H70) = ADR_REL
        INS_ADR(&H71) = ADR_INDY
        INS_ADR(&H72) = ADR_INDZP
        INS_ADR(&H73) = ADR_IMP
        INS_ADR(&H74) = ADR_ZPX
        INS_ADR(&H75) = ADR_ZPX
        INS_ADR(&H76) = ADR_ZPX
        INS_ADR(&H77) = ADR_IMP
        INS_ADR(&H78) = ADR_IMP
        INS_ADR(&H79) = ADR_ABSY
        INS_ADR(&H7A) = ADR_IMP
        INS_ADR(&H7B) = ADR_IMP
        INS_ADR(&H7C) = ADR_INDABSX
        INS_ADR(&H7D) = ADR_ABSX
        INS_ADR(&H7E) = ADR_ABSX
        INS_ADR(&H7F) = ADR_IMP
        INS_ADR(&H80) = ADR_REL
        INS_ADR(&H81) = ADR_INDX
        INS_ADR(&H82) = ADR_IMP
        INS_ADR(&H83) = ADR_IMP
        INS_ADR(&H84) = ADR_ZP
        INS_ADR(&H85) = ADR_ZP
        INS_ADR(&H86) = ADR_ZP
        INS_ADR(&H87) = ADR_IMP
        INS_ADR(&H88) = ADR_IMP
        INS_ADR(&H89) = ADR_IMM
        INS_ADR(&H8A) = ADR_IMP
        INS_ADR(&H8B) = ADR_IMP
        INS_ADR(&H8C) = ADR_ABS
        INS_ADR(&H8D) = ADR_ABS
        INS_ADR(&H8E) = ADR_ABS
        INS_ADR(&H8F) = ADR_IMP
        INS_ADR(&H90) = ADR_REL
        INS_ADR(&H91) = ADR_INDY
        INS_ADR(&H92) = ADR_INDZP
        INS_ADR(&H93) = ADR_IMP
        INS_ADR(&H94) = ADR_ZPX
        INS_ADR(&H95) = ADR_ZPX
        INS_ADR(&H96) = ADR_ZPY
        INS_ADR(&H97) = ADR_IMP
        INS_ADR(&H98) = ADR_IMP
        INS_ADR(&H99) = ADR_ABSY
        INS_ADR(&H9A) = ADR_IMP
        INS_ADR(&H9B) = ADR_IMP
        INS_ADR(&H9C) = ADR_ABS
        INS_ADR(&H9D) = ADR_ABSX
        INS_ADR(&H9E) = ADR_ABSX
        INS_ADR(&H9F) = ADR_IMP
        INS_ADR(&HA0) = ADR_IMM
        INS_ADR(&HA1) = ADR_INDX
        INS_ADR(&HA2) = ADR_IMM
        INS_ADR(&HA3) = ADR_IMP
        INS_ADR(&HA4) = ADR_ZP
        INS_ADR(&HA5) = ADR_ZP
        INS_ADR(&HA6) = ADR_ZP
        INS_ADR(&HA7) = ADR_IMP
        INS_ADR(&HA8) = ADR_IMP
        INS_ADR(&HA9) = ADR_IMM
        INS_ADR(&HAA) = ADR_IMP
        INS_ADR(&HAB) = ADR_IMP
        INS_ADR(&HAC) = ADR_ABS
        INS_ADR(&HAD) = ADR_ABS
        INS_ADR(&HAE) = ADR_ABS
        INS_ADR(&HAF) = ADR_IMP
        INS_ADR(&HB0) = ADR_REL
        INS_ADR(&HB1) = ADR_INDY
        INS_ADR(&HB2) = ADR_INDZP
        INS_ADR(&HB3) = ADR_IMP
        INS_ADR(&HB4) = ADR_ZPX
        INS_ADR(&HB5) = ADR_ZPX
        INS_ADR(&HB6) = ADR_ZPY
        INS_ADR(&HB7) = ADR_IMP
        INS_ADR(&HB8) = ADR_IMP
        INS_ADR(&HB9) = ADR_ABSY
        INS_ADR(&HBA) = ADR_IMP
        INS_ADR(&HBB) = ADR_IMP
        INS_ADR(&HBC) = ADR_ABSX
        INS_ADR(&HBD) = ADR_ABSX
        INS_ADR(&HBE) = ADR_ABSY
        INS_ADR(&HBF) = ADR_IMP
        INS_ADR(&HC0) = ADR_IMM
        INS_ADR(&HC1) = ADR_INDX
        INS_ADR(&HC2) = ADR_IMP
        INS_ADR(&HC3) = ADR_IMP
        INS_ADR(&HC4) = ADR_ZP
        INS_ADR(&HC5) = ADR_ZP
        INS_ADR(&HC6) = ADR_ZP
        INS_ADR(&HC7) = ADR_IMP
        INS_ADR(&HC8) = ADR_IMP
        INS_ADR(&HC9) = ADR_IMM
        INS_ADR(&HCA) = ADR_IMP
        INS_ADR(&HCB) = ADR_IMP
        INS_ADR(&HCC) = ADR_ABS
        INS_ADR(&HCD) = ADR_ABS
        INS_ADR(&HCE) = ADR_ABS
        INS_ADR(&HCF) = ADR_IMP
        INS_ADR(&HD0) = ADR_REL
        INS_ADR(&HD1) = ADR_INDY
        INS_ADR(&HD2) = ADR_INDZP
        INS_ADR(&HD3) = ADR_IMP
        INS_ADR(&HD4) = ADR_IMP
        INS_ADR(&HD5) = ADR_ZPX
        INS_ADR(&HD6) = ADR_ZPX
        INS_ADR(&HD7) = ADR_IMP
        INS_ADR(&HD8) = ADR_IMP
        INS_ADR(&HD9) = ADR_ABSY
        INS_ADR(&HDA) = ADR_IMP
        INS_ADR(&HDB) = ADR_IMP
        INS_ADR(&HDC) = ADR_IMP
        INS_ADR(&HDD) = ADR_ABSX
        INS_ADR(&HDE) = ADR_ABSX
        INS_ADR(&HDF) = ADR_IMP
        INS_ADR(&HE0) = ADR_IMM
        INS_ADR(&HE1) = ADR_INDX
        INS_ADR(&HE2) = ADR_IMP
        INS_ADR(&HE3) = ADR_IMP
        INS_ADR(&HE4) = ADR_ZP
        INS_ADR(&HE5) = ADR_ZP
        INS_ADR(&HE6) = ADR_ZP
        INS_ADR(&HE7) = ADR_IMP
        INS_ADR(&HE8) = ADR_IMP
        INS_ADR(&HE9) = ADR_IMM
        INS_ADR(&HEA) = ADR_IMP
        INS_ADR(&HEB) = ADR_IMP
        INS_ADR(&HEC) = ADR_ABS
        INS_ADR(&HED) = ADR_ABS
        INS_ADR(&HEE) = ADR_ABS
        INS_ADR(&HEF) = ADR_IMP
        INS_ADR(&HF0) = ADR_REL
        INS_ADR(&HF1) = ADR_INDY
        INS_ADR(&HF2) = ADR_INDZP
        INS_ADR(&HF3) = ADR_IMP
        INS_ADR(&HF4) = ADR_IMP
        INS_ADR(&HF5) = ADR_ZPX
        INS_ADR(&HF6) = ADR_ZPX
        INS_ADR(&HF7) = ADR_IMP
        INS_ADR(&HF8) = ADR_IMP
        INS_ADR(&HF9) = ADR_ABSY
        INS_ADR(&HFA) = ADR_IMP
        INS_ADR(&HFB) = ADR_IMP
        INS_ADR(&HFC) = ADR_IMP
        INS_ADR(&HFD) = ADR_ABSX
        INS_ADR(&HFE) = ADR_ABSX
        INS_ADR(&HFF) = ADR_IMP
    End Sub
    Private Sub INIT_BYTES()
        INS_BYTES(&H0) = 1
        INS_BYTES(&H1) = 2
        INS_BYTES(&H2) = 1
        INS_BYTES(&H3) = 1
        INS_BYTES(&H4) = 1
        INS_BYTES(&H5) = 2
        INS_BYTES(&H6) = 2
        INS_BYTES(&H7) = 1
        INS_BYTES(&H8) = 1
        INS_BYTES(&H9) = 2
        INS_BYTES(&HA) = 1
        INS_BYTES(&HB) = 1
        INS_BYTES(&HC) = 1
        INS_BYTES(&HD) = 3
        INS_BYTES(&HE) = 3
        INS_BYTES(&HF) = 1
        INS_BYTES(&H10) = 2
        INS_BYTES(&H11) = 2
        INS_BYTES(&H12) = 1
        INS_BYTES(&H13) = 1
        INS_BYTES(&H14) = 1
        INS_BYTES(&H15) = 2
        INS_BYTES(&H16) = 2
        INS_BYTES(&H17) = 1
        INS_BYTES(&H18) = 1
        INS_BYTES(&H19) = 3
        INS_BYTES(&H1A) = 1
        INS_BYTES(&H1B) = 1
        INS_BYTES(&H1C) = 1
        INS_BYTES(&H1D) = 3
        INS_BYTES(&H1E) = 3
        INS_BYTES(&H1F) = 1
        INS_BYTES(&H20) = 3
        INS_BYTES(&H21) = 2
        INS_BYTES(&H22) = 1
        INS_BYTES(&H23) = 1
        INS_BYTES(&H24) = 2
        INS_BYTES(&H25) = 2
        INS_BYTES(&H26) = 2
        INS_BYTES(&H27) = 1
        INS_BYTES(&H28) = 1
        INS_BYTES(&H29) = 2
        INS_BYTES(&H2A) = 1
        INS_BYTES(&H2B) = 1
        INS_BYTES(&H2C) = 3
        INS_BYTES(&H2D) = 3
        INS_BYTES(&H2E) = 3
        INS_BYTES(&H2F) = 1
        INS_BYTES(&H30) = 2
        INS_BYTES(&H31) = 2
        INS_BYTES(&H32) = 2
        INS_BYTES(&H33) = 1
        INS_BYTES(&H34) = 2
        INS_BYTES(&H35) = 2
        INS_BYTES(&H36) = 2
        INS_BYTES(&H37) = 1
        INS_BYTES(&H38) = 1
        INS_BYTES(&H39) = 3
        INS_BYTES(&H3A) = 1
        INS_BYTES(&H3B) = 1
        INS_BYTES(&H3C) = 3
        INS_BYTES(&H3D) = 3
        INS_BYTES(&H3E) = 3
        INS_BYTES(&H3F) = 1
        INS_BYTES(&H40) = 1
        INS_BYTES(&H41) = 2
        INS_BYTES(&H42) = 1
        INS_BYTES(&H43) = 1
        INS_BYTES(&H44) = 1
        INS_BYTES(&H45) = 2
        INS_BYTES(&H46) = 2
        INS_BYTES(&H47) = 1
        INS_BYTES(&H48) = 1
        INS_BYTES(&H49) = 2
        INS_BYTES(&H4A) = 1
        INS_BYTES(&H4B) = 1
        INS_BYTES(&H4C) = 3
        INS_BYTES(&H4D) = 3
        INS_BYTES(&H4E) = 3
        INS_BYTES(&H4F) = 1
        INS_BYTES(&H50) = 2
        INS_BYTES(&H51) = 2
        INS_BYTES(&H52) = 2
        INS_BYTES(&H53) = 1
        INS_BYTES(&H54) = 1
        INS_BYTES(&H55) = 2
        INS_BYTES(&H56) = 2
        INS_BYTES(&H57) = 1
        INS_BYTES(&H58) = 1
        INS_BYTES(&H59) = 3
        INS_BYTES(&H5A) = 1
        INS_BYTES(&H5B) = 1
        INS_BYTES(&H5C) = 1
        INS_BYTES(&H5D) = 3
        INS_BYTES(&H5E) = 3
        INS_BYTES(&H5F) = 1
        INS_BYTES(&H60) = 1
        INS_BYTES(&H61) = 2
        INS_BYTES(&H62) = 1
        INS_BYTES(&H63) = 1
        INS_BYTES(&H64) = 2
        INS_BYTES(&H65) = 2
        INS_BYTES(&H66) = 2
        INS_BYTES(&H67) = 1
        INS_BYTES(&H68) = 1
        INS_BYTES(&H69) = 2
        INS_BYTES(&H6A) = 1
        INS_BYTES(&H6B) = 1
        INS_BYTES(&H6C) = 3
        INS_BYTES(&H6D) = 3
        INS_BYTES(&H6E) = 3
        INS_BYTES(&H6F) = 1
        INS_BYTES(&H70) = 2
        INS_BYTES(&H71) = 2
        INS_BYTES(&H72) = 2
        INS_BYTES(&H73) = 1
        INS_BYTES(&H74) = 2
        INS_BYTES(&H75) = 2
        INS_BYTES(&H76) = 2
        INS_BYTES(&H77) = 1
        INS_BYTES(&H78) = 1
        INS_BYTES(&H79) = 3
        INS_BYTES(&H7A) = 1
        INS_BYTES(&H7B) = 1
        INS_BYTES(&H7C) = 3
        INS_BYTES(&H7D) = 3
        INS_BYTES(&H7E) = 3
        INS_BYTES(&H7F) = 1
        INS_BYTES(&H80) = 2
        INS_BYTES(&H81) = 2
        INS_BYTES(&H82) = 1
        INS_BYTES(&H83) = 1
        INS_BYTES(&H84) = 2
        INS_BYTES(&H85) = 2
        INS_BYTES(&H86) = 2
        INS_BYTES(&H87) = 1
        INS_BYTES(&H88) = 1
        INS_BYTES(&H89) = 2
        INS_BYTES(&H8A) = 1
        INS_BYTES(&H8B) = 1
        INS_BYTES(&H8C) = 3
        INS_BYTES(&H8D) = 3
        INS_BYTES(&H8E) = 3
        INS_BYTES(&H8F) = 1
        INS_BYTES(&H90) = 2
        INS_BYTES(&H91) = 2
        INS_BYTES(&H92) = 2
        INS_BYTES(&H93) = 1
        INS_BYTES(&H94) = 2
        INS_BYTES(&H95) = 2
        INS_BYTES(&H96) = 2
        INS_BYTES(&H97) = 1
        INS_BYTES(&H98) = 1
        INS_BYTES(&H99) = 3
        INS_BYTES(&H9A) = 1
        INS_BYTES(&H9B) = 1
        INS_BYTES(&H9C) = 3
        INS_BYTES(&H9D) = 3
        INS_BYTES(&H9E) = 3
        INS_BYTES(&H9F) = 1
        INS_BYTES(&HA0) = 2
        INS_BYTES(&HA1) = 2
        INS_BYTES(&HA2) = 2
        INS_BYTES(&HA3) = 1
        INS_BYTES(&HA4) = 2
        INS_BYTES(&HA5) = 2
        INS_BYTES(&HA6) = 2
        INS_BYTES(&HA7) = 1
        INS_BYTES(&HA8) = 1
        INS_BYTES(&HA9) = 2
        INS_BYTES(&HAA) = 1
        INS_BYTES(&HAB) = 1
        INS_BYTES(&HAC) = 3
        INS_BYTES(&HAD) = 3
        INS_BYTES(&HAE) = 3
        INS_BYTES(&HAF) = 1
        INS_BYTES(&HB0) = 2
        INS_BYTES(&HB1) = 2
        INS_BYTES(&HB2) = 2
        INS_BYTES(&HB3) = 1
        INS_BYTES(&HB4) = 2
        INS_BYTES(&HB5) = 2
        INS_BYTES(&HB6) = 2
        INS_BYTES(&HB7) = 1
        INS_BYTES(&HB8) = 1
        INS_BYTES(&HB9) = 3
        INS_BYTES(&HBA) = 1
        INS_BYTES(&HBB) = 1
        INS_BYTES(&HBC) = 3
        INS_BYTES(&HBD) = 3
        INS_BYTES(&HBE) = 3
        INS_BYTES(&HBF) = 1
        INS_BYTES(&HC0) = 2
        INS_BYTES(&HC1) = 2
        INS_BYTES(&HC2) = 1
        INS_BYTES(&HC3) = 1
        INS_BYTES(&HC4) = 2
        INS_BYTES(&HC5) = 2
        INS_BYTES(&HC6) = 2
        INS_BYTES(&HC7) = 1
        INS_BYTES(&HC8) = 1
        INS_BYTES(&HC9) = 2
        INS_BYTES(&HCA) = 1
        INS_BYTES(&HCB) = 1
        INS_BYTES(&HCC) = 3
        INS_BYTES(&HCD) = 3
        INS_BYTES(&HCE) = 3
        INS_BYTES(&HCF) = 1
        INS_BYTES(&HD0) = 2
        INS_BYTES(&HD1) = 2
        INS_BYTES(&HD2) = 2
        INS_BYTES(&HD3) = 1
        INS_BYTES(&HD4) = 1
        INS_BYTES(&HD5) = 2
        INS_BYTES(&HD6) = 2
        INS_BYTES(&HD7) = 1
        INS_BYTES(&HD8) = 1
        INS_BYTES(&HD9) = 3
        INS_BYTES(&HDA) = 1
        INS_BYTES(&HDB) = 1
        INS_BYTES(&HDC) = 1
        INS_BYTES(&HDD) = 3
        INS_BYTES(&HDE) = 3
        INS_BYTES(&HDF) = 1
        INS_BYTES(&HE0) = 2
        INS_BYTES(&HE1) = 2
        INS_BYTES(&HE2) = 1
        INS_BYTES(&HE3) = 1
        INS_BYTES(&HE4) = 2
        INS_BYTES(&HE5) = 2
        INS_BYTES(&HE6) = 2
        INS_BYTES(&HE7) = 1
        INS_BYTES(&HE8) = 1
        INS_BYTES(&HE9) = 2
        INS_BYTES(&HEA) = 1
        INS_BYTES(&HEB) = 1
        INS_BYTES(&HEC) = 3
        INS_BYTES(&HED) = 3
        INS_BYTES(&HEE) = 3
        INS_BYTES(&HEF) = 1
        INS_BYTES(&HF0) = 2
        INS_BYTES(&HF1) = 2
        INS_BYTES(&HF2) = 2
        INS_BYTES(&HF3) = 1
        INS_BYTES(&HF4) = 1
        INS_BYTES(&HF5) = 2
        INS_BYTES(&HF6) = 2
        INS_BYTES(&HF7) = 1
        INS_BYTES(&HF8) = 1
        INS_BYTES(&HF9) = 3
        INS_BYTES(&HFA) = 1
        INS_BYTES(&HFB) = 1
        INS_BYTES(&HFC) = 1
        INS_BYTES(&HFD) = 3
        INS_BYTES(&HFE) = 3
        INS_BYTES(&HFF) = 1
    End Sub
    Private Sub INIT_INST()
        INS_INST(&H0) = INS_BRK
        INS_INST(&H1) = INS_ORA
        INS_INST(&H2) = INS_NOP
        INS_INST(&H3) = INS_NOP
        INS_INST(&H4) = INS_NOP
        INS_INST(&H5) = INS_ORA
        INS_INST(&H6) = INS_ASL
        INS_INST(&H7) = INS_NOP
        INS_INST(&H8) = INS_PHP
        INS_INST(&H9) = INS_ORA
        INS_INST(&HA) = INS_ASLA
        INS_INST(&HB) = INS_NOP
        INS_INST(&HC) = INS_NOP
        INS_INST(&HD) = INS_ORA
        INS_INST(&HE) = INS_ASL
        INS_INST(&HF) = INS_NOP
        INS_INST(&H10) = INS_BPL
        INS_INST(&H11) = INS_ORA
        INS_INST(&H12) = INS_ORA
        INS_INST(&H13) = INS_NOP
        INS_INST(&H14) = INS_NOP
        INS_INST(&H15) = INS_ORA
        INS_INST(&H16) = INS_ASL
        INS_INST(&H17) = INS_NOP
        INS_INST(&H18) = INS_CLC
        INS_INST(&H19) = INS_ORA
        INS_INST(&H1A) = INS_INA
        INS_INST(&H1B) = INS_NOP
        INS_INST(&H1C) = INS_NOP
        INS_INST(&H1D) = INS_ORA
        INS_INST(&H1E) = INS_ASL
        INS_INST(&H1F) = INS_NOP
        INS_INST(&H20) = INS_JSR
        INS_INST(&H21) = INS_AND
        INS_INST(&H22) = INS_NOP
        INS_INST(&H23) = INS_NOP
        INS_INST(&H24) = INS_BIT
        INS_INST(&H25) = INS_AND
        INS_INST(&H26) = INS_ROL
        INS_INST(&H27) = INS_NOP
        INS_INST(&H28) = INS_PLP
        INS_INST(&H29) = INS_AND
        INS_INST(&H2A) = INS_ROLA
        INS_INST(&H2B) = INS_NOP
        INS_INST(&H2C) = INS_BIT
        INS_INST(&H2D) = INS_AND
        INS_INST(&H2E) = INS_ROL
        INS_INST(&H2F) = INS_NOP
        INS_INST(&H30) = INS_BMI
        INS_INST(&H31) = INS_AND
        INS_INST(&H32) = INS_AND
        INS_INST(&H33) = INS_NOP
        INS_INST(&H34) = INS_BIT
        INS_INST(&H35) = INS_AND
        INS_INST(&H36) = INS_ROL
        INS_INST(&H37) = INS_NOP
        INS_INST(&H38) = INS_SEC
        INS_INST(&H39) = INS_AND
        INS_INST(&H3A) = INS_DEA
        INS_INST(&H3B) = INS_NOP
        INS_INST(&H3C) = INS_BIT
        INS_INST(&H3D) = INS_AND
        INS_INST(&H3E) = INS_ROL
        INS_INST(&H3F) = INS_NOP
        INS_INST(&H40) = INS_RTI
        INS_INST(&H41) = INS_EOR
        INS_INST(&H42) = INS_NOP
        INS_INST(&H43) = INS_NOP
        INS_INST(&H44) = INS_NOP
        INS_INST(&H45) = INS_EOR
        INS_INST(&H46) = INS_LSR
        INS_INST(&H47) = INS_NOP
        INS_INST(&H48) = INS_PHA
        INS_INST(&H49) = INS_EOR
        INS_INST(&H4A) = INS_LSRA
        INS_INST(&H4B) = INS_NOP
        INS_INST(&H4C) = INS_JMP
        INS_INST(&H4D) = INS_EOR
        INS_INST(&H4E) = INS_LSR
        INS_INST(&H4F) = INS_NOP
        INS_INST(&H50) = INS_BVC
        INS_INST(&H51) = INS_EOR
        INS_INST(&H52) = INS_EOR
        INS_INST(&H53) = INS_NOP
        INS_INST(&H54) = INS_NOP
        INS_INST(&H55) = INS_EOR
        INS_INST(&H56) = INS_LSR
        INS_INST(&H57) = INS_NOP
        INS_INST(&H58) = INS_CLI
        INS_INST(&H59) = INS_EOR
        INS_INST(&H5A) = INS_PHY
        INS_INST(&H5B) = INS_NOP
        INS_INST(&H5C) = INS_NOP
        INS_INST(&H5D) = INS_EOR
        INS_INST(&H5E) = INS_LSR
        INS_INST(&H5F) = INS_NOP
        INS_INST(&H60) = INS_RTS
        INS_INST(&H61) = INS_ADC
        INS_INST(&H62) = INS_NOP
        INS_INST(&H63) = INS_NOP
        INS_INST(&H64) = INS_NOP
        INS_INST(&H65) = INS_ADC
        INS_INST(&H66) = INS_ROR
        INS_INST(&H67) = INS_NOP
        INS_INST(&H68) = INS_PLA
        INS_INST(&H69) = INS_ADC
        INS_INST(&H6A) = INS_RORA
        INS_INST(&H6B) = INS_NOP
        INS_INST(&H6C) = INS_JMP
        INS_INST(&H6D) = INS_ADC
        INS_INST(&H6E) = INS_ROR
        INS_INST(&H6F) = INS_NOP
        INS_INST(&H70) = INS_BVS
        INS_INST(&H71) = INS_ADC
        INS_INST(&H72) = INS_ADC
        INS_INST(&H73) = INS_NOP
        INS_INST(&H74) = INS_NOP
        INS_INST(&H75) = INS_ADC
        INS_INST(&H76) = INS_ROR
        INS_INST(&H77) = INS_NOP
        INS_INST(&H78) = INS_SEI
        INS_INST(&H79) = INS_ADC
        INS_INST(&H7A) = INS_PLY
        INS_INST(&H7B) = INS_NOP
        INS_INST(&H7C) = INS_JMP
        INS_INST(&H7D) = INS_ADC
        INS_INST(&H7E) = INS_ROR
        INS_INST(&H7F) = INS_NOP
        INS_INST(&H80) = INS_BRA
        INS_INST(&H81) = INS_STA
        INS_INST(&H82) = INS_NOP
        INS_INST(&H83) = INS_NOP
        INS_INST(&H84) = INS_STY
        INS_INST(&H85) = INS_STA
        INS_INST(&H86) = INS_STX
        INS_INST(&H87) = INS_NOP
        INS_INST(&H88) = INS_DEY
        INS_INST(&H89) = INS_BIT
        INS_INST(&H8A) = INS_TXA
        INS_INST(&H8B) = INS_NOP
        INS_INST(&H8C) = INS_STY
        INS_INST(&H8D) = INS_STA
        INS_INST(&H8E) = INS_STX
        INS_INST(&H8F) = INS_NOP
        INS_INST(&H90) = INS_BCC
        INS_INST(&H91) = INS_STA
        INS_INST(&H92) = INS_STA
        INS_INST(&H93) = INS_NOP
        INS_INST(&H94) = INS_STY
        INS_INST(&H95) = INS_STA
        INS_INST(&H96) = INS_STX
        INS_INST(&H97) = INS_NOP
        INS_INST(&H98) = INS_TYA
        INS_INST(&H99) = INS_STA
        INS_INST(&H9A) = INS_TXS
        INS_INST(&H9B) = INS_NOP
        INS_INST(&H9C) = INS_NOP
        INS_INST(&H9D) = INS_STA
        INS_INST(&H9E) = INS_NOP
        INS_INST(&H9F) = INS_NOP
        INS_INST(&HA0) = INS_LDY
        INS_INST(&HA1) = INS_LDA
        INS_INST(&HA2) = INS_LDX
        INS_INST(&HA3) = INS_NOP
        INS_INST(&HA4) = INS_LDY
        INS_INST(&HA5) = INS_LDA
        INS_INST(&HA6) = INS_LDX
        INS_INST(&HA7) = INS_NOP
        INS_INST(&HA8) = INS_TAY
        INS_INST(&HA9) = INS_LDA
        INS_INST(&HAA) = INS_TAX
        INS_INST(&HAB) = INS_NOP
        INS_INST(&HAC) = INS_LDY
        INS_INST(&HAD) = INS_LDA
        INS_INST(&HAE) = INS_LDX
        INS_INST(&HAF) = INS_NOP
        INS_INST(&HB0) = INS_BCS
        INS_INST(&HB1) = INS_LDA
        INS_INST(&HB2) = INS_LDA
        INS_INST(&HB3) = INS_NOP
        INS_INST(&HB4) = INS_LDY
        INS_INST(&HB5) = INS_LDA
        INS_INST(&HB6) = INS_LDX
        INS_INST(&HB7) = INS_NOP
        INS_INST(&HB8) = INS_CLV
        INS_INST(&HB9) = INS_LDA
        INS_INST(&HBA) = INS_TSX
        INS_INST(&HBB) = INS_NOP
        INS_INST(&HBC) = INS_LDY
        INS_INST(&HBD) = INS_LDA
        INS_INST(&HBE) = INS_LDX
        INS_INST(&HBF) = INS_NOP
        INS_INST(&HC0) = INS_CPY
        INS_INST(&HC1) = INS_CMP
        INS_INST(&HC2) = INS_NOP
        INS_INST(&HC3) = INS_NOP
        INS_INST(&HC4) = INS_CPY
        INS_INST(&HC5) = INS_CMP
        INS_INST(&HC6) = INS_DEC
        INS_INST(&HC7) = INS_NOP
        INS_INST(&HC8) = INS_INY
        INS_INST(&HC9) = INS_CMP
        INS_INST(&HCA) = INS_DEX
        INS_INST(&HCB) = INS_NOP
        INS_INST(&HCC) = INS_CPY
        INS_INST(&HCD) = INS_CMP
        INS_INST(&HCE) = INS_DEC
        INS_INST(&HCF) = INS_NOP
        INS_INST(&HD0) = INS_BNE
        INS_INST(&HD1) = INS_CMP
        INS_INST(&HD2) = INS_CMP
        INS_INST(&HD3) = INS_NOP
        INS_INST(&HD4) = INS_NOP
        INS_INST(&HD5) = INS_CMP
        INS_INST(&HD6) = INS_DEC
        INS_INST(&HD7) = INS_NOP
        INS_INST(&HD8) = INS_CLD
        INS_INST(&HD9) = INS_CMP
        INS_INST(&HDA) = INS_PHX
        INS_INST(&HDB) = INS_NOP
        INS_INST(&HDC) = INS_NOP
        INS_INST(&HDD) = INS_CMP
        INS_INST(&HDE) = INS_DEC
        INS_INST(&HDF) = INS_NOP
        INS_INST(&HE0) = INS_CPX
        INS_INST(&HE1) = INS_SBC
        INS_INST(&HE2) = INS_NOP
        INS_INST(&HE3) = INS_NOP
        INS_INST(&HE4) = INS_CPX
        INS_INST(&HE5) = INS_SBC
        INS_INST(&HE6) = INS_INC
        INS_INST(&HE7) = INS_NOP
        INS_INST(&HE8) = INS_INX
        INS_INST(&HE9) = INS_SBC
        INS_INST(&HEA) = INS_NOP
        INS_INST(&HEB) = INS_NOP
        INS_INST(&HEC) = INS_CPX
        INS_INST(&HED) = INS_SBC
        INS_INST(&HEE) = INS_INC
        INS_INST(&HEF) = INS_NOP
        INS_INST(&HF0) = INS_BEQ
        INS_INST(&HF1) = INS_SBC
        INS_INST(&HF2) = INS_SBC
        INS_INST(&HF3) = INS_NOP
        INS_INST(&HF4) = INS_NOP
        INS_INST(&HF5) = INS_SBC
        INS_INST(&HF6) = INS_INC
        INS_INST(&HF7) = INS_NOP
        INS_INST(&HF8) = INS_SED
        INS_INST(&HF9) = INS_SBC
        INS_INST(&HFA) = INS_PLX
        INS_INST(&HFB) = INS_NOP
        INS_INST(&HFC) = INS_NOP
        INS_INST(&HFD) = INS_SBC
        INS_INST(&HFE) = INS_INC
        INS_INST(&HFF) = INS_NOP
    End Sub
    Private Sub INIT_TEXT()
        INS_TEXT(&H0) = "BRK"
        INS_TEXT(&H1) = "ORA"
        INS_TEXT(&H2) = "HLT"
        INS_TEXT(&H3) = "NOP"
        INS_TEXT(&H4) = "NOP"
        INS_TEXT(&H5) = "ORA"
        INS_TEXT(&H6) = "ASL"
        INS_TEXT(&H7) = "NOP"
        INS_TEXT(&H8) = "PHP"
        INS_TEXT(&H9) = "ORA"
        INS_TEXT(&HA) = "ASL"
        INS_TEXT(&HB) = "NOP"
        INS_TEXT(&HC) = "NOP"
        INS_TEXT(&HD) = "ORA"
        INS_TEXT(&HE) = "ASL"
        INS_TEXT(&HF) = "NOP"
        INS_TEXT(&H10) = "BPL"
        INS_TEXT(&H11) = "ORA"
        INS_TEXT(&H12) = "HLT"
        INS_TEXT(&H13) = "NOP"
        INS_TEXT(&H14) = "NOP"
        INS_TEXT(&H15) = "ORA"
        INS_TEXT(&H16) = "ASL"
        INS_TEXT(&H17) = "NOP"
        INS_TEXT(&H18) = "CLC"
        INS_TEXT(&H19) = "NOP"
        INS_TEXT(&H1A) = "INA"
        INS_TEXT(&H1B) = "NOP"
        INS_TEXT(&H1C) = "NOP"
        INS_TEXT(&H1D) = "ORA"
        INS_TEXT(&H1E) = "ASL"
        INS_TEXT(&H1F) = "NOP"
        INS_TEXT(&H20) = "JSR"
        INS_TEXT(&H21) = "AND"
        INS_TEXT(&H22) = "NOP"
        INS_TEXT(&H23) = "NOP"
        INS_TEXT(&H24) = "BIT"
        INS_TEXT(&H25) = "AND"
        INS_TEXT(&H26) = "ROL"
        INS_TEXT(&H27) = "NOP"
        INS_TEXT(&H28) = "PLP"
        INS_TEXT(&H29) = "AND"
        INS_TEXT(&H2A) = "ROL"
        INS_TEXT(&H2B) = "NOP"
        INS_TEXT(&H2C) = "BIT"
        INS_TEXT(&H2D) = "AND"
        INS_TEXT(&H2E) = "ROL"
        INS_TEXT(&H2F) = "NOP"
        INS_TEXT(&H30) = "BMI"
        INS_TEXT(&H31) = "AND"
        INS_TEXT(&H32) = "HLT"
        INS_TEXT(&H33) = "NOP"
        INS_TEXT(&H34) = "BIT"
        INS_TEXT(&H35) = "AND"
        INS_TEXT(&H36) = "ROL"
        INS_TEXT(&H37) = "NOP"
        INS_TEXT(&H38) = "SEC"
        INS_TEXT(&H39) = "AND"
        INS_TEXT(&H3A) = "DEA"
        INS_TEXT(&H3B) = "NOP"
        INS_TEXT(&H3C) = "BIT"
        INS_TEXT(&H3D) = "AND"
        INS_TEXT(&H3E) = "ROL"
        INS_TEXT(&H3F) = "NOP"
        INS_TEXT(&H40) = "RTI"
        INS_TEXT(&H41) = "EOR"
        INS_TEXT(&H42) = "NOP"
        INS_TEXT(&H43) = "NOP"
        INS_TEXT(&H44) = "NOP"
        INS_TEXT(&H45) = "EOR"
        INS_TEXT(&H46) = "LSR"
        INS_TEXT(&H47) = "NOP"
        INS_TEXT(&H48) = "PHA"
        INS_TEXT(&H49) = "EOR"
        INS_TEXT(&H4A) = "LSR"
        INS_TEXT(&H4B) = "NOP"
        INS_TEXT(&H4C) = "JMP"
        INS_TEXT(&H4D) = "EOR"
        INS_TEXT(&H4E) = "LSR"
        INS_TEXT(&H4F) = "NOP"
        INS_TEXT(&H50) = "BVC"
        INS_TEXT(&H51) = "EOR"
        INS_TEXT(&H52) = "EOR"
        INS_TEXT(&H53) = "NOP"
        INS_TEXT(&H54) = "NOP"
        INS_TEXT(&H55) = "EOR"
        INS_TEXT(&H56) = "LSR"
        INS_TEXT(&H57) = "NOP"
        INS_TEXT(&H58) = "CLI"
        INS_TEXT(&H59) = "EOR"
        INS_TEXT(&H5A) = "PHY"
        INS_TEXT(&H5B) = "NOP"
        INS_TEXT(&H5C) = "NOP"
        INS_TEXT(&H5D) = "EOR"
        INS_TEXT(&H5E) = "LSR"
        INS_TEXT(&H5F) = "NOP"
        INS_TEXT(&H60) = "RTS"
        INS_TEXT(&H61) = "ADC"
        INS_TEXT(&H62) = "NOP"
        INS_TEXT(&H63) = "NOP"
        INS_TEXT(&H64) = "NOP"
        INS_TEXT(&H65) = "ADC"
        INS_TEXT(&H66) = "ROR"
        INS_TEXT(&H67) = "NOP"
        INS_TEXT(&H68) = "PLA"
        INS_TEXT(&H69) = "ADC"
        INS_TEXT(&H6A) = "ROR"
        INS_TEXT(&H6B) = "NOP"
        INS_TEXT(&H6C) = "JMP"
        INS_TEXT(&H6D) = "ADC"
        INS_TEXT(&H6E) = "ROR"
        INS_TEXT(&H6F) = "NOP"
        INS_TEXT(&H70) = "BVS"
        INS_TEXT(&H71) = "ADC"
        INS_TEXT(&H72) = "ADC"
        INS_TEXT(&H73) = "NOP"
        INS_TEXT(&H74) = "NOP"
        INS_TEXT(&H75) = "ADC"
        INS_TEXT(&H76) = "ROR"
        INS_TEXT(&H77) = "NOP"
        INS_TEXT(&H78) = "SEI"
        INS_TEXT(&H79) = "ADC"
        INS_TEXT(&H7A) = "PLY"
        INS_TEXT(&H7B) = "NOP"
        INS_TEXT(&H7C) = "JMP"
        INS_TEXT(&H7D) = "ADC"
        INS_TEXT(&H7E) = "ROR"
        INS_TEXT(&H7F) = "NOP"
        INS_TEXT(&H80) = "BRA"
        INS_TEXT(&H81) = "STA"
        INS_TEXT(&H82) = "NOP"
        INS_TEXT(&H83) = "NOP"
        INS_TEXT(&H84) = "STY"
        INS_TEXT(&H85) = "STA"
        INS_TEXT(&H86) = "STX"
        INS_TEXT(&H87) = "NOP"
        INS_TEXT(&H88) = "DEY"
        INS_TEXT(&H89) = "BIT"
        INS_TEXT(&H8A) = "TXA"
        INS_TEXT(&H8B) = "NOP"
        INS_TEXT(&H8C) = "STY"
        INS_TEXT(&H8D) = "STA"
        INS_TEXT(&H8E) = "STX"
        INS_TEXT(&H8F) = "NOP"
        INS_TEXT(&H90) = "BCC"
        INS_TEXT(&H91) = "STA"
        INS_TEXT(&H92) = "STA"
        INS_TEXT(&H93) = "NOP"
        INS_TEXT(&H94) = "STY"
        INS_TEXT(&H95) = "STA"
        INS_TEXT(&H96) = "STX"
        INS_TEXT(&H97) = "NOP"
        INS_TEXT(&H98) = "TYA"
        INS_TEXT(&H99) = "STA"
        INS_TEXT(&H9A) = "TXS"
        INS_TEXT(&H9B) = "NOP"
        INS_TEXT(&H9C) = "NOP"
        INS_TEXT(&H9D) = "STA"
        INS_TEXT(&H9E) = "NOP"
        INS_TEXT(&H9F) = "NOP"
        INS_TEXT(&HA0) = "LDY"
        INS_TEXT(&HA1) = "LDA"
        INS_TEXT(&HA2) = "LDX"
        INS_TEXT(&HA3) = "NOP"
        INS_TEXT(&HA4) = "LDY"
        INS_TEXT(&HA5) = "LDA"
        INS_TEXT(&HA6) = "LDX"
        INS_TEXT(&HA7) = "NOP"
        INS_TEXT(&HA8) = "TAY"
        INS_TEXT(&HA9) = "LDA"
        INS_TEXT(&HAA) = "TAX"
        INS_TEXT(&HAB) = "NOP"
        INS_TEXT(&HAC) = "LDY"
        INS_TEXT(&HAD) = "LDA"
        INS_TEXT(&HAE) = "LDX"
        INS_TEXT(&HAF) = "NOP"
        INS_TEXT(&HB0) = "BCS"
        INS_TEXT(&HB1) = "LDA"
        INS_TEXT(&HB2) = "LDA"
        INS_TEXT(&HB3) = "NOP"
        INS_TEXT(&HB4) = "LDY"
        INS_TEXT(&HB5) = "LDA"
        INS_TEXT(&HB6) = "LDX"
        INS_TEXT(&HB7) = "NOP"
        INS_TEXT(&HB8) = "CLV"
        INS_TEXT(&HB9) = "LDA"
        INS_TEXT(&HBA) = "TSX"
        INS_TEXT(&HBB) = "NOP"
        INS_TEXT(&HBC) = "LDY"
        INS_TEXT(&HBD) = "LDA"
        INS_TEXT(&HBE) = "LDX"
        INS_TEXT(&HBF) = "NOP"
        INS_TEXT(&HC0) = "CPY"
        INS_TEXT(&HC1) = "CMP"
        INS_TEXT(&HC2) = "NOP"
        INS_TEXT(&HC3) = "NOP"
        INS_TEXT(&HC4) = "CPY"
        INS_TEXT(&HC5) = "CMP"
        INS_TEXT(&HC6) = "DEC"
        INS_TEXT(&HC7) = "NOP"
        INS_TEXT(&HC8) = "INY"
        INS_TEXT(&HC9) = "CMP"
        INS_TEXT(&HCA) = "DEX"
        INS_TEXT(&HCB) = "NOP"
        INS_TEXT(&HCC) = "CPY"
        INS_TEXT(&HCD) = "CMP"
        INS_TEXT(&HCE) = "DEC"
        INS_TEXT(&HCF) = "NOP"
        INS_TEXT(&HD0) = "BNE"
        INS_TEXT(&HD1) = "CMP"
        INS_TEXT(&HD2) = "CMP"
        INS_TEXT(&HD3) = "NOP"
        INS_TEXT(&HD4) = "NOP"
        INS_TEXT(&HD5) = "CMP"
        INS_TEXT(&HD6) = "DEC"
        INS_TEXT(&HD7) = "NOP"
        INS_TEXT(&HD8) = "CLD"
        INS_TEXT(&HD9) = "CMP"
        INS_TEXT(&HDA) = "PHX"
        INS_TEXT(&HDB) = "NOP"
        INS_TEXT(&HDC) = "NOP"
        INS_TEXT(&HDD) = "CMP"
        INS_TEXT(&HDE) = "DEC"
        INS_TEXT(&HDF) = "NOP"
        INS_TEXT(&HE0) = "CPX"
        INS_TEXT(&HE1) = "SBC"
        INS_TEXT(&HE2) = "NOP"
        INS_TEXT(&HE3) = "NOP"
        INS_TEXT(&HE4) = "CPX"
        INS_TEXT(&HE5) = "SBC"
        INS_TEXT(&HE6) = "INC"
        INS_TEXT(&HE7) = "NOP"
        INS_TEXT(&HE8) = "INX"
        INS_TEXT(&HE9) = "SBC"
        INS_TEXT(&HEA) = "NOP"
        INS_TEXT(&HEB) = "NOP"
        INS_TEXT(&HEC) = "CPX"
        INS_TEXT(&HED) = "SBC"
        INS_TEXT(&HEE) = "INC"
        INS_TEXT(&HEF) = "NOP"
        INS_TEXT(&HF0) = "BEQ"
        INS_TEXT(&HF1) = "SBC"
        INS_TEXT(&HF2) = "SBC"
        INS_TEXT(&HF3) = "NOP"
        INS_TEXT(&HF4) = "NOP"
        INS_TEXT(&HF5) = "SBC"
        INS_TEXT(&HF6) = "INC"
        INS_TEXT(&HF7) = "NOP"
        INS_TEXT(&HF8) = "SED"
        INS_TEXT(&HF9) = "SBC"
        INS_TEXT(&HFA) = "PLX"
        INS_TEXT(&HFB) = "NOP"
        INS_TEXT(&HFC) = "NOP"
        INS_TEXT(&HFD) = "SBC"
        INS_TEXT(&HFE) = "INC"
        INS_TEXT(&HFF) = "NOP"
    End Sub
    Private Sub INIT_TICKS()
        INS_TICKS(&H0) = 7
        INS_TICKS(&H1) = 6
        INS_TICKS(&H2) = 2
        INS_TICKS(&H3) = 2
        INS_TICKS(&H4) = 3
        INS_TICKS(&H5) = 3
        INS_TICKS(&H6) = 5
        INS_TICKS(&H7) = 2
        INS_TICKS(&H8) = 3
        INS_TICKS(&H9) = 2
        INS_TICKS(&HA) = 2
        INS_TICKS(&HB) = 2
        INS_TICKS(&HC) = 4
        INS_TICKS(&HD) = 4
        INS_TICKS(&HE) = 6
        INS_TICKS(&HF) = 2
        INS_TICKS(&H10) = 2
        INS_TICKS(&H11) = 5
        INS_TICKS(&H12) = 3
        INS_TICKS(&H13) = 2
        INS_TICKS(&H14) = 3
        INS_TICKS(&H15) = 4
        INS_TICKS(&H16) = 6
        INS_TICKS(&H17) = 2
        INS_TICKS(&H18) = 2
        INS_TICKS(&H19) = 4
        INS_TICKS(&H1A) = 2
        INS_TICKS(&H1B) = 2
        INS_TICKS(&H1C) = 4
        INS_TICKS(&H1D) = 4
        INS_TICKS(&H1E) = 7
        INS_TICKS(&H1F) = 2
        INS_TICKS(&H20) = 6
        INS_TICKS(&H21) = 6
        INS_TICKS(&H22) = 2
        INS_TICKS(&H23) = 2
        INS_TICKS(&H24) = 3
        INS_TICKS(&H25) = 3
        INS_TICKS(&H26) = 5
        INS_TICKS(&H27) = 2
        INS_TICKS(&H28) = 4
        INS_TICKS(&H29) = 2
        INS_TICKS(&H2A) = 2
        INS_TICKS(&H2B) = 2
        INS_TICKS(&H2C) = 4
        INS_TICKS(&H2D) = 4
        INS_TICKS(&H2E) = 6
        INS_TICKS(&H2F) = 2
        INS_TICKS(&H30) = 2
        INS_TICKS(&H31) = 5
        INS_TICKS(&H32) = 3
        INS_TICKS(&H33) = 2
        INS_TICKS(&H34) = 4
        INS_TICKS(&H35) = 4
        INS_TICKS(&H36) = 6
        INS_TICKS(&H37) = 2
        INS_TICKS(&H38) = 2
        INS_TICKS(&H39) = 4
        INS_TICKS(&H3A) = 2
        INS_TICKS(&H3B) = 2
        INS_TICKS(&H3C) = 4
        INS_TICKS(&H3D) = 4
        INS_TICKS(&H3E) = 7
        INS_TICKS(&H3F) = 2
        INS_TICKS(&H40) = 6
        INS_TICKS(&H41) = 6
        INS_TICKS(&H42) = 2
        INS_TICKS(&H43) = 2
        INS_TICKS(&H44) = 2
        INS_TICKS(&H45) = 3
        INS_TICKS(&H46) = 5
        INS_TICKS(&H47) = 2
        INS_TICKS(&H48) = 3
        INS_TICKS(&H49) = 2
        INS_TICKS(&H4A) = 2
        INS_TICKS(&H4B) = 2
        INS_TICKS(&H4C) = 3
        INS_TICKS(&H4D) = 4
        INS_TICKS(&H4E) = 6
        INS_TICKS(&H4F) = 2
        INS_TICKS(&H50) = 2
        INS_TICKS(&H51) = 5
        INS_TICKS(&H52) = 3
        INS_TICKS(&H53) = 2
        INS_TICKS(&H54) = 2
        INS_TICKS(&H55) = 4
        INS_TICKS(&H56) = 6
        INS_TICKS(&H57) = 2
        INS_TICKS(&H58) = 2
        INS_TICKS(&H59) = 4
        INS_TICKS(&H5A) = 3
        INS_TICKS(&H5B) = 2
        INS_TICKS(&H5C) = 2
        INS_TICKS(&H5D) = 4
        INS_TICKS(&H5E) = 7
        INS_TICKS(&H5F) = 2
        INS_TICKS(&H60) = 6
        INS_TICKS(&H61) = 6
        INS_TICKS(&H62) = 2
        INS_TICKS(&H63) = 2
        INS_TICKS(&H64) = 3
        INS_TICKS(&H65) = 3
        INS_TICKS(&H66) = 5
        INS_TICKS(&H67) = 2
        INS_TICKS(&H68) = 4
        INS_TICKS(&H69) = 2
        INS_TICKS(&H6A) = 2
        INS_TICKS(&H6B) = 2
        INS_TICKS(&H6C) = 5
        INS_TICKS(&H6D) = 4
        INS_TICKS(&H6E) = 6
        INS_TICKS(&H6F) = 2
        INS_TICKS(&H70) = 2
        INS_TICKS(&H71) = 5
        INS_TICKS(&H72) = 3
        INS_TICKS(&H73) = 2
        INS_TICKS(&H74) = 4
        INS_TICKS(&H75) = 4
        INS_TICKS(&H76) = 6
        INS_TICKS(&H77) = 2
        INS_TICKS(&H78) = 2
        INS_TICKS(&H79) = 4
        INS_TICKS(&H7A) = 4
        INS_TICKS(&H7B) = 2
        INS_TICKS(&H7C) = 6
        INS_TICKS(&H7D) = 4
        INS_TICKS(&H7E) = 7
        INS_TICKS(&H7F) = 2
        INS_TICKS(&H80) = 2
        INS_TICKS(&H81) = 6
        INS_TICKS(&H82) = 2
        INS_TICKS(&H83) = 2
        INS_TICKS(&H84) = 3
        INS_TICKS(&H85) = 3
        INS_TICKS(&H86) = 3
        INS_TICKS(&H87) = 2
        INS_TICKS(&H88) = 2
        INS_TICKS(&H89) = 2
        INS_TICKS(&H8A) = 2
        INS_TICKS(&H8B) = 2
        INS_TICKS(&H8C) = 4
        INS_TICKS(&H8D) = 4
        INS_TICKS(&H8E) = 4
        INS_TICKS(&H8F) = 2
        INS_TICKS(&H90) = 2
        INS_TICKS(&H91) = 6
        INS_TICKS(&H92) = 3
        INS_TICKS(&H93) = 2
        INS_TICKS(&H94) = 4
        INS_TICKS(&H95) = 4
        INS_TICKS(&H96) = 4
        INS_TICKS(&H97) = 2
        INS_TICKS(&H98) = 2
        INS_TICKS(&H99) = 5
        INS_TICKS(&H9A) = 2
        INS_TICKS(&H9B) = 2
        INS_TICKS(&H9C) = 4
        INS_TICKS(&H9D) = 5
        INS_TICKS(&H9E) = 5
        INS_TICKS(&H9F) = 2
        INS_TICKS(&HA0) = 2
        INS_TICKS(&HA1) = 6
        INS_TICKS(&HA2) = 2
        INS_TICKS(&HA3) = 2
        INS_TICKS(&HA4) = 3
        INS_TICKS(&HA5) = 3
        INS_TICKS(&HA6) = 3
        INS_TICKS(&HA7) = 2
        INS_TICKS(&HA8) = 2
        INS_TICKS(&HA9) = 2
        INS_TICKS(&HAA) = 2
        INS_TICKS(&HAB) = 2
        INS_TICKS(&HAC) = 4
        INS_TICKS(&HAD) = 4
        INS_TICKS(&HAE) = 4
        INS_TICKS(&HAF) = 2
        INS_TICKS(&HB0) = 2
        INS_TICKS(&HB1) = 5
        INS_TICKS(&HB2) = 3
        INS_TICKS(&HB3) = 2
        INS_TICKS(&HB4) = 4
        INS_TICKS(&HB5) = 4
        INS_TICKS(&HB6) = 4
        INS_TICKS(&HB7) = 2
        INS_TICKS(&HB8) = 2
        INS_TICKS(&HB9) = 4
        INS_TICKS(&HBA) = 2
        INS_TICKS(&HBB) = 2
        INS_TICKS(&HBC) = 4
        INS_TICKS(&HBD) = 4
        INS_TICKS(&HBE) = 4
        INS_TICKS(&HBF) = 2
        INS_TICKS(&HC0) = 2
        INS_TICKS(&HC1) = 6
        INS_TICKS(&HC2) = 2
        INS_TICKS(&HC3) = 2
        INS_TICKS(&HC4) = 3
        INS_TICKS(&HC5) = 3
        INS_TICKS(&HC6) = 5
        INS_TICKS(&HC7) = 2
        INS_TICKS(&HC8) = 2
        INS_TICKS(&HC9) = 2
        INS_TICKS(&HCA) = 2
        INS_TICKS(&HCB) = 2
        INS_TICKS(&HCC) = 4
        INS_TICKS(&HCD) = 4
        INS_TICKS(&HCE) = 6
        INS_TICKS(&HCF) = 2
        INS_TICKS(&HD0) = 2
        INS_TICKS(&HD1) = 5
        INS_TICKS(&HD2) = 3
        INS_TICKS(&HD3) = 2
        INS_TICKS(&HD4) = 2
        INS_TICKS(&HD5) = 4
        INS_TICKS(&HD6) = 6
        INS_TICKS(&HD7) = 2
        INS_TICKS(&HD8) = 2
        INS_TICKS(&HD9) = 4
        INS_TICKS(&HDA) = 3
        INS_TICKS(&HDB) = 2
        INS_TICKS(&HDC) = 2
        INS_TICKS(&HDD) = 4
        INS_TICKS(&HDE) = 7
        INS_TICKS(&HDF) = 2
        INS_TICKS(&HE0) = 2
        INS_TICKS(&HE1) = 6
        INS_TICKS(&HE2) = 2
        INS_TICKS(&HE3) = 2
        INS_TICKS(&HE4) = 3
        INS_TICKS(&HE5) = 3
        INS_TICKS(&HE6) = 5
        INS_TICKS(&HE7) = 2
        INS_TICKS(&HE8) = 2
        INS_TICKS(&HE9) = 2
        INS_TICKS(&HEA) = 2
        INS_TICKS(&HEB) = 2
        INS_TICKS(&HEC) = 4
        INS_TICKS(&HED) = 4
        INS_TICKS(&HEE) = 6
        INS_TICKS(&HEF) = 2
        INS_TICKS(&HF0) = 2
        INS_TICKS(&HF1) = 5
        INS_TICKS(&HF2) = 3
        INS_TICKS(&HF3) = 2
        INS_TICKS(&HF4) = 2
        INS_TICKS(&HF5) = 4
        INS_TICKS(&HF6) = 6
        INS_TICKS(&HF7) = 2
        INS_TICKS(&HF8) = 2
        INS_TICKS(&HF9) = 4
        INS_TICKS(&HFA) = 4
        INS_TICKS(&HFB) = 2
        INS_TICKS(&HFC) = 2
        INS_TICKS(&HFD) = 4
        INS_TICKS(&HFE) = 7
        INS_TICKS(&HFF) = 2
    End Sub
#End Region
#Region "Flags"
    Private Sub SetFlags(value As Byte)
        If value Then P = P And &HFD Else P = P Or &H2 ' Set Zero Flag
        If value And &H80 Then P = P Or &H80 Else P = P And &H7F ' Set Sign Flag
    End Sub
    Private Sub SetNZ(value As Byte)
        If value Then P = P And &HFD Else P = P Or &H2 ' Set Zero Flag
        If value And &H80 Then P = P Or &H80 Else P = P And &H7F ' Set Sign Flag
    End Sub
    Private Sub SetOverflow(value As Integer)
        If (value) Then P = P Or P_OVERFLOW Else P = P And Not P_OVERFLOW
    End Sub
    Private Sub SetBreak(value As Integer)
        If (value) Then P = P Or P_BREAK Else P = P And Not P_BREAK
    End Sub
    Private Sub SetDecimal(value As Integer)
        If (value) Then P = P Or P_DECIMAL Else P = P And Not P_DECIMAL
    End Sub
    Private Sub SetInterrupt(value As Integer)
        If (value) Then P = P Or P_INTERUPT Else P = P And Not P_INTERUPT
    End Sub
    Private Sub SetCarry(value As Integer)
        If (value) Then P = P Or P_CARRY Else P = P And Not P_CARRY
    End Sub
    Private Sub SetZero(value As Integer)
        If (value) Then P = P Or P_ZERO Else P = P And Not P_ZERO
    End Sub
    Private Sub SetSign(value As Integer)
        If (value And &H80) Then P = P Or P_SIGN Else P = P And Not P_SIGN
    End Sub
#End Region
#Region "Address Modes"
    Private Sub ADRMODE_ABS()
        Select Case ADR_TICK
            Case 0 : Cycles += 2 : savepc = Read(PC) : PC += 1
            Case 2 : savepc += (Read(PC) * &H100) And &HFFFF : PC += 1 : INS_TICK += 1
        End Select
    End Sub
    Private Sub ADRMODE_ABSX()
        Select Case ADR_TICK
            Case 0 : Cycles += 3 : savepc = Read(PC) : PC += 1
            Case 2 : savepc += (Read(PC) * &H100) + X And &HFFFF : PC += 1 : If savepc \ &H100 = (savepc + X) \ &H100 Then INS_TICK += 1 Else Cycles += 1
            Case 3 : INS_TICK += 1
        End Select
    End Sub
    Private Sub ADRMODE_ABSY()
        Select Case ADR_TICK
            Case 0 : Cycles += 3 : savepc = Read(PC) : PC += 1
            Case 2 : savepc += (Read(PC) * &H100) + Y And &HFFFF : PC += 1 : If savepc \ &H100 = (savepc + Y) \ &H100 Then INS_TICK += 1 Else Cycles += 1
            Case 3 : INS_TICK += 1
        End Select
    End Sub
    Private Sub ADRMODE_IND()
        Select Case ADR_TICK
            Case 0 : Cycles += 3 : help = Read(PC) : PC += 1
            Case 1 : help += Read(PC) * &H100 : PC += 1
            Case 2 : savepc = Read(help) + (Read(help + 1) * &H100) : INS_TICK += 1
        End Select
    End Sub
    Private Sub ADRMODE_INDX()
        Select Case ADR_TICK
            Case 0 : Cycles += 4 : value = Read(PC) : PC += 1
            Case 1 : value = (value + X) And &HFF
            Case 2 : savepc = Read(value) + (Read(value + 1) * &H100)
            Case 3 : savepc += Read(value + 1) * &H100 : INS_TICK += 1
        End Select
    End Sub
    Private Sub ADRMODE_INDY()
        Select Case ADR_TICK
            Case 0 : Cycles += 3 : value = Read(PC) : PC += 1
            Case 1 : savepc = Read(value)
            Case 2 : savepc += ((Read(value + 1) * &H100) + Y) And &HFFFF : If savepc \ &H100 = (savepc + Y) \ &H100 Then INS_TICK += 1 Else Cycles += 1 : INS_TICK += 1
            Case 3 : INS_TICK += 1
        End Select
    End Sub
    Private Sub ADRMODE_REL()
        Select Case ADR_TICK
            Case 0 : Cycles += 1 : savepc = Read(PC) : PC += 1 : INS_TICK += 1 : If savepc And &H80 Then savepc -= &H100
        End Select
    End Sub
    Private Sub ADRMODE_ZPX()
        Select Case ADR_TICK
            Case 0 : Cycles += 2 : savepc = Read(PC) : PC += 1
            Case 1 : savepc += X And &HFF : INS_TICK += 1
        End Select
    End Sub
    Private Sub ADRMODE_ZPY()
        Select Case ADR_TICK
            Case 0 : Cycles += 2 : savepc = Read(PC) : PC += 1
            Case 1 : savepc += Y And &HFF : INS_TICK += 1
        End Select
    End Sub
#End Region
#Region "Instructions"
#Region "   Branch on (BCC, BCS, BEQ, BNE, BMI, BPL, BVC, BVS)"
#Region "   Carry"
    Private Sub INST_BCC()
        If INS_TICK = 1 Then If (P And &H1) = 0 Then PC += savepc : Cycles += 1 Else PC += 0 : Cycle = 0
        ' Add 1 Cycle if branch occurs on to different page.
        If INS_TICK = 2 Then If PC \ &H100 <> tempPC \ &H100 Then Cycles += 1 Else Cycle = 0
        If INS_TICK = 3 Then Cycle = 0
    End Sub
    Private Sub INST_BCS()
        If INS_TICK = 1 Then If (P And &H1) Then PC += savepc : Cycles += 1 Else PC += 0 : Cycle = 0
        ' Add 1 Cycle if branch occurs on to different page.
        If INS_TICK = 2 Then If PC \ &H100 <> tempPC \ &H100 Then Cycles += 1 Else Cycle = 0
        If INS_TICK = 3 Then Cycle = 0
    End Sub
#End Region
#Region "   Zero"
    Private Sub INST_BEQ()
        If INS_TICK = 1 Then If (P And &H2) Then PC += savepc : Cycles += 1 Else PC += 0 : Cycle = 0
        ' Add 1 Cycle if branch occurs on to different page.
        If INS_TICK = 2 Then If PC \ &H100 <> tempPC \ &H100 Then Cycles += 1 Else Cycle = 0
        If INS_TICK = 3 Then Cycle = 0
    End Sub
    Private Sub INST_BNE()
        If INS_TICK = 1 Then If (P And &H2) = 0 Then PC += savepc : Cycles += 1 Else PC += 0 : Cycle = 0
        ' Add 1 Cycle if branch occurs on to different page.
        If INS_TICK = 2 Then If PC \ &H100 <> tempPC \ &H100 Then Cycles += 1 Else Cycle = 0
        If INS_TICK = 3 Then Cycle = 0
    End Sub
#End Region
#Region "   Plus/Minus"
    Private Sub INST_BMI()
        If INS_TICK = 1 Then If (P And &H80) Then PC += savepc : Cycles += 1 Else PC += 0 : Cycle = 0
        ' Add 1 Cycle if branch occurs on to different page.
        If INS_TICK = 2 Then If PC \ &H100 <> tempPC \ &H100 Then Cycles += 1 Else Cycle = 0
        If INS_TICK = 3 Then Cycle = 0
    End Sub
    Private Sub INST_BPL()
        If INS_TICK = 1 Then If (P And &H80) = 0 Then PC += savepc : Cycles += 1 Else PC += 0 : Cycle = 0
        ' Add 1 Cycle if branch occurs on to different page.
        If INS_TICK = 2 Then If PC \ &H100 <> tempPC \ &H100 Then Cycles += 1 Else Cycle = 0
        If INS_TICK = 3 Then Cycle = 0
    End Sub
#End Region
#Region "   Overflow"
    Private Sub INST_BVC()
        If INS_TICK = 1 Then If ((P And &H40) = 0) Then PC += savepc : Cycles += 1 Else PC += 0 : Cycle = 0
        ' Add 1 Cycle if branch occurs on to different page.
        If INS_TICK = 2 Then If PC \ &H100 <> tempPC \ &H100 Then Cycles += 1 Else Cycle = 0
        If INS_TICK = 3 Then Cycle = 0
    End Sub
    Private Sub INST_BVS()
        If INS_TICK = 1 Then If (P And &H40) Then PC += savepc : Cycles += 1 Else PC += 0 : Cycle = 0
        ' Add 1 Cycle if branch occurs on to different page.
        If INS_TICK = 2 Then If PC \ &H100 <> tempPC \ &H100 Then Cycles += 1 Else Cycle = 0
        If INS_TICK = 3 Then Cycle = 0
    End Sub
#End Region
#End Region
#Region "Set Flags (SEC, SED, SEI)"
    Private Sub INST_SEC()
        If INS_TICK = 1 Then P = P Or &H1 : Cycle = 0
    End Sub
    Private Sub INST_SED()
        If INS_TICK = 1 Then P = P Or &H8 : Cycle = 0
    End Sub
    Private Sub INST_SEI()
        If INS_TICK = 1 Then P = P Or &H4 : Cycle = 0
    End Sub
#End Region
#Region "Clear Flags (CLC, CLD, CLI, CLV)"
    Private Sub INST_CLC()
        If INS_TICK = 1 Then P = P And &HFE : Cycle = 0
    End Sub
    Private Sub INST_CLD()
        If INS_TICK = 1 Then P = P And &HF7 : Cycle = 0
    End Sub
    Private Sub INST_CLI()
        If INS_TICK = 1 Then P = P And &HFB : Cycle = 0
    End Sub
    Private Sub INST_CLV()
        If INS_TICK = 1 Then P = P And &HBF : Cycle = 0
    End Sub
#End Region
#Region "Compare (CMP, CPX, CPY)"
    Private Sub INST_CMP()
        If INS_TICK = 1 Then
            value = Read(savepc)
            If (A + &H100 - value) > &HFF Then P = P Or &H1 Else P = (P And &HFE)
            value = (A + &H100 - value) And &HFF
            SetFlags(value)
            Cycle = 0
        End If
    End Sub
    Private Sub INST_CPX()
        If INS_TICK = 1 Then
            value = Read(savepc)
            If (X + &H100 - value > &HFF) Then P = P Or &H1 Else P = (P And &HFE)
            value = (X + &H100 - value) And &HFF
            SetFlags(value)
            Cycle = 0
        End If
    End Sub
    Private Sub INST_CPY()
        If INS_TICK = 1 Then
            value = Read(savepc)
            If (Y + &H100 - value > &HFF) Then P = (P Or &H1) Else P = (P And &HFE)
            value = (Y + &H100 - value) And &HFF
            SetFlags(value)
            Cycle = 0
        End If
    End Sub
#End Region
#Region "Decrement (DEC, DEX, DEY)"
    Private Sub INST_DEC()
        If INS_TICK = 1 Then
            Write(savepc, Read(savepc) - 1 And &HFF)
            value = Read(savepc)
            SetFlags(value)
            'If (value) Then P = P And &HFD Else P = P Or &H2
            'If (value And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_DEX()
        If INS_TICK = 1 Then
            X = (X - 1) And &HFF
            If (X) Then P = P And &HFD Else P = P Or &H2
            If (X And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_DEY()
        If INS_TICK = 1 Then
            Y = (Y - 1) And &HFF
            If (Y) Then P = P And &HFD Else P = P Or &H2
            If (Y And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
#End Region
#Region "Increment (INC, INX, INY)"
    Private Sub INST_INC()
        If INS_TICK = 1 Then
            Write(savepc, Read(savepc) + 1 And &HFF)
            value = Read(savepc)
            If (value) Then P = P And &HFD Else P = P Or &H2
            If (value And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_INX()
        If INS_TICK = 1 Then
            X = (X + 1) And &HFF
            If (X) Then P = P And &HFD Else P = P Or &H2
            If (X And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_INY()
        If INS_TICK = 1 Then
            Y = (Y + 1) And &HFF
            If (Y) Then P = P And &HFD Else P = P Or &H2
            If (Y And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
#End Region
#Region "Load (LDA, LDX, LDY)"
    Private Sub INST_LDA()
        If INS_TICK = 1 Then A = Read(savepc) : SetFlags(A) : Cycle = 0
    End Sub
    Private Sub INST_LDX()
        If INS_TICK = 1 Then X = Read(savepc) : SetFlags(X) : Cycle = 0
    End Sub
    Private Sub INST_LDY()
        If INS_TICK = 1 Then Y = Read(savepc) : SetFlags(Y) : Cycle = 0
    End Sub
#End Region
#Region "Bit Shift (ASL, LSR)"
    Private Sub INST_ASL()
        If INS_TICK = 1 Then
            value = Read(savepc)
            P = (P And &HFE) Or ((value \ 128) And &H1)
            value = (value * 2) And &HFF
            Write(savepc, (value And &HFF))
            SetFlags(value)
            Cycle = 0
        End If
    End Sub
    Private Sub INST_ASLA()
        If INS_TICK = 1 Then
            P = (P And &HFE) Or ((A \ 128) And &H1)
            A = (A * 2) And &HFF
            SetFlags(A)
            Cycle = 0
        End If
    End Sub
    Private Sub INST_LSR()
        If INS_TICK = 1 Then
            value = Read(savepc)
            P = ((P And &HFE) Or (value And &H1))
            value = (value \ 2) And &HFF
            Write(savepc, (value And &HFF))
            If (value) Then P = P And &HFD Else P = P Or &H2
            If (value And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_LSRA()
        If INS_TICK = 1 Then
            P = (P And &HFE) Or (A And &H1)
            A = (A \ 2) And &HFF
            If (A) Then P = P And &HFD Else P = P Or &H2
            If (A And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
#End Region
#Region "Bitwise (AND, BIT, EOR, ORA)"
    Private Sub INST_AND()
        If INS_TICK = 1 Then A = A And Read(savepc) : SetFlags(A) : Cycle = 0
    End Sub
    Private Sub INST_BIT()
        If INS_TICK = 1 Then
            value = Read(savepc)
            If (value And A) Then P = (P And &HFD) Else P = P Or &H2
            P = (P And &H3F) Or (value And &HC0)
            Cycle = 0
        End If
    End Sub
    Private Sub INST_EOR()
        If INS_TICK = 1 Then A = A Xor Read(savepc) : SetFlags(A) : Cycle = 0
    End Sub
    Private Sub INST_ORA()
        If INS_TICK = 1 Then A = A Or Read(savepc) : SetFlags(A) : Cycle = 0
    End Sub
#End Region
#Region "Jump (JMP, JSR)"
    Private Sub INST_JMP()
        If INS_TICK = 1 Then PC = savepc : Cycle = 0
    End Sub
    Private Sub INST_JSR()
        ' Cycle Match
        If INS_TICK = 1 Then Cycles += 2 : PC -= 1
        If INS_TICK = 2 Then Write(S + &H100, (PC \ &H100)) : S = (S - 1) And &HFF
        If INS_TICK = 3 Then Write(S + &H100, (PC And &HFF)) : S = (S - 1) And &HFF
        If INS_TICK = 4 Then PC = savepc : Cycle = 0
    End Sub
#End Region
#Region "Return (RTI, RTS)"
    Private Sub INST_RTI()
        If INS_TICK = 1 Then S = (S + 1) And &HFF
        If INS_TICK = 2 Then P = Read(S + &H100) Or &H20 : S = (S + 1) And &HFF
        If INS_TICK = 3 Then PC = Read(S + &H100) : S = (S + 1) And &HFF
        If INS_TICK = 4 Then PC += Read(S + &H100) * &H100 : Cycle = 0
        SYS.IRQ = False
    End Sub
    Private Sub INST_RTS()
        If INS_TICK = 1 Then Cycles += 4 : S = (S + 1) And &HFF
        If INS_TICK = 2 Then PC = Read(S + &H100) : S = (S + 1) And &HFF
        If INS_TICK = 3 Then PC += Read(S + &H100) * &H100
        If INS_TICK = 4 Then PC += 1 : Cycle = 0
    End Sub
#End Region
#Region "Push on Stack (PHA, PHP, PHX, PHY)"
    Private Sub INST_PHA()
        If INS_TICK = 2 Then Write(&H100 + S, A) : S = (S - 1) And &HFF : Cycle = 0
    End Sub
    Private Sub INST_PHP()
        If INS_TICK = 2 Then Write(&H100 + S, P) : S = (S - 1) And &HFF : Cycle = 0
    End Sub
    Private Sub INST_PHX()
        If INS_TICK = 2 Then Write(&H100 + S, X) : S = (S - 1) And &HFF : Cycle = 0
    End Sub
    Private Sub INST_PHY()
        If INS_TICK = 2 Then Write(&H100 + S, Y) : S = (S - 1) And &HFF : Cycle = 0
    End Sub
#End Region
#Region "Pull from Stack (PLA, PLP, PLX, PLY)"
    Private Sub INST_PLA()
        If INS_TICK = 1 Then S = (S + 1) And &HFF
        If INS_TICK = 2 Then
            A = Read(S + &H100)
            If (A) Then P = P And &HFD Else P = P Or &H2
            If (A And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_PLP()
        If INS_TICK = 1 Then S = (S + 1) And &HFF
        If INS_TICK = 2 Then P = Read(S + &H100) Or &H20 : Cycle = 0
    End Sub
    Private Sub INST_PLX()
        If INS_TICK = 1 Then S = (S + 1) And &HFF
        If INS_TICK = 2 Then
            X = Read(S + &H100)
            If (X) Then P = P And &HFD Else P = P Or &H2
            If (X And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_PLY()
        If INS_TICK = 1 Then S = (S + 1) And &HFF
        If INS_TICK = 2 Then
            Y = Read(S + &H100)
            If (Y) Then P = P And &HFD Else P = P Or &H2
            If (Y And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
#End Region
#Region "Rotate Bit (ROL, ROR)"
    Private Sub INST_ROL()
        If INS_TICK = 1 Then
            saveflags = (P And &H1)
            value = Read(savepc)
            P = (P And &HFE) Or ((value \ 128) And &H1)
            value = (value * 2) And &HFF
            value = value Or saveflags
            Write(savepc, (value And &HFF))
            If (value) Then P = P And &HFD Else P = P Or &H2
            If (value And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_ROLA()
        If INS_TICK = 1 Then
            saveflags = (P And &H1)
            P = (P And &HFE) Or ((A \ 128) And &H1)
            A = (A * 2) And &HFF
            A = A Or saveflags
            If (A) Then P = P And &HFD Else P = P Or &H2
            If (A And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_ROR()
        If INS_TICK = 1 Then
            saveflags = (P And &H1)
            value = Read(savepc)
            P = (P And &HFE) Or (value And &H1)
            value = (value \ 2) And &HFF
            If (saveflags) Then value = value Or &H80
            Write(savepc, value And &HFF)
            If (value) Then P = P And &HFD Else P = P Or &H2
            If (value And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_RORA()
        If INS_TICK = 1 Then
            saveflags = (P And &H1)
            P = (P And &HFE) Or (A And &H1)
            A = (A \ 2) And &HFF
            If (saveflags) Then A = A Or &H80
            If (A) Then P = P And &HFD Else P = P Or &H2
            If (A And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
#End Region
#Region "Store (STA, STX, STY)"
    Private Sub INST_STA()
        If INS_TICK = 1 Then Write(savepc, A) : Cycle = 0
    End Sub
    Private Sub INST_STX()
        If INS_TICK = 1 Then Write(savepc, X) : Cycle = 0
    End Sub
    Private Sub INST_STY()
        If INS_TICK = 1 Then Write(savepc, Y) : Cycle = 0
    End Sub
#End Region
#Region "Transfer (TAX, TAY, TSX, TXA, TYA, TXS)"
    Private Sub INST_TAX()
        If INS_TICK = 1 Then
            X = A
            If (X) Then P = P And &HFD Else P = P Or &H2
            If (X And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_TAY()
        If INS_TICK = 1 Then
            Y = A
            If (Y) Then P = P And &HFD Else P = P Or &H2
            If (Y And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_TSX()
        If INS_TICK = 1 Then
            X = S
            If (X) Then P = P And &HFD Else P = P Or &H2
            If (X And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_TXA()
        If INS_TICK = 1 Then
            A = X
            If (A) Then P = P And &HFD Else P = P Or &H2
            If (A And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_TYA()
        If INS_TICK = 1 Then
            A = Y
            If (A) Then P = P And &HFD Else P = P Or &H2
            If (A And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_TXS()
        If INS_TICK = 1 Then S = X : Cycle = 0
    End Sub
#End Region
#Region "Add/Sub with Carry (ADC, SBC)"
    Private Sub INST_ADC()
        Dim tmp_value As Integer
        Dim tmp As Integer

        If INS_TICK = 1 Then
            tmp_value = Read(savepc)
            If (P And P_DECIMAL) Then
                tmp = (A And &HF) + (tmp_value And &HF) + (P And P_CARRY)
                If (tmp > &H9) Then tmp += &H6
                If (tmp <= &HF) Then tmp = (tmp And &HF) + (A And &HF0) + (tmp_value And &HF0) Else tmp = (tmp And &HF) + (A And &HF0) + (tmp_value And &HF0) + &H10
                If ((A + tmp_value + (P And P_CARRY)) And &HFF) = 0 Then P = P Or P_ZERO Else P = P And Not P_ZERO
                If (tmp And &H80) Then P = P Or P_SIGN Else P = P And Not P_SIGN
                If (Not ((A Xor tmp_value) And &H80) And ((A Xor tmp) And &H80)) Then P = P Or P_OVERFLOW Else P = P And Not P_OVERFLOW
                If ((tmp And &H1F0) > &H90) Then tmp += &H60
                If (tmp > &HFF) Then P = P Or P_CARRY Else P = P And Not P_CARRY
            Else
                tmp = A + tmp_value + (P And P_CARRY)
                If ((A + tmp_value + (P And P_CARRY)) And &HFF) = 0 Then P = P Or P_ZERO Else P = P And Not P_ZERO
                If (tmp And &H80) Then P = P Or P_SIGN Else P = P And Not P_SIGN
                If (Not ((A Xor tmp_value) And &H80) And ((A Xor tmp) And &H80)) Then P = P Or P_OVERFLOW Else P = P And Not P_OVERFLOW
                If (tmp > &HFF) Then P = P Or P_CARRY Else P = P And Not P_CARRY
            End If
            A = tmp And &HFF
            Cycle = 0
        End If
    End Sub
    Private Sub INST_SBC()
        Dim tmp_value As Integer
        Dim tmp As Integer

        If INS_TICK = 1 Then
            tmp_value = Read(savepc)
            tmp = A - tmp_value
            If (P And P_CARRY) Then  Else tmp -= 1
            'tmp = A - tmp_value + (P And P_CARRY)
            If (P And P_DECIMAL) Then
                Dim tmp_a As Integer
                tmp_a = (A And &HF) - (tmp_value And &HF)
                If (P And P_CARRY) Then  Else tmp_a -= 1
                'tmp_a = (A And &HF) - (tmp_value And &HF) - (Not (P And P_CARRY))
                If (tmp_a And &H10) Then
                    tmp_a = ((tmp_a - &H6) And &HF) Or ((A And &HF0) - (tmp_value And &HF0) - &H10)
                Else
                    tmp_a = (tmp_a And &HF) Or ((A And &HF0) - (tmp_value And &HF0))
                End If
                If (tmp_a And &H100) Then tmp_a -= &H60
                If ((tmp And &HFFFF) < &H100) Then P = P Or P_CARRY Else P = P And Not P_CARRY
                If ((tmp And &HFFFF) And &H80) Then P = P Or P_SIGN Else P = P And Not P_SIGN
                If ((tmp And &HFFFF) And &HFF) = 0 Then P = P Or P_ZERO Else P = P And Not P_ZERO
                If ((A Xor tmp_value) And &H80) And ((A Xor tmp) And &H80) Then P = P Or P_OVERFLOW Else P = P And Not P_OVERFLOW
                A = tmp_a And &HFF
            Else
                If ((tmp And &HFFFF) And &H80) Then P = P Or P_SIGN Else P = P And Not P_SIGN
                If ((tmp And &HFFFF) And &HFF) = 0 Then P = P Or P_ZERO Else P = P And Not P_ZERO
                If ((tmp And &HFFFF) < &H100) Then P = P Or P_CARRY Else P = P And Not P_CARRY
                If ((A Xor tmp_value) And &H80) And ((A Xor tmp) And &H80) Then P = P Or P_OVERFLOW Else P = P And Not P_OVERFLOW
                A = tmp And &HFF
            End If
            Cycle = 0
        End If
    End Sub
#End Region
#Region "Other (BRK, NOP)"
    Private Sub INST_NOP()
        If INS_TICK = 1 Then Cycle = 0
    End Sub
    Private Sub INST_BRK()
        If INS_TICK = 1 Then P = P Or &H10 : Write(&H100 + S, (PC \ &H100) And &HFF) : S = (S - 1) And &HFF
        If INS_TICK = 2 Then Write(&H100 + S, (PC And &HFF)) : S = (S - 1) And &HFF
        If INS_TICK = 3 Then Write(&H100 + S, P) : S = (S - 1) And &HFF
        If INS_TICK = 4 Then PC = Read(&HFFFE) : P = P Or &H4
        If INS_TICK = 5 Then PC += Read(&HFFFF) * &H100 : Cycle = 0
    End Sub
#End Region
#Region "IRQ/NMI"
    Public Sub INST_IRQ()
        ' Maskable interrupt
        If SYS.Running = False Then LogText("IRQ Cycle: " & Cycle & "/" & Cycles & " Addr: " & Hex(tempPC))
        If INS_TICK = 1 Then Write(&H100 + S, (tempPC \ &H100)) : S = (S - 1) And &HFF ' PC HI
        If INS_TICK = 2 Then Write(&H100 + S, (tempPC And &HFF)) : S = (S - 1) And &HFF ' PC LO
        If INS_TICK = 3 Then Write(&H100 + S, P) : S = (S - 1) And &HFF ' Flags
        If INS_TICK = 4 Then PC = Read(&HFFFE) ' IRQ Entry HI
        If INS_TICK = 5 Then
            PC += Read(&HFFFF) * &H100 ' IRQ Entry LO
            P = P Or &H4 ' Set IRQ Disable
            Cycle = 0
            'SYS.Running = False
        End If
    End Sub
    Public Sub INST_NMI()
        If SYS.Running = False Then LogText("NMI Cycle: " & Cycle & "/" & Cycles & " Addr: " & Hex(tempPC))
        If INS_TICK = 1 Then Write(&H100 + S, (tempPC \ &H100)) : S = (S - 1) And &HFF ' PC HI
        If INS_TICK = 2 Then Write(&H100 + S, (tempPC And &HFF)) : S = (S - 1) And &HFF ' PC LO
        If INS_TICK = 3 Then Write(&H100 + S, P) : S = (S - 1) And &HFF ' Flags
        If INS_TICK = 4 Then PC = Read(&HFFFA) ' IRQ Entry HI
        If INS_TICK = 5 Then
            PC += Read(&HFFFB) * &H100 ' IRQ Entry LO
            P = P Or &H4 ' Set IRQ Disable
            Cycle = 0
        End If
    End Sub
#End Region
#Region "Illegal Instructions"
    Private Sub INST_BRA()
        If INS_TICK = 1 Then PC += savepc : Cycle = 0
    End Sub
    Private Sub INST_DEA()
        If INS_TICK = 1 Then
            A = (A - 1) And &HFF
            If A Then P = P And &HFD Else P = P Or &H2
            If (A And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
    Private Sub INST_INA()
        If INS_TICK = 1 Then
            A = (A + 1) And &HFF
            If (A) Then P = P And &HFD Else P = P Or &H2
            If (A And &H80) Then P = P Or &H80 Else P = P And &H7F
            Cycle = 0
        End If
    End Sub
#End Region
#End Region
#Region "Memory"
    Public Function Read(Address As Integer) As Byte
        Read = SYS.Read(Address)
    End Function
    Public Sub Write(Address As Integer, Value As Byte)
        SYS.Write(Address, Value)
    End Sub
#End Region
End Class
