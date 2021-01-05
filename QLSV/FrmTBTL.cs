using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;
namespace BaiTapLonN6
{
    public partial class FrmTBTL : Form
    {
        public FrmTBTL()
        {
            InitializeComponent();

        }
        static String duongdan = null;
        private static String Trangthai=null;
        private void FrmTBTL_Load(object sender, EventArgs e)
        {
            KhoaDT khoa = new KhoaDT();
            DataSet ds1 = new DataSet();
            ds1 = khoa.Loadkhoa();
            cbboxChonkhoa.DataSource = ds1.Tables[0];
            cbboxChonkhoa.DisplayMember = "Tenkhoa";
            cbboxChonkhoa.ValueMember = "Makhoa";

            btnOK.Enabled = false;
            btnCanCel.Enabled = false;
            simpleButton1.Enabled = false;
            Trangthai = null;
            duongdan = null;
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
                cbboxchonlop.DataSource = ds.Tables[0];
                cbboxchonlop.DisplayMember = "Tenlop";
                cbboxchonlop.ValueMember = "Malop";
                simpleButton1.Enabled = true;
            }
        }

        private void cbboxchonlop_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxchonlop.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                DiemRL drl = new DiemRL();
                Lop a = new Lop();
                DataTable ds = new DataTable();
                ds = drl.DanhsachnamhocSVXemDiem(drl.NamNhapHoc2(t));
                cbboxNamHoc.DataSource = ds;
                cbboxNamHoc.DisplayMember = "Nam";
                cbboxNamHoc.ValueMember = "HocKyThu";
                simpleButton1.Enabled = true;
            }
        }
        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Trangthai == "Tính Điểm")
            {
                if (cbboxNamHoc.Text == "" || cbboxchonlop.Text == "")
                {
                    MessageBox.Show("Trống Lớp OR Năm Học...");
                }
                else
                {
                    int sc = cbboxNamHoc.Text.Length;
                    if (sc == 11)
                    {
                        MessageBox.Show("Điểm Cả Năm Chỉ Hoạt Động Bên Xem Điểm Thôi :)");
                    }
                    else
                    {
                        DiemTBTL a = new DiemTBTL();
                        dataGridView1.DataSource = a.ListDiemTBSV(cbboxNamHoc.Text, cbboxchonlop.SelectedValue.ToString());
                        simpleButton1.Enabled = false;
                        dataGridView1.ReadOnly = true;
                        lblThongBao.Text = "Nhập/Sửa DTB Lớp: " + cbboxchonlop.Text + ",Năm Học: " + cbboxNamHoc.Text;
                        btnOK.Enabled = true;
                        btnCanCel.Enabled = true;
                    }
                }
            }
            else if(Trangthai=="Xem Điểm")
            {
                if (cbboxNamHoc.Text == "" || cbboxchonlop.Text == "")
                {
                    MessageBox.Show("Trống Lớp OR Năm Học...");
                }
                else
                {
                    DiemTBTL a = new DiemTBTL();
                    dataGridView1.DataSource = a.XemDiem(cbboxNamHoc.Text, cbboxchonlop.SelectedValue.ToString());
                    simpleButton1.Enabled = false;
                    dataGridView1.ReadOnly = true;
                }
            }
            else
            {
                MessageBox.Show("Chọn Xem Điểm Hoặc Nhập Điểm");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbboxNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            simpleButton1.Enabled = true;
        }

        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            Trangthai = "Xem Điểm";
            simpleButton1.Text = "XEM ĐIỂM";
            btnXemDiem.Enabled = false;
            btnNhapSuaDiem.Enabled = true;
            simpleButton1.Enabled = true;
            btnXemDiem.BackColor = System.Drawing.Color.Red;
            btnNhapSuaDiem.BackColor = System.Drawing.Color.Empty;
        }

        private void btnNhapSuaDiem_Click(object sender, EventArgs e)
        {
            Trangthai = "Tính Điểm";
            simpleButton1.Text = "TÍNH ĐIỂM TB";
            btnXemDiem.Enabled = true;
            btnNhapSuaDiem.Enabled = false;
            simpleButton1.Enabled = true;
            btnNhapSuaDiem.BackColor = System.Drawing.Color.Red;
            btnXemDiem.BackColor = System.Drawing.Color.Empty;
        }

        private void btnCanCel_Click(object sender, EventArgs e)
        {
            btnNhapSuaDiem.Enabled = true;
            btnXemDiem.Enabled = true;
            lblThongBao.Text = "Here";
            simpleButton1.Enabled = true;
            btnCanCel.Enabled = false;
            btnOK.Enabled = false;
            simpleButton1.Enabled = false;
            btnNhapSuaDiem.BackColor = System.Drawing.Color.Empty;
            btnXemDiem.BackColor = System.Drawing.Color.Empty;
            Trangthai = null;
            simpleButton1.Text = "...";
            dataGridView1.DataSource = null;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(Trangthai=="Tính Điểm")
            {
                if(dataGridView1.Rows.Count==0)
                {
                    MessageBox.Show("DataGridView Nothing ...");
                }
                else
                {
                    DiemTBTL a = new DiemTBTL();
                    if(a.KiemTra(dataGridView1)==true)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            String MSV = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            String NamHoc = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            double DiemHe10 = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                            double DiemHe4 = double.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                            int SoTC = int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                            int TongTCTichLuyTrongKy = int.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                            if (a.Check(MSV,NamHoc)==true)
                            {
                                a.insert(MSV, NamHoc, DiemHe10, DiemHe4, SoTC, TongTCTichLuyTrongKy);
                                String check = NamHoc.Substring(0, 11);
                                if (a.CheckDeNhapDiemCaNam(check, MSV)==true)
                                {
                                    Diem b = a.DiemtongKetSinhVien(check, MSV);
                                    String MSV_C = b.MaSV;
                                    String NH = check;
                                    double? Diem10 = Math.Round(Convert.ToDouble(b.DTB_HE10), 1);
                                    double? Diem4 = Math.Round(Convert.ToDouble(b.DTB_HE4), 2);
                                    int? tongtc = b.So_TCTL;
                                    int? tongtctichluy = b.So_TCTLtk;
                                    a.insertCaNam(MSV_C, NH, Diem10, Diem4, tongtc, tongtctichluy);
                                }
                            }
                            else
                            {
                                //update
                                a.update(MSV, NamHoc, DiemHe10, DiemHe4, SoTC, TongTCTichLuyTrongKy);
                                String check1 = NamHoc.Substring(0, 11);
                                if (a.CheckDeNhapDiemCaNam(check1, MSV) == true)
                                {
                                    Diem b = a.DiemtongKetSinhVien(check1, MSV);
                                    String MSV_C = b.MaSV;
                                    String NH = check1;
                                    double? Diem10 = Math.Round(Convert.ToDouble(b.DTB_HE10), 1);
                                    double? Diem4 = Math.Round(Convert.ToDouble(b.DTB_HE4), 2);
                                    int? tongtc = b.So_TCTL;
                                    int? tongtctichluy = b.So_TCTLtk;
                                    a.updateCaNam(MSV_C, NH, Diem10, Diem4, tongtc, tongtctichluy);
                                }
                            }
                        }
                        MessageBox.Show("Done :)");
                        Trangthai = null;
                        btnCanCel.Enabled = false;
                        btnOK.Enabled = false;
                        lblThongBao.Text = "Here";
                        btnXemDiem.Enabled = true;
                        btnNhapSuaDiem.Enabled = true;
                        btnNhapSuaDiem.BackColor = System.Drawing.Color.Empty;
                        dataGridView1.DataSource = null;
                    }
                    else
                    {
                        MessageBox.Show("Bạn Nên Kiểm Tra Lại, Có Cột Của Sinh Viên Không Có Điểm");
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
                dlg.Filter = "Excel Worksheets|*.xls";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
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

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
