Namespace DragDropTwoGrids.Model

    Public Class File

        Public Property FileName As String

        Public Property FileSize As Long

        Public Sub New(ByVal fileName As String, ByVal fileSize As Long)
            Me.FileName = fileName
            Me.FileSize = fileSize
        End Sub
    End Class
End Namespace
