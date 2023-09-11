Namespace DragDropTwoGrids

    Partial Class DragDropForm

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.splitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
            Me.testView1 = New DragDropTwoGrids.View.TestView()
            Me.testView2 = New DragDropTwoGrids.View.TestView()
            CType((Me.splitContainerControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainerControl1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' splitContainerControl1
            ' 
            Me.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainerControl1.Location = New System.Drawing.Point(0, 0)
            Me.splitContainerControl1.Name = "splitContainerControl1"
            Me.splitContainerControl1.Panel1.Controls.Add(Me.testView1)
            Me.splitContainerControl1.Panel1.Text = "Panel1"
            Me.splitContainerControl1.Panel2.Controls.Add(Me.testView2)
            Me.splitContainerControl1.Panel2.Text = "Panel2"
            Me.splitContainerControl1.Size = New System.Drawing.Size(861, 553)
            Me.splitContainerControl1.SplitterPosition = 436
            Me.splitContainerControl1.TabIndex = 1
            Me.splitContainerControl1.Text = "splitContainerControl1"
            ' 
            ' testView1
            ' 
            Me.testView1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.testView1.Location = New System.Drawing.Point(0, 0)
            Me.testView1.Name = "testView1"
            Me.testView1.Size = New System.Drawing.Size(436, 553)
            Me.testView1.TabIndex = 0
            ' 
            ' testView2
            ' 
            Me.testView2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.testView2.Location = New System.Drawing.Point(0, 0)
            Me.testView2.Name = "testView2"
            Me.testView2.Size = New System.Drawing.Size(420, 553)
            Me.testView2.TabIndex = 1
            ' 
            ' DragDropForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(861, 553)
            Me.Controls.Add(Me.splitContainerControl1)
            Me.Name = "DragDropForm"
            Me.Text = "DragDropForm"
            CType((Me.splitContainerControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainerControl1.ResumeLayout(False)
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private splitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl

        Private testView1 As DragDropTwoGrids.View.TestView

        Private testView2 As DragDropTwoGrids.View.TestView
    End Class
End Namespace
