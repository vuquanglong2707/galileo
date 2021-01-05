using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace BaiTapLonN6
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }
        public static String trangthai;
        public Boolean click = false;
        static String duongdan = null;
        private void ThongKe_Load(object sender, EventArgs e)
        {
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            KhoaDT khoa = new KhoaDT();
            DataSet ds1 = new DataSet();
            ds1 = khoa.Loadkhoa();
            cbboxkhoa.DataSource = ds1.Tables[0];
            cbboxkhoa.DisplayMember = "Tenkhoa";
            cbboxkhoa.ValueMember = "Makhoa";
            duongdan = null;
            click = false;
        }

        private void btnThongKeSV_Click(object sender, EventArgs e)
        {
            if (radiodanghoc.Checked)
            {
                Sinhvien a = new Sinhvien();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                Lop b = new Lop();
                int c = b.MaKhoa(cbboxkhoa.Text);
                dataGridView1.DataSource = a.getTable("select MSV,Hoten,Tinhtrang,GioiTinh from Sinhvien,Lop,Khoa where SinhVien.Malop=Lop.Malop and Lop.MaKhoa=Khoa.Makhoa and Khoa.Makhoa=" + c + "and SinhVien.Tinhtrang=N'Đang Học'");
                String count = a.Count("SELECT COUNT(*)FROM Sinhvien,Lop,Khoa WHERE Tinhtrang=N'Đang Học'and SinhVien.Malop=Lop.Malop and Lop.MaKhoa=Khoa.Makhoa and Khoa.Makhoa=" + c);
                txtTongSo.Text = count;
                click = true;
            }
            else if (radiototnghiep.Checked)
            {
                Sinhvien a = new Sinhvien();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                Lop b = new Lop();
                int c = b.MaKhoa(cbboxkhoa.Text);
                dataGridView1.DataSource = a.getTable("select MSV,Hoten,Tinhtrang,GioiTinh from Sinhvien,Lop,Khoa where SinhVien.Malop=Lop.Malop and Lop.MaKhoa=Khoa.Makhoa and Khoa.Makhoa=" + c + "and SinhVien.Tinhtrang=N'Đã Tốt Nghiệp'");
                String count = a.Count("SELECT COUNT(*)FROM Sinhvien,Lop,Khoa WHERE Tinhtrang=N'Đã Tốt Nghiệp'and SinhVien.Malop=Lop.Malop and Lop.MaKhoa=Khoa.Makhoa and Khoa.Makhoa=" + c);
                txtTongSo.Text = count;
                click = true;
            }
            else if (radiotatca.Checked)
            {
                Sinhvien a = new Sinhvien();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                Lop b = new Lop();
                int c = b.MaKhoa(cbboxkhoa.Text);
                dataGridView1.DataSource = a.getTable("select MSV,Hoten,Tinhtrang,GioiTinh from Sinhvien,Lop,Khoa where SinhVien.Malop=Lop.Malop and Lop.MaKhoa=Khoa.Makhoa and Khoa.Makhoa=" + c);
                String count = a.Count("SELECT COUNT(*)FROM Sinhvien,Lop,Khoa WHERE SinhVien.Malop=Lop.Malop and Lop.MaKhoa=Khoa.Makhoa and Khoa.Makhoa=" + c);
                txtTongSo.Text = count;
                click = true;
            }
            else
            {
                Sinhvien a = new Sinhvien();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                Lop b = new Lop();
                int c = b.MaKhoa(cbboxkhoa.Text);
                dataGridView1.DataSource = a.getTable("select MSV,Hoten,Tinhtrang,GioiTinh from Sinhvien,Lop,Khoa where SinhVien.Malop=Lop.Malop and Lop.MaKhoa=Khoa.Makhoa and Khoa.Makhoa=" + c);
                String count = a.Count("SELECT COUNT(*)FROM Sinhvien,Lop,Khoa WHERE SinhVien.Malop=Lop.Malop and Lop.MaKhoa=Khoa.Makhoa and Khoa.Makhoa=" + c);
                txtTongSo.Text = count;
                click = true;
            }
            trangthai = "Khoa";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbboxlop.Text != "")
            {
                if (radiodanghoclop.Checked)
                {
                    Sinhvien a = new Sinhvien();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                    Lop b = new Lop();
                    int c = b.Malop(cbboxlop.Text);
                    dataGridView1.DataSource = a.getTable("select MSV,Hoten,GioiTinh,Tinhtrang from Sinhvien where Malop=" + c + "and Tinhtrang=N'Đang Học'");
                    String count = a.Count("SELECT COUNT(*)FROM Sinhvien WHERE Tinhtrang=N'Đang Học' and Malop=" + c);
                    txtTongSo.Text = count;
                    click = true;
                }
                else if (radiodatotnghiep.Checked)
                {
                    Sinhvien a = new Sinhvien();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                    Lop b = new Lop();
                    int c = b.Malop(cbboxlop.Text);
                    dataGridView1.DataSource = a.getTable("select MSV,Hoten,GioiTinh,Tinhtrang from Sinhvien where Malop=" + c + "and Tinhtrang=N'Đã Tốt Nghiệp'");
                    String count = a.Count("SELECT COUNT(*)FROM Sinhvien WHERE Tinhtrang=N'Đã Tốt Nghiệp' and Malop=" + c);
                    txtTongSo.Text = count;
                    click = true;
                }
                else if (radiotatcalop.Checked)
                {
                    Sinhvien a = new Sinhvien();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                    Lop b = new Lop();
                    int c = b.Malop(cbboxlop.Text);
                    dataGridView1.DataSource = a.getTable("select MSV,Hoten,GioiTinh,Tinhtrang from Sinhvien where Malop=" + c);
                    String count = a.Count("SELECT COUNT(*)FROM Sinhvien WHERE Malop=" + c);
                    txtTongSo.Text = count;
                    click = true;
                }
                else
                {
                    Sinhvien a = new Sinhvien();
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                    Lop b = new Lop();
                    int c = b.Malop(cbboxlop.Text);
                    dataGridView1.DataSource = a.getTable("select MSV,Hoten,GioiTinh,Tinhtrang from Sinhvien where Malop=" + c);
                    String count = a.Count("SELECT COUNT(*)FROM Sinhvien WHERE Malop=" + c);
                    txtTongSo.Text = count;
                    click = true;
                }
                trangthai = "Lớp";
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn lớp. Hãy Chọn Khoa rồi chọn lớp");
            }
        }

        private void cbboxkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxkhoa.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                Lop dc = new Lop();
                DataSet ds = new DataSet();
                ds = dc.LoadLopselect(t);
                cbboxlop.DataSource = ds.Tables[0];
                cbboxlop.DisplayMember = "Tenlop";
                cbboxlop.ValueMember = "Malop";
            }
        }

        private void export2Excel(DataGridView g, String duongdan)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongdan);
            obj.ActiveWorkbook.Saved = true;
        }
        private void btnXuatExel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count==0)
            {
                MessageBox.Show("Ko co gi de xuat");
            }
            else
            {
                
                if (trangthai == "Khoa")
                {
                    if (duongdan == null)
                    {
                        MessageBox.Show("Bạn Hãy Chọn Nơi Lưu File");
                    }
                    else
                    {
                        export2Excel(dataGridView1, duongdan);
                        MessageBox.Show(@"Xuất Thành Công " + duongdan);
                    }
                }
                else if (trangthai == "Lớp")
                {
                    if (duongdan == null)
                    {
                        MessageBox.Show("Bạn Hãy Chọn Nơi Lưu File");
                    }
                    else
                    {
                        export2Excel(dataGridView1, duongdan);
                        MessageBox.Show(@"Xuất Thành Công " + duongdan);
                    }
                }
            }
        }

        private void btnChonDuongDan_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Select Location";
                dlg.Filter = "Excel Worksheets|*.xlsx";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    duongdan = dlg.FileName.ToString();
                    lblDuongDanFile.Text = duongdan;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
