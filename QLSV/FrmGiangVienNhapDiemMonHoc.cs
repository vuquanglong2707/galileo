using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonN6
{
    public partial class FrmGiangVienNhapDiemMonHoc : Form
    {
        private String magiangvien;
        private static String duongdan = null;
        static String MMH;
        static String NamHocCuaLopHocPhan;
        public FrmGiangVienNhapDiemMonHoc(String mgv)
        {
            InitializeComponent();
            this.magiangvien = mgv;
        }


        private String MAMONHOCTRONGLOPHOCPHAN(String malophocphan)
        {
            String kq = null;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MAMONHOCTRONGLOPHOCPHAN";
                cmd.Parameters.Add(new SqlParameter("@malophocphan", malophocphan));
                var result = cmd.ExecuteScalar();
                con.Close();
                if (result != null)
                {
                    kq = result.ToString();
                }
            }
            return kq;
        }



        private void FrmGiangVienNhapDiemMonHoc_Load(object sender, EventArgs e)
        {
            NamHocCuaLopHocPhan = null;
            MMH = null;

            duongdan = null;
            cbboxLopHocDangDay.DataSource = DSLOPDAY(magiangvien);
            cbboxLopHocDangDay.DisplayMember = "TenLopHP";
            cbboxLopHocDangDay.ValueMember = "MaLopHP";
        }

        private DataTable DSLOPDAY(String mgv)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACH_CACLOPDANGDAY";
                cmd.Parameters.Add(new SqlParameter("@mgv", mgv));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Select Location";
                dlg.Filter = "Excel Worksheets|*.xlsx";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    duongdan = dlg.FileName.ToString();
                    lblDuongDanFile.Text = duongdan;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXuatExCel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Ko co gi de xuat");
            }
            else
            {
                if (duongdan == null)
                {
                    MessageBox.Show("Bạn Hãy Chọn Nơi Lưu File");
                }
                else
                {
                    if (File.Exists(duongdan))
                    {
                        MessageBox.Show("Đã Có Tên File Này Rồi. Bạn Nên Chọn Tên Khác");
                    }
                    else
                    {
                        FrmLoad a = new FrmLoad(dataGridView1, duongdan);
                        a.Show();
                        duongdan = null;
                        lblDuongDanFile.Text = "";
                    }
                }
            }
        }
        private DataTable LoadSVTRONGLOP(String malophocphan,String namhoc,String mmh)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHSINHVIENTRONGLOPHOCPHAN";
                cmd.Parameters.Add(new SqlParameter("@malop", malophocphan));
                cmd.Parameters.Add(new SqlParameter("@namhoc", namhoc));
                cmd.Parameters.Add(new SqlParameter("@mmh", mmh));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        private String NamHoc(String malophocphan)
        {
            String kq = null;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NAMHOC_LOPHOCPHAN";
                cmd.Parameters.Add(new SqlParameter("@malophocphan", malophocphan));
                var result = cmd.ExecuteScalar();
                if(result==null)
                {

                }
                else
                {
                    kq = result.ToString();
                }
            }
            return kq;
        }



        private void btnloadsv_Click(object sender, EventArgs e)
        {
            if(cbboxLopHocDangDay.Text=="")
            {
                MessageBox.Show("Empty :(((");
            }
            else
            {
                
                MMH = MAMONHOCTRONGLOPHOCPHAN(cbboxLopHocDangDay.SelectedValue.ToString());
                NamHocCuaLopHocPhan = NamHoc(cbboxLopHocDangDay.SelectedValue.ToString());
                dataGridView1.DataSource = LoadSVTRONGLOP(cbboxLopHocDangDay.SelectedValue.ToString(),NamHocCuaLopHocPhan,MMH);
            }
        }

        private int SolanhocCuaSV(String msv,String mmh)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SOLANHOC_SINHVIEN";
                cmd.Parameters.Add(new SqlParameter("@msv", msv));
                cmd.Parameters.Add(new SqlParameter("@mmh", mmh));
                result = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return result;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Empty :((");
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    String MSV = dataGridView1.Rows[i].Cells["MSV"].Value.ToString();
                    int solanhoc = SolanhocCuaSV(MSV, MMH);
                    double? Diem1 = null;
                    double? Diem2 = null;
                    double? DiemThi = null;
                    double? DiemTongKet = null;
                    double? DiemHe4 = null;
                    String DiemChu = null;
                    String DanhGia = null;
                    if (dataGridView1.Rows[i].Cells["DiemKT1"].Value.ToString() != "")
                    {
                        Diem1 = double.Parse(dataGridView1.Rows[i].Cells["DiemKT1"].Value.ToString());
                    }
                    if (dataGridView1.Rows[i].Cells["DiemKT2"].Value.ToString() != "")
                    {
                        Diem2 = double.Parse(dataGridView1.Rows[i].Cells["DiemKT2"].Value.ToString());
                    }
                    if (dataGridView1.Rows[i].Cells["DiemThi"].Value.ToString() != "")
                    {
                        DiemThi = double.Parse(dataGridView1.Rows[i].Cells["DiemThi"].Value.ToString());
                    }
                    if (Diem1 != null && Diem2 != null && DiemThi != null)
                    {
                        if (Diem1 > 10 || Diem2 > 10 || DiemThi > 10)
                        {
                            MessageBox.Show("Cảnh Báo. Điểm Nhập Ko Hợp Lệ: MSV:" + MSV);
                            break;
                        }
                        DiemTongKet = (((Diem1 + Diem2) / 2) * 0.4) + (DiemThi * 0.6);
                        String str = String.Format("{0:00.0}", DiemTongKet);
                        DiemTongKet = double.Parse(str);
                        if (DiemTongKet <= 10.0 && DiemTongKet >= 8.5)
                        {
                            DiemChu = "A";
                            DiemHe4 = 4.0;
                        }
                        else if (DiemTongKet >= 8.0 && DiemTongKet <= 8.4)
                        {
                            DiemChu = "B+";
                            DiemHe4 = 3.5;
                        }
                        else if (DiemTongKet >= 7.0 && DiemTongKet <= 7.9)
                        {
                            DiemChu = "B";
                            DiemHe4 = 3.0;
                        }
                        else if (DiemTongKet >= 6.0 && DiemTongKet <= 6.4)
                        {
                            DiemChu = "C";
                            DiemHe4 = 2.0;
                        }
                        else if (DiemTongKet >= 6.5 && DiemTongKet <= 6.9)
                        {
                            DiemChu = "C+";
                            DiemHe4 = 2.5;
                        }
                        else if (DiemTongKet >= 5.0 && DiemTongKet <= 5.9)
                        {
                            DiemChu = "D+";
                            DiemHe4 = 1.5;
                        }
                        else if (DiemTongKet >= 4.0 && DiemTongKet <= 4.9)
                        {
                            DiemChu = "D";
                            DiemHe4 = 1.0;
                        }
                        else if (DiemTongKet < 4.0)
                        {
                            DiemChu = "F";
                            DiemHe4 = 0;
                        }
                        else
                        {
                            MessageBox.Show("Cảnh Báo. Điểm Nhập Ko Hợp Lệ: MSV:" + MSV);
                            break;
                        }

                        if (DiemChu == "A" || DiemChu == "B" || DiemChu == "B+" || DiemChu == "C+" || DiemChu == "C" || DiemChu == "D+" || DiemChu == "D")
                        {
                            DanhGia = "Đạt";
                        }
                        else
                        {
                            DanhGia = "Chưa Đạt";
                        }
                    }
                    DiemMonHoc a = new DiemMonHoc();
                    if (a.checkDaCoDiem(MSV, MMH, solanhoc, NamHocCuaLopHocPhan) == true)
                    {
                        int lanhocchinhthuc = solanhoc + 1;
                        a.insertDiem(MSV, MMH, lanhocchinhthuc, NamHocCuaLopHocPhan, Diem1, Diem2, DiemThi, DiemTongKet, DiemChu, DiemHe4, DanhGia);
                    }
                    else
                    {
                        a.updateDiem(MSV, MMH, solanhoc, Diem1, Diem2, DiemThi, DiemTongKet, DiemChu, DiemHe4, DanhGia);
                    }
                }
                MessageBox.Show("Hoàn Thành");
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
