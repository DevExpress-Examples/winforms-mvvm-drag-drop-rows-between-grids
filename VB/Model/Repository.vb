Imports System
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace DragDropTwoGrids.Model

    Public Module Repository

        Private random As Random = New Random()

        Public Function CreateFiles() As BindingList(Of File)
            Dim used As List(Of Integer) = New List(Of Integer)()
            Dim files As BindingList(Of File) = New BindingList(Of File)()
            Dim i As Integer = 0
            While i < 5
                Dim fileId As Integer = random.Next(0, 10)
                If Not used.Contains(fileId) Then
                    used.Add(fileId)
                    Dim file As File = New File("File" & fileId, fileId * 123456 + 144)
                    files.Add(file)
                    i += 1
                End If
            End While

            Return files
        End Function
    End Module
End Namespace
