using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace BaiTapLonN6
{
    public partial class HoSoSinhVien : Form
    {
        static String imgLoc = "";
        SqlConnection con = new SqlConnection(ConnectionString.connectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        static int start;
        int page;
        static String trangthai="";
        static String TimKiem = "";
        static String Quyen = "";
        static String username = "";
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
        public HoSoSinhVien(String quyenhan,String user)
        {
            InitializeComponent();
            start = 0;
            page = 1;
            Quyen = quyenhan;
            username = user;
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public Boolean click = false;
        
        private void btThemSV_Click(object sender, EventArgs e)
        {
            FrmThemSV frm = new FrmThemSV();
            frm.ShowDialog();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            /*
            label4.ForeColor = ThemeColor.SecondaryColor;
            label5.ForeColor = ThemeColor.PrimaryColor;
            */
        }

        private void HoSoSinhVien_Load_1(object sender, EventArgs e)
        {

            txtCMND1.MaxLength = 11;
            txtSDT1.MaxLength = 11;
            txtHoten1.MaxLength = 40;

            //LoadTheme();
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Diachi dc = new Diachi();
            DataSet ds = new DataSet();
            ds = dc.Load();
            cbboxTinhThanhPho1.DataSource = ds.Tables[0];
            cbboxTinhThanhPho1.DisplayMember = "Tentinh";
            cbboxTinhThanhPho1.ValueMember = "Matinh";
            

            KhoaDT khoa = new KhoaDT();
            DataSet ds1 = new DataSet();
            ds1 = khoa.Loadkhoa();
            cbboxKhoa1.DataSource = ds1.Tables[0];
            cbboxKhoa1.DisplayMember = "Tenkhoa";
            cbboxKhoa1.ValueMember = "Makhoa";


            KhoaDT khoa1 = new KhoaDT();
            DataSet ds5 = new DataSet();
            ds5 = khoa1.Loadkhoa();
            cbboxchonkhoa.DataSource = ds5.Tables[0];
            cbboxchonkhoa.DisplayMember = "Tenkhoa";
            cbboxchonkhoa.ValueMember = "Makhoa";


            //
            Diachi dc1 = new Diachi();
            DataSet ds2 = new DataSet();
            ds2 = dc1.LoadHuyen1();
            cbboxQuanHuyen1.DataSource = ds2.Tables[0];
            cbboxQuanHuyen1.DisplayMember = "Tenhuyen";
            cbboxQuanHuyen1.ValueMember = "Mahuyen";
            //
            Diachi dc2 = new Diachi();
            DataSet ds3 = new DataSet();
            ds3 = dc2.LoadPhuong1();
            cbboxPhuongxa1.DataSource = ds3.Tables[0];
            cbboxPhuongxa1.DisplayMember = "Tenxa";
            cbboxPhuongxa1.ValueMember = "Maxa";
            //

            Lop lop = new Lop();
            DataSet ds4 = new DataSet();
            ds4 = lop.LoadLop1();
            cbboxLop1.DataSource = ds4.Tables[0];
            cbboxLop1.DisplayMember = "Tenlop";
            cbboxLop1.ValueMember = "Malop";
            //
            /*
            Lop lop1 = new Lop();
            DataSet ds6 = new DataSet();
            ds6 = lop1.LoadLop1();
            cbboxchonlop.DataSource = ds6.Tables[0];
            cbboxchonlop.DisplayMember = "Tenlop";
            cbboxchonlop.ValueMember = "Malop";
            */

            txtTimKiem.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTimKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            getData2(DataCollection);
            txtTimKiem.AutoCompleteCustomSource = DataCollection;
            if(Quyen=="Sinh Viên")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
                    {
                        groupBox1.Visible = false;
                        groupBox2.Visible = false;
                        groupBox4.Visible = false;
                        dataGridView1.Visible = false;
                        groupBox3.Dock=DockStyle.Fill;

                        con.Open();
                        String sql = "select MSV,Hoten,AnhHoSo,Ngaysinh,Gioitinh,Dantoc,SDT,CMND,Email,Hedaotao,Hotenbo,Nghebo,Hotenme,Ngheme,TenTinh,Tenhuyen,Tenxa,Tenkhoa,Tenlop,Tinhtrang,NamnhapHoc from SinhVien, Lop, Khoa, Tinh, Huyen, Xa where SinhVien.Maxa=Xa.Maxa and Xa.Mahuyen=Huyen.Mahuyen and Huyen.Matinh=Tinh.Matinh and SinhVien.Malop=Lop.Malop and Lop.Makhoa=Khoa.Makhoa and SinhVien.MSV=" + username;
                        SqlCommand cmd = new SqlCommand(sql, con);
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            // get the results of each column
                            if (rdr["AnhHoSo"].ToString() != "")
                            {
                                byte[] img = (byte[])(rdr["AnhHoSo"]);
                                if (img == null)
                                    picstudent.Image = null;
                                else
                                {
                                    MemoryStream ms = new MemoryStream(img);
                                    picstudent.Image = Image.FromStream(ms);
                                }
                            }
                            txtMSV1.Text = rdr["MSV"].ToString();
                            txtHoten1.Text = (string)rdr["Hoten"];
                            dateTimePicker1.Text = rdr["Ngaysinh"].ToString();
                            cbboxGioitinh1.SelectedItem = (string)rdr["Gioitinh"];
                            cbboxDanToc1.SelectedItem = (string)rdr["Dantoc"];
                            txtSDT1.Text = (string)rdr["SDT"];
                            txtCMND1.Text = (string)rdr["CMND"];
                            txtEmail1.Text = (string)rdr["Email"];
                            cbboxHeDT1.SelectedItem = (string)rdr["Hedaotao"];
                            txtHotenBo1.Text = (string)rdr["Hotenbo"];
                            txtNghebo1.Text = (string)rdr["Nghebo"];
                            txtHotenme1.Text = (string)rdr["Hotenme"];
                            txtNgheme1.Text = (string)rdr["Ngheme"];
                            cbboxTinhThanhPho1.Text = (string)rdr["Tentinh"];
                            cbboxQuanHuyen1.Text = (string)rdr["Tenhuyen"];
                            cbboxPhuongxa1.Text = (string)rdr["Tenxa"];
                            cbboxKhoa1.Text = (string)rdr["Tenkhoa"];
                            cbboxLop1.Text = (string)rdr["Tenlop"];
                            cbboxTinhtrang1.Text = (string)rdr["TinhTrang"];
                            txtNamNhapHoc1.Text = rdr["Namnhaphoc"].ToString();
                        }
                        con.Close();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
                btLoadSV.Visible = false;
                btSuaSV.Visible = false;
                btThemSV.Visible = false;
                btXoaSV.Visible = false;
                btTimSV.Visible = false;
                button1.Enabled = false;
                button2.Enabled = false;
                dataGridView1.Enabled = false;
                txtCMND1.ReadOnly = true;
                txtHoten1.ReadOnly = true;
                txtEmail1.ReadOnly = true;
                txtHotenBo1.ReadOnly = true;
                txtHotenme1.ReadOnly = true;
                txtNamNhapHoc1.ReadOnly = true;
                txtNghebo1.ReadOnly = true;
                txtNgheme1.ReadOnly = true;
                txtSDT1.ReadOnly = true;
                txtTimKiem.Enabled = false;
                cbboxchonkhoa.Enabled = false;
                cbboxchonlop.Enabled = false;
                cbboxDanToc1.Enabled = false;
                cbboxGioitinh1.Enabled = false;
                cbboxKhoa1.Enabled = false;
                cbboxLop1.Enabled = false;
                cbboxPhuongxa1.Enabled = false;
                cbboxQuanHuyen1.Enabled = false;
                cbboxTinhThanhPho1.Enabled = false;
                cbboxHeDT1.Enabled = false;
                cbboxTinhtrang1.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
        }
        private void getData(AutoCompleteStringCollection dataCollection)
        {
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string sql = "SELECT DISTINCT [Hoten] FROM [SinhVien]";
            connection = new SqlConnection(ConnectionString.connectionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataCollection.Add(row[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }
        private void getData2(AutoCompleteStringCollection dataCollection)
        {
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            string sql = "SELECT DISTINCT [MSV] FROM [SinhVien]";
            connection = new SqlConnection(ConnectionString.connectionString); 
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataCollection.Add(row[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (click == true)
            {
                if (dataGridView1.Rows.Count == 0)
                {

                }
                else
                {
                    imgLoc = "";
                    Lop a = new Lop();
                    Diachi b = new Diachi();
                    txtMSV1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtHoten1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    dataGridView1.CurrentRow.Selected = true;
                    if (dataGridView1.CurrentRow.Cells[2].Value.ToString() != "")
                    {
                        byte[] img = (byte[])(dataGridView1.CurrentRow.Cells[2].Value);
                        if (img == null)
                            picstudent.Image = null;
                        else
                        {
                            MemoryStream ms = new MemoryStream(img);
                            picstudent.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        picstudent.Image = null;
                    }
                    dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    cbboxGioitinh1.SelectedItem = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    cbboxDanToc1.SelectedItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    txtSDT1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    txtCMND1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    txtEmail1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    cbboxHeDT1.SelectedItem = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    txtHotenBo1.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    txtNghebo1.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    txtHotenme1.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                    txtNgheme1.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                    cbboxTinhThanhPho1.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                    cbboxQuanHuyen1.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                    cbboxPhuongxa1.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
                    cbboxKhoa1.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                    cbboxLop1.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
                    cbboxTinhtrang1.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
                    txtNamNhapHoc1.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
                }
            }
        }

        private void btLoadSV_Click(object sender, EventArgs e)
        {
            if (cbboxchonlop.Text != "")
            {
                Sinhvien a = new Sinhvien();
                //dataGridView1.AutoResizeColumns();
                //dataGridView1.AutoResizeRows();
                start = 0;
                Lop b = new Lop();
                page = 1;
                lblPageNumber.Text = "Trang :" + page;
                lblPageMAx.Text = "";
                dataGridView1.DataSource = a.Load(b.Malop(cbboxchonlop.Text));
                click = true;
                btnback.Enabled = false;
                btnnext.Enabled = false;
                btnfullnext.Enabled = false;
                btnfullback.Enabled = false;
                trangthai = "L";
            }
            else
            {
                MessageBox.Show("Hãy Chọn Khoa Rồi Chọn Lớp");
            }
        }

        private void cbboxKhoa1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxKhoa1.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                Lop dc = new Lop();
                DataSet ds = new DataSet();
                ds = dc.LoadLopselect(t);
                cbboxLop1.DataSource = ds.Tables[0];
                cbboxLop1.DisplayMember = "Tenlop";
                cbboxLop1.ValueMember = "Malop";
            }
        }
        


        private void cbboxLop1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbboxTinhThanhPho1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxTinhThanhPho1.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                Diachi dc = new Diachi();
                DataSet ds = new DataSet();
                ds = dc.LoadHuyen(t);
                cbboxQuanHuyen1.DataSource = ds.Tables[0];
                cbboxQuanHuyen1.DisplayMember = "Tenhuyen";
                cbboxQuanHuyen1.ValueMember = "Mahuyen";
            }
        }

        private void cbboxQuanHuyen1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbboxQuanHuyen1.SelectedIndex!=-1)
            {
                String t;
                t = cbboxQuanHuyen1.SelectedValue.ToString();
                if (t == "System.Data.DataRowView")
                {

                }
                else
                {
                    Diachi dc = new Diachi();
                    DataSet ds = new DataSet();
                    ds = dc.LoadPhuong(t);
                    cbboxPhuongxa1.DataSource = ds.Tables[0];
                    cbboxPhuongxa1.DisplayMember = "Tenxa";
                    cbboxPhuongxa1.ValueMember = "Maxa";
                }
            }
        }

        private void cbboxchonkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxchonkhoa.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                Lop dc = new Lop();
                DataSet ds = new DataSet();
                ds = dc.LoadLopselect(t);
                cbboxchonlop.DataSource = ds.Tables[0];
                cbboxchonlop.DisplayMember = "Tenlop";
                cbboxchonlop.ValueMember = "Malop";
            }
        }

        private void btSuaSV_Click(object sender, EventArgs e)
        {
            if (txtMSV1.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Xác Nhận Chỉnh Sửa?", "Edit Liền Là Edit Liền", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Sinhvien a = new Sinhvien();
                    Lop b = new Lop();
                    Diachi c = new Diachi();
                    if (txtNamNhapHoc1.Text == "")
                    {
                        if (a.checkCMDNsua(txtCMND1.Text, int.Parse(txtMSV1.Text)) == true)
                        {
                            if (imgLoc != "")
                            {
                                try
                                {
                                    byte[] img = null;
                                    FileStream fs = new System.IO.FileStream(imgLoc, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                    BinaryReader br = new BinaryReader(fs);
                                    img = br.ReadBytes((int)fs.Length);
                                    a.update2(int.Parse(txtMSV1.Text), txtHoten1.Text, dateTimePicker1.Value.ToString(), cbboxGioitinh1.Text, cbboxDanToc1.Text, txtSDT1.Text, txtCMND1.Text, txtEmail1.Text, cbboxHeDT1.Text, txtHotenBo1.Text, txtNghebo1.Text, txtHotenme1.Text, txtNgheme1.Text, c.Maxa(cbboxPhuongxa1.Text), b.Malop(cbboxLop1.Text), cbboxTinhtrang1.Text, txtNamNhapHoc1.Text, img);
                                    MessageBox.Show("Sửa thành công");
                                    txtMSV1.Clear();
                                    txtCMND1.Clear();
                                    txtSDT1.Clear();
                                    txtNghebo1.Clear();
                                    txtNgheme1.Clear();
                                    txtHotenBo1.Clear();
                                    txtHotenme1.Clear();
                                    txtHoten1.Clear();
                                    txtEmail1.Clear();
                                    txtNamNhapHoc1.Clear();
                                    picstudent.Image = null;
                                    imgLoc = "";
                                    if (trangthai == "L")
                                    {
                                        dataGridView1.DataSource = a.Load(b.Malop(cbboxchonlop.Text));
                                    }
                                    else if (trangthai == "TK" && TimKiem!="")
                                    {
                                        if (IsNumber(TimKiem) == true) {
                                            dataGridView1.DataSource = a.Search(int.Parse(txtTimKiem.Text));
                                        }
                                        else
                                        {
                                            dataGridView1.DataSource = a.SearchHoten(RemoveVietnameseTone(txtTimKiem.Text).Trim());
                                        }
                                    }
                                    else if (trangthai == "All")
                                    {
                                        con.Open();
                                        ds.Clear();
                                        string sql = "select MSV,Hoten,AnhHoSo,Ngaysinh,Gioitinh,Dantoc,SDT,CMND,Email,Hedaotao,Hotenbo,Nghebo,Hotenme,Ngheme,TenTinh,Tenhuyen,Tenxa,Tenkhoa,Tenlop,Tinhtrang,NamnhapHoc from SinhVien, Lop, Khoa, Tinh, Huyen, Xa where SinhVien.Maxa=Xa.Maxa and Xa.Mahuyen=Huyen.Mahuyen and Huyen.Matinh=Tinh.Matinh and SinhVien.Malop=Lop.Malop and Lop.Makhoa=Khoa.Makhoa ORDER BY MSV ASC";
                                        SqlCommand cmd = new SqlCommand(sql, con);
                                        adapter.SelectCommand = cmd;
                                        adapter.Fill(ds, start, 18, "OP");
                                        dataGridView1.DataSource = ds.Tables[0];
                                        con.Close();
                                    }
                                    else
                                    {

                                    }

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                a.updateNoChangeImage(int.Parse(txtMSV1.Text), txtHoten1.Text, dateTimePicker1.Value.ToString(), cbboxGioitinh1.Text, cbboxDanToc1.Text, txtSDT1.Text, txtCMND1.Text, txtEmail1.Text, cbboxHeDT1.Text, txtHotenBo1.Text, txtNghebo1.Text, txtHotenme1.Text, txtNgheme1.Text, c.Maxa(cbboxPhuongxa1.Text), b.Malop(cbboxLop1.Text), cbboxTinhtrang1.Text, txtNamNhapHoc1.Text);
                                MessageBox.Show("Sửa thành công");
                                txtMSV1.Clear();
                                txtCMND1.Clear();
                                txtSDT1.Clear();
                                txtNghebo1.Clear();
                                txtNgheme1.Clear();
                                txtHotenBo1.Clear();
                                txtHotenme1.Clear();
                                txtHoten1.Clear();
                                txtEmail1.Clear();
                                txtNamNhapHoc1.Clear();
                                picstudent.Image = null;
                                if (trangthai == "L")
                                {
                                    dataGridView1.DataSource = a.Load(b.Malop(cbboxchonlop.Text));
                                }
                                else if (trangthai == "TK" && TimKiem != "")
                                {
                                    if (IsNumber(TimKiem) == true)
                                    {
                                        dataGridView1.DataSource = a.Search(int.Parse(txtTimKiem.Text));
                                    }
                                    else
                                    {
                                        dataGridView1.DataSource = a.SearchHoten(RemoveVietnameseTone(txtTimKiem.Text).Trim());
                                    }
                                }
                                else if (trangthai == "All")
                                {
                                    con.Open();
                                    ds.Clear();
                                    string sql = "select MSV,Hoten,AnhHoSo,Ngaysinh,Gioitinh,Dantoc,SDT,CMND,Email,Hedaotao,Hotenbo,Nghebo,Hotenme,Ngheme,TenTinh,Tenhuyen,Tenxa,Tenkhoa,Tenlop,Tinhtrang,NamnhapHoc from SinhVien, Lop, Khoa, Tinh, Huyen, Xa where SinhVien.Maxa=Xa.Maxa and Xa.Mahuyen=Huyen.Mahuyen and Huyen.Matinh=Tinh.Matinh and SinhVien.Malop=Lop.Malop and Lop.Makhoa=Khoa.Makhoa ORDER BY MSV ASC";
                                    SqlCommand cmd = new SqlCommand(sql, con);
                                    adapter.SelectCommand = cmd;
                                    adapter.Fill(ds, start, 18, "OP");
                                    dataGridView1.DataSource = ds.Tables[0];
                                    con.Close();
                                }
                                else
                                {

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("CMND này trùng với sinh viên nào đó sử dụng");
                        }
                    }
                    else
                    {
                        if (a.checkCMDNsua(txtCMND1.Text, int.Parse(txtMSV1.Text)) == true)
                        {
                            if (imgLoc != "")
                            {
                                try
                                {
                                    byte[] img = null;
                                    FileStream fs = new System.IO.FileStream(imgLoc, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                    BinaryReader br = new BinaryReader(fs);
                                    img = br.ReadBytes((int)fs.Length);
                                    a.update(int.Parse(txtMSV1.Text), txtHoten1.Text, dateTimePicker1.Value.ToString(), cbboxGioitinh1.Text, cbboxDanToc1.Text, txtSDT1.Text, txtCMND1.Text, txtEmail1.Text, cbboxHeDT1.Text, txtHotenBo1.Text, txtNghebo1.Text, txtHotenme1.Text, txtNgheme1.Text, c.Maxa(cbboxPhuongxa1.Text), b.Malop(cbboxLop1.Text), cbboxTinhtrang1.Text, int.Parse(txtNamNhapHoc1.Text), img);
                                    MessageBox.Show("Sửa thành công");
                                    txtMSV1.Clear();
                                    txtCMND1.Clear();
                                    txtSDT1.Clear();
                                    txtNghebo1.Clear();
                                    txtNgheme1.Clear();
                                    txtHotenBo1.Clear();
                                    txtHotenme1.Clear();
                                    txtHoten1.Clear();
                                    txtEmail1.Clear();
                                    txtNamNhapHoc1.Clear();
                                    picstudent.Image = null;
                                    imgLoc = "";
                                    if (trangthai == "L")
                                    {
                                        dataGridView1.DataSource = a.Load(b.Malop(cbboxchonlop.Text));
                                    }
                                    else if (trangthai == "TK" && TimKiem != "")
                                    {
                                        if (IsNumber(TimKiem) == true)
                                        {
                                            dataGridView1.DataSource = a.Search(int.Parse(txtTimKiem.Text));
                                        }
                                        else
                                        {
                                            dataGridView1.DataSource = a.SearchHoten(RemoveVietnameseTone(txtTimKiem.Text).Trim());
                                        }
                                    }
                                    else if (trangthai == "All")
                                    {
                                        con.Open();
                                        ds.Clear();
                                        string sql = "select MSV,Hoten,AnhHoSo,Ngaysinh,Gioitinh,Dantoc,SDT,CMND,Email,Hedaotao,Hotenbo,Nghebo,Hotenme,Ngheme,TenTinh,Tenhuyen,Tenxa,Tenkhoa,Tenlop,Tinhtrang,NamnhapHoc from SinhVien, Lop, Khoa, Tinh, Huyen, Xa where SinhVien.Maxa=Xa.Maxa and Xa.Mahuyen=Huyen.Mahuyen and Huyen.Matinh=Tinh.Matinh and SinhVien.Malop=Lop.Malop and Lop.Makhoa=Khoa.Makhoa ORDER BY MSV ASC";
                                        SqlCommand cmd = new SqlCommand(sql, con);
                                        adapter.SelectCommand = cmd;
                                        adapter.Fill(ds, start, 18, "OP");
                                        dataGridView1.DataSource = ds.Tables[0];
                                        con.Close();
                                    }
                                    else
                                    {

                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                a.updateNoChangeImage(int.Parse(txtMSV1.Text), txtHoten1.Text, dateTimePicker1.Value.ToString(), cbboxGioitinh1.Text, cbboxDanToc1.Text, txtSDT1.Text, txtCMND1.Text, txtEmail1.Text, cbboxHeDT1.Text, txtHotenBo1.Text, txtNghebo1.Text, txtHotenme1.Text, txtNgheme1.Text, c.Maxa(cbboxPhuongxa1.Text), b.Malop(cbboxLop1.Text), cbboxTinhtrang1.Text, txtNamNhapHoc1.Text);
                                MessageBox.Show("Sửa thành công");
                                txtMSV1.Clear();
                                txtCMND1.Clear();
                                txtSDT1.Clear();
                                txtNghebo1.Clear();
                                txtNgheme1.Clear();
                                txtHotenBo1.Clear();
                                txtHotenme1.Clear();
                                txtHoten1.Clear();
                                txtEmail1.Clear();
                                txtNamNhapHoc1.Clear();
                                picstudent.Image = null;
                                if (trangthai == "L")
                                {
                                    dataGridView1.DataSource = a.Load(b.Malop(cbboxchonlop.Text));
                                }
                                else if (trangthai == "TK" && TimKiem != "")
                                {
                                    if (IsNumber(TimKiem) == true)
                                    {
                                        dataGridView1.DataSource = a.Search(int.Parse(txtTimKiem.Text));
                                    }
                                    else
                                    {
                                        dataGridView1.DataSource = a.SearchHoten(RemoveVietnameseTone(txtTimKiem.Text).Trim());
                                    }
                                }
                                else if (trangthai == "All")
                                {
                                    con.Open();
                                    ds.Clear();
                                    string sql = "select MSV,Hoten,AnhHoSo,Ngaysinh,Gioitinh,Dantoc,SDT,CMND,Email,Hedaotao,Hotenbo,Nghebo,Hotenme,Ngheme,TenTinh,Tenhuyen,Tenxa,Tenkhoa,Tenlop,Tinhtrang,NamnhapHoc from SinhVien, Lop, Khoa, Tinh, Huyen, Xa where SinhVien.Maxa=Xa.Maxa and Xa.Mahuyen=Huyen.Mahuyen and Huyen.Matinh=Tinh.Matinh and SinhVien.Malop=Lop.Malop and Lop.Makhoa=Khoa.Makhoa ORDER BY MSV ASC";
                                    SqlCommand cmd = new SqlCommand(sql, con);
                                    adapter.SelectCommand = cmd;
                                    adapter.Fill(ds, start, 18, "OP");
                                    dataGridView1.DataSource = ds.Tables[0];
                                    con.Close();
                                }
                                else
                                {

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("CMND này trùng với sinh viên nào đó sử dụng");
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đối tượng");
            }
        }

        private void btXoaSV_Click(object sender, EventArgs e)
        {
            if (txtMSV1.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Delete Sinh Vien", "Delete ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Sinhvien a = new Sinhvien();
                    a.ExecuteNonQuery("Delete from DiemRL where MSVien="+txtMSV1.Text);
                    a.ExecuteNonQuery("Delete from Hosotamtru where MSVien="+txtMSV1.Text);
                    try
                    {
                        a.delete(int.Parse(txtMSV1.Text));
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    MessageBox.Show("Xóa thành công");
                    Lop b = new Lop();
                    //dataGridView1.DataSource = a.Load(b.Malop(cbboxchonlop.Text));
                    txtMSV1.Clear();
                    txtCMND1.Clear();
                    txtSDT1.Clear();
                    txtNghebo1.Clear();
                    txtNgheme1.Clear();
                    txtHotenBo1.Clear();
                    txtHotenme1.Clear();
                    txtHoten1.Clear();
                    txtEmail1.Clear();
                    picstudent.Image = null;
                    if(trangthai=="L")
                    {
                        dataGridView1.DataSource= a.Load(b.Malop(cbboxchonlop.Text));
                    }
                    else if(trangthai=="TK" && TimKiem != "")
                    {
                        if (IsNumber(TimKiem) == true)
                        {
                            dataGridView1.DataSource = a.Search(int.Parse(txtTimKiem.Text));
                        }
                        else
                        {
                            dataGridView1.DataSource = a.SearchHoten(RemoveVietnameseTone(txtTimKiem.Text).Trim());
                        }
                    }
                    else if(trangthai=="All")
                    {
                        con.Open();
                        ds.Clear();
                        string sql = "select MSV,Hoten,AnhHoSo,Ngaysinh,Gioitinh,Dantoc,SDT,CMND,Email,Hedaotao,Hotenbo,Nghebo,Hotenme,Ngheme,TenTinh,Tenhuyen,Tenxa,Tenkhoa,Tenlop,Tinhtrang,NamnhapHoc from SinhVien, Lop, Khoa, Tinh, Huyen, Xa where SinhVien.Maxa=Xa.Maxa and Xa.Mahuyen=Huyen.Mahuyen and Huyen.Matinh=Tinh.Matinh and SinhVien.Malop=Lop.Malop and Lop.Makhoa=Khoa.Makhoa ORDER BY MSV ASC";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds, start, 18, "OP");
                        dataGridView1.DataSource = ds.Tables[0];
                        con.Close();
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đối tượng");
            }
        }

        private void txtSDT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCMND1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNamNhapHoc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbboxchonkhoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbboxchonkhoa.DroppedDown = true;
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            string str = cbboxchonkhoa.Text.Substring(0, cbboxchonkhoa.SelectionStart) + e.KeyChar;
            Int32 index = cbboxchonkhoa.FindStringExact(str);
            if (index == -1)
            {
                index = cbboxchonkhoa.FindString(str);
            }
            this.cbboxchonkhoa.SelectedIndex = index;
            this.cbboxchonkhoa.SelectionStart = str.Length;
            this.cbboxchonkhoa.SelectionLength = this.cbboxchonkhoa.Text.Length - this.cbboxchonkhoa.SelectionStart;
            e.Handled = true;
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        private void btTimSV_Click(object sender, EventArgs e)
        {
            click = true;
            page = 1;
            lblPageMAx.Text = "";
            btnback.Enabled = false;
            btnnext.Enabled = false;
            btnfullnext.Enabled = false;
            btnfullback.Enabled = false;
            trangthai = "TK";
            if (txtTimKiem.Text != "")
            {
                click = true;
                Sinhvien a = new Sinhvien();
                if (IsNumber(txtTimKiem.Text) == true)
                {
                    dataGridView1.DataSource = a.Search(int.Parse(txtTimKiem.Text));
                    if(dataGridView1.Rows.Count==0)
                    {
                        MessageBox.Show("Ko tìm thấy :((");
                    }
                    TimKiem = txtTimKiem.Text;
                }
                else
                {
                    dataGridView1.DataSource = a.SearchHoten(RemoveVietnameseTone(txtTimKiem.Text).Trim());
                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("Ko tìm thấy :((");
                    }
                    TimKiem = txtTimKiem.Text;
                }
            }
            else
            {
                MessageBox.Show("Nhập gì đi mới tìm đc chứ :<");
            }
        }

        private void txtCMND1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Cập Nhật Toàn Bộ SV?", "Hiển Thị Toàn Bộ SV", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                click = true;
                con.Open();
                ds.Clear();
                start = 0;
                page = 1;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SV_Load";
                adapter.SelectCommand = cmd;
                double c = (double)count() / (double)18;
                lblPageMAx.Text = "/" + (int)Math.Ceiling(c);

                adapter.Fill(ds, start, 18, "OP");
                
                dataGridView1.DataSource = ds.Tables[0];
                
                lblPageNumber.Text = "Trang: 1";
                btnback.Enabled = false;
                btnnext.Enabled = true;
                btnfullnext.Enabled = true;
                btnfullback.Enabled = false;
                con.Close();
                trangthai = "All";
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            start = start - 18;
            btnnext.Enabled = true;
            btnfullnext.Enabled = true;
            if (start < 0)
            {
                start = 0;
                btnback.Enabled = false;
                btnfullback.Enabled = false;
            }
            else
            {
                ds.Clear();
                adapter.Fill(ds, start, 18, "OP");
                btnfullnext.Enabled = true;
                btnnext.Enabled = true;
                page = page - 1;
                lblPageNumber.Text = "Trang:" + page;
                if (start - 18 < 0)
                {
                    btnback.Enabled = false;
                    btnfullback.Enabled = false;
                }
            }
            
        }
        public static int count()
        {
            int kq;
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*)FROM Sinhvien";
            SqlCommand cmd = new SqlCommand(sql, con);
            kq = (int)cmd.ExecuteScalar();
            con.Close();
            return kq;
        }
        private void btnnext_Click(object sender, EventArgs e)
        {
            start = start + 18;
            btnback.Enabled = true;
            if (start>count())
            {
                btnnext.Enabled = false;
                btnfullnext.Enabled = false;
            }
            else
            {
                ds.Clear();
                adapter.Fill(ds, start, 18, "OP");
                btnback.Enabled = true;
                btnfullback.Enabled = true;
                page = page + 1;
                lblPageNumber.Text = "Trang:" + page;
                if(start+18 >= count())
                {
                    btnnext.Enabled = false;
                    btnfullnext.Enabled = false;
                }
            }
        }

        private void btnfullback_Click(object sender, EventArgs e)
        {
            start = 0;
            ds.Clear();
            adapter.Fill(ds, start, 18, "OP");
            btnfullback.Enabled = false;
            btnfullnext.Enabled = true;
            btnnext.Enabled = true;
            btnback.Enabled = false;
            page = 1;
            lblPageNumber.Text = "Trang:" + page;
        }

        private void btnfullnext_Click(object sender, EventArgs e)
        {
            int phandu = count() % 18;
            if (phandu == 0)
            {
                start = count() - 18;
            }
            else
            {
                start = count() - phandu;
            }
            ds.Clear();
            adapter.Fill(ds, start, 18, "OP");
            btnfullnext.Enabled = false;
            btnfullback.Enabled = true;
            btnback.Enabled = true;
            btnnext.Enabled = false;
            double c = (double) count() / (double) 18;
            page = (int)Math.Ceiling(c);
            lblPageNumber.Text = "Trang:" + page;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
                dlg.Title = "Select Student Picture";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    picstudent.ImageLocation = imgLoc;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
