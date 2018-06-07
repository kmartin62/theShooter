using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theShooter
{
    class Scene
    {
        public List<Brick> helpers { get; set; }
        public List<Brick> bricks { get; set; }
        public List<Wall> walls { get; set; }
        public List<Crown> crowns { get; set; }
        public List<Gate> gates { get; set; }
        public List<Shoot> bullets { get; set; }
        public List<Zombie> zombies { get; set; }
        private bool first, second, third;
        private bool start0 = true;
        private bool start1 = true;
        private bool start2 = true;

        public Scene()
        {
            helpers = new List<Brick>();
            bricks = new List<Brick>();
            walls = new List<Wall>();
            crowns = new List<Crown>();
            gates = new List<Gate>();
            bullets = new List<Shoot>();
            zombies = new List<Zombie>();
            first = second = third = false;
        }

        public void MoveBullet()
        {
            foreach(Shoot b in bullets)
            {
                b.MoveBullet();
            }
        }

        public void addZombie()
        {
            zombies.Add(new Zombie(150, 390)); //0
            zombies.Add(new Zombie(270, 270)); //1
            zombies.Add(new Zombie(420, 150)); //2
        }

        public void deadZombie()
        {
            for(int i = 0; i < bullets.Count; i++)
            {
                for(int j = 0; j < zombies.Count; j++)
                {
                    if (bullets[i].IsHitZombie(zombies[j]))
                    {
                        zombies[j].Shot = true;
                    }
                }
            }

            for(int i = zombies.Count - 1; i >= 0; i--)
            {
                if (zombies[i].Shot)
                {
                    zombies.RemoveAt(i);
                }
            }
        }

        public bool HeroDead(Hero hero)
        {
            foreach(Zombie z in zombies)
            {
                return true;
            }

            return false;
        }

        public void MoveZombies()
        {

            if (!zombies[0].Shot)
            {
                if (start0)
                {
                    zombies[0].X += 50;
                    if (zombies[0].X >= 700)
                    {
                        start0 = false;
                    }
                }
            }

            
            if (!start0)
            {
                zombies[0].X -= 50;
                if(zombies[0].X <= 150)
                {
                    start0 = true;
                }
            }
           

                //start1 za 1 zombie
                if (!zombies[1].Shot)
                {
                    if (start1)
                    {
                        zombies[1].X += 50;
                        if (zombies[1].X >= 450)
                        {
                            start1 = false;
                        }
                    }

                    if (!start1)
                    {
                        zombies[1].X -= 50;
                        if (zombies[1].X <= 270)
                        {
                            start1 = true;
                        }
                    }
                }
            

            

                //start2 za 2 zombie
                if (!zombies[2].Shot)
                {
                    if (!start2)
                    {
                        zombies[2].X += 50;
                        if (zombies[2].X >= 450)
                        {
                            start2 = true;
                        }
                    }

                    if (start2)
                    {
                        zombies[2].X -= 50;
                        if (zombies[2].X <= 270)
                        {
                            start2 = false;
                        }
                    }
                }
            

        }

        //public void ChangeDir(Shoot.SHOOTINGDIRECTION dir)
        //{
        //    foreach(Shoot b in bullets)
        //    {
        //        b.changeDirection(dir);
        //    }
        //}

        public void shoot(Hero hero, Shoot.SHOOTINGDIRECTION dir)
        {
            Shoot shoot = new Shoot(hero.X, hero.Y);
            shoot.changeDirection(dir);
            bullets.Add(shoot);
        }

        public void addGates()
        {
            gates.Add(new Gate(527, 320, 70, 70, true)); //0
            gates.Add(new Gate(460, 0, 70, 100, false)); //1
            gates.Add(new Gate(730, 70, 70, 70, true)); //2
        }

        public void addCrowns()
        {
            crowns.Add(new Crown(730, 390, 50, 50)); //0
            crowns.Add(new Crown(730, 20, 50, 50)); //1
            crowns.Add(new Crown(350, 265, 50, 50)); //2
        }

        public void checkBullet(int x, int y)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].Y + 20 < 0 || bullets[i].Y + 20 > y || bullets[i].X + 20 < 0 || bullets[i].X + 20 > x)
                {
                    bullets[i].ShouldGo = true;
                }
            }

            for(int i = 0; i < bullets.Count; i++)
            {
                for(int j = 0; j < bricks.Count; j++)
                {
                    if (bullets[i].IsHit(bricks[j]))
                    {
                        bullets[i].ShouldGo = true;
                    }
                }
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                for (int j = 0; j < gates.Count; j++)
                {
                    if (bullets[i].IsHitGate(gates[j]))
                    {
                        bullets[i].ShouldGo = true;
                    }
                }
            }

            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                if (bullets[i].ShouldGo)
                {
                    bullets.RemoveAt(i);
                }
            }
        }

        public void check(Hero hero)
        {
            if(crowns.Count == 2)
            {
                first = true;
            }

            if(crowns.Count == 1)
            {
                second = true;
            }

            if(crowns.Count == 0)
            {
                third = true;
            }

            for (int i = 0; i < crowns.Count; i++)
            {
                if (crowns[i].IsHit(hero))
                {
                    crowns[i].IsColliding = true;
                    gates[i].Open = true;
                }
            }

            for(int i = crowns.Count - 1; i >= 0; i--)
            {
                if (crowns[i].IsColliding)
                {
                    crowns.RemoveAt(i);
                }
            }

            for(int i = gates.Count - 1; i >= 0; i--)
            {
                if (gates[i].Open)
                {
                    gates.RemoveAt(i);
                }
            }
        }

        public void addWalls(int x, int y)
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

        public void add(int x, int y)
        {
            

            //helpers
            helpers.Add(new Brick(x + 60, y - 580, 70, 50)); //0
            helpers.Add(new Brick(x + 70, y - 1000, 70, 50)); //1
            helpers.Add(new Brick(x + 453, y - 750, 60, 50)); //2
            helpers.Add(new Brick(x + 330, y - 3555, 65, 40)); //3 po y
            helpers.Add(new Brick(x + 2600, y - 255, 65, 60)); //4 po x
            helpers.Add(new Brick(x + 2600, y - 135, 65, 60)); //5 po x
            helpers.Add(new Brick(x + 185, y - 3550, 70, 40)); //6 po y


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

        public void Draw(Graphics g)
        {
            helpers.ForEach(c => c.Draw(g));
            bricks.ForEach(c => c.Draw(g));
            walls.ForEach(c => c.Draw(g));
            crowns.ForEach(c => c.Draw(g));
            gates.ForEach(c => c.Draw(g));
            bullets.ForEach(c => c.Draw(g));
            zombies.ForEach(c => c.Draw(g));
        }

     

        public void Check(Hero hero)
        {
            if (hero.X < walls[0].X)
            {
                if (hero.Y == 390 || hero.Y < 390)
                {
                    hero.Up = true;
                    hero.Down = false;
                    //hero.Right = true;
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

            if (hero.Y + hero.Height + 10 < walls[0].Y)
            {
                hero.Right = true;
                if (hero.X + hero.Width > walls[0].X)
                {
                    hero.Up = false;
                    hero.Down = false;
                    hero.Left = true;
                }

                if (hero.X == 15)
                {
                    hero.Left = false;
                }
            }

            if (hero.X > helpers[0].X && hero.X < helpers[0].X + helpers[0].Width)
            {
                hero.Down = true;
                hero.Right = false;

                if (hero.Y + hero.Height + 20 > walls[0].Y)
                {
                    hero.Up = true;
                    hero.Left = false;
                }

                if (hero.Y == 390)
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
            if (hero.X > helpers[2].X && hero.X + hero.Width < helpers[2].X + helpers[2].Width)
            {

                //kje ima porta
                if (first)
                {
                    hero.Up = true;
                }

                if (hero.Y < 390)
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
                    if (second)
                    {
                        hero.Left = true;
                    }

                }

                if (hero.Y == 390)
                {
                    hero.Right = true;
                    hero.Left = true;
                    hero.Down = false;
                }
            }

            if (hero.X + hero.Width > helpers[2].X + helpers[2].Width)
            {
                hero.Up = false;
                hero.Left = true;
                hero.Right = true;
            }

            if (hero.Y == 390)
            {
                if (hero.X + hero.Width > 816 - 40)
                {
                    hero.Right = false;


                }
            }

            if (hero.Y < walls[3].Y && hero.X > walls[4].X)
            {

                if (hero.X + hero.Width > 816 - 40)
                {
                    hero.Right = false;
                    //kje ima porta
                    if (third)
                    {
                        hero.Down = true;
                    }
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

                    if (hero.Y + hero.Height > walls[4].Y + walls[4].Height - 10)
                    {
                        hero.Down = false;
                    }
                }
            }

            //kje ima porta helper[3] walls[6] walls[7] helper[4] helper[5]
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
                    if ((hero.Y > helpers[4].Y && hero.Y + hero.Height < helpers[4].Y + helpers[4].Height) || (hero.Y > helpers[5].Y && hero.Y + hero.Height < helpers[5].Y + helpers[5].Height))
                    {
                        hero.Left = true;
                    }
                }

                if (hero.X > helpers[6].X && hero.X + hero.Width < helpers[6].X + helpers[6].Width)
                {
                    hero.Down = true;
                    hero.Up = true;

                    if (hero.Y + hero.Height + 10 < walls[0].Y)
                    {
                        hero.Up = false;
                        hero.Left = false;
                        hero.Right = true;
                        hero.Down = true;

                    }
                }

                if (hero.X < walls[5].X && hero.X > walls[1].X)
                {
                    //helpers[4]
                    if (hero.X < walls[6].X + walls[6].Width && hero.X + 20 > walls[6].X)
                    {
                        hero.Right = true;
                        //hero.Up = false;
                        //hero.Down = false;
                    }


                    if (hero.X < walls[6].X + walls[6].Width && hero.X + 20 > walls[6].X)
                    {
                        hero.Down = false;

                    }

                    if (hero.X < walls[1].X + walls[1].Width + 20)
                    {
                        hero.Left = false;
                    }
                }



            }

            //helper6 

            //walls[5]
            if (hero.Y > walls[7].Y && hero.X < walls[5].X && hero.X > walls[1].X + walls[1].Width)
            {
                if (hero.Y + hero.Height > walls[4].Y + walls[4].Height - 10)
                {
                    hero.Down = false;
                }
            }
        }
    }
}
