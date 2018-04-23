using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DragDropTwoGrids.Model;
using DragDropTwoGrids.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DragDropTwoGrids {
    public class DragAndDropHelper {
        private GridControl gridControl;
        private GridView gridView;
        GridHitInfo downHitInfo = null;

        private EventHandler<MyDragAndDropEventArgs> drop;
        public event EventHandler<MyDragAndDropEventArgs> Drop {
            add { drop += value; }
            remove { drop -= value; }
        }

        private EventHandler<EventArgs> removeRecord;
        public event EventHandler<EventArgs> RemoveRecord {
            add { removeRecord += value; }
            remove { removeRecord -= value; }
        }

        public DragAndDropHelper(GridControl gc) {
            this.gridControl = gc;
            this.gridView = gc.MainView as GridView;
            SetUpGrid();
        }

        public void SetUpGrid() {
            gridControl.AllowDrop = true;
            gridControl.DragOver += new System.Windows.Forms.DragEventHandler(grid_DragOver);
            gridControl.DragDrop += new System.Windows.Forms.DragEventHandler(grid_DragDrop);
            gridView.OptionsBehavior.Editable = false;
            gridView.MouseMove += new System.Windows.Forms.MouseEventHandler(view_MouseMove);
            gridView.MouseDown += new System.Windows.Forms.MouseEventHandler(view_MouseDown);
        }

        private void view_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            GridView view = sender as GridView;
            downHitInfo = null;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if(Control.ModifierKeys != Keys.None) return;
            if(e.Button == MouseButtons.Left && hitInfo.RowHandle >= 0)
                downHitInfo = hitInfo;
        }

        private void view_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
            GridView view = sender as GridView;
            if(e.Button == MouseButtons.Left && downHitInfo != null) {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                    downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
                if(!dragRect.Contains(new Point(e.X, e.Y))) {
                    object row = view.GetRow(downHitInfo.RowHandle);
                    MyDragAndDropEventArgs args = new MyDragAndDropEventArgs(row);
                    view.GridControl.DoDragDrop(args, DragDropEffects.Move);
                    if(removeRecord != null && !args.Cancel) {
                        removeRecord(this, new MyOnDeleteEventArgs(args.Record));
                    }
                    downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        private void grid_DragOver(object sender, System.Windows.Forms.DragEventArgs e) {
            if(e.Data.GetDataPresent(typeof(MyDragAndDropEventArgs)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grid_DragDrop(object sender, System.Windows.Forms.DragEventArgs e) {
            if(drop != null) {
                MyDragAndDropEventArgs args = e.Data.GetData(typeof(MyDragAndDropEventArgs)) as MyDragAndDropEventArgs;
                drop(this, args);
            }
        }
    }

    public class MyDragAndDropEventArgs : MyOnDeleteEventArgs {
        //this class can be extended by necessary arguments
        public bool Cancel { get; set; }
        public MyDragAndDropEventArgs(object dataObject)
            : base(dataObject) {
            Cancel = true;
        }
    }

    public class MyOnDeleteEventArgs : EventArgs {
        public object Record { get; set; }
        public MyOnDeleteEventArgs(object record) {
            Record = record;
        }
    }
}
