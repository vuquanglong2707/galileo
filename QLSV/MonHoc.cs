using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BaiTapLonN6
{
    class MonHoc
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

        public DataSet LoadMonHocselect(int Hocky,int makhoa)
        {
            DataSet data = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHMONHOCTHEOKHOATHEOKY";
                cmd.Parameters.Add(new SqlParameter("@hocky", Hocky));
                cmd.Parameters.Add(new SqlParameter("@makhoa", makhoa));
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public Boolean checkTrungMMH(String MMH)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[MonHoc] where MaMonHoc=@MMH";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@MMH", MMH));
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

        public void deleteMH(String MMH)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "delete from MonHoc where MaMonHoc=@MMH";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@MMH", MMH));
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable SearchMaMonHoc(String MMH)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select * from MonHoc where MaMonHoc=@MMH";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@MMH", MMH));
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        public DataTable SearchTenMH(String MMH)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select * from MonHoc where TenMonHoc=@MMH";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@MMH", MMH));
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        public void updateMonHoc(String MMH,String TenMonHoc,String SoTC,String HocKy,String machuyennganh)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "update MonHoc set TenMonHoc=@TenMonHoc,SoTC=@SoTC,HocKy=@HocKy,MaCN=@machuyennganh where MaMonHoc=@MMH";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@MMH", MMH));
                cmd.Parameters.Add(new SqlParameter("@TenMonHoc", TenMonHoc));
                cmd.Parameters.Add(new SqlParameter("@SoTC", SoTC));
                cmd.Parameters.Add(new SqlParameter("@HocKy", HocKy));
                if (String.IsNullOrEmpty(machuyennganh))
                {
                    cmd.Parameters.Add(new SqlParameter("@machuyennganh", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@machuyennganh", machuyennganh));
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void AddMonHoc(String MMH, String TenMonHoc, String SoTC, String HocKy, String machuyennganh)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "insert into MonHoc(MaMonHoc,TenMonHoc,SoTC,HocKy,MaCN) values(@MMH,@TenMonHoc,@SoTC,@HocKy,@machuyennganh)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@MMH", MMH));
                cmd.Parameters.Add(new SqlParameter("@TenMonHoc", TenMonHoc));
                cmd.Parameters.Add(new SqlParameter("@SoTC", SoTC));
                cmd.Parameters.Add(new SqlParameter("@HocKy", HocKy));
                cmd.Parameters.Add(new SqlParameter("@machuyennganh", machuyennganh));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void AddMonHocChung(String MMH, String TenMonHoc, String SoTC, String HocKy)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "insert into MonHoc(MaMonHoc,TenMonHoc,SoTC,HocKy) values(@MMH,@TenMonHoc,@SoTC,@HocKy)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@MMH", MMH));
                cmd.Parameters.Add(new SqlParameter("@TenMonHoc", TenMonHoc));
                cmd.Parameters.Add(new SqlParameter("@SoTC", SoTC));
                cmd.Parameters.Add(new SqlParameter("@HocKy", HocKy));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


    }
}
