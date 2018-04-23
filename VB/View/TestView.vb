Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DragDropTwoGrids.ViewModels

Namespace DragDropTwoGrids.View
    Partial Public Class TestView
        Inherits UserControl

        Public Sub New()
            InitializeComponent()
            Dim helper As New DragAndDropHelper(Me.gridControl1)
            If Not mvvmContext1.IsDesignMode Then
                InitBindings(helper)
            End If
        End Sub
        Private Sub InitBindings(ByVal helper As DragAndDropHelper)
            Dim fluentAPI = mvvmContext1.OfType(Of DragDropViewModel)()
            fluentAPI.SetBinding(gridControl1, Function(c) c.DataSource, Function(x) x.Files)
            fluentAPI.WithEvent(Of MyDragAndDropEventArgs)(helper, "Drop").EventToCommand(Sub(x) x.Drop(Nothing), Function(args) args.Record IsNot Nothing)
            fluentAPI.WithEvent(Of MyOnDeleteEventArgs)(helper, "RemoveRecord").EventToCommand(Sub(x) x.RemoveRecord(Nothing), Function(args) args.Record)
        End Sub
    End Class
End Namespace
