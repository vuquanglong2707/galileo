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
    
    public partial class FrmSuaDiemRL : Form
    {
        private String Masodiem;
        private String MSV;
        private String Hoten;
        private String Lop;
        private String Namhoc;
        private String Hocky;
        private String tongdiem;

        public FrmSuaDiemRL()
        {
            InitializeComponent();
        }
        public FrmSuaDiemRL(String Masodiem,String MSV,String Hoten,String lop,String namhoc,String hocky,String tongdiem)
        {
            
            InitializeComponent();
            this.Masodiem = Masodiem;
            this.MSV = MSV;
            this.Hoten = Hoten;
            this.Lop = lop;
            this.Namhoc = namhoc;
            this.Hocky = hocky;
            this.tongdiem = tongdiem;
        }

        private void FrmSuaDiemRL_Load(object sender, EventArgs e)
        {
            txtTongDiemRL.MaxLength = 3;
            MaximizeBox = false;
            txtMadiem.Text = this.Masodiem;
            txtHoten.Text = this.Hoten;
            txtMSV.Text = this.MSV;
            txtLop.Text = this.Lop;
            txtNamHoc.Text = this.Namhoc;
            if(this.Hocky=="Học Kỳ I")
            {
                radioButtonHK1.Checked=true;
                radioButtonHK1.Text = "Học Kỳ I";
            }
            else
            {
                radioButtonHK1.Checked = true;
                radioButtonHK1.Text = "Học Kỳ II";
            }
            txtTongDiemRL.Text = this.tongdiem;
        }
        public int DiemHocKy(String HocKy, String NamHoc, String MSV)
        {
            int Diem;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "SELECT Tongdiem FROM DiemRL where MSVien=@msv and Namhoc=@namhoc and Hocky=@hocky";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@msv", MSV));
                cmd.Parameters.Add(new SqlParameter("@namhoc", NamHoc));
                cmd.Parameters.Add(new SqlParameter("@hocky", HocKy));
                Diem = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return Diem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Xác Nhận Chỉnh Sửa?", "Edit Liền Là Edit Liền", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                if (txtTongDiemRL.Text == "")
                {
                    MessageBox.Show("Trống điểm RL");
                }
                else
                {
                    int tongdiem = int.Parse(txtTongDiemRL.Text);
                    String xeploai;
                    String xeploai2;
                    if (tongdiem >= 90)
                    {
                        xeploai = "Xuất Sắc";
                    }
                    else if (tongdiem >= 80 && tongdiem < 90)
                    {
                        xeploai = "Tốt";
                    }
                    else if (tongdiem >= 70 && tongdiem < 80)
                    {
                        xeploai = "Khá";
                    }
                    else
                    {
                        xeploai = "Trung Bình";
                    }
                    Sinhvien a = new Sinhvien();
                    a.ExecuteNonQuery("update DiemRL set Tongdiem=" + int.Parse(txtTongDiemRL.Text) + ",Xeploai=N'"+xeploai+ "' where Masodiem = " + int.Parse(txtMadiem.Text));
                    MessageBox.Show("Cập nhật thành công");
                    
                    int Diem1 = DiemHocKy("Học Kỳ I", txtNamHoc.Text, txtMSV.Text);
                    int Diem2 = DiemHocKy("Học Kỳ II", txtNamHoc.Text, txtMSV.Text);
                    double dtk = ((double)Diem1 + (double)Diem2) / (double)2;
                    int DiemCaNam = (int)Math.Ceiling(dtk);
                    if (DiemCaNam >= 90)
                    {
                        xeploai2 = "Xuất Sắc";
                    }
                    else if (DiemCaNam >= 80 && DiemCaNam < 90)
                    {
                        xeploai2 = "Tốt";
                    }
                    else if (DiemCaNam >= 70 && DiemCaNam < 80)
                    {
                        xeploai2 = "Khá";
                    }
                    else
                    {
                        xeploai2 = "Trung Bình";
                    }
                    a.ExecuteNonQuery("update DiemRL set Tongdiem=" + DiemCaNam + ",Xeploai=N'" + xeploai2 + "' where MSVien = " + txtMSV.Text+" and Namhoc=N'"+txtNamHoc.Text+"' and Hocky=N'Cả Năm'" );
                    this.Close();
                }
            }
        }

        private void txtTongDiemRL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTongDiemRL_TextChanged(object sender, EventArgs e)
        {
            if (txtTongDiemRL.Text == "") { }
            else
            {
                if (int.Parse(txtTongDiemRL.Text) > 100)
                {
                    txtTongDiemRL.Text = "100";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Xác Nhận Xóa?", "Bạn Chắc Chắn Muốn Xóa Chứ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                Sinhvien a = new Sinhvien();
                Lop b = new Lop();
                a.ExecuteNonQuery("delete from DiemRL where Masodiem=" + int.Parse(txtMadiem.Text));
                MessageBox.Show("Xóa Thành Công");
                a.ExecuteNonQuery("delete from DiemRL where MSVien=" + txtMSV.Text + " and Namhoc=N'" + txtNamHoc.Text + "' and Hocky=N'Cả Năm'");
                this.Close();
            }
        }
    }
}
