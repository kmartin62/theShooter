using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theShooter
{
    class Hero
    {
        public enum DIRECTION { UP, DOWN, LEFT, RIGHT}
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
        public DIRECTION dir;
        private string hero = "8bit_megaman_cyclop_edit_by_oilusionista-d32d6fa.gif";
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Hero(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            dir = DIRECTION.UP;
            Up = false;
            Right = false;
            Left = false;
            Down = false;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(new Bitmap(hero), new Rectangle(new Point(X, Y), new Size(Width, Height)));
            g.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(new Point(X, Y), new Size(Width, Height)));
        }

        public void ChangeDirection(DIRECTION direction)
        {
            if(direction == DIRECTION.UP)
            {
                dir = DIRECTION.UP;
            }

            if(direction == DIRECTION.DOWN)
            {
                dir = DIRECTION.DOWN;
            }

            if(direction == DIRECTION.RIGHT)
            {
                dir = DIRECTION.RIGHT;
            }

            if(direction == DIRECTION.LEFT)
            {
                dir = DIRECTION.LEFT;
            }
        }

        public void Move()
        {
            int Z = 15;
            if (Up)
            {
                if (dir == DIRECTION.UP)
                {
                    Y = Y - Z;
                }
            }

            if (Down)
            {
                if (dir == DIRECTION.DOWN)
                {
                    Y = Y + Z;
                }
            }

            if (Right)
            {
                if(dir == DIRECTION.RIGHT)
                {
                    X = X + Z;
                }
            }

            if (Left)
            {
                if(dir == DIRECTION.LEFT)
                {
                    X = X - Z;
                }
            }

            
        }
    }
}
