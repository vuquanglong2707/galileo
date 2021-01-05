using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BaiTapLonN6
{
    class DiemTBTL
    {
        
        
        public Boolean KiemTra(DataGridView data)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    String value = data.Rows[i].Cells[j].Value.ToString();
                    if (value == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Boolean CheckDeNhapDiemCaNam(String namhoc,String msv)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "KTTinhDiemCaNam";
                cmd.Parameters.Add(new SqlParameter("@masinhvien", msv));
                cmd.Parameters.Add(new SqlParameter("@namhoc", namhoc));
                var kq = cmd.ExecuteScalar();
                con.Close();
                if(kq.ToString()=="2" || kq.ToString()=="3")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public DataTable XemDiemHe4BySinhVien(String msv)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SVXemDTBC";
                cmd.Parameters.Add(new SqlParameter("@masinhvien", msv));
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        


        public Boolean Check(String MSV,String NamHoc)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SinhVien_KTDTB";
                cmd.Parameters.Add(new SqlParameter("@msv", MSV));
                cmd.Parameters.Add(new SqlParameter("@namhoc", NamHoc));
                var kq = cmd.ExecuteScalar();
                con.Close();
                if (kq.ToString()=="0")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void insertCaNam(String MSV, String NamHoc, Double? DiemHe10, Double? DiemHe4, int? TongTc,int? tongtctrongky)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TBC_insert";
                cmd.Parameters.Add(new SqlParameter("@msv", MSV));
                cmd.Parameters.Add(new SqlParameter("@namhoc", NamHoc));
                cmd.Parameters.Add(new SqlParameter("@diemhe10", DiemHe10));
                cmd.Parameters.Add(new SqlParameter("@diemhe4", DiemHe4));
                cmd.Parameters.Add(new SqlParameter("@tongtc", TongTc));
                cmd.Parameters.Add(new SqlParameter("@tongtctrongky", tongtctrongky));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void insert(String MSV,String NamHoc,Double DiemHe10,Double DiemHe4,int TongTc,int tongtctrongky)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TBC_insert";
                cmd.Parameters.Add(new SqlParameter("@msv", MSV));
                cmd.Parameters.Add(new SqlParameter("@namhoc", NamHoc));
                cmd.Parameters.Add(new SqlParameter("@diemhe10", DiemHe10));
                cmd.Parameters.Add(new SqlParameter("@diemhe4", DiemHe4));
                cmd.Parameters.Add(new SqlParameter("@tongtc", TongTc));
                cmd.Parameters.Add(new SqlParameter("@tongtctrongky", tongtctrongky));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void update(String MSV, String NamHoc, Double DiemHe10, Double DiemHe4, int TongTc,int tongtctrongky)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TBC_update";
                cmd.Parameters.Add(new SqlParameter("@msv", MSV));
                cmd.Parameters.Add(new SqlParameter("@namhoc", NamHoc));
                cmd.Parameters.Add(new SqlParameter("@diemhe10", DiemHe10));
                cmd.Parameters.Add(new SqlParameter("@diemhe4", DiemHe4));
                cmd.Parameters.Add(new SqlParameter("@tongtc", TongTc));
                cmd.Parameters.Add(new SqlParameter("@tongtctrongky", tongtctrongky));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void updateCaNam(String MSV, String NamHoc, Double? DiemHe10, Double? DiemHe4, int? TongTc, int? tongtctrongky)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TBC_update";
                cmd.Parameters.Add(new SqlParameter("@msv", MSV));
                cmd.Parameters.Add(new SqlParameter("@namhoc", NamHoc));
                cmd.Parameters.Add(new SqlParameter("@diemhe10", DiemHe10));
                cmd.Parameters.Add(new SqlParameter("@diemhe4", DiemHe4));
                cmd.Parameters.Add(new SqlParameter("@tongtc", TongTc));
                cmd.Parameters.Add(new SqlParameter("@tongtctrongky", tongtctrongky));
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public int TongSoMonHoc(String hocky,String Khoa)
        {
            int Count;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TongSoMonHoc";
                cmd.Parameters.Add(new SqlParameter("@hocky", hocky));
                cmd.Parameters.Add(new SqlParameter("@makhoa", Khoa));
                var a = cmd.ExecuteScalar();
                if (a == null)
                {
                    Count = 0;
                }
                else
                {
                    Count = (int)a;
                }
                con.Close();
            }
            return Count;
        }
        public DataTable XemDiem(String namhoc, String malop)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XemDiemTBTL";
                cmd.Parameters.Add(new SqlParameter("@namhoc", namhoc));
                cmd.Parameters.Add(new SqlParameter("@malop", malop));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                con.Close();
            }
            return data;
        }



        public DataTable ListDiemTBSV(String namhoc,String malop)
        {
            DataTable data = new DataTable();
            using(SqlConnection con=new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TinhDiemTBTL";
                cmd.Parameters.Add(new SqlParameter("@Namhoc", namhoc));
                cmd.Parameters.Add(new SqlParameter("@Malop", malop));
                SqlDataReader rdr = cmd.ExecuteReader();
                data.Columns.Add("Mã SV");
                data.Columns.Add("Họ Tên");
                data.Columns.Add("Năm Học_HK");
                data.Columns.Add("DTB Hệ 10");
                data.Columns.Add("DTB Hệ 4");
                data.Columns.Add("Tổng Số Tín Chỉ");
                data.Columns.Add("Tổng Số Tín Chỉ Tích Lũy");
                while (rdr.Read())
                {
                    String MSv = rdr["MaSV"].ToString();
                    String Hoten = rdr["Hoten"].ToString();
                    String NamHoc = rdr["NamHoc"].ToString();
                    double? DTBHE10 = null;
                    double? DTBHE4 = null;
                    int? TongTC = null;
                    int? TongTCTL = null;
                    if (rdr["DTBHE10"].ToString() != "")
                    {
                        DTBHE10 = (double)rdr["DTBHE10"];
                    }
                    if (rdr["DTBHE4"].ToString() != "")
                    {
                        String DTBHE4i = rdr["DTBHE4"].ToString();
                        DTBHE4 = Math.Round(Convert.ToDouble(DTBHE4i), 2);
                    }
                    if (rdr["TongSoTC"].ToString() != "")
                    {
                        TongTC = (int)rdr["TongSoTC"];
                    }
                    TongTCTL = sotinchihoctrongky(NamHoc, MSv);
                    DataRow row = data.NewRow();
                    row["Mã SV"] = MSv;
                    row["Họ Tên"] = Hoten;
                    row["Năm Học_HK"] = NamHoc;
                    row["DTB Hệ 10"] = DTBHE10;
                    row["DTB Hệ 4"] = DTBHE4;
                    row["Tổng Số Tín Chỉ"] = TongTC;
                    row["Tổng Số Tín Chỉ Tích Lũy"] = TongTCTL;
                    data.Rows.Add(row);
                }
                con.Close();
            }
            return data;
        }
        private int? sotinchihoctrongky(String namhoc, String msv)
        {
            int? result=null;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TongSoTCTichLuy";
                cmd.Parameters.Add(new SqlParameter("@namhoc", namhoc));
                cmd.Parameters.Add(new SqlParameter("@msv", msv));
                var a = cmd.ExecuteScalar();
                if(a.ToString()=="")
                {
                    result = 0;
                }
                else
                {
                    result = (int)a;
                }
                con.Close();
            }
            return result;
        }

        public Diem DiemtongKetSinhVien(String namhoc, String msv)
        {
            Diem a = new Diem();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Lay2Diem2HocKy";
                cmd.Parameters.Add(new SqlParameter("@namhoc", namhoc));
                cmd.Parameters.Add(new SqlParameter("@masinhvien", msv));
                SqlDataReader rdr = cmd.ExecuteReader();
                String MSV=null;
                double? DiemHe10_1=null;
                double? DiemHe10_2 = null;
                double? DiemHe4_1 = null;
                double? DiemHe4_2 = null;
                int? tongTC_1=null;
                int? tongTC_2=null;
                int? tongTCTK_1 = null;
                int? tongTCTK_2 = null;
                while (rdr.Read())
                {
                    MSV = rdr["MaSinhVien"].ToString();
                    if(DiemHe10_1==null)
                    {
                        DiemHe10_1 = double.Parse(rdr["DiemTBCHe10"].ToString());
                    }
                    else
                    {
                        DiemHe10_2 = double.Parse(rdr["DiemTBCHe10"].ToString());
                    }
                    if (DiemHe4_1 == null)
                    {
                        DiemHe4_1 = double.Parse(rdr["TBCHe4"].ToString());
                    }
                    else
                    {
                        DiemHe4_2 = double.Parse(rdr["TBCHe4"].ToString());
                    }
                    if (tongTC_1 == null)
                    {
                        tongTC_1 = int.Parse(rdr["SoTCTL"].ToString());
                    }
                    else
                    {
                        tongTC_2 = int.Parse(rdr["SoTCTL"].ToString());
                    }
                    if (tongTCTK_1 == null)
                    {
                        tongTCTK_1 = int.Parse(rdr["SoTCTLTK"].ToString());
                    }
                    else
                    {
                        tongTCTK_2 = int.Parse(rdr["SoTCTLTK"].ToString());
                    }
                }
                double? DiemHe10CaNam = ((DiemHe10_1 * tongTC_1) + (DiemHe10_2 * tongTC_2))/(tongTC_1+tongTC_2);
                double? DiemHe4CaNam = ((DiemHe4_1 * tongTC_1) + (DiemHe4_2 * tongTC_2)) / (tongTC_1 + tongTC_2);
                int? TongTCCaNam = tongTC_1 + tongTC_2;
                int? TongTCCaNamTichLuyDuoc = tongTCTK_1 + tongTCTK_2;
                a.MaSV = MSV;
                a.DTB_HE10 = DiemHe10CaNam;
                a.DTB_HE4 = DiemHe4CaNam;
                a.So_TCTL = TongTCCaNam;
                a.So_TCTLtk = TongTCCaNamTichLuyDuoc;
                con.Close();
            }
            return a;
        }




        public int TongSoSV(String malop)
        {
            int Count;
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TongSoSV";
                cmd.Parameters.Add(new SqlParameter("@malop", malop));
                var a = cmd.ExecuteScalar();
                if (a == null)
                {
                    Count = 0;
                }
                else
                {
                    Count = (int)a;
                }
                con.Close();
            }
            return Count;
        }


        
    }
}
