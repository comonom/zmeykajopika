using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zmeykajopika.Properties;

namespace zmeykajopika
{
    public class Food
    {
        public int x, y;
        public void DrawFood(Graphics g)
        {
            Random random = new Random();
            random.Next();
            g.DrawImage(Resources.free_icon_apple_1330449, x*Kletochki.width, y*Kletochki.heigth, Kletochki.width, Kletochki.heigth);
        }
    }
}
