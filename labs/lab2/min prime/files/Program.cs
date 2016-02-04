using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace files
{
    class Program
    {
        static bool is_Prime(int n)
        {
            for(int i=2; i< n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
                if((i==n) || (i > Math.Sqrt(n)))
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            string line;
            int maxx, minn;
            /*StreamReader file = new StreamReader(@"C: \Users\ы\Documents\programming languages\far2.0\far2.0\PT_labs\theory\lab2\Reader.txt");
            while((line=file.ReadLine())!=null) 
            {
                Console.WriteLine(line);
            }
            //using (StreamWriter )*/
            StreamReader lines = new StreamReader(@"C:\Users\ы\Documents\казахский\numbers.txt");
            using (StreamWriter output = new StreamWriter(@"output.txt"))
            {
                int curr_n = int.Parse(lines.ReadLine());
                minn = curr_n;
                maxx = minn;
                string t_line;
                while ((t_line = lines.ReadLine()) != null)
                {
                    curr_n = int.Parse(t_line);
                    if (is_Prime(curr_n) && maxx < curr_n)
                    {
                        maxx = curr_n;
                    }

                    if(is_Prime(curr_n) && minn>curr_n)
                    {
                        minn = curr_n;
                    }
                }
                output.WriteLine(maxx + " " + minn);

                /*int n = int.Parse(lines.ReadLine());
                int[] array = new int[n];
                for(int i=0; i< n; i++)
                {
                    array[i] = int.Parse(lines.ReadLine());
                }
                maxx = array[0];
                minn = array[0];
                for(int i=0; i< n; i++)
                {
                    if (is_Prime(array[i]) && maxx < array[i])
                    {
                        maxx = array[i];
                    }
                    else if (is_Prime(array[i]) && minn > array[i])
                        minn = array[i];
                }
                output.WriteLine(maxx + " " + minn);*/
            }
            Console.ReadKey();
        }
    }
}
