using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonN6
{
    public partial class ThemTamTru : Form
    {
        public ThemTamTru()
        {
            InitializeComponent();
        }
        public Boolean click = false;

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMSV.Text == "" || txtMSV.Text == "Chọn Tên")
            {
                MessageBox.Show("Vui lòng chọn Sinh Viên nào đó");
            }
            else
            {
                String diachi = "" +txtNoitamtru.Text+","+cbboxPhuongxa.Text+","+cbboxQuanHuyen.Text+","+cbboxTinhThanhPho.Text+"";
                String diachireal = diachi.Trim();
                Sinhvien a = new Sinhvien();
                a.ExecuteNonQuery("insert into Hosotamtru values(" + int.Parse(txtMSV.Text) +  ",N'" + diachireal + "','" + dateTimePicker1.Value.ToString() + "',N'" + txtGhichu.Text + "')");
                MessageBox.Show("Thêm Dữ Liệu Thành Công");
                txtGhichu.Clear();
                txtNoitamtru.Clear();
                //this.Close();
            }
        }

        private void ThemTamTru_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            KhoaDT khoa = new KhoaDT();
            DataSet ds1 = new DataSet();
            ds1 = khoa.Loadkhoa();
            cbboxkhoa.DataSource = ds1.Tables[0];
            cbboxkhoa.DisplayMember = "Tenkhoa";
            cbboxkhoa.ValueMember = "Makhoa";

            Lop lop = new Lop();
            DataSet ds4 = new DataSet();
            ds4 = lop.LoadLop1();
            cbboxlop.DataSource = ds4.Tables[0];
            cbboxlop.DisplayMember = "Tenlop";
            cbboxlop.ValueMember = "Malop";


            
            cbboxchonkhoa.DataSource = ds1.Tables[0];
            cbboxchonkhoa.DisplayMember = "Tenkhoa";
            cbboxchonkhoa.ValueMember = "Makhoa";

            Diachi dc = new Diachi();
            DataSet ds = new DataSet();
            ds = dc.Load();
            cbboxTinhThanhPho.DataSource = ds.Tables[0];
            cbboxTinhThanhPho.DisplayMember = "Tentinh";
            cbboxTinhThanhPho.ValueMember = "Matinh";

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

        private void cbboxlop_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxlop.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                Sinhvien dc = new Sinhvien();
                DataSet ds = new DataSet();
                ds = dc.LoadSVselect(t);
                cbboxHoten.DataSource = ds.Tables[0];
                cbboxHoten.DisplayMember = "Hoten";
                cbboxHoten.ValueMember = "Hoten";
            }
        }

        private void cbboxHoten_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            Sinhvien a = new Sinhvien();
            Lop b = new Lop();
            t = cbboxHoten.SelectedValue.ToString();
            txtMSV.Text = a.MSV(t,b.Malop(cbboxlop.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbboxchonlop.Text == "")
            {
                MessageBox.Show("Chọn lớp đi");
            }
            else
            {
                click = true;
                Sinhvien a = new Sinhvien();
                Lop b = new Lop();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = a.getTable("select MSV,Hoten,Tenlop from SinhVien inner join Lop on SinhVien.Malop=Lop.Malop and SinhVien.Malop=" + b.Malop(cbboxchonlop.Text));
            }
        }


        private void cbboxchonkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxchonkhoa.SelectedValue.ToString();
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
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(click==true)
            {
                txtMSV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                cbboxHoten.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                cbboxlop.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cbboxTinhThanhPho_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxTinhThanhPho.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                Diachi dc = new Diachi();
                DataSet ds = new DataSet();
                ds = dc.LoadHuyen(t);
                cbboxQuanHuyen.DataSource = ds.Tables[0];
                cbboxQuanHuyen.DisplayMember = "Tenhuyen";
                cbboxQuanHuyen.ValueMember = "Mahuyen";
            }
        }

        private void cbboxQuanHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            t = cbboxQuanHuyen.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                Diachi dc = new Diachi();
                DataSet ds = new DataSet();
                ds = dc.LoadPhuong(t);
                cbboxPhuongxa.DataSource = ds.Tables[0];
                cbboxPhuongxa.DisplayMember = "Tenxa";
                cbboxPhuongxa.ValueMember = "Maxa";
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
