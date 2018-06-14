Public Class clsAPU
    Private CONTROLLERREAD(1) As Byte
    Public CONTROLLERBYTE(1) As Byte
#Region "Public Functions"
    Public Sub New()
    End Sub
    Public Sub Reset()

    End Sub
    Public Sub Tick()
    End Sub
#End Region
#Region "Memory Functions"
    Public Function Read(Address As Integer) As Byte
        Address = Address And &H1F
        Select Case Address
            Case &H16
                Read = ((CONTROLLERBYTE(0) << CONTROLLERREAD(0)) \ &H80) And &H1
                CONTROLLERREAD(0) = (CONTROLLERREAD(0) + 1) And &H7
            Case &H17
                Read = ((CONTROLLERBYTE(1) << CONTROLLERREAD(1)) \ &H80) And &H1
                CONTROLLERREAD(1) = (CONTROLLERREAD(1) + 1) And &H7
            Case Else : Read = &H0
        End Select
    End Function
    Public Sub Write(Address As Integer, Value As Byte)
        Address = Address And &H1F
    End Sub
#End Region

End Class
