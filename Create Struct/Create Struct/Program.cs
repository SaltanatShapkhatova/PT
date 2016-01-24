using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Create_Struct
{
    class Person
    {
        public string firstname, lastname;
        public int age;
        public Person()
        {
            age = 0;
            firstname = lastname = "";
        }
        
        public Person(string a, string b, int age)
        {
            firstname = a;
            lastname = b;
            this.age = age;
        }
        public override string ToString()
        {
            return firstname + " " + lastname + ", " + age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Tony", "Allen", 32);
            Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}


