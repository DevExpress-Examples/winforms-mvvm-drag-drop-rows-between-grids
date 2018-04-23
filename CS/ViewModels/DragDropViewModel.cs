using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Mvvm.POCO;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
using DragDropTwoGrids.Model;

namespace DragDropTwoGrids.ViewModels {
    public class DragDropViewModel {
        public virtual BindingList<File> Files { get; set; }
        public DragDropViewModel() {
            InitData();
        }
        private void InitData() {
            Files = Repository.CreateFiles();
        }
        public void Drop(MyDragAndDropEventArgs dataObject) {
            File file = dataObject.Record as File;
            if(file != null) {
                if(Files.Where(f => f.FileName == file.FileName && f.FileSize == file.FileSize).FirstOrDefault() != null) {
                    dataObject.Cancel = true;
                }
                else {
                    dataObject.Cancel = false;
                    Files.Add(file);
                }
            }
        }
        public void RemoveRecord(object record) {
            File file = record as File;
            if(file != null)
                Files.Remove(file);
        }
    }
}
