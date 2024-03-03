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
    public partial class QuanLyTaiKhoan : Form
    {
        Conn conn = DangNhap.instance.conn;
        public QuanLyTaiKhoan()
        {
            InitializeComponent();
            conn.initilize();
            conn.OpenConnection();
            String select = "select * from users";
            dt1.DataSource = conn.Select(select);
            conn.CloseConnection();
            dt1.Columns[0].HeaderText = "Tài khoản";
            dt1.Columns[1].Visible = false;
            dt1.Columns[2].HeaderText = "Họ & tên";
            dt1.Columns[3].Visible=false;
            dt1.Columns[4].HeaderText = "Ngày sinh";
            dt1.Columns[5].HeaderText = "Địa chỉ";
            dt1.Columns[6].HeaderText = "Điện thoại";

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

        private void btnQLTK_Click_1(object sender, EventArgs e)
        {
            QuanLyNhap qln = new QuanLyNhap();
            this.Hide();
            qln.ShowDialog();
        }

        private void QuanLyTaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
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

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            name.Text = DangNhap.instance.ten;
        }

        private void dt1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dt1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dt1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dt1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dt1.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker1.Value = (DateTime)dt1.CurrentRow.Cells[4].Value;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO users (id, username, fullname, birth, location, phone) VALUES (" + (conn.Count("select count(*) from users") + 1) + ", '" + textBox1.Text + "', '" + textBox2.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
            conn.Insert(sql);
            DataTable dt = conn.Select("select * from users");
            dt1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dt1.SelectedRows.Count > 0)
            {
                String sql = "DELETE FROM users WHERE id =" + dt1.CurrentRow.Cells[3].Value.ToString() + "";
                conn.Insert(sql);
                DataTable dt = conn.Select("select * from users");
                dt1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dt1.SelectedRows.Count > 0)
            {
                String sql = "UPDATE users SET username = '" + textBox1.Text + "', fullname = '" + textBox2.Text + "', phone = '" + textBox4.Text + "', location = '" + textBox3.Text + "', birth = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' WHERE id =" + dt1.CurrentRow.Cells[3].Value.ToString() + "";
                conn.Update(sql);
                DataTable dt = conn.Select("select * from users");
                dt1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
