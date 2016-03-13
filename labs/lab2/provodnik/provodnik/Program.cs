using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace provodnik
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\ы";

            DirectoryInfo dir = new DirectoryInfo(path);



            List<FileSystemInfo> items = new List<FileSystemInfo>();

            items.AddRange(dir.GetDirectories());
            items.AddRange(dir.GetFiles());
            int index = 0;//cursors' movement
            while (true)
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    if (i == index)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    if (items[i].GetType() == typeof(FileInfo))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine(items[i].Name);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }


                Console.SetCursorPosition(0, index);
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow: //esli stoit ne na nulevoi koord, podnimaet lursor vverh
                        if (index > 0) index--;
                        Console.SetCursorPosition(0, index);
                        break;
                    case ConsoleKey.DownArrow: //esli ne stoit na poslednei koord, spuskaetsya
                        if (index < items.Count - 1) index++;
                        Console.SetCursorPosition(0, index);
                        break;
                    case ConsoleKey.Escape://beret put' roditelya current papki
                        {
                            path = dir.Parent.FullName;
                            dir = new DirectoryInfo(path);
                            items.Clear();
                            items.AddRange(dir.GetDirectories());
                            items.AddRange(dir.GetFiles());
                            index = 0;
                        }
                        break;
                    case ConsoleKey.Enter://beret put' current papki i otkryvaet ego(esli my stoim na papke)
                        if (items[index].GetType() == typeof(DirectoryInfo))
                        {
                            path = items[index].FullName;
                            dir = new DirectoryInfo(path);
                            items.Clear();//chistim spisok
                            items.AddRange(dir.GetDirectories());
                            items.AddRange(dir.GetFiles());
                            index = 0;
                        }
                        else//esli stoim na faile to citaem soderzhimoe
                        {
                            Console.Clear();//chistim ekran
                            string text = File.ReadAllText(items[index].FullName);
                            Console.WriteLine(text);
                            Console.ReadKey();
                        }
                        break;
                }
                Console.Clear();
            }
        }
    }
}
