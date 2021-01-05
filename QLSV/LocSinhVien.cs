using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonN6
{
    class LocSinhVien
    {
        private String maSV;
        private String hoTen;
        private String tenLop;
        private String namHoc;
        private String diemHe10;
        private String diemHe4;
        private String diemRL;
        private String SoTC;

        public LocSinhVien(String MSV,String HoTen,String TenLop,String NamHoc,String Diem10,String Diem4,String DiemRL,String SoTC)
        {
            this.maSV = MSV;
            this.hoTen = HoTen;
            this.tenLop = TenLop;
            this.namHoc = NamHoc;
            this.diemHe10 = Diem10;
            this.diemHe4 = Diem4;
            this.diemRL = DiemRL;
            this.SoTC = SoTC;
        }


        public String ma_SV  // property
        {
            get { return maSV; }   // get method
            set { maSV = value; }  // set method
        }

        public String ho_ten  // property
        {
            get { return hoTen; }   // get method
            set { hoTen = value; }  // set method
        }

        public String ten_lop  // property
        {
            get { return tenLop; }   // get method
            set { tenLop = value; }  // set method
        }

        public String nam_hoc  // property
        {
            get { return namHoc; }   // get method
            set { namHoc = value; }  // set method
        }

        public String diem_he_10  // property
        {
            get { return diemHe10; }   // get method
            set { diemHe10 = value; }  // set method
        }

        public String diem_he_4  // property
        {
            get { return diemHe4; }   // get method
            set { diemHe4 = value; }  // set method
        }

        public String diem_rl  // property
        {
            get { return diemRL; }   // get method
            set { diemRL = value; }  // set method
        }

        public String so_tc  // property
        {
            get { return SoTC; }   // get method
            set { SoTC = value; }  // set method
        }

    }
}
