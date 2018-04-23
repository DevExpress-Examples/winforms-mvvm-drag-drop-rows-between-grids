Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DragDropTwoGrids.Model
Imports DragDropTwoGrids.ViewModels
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace DragDropTwoGrids
    Public Class DragAndDropHelper
        Private gridControl As GridControl
        Private gridView As GridView
        Private downHitInfo As GridHitInfo = Nothing

        Private _Drop As EventHandler(Of MyDragAndDropEventArgs)
        Public Custom Event Drop As EventHandler(Of MyDragAndDropEventArgs)
            AddHandler(ByVal value As EventHandler(Of MyDragAndDropEventArgs))
                _Drop = DirectCast(System.Delegate.Combine(_Drop, value), EventHandler(Of MyDragAndDropEventArgs))
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of MyDragAndDropEventArgs))
                _Drop = DirectCast(System.Delegate.Remove(_Drop, value), EventHandler(Of MyDragAndDropEventArgs))
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As MyDragAndDropEventArgs)
                If _Drop IsNot Nothing Then
                    For Each d As EventHandler(Of MyDragAndDropEventArgs) In _Drop.GetInvocationList()
                        d.Invoke(sender, e)
                    Next d
                End If
            End RaiseEvent
        End Event

        Private _RemoveRecord As EventHandler(Of EventArgs)
        Public Custom Event RemoveRecord As EventHandler(Of EventArgs)
            AddHandler(ByVal value As EventHandler(Of EventArgs))
                _RemoveRecord = DirectCast(System.Delegate.Combine(_RemoveRecord, value), EventHandler(Of EventArgs))
            End AddHandler
            RemoveHandler(ByVal value As EventHandler(Of EventArgs))
                _RemoveRecord = DirectCast(System.Delegate.Remove(_RemoveRecord, value), EventHandler(Of EventArgs))
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As EventArgs)
                If _RemoveRecord IsNot Nothing Then
                    For Each d As EventHandler(Of EventArgs) In _RemoveRecord.GetInvocationList()
                        d.Invoke(sender, e)
                    Next d
                End If
            End RaiseEvent
        End Event

        Public Sub New(ByVal gc As GridControl)
            Me.gridControl = gc
            Me.gridView = TryCast(gc.MainView, GridView)
            SetUpGrid()
        End Sub

        Public Sub SetUpGrid()
            gridControl.AllowDrop = True
            AddHandler gridControl.DragOver, AddressOf grid_DragOver
            AddHandler gridControl.DragDrop, AddressOf grid_DragDrop
            gridView.OptionsBehavior.Editable = False
            AddHandler gridView.MouseMove, AddressOf view_MouseMove
            AddHandler gridView.MouseDown, AddressOf view_MouseDown
        End Sub

        Private Sub view_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            downHitInfo = Nothing
            Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
            If Control.ModifierKeys <> Keys.None Then
                Return
            End If
            If e.Button = MouseButtons.Left AndAlso hitInfo.RowHandle >= 0 Then
                downHitInfo = hitInfo
            End If
        End Sub

        Private Sub view_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
                Dim dragSize As Size = SystemInformation.DragSize
                Dim dragRect As New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width \ 2, downHitInfo.HitPoint.Y - dragSize.Height \ 2), dragSize)
                If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                    Dim row As Object = view.GetRow(downHitInfo.RowHandle)
                    Dim args As New MyDragAndDropEventArgs(row)
                    view.GridControl.DoDragDrop(args, DragDropEffects.Move)
                    If _RemoveRecord IsNot Nothing AndAlso (Not args.Cancel) Then
                        _RemoveRecord(Me, New MyOnDeleteEventArgs(args.Record))
                    End If
                    downHitInfo = Nothing
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
                End If
            End If
        End Sub

        Private Sub grid_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
            If e.Data.GetDataPresent(GetType(MyDragAndDropEventArgs)) Then
                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.None
            End If
        End Sub

        Private Sub grid_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)
            If _Drop IsNot Nothing Then
                Dim args As MyDragAndDropEventArgs = TryCast(e.Data.GetData(GetType(MyDragAndDropEventArgs)), MyDragAndDropEventArgs)
                _Drop(Me, args)
            End If
        End Sub
    End Class

    Public Class MyDragAndDropEventArgs
        Inherits MyOnDeleteEventArgs

        'this class can be extended by necessary arguments
        Public Property Cancel() As Boolean
        Public Sub New(ByVal dataObject As Object)
            MyBase.New(dataObject)
            Cancel = True
        End Sub
    End Class

    Public Class MyOnDeleteEventArgs
        Inherits EventArgs

        Public Property Record() As Object
        Public Sub New(ByVal record As Object)
            Me.Record = record
        End Sub
    End Class
End Namespace
