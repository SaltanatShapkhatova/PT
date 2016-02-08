using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameW4G3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(48, 48);
            Game game = new Game();
            Console.ReadKey();
        }
    }
}
