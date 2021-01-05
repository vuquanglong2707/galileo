using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BaiTapLonN6
{
    public partial class HoSoTamTru : Form
    {
        SqlConnection con = new SqlConnection(ConnectionString.connectionString);
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        static int start;
        int page;
        static String trangthai = "";
        static String TimKiem = "";

        private String ten;
        private String quyen;
        public HoSoTamTru(String tenuser,String quyenhan)
        {
            InitializeComponent();
            this.ten = tenuser;
            this.quyen = quyenhan;
        }

        public Boolean click = false;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (click == true)
            {
                if (dataGridView1.Rows.Count == 0)
                {

                }
                else
                {
                    txtMaID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtMSV1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtHoten1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txtNoitamtru1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    txtGhichu1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMSV1.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Xác Nhận Chỉnh Sửa?", "Edit Liền Là Edit Liền", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Sinhvien a = new Sinhvien();
                    Lop b = new Lop();
                    a.ExecuteNonQuery("update Hosotamtru set Ngayden='" + dateTimePicker1.Value.ToString() + "',Ghichu=N'" + txtGhichu1.Text + "',Noitamtru=N'" + txtNoitamtru1.Text + "' where ID=" + txtMaID.Text);
                    MessageBox.Show("Sửa thành công");
                    txtMaID.Clear();
                    txtMSV1.Clear();
                    txtHoten1.Clear();
                    txtNoitamtru1.Clear();
                    txtGhichu1.Clear();
                    if (trangthai == "L")
                    {
                        dataGridView1.DataSource = a.getTable("Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop,Hosotamtru where SinhVien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop and SinhVien.Malop=" + b.Malop(cbboxLop.Text));
                    }
                    else if (trangthai == "All")
                    {
                        con.Open();
                        ds.Clear();
                        string sql = "Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop,Hosotamtru where SinhVien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds, start, 25, "OP");
                        dataGridView1.DataSource = ds.Tables[0];
                        con.Close();
                    }
                    else if (trangthai == "TK" && TimKiem != "")
                    {
                        if (IsNumber(TimKiem) == true)
                        {
                            int msv = int.Parse(TimKiem);
                            dataGridView1.DataSource = a.getTable("Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop, Hosotamtru where Sinhvien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop and SinhVien.MSV=" + msv);
                        }
                        else
                        {
                            dataGridView1.DataSource = a.getTable("Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop, Hosotamtru where Sinhvien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop and dbo.ufn_removeMark(Hoten)='" + RemoveVietnameseTone(TimKiem) + "'");
                        }
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Dữ Liệu Bạn Muốn Chỉnh Sửa");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaID.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Xác Nhận Xóa?", "Bạn Chắc Chắn Muốn Xóa Chứ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Sinhvien a = new Sinhvien();
                    Lop b = new Lop();
                    a.ExecuteNonQuery("delete from Hosotamtru where ID=" + txtMaID.Text);
                    MessageBox.Show("Xóa Thành Công");
                    //dataGridView1.DataSource = a.getTable("Select ID,MSV,Hoten,Noitamtru,Ngayden,Ghichu from SinhVien, Hosotamtru where Sinhvien.MSV=Hosotamtru.MSVien and SinhVien.Malop=" + b.Malop(cbboxLop.Text));
                    txtMaID.Clear();
                    txtMSV1.Clear();
                    txtHoten1.Clear();
                    txtNoitamtru1.Clear();
                    txtGhichu1.Clear();
                    if (trangthai == "L")
                    {
                        dataGridView1.DataSource = a.getTable("Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop,Hosotamtru where SinhVien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop and SinhVien.Malop=" + b.Malop(cbboxLop.Text));
                    }
                    else if (trangthai == "All")
                    {
                        con.Open();
                        ds.Clear();
                        string sql = "Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop,Hosotamtru where SinhVien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds, start, 25, "OP");
                        dataGridView1.DataSource = ds.Tables[0];
                        con.Close();
                    }
                    else if (trangthai == "TK" && TimKiem != "")
                    {
                        if (IsNumber(TimKiem) == true)
                        {
                            int msv = int.Parse(TimKiem);
                            dataGridView1.DataSource = a.getTable("Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop, Hosotamtru where Sinhvien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop and SinhVien.MSV=" + msv);
                        }
                        else
                        {
                            dataGridView1.DataSource = a.getTable("Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop, Hosotamtru where Sinhvien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop and dbo.ufn_removeMark(Hoten)='" + RemoveVietnameseTone(TimKiem) + "'");
                        }
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Dữ Liệu Bạn Muốn Xóa");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbboxLop.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lớp");
            }
            else
            {
                Sinhvien a = new Sinhvien();
                Lop b = new Lop();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = a.getTable("Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop,Hosotamtru where SinhVien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop and SinhVien.Malop=" + b.Malop(cbboxLop.Text));
                click = true;
                start = 0;
                page = 1;
                lblPageNumber.Text = "Trang :" + page;
                lblPageMAx.Text = "";
                btnback.Enabled = false;
                btnnext.Enabled = false;
                btnfullnext.Enabled = false;
                btnfullback.Enabled = false;
                trangthai = "L";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemTamTru frm = new ThemTamTru();
            frm.ShowDialog();
        }

        private void HoSoTamTru_Load(object sender, EventArgs e)
        {
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            KhoaDT khoa = new KhoaDT();
            DataSet ds1 = new DataSet();
            ds1 = khoa.Loadkhoa();
            cbboxKhoa.DataSource = ds1.Tables[0];
            cbboxKhoa.DisplayMember = "Tenkhoa";
            cbboxKhoa.ValueMember = "Makhoa";


            txtTimKiem.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTimKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            getData2(DataCollection);
            txtTimKiem.AutoCompleteCustomSource = DataCollection;

            if(quyen=="Sinh Viên")
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                dataGridView1.Dock = DockStyle.Fill;
                DataTable data = new DataTable();
                using(SqlConnection con=new SqlConnection(ConnectionString.connectionString))
                {
                    con.Open();
                    String sql = "Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop,Hosotamtru where SinhVien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop and SinhVien.MSV="+ten;
                    SqlCommand cmd = new SqlCommand(sql,con);
                    SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                    Adapter.Fill(data);
                    con.Close();
                }
                dataGridView1.DataSource = data;
                dataGridView1.ReadOnly = true;
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

        private void cbboxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxKhoa.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                Lop dc = new Lop();
                DataSet ds = new DataSet();
                ds = dc.LoadLopselect(t);
                cbboxLop.DataSource = ds.Tables[0];
                cbboxLop.DisplayMember = "Tenlop";
                cbboxLop.ValueMember = "Malop";
            }
        }
        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
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
        private void btTimSV_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                click = true;
                Sinhvien a = new Sinhvien();
                if (IsNumber(txtTimKiem.Text) == true)
                {
                    int msv = int.Parse(txtTimKiem.Text);
                    dataGridView1.DataSource = a.getTable("Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop, Hosotamtru where Sinhvien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop and SinhVien.MSV=" + msv);
                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("Ko tìm thấy Hoặc Sinh Viên Này Chưa Có Tạm Trú Nào :((");
                    }
                    start = 0;
                    page = 1;
                    lblPageMAx.Text = "";
                    btnback.Enabled = false;
                    btnnext.Enabled = false;
                    btnfullnext.Enabled = false;
                    btnfullback.Enabled = false;
                    trangthai = "TK";
                    TimKiem = txtTimKiem.Text;
                }
                else
                {
                    dataGridView1.DataSource = a.getTable("Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop, Hosotamtru where Sinhvien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop and dbo.ufn_removeMark(Hoten)='" + RemoveVietnameseTone(txtTimKiem.Text) + "'");
                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("Ko tìm thấy Hoặc Sinh Viên Này Chưa Có Tạm Trú Nào :((");
                    }
                    start = 0;
                    page = 1;
                    lblPageMAx.Text = "";
                    btnback.Enabled = false;
                    btnnext.Enabled = false;
                    btnfullnext.Enabled = false;
                    btnfullback.Enabled = false;
                    trangthai = "TK";
                    TimKiem = txtTimKiem.Text;
                }
            }
            else
            {
                MessageBox.Show("Nhập gì đi mới tìm đc chứ :<");
            }
        }
        public static int count()
        {
            int kq;
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*)FROM Hosotamtru";
            SqlCommand cmd = new SqlCommand(sql, con);
            kq = (int)cmd.ExecuteScalar();
            con.Close();
            return kq;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Cập Nhật Toàn Bộ Tạm Trú?", "Hiển Thị Toàn Bộ Hồ Sơ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (thongbao == DialogResult.OK)
            {
                click = true;
                con.Open();
                ds.Clear();
                string sql = "Select ID,MSV,Hoten,Tenlop,Noitamtru,Ngayden,Ghichu from SinhVien,Lop,Hosotamtru where SinhVien.MSV=Hosotamtru.MSVien and SinhVien.Malop=Lop.Malop";
                SqlCommand cmd = new SqlCommand(sql, con);
                adapter.SelectCommand = cmd;
                start = 0;
                page = 1;
                double c = (double)count() / (double)25;
                lblPageMAx.Text = "/" + (int)Math.Ceiling(c);

                adapter.Fill(ds, start, 25, "OP");

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

        private void btnfullback_Click(object sender, EventArgs e)
        {
            start = 0;
            ds.Clear();
            adapter.Fill(ds, start, 25, "OP");
            btnfullback.Enabled = false;
            btnfullnext.Enabled = true;
            btnnext.Enabled = true;
            btnback.Enabled = false;
            page = 1;
            lblPageNumber.Text = "Trang:" + page;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            start = start - 25;
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
                adapter.Fill(ds, start, 25, "OP");
                btnfullnext.Enabled = true;
                btnnext.Enabled = true;
                page = page - 1;
                lblPageNumber.Text = "Trang:" + page;
                if (start - 25 < 0)
                {
                    btnback.Enabled = false;
                    btnfullback.Enabled = false;
                }
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            start = start + 25;
            btnback.Enabled = true;
            if (start > count())
            {
                btnnext.Enabled = false;
                btnfullnext.Enabled = false;
            }
            else
            {
                ds.Clear();
                adapter.Fill(ds, start, 25, "OP");
                btnback.Enabled = true;
                btnfullback.Enabled = true;
                page = page + 1;
                lblPageNumber.Text = "Trang:" + page;
                if (start + 25 >= count())
                {
                    btnnext.Enabled = false;
                    btnfullnext.Enabled = false;
                }
            }
        }

        private void btnfullnext_Click(object sender, EventArgs e)
        {
            int phandu = count() % 25;
            if (phandu == 0)
            {
                start = count() - 25;
            }
            else
            {
                start = count() - phandu;
            }
            ds.Clear();
            adapter.Fill(ds, start, count(), "OP");
            btnfullnext.Enabled = false;
            btnfullback.Enabled = true;
            btnback.Enabled = true;
            btnnext.Enabled = false;
            double c = (double)count() / (double)25;
            page = (int)Math.Ceiling(c);
            lblPageNumber.Text = "Trang:" + page;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
