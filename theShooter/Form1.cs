using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace theShooter
{
    public partial class Form1 : Form
    {
        private FinalGame game;       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            game.Check();
            if (game.hero.Up)
            {
                if(e.KeyCode == Keys.Up)
                {
                    game.hero.ChangeDirection(Hero.DIRECTION.UP);
                    
                    game.Move();
                }
            }

            if (game.hero.Down)
            {
                if(e.KeyCode == Keys.Down)
                {
                    game.hero.ChangeDirection(Hero.DIRECTION.DOWN);
                    game.Move();
                }
            }

            if (game.hero.Right)
            {
                if(e.KeyCode == Keys.Right)
                {
                    game.hero.ChangeDirection(Hero.DIRECTION.RIGHT);
                    game.Move();
                }
            }

            if (game.hero.Left)
            {
                if (e.KeyCode == Keys.Left)
                {
                    game.hero.ChangeDirection(Hero.DIRECTION.LEFT);
                    game.Move();
                }
            }

            Invalidate();
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //do something
        }

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            DoubleBuffered = true;
            newGame(); 
        }

        private void newGame()
        {
            game = new FinalGame();
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
            //e.Graphics.DrawImage(new Bitmap("8bit_megaman_cyclop_edit_by_oilusionista-d32d6fa.gif"), new Rectangle(new Point(15, 50), new Size(50, 50)));
           
        }
    }
}
