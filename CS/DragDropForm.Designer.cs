namespace DragDropTwoGrids {
    partial class DragDropForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.testView1 = new DragDropTwoGrids.View.TestView();
            this.testView2 = new DragDropTwoGrids.View.TestView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.testView1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.testView2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(861, 553);
            this.splitContainerControl1.SplitterPosition = 436;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // testView1
            // 
            this.testView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testView1.Location = new System.Drawing.Point(0, 0);
            this.testView1.Name = "testView1";
            this.testView1.Size = new System.Drawing.Size(436, 553);
            this.testView1.TabIndex = 0;
            // 
            // testView2
            // 
            this.testView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testView2.Location = new System.Drawing.Point(0, 0);
            this.testView2.Name = "testView2";
            this.testView2.Size = new System.Drawing.Size(420, 553);
            this.testView2.TabIndex = 1;
            // 
            // DragDropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 553);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "DragDropForm";
            this.Text = "DragDropForm";         
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private View.TestView testView1;
        private View.TestView testView2;
    }
}