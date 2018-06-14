Public Class clsMemory
    Public Data() As Byte
    Private WriteEnable As Boolean  ' True = RAM, False = ROM
#Region "Memory Init/Reset Functions"
    Public Sub New(Bytes As Long, RAM As Boolean)
        ReDim Data(Bytes - 1)
        WriteEnable = RAM
        LogText("RAM Initialized " & Bytes & " bytes")
    End Sub
    Public Sub Reset()
        For intByte = 0 To Data.Length - 1 : Data(intByte) = 0 : Next
    End Sub
#End Region
#Region "Memory Read/Write"
    Public Function Read(Address As Integer) As Byte
        Read = Data(Address And (Data.Length - 1))   ' Keep our reads inside our array.
        'If SYS.Running = False Then LogText("RAM Read - Address: " & Address & " (" & Hex(Address) & ") Value: " & Read & " (" & Hexed(Read, 2) & ")")
    End Function
    Public Sub Write(Address As Integer, value As Byte)
        If WriteEnable = True Then
            Data(Address And (Data.Length - 1)) = value  ' Keep our reads inside our array.
            If SYS.Running = False Then LogText("RAM Write - Address: " & Address & " (" & Hex(Address) & ") Value: " & value & " (" & Hexed(value, 2) & ")")
        End If
    End Sub
#End Region
#Region "Load File"
    Public Sub Load(Filename As String, Address As Integer)
        Dim FILEDATA() As Byte = My.Computer.FileSystem.ReadAllBytes(Filename)
        For intByte = 0 To FILEDATA.Length - 1
            Data(Address + intByte) = FILEDATA(intByte)
        Next
        LogText("RAM Loaded " & Filename & " ROM - " & FileLen(Filename) & " bytes at Address " & Address & " (" & Hex(Address) & ")")
    End Sub
    Public Sub LoadSRec(FileName As String)
        Dim FileNumber As Integer = FreeFile()
        Dim Line As Integer = 0

        Dim FileData As New String(" ", FileLen(FileName))
        FileOpen(FileNumber, FileName, OpenMode.Binary)
        FileGet(FileNumber, FileData)
        FileClose(FileNumber)

        Dim Lines() As String = Split(FileData, vbCrLf)
        Dim LineLength As Integer = 0
        Dim LineAddress As Integer = 0
        Dim LineData As String = ""

        For Line = 0 To Lines.Count - 1
            Select Case Left(Lines(Line), 2)
                Case "S1"
                    LineLength = (Convert.ToInt16(Mid(Lines(Line), 3, 2), 16) - 3) * 2
                    LineAddress = Convert.ToInt32(Mid(Lines(Line), 5, 4), 16)
                    LineData = Mid(Lines(Line), 9, LineLength)
                    For Pos = 1 To Len(LineData) - 1 Step 2
                        Data(LineAddress) = Convert.ToInt16(Mid(LineData, Pos, 2), 16)
                        LineAddress += 1
                    Next
            End Select
        Next

        LogText("RAM Loaded " & FileName)
    End Sub
#End Region
End Class
