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
        public SnakeStateEnum nextState;
        Random random = new Random();
        Food food;
        Size ClientSize;
        public int score;
        public int CountCellsWidth => ClientSize.Width / Kletochki.width;
        public int CountCellsHeigth => ClientSize.Height / Kletochki.heigth;

        public Controller(Size size)
        {
            ClientSize = size;
            NewGame();
        }

        public void NewGame()
        {
            score = 2;
            nextState = SnakeStateEnum.Pause;
            CreateSnake();
            CreateFood();
        }
        public void Draw(Graphics g)
        {
            snake?.Draw(g);
            food?.DrawFood(g);
        }

        private void CreateSnake()
        {
            int xHead = random.Next(1, CountCellsWidth - 1);
            int yHead = random.Next(1, CountCellsHeigth - 1);

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

        private void CreateFood()
        {
            List<Point> freeBloks = new List<Point>();
            for (int x = 0; x < CountCellsWidth; x++)
            {
                for(int y = 0; y < CountCellsHeigth; y++)
                {
                    if (snake.head.x == x && snake.head.y == y || snake.tail.x == x && snake.tail.y == y)
                        continue;
                    else if (snake.body.Any(blok => blok.x == x && blok.y == y))
                        continue;
                    freeBloks.Add(new Point (x, y));
                }
            }
            if (freeBloks.Any())
            {
                Point randPoint = freeBloks[random.Next(freeBloks.Count)];
                food = new Food(randPoint.X, randPoint.Y);
            }
        }
        public void MoveHandler()
        {
            SnakeBlok tempTail = new SnakeBlok(snake.tail.x, snake.tail.y);
            snake.state = nextState;
            if (snake.state == SnakeStateEnum.Pause)
            {
                return;
            }
            else if (snake.state == SnakeStateEnum.Up)
            {
                snake.tail.y = snake.head.y - 1;
                snake.tail.x = snake.head.x;
            }
            else if (snake.state == SnakeStateEnum.Down)
            {
                snake.tail.y = snake.head.y + 1;
                snake.tail.x = snake.head.x;
            }
            else if (snake.state == SnakeStateEnum.Left)
            {
                snake.tail.x = snake.head.x - 1;
                snake.tail.y = snake.head.y;
            }
            else if (snake.state == SnakeStateEnum.Right)
            {
                snake.tail.x = snake.head.x + 1;
                snake.tail.y = snake.head.y;
            }
            snake.body.Insert(0, snake.head);
            snake.head = snake.tail;
            SnakeOutPole();

            if (snake.head.x == food?.x && snake.head.y == food?.y) // если съедена еда, то тогда хвост появляется в прошлых координатах
            {
                score++;
                snake.tail = tempTail;
                CreateFood();
            }
            else //иначе последний блок тела переносится в хвост
            {
                snake.tail = snake.body.Last();
                snake.body.RemoveAt(snake.body.Count - 1);
            }

            
        }
        private void SnakeOutPole()
        {
            if (snake.head.x < 0)
                snake.head.x = CountCellsWidth - 1;
            else if (snake.head.y < 0)
                snake.head.y = CountCellsHeigth - 1;
            else if (snake.head.x > CountCellsWidth - 1)
                snake.head.x = 0;
            else if (snake.head.y > CountCellsHeigth -1)
                snake.head.y = 0;
        }
    }
}
