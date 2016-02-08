using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameW4G3
{
    public class Food : Drawer
    {
        public Food()
        {
            color = ConsoleColor.Yellow;
            sign = '$';
        }

        public void SetNewPosition()
        {
            int x = new Random().Next() % 20;
            int y = new Random().Next() % 20;
            if (body.Count == 0)
                body.Add(new Point(x, y));
            else
            {
                body[0].x = x;
                body[0].y = y;
            }

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
            
        }
    }
}
