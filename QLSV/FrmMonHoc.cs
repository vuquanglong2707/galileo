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
    public partial class FrmMonHoc : Form
    {
        public FrmMonHoc()
        {
            InitializeComponent();
        }
        MonHoc a = new MonHoc();
        KhoaDT b = new KhoaDT();
        static Boolean click = false;

        private DataTable LoadMonHocTheoChuyenNganh(String machuyennganh,String chuyennganhchung)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHMONHOCTHEOCHUYENNGANH";
                cmd.Parameters.Add(new SqlParameter("@machuyennganh", machuyennganh));
                cmd.Parameters.Add(new SqlParameter("@chuyennganhchung", chuyennganhchung));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        private DataTable LoadTatCaMonHoc()
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LOADTATCAMONHOC";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        private String MaChuyenNganhChung(String makhoa)
        {
            String kq = null;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MACHUYENNGANHCHUNGTHEOKHOA";
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                object result = cmd.ExecuteScalar();
                con.Close();
                if(result!=null)
                {
                    kq = result.ToString();
                }
            }
            return kq;
        }

        private void btLoadMH_Click(object sender, EventArgs e)
        {
            if (radioButtonTatCa.Checked)
            {
                dataGridView1.DataSource = LoadTatCaMonHoc();
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Empty :(");
                }
                else
                {
                    click = true;
                }
            }
            //else if(radioButtonTheoKhoa.Checked)
            //{
            //    if (cbboxLoadChuyenNganh.Text != "")
            //    {
            //        if(MaChuyenNganhChung(cbboxchonkhoa.SelectedValue.ToString())==null)
            //        {
            //            MessageBox.Show("Cảnh báo. Ko Tìm Thấy Những Môn Học Chung Của Khoa :"+cbboxchonkhoa.Text);
            //        }
            //        dataGridView1.DataSource = LoadMonHocTheoChuyenNganh(cbboxLoadChuyenNganh.SelectedValue.ToString(), MaChuyenNganhChung(cbboxchonkhoa.SelectedValue.ToString()));
            //        if(dataGridView1.Rows.Count==0)
            //        {
            //            MessageBox.Show("Empty :(");
            //        }
            //        else
            //        {
            //            click = true;
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Empty CN :(");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Hãy Lựa Chọn");
            //}
        }

        private void btThemMH_Click(object sender, EventArgs e)
        {
            if(txtMaMonHocThemMoi.Text=="")
            {
                MessageBox.Show("Bạn Chưa nhập Mã MH");
            }
            else
            {
                if(a.checkTrungMMH(txtMaMonHocThemMoi.Text)==true)
                {
                    if (radioMonHocTheoKhoa.Checked)
                    {
                        a.AddMonHoc(txtMaMonHocThemMoi.Text, txtTenMH.Text, numericUpSoTC.Value.ToString(), numericUpDownHocKyThu.Value.ToString(), cbboxChuyenNganh.SelectedValue.ToString());
                        txtMaMonHocThemMoi.Clear();
                        txtTenMH.Clear();
                        numericUpSoTC.Value = 1;
                        numericUpDownHocKyThu.Value = 1;
                        MessageBox.Show("Thêm Thành Công");
                        click = true;
                    }
                    else
                    {
                        a.AddMonHocChung(txtMaMonHocThemMoi.Text, txtTenMH.Text, numericUpSoTC.Value.ToString(), numericUpDownHocKyThu.Value.ToString());
                        txtMaMonHocThemMoi.Clear();
                        txtTenMH.Clear();
                        numericUpSoTC.Value = 1;
                        numericUpDownHocKyThu.Value = 1;
                        MessageBox.Show("Thêm Thành Công");
                        click = true;
                    }
                }
                else
                {
                    MessageBox.Show("Trùng MMH");
                }
            }
        }

        private void FrmMonHoc_Load(object sender, EventArgs e)
        {
            //cbboxchonkhoa.Enabled = false;
            KhoaDT khoa = new KhoaDT();
            DataSet ds1 = new DataSet();
            ds1 = khoa.Loadkhoa();
            cbboxKhoa.DataSource = ds1.Tables[0];
            cbboxKhoa.DisplayMember = "Tenkhoa";
            cbboxKhoa.ValueMember = "Makhoa";

            DataSet ds2 = new DataSet();
            ds2 = khoa.Loadkhoa();
            cbboxKhoa1.DataSource = ds2.Tables[0];
            cbboxKhoa1.DisplayMember = "Tenkhoa";
            cbboxKhoa1.ValueMember = "Makhoa";

            DataSet ds3 = new DataSet();
            ds3 = khoa.Loadkhoa();
            //cbboxchonkhoa.DataSource = ds3.Tables[0];
            //cbboxchonkhoa.DisplayMember = "Tenkhoa";
            //cbboxchonkhoa.ValueMember = "Makhoa";


           


            DataTable dt2 = new DataTable();
            dt2 = TatCaChuyenNganh();
            cbboxChuyenNganh1.DataSource = dt2;
            cbboxChuyenNganh1.DisplayMember = "TenChuyenNganh";
            cbboxChuyenNganh1.ValueMember = "MaChuyenNganh";




            radioMonHocTheoKhoa.Checked=true;
            radioMonHocTheoKhoa2.Checked = true;
        }

        private void btXoaMH_Click(object sender, EventArgs e)
        {
            if(txtMaMH1.Text=="")
            {
                MessageBox.Show("Hãy Chọn 1 môn học nào đó");
            }
            else
            {
                try
                {
                    a.deleteMH(txtMaMH1.Text);
                    txtMaMH1.Clear();
                    txtTenMH1.Clear();
                    numericUpDownSoTC1.Value = 1;
                    numericUpDownHocKyThu1.Value = 1;
                    MessageBox.Show("Done :)");
                    click = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btsuaMH_Click(object sender, EventArgs e)
        {
            if (txtMaMH1.Text == "")
            {
                MessageBox.Show("Hãy Chọn 1 môn học nào đó");
            }
            else
            {
                if (radioMonHocTheoKhoa2.Checked)
                {
                    a.updateMonHoc(txtMaMH1.Text, txtTenMH1.Text, numericUpDownSoTC1.Value.ToString(), numericUpDownHocKyThu1.Value.ToString(), cbboxChuyenNganh1.SelectedValue.ToString());
                    txtMaMH1.Clear();
                    txtTenMH1.Clear();
                    numericUpDownSoTC1.Value = 1;
                    numericUpDownHocKyThu1.Value = 1;
                    MessageBox.Show("Done :)");
                    
                    click = true;
                }
                else
                {
                    String c = null;
                    a.updateMonHoc(txtMaMH1.Text, txtTenMH1.Text, numericUpDownSoTC1.Value.ToString(), numericUpDownHocKyThu1.Value.ToString(), c);
                    txtMaMH1.Clear();
                    txtTenMH1.Clear();
                    numericUpDownSoTC1.Value = 1;
                    numericUpDownHocKyThu1.Value = 1;
                    MessageBox.Show("Done :)");
                    dataGridView1.DataSource = a.getTable("select MaMonHoc,TenMonHoc,SoTC,HocKy,TenChuyenNganh from MonHoc left join ChuyenNganh on MonHoc.MaCN=ChuyenNganh.MaChuyenNganh");
                    click = true;
                }
            }
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
                    txtMaMH1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtTenMH1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    numericUpDownSoTC1.Value = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                    numericUpDownHocKyThu1.Value = int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                    if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "")
                    {
                        radioMonHocChung2.Checked = true;
                    }
                    else
                    {
                        cbboxKhoa1.Enabled = true;
                        cbboxChuyenNganh1.Enabled = true;

                        DataTable dt2 = new DataTable();
                        dt2 = TatCaChuyenNganh();
                        cbboxChuyenNganh1.DataSource = dt2;
                        cbboxChuyenNganh1.DisplayMember = "TenChuyenNganh";
                        cbboxChuyenNganh1.ValueMember = "MaChuyenNganh";

                        cbboxChuyenNganh1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                        cbboxKhoa1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                        radioMonHocTheoKhoa2.Checked = true;
                    }
                }
            }
        }

        private void radioButtonTheoKhoa_CheckedChanged(object sender, EventArgs e)
        {
            //cbboxchonkhoa.Enabled = true;
            //cbboxLoadChuyenNganh.Enabled = true;
        }

        private void radioButtonTatCa_CheckedChanged(object sender, EventArgs e)
        {
            //cbboxchonkhoa.Enabled = false;
            //cbboxLoadChuyenNganh.Enabled = false;
        }

        private void radioMonHocTheoKhoa_CheckedChanged(object sender, EventArgs e)
        {
            cbboxKhoa.Enabled = true;
            cbboxChuyenNganh.Enabled = true;
        }

        private void radioMonHocChung_CheckedChanged(object sender, EventArgs e)
        {
            cbboxKhoa.Enabled = false;
            cbboxChuyenNganh.Enabled = false;
        }

        private void radioMonHocChung2_CheckedChanged(object sender, EventArgs e)
        {
            cbboxKhoa1.Enabled = false;
            cbboxChuyenNganh1.Enabled = false;
        }

        private void radioMonHocTheoKhoa2_CheckedChanged(object sender, EventArgs e)
        {
            cbboxKhoa1.Enabled = true;
            cbboxChuyenNganh1.Enabled = true;
        }

        private DataTable ChuyenNganhTheoKhoa(String makhoa)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHCHUYENNGANH";
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        private DataTable TatCaChuyenNganh()
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHCHUYENNGANHTATCA";
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
                DataTable dt2 = new DataTable();
                dt2 = ChuyenNganhTheoKhoa(t);
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("Empty :(");
                    cbboxChuyenNganh.DataSource = null;
                }
                else
                {
                    cbboxChuyenNganh.DataSource = dt2;
                    cbboxChuyenNganh.DisplayMember = "TenChuyenNganh";
                    cbboxChuyenNganh.ValueMember = "MaChuyenNganh";
                }
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
                DataTable dt2 = new DataTable();
                dt2 = ChuyenNganhTheoKhoa(t);
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show("Empty :(");
                    cbboxChuyenNganh1.DataSource = null;
                }
                else
                {
                    cbboxChuyenNganh1.DataSource = dt2;
                    cbboxChuyenNganh1.DisplayMember = "TenChuyenNganh";
                    cbboxChuyenNganh1.ValueMember = "MaChuyenNganh";
                }
            }
        }

        private void cbboxchonkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String t;
            ////t = cbboxchonkhoa.SelectedValue.ToString();
            //if (t == "System.Data.DataRowView")
            //{

            //}
            //else
            //{
            //    DataTable dt2 = new DataTable();
            //    dt2 = ChuyenNganhTheoKhoa(t);
            //    if (dt2.Rows.Count == 0)
            //    {
            //        MessageBox.Show("Empty :(");
            //        cbboxLoadChuyenNganh.DataSource = null;
            //    }
            //    else
            //    {
            //        cbboxLoadChuyenNganh.DataSource = dt2;
            //        cbboxLoadChuyenNganh.DisplayMember = "TenChuyenNganh";
            //        cbboxLoadChuyenNganh.ValueMember = "MaChuyenNganh";
            //    }
            //}
        }

        private String makhoa(String machuyennganh)
        {
            String kq = null;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MAKHOA";
                cmd.Parameters.Add(new SqlParameter("@machuyennganh", machuyennganh));
                var result = cmd.ExecuteScalar();
                con.Close();
                if (result != null)
                {
                    kq = result.ToString();
                }
            }
            return kq;
        }

        private void cbboxChuyenNganh1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t = cbboxChuyenNganh1.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                KhoaDT a = new KhoaDT();
                cbboxKhoa1.Text =a.tenkhoa(makhoa(t));
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
