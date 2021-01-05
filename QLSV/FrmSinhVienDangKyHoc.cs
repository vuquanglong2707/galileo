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
    public partial class FrmSinhVienDangKyHoc : Form
    {
        private String msvien;
        static String MMH;
        public FrmSinhVienDangKyHoc(String user)
        {
            InitializeComponent();
            this.msvien=user;

        }

        private int Makhoa(String msv)
        {
            int makhoa;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MaKhoaSV";
                cmd.Parameters.Add(new SqlParameter("@msv", msv));
                var result = cmd.ExecuteScalar();
                con.Close();
                if (result.ToString() == null)
                {
                    makhoa = 0;
                }
                else
                {
                    makhoa = (int)result;
                }

            }
            return makhoa;
        }


        private DataTable LoadMonHoc(int makhoa)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LIST_MonHocTheoKhoa";
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        private DataTable LoadLopMo(String mmh)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LIST_LOPHOCTHEOMONHOC";
                cmd.Parameters.Add(new SqlParameter("@mmh", mmh));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }


        private void FrmSinhVienDangKyHoc_Load(object sender, EventArgs e)
        {

            MMH = null;
            int mk = Makhoa(msvien);
            if (mk == 0)
            {
                MessageBox.Show("Đã Có Lỗi Xảy Ra. Không Xác Định Được Khoa Của Sinh Viên");
            }
            else
            {
                cbboxMonHoc.DataSource = LoadMonHoc(mk);
                cbboxMonHoc.DisplayMember = "TenMonHoc";
                cbboxMonHoc.ValueMember = "MaMonHoc";
            }
            dataGridView2.DataSource = KetQUADANGKY(DSCACLOPHOCDANGKY(msvien));

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chk);
            chk.HeaderText = "Chọn";
            chk.Name = "chk";


            DataGridViewCheckBoxColumn chk2 = new DataGridViewCheckBoxColumn();
            dataGridView2.Columns.Add(chk2);
            chk2.HeaderText = "Chọn";
            chk2.Name = "chk2";

            dataGridView3.DataSource = TongCong(dataGridView2);
        }
        private List<String> DSCACLOPHOCDANGKY(String msv)
        {
            List<String> Arr = new List<String>();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHLOP_DK";
                cmd.Parameters.Add(new SqlParameter("@masinhvien", msv));
                SqlDataReader rdr=cmd.ExecuteReader();
                while(rdr.Read())
                {
                    String MH = rdr[0].ToString();
                    Arr.Add(MH);
                }
                con.Close();
            }
            return Arr;
        }

        private double? SoTien(String malophocphan)
        {
            double? Sotien;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SOTIEN1TC_SINHVIENDKHOC";
                cmd.Parameters.Add(new SqlParameter("@malophocphan", malophocphan));
                var result = cmd.ExecuteScalar();
                con.Close();
                if (result.ToString()=="")
                {
                    Sotien = 306500;
                }
                else
                {
                    Sotien = (double)result;
                }
            }
            return Sotien;
        }


        private DataTable TongCong(DataGridView datag)
        {
            DataTable data = new DataTable();
            data.Columns.Add("Tong");
            data.Columns.Add("TongSoTC");
            data.Columns.Add("TongHocPhi");
            if (datag.Rows.Count == 0)
            {
                DataRow row = data.NewRow();
                row["Tong"] = "Tổng";
                row["TongSoTC"] = 0;
                row["TongHocPhi"] = 0;
                data.Rows.Add(row);
            }
            else
            {
                int? TongSoTC=0;
                double? TongHocPhi=0;
                for (int i = 0; i < datag.Rows.Count; i++)
                {
                    TongSoTC = TongSoTC + int.Parse(datag.Rows[i].Cells["SoTCG"].Value.ToString());
                    TongHocPhi = TongHocPhi + double.Parse(datag.Rows[i].Cells["HocPhi"].Value.ToString());
                }
                DataRow row = data.NewRow();
                row["Tong"] = "Tổng";
                row["TongSoTC"] = TongSoTC;
                row["TongHocPhi"] = TongHocPhi;
                data.Rows.Add(row);
            }
            return data;
        }




        private DataTable KetQUADANGKY(List<String> arr)
        {
            DataTable data = new DataTable();
            data.Columns.Add("MaLopHP");
            data.Columns.Add("TenLopHp");
            data.Columns.Add("TenMonHoc");
            data.Columns.Add("ThoiGian");
            data.Columns.Add("DiaDiem");
            data.Columns.Add("SiSo");
            data.Columns.Add("DaDangKy");
            data.Columns.Add("SoTC");
            data.Columns.Add("HocPhi");
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                foreach (String item in arr)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DANHSACHLOP_HIENTHIDADANGKY";
                    cmd.Parameters.Add(new SqlParameter("@malop", item));
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        String MaLopHP = rdr["MaLopHP"].ToString();
                        String TenLopHp = rdr["TenLopHp"].ToString();
                        String TenMonHoc = rdr["TenMonHoc"].ToString();
                        String ThoiGian = rdr["ThoiGian"].ToString();
                        String DiaDiem = rdr["DiaDiem"].ToString();
                        String SiSo = rdr["SiSo"].ToString();
                        String DaDangKy = rdr["DaDangKy"].ToString();
                        String SoTC = rdr["SoTC"].ToString();
                        double? HP = SoTien(MaLopHP) * int.Parse(SoTC);
                        DataRow row = data.NewRow();
                        row["MaLopHP"] = MaLopHP;
                        row["TenLopHp"] = TenLopHp;
                        row["TenMonHoc"] = TenMonHoc;
                        row["ThoiGian"] = ThoiGian;
                        row["DiaDiem"] = DiaDiem;
                        row["SiSo"] = SiSo;
                        row["DaDangKy"] = DaDangKy;
                        row["SoTC"] = SoTC;
                        row["HocPhi"] = HP;
                        data.Rows.Add(row);
                    }
                    con.Close();
                }
            }
            return data;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (cbboxMonHoc.Text == "")
            {
                MessageBox.Show("Empty");
            }
            else
            {
                dataGridView1.DataSource = LoadLopMo(cbboxMonHoc.SelectedValue.ToString());
                MMH = cbboxMonHoc.SelectedValue.ToString();
            }
        }

        private void Dangky(String msv,String MLH)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DangKY_LopHoc";
                cmd.Parameters.Add(new SqlParameter("@masinhvien", msv));
                cmd.Parameters.Add(new SqlParameter("@malophoc", MLH));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void HuyDangky(String msv, String MLH)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HuyDangKY_LopHoc";
                cmd.Parameters.Add(new SqlParameter("@masinhvien", msv));
                cmd.Parameters.Add(new SqlParameter("@malophoc", MLH));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }



        private Boolean DaDangKyLopNayHayChua(String MaLopHoc,String msv)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "KIEMTRADADANGKYLOPNAYCHUA";
                cmd.Parameters.Add(new SqlParameter("@malophoc", MaLopHoc));
                cmd.Parameters.Add(new SqlParameter("@msv", msv));
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

        private Boolean DaDangKyLopMONHOCNayHayChua(String mamonhoc,String msv)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "KIEMTRADADANGKYLOPMONHOCNAYCHUA";
                cmd.Parameters.Add(new SqlParameter("@mamonhoc", mamonhoc));
                cmd.Parameters.Add(new SqlParameter("@msv", msv));
                int result = (int)cmd.ExecuteScalar();
                con.Close();
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private int Sothangdadangkyvaocailopnay(String malop)
        {
            int number;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SoTHANGDADANGKYLOPNAY";
                cmd.Parameters.Add(new SqlParameter("@malop", malop));
                number = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return number;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Ko Có Gì Hết");
            }
            else
            {
                String LopHoc = null;
                int check = 0;
                int siso = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["chk"].Value == null)
                    {

                    }
                    else
                    {
                        bool checkedCell = (bool)dataGridView1.Rows[i].Cells["chk"].Value;
                        if (checkedCell == true)
                        {
                            check++;
                            LopHoc = dataGridView1.Rows[i].Cells["MaLop"].Value.ToString();
                            siso = int.Parse(dataGridView1.Rows[i].Cells["SiSo"].Value.ToString());
                        }
                    }
                    if (i == dataGridView1.Rows.Count - 1)
                    {
                        if (check > 1)
                        {
                            MessageBox.Show("Tôi xin anh. Anh chọn 1 lớp thôi :(");
                        }
                        else if (check == 0)
                        {
                            MessageBox.Show("Bạn chưa Chọn Lớp.");
                        }
                        else
                        {
                            if (DaDangKyLopNayHayChua(LopHoc, msvien) == true)
                            {
                                if (DaDangKyLopMONHOCNayHayChua(MMH, msvien) == true)
                                {
                                    if (Sothangdadangkyvaocailopnay(LopHoc) == siso)
                                    {
                                        MessageBox.Show("Lớp này đã đủ sĩ số.. hãy chọn lớp khác");
                                    }
                                    else
                                    {
                                        if (KIEMTRA_SINHVIENDANGKYHOC(msvien, MMH)==true)
                                        {
                                            Dangky(msvien, LopHoc);
                                            MessageBox.Show("ĐK Thành Công. Bạn Hãy Kiểm Tra Ở Kết Quả Đăng Ký");
                                            dataGridView2.DataSource = KetQUADANGKY(DSCACLOPHOCDANGKY(msvien));
                                            dataGridView3.DataSource = TongCong(dataGridView2);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Môn Học Này Bạn Ko Học Lại Và Điểm Không Quá Yếu Để Không Phải Học Cải Thiện.");
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Bạn Đã Đăng Ký Môn học Này Rồi");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Bạn Đã Đăng Ký Lớp Này Rồi. Hãy Kiểm Tra Kết Quả");
                            }
                        }
                    }
                }
            }
        }

        private Boolean KIEMTRA_SINHVIENDANGKYHOC(String msv,String mamonhoc)
        {
            Boolean kq = true;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "KIEMTRA_SINHVIENDANGKYHOC";
                cmd.Parameters.Add(new SqlParameter("@msv", msv));
                cmd.Parameters.Add(new SqlParameter("@mamonhoc", mamonhoc));
                SqlDataReader rdr= cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var result = rdr["Diemchu"];
                    if (result == null || result.ToString() == "F" || result.ToString() == "D" || result.ToString() == "D+")
                    {
                        kq= true;
                    }
                    else
                    {
                        kq = false;
                    }
                }
                con.Close();
            }
            return kq;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("Ko Có Gì Hết");
            }
            else
            {
                String LopHoc = null;
                int check = 0;
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells["chk2"].Value == null)
                    {

                    }
                    else
                    {
                        bool checkedCell = (bool)dataGridView2.Rows[i].Cells["chk2"].Value;
                        if (checkedCell == true)
                        {
                            check++;
                            LopHoc = dataGridView2.Rows[i].Cells["Malop2"].Value.ToString();
                        }
                    }
                    if (i == dataGridView2.Rows.Count - 1)
                    {
                        if (check > 1)
                        {
                            MessageBox.Show("Bạn Chỉ Có Thể Hủy Từng Lớp 1 :(");
                        }
                        else if (check == 0)
                        {
                            MessageBox.Show("Bạn chưa Chọn Lớp.");
                        }
                        else
                        {
                            HuyDangky(msvien, LopHoc);
                            MessageBox.Show("Hủy Thành Công. Lớp Trống ra 1 thằng :) hahaa");
                            dataGridView2.DataSource = KetQUADANGKY(DSCACLOPHOCDANGKY(msvien));
                            dataGridView3.DataSource = TongCong(dataGridView2);
                        }
                    }
                }
            }
        }

        private void dataGridView3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView3.ClearSelection();
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
