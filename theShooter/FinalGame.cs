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

        public Scene scene = new Scene();
        public Shoot shoot { get; set; }
        public Hero hero { get; set; }
        private int x = 80;
        private int y = 400;

        public FinalGame()
        {
            hero = new Hero(15, 390, 50, 50);
            shoot = new Shoot(hero.X, hero.Y);
          
            addBrick();
            addWall();
            addCrown();
            addGates();
        }

        public void MoveShoot()
        {
            scene.MoveBullet();
        }

        public void checkBullets(int x, int y)
        {
            scene.checkBullet(x, y);
        }

        public void Shoot()
        {
            scene.shoot(hero, (Shoot.SHOOTINGDIRECTION)hero.dir);
        }

        public void addGates()
        {
            scene.addGates();
        }

        public void check()
        {
            scene.check(hero);
        }

        private void addCrown()
        {
            scene.addCrowns();
        }

        private void addBrick()
        {
            scene.add(x, y);
        }

        private void addWall()
        {
            scene.addWalls(x, y);
        }

        public void Draw(Graphics g)
        {
            scene.Draw(g);
            hero.Draw(g);
        }

        public void ChangeBullet(Shoot.SHOOTINGDIRECTION direction)
        {
          //  scene.ChangeDir(direction);
            //shoot.changeDirection(direction);
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
            scene.Check(hero);
        }
    }
}
