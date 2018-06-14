Module modMain
#Region "Project Information"
    Public strProgramTitle As String = "NES Emulator"
    Public strRegistryPath As String = "Software\Game Tools\NES Emulator"
#End Region

#Region "Simulation Items"
    Public SYS As New clsNES
    Public PPU As New clsPPU
    Public APU As New clsAPU
    Public CPU As New cls6502

    Public RAM As New clsMemory(2048, True)
    Public VRAM As New clsMemory(16384, True)
    Public SPRITERAM As New clsMemory(256, True)
    Public SAVERAM As New clsMemory(8192, True)
    Public CHRRAM As New clsMemory(8192, True)
#End Region

#Region "Custom Functions"
    Public Function Hexed(Value As Long, Length As Integer) As String
        ' A little code to display Padded Hex Values...
        Return Hex(Value).PadLeft(Length, "0")
    End Function
    Public Function BinaryString(Dec As Long, maxpower As Integer) As String
        BinaryString = ""
        If Dec > 2 ^ maxpower Then
            MsgBox("Number must be no larger than " & Str$(2 ^ maxpower))
            End
        End If
        Dim m
        For m = maxpower - 1 To 0 Step -1
            If Dec And (2 ^ m) Then   ' Use the logical "AND" operator.
                BinaryString &= "1"
            Else
                BinaryString &= "0"
            End If
        Next
    End Function
    Public Sub LogText(Text As String)
        Debug.Print(Text)
    End Sub
#End Region
End Module
