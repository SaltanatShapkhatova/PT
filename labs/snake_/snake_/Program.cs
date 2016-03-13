using Example3.Models;
using System;
using System.Threading;
namespace Example3
{
    class Program
    {
        public enum Direction { up, down, left, right };
        public static Direction direction;
        //public static int speed = 200;
        static void MoveSnake(object timer)
        {
            //    if (Game.snake.body.Count % 4 == 0)
            //    {
            //        speed -= 500;
            //    }
            while(Game.inGame)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        direction = Direction.up;
                        break;
                    case ConsoleKey.DownArrow:
                        direction = Direction.down;
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = Direction.left;
                        break;
                    case ConsoleKey.RightArrow:
                        direction = Direction.right;
                        break;
                    case ConsoleKey.Escape:
                        Game.inGame = false;
                        break;
                    case ConsoleKey.F2:
                        Game.Save();
                        break;
                    case ConsoleKey.F3:
                        Game.Resume();
                        break;
                }
                if (!Game.inGame)
                {
                    Console.Clear();
                    Console.SetCursorPosition(20, 10);
                    Console.WriteLine("Game Over!!");

                }
            }
            switch (direction)
            {
                case Direction.up:
                    Game.snake.Move(0, -1);
                    break;
                case Direction.down:
                    Game.snake.Move(0, 1);
                    break;
                case Direction.left:
                    Game.snake.Move(-1, 0);
                    break;
                case Direction.right:
                    Game.snake.Move(1, 0);
                    break;
            }
            Game.Redraw();
           
        }
        static void Main(string[] args)
        {
            Game.inGame = true;
            Game.LoadLevel(1);
            Game.Init();
            Console.SetWindowSize(48, 48);
            Timer timer = new Timer(new TimerCallback(MoveSnake));
            timer.Change(1000, 100);
            //Game.wall.Draw(); //ubiraem pererisovku
            while (Game.inGame)
            {

            }
            timer.Dispose();
            Console.Clear();
            Console.ReadKey();
        }
    }
}