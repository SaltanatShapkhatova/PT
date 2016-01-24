using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Student
    {
        public string firstname, lastname;
        public int gpa;
        public Student()
        {
            gpa = 0;
            firstname = lastname = "";
        }
       
        public override string ToString()
        {
            return firstname + " " + lastname + " " + "," + gpa;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string a, b;
            int c;
            a = Console.ReadLine();
            b = Console.ReadLine();
            c = int.Parse(Console.ReadLine());
            Console.Write(a);
            Console.Write(b);
            Console.Write(c);
            Console.ReadKey();
        }
    }
}
