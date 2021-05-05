using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QlSinhVien
{
    class SinhVienBLL
    {
        //Khoi tao dataAccess
        SinhVienDAL dalSV;
        public SinhVienBLL()
        {
            dalSV = new SinhVienDAL();
        }
        public DataTable getAllSinhVien()
        {
            return dalSV.getAllSinhVien();
        }
        public bool InsertSinhVien(SinhVien sv)
        {
            return dalSV.InsertSinhVien(sv);
        }
        public bool UpdateSinhVien(SinhVien sv)
        {
            return dalSV.UpdateSinhVien(sv);
        }
        public bool DeleteSinhVien(SinhVien sv)
        {
            return dalSV.DeleteSinhVien(sv);
        }
       
    }
}
