using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theShooter
{
    class FinalGame
    {
        public List<Brick> bricks { get; set; }
        public List<Wall> walls { get; set; }
        public List<Brick> helpers { get; set; }
        public Hero hero { get; set; }
        private int x = 80;
        private int y = 400;

        public FinalGame()
        {
            hero = new Hero(15, 390, 50, 50);
            bricks = new List<Brick>();
            helpers = new List<Brick>();
            walls = new List<Wall>();
            addBrick();
            addWall();
        }

        private void addBrick()
        {
            //helper
            helpers.Add(new Brick(x + 60, y - 580, 70, 50));
            helpers.Add(new Brick(x + 70, y  - 1000, 70, 50));
            helpers.Add(new Brick(x + 453, y - 750, 60, 50));
            helpers.Add(new Brick(x + 330, y - 355, 65, 40));

            //1
            bricks.Add(new Brick(x, y, 50, 50));
            bricks.Add(new Brick(x, y - 50, 50, 50));
            bricks.Add(new Brick(x, y - 100, 50, 50));
            bricks.Add(new Brick(x, y - 150, 50, 50));
            bricks.Add(new Brick(x, y - 200, 50, 50));
            bricks.Add(new Brick(x, y - 250, 50, 50));
            bricks.Add(new Brick(x, y - 300, 50, 50));

            //2
            bricks.Add(new Brick(x + 130, y - 400, 50, 50));
            bricks.Add(new Brick(x + 130, y - 350, 50, 50));
            bricks.Add(new Brick(x + 130, y - 300, 50, 50));
            bricks.Add(new Brick(x + 130, y - 250, 50, 50));
            bricks.Add(new Brick(x + 130, y - 200, 50, 50));
            bricks.Add(new Brick(x + 130, y - 150, 50, 50));
            bricks.Add(new Brick(x + 130, y - 100, 50, 50));
            bricks.Add(new Brick(x + 130, y - 50, 50, 25));

            //3
            bricks.Add(new Brick(x + 180, y - 75, 50, 50));
            bricks.Add(new Brick(x + 230, y - 75, 50, 50));
            bricks.Add(new Brick(x + 280, y - 75, 50, 50));
            bricks.Add(new Brick(x + 330, y - 75, 50, 50));
            bricks.Add(new Brick(x + 380, y - 75, 65, 50));

            //4
            bricks.Add(new Brick(x + 520, y - 75, 70, 50));
            bricks.Add(new Brick(x + 590, y - 75, 50, 50));
            bricks.Add(new Brick(x + 640, y - 75, 50, 50));
            bricks.Add(new Brick(x + 690, y - 75, 50, 50));

            //5
            bricks.Add(new Brick(x + 520, y - 125, 50, 50));
            bricks.Add(new Brick(x + 520, y - 175, 50, 50));
            bricks.Add(new Brick(x + 520, y - 225, 50, 50));
            bricks.Add(new Brick(x + 520, y - 275, 50, 50));
            bricks.Add(new Brick(x + 520, y - 305, 50, 30));

            bricks.Add(new Brick(x + 570, y - 125, 75, 50));
            bricks.Add(new Brick(x + 570, y - 175, 75, 50));
            bricks.Add(new Brick(x + 570, y - 225, 75, 50));
            bricks.Add(new Brick(x + 570, y - 275, 75, 50));
            bricks.Add(new Brick(x + 570, y - 305, 75, 30));

            //6
            bricks.Add(new Brick(x + 395, y - 125, 50, 50));
            bricks.Add(new Brick(x + 395, y - 175, 50, 50));
            bricks.Add(new Brick(x + 395, y - 225, 50, 50));
            bricks.Add(new Brick(x + 395, y - 275, 50, 50));
            bricks.Add(new Brick(x + 395, y - 305, 50, 30));

            //7
            bricks.Add(new Brick(x + 260, y - 305, 65, 40));

            //8
            bricks.Add(new Brick(x + 260, y - 185, 65, 40));

        }

        private void addWall()
        {
            walls.Add(new Wall(x, y - 300, 50, 350)); //1
            walls.Add(new Wall(x + 130, y - 400, 50, 375)); //2
            walls.Add(new Wall(x + 180, y - 75, 263, 50)); //3
            walls.Add(new Wall(x + 520, y - 75, 200, 50)); //4
            walls.Add(new Wall(x + 520, y - 305, 125, 230)); //5
            walls.Add(new Wall(x + 393, y - 305, 50, 230)); //6
            walls.Add(new Wall(x + 260, y - 305, 65, 40)); //7
            walls.Add(new Wall(x + 260, y - 185, 65, 40)); //8
        }

        public void Draw(Graphics g)
        {
            bricks.ForEach(c => c.Draw(g));
            walls.ForEach(c => c.Draw(g));
            helpers.ForEach(c => c.Draw(g));
            hero.Draw(g);
        }

        public void ChangeDirection(Hero.DIRECTION direction)
        {
            hero.ChangeDirection(direction);
        }

        public void Move()
        {
            hero.Move();
        }

        public void Check()
        {
            if(hero.X < walls[0].X)
            {
                if(hero.Y == 390 || hero.Y < 390)
                {
                    hero.Up = true;
                    hero.Down = false;
                    hero.Right = true;
                }

                if (hero.Y < 390)
                {
                    hero.Down = true;
                    hero.Right = false;
                }

                if (hero.Y + hero.Height + 10 < walls[0].Y)
                {
                    hero.Up = false;
                    hero.Right = false;
                }

                
            }

            if(hero.Y + hero.Height + 10 < walls[0].Y)
            {
                hero.Right = true;
                if(hero.X + hero.Width > walls[0].X)
                {
                    hero.Up = false;
                    hero.Down = false;
                    hero.Left = true;
                }

                if(hero.X == 15)
                {
                    hero.Left = false;
                }
            }

            if (hero.X > helpers[0].X && hero.X < helpers[0].X + helpers[0].Width)
            {
                hero.Down = true;
                hero.Right = false;

                if(hero.Y + hero.Height + 20 > walls[0].Y)
                {
                    hero.Up = true;
                    hero.Left = false;
                }

                if(hero.Y == 390)
                {
                    hero.Down = false;
                    hero.Right = true;
                    hero.Left = false;
                }
            }

            if (hero.X > helpers[1].X && hero.X < walls[2].X + walls[2].Width)
            { 
                    hero.Left = true;
                    hero.Up = false;
            }

            //helper
            if(hero.X > helpers[2].X && hero.X + hero.Width < helpers[2].X + helpers[2].Width)
            {

                //kje ima porta

                hero.Up = true;
                if(hero.Y < 390)
                {
                    hero.Down = true;
                    hero.Right = false;
                    hero.Left = false;
                }

                if (hero.Y + hero.Height + 10 < walls[0].Y)
                {
                    hero.Up = false;
                    //proverka za left, porta
                    hero.Right = true;
                    hero.Left = true;

                }

                if(hero.Y == 390)
                {
                    hero.Right = true;
                    hero.Left = true;
                    hero.Down = false;
                }
            }

            if(hero.X + hero.Width > helpers[2].X + helpers[2].Width)
            {
                hero.Up = false;
                hero.Left = true;
                hero.Right = true;
            }

            if(hero.Y == 390)
            {
                if(hero.X + hero.Width > 816 - 40)
                {
                    hero.Right = false;


                }
            }

            if(hero.Y < walls[3].Y && hero.X > walls[4].X)
            {
               
                if (hero.X + hero.Width > 816 - 40)
                {
                    hero.Right = false;
                    //kje ima porta
                    hero.Down = true;
                }

                
                if (hero.Y + hero.Height < walls[4].Y + walls[4].Height)
                {
                    hero.Up = true;
                    hero.Left = false;

                    if (hero.Y + hero.Height + 10 < walls[0].Y)
                    {
                        hero.Up = false;
                        hero.Left = true;
                       
                    }

                    if(hero.Y + hero.Height > walls[4].Y + walls[4].Height - 10)
                    {
                        hero.Down = false;
                    }
                }
            }

            //kje ima porta helper[3] walls[6] walls[7]
            if (hero.Y < walls[2].Y)
            {
                if (hero.X > helpers[3].X && hero.X + hero.Width < helpers[3].X + helpers[3].Width)
                {
                    hero.Down = true;
                    hero.Up = true;

                    if (hero.Y + hero.Height > walls[6].Y)
                    {
                        hero.Right = false;
                        hero.Left = false;
                    }

                    if (hero.Y + hero.Height + 10 < walls[0].Y)
                    {
                        hero.Up = false;
                        hero.Left = true;
                        hero.Right = true;

                    }
                }

 
            }
            //walls[5]
            if(hero.Y > walls[7].Y && hero.X < walls[5].X && hero.X > walls[1].X + walls[1].Width)
            {
                if (hero.Y + hero.Height > walls[4].Y + walls[4].Height - 10)
                    {
                        hero.Down = false;
                    }
            }


        }
    }
}
