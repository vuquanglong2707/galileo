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
    public partial class FrmNhapDiemRL : Form
    {
        public FrmNhapDiemRL()
        {
            InitializeComponent();
        }

        public Boolean click = false;

        private void FrmNhapDiemRL_Load(object sender, EventArgs e)
        {
            txtTongDiemRL.MaxLength = 3;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            KhoaDT khoa = new KhoaDT();
            DataSet ds1 = new DataSet();
            ds1 = khoa.Loadkhoa();
            cbboxChonkhoa.DataSource = ds1.Tables[0];
            cbboxChonkhoa.DisplayMember = "Tenkhoa";
            cbboxChonkhoa.ValueMember = "Makhoa";
        }

        private void cbboxChonkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxChonkhoa.SelectedValue.ToString();
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

        private void btnLoadSV_Click(object sender, EventArgs e)
        {
            if (cbboxchonlop.Text != "")
            {
                DiemRL a = new DiemRL();
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                Lop b = new Lop();
                dataGridView1.DataSource = a.LoadDanhSachSinhVien(b.Malop(cbboxchonlop.Text));
                click = true;
            }
            else
            {
                MessageBox.Show("Hãy Chọn Lớp");
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
                    txtMSV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtHoten.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    Lop b = new Lop();
                    txtLop.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();


                    DiemRL drl = new DiemRL();
                    DataTable ds1 = new DataTable();

                    String test = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    if (test != "" && int.Parse(test) != 0)
                    {
                        ds1 = drl.Danhsachnamhoc(int.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()));
                        cbboxNamHoc.DataSource = ds1;
                        cbboxNamHoc.DisplayMember = "Nam";
                        cbboxNamHoc.ValueMember = "Nam";
                    }
                    else
                    {
                        MessageBox.Show("Bạn nên cập nhật năm nhập học cho sinh viên này để xác định các năm học của sinh viên");
                    }
                }
            }
        }

        public Boolean TinhTK(String Namhoc,String msv)
        {
     
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "SELECT COUNT(*)FROM DiemRL where NamHoc=@namhoc and MSVien=@msv";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@namhoc", Namhoc));
                cmd.Parameters.Add(new SqlParameter("@msv", msv));
                int kq = (int)cmd.ExecuteScalar();
                con.Close();
                if (kq == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
      
        }
        public int DiemHocKy(String HocKy,String NamHoc,String MSV)
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
        public Boolean KTraTrung(String msv,String namhoc,String hocky)  
        {
            Boolean check;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "SELECT COUNT(*)FROM DiemRL WHERE MSVien=@msv and Namhoc=@namhoc and Hocky=@hocky";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@msv", SqlDbType.NVarChar, 10);
                cmd.Parameters["@msv"].Value = msv;
                cmd.Parameters.Add("@namhoc", SqlDbType.NVarChar, 30);
                cmd.Parameters["@namhoc"].Value = namhoc;
                cmd.Parameters.Add("@hocky", SqlDbType.NVarChar, 20);
                cmd.Parameters["@hocky"].Value = hocky;
                int b = (int)cmd.ExecuteScalar();
                if (b == 0)
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
                con.Close();
            }
            return check;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMSV.Text == "")
            {
                MessageBox.Show("Hãy chọn 1 sinh viên nào đó");
            }
            else
            {
                if (txtTongDiemRL.Text == "")
                {
                    MessageBox.Show("Hãy điền điểm");
                }
                else
                {
                    if (int.Parse(txtTongDiemRL.Text) >= 0 && int.Parse(txtTongDiemRL.Text) <= 100)
                    {
                        Lop a = new Lop();
                        if (radioButtonHK1.Checked)
                        {

                            DiemRL drl = new DiemRL();
                            if (drl.KiemtraTrung(int.Parse(txtMSV.Text), cbboxNamHoc.Text, radioButtonHK1.Text) == true)
                            {
                                drl.NhapDiem(int.Parse(txtMSV.Text), cbboxNamHoc.Text, radioButtonHK1.Text, int.Parse(txtTongDiemRL.Text));
                                MessageBox.Show("Cập Nhật Điểm Thành Công.Chi Tiết : MSV:" + txtMSV.Text + ",Họ Tên:" + txtHoten.Text + ",Lop:" + txtLop.Text + ",Năm Học:" + cbboxNamHoc.Text + "," + radioButtonHK1.Text + ",Điểm:" + txtTongDiemRL.Text);
                                if(TinhTK(cbboxNamHoc.Text,txtMSV.Text)==true)
                                {
                                    int Diem1 = DiemHocKy(radioButtonHK1.Text, cbboxNamHoc.Text, txtMSV.Text);
                                    int Diem2 = DiemHocKy(radioButtonHK2.Text, cbboxNamHoc.Text, txtMSV.Text);
                                    double dtk = ((double)Diem1 + (double)Diem2) / (double)2;
                                    int DiemCaNam = (int)Math.Ceiling(dtk);
                                    if(KTraTrung(txtMSV.Text,cbboxNamHoc.Text,"Cả Năm")==true)
                                    {
                                        drl.NhapDiem(int.Parse(txtMSV.Text), cbboxNamHoc.Text, "Cả Năm", DiemCaNam);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Bạn đã cập nhật điểm cho sinh viên " + txtHoten.Text + " Trong Năm Học Và Học Kỳ Này rồi. Vào Xem Điểm Để Sửa Điểm Lại Nếu Bạn Muốn");
                            }
                        }
                        else if (radioButtonHK2.Checked)
                        {
                            DiemRL drl = new DiemRL();
                            if (drl.KiemtraTrung(int.Parse(txtMSV.Text), cbboxNamHoc.Text, radioButtonHK2.Text) == true)
                            {
                                drl.NhapDiem(int.Parse(txtMSV.Text), cbboxNamHoc.Text, radioButtonHK2.Text, int.Parse(txtTongDiemRL.Text));
                                MessageBox.Show("Cập Nhật Điểm Thành Công.Chi Tiết : MSV:" + txtMSV.Text + ",Họ Tên:" + txtHoten.Text + ",Lop:" + txtLop.Text + ",Năm Học:" + cbboxNamHoc.Text + "," + radioButtonHK2.Text + ",Điểm:" + txtTongDiemRL.Text);
                                if (TinhTK(cbboxNamHoc.Text,txtMSV.Text) == true)
                                {
                                    int Diem1 = DiemHocKy(radioButtonHK1.Text, cbboxNamHoc.Text, txtMSV.Text);
                                    int Diem2 = DiemHocKy(radioButtonHK2.Text, cbboxNamHoc.Text, txtMSV.Text);
                                    double dtk = ((double)Diem1 + (double)Diem2) / (double)2;
                                    int DiemCaNam = (int)Math.Ceiling(dtk);
                                    if (KTraTrung(txtMSV.Text, cbboxNamHoc.Text, "Cả Năm") == true)
                                    {
                                        drl.NhapDiem(int.Parse(txtMSV.Text), cbboxNamHoc.Text, "Cả Năm", DiemCaNam);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Bạn đã cập nhật điểm cho sinh viên " + txtHoten.Text + " Trong Năm Học Và Học Kỳ Này rồi. Vào Xem Điểm Để Sửa Điểm Lại Nếu Bạn Muốn");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hãy chọn 1 học kỳ nào đó");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn Nhập Điểm Ko hợp lệ");
                    }
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

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
