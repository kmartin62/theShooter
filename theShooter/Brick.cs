using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theShooter
{
    class Brick
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string brick { get; set; }

        public Brick(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            brick = "bricks_001aPreview1.jpg";
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(new Bitmap(brick), new Rectangle(new Point(X, Y), new Size(Width, Height)));
        }
    }
}
