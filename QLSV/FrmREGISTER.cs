using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonN6
{
    public partial class FrmREGISTER : Form
    {
        private String _name;
        public FrmREGISTER(String user)
        {
            InitializeComponent();
            _name = user;
        }

        private void FrmREGISTER_Load(object sender, EventArgs e)
        {
            txtMatKhauCu.MaxLength = 15;
            txtmatkhaumoi.MaxLength = 15;
            txtNhapLaiMKmoi.MaxLength = 15;
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
        private void changepassword(String user,String pass)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHANGE_PASS";
                cmd.Parameters.Add(new SqlParameter("@username", user));
                cmd.Parameters.Add(new SqlParameter("@password", pass));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            Admin a= new Admin();
            if(txtMatKhauCu.Text=="" || txtmatkhaumoi.Text=="" || txtNhapLaiMKmoi.Text=="")
            {
                MessageBox.Show("Hãy Nhập Đầy Đủ");
            }
            else
            {
                if(a.checklog(_name,GetMD5(txtMatKhauCu.Text))==true) {
                    if(txtmatkhaumoi.Text==txtNhapLaiMKmoi.Text)
                    {
                        changepassword(_name, GetMD5(txtmatkhaumoi.Text));
                        MessageBox.Show("Đổi Mật Khẩu Thành Công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bạn nên xem lại. Nhập lại mật khẩu mới ko trùng khớp");
                    }
                }
                else
                {
                    MessageBox.Show("Password cũ không đúng");
                }
            }
        }
    }
}
