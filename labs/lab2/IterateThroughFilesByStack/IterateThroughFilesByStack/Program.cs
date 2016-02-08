using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class IterateByStack
{
    static void Main(string[] args)
    {
        WalkTree(@"C:\Users\ы\Documents\programming languages");
        Console.ReadKey();
    }

    public static void WalkTree(string root)
    {
        Stack<string> direcs = new Stack<string>(100);
        if (!System.IO.Directory.Exists(root))
        {
            throw new ArgumentException();
        }
        direcs.Push(root);
        while (direcs.Count > 0)
        {
            string curr_dir = direcs.Pop();
            string[] Dirs;
            try
            {
                Dirs = System.IO.Directory.GetDirectories(curr_dir);
            }
    
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            string[] files = null;
            try
            {
                files = System.IO.Directory.GetFiles(curr_dir);
            }

            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
                continue;
            }
            
            foreach (string file in files)
            {
                try
                {       
                    System.IO.FileInfo fi = new System.IO.FileInfo(file);
                    Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
                }
                catch (System.IO.FileNotFoundException e)
                {                    
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            foreach (string str in Dirs)
                direcs.Push(str);
        }
    }
}