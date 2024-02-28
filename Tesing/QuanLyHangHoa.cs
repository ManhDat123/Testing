using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Tesing
{
    public partial class QuanLyHangHoa : Form
    {
        Conn conn = new Conn();
        public QuanLyHangHoa()
        {
            InitializeComponent();

            String select = "select * from nguyen_lieu";


            conn.initilize();
            conn.OpenConnection();

            dt1.DataSource = conn.Select(select);
            dt1.Columns[0].HeaderText = "ID";
            dt1.Columns[1].HeaderText = "Tên";
            dt1.Columns[2].HeaderText = "Đơn vị";
            dt1.Columns[3].HeaderText = "Số lượng";
            dt1.Columns[4].HeaderText = "Tối thiểu";
            dt1.Columns[5].HeaderText = "Tối đa";
            conn.CloseConnection(); 
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

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien qlnv = new QuanLyNhanVien();
            this.Hide();
            qlnv.ShowDialog();
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

        private void QuanLyHangHoa_FormClosing(object sender, FormClosingEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            conn.OpenConnection();
            String cond=textBox8.Text;
            String search = "select * from nguyen_lieu where ten like'%"+cond+"%';";
            dt1.DataSource = conn.Select(search);
            conn.CloseConnection();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void QuanLyHangHoa_Load(object sender, EventArgs e)
        {
            fullname.Text = DangNhap.ten;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
