using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zmeykajopika
{
    public class SnakeBlok
    {
        public int x, y;
        public SnakeBlok(int x,int y) 
        {
            this.x = x;
            this.y = y;
        }
        public void DrawBlok(Graphics g, bool isHead = false)
        {
            g.FillRectangle(isHead ? Brushes.Red : Brushes.Blue, x*Kletochki.width, y*Kletochki.heigth, Kletochki.width, Kletochki.heigth);
        }
    }
}
