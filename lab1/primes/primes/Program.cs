using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());
            for(int i=2; i<n; i++)
            {
                if(n%i==0)
                {
                    
                    Console.WriteLine("This number isn`t prime");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("This number is- prime");
            Console.ReadKey();
        }
    }
}
