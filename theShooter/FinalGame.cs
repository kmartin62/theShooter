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

        private Scene scene = new Scene();
      
        public Hero hero { get; set; }
        private int x = 80;
        private int y = 400;

        public FinalGame()
        {
            hero = new Hero(15, 390, 50, 50);
          
            addBrick();
            addWall();
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
