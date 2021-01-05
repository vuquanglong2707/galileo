using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonN6
{
    public delegate void SendMessage(String value,String quyen);
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
        }
        static String quyenhan = "";
        static String username = "";
        private void SetValue(String value,String quyen) //truyền giá trị nhận từ form frmlogin
        {
            //this.lblTrangThaiDN.Text = "Xin chào : " + value;
            this.trangthaidn = true;
            quyenhan = quyen;
            username = value;
            LoadLai(value,quyen);
        }

        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;


        public Boolean trangthaidn = false;
        public String tendn;

        //Bật menu
        public void EnableMenuAdmin()
        {
            btnHoSoSinhVien.Enabled = true;
            btnHoSoTamTru.Enabled = true;
            btnDiemRenLuyen.Enabled = true;
            btnDiaDanh.Enabled = true;
            btnDanhSachLop.Enabled = true;
            btnDanhSachKhoa.Enabled = true;
            btnThongKe.Enabled = true;
            btnQLMonHoc.Enabled = true;
            btnQLTaiKhoan.Enabled = true;
            btnQLGiangVien.Enabled = true;
            btnQLDiem.Enabled = true;
            //btnTBTL.Enabled = true;
            btnNhapDiem.Enabled = true;
            btnXetHocBongnull.Enabled = true;
        }
        //Tắt menu admin
        public void DisableMenuAdmin()
        {
            btnHoSoSinhVien.Enabled = false;
            btnHoSoTamTru.Enabled = false;
            btnDiemRenLuyen.Enabled = false;
            btnDiaDanh.Enabled = false;
            btnDanhSachLop.Enabled = false;
            btnDanhSachKhoa.Enabled = false;
            btnThongKe.Enabled = false;
            btnQLMonHoc.Enabled = false;
            btnQLTaiKhoan.Enabled = false;
            btnQLGiangVien.Enabled = false;
            btnQLDiem.Enabled = false;
            //btnTBTL.Enabled = false;
            btnXetHocBongnull.Enabled = false;
        }
        //bật menu tài khoản sinh viên
        public void EnableMenuSV()
        {
            btnHoSoSinhVien.Enabled = true;
            btnHoSoTamTru.Enabled = true;
            btnDiemRenLuyen.Enabled = true;
            btnNhapDiem.Enabled = false;
            btnQLMonHoc.Enabled = false;
            btnQLDiem.Enabled = true;
        }
        //bật menu quyền cho giảng viên
        public void EnableMenuGV()
        {
            btnDiemRenLuyen.Enabled = true;
            btnNhapDiem.Enabled = true;
            btnXemDiem.Enabled = true;
            btnQLGiangVien.Enabled = true;
            btnQLGiangVien.Text = "GIẢNG VIÊN";
        }
        //Chọn màu
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }

            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        //

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisnableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    /*
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    
                    */
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisnableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        //Mở form con 
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        // mở form login con
        private void OpenChildFormLogin(Form childForm, object btnSender)
        {
            
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.MdiParent = this;
            childForm.Dock = DockStyle.Fill;      
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        //Quay lại trang home
        private void Reset()
        {
            DisnableButton();
            lblTitle.Text = "HOME";
            /*
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            */
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        //Check đăng nhập
        private void FrmMain_Load(object sender, EventArgs e)
        {
            
            if (trangthaidn == false)
            {
                lblTrangThaiDN.Text = "Bạn Chưa Đăng Nhập";
                DisableMenuAdmin();
            }
            else
            {
                btnDangNhap.Enabled=false;
                lblTrangThaiDN.Text = "Xin chào : " + tendn;
                thoatLogin.Text = "Thoát";
                EnableMenuAdmin();
            }
            
        }

        public void LoadLai(String tendnhap,String quyen)
        {
            if (trangthaidn == false)
            {
                lblTrangThaiDN.Text = "Bạn Chưa Đăng Nhập";
                DisableMenuAdmin();
            }
            else
            {
                //ĐĂNG NHẬP THÀNH CÔNG
                lblTrangThaiDN.Text = "Xin chào : " + tendnhap +"("+quyen+")";
                lblTitle.Text = "HOME";
                thoatLogin.Text = "Thoát";
                if (quyen == "Quản Lý")
                {
                    EnableMenuAdmin();
                    btnDangNhap.Text = "MỞ LỚP HỌC";
                    btnQLDiem.Text = "QUẢN LÝ ĐIỂM";
                    btnQLGiangVien.Text = "  QL GIẢNG VIÊN";
                    linkdoimatkhau.Visible = true;
                    panel4.Visible = true;
                }
                else if(quyen =="Sinh Viên")
                {
                    EnableMenuSV();
                    btnDangNhap.Text = "ĐĂNG KÝ HỌC";
                    btnQLDiem.Text = "  ĐIỂM MÔN HỌC";
                    linkdoimatkhau.Visible = true;
                    panel4.Visible = true;
                }
                else if(quyen == "Giảng Viên")
                {
                    btnDangNhap.Text = "";
                    EnableMenuGV();
                    btnQLDiem.Text = "QL ĐIỂM";
                    linkdoimatkhau.Visible = true;
                    panel4.Visible = true;
                    btnDangNhap.Text = "ĐIỂM SV";
                }
            }
        }

        private void btnHoSoSinhVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.HoSoSinhVien(quyenhan, username), sender);
        }

        
        
        private void btnHoSoTamTru_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.HoSoTamTru(username,quyenhan), sender);
        }

        private void btnDanhSachLop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.FrmLop(), sender);
        }

        private void btnDanhSachKhoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.Khoa(), sender);
        }

        private void btnDiemRenLuyen_Click(object sender, EventArgs e)
        {
            if (btnNhapDiem.Visible == false)
            {
                btnXemDiem.Visible = true;
                btnNhapDiem.Visible = true;
            }
            else
            {
                btnNhapDiem.Visible = false;
                btnXemDiem.Visible = false;
            }
        }

        private void btnDiaDanh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.FrmDiaDanh(), sender);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.ThongKe(), sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contact : https://www.facebook.com/quanglong27 ");
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            Reset();
        }

        private void thoatLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisableMenuAdmin();
            btnDangNhap.Text = "ĐĂNG NHẬP";
            lblTrangThaiDN.Text = "Bạn Chưa Đăng Nhập";
            thoatLogin.Text = "";
            lblTitle.Text = "HOME";
            btnCloseChildForm.Hide();
            panel4.Visible = false;
            linkdoimatkhau.Visible = false;

            if (activeForm != null)
            {
                activeForm.Close();
            }
            if(btnNhapDiem.Visible==true)
            {
                btnNhapDiem.Visible = false;
                btnXemDiem.Visible = false;
            }
            Reset();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (btnDangNhap.Text == "ĐĂNG NHẬP")
            {
                OpenChildFormLogin(new BaiTapLonN6.FrmLogin(SetValue), sender);
            }
            else if(btnDangNhap.Text == "MỞ LỚP HỌC")
            {
                OpenChildFormLogin(new BaiTapLonN6.FrmTaoLopDangKyHoc(), sender);
            }
            else if(btnDangNhap.Text == "ĐĂNG KÝ HỌC")
            {
                OpenChildFormLogin(new BaiTapLonN6.FrmSinhVienDangKyHoc(username), sender);
            }
            else if(btnDangNhap.Text == "ĐIỂM SV")
            {
                OpenChildFormLogin(new BaiTapLonN6.FrmGiangVienNhapDiemMonHoc(username), sender);
            }
        }

        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.FrmNhapDiemRL(), sender);
        }

        private void btnXemDiem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.FrmXemDiemRL(quyenhan,username), sender);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnQLGiangVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.FrmQLTaiKhoan(), sender);
        }

        private void btnQLGiangVien_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.FrmQLGiangVien(username,quyenhan), sender);
        }

        private void btnQLMonHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.FrmMonHoc(), sender);
        }

        private void btnQLDiem_Click(object sender, EventArgs e)
        {
            if(quyenhan=="Sinh Viên")
            {
                OpenChildForm(new BaiTapLonN6.FrmXemDiem(username), sender);
            }
            else if(quyenhan=="Giảng Viên")
            {
                OpenChildForm(new BaiTapLonN6.FrmQLDiem(), sender);
            }
            else if(quyenhan=="Quản Lý")
            {
                OpenChildForm(new BaiTapLonN6.FrmQLDiem(), sender);
            }
        }

        private void btnTBTL_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.FrmTBTL(), sender);
        }

        private void btnXetHocBong_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BaiTapLonN6.FrmXetHocBong(), sender);
        }

        private void linkdoimatkhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmREGISTER frm = new FrmREGISTER(username);
            frm.ShowDialog();
        }

        private void panelDesktopPane_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
