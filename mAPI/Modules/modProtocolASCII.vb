Imports System.IO
Module modProtocolASCII

    'ASCII Values
    Public SOH As String = Char.ConvertFromUtf32(1)
    Public STX As String = Char.ConvertFromUtf32(2)
    Public ETX As String = Char.ConvertFromUtf32(3)
    Public EOT As String = Char.ConvertFromUtf32(4)
    Public ENQ As String = Char.ConvertFromUtf32(5)
    Public ACK As String = Char.ConvertFromUtf32(6)
    Public LF As String = Char.ConvertFromUtf32(10)
    Public CR As String = Char.ConvertFromUtf32(13)
    Public DLE As String = Char.ConvertFromUtf32(16)
    Public NACK As String = Char.ConvertFromUtf32(21)
    Public ETB As String = Char.ConvertFromUtf32(23)
    'END ASCII

End Module
