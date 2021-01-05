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
    public partial class FrmTaoLopDangKyHoc : Form
    {
        static String NHHK;
        public FrmTaoLopDangKyHoc()
        {
            InitializeComponent();
        }

        private void FrmTaoLopDangKyHoc_Load(object sender, EventArgs e)
        {
            NHHK = null;
            KhoaDT khoa = new KhoaDT();
            DataSet ds1 = new DataSet();
            ds1 = khoa.Loadkhoa();
            cbboxKhoa.DataSource = ds1.Tables[0];
            cbboxKhoa.DisplayMember = "Tenkhoa";
            cbboxKhoa.ValueMember = "Makhoa";


            DataSet ds2 = new DataSet();
            ds2 = khoa.Loadkhoa();
            cbboxLoadKhoa.DataSource = ds2.Tables[0];
            cbboxLoadKhoa.DisplayMember = "Tenkhoa";
            cbboxLoadKhoa.ValueMember = "Makhoa";


            DateTime today = DateTime.Now;
            int year = today.Year;
            int month = today.Month;
            if (month <= 6)
            {
                NHHK = year - 1 + " - " + year + "_2";
            }
            else if (month > 6)
            {
                NHHK = year + " - " + (year + 1) + "_1";
            }
            txtNamHocHienTai.Text = NHHK;


        }

        private Boolean check(String MaHocPhan)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "Select COUNT(*) from LopHocPhan where MaLopHP=@MaHocPhan";
                SqlCommand cmd = new SqlCommand(sql,con);
                cmd.Parameters.Add(new SqlParameter("@MaHocPhan", MaHocPhan));
                int result = (int)cmd.ExecuteScalar();
                con.Close();
                if(result==0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        private void XoaLop(String Malop)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETE_LOPHOC";
                cmd.Parameters.Add(new SqlParameter("@malop", Malop));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void XoaSVDANGKYTRONGLOP(String Malop)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETE_SINHVIENTRONGLOPHOC";
                cmd.Parameters.Add(new SqlParameter("@malop", Malop));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private DataTable LoadLopMo()
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LIST_LOPHOC";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }


        private DataTable LoadLopMoTheoKhoa(String makhoa)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LIST_LOPHOCTHEOKHOA";
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }


        private DataTable DSMonHoc(String makhoa)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DSMONHOC_MOLOP";
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        private DataTable DSGiangVien(String makhoa)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DSGIANGVIEN_MOLOP";
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
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
                cbboxMonHoc.DataSource = DSMonHoc(t);
                cbboxMonHoc.DisplayMember = "TenMonHoc";
                cbboxMonHoc.ValueMember = "MaMonHoc";

                cbboxGiangVien.DataSource = DSGiangVien(t);
                cbboxGiangVien.DisplayMember = "Hoten";
                cbboxGiangVien.ValueMember = "MGV";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtChiTiet.Text=="" || txtMaLopHP.Text=="" || txtNoiHoc.Text=="" || txtTenLopHP.Text =="" || cbboxMonHoc.Text=="" || cbboxGiangVien.Text=="" || txtNamHocHienTai.Text=="")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin lớp học cần mở");
            }
            else
            {
                if (check(txtMaLopHP.Text) == true)
                {
                    using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "Insert_MOLOPHoc";
                        cmd.Parameters.Add(new SqlParameter("@makhoa", cbboxKhoa.SelectedValue.ToString()));
                        cmd.Parameters.Add(new SqlParameter("@malop", txtMaLopHP.Text));
                        cmd.Parameters.Add(new SqlParameter("@tenlop", txtTenLopHP.Text));
                        cmd.Parameters.Add(new SqlParameter("@mamonhoc", cbboxMonHoc.SelectedValue.ToString()));
                        object obj = "Từ " + dateTimePicker1.Text + " Đến " + dateTimePicker2.Text + " " + txtChiTiet.Text;
                        cmd.Parameters.Add(new SqlParameter("@thoigian", obj));
                        cmd.Parameters.Add(new SqlParameter("@mgv", cbboxGiangVien.SelectedValue.ToString()));
                        cmd.Parameters.Add(new SqlParameter("@diadiem", txtNoiHoc.Text));
                        cmd.Parameters.Add(new SqlParameter("@siso", txtSiSo.Text));
                        cmd.Parameters.Add(new SqlParameter("@namhoc", txtNamHocHienTai.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    MessageBox.Show("Mở Thành Công Lớp");
                    dataGridView1.DataSource = LoadLopMo();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[10, i] = linkCell;
                    }
                    txtMaLopHP.Clear();
                    txtChiTiet.Clear();
                    txtSiSo.Clear();
                    txtTenLopHP.Clear();
                    txtNoiHoc.Clear();

                    DateTime today = DateTime.Now;
                    int year = today.Year;
                    int month = today.Month;
                    if (month <= 6)
                    {
                        NHHK = year - 1 + " - " + year + "_2";
                    }
                    else if (month > 6)
                    {
                        NHHK = year + " - " + (year + 1) + "_1";
                    }
                    txtNamHocHienTai.Text = NHHK;
                    radioThayDoi.Checked = true;
                    txtNamHocHienTai.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Đã Có Mã Lớp Này");
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
                if (e.ColumnIndex == 10)
                {
                    string Task = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    if (Task == "Delete")
                    {
                        if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            String ID = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
                            XoaSVDANGKYTRONGLOP(ID);
                            XoaLop(ID);
                            dataGridView1.DataSource = LoadLopMo();
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                                dataGridView1[10, i] = linkCell;
                            }
                        }
                    }
                }

            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadLopMo();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[10, i] = linkCell;
            }
        }

        private void txtSiSo_TextChanged(object sender, EventArgs e)
        {
            if (txtSiSo.Text == "") { }
            else
            {
                if (int.Parse(txtSiSo.Text) > 100)
                {
                    txtSiSo.Text = "60";
                }
            }
        }

        private void txtSiSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnLoadTheoKhoa_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadLopMoTheoKhoa(cbboxLoadKhoa.SelectedValue.ToString());
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView1[10, i] = linkCell;
            }
        }

        private void radioThayDoi_CheckedChanged(object sender, EventArgs e)
        {
            txtNamHocHienTai.Enabled = true;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
