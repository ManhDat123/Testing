using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tesing
{
    public partial class QuanLyNhap : Form
    {
        Conn conn = DangNhap.instance.conn;
        public QuanLyNhap()
        {
            InitializeComponent();
            conn.initilize();
            conn.OpenConnection();
            String select = "select * from ql_nhap";
            dt1.DataSource= conn.Select(select);
            conn.CloseConnection();
            dt1.Columns[0].HeaderText = "ID";
            dt1.Columns[1].HeaderText = "Tên nhân viên";
            dt1.Columns[2].HeaderText = "Tên đại lý";
            dt1.Columns[3].HeaderText = "Mặt hàng";
            dt1.Columns[4].HeaderText = "Đơn vị";
            dt1.Columns[5].HeaderText = "Số lượng";
            dt1.Columns[6].HeaderText = "Đơn giá";
            dt1.Columns[7].HeaderText = "Ngày nhập";
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                DangNhap dn = new DangNhap();
                dn.ShowDialog();
            }
        }
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinCaNhan tt = new ThongTinCaNhan();
            this.Hide();
            tt.ShowDialog();
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan qltk = new QuanLyTaiKhoan();
            this.Hide();
            qltk.ShowDialog();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien qlnv = new QuanLyNhanVien();
            this.Hide();
            qlnv.ShowDialog();
        }

        private void btnQLHH_Click(object sender, EventArgs e)
        {
            QuanLyHangHoa qlhh = new QuanLyHangHoa();
            this.Hide();
            qlhh.ShowDialog();
        }

        private void btnQLX_Click(object sender, EventArgs e)
        {
            QuanLyXuat qlx = new QuanLyXuat();
            this.Hide();
            qlx.ShowDialog();
        }

        private void btnBCTK_Click(object sender, EventArgs e)
        {
            BaoCaoThongKe bctk = new BaoCaoThongKe();
            this.Hide();
            bctk.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau dmk = new DoiMatKhau();
            this.Hide();
            dmk.ShowDialog();
        }

        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HuongDan hd = new HuongDan();
            this.Hide();
            hd.ShowDialog();
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu();
            this.Hide();
            tc.ShowDialog();
        }

        private void btnQLTK_Click_1(object sender, EventArgs e)
        {
            QuanLyNhap qln = new QuanLyNhap();
            this.Hide();
            qln.ShowDialog();
        }

        private void QuanLyNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.IsExiting && e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Program.IsExiting = true;
                    Application.Exit();
                }
            }
        }

        private void QuanLyNhap_Load(object sender, EventArgs e)
        {
            name.Text = DangNhap.instance.ten;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            conn.OpenConnection();
            String cond = textBox7.Text;
            String search = "select * from ql_nhap where ten like'%" + cond + "%';";
            dt1.DataSource = conn.Select(search);
            conn.CloseConnection();
        }

        private void dt1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dt1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dt1.CurrentRow.Cells[1].Value.ToString();
            textBox9.Text = dt1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dt1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dt1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dt1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dt1.CurrentRow.Cells[4].Value.ToString();
            dateTimePicker1.Value = (DateTime)dt1.CurrentRow.Cells[7].Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO ql_nhap (id, ten_nhan_vien, ten_dai_ly, ten, don_vi, so_luong, don_gia, date) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox9.Text + "',  '" + textBox8.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')";
            conn.Insert(sql);
            DataTable dt = conn.Select("select * from ql_nhap");
            dt1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dt1.SelectedRows.Count > 0)
            {
                String sql = "UPDATE ql_nhap SET id = '" + textBox1.Text + "', ten_nhan_vien = '" + textBox2.Text + "', ten_dai_ly = '" + textBox9.Text + "', ten = '" + textBox8.Text + "', don_vi = '" + textBox3.Text + "', so_luong = '" + textBox4.Text + "', don_gia = '" + textBox5.Text + "', date = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' WHERE id ='" + dt1.CurrentRow.Cells[0].Value.ToString() + "'";
                conn.Update(sql);
                DataTable dt = conn.Select("select * from ql_nhap");
                dt1.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dt1.SelectedRows.Count > 0)
            {
                String sql = "DELETE FROM ql_nhap WHERE id ='" + dt1.CurrentRow.Cells[0].Value.ToString() + "'";
                conn.Insert(sql);
                DataTable dt = conn.Select("select * from ql_nhap");
                dt1.DataSource = dt;
            }
        }

        private void dt1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
