using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theShooter
{
    class Wall
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Wall(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Transparent, 3), new Rectangle(new Point(X, Y), new Size(Width, Height)));
        }
    }
}
