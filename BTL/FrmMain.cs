using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BTL
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        public static string name = "";
        string[,] brr;
        string[] arr;
        string[] check = new string[89];
        int i;
        int Diem;
        Random rd = new Random();
        SoundPlayer sd = new SoundPlayer("D://loto.wav");
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //sd.Play();
            arr = new string[89];
            brr = new string[5, 5];
            i = 0;
            Diem = 0;
            lbPlayer.Text = name;
        }
          

        Color[] color = { Color.Red, Color.Lime, Color.Gold, Color.Blue, Color.Fuchsia };

        
        private void btChoose_Click(object sender, EventArgs e)
        {
            Button[,] a = { {so1, so2, so3, so4, so5},
                           {so6, so7, so8, so9, so10},
                           {so11, so12, so13, so14, so15},
                           {so16, so17, so18, so19, so20},
                           {so21, so22, so23, so24, so25},

            };

            int i = 0;

            while (i < brr.GetLength(0))
            {
                int j = 0;
                while(j < brr.GetLength(1))
                {
                    string x = rd.Next(1, 90).ToString();

                    if (Check(brr, i, j, x) == true)
                    {
                        brr[i, j] = x;
                        j++;
                    }
                    else
                        continue;   
                }
                i++;  
            }

            for (int x = 0; x < a.GetLength(0); x++)
                for (int y = 0; y < a.GetLength(1); y++)
                {
                    a[x, y].Text = brr[x,y];
                    
                }
            pnPhieu.ForeColor = color[rd.Next(0, 5)];
        }

        private bool Check(string[,] arr,int size1, int size2,string x)
        {
            int i = 0;
            while(i <= size1)
            {
                int j = 0;
                while(j < arr.GetLength(1))
                {
                    if (arr[i, j] == x)
                        return false;
                    else
                        j++;
                }
                i++;
            }
            return true;
        }

        private bool Check1(string[] a,int size, string x)
        {
            for (int i = 0; i < size; i++) 
            {
                if (a[i] == x)
                    return false;
            } 
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sd.Stop();
            this.Close();
            FrmBia f = new FrmBia();
            f.Show();
        }

        private void btQuay_Click(object sender, EventArgs e)
        {
            if (so1.Text == "-")
            {
                MessageBox.Show("Bạn phải chọn phiếu trước");
            }
            else
            {
                int i = 0;
                while (i < arr.Length)
                {
                    string x = rd.Next(1, 90).ToString();

                    if (Check1(arr, i, x) == true)
                        arr[i++] = x;
                }
                btChoose.Enabled = false;
                btChoose3.Enabled = false;
                btStop.BackColor = Color.White;
                btQuay.BackColor = Color.Cyan;

                timer1.Enabled = true;
                if (PlayerName.i == 1)
                    timer2.Enabled = true;
                else if (PlayerName.i == 2)
                    timer3.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbNumber.Text = arr[i];
            check[i] = lbNumber.Text;
            listContains.Items.Add(lbNumber.Text);
            i++;
            if (i == arr.Length)
            {
                timer1.Enabled = false;
                MessageBox.Show("Hết số để gọi");
            }
            
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            CheckWin();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            AutoCheck();
            CheckWin();
            
        }
        private void btStop_Click(object sender, EventArgs e)
        {
            if (so1.Text == "-")
            {
                MessageBox.Show("Bạn phải chọn phiếu trước");
            }
            else
            {
                timer1.Enabled = false;
                btQuay.BackColor = Color.White;
                btStop.BackColor = Color.Cyan;
            }
        }


        private void AutoCheck()
        {
            Button[,] a = { {so1, so2, so3, so4, so5},
                           {so6, so7, so8, so9, so10},
                           {so11, so12, so13, so14, so15},
                           {so16, so17, so18, so19, so20},
                           {so21, so22, so23, so24, so25},

            };

            for (int i = 0; i < a.GetLength(0); i++) 
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j].Text == lbNumber.Text)
                    {
                        a[i, j].Enabled = false;
                        a[i, j].BackColor = Color.Cyan;
                    }
                }
        }
        private void CheckWin()
        {
            Button[,] a = { {so1, so2, so3, so4, so5},
                           {so6, so7, so8, so9, so10},
                           {so11, so12, so13, so14, so15},
                           {so16, so17, so18, so19, so20},
                           {so21, so22, so23, so24, so25},

            };
            int j = 0;
            for (int i = 0; i < a.GetLength(0); i++)  
            {
                if ((a[i, j].Enabled == false &&
                    a[i, j + 1].Enabled == false &&
                    a[i, j + 2].Enabled == false &&
                    a[i, j + 3].Enabled == false &&
                    a[i, j + 4].Enabled == false) ||

                        (a[j, i].Enabled == false &&
                        a[j + 1, i].Enabled == false &&
                        a[j + 2, i].Enabled == false &&
                        a[j + 3, i].Enabled == false &&
                        a[j + 4, i].Enabled == false))
                {
                    timer1.Enabled = timer2.Enabled = timer3.Enabled = false;
                    MessageBox.Show("CHÚC MỪNG BẠN ĐÃ THẮNG");
                   
                    Diem += 10;
                    lbDiem.Text = Diem.ToString();

                }    
            }
        }

        private void btChoose3_Click(object sender, EventArgs e)
        {
            QuickChoise();         
        }

        private void so1_Click(object sender, EventArgs e)
        {
           
            Button bt = (Button)sender;

            if (bt.BackColor == Color.White)
                bt.BackColor = Color.Cyan;
            else
                bt.BackColor = Color.White;

        }

        private void btReplay_Click(object sender, EventArgs e)
        {
            Button[,] a = { {so1, so2, so3, so4, so5},
                           {so6, so7, so8, so9, so10},
                           {so11, so12, so13, so14, so15},
                           {so16, so17, so18, so19, so20},
                           {so21, so22, so23, so24, so25},

            };
            listContains.Items.Clear();
            lbNumber.Text = "";
            timer1.Enabled = false;
            timer2.Enabled = false;
            arr = new string[89];
            brr = new string[5, 5];
            check = new string[89];
            btChoose.Enabled = true;
            btChoose3.Enabled = true;
            pnPhieu.ForeColor = Color.Black;
            btQuay.BackColor = Color.White;
            btStop.BackColor = Color.White;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j].Text = "-";
                    a[i, j].BackColor = Color.White;
                    a[i, j].Enabled = true;

                }
            i = 0;
            
            
        }

        private void QuickChoise()
        {
            ChooseCard f = new ChooseCard();
            f.ShowDialog();
            if (ChooseCard.i == 1)
            {
                so1.Text = "1";
                so2.Text = "23";
                so3.Text = "12";
                so4.Text = "78";
                so5.Text = "9";
                so6.Text = "56";
                so7.Text = "33";
                so8.Text = "27";
                so9.Text = "19";
                so10.Text = "89";
                so11.Text = "51";
                so12.Text = "45";
                so13.Text = "39";
                so14.Text = "90";
                so15.Text = "70";
                so16.Text = "66";
                so17.Text = "22";
                so18.Text = "81";
                so19.Text = "20";
                so20.Text = "13";
                so21.Text = "75";
                so22.Text = "21";
                so23.Text = "65";
                so24.Text = "58";
                so25.Text = "43";
                pnPhieu.ForeColor = Color.Red;
            }
            if (ChooseCard.i == 2)
            {
                so1.Text = "11";
                so2.Text = "65";
                so3.Text = "41";
                so4.Text = "7";
                so5.Text = "61";
                so6.Text = "79";
                so7.Text = "36";
                so8.Text = "4";
                so9.Text = "73";
                so10.Text = "70";
                so11.Text = "81";
                so12.Text = "1";
                so13.Text = "76";
                so14.Text = "88";
                so15.Text = "82";
                so16.Text = "31";
                so17.Text = "28";
                so18.Text = "24";
                so19.Text = "57";
                so20.Text = "90";
                so21.Text = "48";
                so22.Text = "56";
                so23.Text = "18";
                so24.Text = "5";
                so25.Text = "9";
                pnPhieu.ForeColor = Color.Red;
            }
            if (ChooseCard.i == 3)
            {
                so1.Text = "73";
                so2.Text = "5";
                so3.Text = "29";
                so4.Text = "30";
                so5.Text = "56";
                so6.Text = "80";
                so7.Text = "10";
                so8.Text = "35";
                so9.Text = "54";
                so10.Text = "63";
                so11.Text = "81";
                so12.Text = "4";
                so13.Text = "26";
                so14.Text = "45";
                so15.Text = "61";
                so16.Text = "79";
                so17.Text = "3";
                so18.Text = "14";
                so19.Text = "43";
                so20.Text = "50";
                so21.Text = "71";
                so22.Text = "7";
                so23.Text = "23";
                so24.Text = "31";
                so25.Text = "52";
                pnPhieu.ForeColor = Color.Blue;
            }
            if (ChooseCard.i == 4)
            {
                so1.Text = "32";
                so2.Text = "11";
                so3.Text = "35";
                so4.Text = "59";
                so5.Text = "69";
                so6.Text = "80";
                so7.Text = "17";
                so8.Text = "24";
                so9.Text = "42";
                so10.Text = "57";
                so11.Text = "76";
                so12.Text = "1";
                so13.Text = "27";
                so14.Text = "48";
                so15.Text = "79";
                so16.Text = "81";
                so17.Text = "7";
                so18.Text = "16";
                so19.Text = "31";
                so20.Text = "65";
                so21.Text = "77";
                so22.Text = "23";
                so23.Text = "44";
                so24.Text = "50";
                so25.Text = "71";
                pnPhieu.ForeColor = Color.Blue;
            }
            if (ChooseCard.i == 5)
            {
                so1.Text = "77";
                so2.Text = "13";
                so3.Text = "22";
                so4.Text = "41";
                so5.Text = "61";
                so6.Text = "86";
                so7.Text = "3";
                so8.Text = "24";
                so9.Text = "34";
                so10.Text = "52";
                so11.Text = "71";
                so12.Text = "1";
                so13.Text = "35";
                so14.Text = "56";
                so15.Text = "64";
                so16.Text = "83";
                so17.Text = "7";
                so18.Text = "23";
                so19.Text = "36";
                so20.Text = "53";
                so21.Text = "75";
                so22.Text = "5";
                so23.Text = "48";
                so24.Text = "59";
                so25.Text = "50";
                pnPhieu.ForeColor = Color.Gold;
            }
            if (ChooseCard.i == 6)
            {
                so1.Text = "39";
                so2.Text = "14";
                so3.Text = "28";
                so4.Text = "50";
                so5.Text = "75";
                so6.Text = "90";
                so7.Text = "19";
                so8.Text = "31";
                so9.Text = "49";
                so10.Text = "68";
                so11.Text = "81";
                so12.Text = "5";
                so13.Text = "20";
                so14.Text = "47";
                so15.Text = "77";
                so16.Text = "84";
                so17.Text = "12";
                so18.Text = "38";
                so19.Text = "55";
                so20.Text = "69";
                so21.Text = "89";
                so22.Text = "1";
                so23.Text = "36";
                so24.Text = "46";
                so25.Text = "86";
                pnPhieu.ForeColor = Color.Gold;
            }
            if (ChooseCard.i == 7)
            {
                so1.Text = "52";
                so2.Text = "19";
                so3.Text = "28";
                so4.Text = "46";
                so5.Text = "68";
                so6.Text = "75";
                so7.Text = "5";
                so8.Text = "26";
                so9.Text = "39";
                so10.Text = "58";
                so11.Text = "78";
                so12.Text = "14";
                so13.Text = "37";
                so14.Text = "50";
                so15.Text = "69";
                so16.Text = "84";
                so17.Text = "3";
                so18.Text = "25";
                so19.Text = "57";
                so20.Text = "60";
                so21.Text = "86";
                so22.Text = "70";
                so23.Text = "4";
                so24.Text = "9";
                so25.Text = "30";
                pnPhieu.ForeColor = Color.Lime;
            }
            if (ChooseCard.i == 8)
            {
                so1.Text = "79";
                so2.Text = "6";
                so3.Text = "18";
                so4.Text = "47";
                so5.Text = "69";
                so6.Text = "13";
                so7.Text = "31";
                so8.Text = "44";
                so9.Text = "61";
                so10.Text = "70";
                so11.Text = "7";
                so12.Text = "24";
                so13.Text = "34";
                so14.Text = "56";
                so15.Text = "71";
                so16.Text = "5";
                so17.Text = "23";
                so18.Text = "10";
                so19.Text = "17";
                so20.Text = "42";
                so21.Text = "82";
                so22.Text = "3";
                so23.Text = "26";
                so24.Text = "58";
                so25.Text = "66";
                pnPhieu.ForeColor = Color.Lime;
            }
            if (ChooseCard.i == 9)
            {
                so1.Text = "33";
                so2.Text = "18";
                so3.Text = "29";
                so4.Text = "58";
                so5.Text = "74";
                so6.Text = "90";
                so7.Text = "17";
                so8.Text = "38";
                so9.Text = "44";
                so10.Text = "69";
                so11.Text = "88";
                so12.Text = "2";
                so13.Text = "27";
                so14.Text = "37";
                so15.Text = "55";
                so16.Text = "67";
                so17.Text = "7";
                so18.Text = "23";
                so19.Text = "36";
                so20.Text = "53";
                so21.Text = "75";
                so22.Text = "48";
                so23.Text = "59";
                so24.Text = "72";
                so25.Text = "24";
                pnPhieu.ForeColor = Color.Fuchsia;
            }
            if (ChooseCard.i == 10)
            {
                so1.Text = "41";
                so2.Text = "7";
                so3.Text = "16";
                so4.Text = "32";
                so5.Text = "66";
                so6.Text = "73";
                so7.Text = "18";
                so8.Text = "29";
                so9.Text = "46";
                so10.Text = "55";
                so11.Text = "88";
                so12.Text = "2";
                so13.Text = "23";
                so14.Text = "34";
                so15.Text = "50";
                so16.Text = "75";
                so17.Text = "4";
                so18.Text = "30";
                so19.Text = "40";
                so20.Text = "61";
                so21.Text = "78";
                so22.Text = "10";
                so23.Text = "27";
                so24.Text = "9";
                so25.Text = "3";
                pnPhieu.ForeColor = Color.Fuchsia;
            }
        }

        private void so1_BackColorChanged(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
           
            int i = 0;
            while(i < 89)
            {
                if (bt.Text == check[i])
                {
                    bt.Enabled = false;
                    bt.BackColor = Color.Cyan;
                }    
                   
                i++;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("BẠN MUỐN THOÁT?", "CẢNH BÁO",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }

        private void listContains_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
