using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class person
    {
        public string name, lastname;
        public int age;
        public enum gender : int { male, female };
        gender gen;
        public person()
        {
            age = 0;
            name = lastname = "";
        }
        public person(string name, string lastn, int age, gender gend)
        {
            this.name = name;
            lastname = lastn;
            this.age = age;
            gen = gend;
        }
        public override string ToString()
        {
            return name + " " + lastname + ", " + gen + ", " + age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            person p = new person("Salta","Shapkhatova",17,person.gender.female);
            Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}
