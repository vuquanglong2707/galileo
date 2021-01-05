using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BaiTapLonN6
{
    class Lop
    {
        public DataTable LoadLop()
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Lop.Malop,Lop.Tenlop,Khoa.Tenkhoa,KhoaHoc.TenKhoaHoc from Lop left join Khoa on Lop.Makhoa = Khoa.Makhoa left join KhoaHoc on Lop.Khoa = KhoaHoc.MaKhoaHoc";
                //String sql = "select Lop.Malop,Lop.Tenlop,Khoa.Tenkhoa,KhoaHoc.TenKhoaHoc from Lop, Khoa, KhoaHoc where Lop.Makhoa = Khoa.Makhoa and Lop.Khoa = KhoaHoc.MaKhoaHoc";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public DataTable LoadKhoaHoc()
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "Select *, 'Delete' AS [Delete] from KhoaHoc";
                //String sql = "select Lop.Malop,Lop.Tenlop,Khoa.Tenkhoa,KhoaHoc.TenKhoaHoc from Lop, Khoa, KhoaHoc where Lop.Makhoa = Khoa.Makhoa and Lop.Khoa = KhoaHoc.MaKhoaHoc";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public void SuaKhoaHoc(String makhoa,String tenkhoa,String tinhtrang)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "update KhoaHoc set TenKhoaHoc=@tenkhoa,TrangThai=@tinhtrang where MaKhoaHoc=@makhoa";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@tenkhoa", tenkhoa));
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                cmd.Parameters.Add(new SqlParameter("@tinhtrang", tinhtrang));
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void ThemKhoaHoc(String makhoa, String tenkhoa,String trangthai)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "insert into KhoaHoc(MaKhoaHoc,TenKhoaHoc,TrangThai) values(@makhoa,@tenkhoa,@trangthai)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@tenkhoa", tenkhoa));
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                cmd.Parameters.Add(new SqlParameter("@trangthai", trangthai));
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void XoaKhoaHoc(String makhoa)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "delete from KhoaHoc where MaKhoaHoc=@makhoa";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public Boolean checklop(String Tenlop,String malop)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[Lop] where Tenlop=@tenlop and Malop!=@malop";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@tenlop", Tenlop));
            cmd.Parameters.Add(new SqlParameter("@malop", malop));
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


        public Boolean checkthemkhoatrungtenkhoa(String tenkhoa)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[KhoaHoc] where TenKhoaHoc=@tenkhoa";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@tenkhoa", tenkhoa));
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


        public Boolean checkkhoahoc(String Tenkhoahoc, String makhoahoc)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[KhoaHoc] where TenKhoaHoc=@Tenkhoahoc and MaKhoaHoc!=@makhoahoc";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@Tenkhoahoc", Tenkhoahoc));
            cmd.Parameters.Add(new SqlParameter("@makhoahoc", makhoahoc));
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


        public Boolean checklop123(String Tenlop)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[Lop] where Tenlop=@tenlop";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@tenlop", Tenlop));
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


        public Boolean checkmakhoathem(String Makhoa)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[KhoaHoc] where MaKhoaHoc=@makhoahoc";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@makhoahoc", Makhoa));
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

        public DataSet LoadLop1()
        {
            DataSet data = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select * from Lop";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        public String Tenlop(int malop)
        {
            String tenlop;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Tenlop from Lop where Malop=" + malop;
                SqlCommand cmd = new SqlCommand(sql, con);
                tenlop = (String)cmd.ExecuteScalar();
                con.Close();
            }
            return tenlop;
        }
        public int Malop(String tenlop)
        {
            int malop;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Malop from Lop where Tenlop='" + @tenlop + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@tenlop", SqlDbType.NVarChar, 30);
                cmd.Parameters["@tenlop"].Value = tenlop;
                var a = cmd.ExecuteScalar();
                if(a==null)
                {
                    malop = 0;
                }
                else
                {
                    malop = (int)a;
                }
                con.Close();
            }
            return malop;
        }
        public DataSet LoadLopselect(String t)
        {
            DataSet data = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select * from Lop where Makhoa='" + t + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        public void Them(String tenlop, int makhoa,String MKH)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "insert into Lop values(@tenlop,@makhoa,@MKH)";
                SqlCommand cmd = new SqlCommand(sql, con);
                /*
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                */
                cmd.Parameters.Add("@makhoa", SqlDbType.Int, 30);
                cmd.Parameters.Add("@tenlop", SqlDbType.NVarChar, 30);
                cmd.Parameters["@tenlop"].Value = tenlop;
                cmd.Parameters["@makhoa"].Value = makhoa;
                cmd.Parameters.Add(new SqlParameter("@MKH",MKH));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /*
        public DataTable Search(String makhoa)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select * from KhoaDT where Makhoa=@makhoa";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@makhoa", SqlDbType.NVarChar, 20);
                cmd.Parameters["@makhoa"].Value = makhoa;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        */
        public void update(int malop, String tenlop, int makhoa)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "UPDATE Lop SET Tenlop=@tenlop,Makhoa=@makhoa where Malop=@malop";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenlop", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@makhoa", SqlDbType.Int, 30);
            cmd.Parameters.Add("@malop", SqlDbType.Int, 30);
            cmd.Parameters["@tenlop"].Value = tenlop;
            cmd.Parameters["@makhoa"].Value = makhoa;
            cmd.Parameters["@malop"].Value = malop;
            cmd.ExecuteNonQuery();
            con.Close();
        }
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
        public int MaKhoa(String Tenkhoa)
        {
            int makhoa;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Makhoa from Khoa where Tenkhoa=N'" + Tenkhoa + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                makhoa = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return makhoa;
        }

        public void delete(int malop)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "delete from Lop where Malop=@malop";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@malop", SqlDbType.Int, 10);
            cmd.Parameters["@malop"].Value = malop;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Boolean check(int malop)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "select * from SinhVien where Malop=@malop";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@malop", SqlDbType.Int, 10);
            cmd.Parameters["@malop"].Value = malop;
            var a = cmd.ExecuteScalar();
            con.Close();
            if (a == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
