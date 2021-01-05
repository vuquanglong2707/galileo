using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;

namespace BaiTapLonN6
{
    public partial class FrmXemDiemRL : Form
    {
        private String quyenhan;
        private String username;
        public FrmXemDiemRL(String quyenhan,String MaSV)
        {
            InitializeComponent();
            this.quyenhan = quyenhan;
            this.username = MaSV;
        }

        static String duongdan=null;
        public Boolean click = false;

        private void FrmXemDiemRL_Load(object sender, EventArgs e)
        {
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            KhoaDT khoa = new KhoaDT();
            DataSet ds1 = new DataSet();
            ds1 = khoa.Loadkhoa();
            cbboxChonkhoa.DataSource = ds1.Tables[0];
            cbboxChonkhoa.DisplayMember = "Tenkhoa";
            cbboxChonkhoa.ValueMember = "Makhoa";
            duongdan = null;
            click = false;
            if (quyenhan=="Sinh Viên")
            {
                groupBox1.Visible = false;
                dataGridView1.Dock = DockStyle.Fill;
                button1.Visible = false;
                DiemRL a = new DiemRL();
                
                dataGridView1.Enabled = false;
                btnLoadDanhSach.Enabled = false;
                groupBox2.Visible = false;
        

                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.ColumnCount = 6;
                dataGridView1.Columns[0].Name = "Mã Sinh Viên";
                dataGridView1.Columns[0].DataPropertyName = "MSV";
                dataGridView1.Columns[1].Name = "Họ Tên";
                dataGridView1.Columns[1].DataPropertyName = "HoTen";
                dataGridView1.Columns[2].Name = "Năm Học";
                dataGridView1.Columns[2].DataPropertyName = "NamHoc";
                dataGridView1.Columns[3].Name = "Học Kỳ";
                dataGridView1.Columns[3].DataPropertyName = "HocKy";
                dataGridView1.Columns[4].Name = "Tổng Điểm";
                dataGridView1.Columns[4].DataPropertyName = "TongDiem";
                dataGridView1.Columns[5].Name = "Xếp Loại";
                dataGridView1.Columns[5].DataPropertyName = "XepLoai";

                dataGridView1.DataSource = a.XemDiemRLQHSV(username);
                dataGridView1.ReadOnly = true;
            }
            else
            {

            }
        }

        private void export2Excel(DataGridView g,String duongdan)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for(int i=1; i < g.Columns.Count+1;i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for(int i=0;i<g.Rows.Count;i++)
            {
                for(int j=0;j<g.Columns.Count;j++)
                {
                    if(g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongdan);
            obj.ActiveWorkbook.Saved = true;
        }
        private void cbboxChonkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxChonkhoa.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                Lop dc = new Lop();
                DataSet ds = new DataSet();
                ds = dc.LoadLopselect(t);
                cbboxChonlop.DataSource = ds.Tables[0];
                cbboxChonlop.DisplayMember = "Tenlop";
                cbboxChonlop.ValueMember = "Malop";
            }
        }

        private void cbboxChonlop_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxChonlop.Text;
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                DiemRL drl = new DiemRL();
                DataTable ds = new DataTable();
                if (drl.KiemtratontaiSV(drl.Malop(t)) == true)
                {
                    ds = drl.Danhsachnamhoc(drl.NamNhapHoc(drl.Malop(t)));
                    cbboxNamHoc.DataSource = ds;
                    cbboxNamHoc.DisplayMember = "Nam";
                    cbboxNamHoc.ValueMember = "Nam";
                }
                else
                {
                    MessageBox.Show("Không tồn tại sinh viên trong lớp nên không thể cập nhật Mới các niên khóa học tập");
                }
            }
        }

        private void btnLoadDanhSach_Click(object sender, EventArgs e)
        {
            if (cbboxChonlop.Text == "")
            {
                MessageBox.Show("Vui lòng chọn lớp cần hiển thị");
            }
            else
            {
                DiemRL a = new DiemRL();
                Lop b = new Lop();
                if (radioButtonHK1.Checked)
                {
                    dataGridView1.DataSource = a.diemrenluyenthoelop(b.Malop(cbboxChonlop.Text), cbboxNamHoc.Text, radioButtonHK1.Text);
                    click = true;
                }
                else if (radioButtonHK2.Checked)
                {
                    dataGridView1.DataSource = a.diemrenluyenthoelop(b.Malop(cbboxChonlop.Text), cbboxNamHoc.Text, radioButtonHK2.Text);
                    click = true;
                }
                else if(radioButtonCaNam.Checked)
                {
                    dataGridView1.DataSource = a.diemrenluyenthoelop(b.Malop(cbboxChonlop.Text), cbboxNamHoc.Text, radioButtonCaNam.Text);
                    click = false;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn học kỳ nào đó cần hiển thị");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(click==true)
            {
                if (dataGridView1.Rows.Count == 0)
                {

                }
                else
                {
                    String Masodiem = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    String MSV = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    String Hoten = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    String Lop = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    String Namhoc = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    String Hocky = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    String Tongdiem = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    FrmSuaDiemRL frm = new FrmSuaDiemRL(Masodiem, MSV, Hoten, Lop, Namhoc, Hocky, Tongdiem);
                    frm.ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count==0)
            {
                MessageBox.Show("Ko co gi de xuat Excel");
            }
            else
            {
                if (duongdan == null)
                {
                    MessageBox.Show("Bạn Hãy Chọn Nơi Lưu File");
                }
                else
                {
                    if (File.Exists(duongdan))
                    {
                        MessageBox.Show("Đã Có Tên File Này Rồi. Bạn Nên Chọn Tên Khác");
                    }
                    else
                    {
                        FrmLoad a = new FrmLoad(dataGridView1, duongdan);
                        a.Show();
                        duongdan = null;
                        lblDuongDanFile.Text = "";
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

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

        private void cbboxNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonHK1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
