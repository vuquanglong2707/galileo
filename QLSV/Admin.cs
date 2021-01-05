using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace BaiTapLonN6
{
    class Admin
    {
        private String GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }
        public Boolean checktentk(String username)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[Canbo] where Username=@username";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@username", username));
            int x = (int)cmd.ExecuteScalar();
            //int x = (int)cmd.ExecuteNonQuery(); 
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void XoaTaiKhoan(String ID)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "Delete from Canbo where ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@ID", ID));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public DataTable taikhoan(String loaitaikhoan)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "SELECT *,'Delete' AS [Delete] from CanBo where QuyenHan=@quyenhan";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@quyenhan", loaitaikhoan));
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public String Quyenhan(String user,String pass)
        {
            String Quyenhan="";
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT QuyenHan from CanBo where Username=@user and Password=@pass";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.Parameters.Add(new SqlParameter("@pass", pass));
            Quyenhan = (String)cmd.ExecuteScalar();
            con.Close();
            return Quyenhan;
        }
        public Boolean checkpass(String password)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[Canbo] where Password=@password";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@password", password));
            int x = (int)cmd.ExecuteScalar();
            //int x = (int)cmd.ExecuteNonQuery(); 
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean checklog(String username, String password)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CHECK_LOG";
            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            int x = (int)cmd.ExecuteScalar();
            //int x = (int)cmd.ExecuteNonQuery(); 
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean check(String user)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[Canbo] where Username=@username";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@username", user));
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
        public void addadmin(String hoten, String user, String pass,String quyenhan)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "insert into Canbo(Hoten, Username, Password, QuyenHan) values(@hoten, @user, @pass, @quyenhan)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@user", SqlDbType.NVarChar, 100);

                cmd.Parameters["@hoten"].Value = hoten;
                cmd.Parameters["@user"].Value = user;
                cmd.Parameters.Add(new SqlParameter("@pass", pass));
                cmd.Parameters.Add(new SqlParameter("@quyenhan", quyenhan));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
