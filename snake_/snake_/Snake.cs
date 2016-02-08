
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3.Models
{
    public class Snake : Drawer
    {
        Point head = new Point();//naznachaem x i y koord
        public void Eat() { }
        public Snake()
        {
            color = ConsoleColor.Yellow;
            sign = 'o';
        }

        public void Move(int dx, int dy)
        {
            //if (dx < 0) dx = dx + 48; Console.WriteLine("Za ramku po x v -");
            //if (dy < 0) Console.WriteLine("Za ramku po y v -");
            //if (dx > 48) Console.WriteLine("Za ramku po x v -");
            //if (dy > 48) Console.WriteLine("Za ramku po y v -");

            for (int i = body.Count - 1; i > 0; --i)//counts ot poslednei tochki zmeii
            {
                body[i].x = body[i - 1].x;//the last point of body stands to the previous
                body[i].y = body[i - 1].y;
            }//границы игры 
            if (body[0].x + dx < 0) dx = dx + 48;
            if (body[0].y + dy < 0) dy = dy + 48;
            if (body[0].x + dx > 48) dx = dx - 48;
            if (body[0].y + dy > 48) dy = dy - 48;
            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;

            //проверка, можем ли скушать
            if (Game.snake.body[0].x == Game.food.body[0].x && Game.snake.body[0].y == Game.food.body[0].y)
            {
                //добавил к змейке новую точку. прирост
                Game.snake.body.Add(new Point { x = 0, y = 0});
                // переместил еду на новую позицию 

                //new koordinates of food
                int tx = 0, ty = 0;
                bool success = false;//do tex por poka ne poluchilos 
                while (!success)
                {
                    tx = new Random().Next(0, 20);//budem generirovat novie koord
                    ty = new Random().Next(0, 20);
                    success = true;//predpolagaem wto poluchilos
                    for (int i = 0; i < Game.wall.body.Count; ++i)//zapuskaem cikl ot 0 do vsex tochek walla
                    {
                        if (tx == Game.wall.body[i].x &&//sopostavlyet s koord edi
                            ty == Game.wall.body[i].y)
                        {
                            success = false;//u nas ne poluchilos
                            break;
                        }
                    }
                    for (int i = 0; i < Game.snake.body.Count; ++i)//proveryem na zmeiku
                    {
                        if (tx == Game.snake.body[i].x &&
                            ty == Game.snake.body[i].y)
                        {
                            success = false;
                            break;
                        }
                    }
                }

                Game.food.body[0].x = tx;
                Game.food.body[0].y = ty;

                Game.foodEaten++;
                if (Game.foodEaten % 4 == 0)
                {

                    Console.Clear();//dlya perexoda na new level
                    Game.wall.body.Clear();
                    Game.food.body.Clear();
                    Game.LoadLevel((Game.foodEaten / 4) + 1);
                    Game.Init();
                }
            }

            //проверка, есть ли столкновение со стеной
            for (int i = 0; i < Game.wall.body.Count; ++i)
            {
                if (Game.snake.body[0].x == Game.wall.body[i].x && Game.snake.body[0].y == Game.wall.body[i].y)
                {
                    Console.Clear();
                    Console.SetCursorPosition(24, 24);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over!");
                    Game.inGame = false;
                }
            }
            for(int i=body.Count-1; i > 0; i--)
            {
                if(body[0].x==body[i].x && body[0].y == body[i].y)
                {
                    Console.Clear();
                    Console.SetCursorPosition(24, 24);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over!");
                    Game.inGame = false;
                }
            }
        }
    }

}
