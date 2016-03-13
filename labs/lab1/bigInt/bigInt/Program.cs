using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class bigint
    {
        public int[] a = new int[1111];
        public int size;
        public static bigint f(string s)
        {
            bigint a = new bigint();
            a.size = s.Length;
            for (int i = 1; i <= a.size; i++)
            {
                a.a[a.size - i + 1] = s[i - 1] - 48;
            }
            return a;
        }
        public static bigint operator +(bigint a, bigint b)
        {
            bigint c = new bigint();
            c.size = Math.Max(a.size, b.size);
            for (int i = 1; i <= c.size; i++)
                c.a[i] = a.a[i] + b.a[i];
            for (int i = 1; i <= c.size; i++)
                if (c.a[i] > 9)
                {
                    c.a[i] -= 10;
                    c.a[i + 1]++;
                    if (i == c.size)
                        c.size++;
                }
            return c;
        }
        public static bigint operator -(bigint a, bigint b)
        {
            bigint c = new bigint();
            c.size = Math.Max(a.size, b.size);
            for (int i = 1; i <= c.size; i++)
                c.a[i] = a.a[i] - b.a[i];
            for (int i = 1; i <= c.size; i++)
                if (c.a[i] < 0)
                {
                    c.a[i] += 10;
                    c.a[i + 1]--;
                }
            while (c.a[c.size] == 0 && c.size > 1)
                c.size--;
            return c;
        }
        public static bigint operator *(bigint a, bigint b)
        {
            bigint c = new bigint();
            c.size = a.size + b.size;
            for (int i = 1; i <= a.size; i++)
                for (int j = 1; j <= b.size; j++)
                    c.a[i + j - 1] += a.a[i] * b.a[j];
            for (int i = 1; i <= c.size; i++)
                if (c.a[i] > 9)
                {
                    c.a[i + 1] += c.a[i] / 10;
                    c.a[i] %= 10;
                    if (i == c.size)
                        c.size++;
                }
            while (c.a[c.size] == 0 && c.size > 1)
                c.size--;
            return c;
        }
        public override string ToString()
        {
            string s = "";
            for (int i = size; i >= 1; i--)
                s = s + a[i];
            return s;
        }
    }
}