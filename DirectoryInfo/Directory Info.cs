using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryInfo
{
    class Directory_Info
    {
        private System.IO.DirectoryInfo dir;
        private List<FileInfo> Files;
        public Directory_Info(string path)
        {
            dir = new System.IO.DirectoryInfo(@path);
            Files = new List<FileInfo>();
            var a = this.dir.GetDirectories().ToList();

            foreach (FileInfo fi in this.dir.GetFiles())
            {
                Files.Add(fi);
            }
        }

        public IEnumerable<FileInfo> GetFiles()
        {
            foreach(FileInfo fi in Files)
            {
                yield return fi;
            }
        }

    }
}
