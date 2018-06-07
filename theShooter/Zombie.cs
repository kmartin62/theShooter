using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theShooter
{
    class Zombie
    {
        private string zombie = "zombie_pixelart2.png";
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Shot { get; set; }

        public Zombie(int x, int y)
        {
            X = x;
            Y = y;
            Width = Height = 50;
            Shot = false;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(new Bitmap(zombie), new Rectangle(new Point(X, Y), new Size(Width, Height)));
        }

        public bool IsHit(Hero hero)
        {
            return X <= hero.X && hero.X <= X + Width && hero.Y >= Y && hero.Y <= Y + Height;
        }

        
    }
}
