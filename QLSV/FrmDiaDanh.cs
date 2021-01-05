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
    public partial class FrmDiaDanh : Form
    {
        public FrmDiaDanh()
        {
            InitializeComponent();
        }

        static String trangthai = null;
        private void FrmDiaDanh_Load(object sender, EventArgs e)
        {
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Diachi dc = new Diachi();
            DataSet ds = new DataSet();
            ds = dc.Load();
            cbboxTinh.DataSource = ds.Tables[0];
            cbboxTinh.DisplayMember = "Tentinh";
            cbboxTinh.ValueMember = "Matinh";

            Diachi dc1 = new Diachi();
            DataSet ds2 = new DataSet();
            ds2 = dc1.LoadHuyen1();
            cbboxHuyen.DataSource = ds2.Tables[0];
            cbboxHuyen.DisplayMember = "Tenhuyen";
            cbboxHuyen.ValueMember = "Mahuyen";


            DataSet dt = new DataSet();
            dt=dc1.Load();
            cbboxTTP3.DataSource = dt.Tables[0];
            cbboxTTP3.DisplayMember = "Tentinh";
            cbboxTTP3.ValueMember = "Matinh";
            trangthai = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbboxdiadanh.Text != "")
            {
                Diachi a = new Diachi();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeRows();
                dataGridView1.DataSource = a.Loaddiachi(cbboxdiadanh.Text);
                if(cbboxdiadanh.Text=="Xa")
                {
                    trangthai = "Xa";
                }
                else if(cbboxdiadanh.Text == "Huyen")
                {
                    trangthai = "Huyen";
                }
                else if(cbboxdiadanh.Text=="Tinh")
                {
                    trangthai = "Tinh";
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn mục hiển thị");
            }
        }

        private void resettinhtp_Click(object sender, EventArgs e)
        {
            txtmatinh.Clear();
            txttentinh.Clear();
        }

        private void resetquanhuyen_Click(object sender, EventArgs e)
        {
            txtmaquanhuyen.Clear();
            txttenquanhuyen.Clear();
        }

        private void resetphuongxa_Click(object sender, EventArgs e)
        {
            txtmaphuongxa.Clear();
            txttenphuongxa.Clear();
        }

        private void btthemtinh_Click(object sender, EventArgs e)
        {
            if (txttentinh.Text != "")
            {
                Diachi a = new Diachi();
                a.themtinh(txttentinh.Text);
                MessageBox.Show("Thêm Thành Công");
            }
            else
            {
                MessageBox.Show("vui lòng Điền tên tỉnh");
            }
        }

        private void btsuatinh_Click(object sender, EventArgs e)
        {
            if (txtmatinh.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Update", "Xác nhận chỉnh sửa?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Diachi a = new Diachi();
                    a.updatetinh(int.Parse(txtmatinh.Text), txttentinh.Text);
                    MessageBox.Show("Sửa Thành Công");
                }
            }
            else
            {
                MessageBox.Show("vui lòng chọn đối tượng");
            }
        }

        private void btxoatinh_Click(object sender, EventArgs e)
        {
            if (txtmatinh.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Delete", "Bạn thực sự muốn xóa?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Diachi a = new Diachi();
                    try
                    {
                        a.Xoatinh(int.Parse(txtmatinh.Text));
                        MessageBox.Show("Xóa Thành Công");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại.Tồn Tại Huyện Thuộc tỉnh thành này.");
                    }
                }
            }
            else
            {
                MessageBox.Show("vui lòng chọn đối tượng");
            }
        }

        private void btthemhuyen_Click(object sender, EventArgs e)
        {
            if (txttenquanhuyen.Text != "")
            {
                Diachi a = new Diachi();
                a.themhuyen(txttenquanhuyen.Text, a.Matinh(cbboxTinh.Text));
                MessageBox.Show("Thêm Thành Công");
            }
            else
            {
                MessageBox.Show("vui lòng Điền tên Huyện");
            }
        }

        private void btsuahuyen_Click(object sender, EventArgs e)
        {
            if (txtmaquanhuyen.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Update", "Bạn xác nhận chỉnh sửa?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Diachi a = new Diachi();
                    a.updatehuyen(int.Parse(txtmaquanhuyen.Text), txttenquanhuyen.Text, a.Matinh(cbboxTinh.Text));
                    MessageBox.Show("Sửa Thành Công");
                }
            }
            else
            {
                MessageBox.Show("vui lòng chọn đối tượng");
            }
        }

        private void btxoahuyen_Click(object sender, EventArgs e)
        {
            if (txtmaquanhuyen.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Delete", "Bạn thực sự muốn xóa?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    try
                    {
                        Diachi a = new Diachi();
                        a.Xoahuyen(int.Parse(txtmaquanhuyen.Text));
                        MessageBox.Show("Xóa Thành Công");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại, Tồn tại xã thuộc huyện này");
                    }
                }
            }
            else
            {
                MessageBox.Show("vui lòng chọn đối tượng");
            }
        }

        private void btnthemXa_Click(object sender, EventArgs e)
        {
            if (txttenphuongxa.Text != "")
            {
                Diachi a = new Diachi();
                a.themxa(txttenphuongxa.Text, a.Mahuyen(cbboxHuyen.Text));
                MessageBox.Show("Thêm Thành Công");
            }
            else
            {
                MessageBox.Show("vui lòng Điền tên Xã");
            }
        }

        private void btnSuaXa_Click(object sender, EventArgs e)
        {
            if (txtmaphuongxa.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Update", "Bạn đồng ý chỉnh sửa?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Diachi a = new Diachi();
                    a.updatexa(int.Parse(txtmaphuongxa.Text), txttenphuongxa.Text, a.Mahuyen(cbboxHuyen.Text));
                    MessageBox.Show("Sửa Thành Công");
                }
            }
            else
            {
                MessageBox.Show("vui lòng chọn đối tượng");
            }
        }

        private void btnXoaXa_Click(object sender, EventArgs e)
        {
            if (txtmaphuongxa.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Delete", "Bạn thực sự muốn xóa?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    try
                    {
                        Diachi a = new Diachi();
                        a.Xoaxa(int.Parse(txtmaphuongxa.Text));
                        MessageBox.Show("Xóa Thành Công");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Xóa thất bại, Tồn tại sinh viên đang ở phường xã này.");
                    }
                }
            }
            else
            {
                MessageBox.Show("vui lòng chọn đối tượng");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {

            }
            {
                if (trangthai == "Tinh")
                {
                    txtmatinh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txttentinh.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                }
                if (trangthai == "Huyen")
                {
                    txtmaquanhuyen.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txttenquanhuyen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    //tmatinhtpquanhuyen.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    cbboxTinh.SelectedIndex = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) - 1;
                }
                if (trangthai == "Xa")
                {
                    Diachi dc=new Diachi();
                    DataSet dt = new DataSet();
                    dt = dc.Load();
                    cbboxTTP3.DataSource = dt.Tables[0];
                    cbboxTTP3.DisplayMember = "Tentinh";
                    cbboxTTP3.ValueMember = "Matinh";

                    Diachi dc1 = new Diachi();
                    DataSet ds = new DataSet();
                    ds = dc1.LoadHuyen1();
                    cbboxHuyen.DataSource = ds.Tables[0];
                    cbboxHuyen.DisplayMember = "Tenhuyen";
                    cbboxHuyen.ValueMember = "Mahuyen";

                    Diachi a = new Diachi();
                    txtmaphuongxa.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txttenphuongxa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    cbboxHuyen.Text = a.Tenhuyen(int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()));
                }
            }
        }

        private void cbboxTTP3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtmaphuongxa.Text == "")
            {
                String t;
                t = cbboxTTP3.SelectedValue.ToString();
                if (t == "System.Data.DataRowView")
                {

                }
                else
                {
                    Diachi dc = new Diachi();
                    DataSet ds = new DataSet();
                    ds = dc.LoadHuyen(t);
                    cbboxHuyen.DataSource = ds.Tables[0];
                    cbboxHuyen.DisplayMember = "Tenhuyen";
                    cbboxHuyen.ValueMember = "Mahuyen";
                }
            }
        }

        private void cbboxHuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t = cbboxHuyen.SelectedValue.ToString();
            if (t == "System.Data.DataRowView")
            {

            }
            else
            {
                Diachi a = new Diachi();
                cbboxTTP3.Text = a.TenTinh(int.Parse(t)); 
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }
    }
}
