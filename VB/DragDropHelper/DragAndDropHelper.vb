Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace DragDropTwoGrids

    Public Class DragAndDropHelper

        Private gridControl As GridControl

        Private gridView As GridView

        Private downHitInfo As GridHitInfo = Nothing

        Private dropField As EventHandler(Of MyDragAndDropEventArgs)

        Public Custom Event Drop As EventHandler(Of MyDragAndDropEventArgs)
            AddHandler(ByVal value As EventHandler(Of MyDragAndDropEventArgs))
                dropField = [Delegate].Combine(dropField, value)
            End AddHandler

            RemoveHandler(ByVal value As EventHandler(Of MyDragAndDropEventArgs))
                dropField = [Delegate].Remove(dropField, value)
            End RemoveHandler

            RaiseEvent(ByVal sender As Object, ByVal e As MyDragAndDropEventArgs)
                If dropField IsNot Nothing Then
                    dropField(sender, e)
                End If
            End RaiseEvent
        End Event

        Private removeRecordField As EventHandler(Of EventArgs)

        Public Custom Event RemoveRecord As EventHandler(Of EventArgs)
            AddHandler(ByVal value As EventHandler(Of EventArgs))
                removeRecordField = [Delegate].Combine(removeRecordField, value)
            End AddHandler

            RemoveHandler(ByVal value As EventHandler(Of EventArgs))
                removeRecordField = [Delegate].Remove(removeRecordField, value)
            End RemoveHandler

            RaiseEvent(ByVal sender As Object, ByVal e As EventArgs)
                If removeRecordField IsNot Nothing Then
                    removeRecordField(sender, e)
                End If
            End RaiseEvent
        End Event

        Public Sub New(ByVal gc As GridControl)
            gridControl = gc
            gridView = TryCast(gc.MainView, GridView)
            SetUpGrid()
        End Sub

        Public Sub SetUpGrid()
            gridControl.AllowDrop = True
            AddHandler gridControl.DragOver, New DragEventHandler(AddressOf grid_DragOver)
            AddHandler gridControl.DragDrop, New DragEventHandler(AddressOf grid_DragDrop)
            gridView.OptionsBehavior.Editable = False
            AddHandler gridView.MouseMove, New MouseEventHandler(AddressOf view_MouseMove)
            AddHandler gridView.MouseDown, New MouseEventHandler(AddressOf view_MouseDown)
        End Sub

        Private Sub view_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            downHitInfo = Nothing
            Dim hitInfo As GridHitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
            If Control.ModifierKeys <> Keys.None Then Return
            If e.Button = MouseButtons.Left AndAlso hitInfo.RowHandle >= 0 Then downHitInfo = hitInfo
        End Sub

        Private Sub view_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            If e.Button = MouseButtons.Left AndAlso downHitInfo IsNot Nothing Then
                Dim dragSize As Size = SystemInformation.DragSize
                Dim dragRect As Rectangle = New Rectangle(New Point(downHitInfo.HitPoint.X - dragSize.Width \ 2, downHitInfo.HitPoint.Y - dragSize.Height \ 2), dragSize)
                If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                    Dim row As Object = view.GetRow(downHitInfo.RowHandle)
                    Dim args As MyDragAndDropEventArgs = New MyDragAndDropEventArgs(row)
                    view.GridControl.DoDragDrop(args, DragDropEffects.Move)
                    If removeRecordField IsNot Nothing AndAlso Not args.Cancel Then
                        removeRecordField(Me, New MyOnDeleteEventArgs(args.Record))
                    End If

                    downHitInfo = Nothing
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
                End If
            End If
        End Sub

        Private Sub grid_DragOver(ByVal sender As Object, ByVal e As DragEventArgs)
            If e.Data.GetDataPresent(GetType(MyDragAndDropEventArgs)) Then
                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.None
            End If
        End Sub

        Private Sub grid_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs)
            If dropField IsNot Nothing Then
                Dim args As MyDragAndDropEventArgs = TryCast(e.Data.GetData(GetType(MyDragAndDropEventArgs)), MyDragAndDropEventArgs)
                dropField(Me, args)
            End If
        End Sub
    End Class

    Public Class MyDragAndDropEventArgs
        Inherits MyOnDeleteEventArgs

        'this class can be extended by necessary arguments
        Public Property Cancel As Boolean

        Public Sub New(ByVal dataObject As Object)
            MyBase.New(dataObject)
            Cancel = True
        End Sub
    End Class

    Public Class MyOnDeleteEventArgs
        Inherits EventArgs

        Public Property Record As Object

        Public Sub New(ByVal record As Object)
            Me.Record = record
        End Sub
    End Class
End Namespace
