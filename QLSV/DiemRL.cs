using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BaiTapLonN6
{
    class DiemRL
    {
        public DataTable LoadDanhSachSinhVien(int Malop)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select MSV,Hoten,Tenlop,NamNhapHoc from SinhVien inner join Lop on SinhVien.Malop=Lop.Malop and SinhVien.Malop=" + Malop;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }


        public DataTable XemDiemRLQHSV(String MSV)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select SinhVien.MSV,SinhVien.HoTen,DiemRL.Namhoc,DiemRL.Hocky,DiemRL.Tongdiem,DiemRL.Xeploai from SinhVien, DiemRL where SinhVien.MSV = @MSV and SinhVien.MSV = DiemRL.MSVien";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@MSV", MSV));
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(dt);
                con.Close();
            }
            return dt;
        }

        public DataTable Danhsachnamhoc(int NamNhapHoc)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Nam", typeof(String));
            for (int i = NamNhapHoc; i < NamNhapHoc + 4; i++)
            {
                String _ravi = i+" - "+(i+1);
                dt.Rows.Add(_ravi);
            }
            return dt;
        }

        public int NamNhapHoc(String MSV)
        {
            int NamNhapHoc;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String Sql = "Select NamNhapHoc from SinhVien where MSV=@MSV";
                SqlCommand cmd = new SqlCommand(Sql,con);
                cmd.Parameters.Add(new SqlParameter("@MSV", MSV));
                NamNhapHoc = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return NamNhapHoc;
        }

        public int NamNhapHoc2(String malop)
        {
            int NamNhapHoc;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String Sql = "select NamNhapHoc from SinhVien where Malop=@malop";
                SqlCommand cmd = new SqlCommand(Sql, con);
                cmd.Parameters.Add(new SqlParameter("@malop", malop));
                NamNhapHoc = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return NamNhapHoc;
        }


        public DataTable DanhsachnamhocSVXemDiem(int NamNhapHoc)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Nam", typeof(String));
            dt.Columns.Add("HocKyThu", typeof(Int32));
            int hocky = 1;
            for (int i = NamNhapHoc; i < NamNhapHoc + 4; i++)
            {
                int hk = 1;
                String _ravi = i + " - " + (i + 1)+"_"+hk;
                dt.Rows.Add(_ravi, hocky);
                hocky++;
                hk++;
                String _ravi2 = i + " - " + (i + 1) + "_" + hk;
                dt.Rows.Add(_ravi2, hocky);
                String _ravi3 = i + " - " + (i + 1);
                dt.Rows.Add(_ravi3);
                hocky++;
            }
            return dt;
        }

        public DataTable DanhsachnamhocSVXemDiem123(int NamNhapHoc)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Nam", typeof(String));
            dt.Columns.Add("HocKyThu", typeof(Int32));
            int hocky = 1;
            for (int i = NamNhapHoc; i < NamNhapHoc + 4; i++)
            {
                int hk = 1;
                String _ravi = i + " - " + (i + 1) + "_" + hk;
                dt.Rows.Add(_ravi, hocky);
                hocky++;
                hk++;
                String _ravi2 = i + " - " + (i + 1) + "_" + hk;
                dt.Rows.Add(_ravi2, hocky);
                hocky++;
            }
            return dt;
        }


        public DataTable DanhsachnamhocDiem(int NamNhapHoc)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Nam", typeof(String));
            dt.Columns.Add("HocKy", typeof(Int32));
            int _HK = 2;
            for (int i = NamNhapHoc; i < NamNhapHoc + 4; i++)
            {
                String _ravi = i + " - " + (i + 1);
                dt.Rows.Add(_ravi,_HK);
                _HK = _HK + 2;
            }
            return dt;
        }

        

        public Boolean KiemtratontaiSV(int malop)
        {
            int a;
            Boolean check;
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*)FROM Sinhvien WHERE Malop="+malop;
            SqlCommand cmd = new SqlCommand(sql, con);
            a=(int)cmd.ExecuteScalar();
            con.Close();
            if(a==0)
            {
                check = false;
            }
            else
            {
                check = true;
            }
            return check;
        }

       

        /*
        public DataTable Danhsachnamhoc(String Lop)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Nam", typeof(String));
            for (int i = NamNhapHoc; i < NamNhapHoc + 4; i++)
            {
                String _ravi = i + " - " + (i + 1);
                dt.Rows.Add(_ravi);
            }
            return dt;
        }
        */

        public DataTable diemrenluyenthoelop(int malop,String namhoc,String hocky)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Masodiem,MSV,Hoten,Tenlop,Namhoc,Hocky,Tongdiem,Xeploai from SinhVien, Lop, DiemRL where SinhVien.MSV=DiemRL.MSVien and SinhVien.Malop=Lop.Malop and SinhVien.Malop=@malop and DiemRL.Namhoc=@namhoc and DiemRL.Hocky=@hocky";
                SqlCommand cmd = new SqlCommand(sql, con);
 
                cmd.Parameters.Add("@namhoc", SqlDbType.NVarChar, 30);
                cmd.Parameters["@namhoc"].Value = namhoc;
                cmd.Parameters.Add("@hocky", SqlDbType.NVarChar, 20);
                cmd.Parameters["@hocky"].Value = hocky;
                cmd.Parameters.Add("@malop", SqlDbType.Int, 10);
                cmd.Parameters["@malop"].Value = malop;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(dt);
                con.Close();
            }
            return dt;
        }
        
        public int Malop(String tenlop) // Lấy ra mã lớp đang chọn
        {
            int malop;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Malop from Lop where Tenlop='" + tenlop + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                malop = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return malop;
        }
        
        public int NamNhapHoc(int Malop) // lấy về năm nhập học của mã lớp dang chọn
        {
            int NamNhapHoc;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select NamNhapHoc from SinhVien where Malop=" + Malop;
                SqlCommand cmd = new SqlCommand(sql, con);
                NamNhapHoc = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return NamNhapHoc;
        }

        public Boolean KiemtraTrung(int msv,String namhoc,String hocky)
        {
            Boolean check;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "SELECT COUNT(*)FROM DiemRL WHERE MSVien=@msv and Namhoc=@namhoc and Hocky=@hocky";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@msv", SqlDbType.Int, 10);
                cmd.Parameters["@msv"].Value = msv;
                cmd.Parameters.Add("@namhoc", SqlDbType.NVarChar, 30);
                cmd.Parameters["@namhoc"].Value = namhoc;
                cmd.Parameters.Add("@hocky", SqlDbType.NVarChar, 20);
                cmd.Parameters["@hocky"].Value = hocky;

                int b = (int)cmd.ExecuteScalar();
                if(b==0)
                {
                    check=true;
                }
                else 
                {
                    check = false;
                }
                con.Close();
            }
            return check;
        }

        public void NhapDiem(int msv,String namhoc,String hocky,int tongdiem)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String xeploai;
                String sql = "insert into DiemRL values(@msv,@namhoc,@hocky,@tongdiem,@xeploai)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@msv", SqlDbType.Int, 10);
                
                cmd.Parameters.Add("@namhoc", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@hocky", SqlDbType.NVarChar, 10);
                cmd.Parameters.Add("@tongdiem", SqlDbType.Int, 4);
                cmd.Parameters.Add("@xeploai", SqlDbType.NVarChar, 10);


                cmd.Parameters["@msv"].Value = msv;
                
                cmd.Parameters["@namhoc"].Value = namhoc;
                cmd.Parameters["@hocky"].Value = hocky;
                cmd.Parameters["@tongdiem"].Value = tongdiem;
                if(tongdiem >= 90)
                {
                    xeploai = "Xuất Sắc";
                }
                else if(tongdiem >= 80 && tongdiem < 90)
                {
                    xeploai = "Tốt";
                }
                else if(tongdiem >= 70 && tongdiem < 80)
                {
                    xeploai = "Khá";
                }
                else
                {

                }
                {
                    xeploai = "Trung Bình";
                }
                cmd.Parameters["@xeploai"].Value = xeploai;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
