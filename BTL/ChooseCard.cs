using System;
using System.Windows.Forms;
using System.Media;
namespace BTL
{
    public partial class ChooseCard : Form
    {
        public ChooseCard()
        {
            InitializeComponent();
        }
        
        private void ChooseCard_Load(object sender, EventArgs e)
        {
            i = 0;
        }
        public static int i;
        public void btA1_Click(object sender, EventArgs e)
        {
            i = 1;
            this.Hide();
        }

        private void btA2_Click(object sender, EventArgs e)
        {
            i = 2;
            this.Hide();
        }

        private void btB1_Click(object sender, EventArgs e)
        {
            i = 3;
            this.Hide();
        }

        private void btB2_Click(object sender, EventArgs e)
        {
            i = 4;
            this.Hide();
        }

        private void btC1_Click(object sender, EventArgs e)
        {
            i = 5;
            this.Hide();
        }

        private void btC2_Click(object sender, EventArgs e)
        {
            i = 6;
            this.Hide();
        }

        private void btD1_Click(object sender, EventArgs e)
        {
            i = 7;
            this.Hide();
        }

        private void btD2_Click(object sender, EventArgs e)
        {
            i = 8;
            this.Hide();
        }

        private void btD3_Click(object sender, EventArgs e)
        {
            i = 9;
            this.Hide();
        }

        private void btD4_Click(object sender, EventArgs e)
        {
            i = 10;
            this.Hide();
        }

        private void ChooseCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            i = 0; 
        }
    }
}
