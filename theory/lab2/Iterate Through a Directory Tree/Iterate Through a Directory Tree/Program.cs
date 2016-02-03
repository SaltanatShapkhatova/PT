using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterate_Through_a_Directory_Tree
{
    class Program
    {
        public static void throughfiles(DirectoryInfo d, int depth)
        {
            try {
                DirectoryInfo[] directories = d.GetDirectories();
                foreach (DirectoryInfo di in directories)
                {
                    Console.WriteLine(depth + " " + di.Name + " " + di.FullName);
                    throughfiles(di, depth + 1);
                }
                foreach (FileInfo fi in d.GetFiles())
                {
                    Console.WriteLine("*" + fi.Name + " " + fi.Length);
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
                Console.ReadKey();
            }
            
        }
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"C: \Users\ы\Documents");
            if (d.Exists)
            {
                Console.WriteLine(d.Name + " " + d.FullName);
                throughfiles(d, 0);
            }
            Console.ReadKey();
        }
    }
}
