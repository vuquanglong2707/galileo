using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BaiTapLonN6
{
    class XemDiemSV
    {
        public DataTable LoadTatCaDiemSV(String MSV)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select MonHoc.MaMonHoc,MonHoc.TenMonHoc,MonHoc.SoTC,DiemMonHoc.LanHoc,DiemMonHoc.Diem1,DiemMonHoc.Diem2,DiemMonHoc.DiemThi,DiemMonHoc.DiemTongKet,DiemMonHoc.DiemChu,DiemMonHoc.DanhGia from (DiemMonHoc inner join MonHoc on DiemMonHoc.MaMH = MonHoc.MaMonHoc) where DiemMonHoc.MaSV = @MSV";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@MSV", MSV));
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }

        public DataTable LoadDiemSVTheoHocKy(String MSV,String NamHoc)
        {
            DataTable data = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                String sql = "select MonHoc.MaMonHoc,MonHoc.TenMonHoc,MonHoc.SoTC,DiemMonHoc.LanHoc,DiemMonHoc.Diem1,DiemMonHoc.Diem2,DiemMonHoc.DiemThi,DiemMonHoc.DiemTongKet,DiemMonHoc.DiemChu,DiemMonHoc.DanhGia  from(DiemMonHoc inner join MonHoc on DiemMonHoc.MaMH = MonHoc.MaMonHoc) where DiemMonHoc.MaSV = @MSV and DiemMonHoc.NamHoc = @NamHoc";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add(new SqlParameter("@MSV", MSV));
                cmd.Parameters.Add(new SqlParameter("@NamHoc", NamHoc));
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                Adapter.Fill(data);
                con.Close();
            }
            return data;
        }
    }
}
