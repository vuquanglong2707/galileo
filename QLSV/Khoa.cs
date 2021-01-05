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
    public partial class Khoa : Form
    {
        public Khoa()
        {
            InitializeComponent();
        }
        public Boolean click = false;

        private void btLoadkhoa_Click(object sender, EventArgs e)
        {
            KhoaDT k = new KhoaDT();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = k.Loadkhoa().Tables[0];
            click = true;
        }

        private void btThemkhoa_Click(object sender, EventArgs e)
        {
            if (txtTenkhoa.Text != "")
            {
                KhoaDT k = new KhoaDT();
                k.Them(txtTenkhoa.Text,txtSoTien.Text);
                MessageBox.Show("Thêm thành Công");
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = k.Loadkhoa();
                txtTenkhoa.Clear();
                txtTenkhoa.Clear();
                txtSoTien2.Clear();
            }
            else
            {
                MessageBox.Show("Tên Khoa không thể bỏ trống");
            }
        }

        private void btsuakhoa_Click(object sender, EventArgs e)
        {
            if (txtMakhoa1.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Xác Nhận Chỉnh Sửa?", "Edit Liền Là Edit Liền", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    KhoaDT k = new KhoaDT();
                    k.update(txtMakhoa1.Text, txtTenkhoa1.Text,txtSoTien2.Text);
                    MessageBox.Show("Sửa thành công");
                    txtMakhoa1.Clear();
                    txtTenkhoa1.Clear();
                    txtSoTien2.Clear();
                    dataGridView1.DataSource = k.Loadkhoa().Tables[0];
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đối tượng");
            }
        }

        private void btXoakhoa_Click(object sender, EventArgs e)
        {
            if (txtMakhoa1.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Delete Khoa", "Bạn thực sự Muốn Xóa Khoa này ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    KhoaDT k = new KhoaDT();
                    if (k.check(int.Parse(txtMakhoa1.Text)) == false)
                    {
                        k.delete(txtMakhoa1.Text);
                        MessageBox.Show("Xóa thành công");
                        dataGridView1.DataSource = k.Loadkhoa().Tables[0];
                        txtMakhoa1.Clear();
                        txtTenkhoa1.Clear();
                        txtSoTien2.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Tồn Tại Lớp Học Thuộc Khoa Này");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đối tượng");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(click == true)
            {
                if (dataGridView1.Rows.Count == 0)
                {

                }
                else
                {
                    txtMakhoa1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtTenkhoa1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtSoTien2.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
                }
            }
        }

        private void Khoa_Load(object sender, EventArgs e)
        {
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            KhoaDT khoa = new KhoaDT();
            DataSet ds1 = new DataSet();
            ds1 = khoa.Loadkhoa();
            cbboxKhoa.DataSource = ds1.Tables[0];
            cbboxKhoa.DisplayMember = "Tenkhoa";
            cbboxKhoa.ValueMember = "Makhoa";

            DataSet ds2 = new DataSet();
            ds2 = khoa.Loadkhoa();
            cbboxChonKhoaCapNhat.DataSource = ds2.Tables[0];
            cbboxChonKhoaCapNhat.DisplayMember = "Tenkhoa";
            cbboxChonKhoaCapNhat.ValueMember = "Makhoa";

        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoTien2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtMaChuyenNganh.Clear();
            txtTenChuyenNganh.Clear();
        }

        private void themchuyennganh(String machuyennganh,String tenchuyennganh,String makhoa)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TAOCHUYENNGANH";
                cmd.Parameters.Add(new SqlParameter("@machuyennganh", machuyennganh));
                cmd.Parameters.Add(new SqlParameter("@tenchuyennganh", tenchuyennganh));
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        private void xoachuyennganh(String machuyennganh)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XOACHUYENNGANH";
                cmd.Parameters.Add(new SqlParameter("@machuyennganh", machuyennganh));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void suachuyennganh(String machuyennganh, String tenchuyennganh, String makhoa)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SUACHUYENNGANH";
                cmd.Parameters.Add(new SqlParameter("@machuyennganh", machuyennganh));
                cmd.Parameters.Add(new SqlParameter("@tenchuyennganh", tenchuyennganh));
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



        private DataTable LoadChuyenNganh()
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHTATCACHUYENNGANH";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        private DataTable LoadChuyenNganhTheoKhoa(String makhoa)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHTATCACHUYENNGANHTHEOKHOA";
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtTenChuyenNganh.Text!="" && txtMaChuyenNganh.Text!="")
            {
                try
                {
                    themchuyennganh(txtMaChuyenNganh.Text, txtTenChuyenNganh.Text, cbboxKhoa.SelectedValue.ToString());
                    MessageBox.Show("Thêm Thành Công");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Trùng Mã CN");
                } 
            }
            else
            {
                MessageBox.Show("Điền Đầy Đủ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = LoadChuyenNganh();
        }

        private void btnCapNhatCNTheoKhoa_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource= LoadChuyenNganhTheoKhoa(cbboxChonKhoaCapNhat.SelectedValue.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtMaChuyenNganh.Text != "")
            {
                suachuyennganh(txtMaChuyenNganh.Text, txtTenChuyenNganh.Text, cbboxKhoa.SelectedValue.ToString());
                MessageBox.Show("Done :)");
            }
            else
            {
                MessageBox.Show("Chọn đối tượng");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtMaChuyenNganh.Text != "")
            {
                xoachuyennganh(txtMaChuyenNganh.Text);
                MessageBox.Show("Done :)");
            }
            else
            {
                MessageBox.Show("Chọn đối tượng");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView2.Rows.Count==0)
            {

            }
            else
            {
                txtMaChuyenNganh.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                txtTenChuyenNganh.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                cbboxKhoa.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
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
    }
}
