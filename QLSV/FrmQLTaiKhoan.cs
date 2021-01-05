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
    public partial class FrmQLTaiKhoan : Form
    {
        public FrmQLTaiKhoan()
        {
            InitializeComponent();
        }
        static String trangthai = "";
        static String Lop= "";
        static String khoa = "";

        private void FrmQLTaiKhoan_Load(object sender, EventArgs e)
        {
            KhoaDT khoa = new KhoaDT();
            DataSet ds3 = new DataSet();
            ds3 = khoa.Loadkhoa();
            cbboxLocKhoa.DataSource = ds3.Tables[0];
            cbboxLocKhoa.DisplayMember = "Tenkhoa";
            cbboxLocKhoa.ValueMember = "Makhoa";

            txttendangnhap.MaxLength = 15;
            txtmatkhau.MaxLength = 15;
            txtNhapLaiMK.MaxLength = 15;
            txthoten.MaxLength = 30;

            txtReMKGV.MaxLength = 15;
            txtReMKSV.MaxLength = 15;
            txtMKSV.MaxLength = 15;
            txtMKGV.MaxLength = 15;




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

        private void cbboxkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbboxlop_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbboxHoten_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btncapnhattaikhoan_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            if(cbboxloaitaikhoan.Text=="")
            {
                MessageBox.Show("Hãy Chọn Loại Tài Khoản Hiển Thị");
            }
            else
            {
                dataGridView1.DataSource = a.taikhoan(cbboxloaitaikhoan.Text);
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[5, i] = linkCell;
                }
                
            }
        }

        private void btnThemTKQL_Click(object sender, EventArgs e)
        {
            if (txttendangnhap.Text == "" || txtmatkhau.Text == "" || txtNhapLaiMK.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ User và Pass/Nhập Lại Pass");
            }
            else
            {
                if (txtNhapLaiMK.Text == txtmatkhau.Text)
                {
                    Admin a = new Admin();
                    if (a.check(txttendangnhap.Text) == true)
                    {
                        String c = GetMD5(txtmatkhau.Text);
                        a.addadmin(txthoten.Text, txttendangnhap.Text, c, "Quản Lý");
                        MessageBox.Show("Tạo Tài Khoản Thành Công");
                        dataGridView1.DataSource = a.taikhoan("Quản Lý");
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                            dataGridView1[5, i] = linkCell;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại User này");
                    }
                }
                else
                {
                    MessageBox.Show("Password nhập lại ko đúng, vui lòng kiểm tra lại");
                }
            }
        }

        private void btThemTKSV_Click(object sender, EventArgs e)
        {
            if (txtMSV.Text=="")
            {
                MessageBox.Show("Vui lòng Chọn SV,điền đầy đủ User và Pass/Nhập Lại Pass");
            }
            else
            {

                if (txtMKSV.Text==txtReMKSV.Text)
                {
                    GiangVien b = new GiangVien();
                    Admin a = new Admin();
                    if (a.check(txtMSV.Text) == true)
                    {
                        a.addadmin(txtHoTenSV.Text, txtMSV.Text, GetMD5(txtMKSV.Text), "Sinh Viên");
                        MessageBox.Show("Tạo Tài Khoản Thành Công");
                        dataGridView1.DataSource = a.taikhoan("Sinh Viên");
                        if(trangthai=="Sinh Viên")
                        {
                            dataGridView2.DataSource = b.DanhSachTatCaSVThemTaiKhoan(Lop);
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                                dataGridView1[5, i] = linkCell;
                            }

                        }
                        else if(trangthai=="Giảng Viên")
                        {
                            dataGridView2.DataSource = b.DanhSachTatCaGVThemTaiKhoan(khoa);
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                                dataGridView1[5, i] = linkCell;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại User này");
                    }
                }
                else
                {
                    MessageBox.Show("Password nhập lại ko đúng, vui lòng kiểm tra lại");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {

            }
            else
            {
                if (e.ColumnIndex == 5)
                {
                    Admin a = new Admin();
                    string Task = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (Task == "Delete")
                    {
                        if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            String ID = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                            a.XoaTaiKhoan(ID);
                            dataGridView1.DataSource = a.taikhoan(cbboxloaitaikhoan.Text);
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                                dataGridView1[5, i] = linkCell;
                            }
                        }
                    }
                }
         
            }
        }

        private void cbboxKhoaGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbboxHotenGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThemTKGV_Click(object sender, EventArgs e)
        {
            if (txtMGV.Text == "")
            {
                MessageBox.Show("Vui lòng Chọn SV,điền đầy đủ User và Pass/Nhập Lại Pass");
            }
            else
            {

                if (txtMKGV.Text == txtReMKGV.Text)
                {
                    GiangVien b = new GiangVien();
                    Admin a = new Admin();
                    if (a.check(txtMGV.Text) == true)
                    {
                        a.addadmin(txtHoTenGV.Text, txtMGV.Text, GetMD5(txtMKGV.Text), "Giảng Viên");
                        MessageBox.Show("Tạo Tài Khoản Thành Công");
                        dataGridView1.DataSource = a.taikhoan("Giảng Viên");
                        if (trangthai == "Sinh Viên")
                        {
                            dataGridView2.DataSource = b.DanhSachTatCaSVThemTaiKhoan(Lop);
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                                dataGridView1[5, i] = linkCell;
                            }
                        }
                        else if (trangthai == "Giảng Viên")
                        {
                            dataGridView2.DataSource = b.DanhSachTatCaGVThemTaiKhoan(khoa);
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                                dataGridView1[5, i] = linkCell;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã tồn tại User này");
                    }
                }
                else
                {
                    MessageBox.Show("Password nhập lại ko đúng, vui lòng kiểm tra lại");
                }
            }
        }

        private void cbboxLocKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxLocKhoa.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                Lop dc = new Lop();
                DataSet ds = new DataSet();
                ds = dc.LoadLopselect(t);
                cbboxLocLop.DataSource = ds.Tables[0];
                cbboxLocLop.DisplayMember = "Tenlop";
                cbboxLocLop.ValueMember = "Malop";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GiangVien a = new GiangVien();
            if(radioButtonSinhVien.Checked)
            {
                if(cbboxLocLop.Text=="")
                {
                    MessageBox.Show("Vui lòng chọn lớp để lọc sinh viên");
                }
                else
                {
                    dataGridView2.DataSource = a.DanhSachTatCaSVThemTaiKhoan(cbboxLocLop.SelectedValue.ToString());
                    trangthai = "Sinh Viên";
                    Lop = cbboxLocLop.SelectedValue.ToString();
                }
            }
            else if(radioButtonGV.Checked)
            {
                dataGridView2.DataSource = a.DanhSachTatCaGVThemTaiKhoan(cbboxLocKhoa.SelectedValue.ToString());
                trangthai = "Giảng Viên";
                khoa = cbboxLocKhoa.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Bạn Cần Chọn Sinh Viên Hoặc Giảng Viên trước Khi Cập Nhật Danh Sách");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView2.Rows.Count==0)
            {

            }
            else
            {
                if(trangthai=="Sinh Viên")
                {
                    txtMSV.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    txtHoTenSV.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                }
                else if(trangthai=="Giảng Viên")
                {
                    txtMGV.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    txtHoTenGV.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                }
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView2.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
