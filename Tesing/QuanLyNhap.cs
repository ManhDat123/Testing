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
        Conn conn = new Conn();
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
            name.Text = DangNhap.ten;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            conn.OpenConnection();
            String cond = textBox7.Text;
            String search = "select * from ql_nhap where ten like'%" + cond + "%';";
            dt1.DataSource = conn.Select(search);
            conn.CloseConnection();
        }
    }
}
