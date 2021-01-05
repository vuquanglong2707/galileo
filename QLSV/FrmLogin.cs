using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonN6
{
    
    public partial class FrmLogin : Form
    {
        public SendMessage send;
        public FrmLogin()
        {
            InitializeComponent();
        }
        public FrmLogin(SendMessage sender)
        {
            InitializeComponent();
            this.send = sender;
        }


        private String GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Bạn không thể thực hiện quyền này");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.TextLength == 0 && txtPassword.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập User và Password");
                this.txtUsername.Focus();
                
            }
            else if (txtUsername.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập User");
                this.txtUsername.Focus();
            }
            else if (txtPassword.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập Password");
                this.txtPassword.Focus();
            }
            else
            {
                Admin a = new Admin();
                if (a.checklog(txtUsername.Text, GetMD5(txtPassword.Text)) == true)
                {
                    String str= a.Quyenhan(txtUsername.Text, GetMD5(txtPassword.Text));
                    this.send(txtUsername.Text,str);
                    this.Close();
                }
                else if(a.checktentk(txtUsername.Text)==true)
                {
                    MessageBox.Show("Sai password");
                }
                else if(a.checkpass(GetMD5(txtPassword.Text))==true)
                {
                    MessageBox.Show("Sai Username");
                }
                else
                {
                    MessageBox.Show("Tài Khoản Không Tồn Tại !!");
                }
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.MaxLength = 15;
            txtPassword.MaxLength = 15;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
