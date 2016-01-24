using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Split();
            foreach (string t in s)
            {
                int a = Convert.ToInt32(t), c = 0;
                for (int i = 2; i<a; i++)
                {
                    if (a % i == 0)
                        c = 1;
                }
                if (c == 0)
                    Console.Write(a + " is a Prime Number ");
            }
            Console.ReadKey();
        }
    }
}
