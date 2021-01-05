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
    public partial class FrmLop : Form
    {
        public FrmLop()
        {
            InitializeComponent();
        }
        public Boolean click = false;
        public Boolean click2 = false;
        private void FrmLop_Load(object sender, EventArgs e)
        {
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            KhoaDT dc = new KhoaDT();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = dc.Loadkhoa();
            cbboxKhoa.DataSource = ds.Tables[0];
            cbboxKhoa.DisplayMember = "Tenkhoa";
            cbboxKhoa.ValueMember = "Makhoa";
            dt = dc.Loadkhoa2();
            cbboxKhoa1.DataSource = dt;
            cbboxKhoa1.DisplayMember = "Tenkhoa";
            cbboxKhoa1.ValueMember = "Makhoa";

            DataSet ds1 = new DataSet();
            ds1 = dc.LoadkhoaHoc();
            comboKH.DataSource = ds1.Tables[0];
            comboKH.DisplayMember = "TenKhoaHoc";
            comboKH.ValueMember = "MakhoaHoc";


            DataSet ds2 = new DataSet();
            ds2 = dc.LoadkhoaHoc();
            cbboxKH2.DataSource = ds2.Tables[0];
            cbboxKH2.DisplayMember = "TenKhoaHoc";
            cbboxKH2.ValueMember = "MakhoaHoc";


            /*
            DataGridViewComboBoxColumn TrangThai = new DataGridViewComboBoxColumn();
            var list11 = new List<string>() { "Đã Hoàn Thành", "Đang Quản Lý"};
            TrangThai.DataSource = list11;
            TrangThai.HeaderText = "Trạng Thái";
            TrangThai.DataPropertyName = "TrangThai";
            TrangThai.FlatStyle = FlatStyle.Flat;
            TrangThai.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;



            dataGridView2.Columns.AddRange(TrangThai);
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[0].ReadOnly = true;
            */
            


        }

        private void btLoadLop_Click(object sender, EventArgs e)
        {
            Lop k = new Lop();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = k.LoadLop();
            click = true;
        }

        private void btThemLop_Click(object sender, EventArgs e)
        {
            if (txtTenlop.Text != "")
            {
                
                Lop a = new Lop();
                if (a.checklop123(txtTenlop.Text) == true)
                {
                    try
                    {
                        a.Them(txtTenlop.Text, a.MaKhoa(cbboxKhoa.Text),cbboxKH2.SelectedValue.ToString());
                        MessageBox.Show("Thêm Thành Công");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Vượt Quá Kí tự cho phép !!");
                        
                    }
                    
                    dataGridView1.DataSource = a.LoadLop();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.Tên Lớp này đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("vui lòng điền tên lớp");
            }
        }



        private void btsuaLop_Click(object sender, EventArgs e)
        {
            if (txtMalop1.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Xác Nhận Chỉnh Sửa?", "Edit Liền Là Edit Liền", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Lop b = new Lop();
                    //b.update(int.Parse(txtMalop1.Text), txtTenlop1.Text, b.MaKhoa(cbboxKhoa1.Text));
                    try
                    {
                        if (b.checklop(txtTenlop1.Text,txtMalop1.Text) == true)
                        {
                            b.ExecuteNonQuery("UPDATE Lop SET Tenlop=N'" + txtTenlop1.Text + "',Makhoa=" + b.MaKhoa(cbboxKhoa1.Text) +",Khoa=N'"+comboKH.SelectedValue.ToString() +"' where Malop=" + int.Parse(txtMalop1.Text));
                            MessageBox.Show("Sửa thành công");
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại.Tên lớp này đã tồn tại");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Sửa không thành công. Lỗi vượt quá kí tự !");
                    }
                    //dataGridView1.DataSource = b.LoadLop();
                    txtMalop1.Clear();
                    txtTenlop1.Clear();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đối tượng");
            }
        }

        private void btXoaLop_Click(object sender, EventArgs e)
        {
            if (txtMalop1.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Delete", "Bạn thực sự muốn xóa?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Lop a = new Lop();
                    if (a.check(int.Parse(txtMalop1.Text)) == false)
                    {
                        a.delete(int.Parse(txtMalop1.Text));
                        MessageBox.Show("Xóa Thành Công");
                        a.LoadLop();
                    }
                    else
                    {
                        MessageBox.Show("Thất bại.Tồn Tại SV Đang Học Tại Lớp Này");
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
            if (click == true)
            {
                if (dataGridView1.Rows.Count == 0)
                {

                }
                else
                {
                    txtMalop1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtTenlop1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    KhoaDT b = new KhoaDT();
                    cbboxKhoa1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    if (dataGridView1.CurrentRow.Cells[3].Value.ToString() != "")
                    {
                        comboKH.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    }
                }
            }
        }

        private void btnCapNhatKhoa_Click(object sender, EventArgs e)
        {
            Lop a = new Lop();
            dataGridView2.DataSource = a.LoadKhoaHoc();
            click2 = true;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                dataGridView2[3, i] = linkCell;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }



        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            if (txtMaKhoaHoc.Text != "")
            {
                Lop a = new Lop();
                if (a.checkmakhoathem(txtMaKhoaHoc.Text) == true)
                {
                    if (a.checkthemkhoatrungtenkhoa(txtTenKHoaHoc.Text) == true)
                    {
                        try
                        {
                            a.ThemKhoaHoc(txtMaKhoaHoc.Text, txtTenKHoaHoc.Text,cbboxTinhTrang.Text);
                            MessageBox.Show("Thêm Thành Công");
                            txtTenKHoaHoc.Clear();
                            txtMaKhoaHoc.Clear();
                            dataGridView2.DataSource = a.LoadKhoaHoc();
                            for (int i = 0; i < dataGridView2.Rows.Count; i++)
                            {
                                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                                dataGridView2[3, i] = linkCell;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đã có tên khóa này");
                    }

                    dataGridView2.DataSource = a.LoadKhoaHoc();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại.Mã Khóa này đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("vui lòng điền Mã Khóa");
            }
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (click2 == true)
            {
                if (dataGridView2.Rows.Count == 0)
                {

                }
                else
                {
                    txtMaKhoaHoc.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    txtTenKHoaHoc.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                    cbboxTinhTrang.Text= dataGridView2.CurrentRow.Cells[2].Value.ToString();
                }
            }

            if (dataGridView2.Rows.Count == 0)
            {

            }
            else
            {
                if (e.ColumnIndex == 3)
                {
                    Lop a = new Lop();
                    string Task = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                    if (Task == "Delete")
                    {
                        if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            String ID = dataGridView2.Rows[rowIndex].Cells[0].Value.ToString();
                            a.XoaKhoaHoc(ID);
                            dataGridView2.DataSource = a.LoadKhoaHoc();
                            for (int i = 0; i < dataGridView2.Rows.Count; i++)
                            {
                                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                                dataGridView2[3, i] = linkCell;
                            }
                        }
                    }
                }

            }

        }

        

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtMaKhoaHoc.Clear();
            txtTenKHoaHoc.Clear();
            cbboxTinhTrang.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMaKhoaHoc.Text != "")
            {
                DialogResult thongbao;
                thongbao = MessageBox.Show("Xác Nhận Chỉnh Sửa?", "Edit Liền Là Edit Liền", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (thongbao == DialogResult.OK)
                {
                    Lop b = new Lop();
                    try
                    {
                        if(b.checkkhoahoc(txtTenKHoaHoc.Text,txtMaKhoaHoc.Text)==true)
                        {
                            b.SuaKhoaHoc(txtMaKhoaHoc.Text, txtTenKHoaHoc.Text, cbboxTinhTrang.Text);
                            MessageBox.Show("Done :)");
                            dataGridView2.DataSource = b.LoadKhoaHoc();
                            txtMaKhoaHoc.Clear();
                            txtTenKHoaHoc.Clear();
                            for (int i = 0; i < dataGridView2.Rows.Count; i++)
                            {
                                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                                dataGridView2[3, i] = linkCell;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Trùng Tên KH");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Bạn không thể sửa Mã khóa học");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đối tượng");
            }
        }

        private void cbboxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView2.ClearSelection();
        }
    }
}
