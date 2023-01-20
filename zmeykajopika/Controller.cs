using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zmeykajopika
{
    public class Controller
    {
        public Snake snake;
        Food food;
        Size ClientSize;
        int CountCellsWidth => ClientSize.Width / Kletochki.width;
        int CountCellsHeigth => ClientSize.Height / Kletochki.heigth;

        public Controller(Size size)
        {
            ClientSize = size;
            CreateSnake();
            food = new Food();
            food.x = 4;
            food.y = 6;
        }

        public void Draw(Graphics g)
        {
            snake.Draw(g);
            food.DrawFood(g);
        }

        public void CreateSnake()
        {
            Random random = new Random();
            int xHead = random.Next(CountCellsWidth + 1);
            int yHead = random.Next(CountCellsHeigth + 1);

            int offSetTail = random.Next(2) == 0 ? -1 : 1;
            bool isYOffset = Convert.ToBoolean(random.Next(2));

            int xTail = 0;
            int yTail = 0;
            if (isYOffset)
            {
                yTail = yHead + offSetTail;
                xTail = xHead;
            }
            else
            {
                xTail = xHead + offSetTail;
                yTail = yHead;
            }

            snake = new Snake(xHead, yHead, xTail, yTail);
        }
        public void MoveHandler()
        {
            if (snake.state == SnakeStateEnum.Pause)
            {
                return;
            }
            else if (snake.state == SnakeStateEnum.Up)
            {
                snake.tail.y = snake.head.y - 1;
            }
            else if (snake.state == SnakeStateEnum.Down)
            {
                snake.tail.y = snake.head.y + 1;
            }
            else if (snake.state == SnakeStateEnum.Left)
            {
                snake.tail.x = snake.head.x - 1;
            }
            else if (snake.state == SnakeStateEnum.Right)
            {
                snake.tail.x = snake.head.x + 1;
            }
        }
    }
}
