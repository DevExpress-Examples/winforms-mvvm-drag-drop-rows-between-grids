using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DragDropTwoGrids.Model {
    public static class Repository {
        private static Random random = new Random();
        public static BindingList<File> CreateFiles() {
            List<int> used = new List<int>();
            BindingList<File> files = new BindingList<File>();
            for(int i = 0; i < 5; ) {
                int fileId = random.Next(0, 10);
                if(!used.Contains(fileId)) {
                    used.Add(fileId);
                    File file = new File("File" + fileId, fileId * 123456 + 144);
                    files.Add(file);
                    i++;
                }
            }
            return files;
        }
    }
}
