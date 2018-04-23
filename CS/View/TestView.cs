using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DragDropTwoGrids.ViewModels;

namespace DragDropTwoGrids.View {
    public partial class TestView : UserControl {
        public TestView() {
            InitializeComponent();
            DragAndDropHelper helper = new DragAndDropHelper(this.gridControl1);
            if(!mvvmContext1.IsDesignMode)
                InitBindings(helper);
        }
        private void InitBindings(DragAndDropHelper helper) {
            var fluentAPI = mvvmContext1.OfType<DragDropViewModel>();
            fluentAPI.SetBinding(gridControl1, c => c.DataSource, x => x.Files);

            fluentAPI.WithEvent<MyDragAndDropEventArgs>(helper, "Drop")
                    .EventToCommand(x => x.Drop(null), args => args.Record != null);

            fluentAPI.WithEvent<MyOnDeleteEventArgs>(helper, "RemoveRecord")
                    .EventToCommand(x => x.RemoveRecord(null), args => args.Record);
        }
    }
}
