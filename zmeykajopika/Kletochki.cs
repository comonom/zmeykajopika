using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zmeykajopika
{
    public static class Kletochki
    {
        public const int width = 40, heigth = 40;
        public static void poleDraw(Graphics g, Size area)
        {
            for(int x =0; x<area.Width; x += width)
            {
                g.DrawLine(new Pen(Color.Black), x, 0, x, area.Height);
            } 
            for (int y = 0; y < area.Height; y += heigth)
            {
                g.DrawLine(new Pen(Color.Black),0,y,area.Width,y);
            }
        }
    }
}