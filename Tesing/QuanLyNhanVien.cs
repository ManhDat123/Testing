using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tesing
{
    public partial class QuanLyNhanVien : Form
    {
        Conn conn = new Conn();
        public QuanLyNhanVien()
        {
            InitializeComponent();
            
            conn.initilize();
            conn.OpenConnection();
            String select = "select * from nhan_vien";
            dt1.DataSource = conn.Select(select);
            conn.CloseConnection();
            dt1.Columns[0].HeaderText = "ID";
            dt1.Columns[1].HeaderText = "Tên";
            dt1.Columns[2].HeaderText = "Giới tính";
            dt1.Columns[3].HeaderText = "Ngày sinh";
            dt1.Columns[4].HeaderText = "Địa chỉ";
            dt1.Columns[5].HeaderText = "SĐT";
            dt1.Columns[6].HeaderText = "Ghi chú";
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinCaNhan tt = new ThongTinCaNhan();
            this.Hide();
            tt.ShowDialog();

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

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan qltk = new QuanLyTaiKhoan();
            this.Hide();
            qltk.ShowDialog();
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

        private void btnQLN_Click(object sender, EventArgs e)
        {
            QuanLyNhap qln = new QuanLyNhap();
            this.Hide();
            qln.ShowDialog();
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

        private void QuanLyNhanVien_FormClosing(object sender, FormClosingEventArgs e)
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

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            fullname.Text = DangNhap.ten;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            conn.OpenConnection();
            String cond = textBox7.Text;
            String search = "select * from nhan_vien where name like'%" + cond + "%';";
            dt1.DataSource = conn.Select(search);
            conn.CloseConnection();
        }
    }
}
