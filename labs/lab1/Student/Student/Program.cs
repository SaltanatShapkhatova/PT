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
        public double gpa;
        public Student()
        {
            gpa = 0;
            firstname = lastname = "";
        }
        public Student(string firstname, string lastname, double gpa)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.gpa = gpa;
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
            double c;
            a = Console.ReadLine();
            b = Console.ReadLine();
            c = double.Parse(Console.ReadLine());
            Student s = new Student(a, b, c);
            Console.Write(s);
            Console.ReadKey();
        }
    }
}
