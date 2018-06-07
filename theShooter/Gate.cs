using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theShooter
{
    class Gate
    {
        private string gate = "line-dividers-without-background-6.png";
        private string verticalGate = "vertical gate.png";
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Position { get; set; }
        public bool Open { get; set; }

        public Gate(int x, int y, int width, int height, bool pos)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Open = false;
            Position = pos;
        }

        public void Draw(Graphics g)
        {
            if (Position)
            {
                g.DrawImage(new Bitmap(gate), new Rectangle(new Point(X, Y), new Size(Width, Height)));
            }
            else
            {
                g.DrawImage(new Bitmap(verticalGate), new Rectangle(new Point(X, Y), new Size(Width, Height)));
            }
        }
    }
}
