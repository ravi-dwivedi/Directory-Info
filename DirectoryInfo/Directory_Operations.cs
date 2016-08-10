using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DirectoryInfo
{
    class Directory_Operations
    {
        IEnumerable<FileInfo> FileEnumerator;

        public Directory_Operations(string path)
        {
            Directory_Info dir = new Directory_Info(path);
            FileEnumerator = dir.GetFiles();
        }
        internal int getTotalFiles(string extension)
        {
            var a = from f in this.FileEnumerator
                    select f;
            System.Console.WriteLine(" "+a.GetType());
            int count = 0;
            foreach (FileInfo fi in a)
            {
                ++count;
            }

            return count;
        }
        internal IEnumerable<IGrouping<string, FileInfo>> filesPerExtension()
        {
            var rows = from fe in this.FileEnumerator
                       group fe by fe.Extension into countANDextension
                       select countANDextension;

            IEnumerable<IGrouping<string, FileInfo>> resultSet = rows;
            return resultSet;
        }


        internal Dictionary<string, long> topFiveBySize()
        {
            var a = this.FileEnumerator.ToList();
            var rows = (from fe in this.FileEnumerator
                        orderby fe.Length descending
                        select new
                        {
                            Name = fe.Name,
                            Size = fe.Length
                        });
            Dictionary<string, long> d = new Dictionary<string, long>();
            foreach (var row in rows)
            {
                d.Add(row.Name,row.Size);
            }
            return d;
        }
    }
}
