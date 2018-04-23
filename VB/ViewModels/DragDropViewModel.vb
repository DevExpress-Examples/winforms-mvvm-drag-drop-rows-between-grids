Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.Mvvm.POCO
Imports System.Data
Imports System.Windows.Forms
Imports System.ComponentModel
Imports DragDropTwoGrids.Model

Namespace DragDropTwoGrids.ViewModels
    Public Class DragDropViewModel
        Public Overridable Property Files() As BindingList(Of File)
        Public Sub New()
            InitData()
        End Sub
        Private Sub InitData()
            Files = Repository.CreateFiles()
        End Sub
        Public Sub Drop(ByVal dataObject As MyDragAndDropEventArgs)
            Dim file As File = TryCast(dataObject.Record, File)
            If file IsNot Nothing Then
                If Files.Where(Function(f) f.FileName = file.FileName AndAlso f.FileSize = file.FileSize).FirstOrDefault() IsNot Nothing Then
                    dataObject.Cancel = True
                Else
                    dataObject.Cancel = False
                    Files.Add(file)
                End If
            End If
        End Sub
        Public Sub RemoveRecord(ByVal record As Object)
            Dim file As File = TryCast(record, File)
            If file IsNot Nothing Then
                Files.Remove(file)
            End If
        End Sub
    End Class
End Namespace
