using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\ы\Documents\казахский\numbers.txt");
            int maxx = 0, minn = 10000000;
            foreach (string line in lines)
            {
                int number = int.Parse(line);
                if (maxx < number)
                {
                    maxx = number;
                }
                if(minn>number)
                {
                    minn = number;
                }
            }
            Console.WriteLine("Maximum number is: "+maxx+" Minimum number is: "+minn);
            Console.ReadKey();
        }
    }
}
