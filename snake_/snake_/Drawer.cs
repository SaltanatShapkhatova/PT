using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Example3.Models
{
    [Serializable]
    public class Drawer
    {
        public ConsoleColor color;
        public char sign;
        public List<Point> body = new List<Point>();//spisok x y
        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
        public Drawer() {}
        public void Save()
        {
            string fileName = "";
            switch (sign)
            {
                case '#':
                    //fileName = "wall.xml";//save as xml
                    fileName = "wall.dat";
                    break;
                case '$':
                    fileName = "food.dat";
                    break;
                case 'o':
                    fileName = "snake.dat";
                    break;
            }
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            //XmlSerializer xs = new XmlSerializer(GetType());//saves
            //xs.Serialize(fs, this);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void Resume()//cherz serialize chitaet. esli stena body ochist.serializ is koda v tekst zapis.
        {
            string fileName = "";

            switch (sign)
            {
                case '#':
                    fileName = "wall.dat";
                    break;
                case '$':
                    fileName = "food.dat";
                    break;
                case 'o':
                    fileName = "snake.dat";
                    break;
            }
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //XmlSerializer xs = new XmlSerializer(GetType());
            BinaryFormatter bf = new BinaryFormatter();
            switch (sign)
            {
                case '#':
                    Game.wall.body.Clear();
                    Game.wall = bf.Deserialize(fs) as Wall;
                    break;
                case '$':
                    Game.food.body.Clear();
                    Game.food = bf.Deserialize(fs) as Food;
                    break;
                case 'o':
                    Game.snake.body.Clear();

                    Game.snake = bf.Deserialize(fs) as Snake;
                    break;
            }
            fs.Close();
        }
    }

}