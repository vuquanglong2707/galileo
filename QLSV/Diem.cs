using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLonN6
{
    class Diem
    {
        private String MSV;
        private double? DTBHE10;
        private double? DTBHE4;
        private int? SoTCTL;
        private int? SoTCTichLuyTrongKy;
        public String MaSV  // property
        {
            get { return MSV; }   // get method
            set { MSV = value; }  // set method
        }

        public double? DTB_HE10  // property
        {
            get { return DTBHE10; }   // get method
            set { DTBHE10 = value; }  // set method
        }

        public double? DTB_HE4  // property
        {
            get { return DTBHE4; }   // get method
            set { DTBHE4 = value; }  // set method
        }

        public int? So_TCTL  // property
        {
            get { return SoTCTL; }   // get method
            set { SoTCTL = value; }  // set method
        }

        public int? So_TCTLtk  // property
        {
            get { return SoTCTichLuyTrongKy; }   // get method
            set { SoTCTichLuyTrongKy = value; }  // set method
        }
    }
}
