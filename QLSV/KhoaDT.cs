using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BaiTapLonN6
{
    class KhoaDT
    {
        public DataSet Loadkhoa()
        {
            DataSet data = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString)) // 
            {
                con.Open();
                String sql = "select * from Khoa";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public DataTable Loadkhoahoc()
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString)) // 
            {
                con.Open();
                String sql = "select MaKhoaHoc,TenKhoaHoc from KhoaHoc where TrangThai=N'Đang Quản Lý'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public int LayRaNamHocCuaKhoaHoc(String Makhoahoc)
        {
            int kq;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString)) // 
            {
                con.Open();
                String sql = "select NamNhapHoc from SinhVien, Lop, KhoaHoc where SinhVien.Malop = Lop.Malop and Lop.Khoa = KhoaHoc.MaKhoaHoc and KhoaHoc.MaKhoaHoc = @makhoahoc";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@makhoahoc", Makhoahoc));
                var kq1 = cmd.ExecuteScalar();
                con.Close();
                if(kq1!=null)
                {
                    kq = (int)kq1;
                }
                else
                {
                    kq = 0;
                }
            }
            return kq;
        }

        public DataSet LoadkhoaHoc()
        {
            DataSet data = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString)) // 
            {
                con.Open();
                String sql = "select * from KhoaHoc";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public Boolean check(int makhoa) 
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "select * from Lop where Makhoa=@makhoa";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@makhoa", SqlDbType.Int, 10);
            cmd.Parameters["@makhoa"].Value = makhoa;
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

        public String TenKhoa(int makhoa)
        {
            String tenkhoa;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Tenkhoa from Khoa where Makhoa=" + makhoa;
                SqlCommand cmd = new SqlCommand(sql, con);
                tenkhoa = (String)cmd.ExecuteScalar();
                con.Close();
            }
            return tenkhoa;
        }
        public DataTable Loadkhoa2()
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select * from Khoa";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        public void Them(String tenkhoa,String sotien)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "insert into Khoa(Tenkhoa,SoTien1TC) values(@tenkhoa,@sotien)";
                SqlCommand cmd = new SqlCommand(sql, con);
                /*
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                */
                cmd.Parameters.Add("@tenkhoa", SqlDbType.NVarChar, 30);
                cmd.Parameters["@tenkhoa"].Value = tenkhoa;
                cmd.Parameters.Add(new SqlParameter("@sotien",sotien));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public String tenkhoa(String makhoa)
        {
            String tenkhoa = null;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Tenkhoa from Khoa where Makhoa=@makhoa";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@makhoa", SqlDbType.NVarChar, 20);
                cmd.Parameters["@makhoa"].Value = makhoa;
                object result = cmd.ExecuteScalar();
                con.Close();
                if (result != null)
                {
                    tenkhoa = result.ToString();
                }
                con.Close();
            }
            return tenkhoa;
        }

        public String tenkhoa(int makhoa)
        {
            String tenkhoa = "";
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Tenkhoa from Khoa where Makhoa=@makhoa";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@makhoa", SqlDbType.Int, 10);
                cmd.Parameters["@makhoa"].Value = makhoa;
                con.Close();
            }
            return tenkhoa;
        }

        public DataSet Search(String makhoa)
        {
            DataSet data = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select * from Khoa where Makhoa=@makhoa";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@makhoa", SqlDbType.NVarChar, 20);
                cmd.Parameters["@makhoa"].Value = makhoa;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public void update(String makhoa, String tenkhoa,String sotien)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "UPDATE Khoa SET Tenkhoa=@tenkhoa,SoTien1TC=@sotien where Makhoa=@makhoa";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@tenkhoa", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add(new SqlParameter("@sotien", sotien));
            cmd.Parameters.Add("@makhoa", SqlDbType.NVarChar, 20);
            cmd.Parameters["@tenkhoa"].Value = tenkhoa;
            cmd.Parameters["@makhoa"].Value = makhoa;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void delete(String makhoa)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "delete from Khoa where Makhoa=@makhoa";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@makhoa", SqlDbType.NVarChar, 20);
            cmd.Parameters["@makhoa"].Value = makhoa;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int Makhoa(String tenkhoa)
        {
            int makhoa;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Makhoa from Khoa where Tenkhoa=@tenkhoa";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@tenkhoa", SqlDbType.NVarChar, 30);
                cmd.Parameters["@tenkhoa"].Value = tenkhoa;
                makhoa = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return makhoa;
        }
    }
}
