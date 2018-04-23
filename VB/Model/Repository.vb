Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text

Namespace DragDropTwoGrids.Model
    Public NotInheritable Class Repository

        Private Sub New()
        End Sub

        Private Shared random As New Random()
        Public Shared Function CreateFiles() As BindingList(Of File)
            Dim used As New List(Of Integer)()
            Dim files As New BindingList(Of File)()
            Dim i As Integer = 0
            Do While i < 5
                Dim fileId As Integer = random.Next(0, 10)
                If Not used.Contains(fileId) Then
                    used.Add(fileId)
                    Dim file As New File("File" & fileId, fileId * 123456 + 144)
                    files.Add(file)
                    i += 1
                End If
            Loop
            Return files
        End Function
    End Class
End Namespace
