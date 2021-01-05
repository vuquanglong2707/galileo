using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BaiTapLonN6
{
    class Diachi
    {
        public DataSet Load()
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "select * from Tinh";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, con);
            DataSet data = new DataSet();
            Adapter.Fill(data);
            con.Close();
            return data;
        }

        public int Mahuyen1(int Maxa)
        {
            int maxa;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Mahuyen from Xa where Maxa=" + Maxa;
                SqlCommand cmd = new SqlCommand(sql, con);
                maxa = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return maxa;
        }

        public String TenTinh(int Mahuyen)
        {
            String TenTinh;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Tinh.TenTinh from Huyen,Tinh where Huyen.Matinh=Tinh.Matinh and Huyen.Mahuyen=" + Mahuyen;
                SqlCommand cmd = new SqlCommand(sql, con);
                TenTinh = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            return TenTinh;
        }


        public int Matinh1(int Mahuyen)
        {
            int matinh;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Matinh from Huyen where Mahuyen=" + Mahuyen;
                SqlCommand cmd = new SqlCommand(sql, con);
                matinh = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return matinh;
        }

        public int Mahuyen(String tenhuyen)
        {
            int mahuyen;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Mahuyen from Huyen where Tenhuyen=N'" + tenhuyen + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                mahuyen = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return mahuyen;
        }

        public int Matinh(String tentinh)
        {
            int matinh;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Matinh from Tinh where Tentinh=N'" + tentinh + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                matinh = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return matinh;
        }

        public int Maxa(String tenxa)
        {
            int maxa;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Maxa from Xa where Tenxa=N'" + tenxa + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                maxa = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return maxa;
        }

        public String Tenhuyen(int mahuyen)
        {
            String tenhuyen;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Tenhuyen from Huyen where Mahuyen=" + mahuyen;
                SqlCommand cmd = new SqlCommand(sql, con);
                tenhuyen = (String)cmd.ExecuteScalar();
                con.Close();
            }
            return tenhuyen;
        }
        public String Tenxa(int maxa)
        {
            String tenxa;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Tenxa from Xa where Maxa=" + maxa;
                SqlCommand cmd = new SqlCommand(sql, con);
                tenxa = (String)cmd.ExecuteScalar();
                con.Close();
            }
            return tenxa;
        }
        public DataSet LoadHuyen(String id)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "select * from Huyen where Matinh=" + id;
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, con);
            DataSet data = new DataSet();
            Adapter.Fill(data);
            con.Close();
            return data;
        }
        public DataSet LoadPhuong(string id)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "select * from Xa where Mahuyen=" + id;
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, con);
            DataSet data = new DataSet();
            Adapter.Fill(data);
            con.Close();
            return data;
        }

        public DataSet LoadHuyen1()
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "select * from Huyen";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, con);
            DataSet data = new DataSet();
            Adapter.Fill(data);
            con.Close();
            return data;
        }
        public DataSet LoadPhuong1()
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "select * from Xa";
            SqlDataAdapter Adapter = new SqlDataAdapter(sql, con);
            DataSet data = new DataSet();
            Adapter.Fill(data);
            con.Close();
            return data;
        }

        public DataTable Loaddiachi(String ten)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select * from " + ten;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public void themtinh(String tentinh)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "insert into Tinh values(@tentinh)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@tentinh", SqlDbType.NVarChar, 50);
                cmd.Parameters["@tentinh"].Value = tentinh;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void updatetinh(int matinh, String tentinh)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "update Tinh set Tentinh=@tentinh where Matinh=@matinh";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@matinh", SqlDbType.Int, 10);
                cmd.Parameters["@matinh"].Value = matinh;
                cmd.Parameters.Add("@tentinh", SqlDbType.NVarChar, 50);
                cmd.Parameters["@tentinh"].Value = tentinh;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Xoatinh(int matinh)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "Delete from Tinh where Matinh=@matinh";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@matinh", SqlDbType.Int, 10);
                cmd.Parameters["@matinh"].Value = matinh;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void themhuyen(String tenhuyen, int matinh)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "insert into Huyen values(@tenhuyen,@matinh)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@tenhuyen", SqlDbType.NVarChar, 50);
                cmd.Parameters["@tenhuyen"].Value = tenhuyen;
                cmd.Parameters.Add("@matinh", SqlDbType.Int, 10);
                cmd.Parameters["@matinh"].Value = matinh;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void updatehuyen(int mahuyen, String tenhuyen, int matinh)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "update Huyen set Tenhuyen=@tenhuyen,Matinh=@matinh where Mahuyen=@mahuyen";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@mahuyen", SqlDbType.Int, 10);
                cmd.Parameters["@mahuyen"].Value = mahuyen;
                cmd.Parameters.Add("@tenhuyen", SqlDbType.NVarChar, 50);
                cmd.Parameters["@tenhuyen"].Value = tenhuyen;
                cmd.Parameters.Add("@matinh", SqlDbType.Int, 10);
                cmd.Parameters["@matinh"].Value = matinh;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Xoahuyen(int mahuyen)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "Delete from Huyen where Mahuyen=@mahuyen";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@mahuyen", SqlDbType.Int, 10);
                cmd.Parameters["@mahuyen"].Value = mahuyen;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void themxa(String tenxa, int mahuyen)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "insert into Xa values(@tenxa,@mahuyen)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@tenxa", SqlDbType.NVarChar, 50);
                cmd.Parameters["@tenxa"].Value = tenxa;
                cmd.Parameters.Add("@mahuyen", SqlDbType.Int, 10);
                cmd.Parameters["@mahuyen"].Value = mahuyen;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void updatexa(int maxa, String tenxa, int mahuyen)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "update Xa set Tenxa=@tenxa,Mahuyen=@mahuyen where Maxa=@maxa";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@mahuyen", SqlDbType.Int, 10);
                cmd.Parameters["@mahuyen"].Value = mahuyen;
                cmd.Parameters.Add("@tenxa", SqlDbType.NVarChar, 50);
                cmd.Parameters["@tenxa"].Value = tenxa;
                cmd.Parameters.Add("@maxa", SqlDbType.Int, 10);
                cmd.Parameters["@maxa"].Value = maxa;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Xoaxa(int maxa)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "Delete from Xa where Maxa=@maxa";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@maxa", SqlDbType.Int, 10);
                cmd.Parameters["@maxa"].Value = maxa;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
