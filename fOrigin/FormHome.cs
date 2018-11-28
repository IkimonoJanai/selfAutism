using DemoQuanLyThuVien.fOrigin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoQuanLyThuVien
{
    public partial class FormHome : Form
    {
        private Account loginAccountUser;
        private int btnHeight05 = 50;
        private int btnHeight075 = 75;
        private int btnWidth05 = 350;
        private int btnWidth075 = 525;
        private bool isCollapsed = true;
        private int btn8 = 0;
        public Account LoginAccountUser
        {
            get { return loginAccountUser; }
            set { loginAccountUser = value; ChangeAccount(loginAccountUser.Type); }
        }

        //ChangeAccount(loginAccountUser.Type);

        public FormHome(Account acc)
        {
            InitializeComponent();
            this.LoginAccountUser = acc;
            button8.Height = btn8;

        }

        private void Main_Load(object sender, EventArgs e)
        {
            string str = "Welcome to Sài gòn 3/// 2020!!!";
            label1.Text = str;
            
        }
        private void timerRunText_Tick(object sender, EventArgs e)
        {

        }
        #region Method
        #endregion

        #region Property
        #endregion

        #region Events
        private void readMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This product belong to our work , please ask before show it in public!!!");
        }
        private void picBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mnAdminHause_Click(object sender, EventArgs e)
        {
            FormAdmin fA = new FormAdmin();
            this.Hide();
            fA.ShowDialog();
            this.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển");
        }
        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển");
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.button1.Height = btnHeight075;
            this.button1.Width = btnWidth075;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.Height = btnHeight05;
            this.button1.Width = btnWidth05;
        }
        private void btnAd1_MouseEnter(object sender, EventArgs e)
        {
            this.btnAd1.Height = btnHeight075;
            this.btnAd1.Width = btnWidth075;
        }
        private void btnAd1_MouseLeave(object sender, EventArgs e)
        {
            this.btnAd1.Height = btnHeight05;
            this.btnAd1.Width = btnWidth05;
        }
        private void btnAd2_MouseEnter(object sender, EventArgs e)
        {
            this.btnAd2.Height = btnHeight075;
            this.btnAd2.Width = btnWidth075;
        }
        private void btnAd2_MouseLeave(object sender, EventArgs e)
        {
            this.btnAd2.Height = btnHeight05;
            this.btnAd2.Width = btnWidth05;
        }
        #endregion 



        void ChangeAccount (int Type)
        {
            mnAdminHause.Enabled = Type == 1;
        }
        private int idSprite = 1;
        private void SpriteAnimation()
        {
            if(idSprite == 58)
           
                {
                    idSprite = 1;
                }
                picBack.ImageLocation = string.Format(@"Sprite\{0}.png", idSprite);
                idSprite++;
            
        
        }

        private void timerBack_Tick(object sender, EventArgs e)
        {
            SpriteAnimation();
        }

        private void timerCollapse_Tick(object sender, EventArgs e)
        {          
            if(isCollapsed)
            {
                pnDropDown.Height += 10;
                button8.Height += 20;
                if (pnDropDown.Height >= pnDropDown.MaximumSize.Height)
                {
                    timerCollapse.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                pnDropDown.Height -= 10;
                button8.Height -= 20;
                if (pnDropDown.Height <= pnDropDown.MinimumSize.Height)
                {
                    timerCollapse.Stop();
                    isCollapsed = true;
                }
            }
        }
        private void btnDropdown_Click(object sender, EventArgs e)
        {
            timerCollapse.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fRentBook fRB = new fRentBook();
            this.Hide();
            fRB.ShowDialog();
            this.Show();
        }

        private void btnAd1_Click(object sender, EventArgs e)
        {
            Advertiment ad = new Advertiment();
            ad.Show();
        }

        private void btnAd2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này hiện đang đươc phát triển");
        }







        







        //#region Property
        //#endregion
        //#region Method
        //#endregion
        //#region Events
        //#endregion


    }
}
