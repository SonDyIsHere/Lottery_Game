using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL
{
    public partial class FrmBia : Form
    {
        public FrmBia()
        {
            InitializeComponent();
        }
      
        private void FrmBia_Load(object sender, EventArgs e)
        {
      
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            PlayerName f = new PlayerName();
            f.Show();
            this.Hide();
        }

        private void FrmBia_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("BẠN MUỐN THOÁT?", "CẢNH BÁO",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                e.Cancel = true;
        }

        private void btEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
