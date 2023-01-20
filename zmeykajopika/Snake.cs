using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zmeykajopika
{
    public class Snake
    {
        public SnakeStateEnum state;
        public SnakeBlok head;
        public SnakeBlok tail;
        public List<SnakeBlok> body = new List<SnakeBlok>();
        public Snake(int xHead, int yHead, int xTail, int yTail)
        {
            head = new SnakeBlok(xHead, yHead);
            tail = new SnakeBlok(xTail, yTail);
        }
        public void Draw(Graphics g)
        {
            head.DrawBlok(g, true);
            tail.DrawBlok(g);
            foreach (SnakeBlok blok in body)
            {
                blok.DrawBlok(g);
            }
        } 
    }
    
}
