using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DirectoryInfo
{
    class DirectoryAccessImplementation
    {
      
        static void Main(string[] args)
        {
            Directory_Operations dO = new Directory_Operations(@"E:\Geeks\");

            Console.WriteLine(dO.getTotalFiles("txt"));
           
            Console.WriteLine("-----------------------------------");

            IEnumerable<IGrouping<string, FileInfo>> resultSet;
            resultSet = dO.filesPerExtension();
            foreach(var file in resultSet)
            {
                Console.WriteLine("{0,-10}{1,-10}",file.Key,file.Count());
            }

            Console.WriteLine("-----------------------------------");
            Dictionary<string, long> resultDic = dO.topFiveBySize();
            foreach (var file in resultDic)
            {

                Console.WriteLine("{0,-20}{1,-10}",file.Key,file.Value);
            }
            Console.Read();

        }
    }
}
