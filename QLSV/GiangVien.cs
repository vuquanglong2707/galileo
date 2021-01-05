using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BaiTapLonN6
{
    class GiangVien
    {
        public void ExecuteNonQuery(String sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public DataTable TenGiangVien(String Makhoa)
        {
            DataTable data=new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select HoTen from GiangVien where Khoa=" + Makhoa;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        public DataTable DanhSachTatCaGVThemTaiKhoan(String Makhoa)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select GiangVien.MGV,GiangVien.HoTen,Canbo.Username from GiangVien left join Canbo on CAST(GiangVien.MGV AS varchar(8)) = Canbo.Username where GiangVien.Khoa ="+Makhoa;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public DataTable DanhSachTatCaSVThemTaiKhoan(String malop)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select SinhVien.MSV,SinhVien.HoTen,Canbo.Username from SinhVien left join Canbo on CAST(SinhVien.MSV AS varchar(8)) = Canbo.Username where SinhVien.Malop = "+malop;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public Boolean checkCMDN(String CMND)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[GiangVien] where CMND=@CMND";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@CMND", CMND));
            int x = (int)cmd.ExecuteScalar();
            //int x = (int)cmd.ExecuteNonQuery(); 
            if (x == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean checkMGV(String MGV)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[GiangVien] where MGV=@MGV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@MGV", MGV));
            int x = (int)cmd.ExecuteScalar();
            //int x = (int)cmd.ExecuteNonQuery(); 
            if (x == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean checkCMDNsuaGV(String CMND, String MGV)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[GiangVien] where CMND=@CMND and MGV!=@MGV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@CMND", CMND));
            cmd.Parameters.Add(new SqlParameter("@MGV", MGV));
            int x = (int)cmd.ExecuteScalar();
            //int x = (int)cmd.ExecuteNonQuery(); 
            if (x == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public DataTable getTable(String sql)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlDataAdapter Adapter = new SqlDataAdapter(sql, con);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public void deleteGV(int mgv)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "delete from GiangVien where MGV=@mgv";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@mgv", SqlDbType.Int, 10);
            cmd.Parameters["@mgv"].Value = mgv;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddGiangVienAnhHS(String MGV,byte[] img,String HoTen,String GioiTinh,String NgaySinh,String SDT,String CMND,String Email,String ChuyenMon,int Khoa)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "insert into GiangVien(MGV,AnhHoSo,HoTen,GioiTinh,NgaySinh,SDT,CMND,Email,ChuyenMon,Khoa) values (@MGV,@img,@HoTen,@GioiTinh,@NgaySinh,@SDT,@CMND,@Email,@ChuyenMon,@Khoa)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                cmd.Parameters.Add(new SqlParameter("@MGV", MGV));
                cmd.Parameters.Add(new SqlParameter("@HoTen", HoTen));
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", GioiTinh));
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", NgaySinh));
                cmd.Parameters.Add(new SqlParameter("@SDT", SDT));
                cmd.Parameters.Add(new SqlParameter("@CMND", CMND));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@ChuyenMon", ChuyenMon));
                cmd.Parameters.Add(new SqlParameter("@Khoa", Khoa));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void AddGiangVienKoAnhHS(String MGV,String HoTen, String GioiTinh, String NgaySinh, String SDT, String CMND, String Email, String ChuyenMon, int Khoa)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "insert into GiangVien(MGV,HoTen,GioiTinh,NgaySinh,SDT,CMND,Email,ChuyenMon,Khoa) values (@MGV,@HoTen,@GioiTinh,@NgaySinh,@SDT,@CMND,@Email,@ChuyenMon,@Khoa)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@MGV", MGV));
                cmd.Parameters.Add(new SqlParameter("@HoTen", HoTen));
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", GioiTinh));
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", NgaySinh));
                cmd.Parameters.Add(new SqlParameter("@SDT", SDT));
                cmd.Parameters.Add(new SqlParameter("@CMND", CMND));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@ChuyenMon", ChuyenMon));
                cmd.Parameters.Add(new SqlParameter("@Khoa", Khoa));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void updateGiangVienANHHS(String MGV, byte[] img, String HoTen, String GioiTinh, String NgaySinh, String SDT, String CMND, String Email, String ChuyenMon, int Khoa)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "update GiangVien set AnhHoSo=@img,HoTen=@HoTen,GioiTinh=@GioiTinh,NgaySinh=@NgaySinh,SDT=@SDT,CMND=@CMND,Email=@Email,ChuyenMon=@ChuyenMon,Khoa=@Khoa where MGV=@MGV";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                cmd.Parameters.Add(new SqlParameter("@MGV", MGV));
                cmd.Parameters.Add(new SqlParameter("@HoTen", HoTen));
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", GioiTinh));
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", NgaySinh));
                cmd.Parameters.Add(new SqlParameter("@SDT", SDT));
                cmd.Parameters.Add(new SqlParameter("@CMND", CMND));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@ChuyenMon", ChuyenMon));
                cmd.Parameters.Add(new SqlParameter("@Khoa", Khoa));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void updateGiangVienKoANHHS(String MGV, String HoTen, String GioiTinh, String NgaySinh, String SDT, String CMND, String Email, String ChuyenMon, int Khoa)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "update GiangVien set HoTen=@HoTen,GioiTinh=@GioiTinh,NgaySinh=@NgaySinh,SDT=@SDT,CMND=@CMND,Email=@Email,ChuyenMon=@ChuyenMon,Khoa=@Khoa where MGV=@MGV";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@MGV", MGV));
                cmd.Parameters.Add(new SqlParameter("@HoTen", HoTen));
                cmd.Parameters.Add(new SqlParameter("@GioiTinh", GioiTinh));
                cmd.Parameters.Add(new SqlParameter("@NgaySinh", NgaySinh));
                cmd.Parameters.Add(new SqlParameter("@SDT", SDT));
                cmd.Parameters.Add(new SqlParameter("@CMND", CMND));
                cmd.Parameters.Add(new SqlParameter("@Email", Email));
                cmd.Parameters.Add(new SqlParameter("@ChuyenMon", ChuyenMon));
                cmd.Parameters.Add(new SqlParameter("@Khoa", Khoa));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public DataTable SearchMGV(String tk)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select MGV,AnhHoSo,HoTen,GioiTinh,NgaySinh,CMND,SDT,Email,ChuyenMon,TenKhoa from GiangVien,Khoa where GiangVien.Khoa=Khoa.MaKhoa and GiangVien.MGV=@MGV";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@MGV", tk));
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        public DataTable SearchHoTenGV(String tk)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select MGV,AnhHoSo,HoTen,GioiTinh,NgaySinh,CMND,SDT,Email,ChuyenMon,TenKhoa from GiangVien,Khoa where GiangVien.Khoa=Khoa.MaKhoa and dbo.ufn_removeMark(HoTen)=@MGV";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@MGV", tk));
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

    }
}
