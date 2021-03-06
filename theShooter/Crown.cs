﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theShooter
{
    class Crown
    {
        private string crown = "crown.png";
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsColliding { get; set; }

        public Crown(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            IsColliding = false;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(new Bitmap(crown), new Rectangle(new Point(X, Y), new Size(Width, Height)));
            g.DrawRectangle(new Pen(Color.Transparent, 3), new Rectangle(new Point(X, Y), new Size(Width, Height)));
        }

        public bool IsHit(Hero hero)
        {
            return X <= hero.X && hero.X <= X + Width && hero.Y >= Y && hero.Y <= Y + Height;
        }
    }
}
