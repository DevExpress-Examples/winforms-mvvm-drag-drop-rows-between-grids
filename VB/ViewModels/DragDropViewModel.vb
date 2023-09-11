Imports System.Linq
Imports System.ComponentModel
Imports DragDropTwoGrids.Model

Namespace DragDropTwoGrids.ViewModels

    Public Class DragDropViewModel

        Public Overridable Property Files As BindingList(Of File)

        Public Sub New()
            InitData()
        End Sub

        Private Sub InitData()
            Files = CreateFiles()
        End Sub

        Public Sub Drop(ByVal dataObject As MyDragAndDropEventArgs)
            Dim file As File = TryCast(dataObject.Record, File)
            If file IsNot Nothing Then
                If Files.Where(Function(f) Equals(f.FileName, file.FileName) AndAlso f.FileSize = file.FileSize).FirstOrDefault() IsNot Nothing Then
                    dataObject.Cancel = True
                Else
                    dataObject.Cancel = False
                    Files.Add(file)
                End If
            End If
        End Sub

        Public Sub RemoveRecord(ByVal record As Object)
            Dim file As File = TryCast(record, File)
            If file IsNot Nothing Then Files.Remove(file)
        End Sub
    End Class
End Namespace
