using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theShooter
{
    class Princess
    {
        private string princesHillary = "hillary-clinton.png";
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Safe { get; set; }

        public Princess(int x, int y, int height, int width)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Safe = false;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(new Bitmap("hillary-clinton.png"), new Rectangle(new Point(X, Y), new Size(Width, Height)));
        }

        public bool IsHit(Hero hero)
        {
            return X <= hero.X && hero.X <= X + Width && hero.Y >= Y && hero.Y <= Y + Height;
        }
    }
}
