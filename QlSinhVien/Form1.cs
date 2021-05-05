using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlSinhVien
{
    public partial class Form1 : Form
    {
        SinhVienBLL bllSV;
        public Form1()
        {
            
            InitializeComponent();
            bllSV = new SinhVienBLL();
        }
        public void ShowAllSinhVien()
        {
            DataTable dt = bllSV.getAllSinhVien();
            dataGridView1.DataSource = dt;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowAllSinhVien();
        }
        public bool CheckData()
        {
            if(string.IsNullOrEmpty(txtMaSV.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Bạn chưa nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtGT.Text))
            {
                MessageBox.Show("Bạn chưa nhập giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return false;
            }
            return true;
        }

        private void Them_Click(object sender, EventArgs e)
        {
            if(CheckData())
            {
                SinhVien sv = new SinhVien();
                sv.MaSV = txtMaSV.Text;
                sv.HoTen = txtHoTen.Text;
                sv.NgaySinh = dateTimeNgaySinh.Text;
                sv.GT = txtGT.Text;
                sv.DiaChi = txtDiaChi.Text;
                sv.SDT = txtSDT.Text;
                if (bllSV.InsertSinhVien(sv))
                    ShowAllSinhVien();
                else
                    MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index >=0)
            {
                txtMaSV.Text = dataGridView1.Rows[index].Cells["MaSV"].Value.ToString();
                txtHoTen.Text = dataGridView1.Rows[index].Cells["HoTen"].Value.ToString();
                dateTimeNgaySinh.Text = dataGridView1.Rows[index].Cells["NgaySinh"].Value.ToString();
                txtGT.Text = dataGridView1.Rows[index].Cells["GT"].Value.ToString();
                txtDiaChi.Text = dataGridView1.Rows[index].Cells["DiaChi"].Value.ToString();
                txtSDT.Text = dataGridView1.Rows[index].Cells["SDT"].Value.ToString();

            }
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                SinhVien sv = new SinhVien();
                sv.MaSV = txtMaSV.Text;
                sv.HoTen = txtHoTen.Text;
                sv.NgaySinh = dateTimeNgaySinh.Text;
                sv.GT = txtGT.Text;
                sv.DiaChi = txtDiaChi.Text;
                sv.SDT = txtSDT.Text;
                if (bllSV.UpdateSinhVien(sv))
                    ShowAllSinhVien();
                else
                    MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa không ?","Cảnh báo", MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SinhVien sv = new SinhVien();
                sv.MaSV = txtMaSV.Text;
                if (bllSV.DeleteSinhVien(sv))
                    ShowAllSinhVien();
                else
                    MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }    
                
        }

        private void Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        }
    }
