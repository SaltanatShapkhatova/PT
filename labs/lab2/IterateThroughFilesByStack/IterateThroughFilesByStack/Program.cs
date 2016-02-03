using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IterateThroughFilesByStack
{
    public static void WalkTreeDirectory(DirectoryInfo d)
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\ы\Documents\programming languages");
            Console.WriteLine(d.Name+" "+d.FullName);
            WalkTreeDirectory(d);
            
        }
    }
}
