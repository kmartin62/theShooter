using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theShooter
{
    class Shoot
    {
        private string weapon = "shot_poulpi.png";
        public enum SHOOTINGDIRECTION { UP, DOWN, LEFT, RIGHT}
        public SHOOTINGDIRECTION direction;
        public bool ShouldGo { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Shoot()
        {

        }

        public Shoot(int x, int y)
        {
            X = x;
            Y = y;
            ShouldGo = false;
            direction = SHOOTINGDIRECTION.DOWN; 
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(new Bitmap(weapon), new Rectangle(new Point(X, Y), new Size(40, 40)));
        }

        public void changeDirection(SHOOTINGDIRECTION dir)
        {
            if(dir == SHOOTINGDIRECTION.UP)
            {
                direction = SHOOTINGDIRECTION.UP;
            }

            if (dir == SHOOTINGDIRECTION.DOWN)
            {
                direction = SHOOTINGDIRECTION.DOWN;
            }

            if (dir == SHOOTINGDIRECTION.LEFT)
            {
                direction = SHOOTINGDIRECTION.LEFT;
            }

            if (dir == SHOOTINGDIRECTION.RIGHT)
            {
                direction = SHOOTINGDIRECTION.RIGHT;
            }
        }

        public void MoveBullet()
        {
            int z = 40;
           //Y = Y - z;

            if(direction == SHOOTINGDIRECTION.UP)
            {
                Y -= z;
            }

            if(direction == SHOOTINGDIRECTION.DOWN)
            {
                Y += z;
            }

            if(direction == SHOOTINGDIRECTION.LEFT)
            {
                X -= z;
            }

            if(direction == SHOOTINGDIRECTION.RIGHT)
            {
                X += z;
            }
        }

        public bool IsHit(Brick wall)
        {
            return X <= wall.X && wall.X <= X + 40 && wall.Y >= Y && wall.Y <= Y + 40;
        }

        public bool IsHitGate(Gate wall)
        {
            return X <= wall.X && wall.X <= X + 40 && wall.Y >= Y && wall.Y <= Y + 40;
        }
    }
}
