using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonN6
{
    public partial class FrmQLGiangVien : Form
    {
        private String magiangvien;
        private String quyenhan;
        public FrmQLGiangVien(String user,String quyen)
        {
            InitializeComponent();
            this.magiangvien = user;
            this.quyenhan = quyen;
        }
        Boolean click = false;
        static String Trangthai = "";
        static String imgLoc = "";
        static String trangthai1="";
        static String TimKiem = "";
        private void FrmQLGiangVien_Load(object sender, EventArgs e)
        {
            cbboxchonkhoa.Enabled = false;
            btnCanCel.Enabled = false;
            btnOK.Enabled = false;
            btnchonhinh.Enabled = false;
            btnOK.ForeColor = Color.FromArgb(250, 254, 252);
            btnCanCel.ForeColor = Color.FromArgb(250, 254, 252);


            KhoaDT khoa = new KhoaDT();
            DataSet ds1 = new DataSet();
            ds1 = khoa.Loadkhoa();
            cbboxKhoa.DataSource = ds1.Tables[0];
            cbboxKhoa.DisplayMember = "Tenkhoa";
            cbboxKhoa.ValueMember = "Makhoa";

            DataSet ds2 = new DataSet();
            ds2 = khoa.Loadkhoa();
            cbboxchonkhoa.DataSource = ds2.Tables[0];
            cbboxchonkhoa.DisplayMember = "Tenkhoa";
            cbboxchonkhoa.ValueMember = "Makhoa";
            if(quyenhan=="Giảng Viên")
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                groupBox6.Enabled = false;
                dataGridView1.Enabled = false;
                try
                {
                    using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
                    {
                        con.Open();
                        String sql = "select MGV,AnhHoSo,Hoten,GioiTinh,NgaySinh,SDT,CMND,Email,ChuyenMon,TenKhoa from GiangVien, Khoa where GiangVien.Khoa = Khoa.Makhoa and GiangVien.MGV = '"+magiangvien+"'";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            // get the results of each column
                            if (rdr["AnhHoSo"].ToString() != "")
                            {
                                byte[] img = (byte[])(rdr["AnhHoSo"]);
                                if (img == null)
                                    picsGV.Image = null;
                                else
                                {
                                    MemoryStream ms = new MemoryStream(img);
                                    picsGV.Image = Image.FromStream(ms);
                                }
                            }
                            txtMGV.Text = rdr["MGV"].ToString();
                            txtHoten.Text = (string)rdr["Hoten"];
                            dateTimePicker1.Text = rdr["NgaySinh"].ToString();
                            cbboxGioitinh.Text = rdr["GioiTinh"].ToString();
                            txtSDT.Text= rdr["SDT"].ToString();
                            txtCMND.Text = rdr["CMND"].ToString();
                            txtEmail.Text = rdr["Email"].ToString();
                            txtChuyenMon.Text = rdr["ChuyenMon"].ToString();
                            cbboxKhoa.Text = rdr["TenKhoa"].ToString();

                        }
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMGV.Enabled = true;
            Trangthai = "Thêm";
            btnThemMoi.BackColor = System.Drawing.Color.Red;
            btnSua.BackColor = Color.FromArgb(151, 227, 227);
            btnXoa.BackColor = Color.FromArgb(151, 227, 227);
            lblThongBao.Text = "Bạn Đang Chọn Chức Năng Thêm";
            btnCanCel.Enabled = true;
            btnOK.Enabled = true;
            btnOK.ForeColor = Color.FromArgb(0,0,0);
            btnCanCel.ForeColor = Color.FromArgb(0,0,0);
            picsGV.Image = null;
            imgLoc = "";
            picsGV.ImageLocation = null;
            btnchonhinh.Enabled = true;
            txtChuyenMon.Clear();
            txtCMND.Clear();
            txtEmail.Clear();
            txtHoten.Clear();
            txtMGV.Clear();
            txtSDT.Clear();
            txtTimKiem.Clear();

            btnThemMoi.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = "Sửa";
            txtMGV.Enabled = false;
            btnSua.BackColor = System.Drawing.Color.Red;
            btnThemMoi.BackColor = Color.FromArgb(151, 227, 227);
            btnXoa.BackColor = Color.FromArgb(151, 227, 227);

            lblThongBao.Text = "Bạn Đang Chọn Chức Năng Sửa";
            btnCanCel.Enabled = true;
            btnOK.Enabled = true;
            btnOK.ForeColor = Color.FromArgb(0, 0, 0);
            btnCanCel.ForeColor = Color.FromArgb(0, 0, 0);
            btnchonhinh.Enabled = true;

            btnSua.Enabled = false;
            btnThemMoi.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMGV.Enabled = false;
            Trangthai = "Xóa";
            btnXoa.BackColor = System.Drawing.Color.Red;
            btnThemMoi.BackColor = Color.FromArgb(151, 227, 227);
            btnSua.BackColor = Color.FromArgb(151, 227, 227);
            lblThongBao.Text = "Bạn Đang Chọn Chức Năng Xóa";
            btnCanCel.Enabled = true;
            btnOK.Enabled = true;
            btnOK.ForeColor = Color.FromArgb(0, 0, 0);
            btnCanCel.ForeColor = Color.FromArgb(0, 0, 0);
            btnXoa.Enabled = false;
            btnSua.Enabled = true;
            btnThemMoi.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            KhoaDT b = new KhoaDT();
            GiangVien a = new GiangVien();
            if (Trangthai == "Thêm")
            {
                if (txtMGV.Text =="" || txtHoten.Text == "" || txtCMND.Text == "" || cbboxKhoa.Text == "")
                {
                    MessageBox.Show("Hãy Điền Đầy Đủ Thông Tin Cần Thiết");

                }
                else
                {
                    if (a.checkMGV(txtMGV.Text) == true)
                    {
                        if (a.checkCMDN(txtCMND.Text) == true)
                        {
                            if (imgLoc == "")
                            {
                                try
                                {
                                    a.AddGiangVienKoAnhHS(txtMGV.Text, txtHoten.Text, cbboxGioitinh.Text, dateTimePicker1.Text, txtSDT.Text, txtCMND.Text, txtEmail.Text, txtChuyenMon.Text, b.Makhoa(cbboxKhoa.Text));
                                    MessageBox.Show("Thêm Thành Công");
                                    imgLoc = "";
                                    picsGV.ImageLocation = null;
                                    picsGV.Image = null;
                                    btnchonhinh.Enabled = false;
                                    txtChuyenMon.Clear();
                                    txtCMND.Clear();
                                    txtEmail.Clear();
                                    txtHoten.Clear();
                                    txtMGV.Clear();
                                    txtSDT.Clear();
                                    txtTimKiem.Clear();
                                    Trangthai = "";
                                    btnThemMoi.BackColor = Color.FromArgb(151, 227, 227);
                                    btnThemMoi.Enabled = true;
                                    btnCanCel.Enabled = false;
                                    btnOK.Enabled = false;
                                    btnOK.ForeColor = Color.FromArgb(250, 254, 252);
                                    btnCanCel.ForeColor = Color.FromArgb(250, 254, 252);
                                    lblThongBao.Text = "Here";
                                    btnchonhinh.Enabled = false;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                try
                                {
                                    byte[] img = null;
                                    FileStream fs = new System.IO.FileStream(imgLoc, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                    BinaryReader br = new BinaryReader(fs); //Doc nhi phan
                                    img = br.ReadBytes((int)fs.Length);
                                    a.AddGiangVienAnhHS(txtMGV.Text, img, txtHoten.Text, cbboxGioitinh.Text, dateTimePicker1.Text, txtSDT.Text, txtCMND.Text, txtEmail.Text, txtChuyenMon.Text, b.Makhoa(cbboxKhoa.Text));
                                    MessageBox.Show("Thêm Thành Công");
                                    imgLoc = "";
                                    picsGV.ImageLocation = null;
                                    picsGV.Image = null;
                                    btnchonhinh.Enabled = false;
                                    txtChuyenMon.Clear();
                                    txtCMND.Clear();
                                    txtEmail.Clear();
                                    txtHoten.Clear();
                                    txtMGV.Clear();
                                    txtSDT.Clear();
                                    txtTimKiem.Clear();
                                    Trangthai = "";
                                    btnThemMoi.BackColor = Color.FromArgb(151, 227, 227);
                                    btnThemMoi.Enabled = true;
                                    btnCanCel.Enabled = false;
                                    btnOK.Enabled = false;
                                    btnOK.ForeColor = Color.FromArgb(250, 254, 252);
                                    btnCanCel.ForeColor = Color.FromArgb(250, 254, 252);
                                    lblThongBao.Text = "Here";
                                    btnchonhinh.Enabled = false;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Có vẻ Như Đã Có Giảng Viên Có Sử Dụng CMND này");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Có vẻ Như Đã Có Giảng Viên Có Sử Dụng MGV Này");
                    }
                }
            }
            else if(Trangthai=="Sửa")
            {
                if(txtMGV.Text != "")
                {
                   if(a.checkCMDNsuaGV(txtCMND.Text,txtMGV.Text)==true)
                    {
                        if(imgLoc=="")
                        {
                            a.updateGiangVienKoANHHS(txtMGV.Text, txtHoten.Text, cbboxGioitinh.Text, dateTimePicker1.Text, txtSDT.Text, txtCMND.Text, txtEmail.Text, txtChuyenMon.Text, b.Makhoa(cbboxKhoa.Text));
                            imgLoc = "";
                            picsGV.ImageLocation = null;
                            picsGV.Image = null;
                            btnchonhinh.Enabled = false;
                            txtChuyenMon.Clear();
                            txtCMND.Clear();
                            txtEmail.Clear();
                            txtHoten.Clear();
                            txtMGV.Clear();
                            txtSDT.Clear();
                            txtTimKiem.Clear();
                            Trangthai = "";
                            btnSua.BackColor = Color.FromArgb(151, 227, 227);
                            btnSua.Enabled = true;
                            btnCanCel.Enabled = false;
                            btnOK.Enabled = false;
                            btnOK.ForeColor = Color.FromArgb(250, 254, 252);
                            btnCanCel.ForeColor = Color.FromArgb(250, 254, 252);
                            lblThongBao.Text = "Here";
                            btnchonhinh.Enabled = false;
                            MessageBox.Show("Done :)");
                        }
                        else
                        {
                            byte[] img = null;
                            FileStream fs = new System.IO.FileStream(imgLoc, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            BinaryReader br = new BinaryReader(fs);
                            img = br.ReadBytes((int)fs.Length);
                            a.updateGiangVienANHHS(txtMGV.Text,img, txtHoten.Text, cbboxGioitinh.Text, dateTimePicker1.Text, txtSDT.Text, txtCMND.Text, txtEmail.Text, txtChuyenMon.Text, b.Makhoa(cbboxKhoa.Text));
                            imgLoc = "";
                            picsGV.ImageLocation = null;
                            picsGV.Image = null;
                            btnchonhinh.Enabled = false;
                            txtChuyenMon.Clear();
                            txtCMND.Clear();
                            txtEmail.Clear();
                            txtHoten.Clear();
                            txtMGV.Clear();
                            txtSDT.Clear();
                            txtTimKiem.Clear();
                            Trangthai = "";
                            btnSua.BackColor = Color.FromArgb(151, 227, 227);
                            btnSua.Enabled = true;
                            btnCanCel.Enabled = false;
                            btnOK.Enabled = false;
                            btnOK.ForeColor = Color.FromArgb(250, 254, 252);
                            btnCanCel.ForeColor = Color.FromArgb(250, 254, 252);
                            lblThongBao.Text = "Here";
                            btnchonhinh.Enabled = false;
                            MessageBox.Show("Done :)");
                        }
                    }
                   else
                    {
                        MessageBox.Show("Tồn Tại GV Có CMND Này");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đối tượng");
                }
            }
            else if(Trangthai=="Xóa")
            {
                if (txtMGV.Text != "")
                {
                    
                    a.ExecuteNonQuery("Delete from GiangVien where MGV=N'" + txtMGV.Text+"'");
                    MessageBox.Show("Xóa thành công");
                    //dataGridView1.DataSource = a.Load(b.Malop(cbboxchonlop.Text));
                    imgLoc = "";
                    picsGV.ImageLocation = null;
                    picsGV.Image = null;
                    btnchonhinh.Enabled = true;
                    txtChuyenMon.Clear();
                    txtCMND.Clear();
                    txtEmail.Clear();
                    txtHoten.Clear();
                    txtMGV.Clear();
                    txtSDT.Clear();
                    txtTimKiem.Clear();
                    Trangthai = "";
                    /*
                    btnThemMoi.BackColor = Color.FromArgb(151, 227, 227);
                    btnThemMoi.Enabled = true;
                    */
                    lblThongBao.Text = "Here";
                    if (trangthai1 == "K") 
                        {
                            dataGridView1.DataSource = a.getTable("select MGV,AnhHoSo,HoTen,GioiTinh,NgaySinh,CMND,SDT,Email,ChuyenMon,TenKhoa from GiangVien,Khoa where GiangVien.Khoa=Khoa.MaKhoa and Khoa.Makhoa="+b.Makhoa(cbboxchonkhoa.Text));
                        }
                    else if (trangthai1 == "TK" && TimKiem != "")
                        {
                            dataGridView1.DataSource = a.SearchMGV(RemoveVietnameseTone(TimKiem).Trim());
                            if (dataGridView1.Rows.Count == 0)
                            {
                                dataGridView1.DataSource = a.SearchHoTenGV(RemoveVietnameseTone(TimKiem).Trim());
                            }
                        }
                    else if (trangthai1 == "All")
                        {
                            dataGridView1.DataSource = a.getTable("select MGV,AnhHoSo,HoTen,GioiTinh,NgaySinh,CMND,SDT,Email,ChuyenMon,TenKhoa from GiangVien inner join Khoa on GiangVien.Khoa=Khoa.Makhoa");
                        }
                    else
                        {

                        }
                    Trangthai = "";
                    btnXoa.BackColor = Color.FromArgb(151, 227, 227);
                    btnXoa.Enabled = true;
                    btnCanCel.Enabled = false;
                    btnOK.Enabled = false;
                    btnchonhinh.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn đối tượng");
                }
            }
            else
            {

            }
        }

        private void btnCanCel_Click(object sender, EventArgs e)
        {
            btnThemMoi.BackColor = Color.FromArgb(151, 227, 227);
            btnXoa.BackColor = Color.FromArgb(151, 227, 227);
            btnSua.BackColor = Color.FromArgb(151, 227, 227);
            Trangthai = "";
            lblThongBao.Text = "Here";
            btnCanCel.Enabled = false;
            btnOK.Enabled = false;
            btnOK.ForeColor = Color.FromArgb(250, 254, 252);
            btnCanCel.ForeColor = Color.FromArgb(250, 254, 252);
            btnThemMoi.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnchonhinh.Enabled = false;
        }

        private void btnchonhinh_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
                dlg.Title = "Select Student Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    picsGV.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadDSGV_Click(object sender, EventArgs e)
        {
            GiangVien a = new GiangVien();
            KhoaDT b = new KhoaDT();
            if (radioButtonTatCa.Checked)
            {
                dataGridView1.DataSource = a.getTable("select MGV,AnhHoSo,HoTen,GioiTinh,NgaySinh,CMND,SDT,Email,ChuyenMon,TenKhoa from GiangVien inner join Khoa on GiangVien.Khoa=Khoa.Makhoa");
                click = true;
                trangthai1 = "All";
            }
            else if (radioButtonTheoKhoa.Checked)
            {
                if (cbboxchonkhoa.Text != "")
                {
                    dataGridView1.DataSource = a.getTable("select MGV,AnhHoSo,HoTen,GioiTinh,NgaySinh,CMND,SDT,Email,ChuyenMon,TenKhoa from GiangVien inner join Khoa on GiangVien.Khoa=Khoa.Makhoa where GiangVien.Khoa=" + b.Makhoa(cbboxchonkhoa.Text));
                    click = true;
                    trangthai1 = "K";
                }
                else
                {
                    MessageBox.Show("Chọn Khoa");
                }
            }
            else
            {
                MessageBox.Show("Lựa Chọn");
            }
        }

        private void radioButtonTatCa_CheckedChanged(object sender, EventArgs e)
        {
            cbboxchonkhoa.Enabled = false;
        }

        private void radioButtonTheoKhoa_CheckedChanged(object sender, EventArgs e)
        {
            cbboxchonkhoa.Enabled = true;
        }

        private void cbboxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(click==true)
            {
                if (dataGridView1.Rows.Count == 0)
                {

                }
                else
                {
                    txtMGV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtHoten.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    dataGridView1.CurrentRow.Selected = true;
                    imgLoc = "";
                    if (dataGridView1.CurrentRow.Cells[1].Value.ToString() != "")
                    {
                        byte[] img = (byte[])(dataGridView1.CurrentRow.Cells[1].Value);
                        if (img == null)
                            picsGV.Image = null;
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            picsGV.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        picsGV.Image = null;
                    }
                    dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    cbboxGioitinh.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    txtSDT.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    txtCMND.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    txtEmail.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    txtChuyenMon.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    cbboxKhoa.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                }

            }
        }
        public static string RemoveVietnameseTone(string text)
        {
            string result = text.ToLower();
            result = Regex.Replace(result, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
            result = Regex.Replace(result, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|/g", "e");
            result = Regex.Replace(result, "ì|í|ị|ỉ|ĩ|/g", "i");
            result = Regex.Replace(result, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|/g", "o");
            result = Regex.Replace(result, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
            result = Regex.Replace(result, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
            result = Regex.Replace(result, "đ", "d");
            return result;
        }

        private void btTimGV_Click(object sender, EventArgs e)
        {
            click = true;
            trangthai1 = "TK";
            GiangVien a = new GiangVien();
            if (txtTimKiem.Text != "")
            {
                 dataGridView1.DataSource = a.SearchHoTenGV(RemoveVietnameseTone(txtTimKiem.Text).Trim());
                 if (dataGridView1.Rows.Count == 0)
                 {
                    dataGridView1.DataSource = a.SearchMGV(RemoveVietnameseTone(txtTimKiem.Text).Trim());
                    if(dataGridView1.Rows.Count==0)
                    {
                        MessageBox.Show("Không Tìm Thấy :<");
                    }
                 }
                 TimKiem = txtTimKiem.Text;
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập gì :<");
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
