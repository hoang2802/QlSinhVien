using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace QlSinhVien
{
    class SinhVienDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public SinhVienDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getAllSinhVien()
        {
            //Tao cau lenh lay toan bon sv
            //string sql = "SELECT * FROM SinhVien";
            //Tao ket noi den sql
            SqlConnection con = dc.getConnect();
            //Khoi tao doi tuong cua lop SqlDataADapter
            cmd = new SqlCommand("SinhVien_SelectAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            con.Open();
            //Do du lieu tu SqldataAdapter vao Database
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool InsertSinhVien(SinhVien sv)
        {
            //string sql = "INSERT INTO SinhVien(MaSV,HoTen,NgaySinh, GT,DiaChi,SDT) VALUES(@MaSV,@HoTen,@NgaySinh, @GT,@DiaChi,@SDT)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand("SinhVien_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = sv.HoTen;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.NVarChar).Value = sv.NgaySinh;
                cmd.Parameters.Add("@GT", SqlDbType.NVarChar).Value = sv.GT;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = sv.DiaChi;
                cmd.Parameters.Add("@SDT", SqlDbType.Char).Value = sv.SDT;
                //Thuc thi cau lenh lop Command
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {
               
                return false;
            }
            return true;
        }
        public bool UpdateSinhVien(SinhVien sv)
        {
            //string sql = "UPDATE SinhVien SET HoTen=@HoTen,NgaySinh=@NgaySinh,GT=@GT,DiaChi=@DiaChi,SDT=@SDT WHERE MaSV=@MaSV ";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand("SinhVien_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                
                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSV;
                cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = sv.HoTen;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.NVarChar).Value = sv.NgaySinh;
                cmd.Parameters.Add("@GT", SqlDbType.NVarChar).Value = sv.GT;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = sv.DiaChi;
                cmd.Parameters.Add("@SDT", SqlDbType.Char).Value = sv.SDT;
                //Thuc thi cau lenh lop Command
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool DeleteSinhVien(SinhVien sv)
        {
            //string sql = "DELETE FROM SinhVien WHERE MaSV=@MaSV";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand("SinhVien_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar).Value = sv.MaSV;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
       
    }
}
