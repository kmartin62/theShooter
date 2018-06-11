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
    public partial class Front : Form
    {
        public Front()
        {
            InitializeComponent();
        }

        private void Front_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Убиј ги чудовиштата и пробај да ја ослободиш Хилари Клинтон. Се пука на SPACE а херојот се командува на стрелките за движење. Be brave and don't dissapoint me! >:(");
        }
    }
}
