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
    public partial class PlayerName : Form
    {
        public PlayerName()
        {
            InitializeComponent();
        }
        
        private void PlayerName_Load(object sender, EventArgs e)
        {
            
        }
        public static int i;
        private void btStart_Click(object sender, EventArgs e)
        {
            Start();
        }
        private void Start()
        {
            if (tbname.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên người chơi");
            }
            else
            {
                if (rdNormal.Checked)
                    i = 1;
                if (rdAuto.Checked)
                    i = 2;
                FrmMain.name = tbname.Text;
                FrmMain f = new FrmMain();
                f.Show();
                this.Hide();
            }
        }
        private void PlayerName_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("BẠN MUỐN THOÁT?", "CẢNH BÁO",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                e.Cancel = true;
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter: Start(); break;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
