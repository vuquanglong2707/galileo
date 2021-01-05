using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BaiTapLonN6
{
    class Sinhvien
    {
        public DataTable LoadThongKe(int makhoa)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select MSV,Hoten,NgaySinh from Sinhvien where Makhoa=" + makhoa;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        
        public String TenSinhVien(int MSV)
        {
            String tensv;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select HoTen from SinhVien where MSV=" + MSV;
                SqlCommand cmd = new SqlCommand(sql, con);
                tensv = (String)cmd.ExecuteScalar();
                con.Close();
            }
            return tensv;
        }

      


        public Boolean checkCMDN(String CMND)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[SinhVien] where CMND=@CMND";
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
        public Boolean checkCMDNsua(String CMND,int MSV)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "SELECT COUNT(*) FROM [QLSV].[dbo].[SinhVien] where CMND=@CMND and MSV!=@MSV";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@CMND", CMND));
            cmd.Parameters.Add(new SqlParameter("@MSV", MSV));
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

        /*
        public DataTable LoadThongKeLop(int malop)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select MSV,Hoten,NgaySinh from Sinhvien where Malop=" + malop;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        */
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

        public String Count(String sql)
        {
            String Count;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                var a = cmd.ExecuteScalar();
                if (a == null)
                {
                    Count = "0";
                }
                else
                {
                    Count = a.ToString();
                }
                con.Close();
            }
            return Count;
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

        public String MSV(String hoten,int malop)
        {
            String MSV;
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "select MSV from SinhVien where Hoten=N'" + hoten + "' and Malop="+malop;
            SqlCommand cmd = new SqlCommand(sql, con);
            var a = cmd.ExecuteScalar();
            con.Close();
            if (a == null)
            {
                MSV = "";
            }
            else
            {
                MSV = a.ToString();
            }
            return MSV;
        }

        public DataSet LoadSVselect(String t)
        {
            DataSet data = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select Hoten from SinhVien where Malop='" + t + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        public DataTable Load(int malop)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                /*
                String sql = "select MSV,Hoten,AnhHoSo,Ngaysinh,Gioitinh,Dantoc,SDT,CMND,Email,Hedaotao,Hotenbo,Nghebo,Hotenme,Ngheme,TenTinh,Tenhuyen,Tenxa,Tenkhoa,Tenlop,Tinhtrang,NamnhapHoc from SinhVien, Lop, Khoa, Tinh, Huyen, Xa where SinhVien.Maxa=Xa.Maxa and Xa.Mahuyen=Huyen.Mahuyen and Huyen.Matinh=Tinh.Matinh and SinhVien.Malop=Lop.Malop and Lop.Makhoa=Khoa.Makhoa and SinhVien.Malop=" + malop;
                */
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SV_LoadLop";
                cmd.Parameters.Add(new SqlParameter("@malop", malop));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        public DataTable Search(int msv)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select MSV,Hoten,AnhHoSo,Ngaysinh,Gioitinh,Dantoc,SDT,CMND,Email,Hedaotao,Hotenbo,Nghebo,Hotenme,Ngheme,TenTinh,Tenhuyen,Tenxa,Tenkhoa,Tenlop,Tinhtrang,NamnhapHoc from SinhVien, Lop, Khoa, Tinh, Huyen, Xa where SinhVien.Maxa=Xa.Maxa and Xa.Mahuyen=Huyen.Mahuyen and Huyen.Matinh=Tinh.Matinh and SinhVien.Malop=Lop.Malop and Lop.Makhoa=Khoa.Makhoa and SinhVien.MSV=" + @msv;
                SqlCommand cmd = new SqlCommand(sql, con);
                /*
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                */
                cmd.Parameters.Add("@msv", SqlDbType.Int, 15);
                cmd.Parameters["@msv"].Value = msv;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }
       
        public DataTable SearchHoten(String hoten)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select MSV,Hoten,AnhHoSo,Ngaysinh,Gioitinh,Dantoc,SDT,CMND,Email,Hedaotao,Hotenbo,Nghebo,Hotenme,Ngheme,TenTinh,Tenhuyen,Tenxa,Tenkhoa,Tenlop,Tinhtrang,NamnhapHoc from SinhVien, Lop, Khoa, Tinh, Huyen, Xa where SinhVien.Maxa=Xa.Maxa and Xa.Mahuyen=Huyen.Mahuyen and Huyen.Matinh=Tinh.Matinh and SinhVien.Malop=Lop.Malop and Lop.Makhoa=Khoa.Makhoa and dbo.ufn_removeMark(Hoten)='" + @hoten+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                /*
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                */
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar, 50);
                cmd.Parameters["@hoten"].Value = hoten;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }
        
        public void addnew(String hoten, String ngaysinh, String gioitinh, String dantoc, String sdt, String cmnd, String email, String hedaotao, String hotenbo, String nghebo, String hotenme, String ngheme, int maxa, int malop, String tinhtrang,int namnhaphoc)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "insert into SinhVien(Hoten, Ngaysinh, Gioitinh, Dantoc, SDT, CMND, Email, Hedaotao, Hotenbo, Nghebo, Hotenme, Ngheme, Maxa, Malop, Tinhtrang, NamNhapHoc) values(@Hoten, @Ngaysinh, @Gioitinh, @Dantoc, @SDT, @CMND, @Email, @Hedaotao, @Hotenbo, @Nghebo, @Hotenme, @Ngheme, @Maxa, @Malop, @Tinhtrang, @namnhaphoc)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add(new SqlParameter("@Ngaysinh", ngaysinh));
            cmd.Parameters.Add("@Hoten", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@Gioitinh", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@Dantoc", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@CMND", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@Hedaotao", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@Hotenbo", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@Nghebo", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@Hotenme", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@Ngheme", SqlDbType.NVarChar, 60);
            
            cmd.Parameters.Add("@Maxa", SqlDbType.Int, 10);
            
            cmd.Parameters.Add("@Malop", SqlDbType.Int, 10);
            cmd.Parameters.Add("@Tinhtrang", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@namnhaphoc", SqlDbType.Int, 10);

            cmd.Parameters["@Hoten"].Value = hoten;
            cmd.Parameters["@Gioitinh"].Value = gioitinh;
            cmd.Parameters["@Dantoc"].Value = dantoc;
            cmd.Parameters["@SDT"].Value = sdt;
            cmd.Parameters["@CMND"].Value = cmnd;
            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@Hedaotao"].Value = hedaotao;
            cmd.Parameters["@Hotenbo"].Value = hotenbo;
            cmd.Parameters["@Nghebo"].Value = nghebo;
            cmd.Parameters["@Hotenme"].Value = hotenme;
            cmd.Parameters["@Ngheme"].Value = ngheme;
            
            cmd.Parameters["@Maxa"].Value = maxa;
            cmd.Parameters["@Malop"].Value = malop;
            
            cmd.Parameters["@Tinhtrang"].Value = tinhtrang;
            cmd.Parameters["@namnhaphoc"].Value = namnhaphoc;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void addnewIMG(String hoten, String ngaysinh, String gioitinh, String dantoc, String sdt, String cmnd, String email, String hedaotao, String hotenbo, String nghebo, String hotenme, String ngheme, int maxa, int malop, String tinhtrang, int namnhaphoc,byte[] img)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "insert into SinhVien(Hoten, Ngaysinh, Gioitinh, Dantoc, SDT, CMND, Email, Hedaotao, Hotenbo, Nghebo, Hotenme, Ngheme, Maxa, Malop, Tinhtrang, NamNhapHoc,AnhHoSo) values(@Hoten, @Ngaysinh, @Gioitinh, @Dantoc, @SDT, @CMND, @Email, @Hedaotao, @Hotenbo, @Nghebo, @Hotenme, @Ngheme, @Maxa, @Malop, @Tinhtrang, @namnhaphoc,@img)";
            SqlCommand cmd = new SqlCommand(sql, con);
            /*
             * cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            */
            cmd.Parameters.Add("@Hoten", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add(new SqlParameter("@Ngaysinh", ngaysinh));
            cmd.Parameters.Add("@Gioitinh", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@Dantoc", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@SDT", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@CMND", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@Hedaotao", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@Hotenbo", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@Nghebo", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@Hotenme", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@Ngheme", SqlDbType.NVarChar, 60);

            cmd.Parameters.Add("@Maxa", SqlDbType.Int, 10);
            
            cmd.Parameters.Add("@Malop", SqlDbType.Int, 10);
            cmd.Parameters.Add("@Tinhtrang", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@namnhaphoc", SqlDbType.Int, 10);

            cmd.Parameters["@Hoten"].Value = hoten;
            cmd.Parameters["@Gioitinh"].Value = gioitinh;
            cmd.Parameters["@Dantoc"].Value = dantoc;
            cmd.Parameters["@SDT"].Value = sdt;
            cmd.Parameters["@CMND"].Value = cmnd;
            cmd.Parameters["@Email"].Value = email;
            cmd.Parameters["@Hedaotao"].Value = hedaotao;
            cmd.Parameters["@Hotenbo"].Value = hotenbo;
            cmd.Parameters["@Nghebo"].Value = nghebo;
            cmd.Parameters["@Hotenme"].Value = hotenme;
            cmd.Parameters["@Ngheme"].Value = ngheme;

            cmd.Parameters["@Maxa"].Value = maxa;
            cmd.Parameters["@Malop"].Value = malop;
            
            cmd.Parameters["@Tinhtrang"].Value = tinhtrang;
            cmd.Parameters["@namnhaphoc"].Value = namnhaphoc;
            cmd.Parameters.Add(new SqlParameter("@img", img));
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void update(int msv, String hoten, String ngaysinh, String gioitinh, String dantoc, String sdt, String cmnd, String email, String hedaotao, String hotenbo, String nghebo, String hotenme, String ngheme, int maxa, int malop, String tinhtrang, int namnhaphoc,byte[] img)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "update SinhVien set Hoten=@hoten,AnhHoSo=@img,Ngaysinh=@ngaysinh,Gioitinh=@gioitinh,Dantoc=@dantoc,SDT=@sdt,CMND=@cmnd,Email=@email,Hedaotao=@hedaotao,Hotenbo=@hotenbo,Nghebo=@nghebo,Hotenme=@hotenme,Ngheme=@ngheme,Maxa=@maxa,Malop=@malop,Tinhtrang=@tinhtrang,NamNhapHoc=@namnhaphoc where MSV=@msv";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@msv", SqlDbType.Int, 20);
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add(new SqlParameter("@ngaysinh", ngaysinh));
                cmd.Parameters.Add("@gioitinh", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@dantoc", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@sdt", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@cmnd", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add("@hedaotao", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@hotenbo", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add("@nghebo", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add("@hotenme", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add("@ngheme", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                cmd.Parameters.Add("@maxa", SqlDbType.Int, 10);
                
                cmd.Parameters.Add("@malop", SqlDbType.Int, 10);
                cmd.Parameters.Add("@tinhtrang", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@namnhaphoc", SqlDbType.Int, 15);

                cmd.Parameters["@msv"].Value = msv;
                cmd.Parameters["@hoten"].Value = hoten;
                cmd.Parameters["@gioitinh"].Value = gioitinh;
                cmd.Parameters["@dantoc"].Value = dantoc;
                cmd.Parameters["@sdt"].Value = sdt;
                cmd.Parameters["@cmnd"].Value = cmnd;
                cmd.Parameters["@email"].Value = email;
                cmd.Parameters["@hedaotao"].Value = hedaotao;
                cmd.Parameters["@hotenbo"].Value = hotenbo;
                cmd.Parameters["@nghebo"].Value = nghebo;
                cmd.Parameters["@hotenme"].Value = hotenme;
                cmd.Parameters["@ngheme"].Value = ngheme;
                
                cmd.Parameters["@maxa"].Value = maxa;
                cmd.Parameters["@malop"].Value = malop;
                
                cmd.Parameters["@tinhtrang"].Value = tinhtrang;
                cmd.Parameters["@namnhaphoc"].Value = namnhaphoc;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void updateNoChangeImage(int msv, String hoten, String ngaysinh, String gioitinh, String dantoc, String sdt, String cmnd, String email, String hedaotao, String hotenbo, String nghebo, String hotenme, String ngheme, int maxa, int malop, String tinhtrang, String namnhaphoc)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "update Sinhvien set Hoten=@hoten,Ngaysinh=@ngaysinh,Gioitinh=@gioitinh,Dantoc=@dantoc,SDT=@sdt,CMND=@cmnd,Email=@email,Hedaotao=@hedaotao,Hotenbo=@hotenbo,Nghebo=@nghebo,Hotenme=@hotenme,Ngheme=@ngheme,Maxa=@maxa,Malop=@malop,Tinhtrang=@tinhtrang,NamNhapHoc=@namnhaphoc where MSV=@msv";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@msv", SqlDbType.Int, 20);
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add(new SqlParameter("@ngaysinh", ngaysinh));
                cmd.Parameters.Add("@gioitinh", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@dantoc", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@sdt", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@cmnd", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add("@hedaotao", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@hotenbo", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add("@nghebo", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add("@hotenme", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add("@ngheme", SqlDbType.NVarChar, 60);

                cmd.Parameters.Add("@maxa", SqlDbType.Int, 10);
                
                cmd.Parameters.Add("@malop", SqlDbType.Int, 10);
                cmd.Parameters.Add("@tinhtrang", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@namnhaphoc", SqlDbType.NVarChar, 15);


                cmd.Parameters["@msv"].Value = msv;
                cmd.Parameters["@hoten"].Value = hoten;

                cmd.Parameters["@gioitinh"].Value = gioitinh;
                cmd.Parameters["@dantoc"].Value = dantoc;
                cmd.Parameters["@sdt"].Value = sdt;
                cmd.Parameters["@cmnd"].Value = cmnd;
                cmd.Parameters["@email"].Value = email;
                cmd.Parameters["@hedaotao"].Value = hedaotao;
                cmd.Parameters["@hotenbo"].Value = hotenbo;
                cmd.Parameters["@nghebo"].Value = nghebo;
                cmd.Parameters["@hotenme"].Value = hotenme;
                cmd.Parameters["@ngheme"].Value = ngheme;

                cmd.Parameters["@maxa"].Value = maxa;
                cmd.Parameters["@malop"].Value = malop;
                
                cmd.Parameters["@tinhtrang"].Value = tinhtrang;
                cmd.Parameters["@namnhaphoc"].Value = namnhaphoc;


                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void update2(int msv, String hoten, String ngaysinh, String gioitinh, String dantoc, String sdt, String cmnd, String email, String hedaotao, String hotenbo, String nghebo, String hotenme, String ngheme, int maxa, int malop, String tinhtrang,String namnhaphoc,byte[] img)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "update Sinhvien set Hoten=@hoten,AnhHoSo=@img,Ngaysinh=@ngaysinh,Gioitinh=@gioitinh,Dantoc=@dantoc,SDT=@sdt,CMND=@cmnd,Email=@email,Hedaotao=@hedaotao,Hotenbo=@hotenbo,Nghebo=@nghebo,Hotenme=@hotenme,Ngheme=@ngheme,Maxa=@maxa,Malop=@malop,Tinhtrang=@tinhtrang,NamNhapHoc=@namnhaphoc where MSV=@msv";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@msv", SqlDbType.Int, 20);
                cmd.Parameters.Add("@hoten", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add(new SqlParameter("@ngaysinh", ngaysinh));
                cmd.Parameters.Add("@gioitinh", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@dantoc", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@sdt", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@cmnd", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add("@hedaotao", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@hotenbo", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add("@nghebo", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add("@hotenme", SqlDbType.NVarChar, 60);
                cmd.Parameters.Add("@ngheme", SqlDbType.NVarChar, 60);
                
                cmd.Parameters.Add("@maxa", SqlDbType.Int, 10);
                
                cmd.Parameters.Add("@malop", SqlDbType.Int, 10);
                cmd.Parameters.Add("@tinhtrang", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@namnhaphoc", SqlDbType.NVarChar, 15);
                cmd.Parameters.Add(new SqlParameter("@img", img));

                cmd.Parameters["@msv"].Value = msv;
                cmd.Parameters["@hoten"].Value = hoten;
                
                cmd.Parameters["@gioitinh"].Value = gioitinh;
                cmd.Parameters["@dantoc"].Value = dantoc;
                cmd.Parameters["@sdt"].Value = sdt;
                cmd.Parameters["@cmnd"].Value = cmnd;
                cmd.Parameters["@email"].Value = email;
                cmd.Parameters["@hedaotao"].Value = hedaotao;
                cmd.Parameters["@hotenbo"].Value = hotenbo;
                cmd.Parameters["@nghebo"].Value = nghebo;
                cmd.Parameters["@hotenme"].Value = hotenme;
                cmd.Parameters["@ngheme"].Value = ngheme;
                
                cmd.Parameters["@maxa"].Value = maxa;
                cmd.Parameters["@malop"].Value = malop;
                
                cmd.Parameters["@tinhtrang"].Value = tinhtrang;
                cmd.Parameters["@namnhaphoc"].Value = namnhaphoc;


                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void delete(int msv)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            String sql = "delete from SinhVien where MSV=@msv";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@msv", SqlDbType.Int, 15);
            cmd.Parameters["@msv"].Value = msv;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
