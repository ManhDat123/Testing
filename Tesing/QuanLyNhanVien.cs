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
        Conn conn = DangNhap.instance.conn;
        public QuanLyNhanVien()
        {
            InitializeComponent();
            
            conn.initilize();
            conn.OpenConnection();
            String select = "select * from nhan_vien";
            DataTable dt = conn.Select(select);
            dt1.DataSource = dt;
            dt1.Columns[0].HeaderText = "ID";
            dt1.Columns[1].HeaderText = "Tên";
            dt1.Columns[2].HeaderText = "Giới tính";
            dt1.Columns[3].HeaderText = "Ngày sinh";
            dt1.Columns[4].HeaderText = "Địa chỉ";
            dt1.Columns[5].HeaderText = "SĐT";
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
            fullname.Text = DangNhap.instance.ten;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dt1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dt1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dt1.CurrentRow.Cells[5].Value.ToString();
            dateTimePicker1.Value = (DateTime)dt1.CurrentRow.Cells[3].Value;
            comboBox1.SelectedIndex = comboBox1.FindStringExact(dt1.CurrentRow.Cells[2].Value.ToString());
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            conn.OpenConnection();
            String cond = textBox7.Text;
            String search = "select * from nhan_vien where name like'%" + cond + "%';";
            dt1.DataSource = conn.Select(search);
            conn.CloseConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO nhan_vien (id, name, sex, birth, address, phone, note) VALUES (" + (conn.Count("select count(*) from nhan_vien") + 1) + ", '" +  textBox1.Text + "', '" + comboBox1.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + textBox2.Text + "', " + textBox4.Text + "')";
            conn.Insert(sql);
            DataTable dt = conn.Select("select * from nhan_vien");
            dt1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dt1.SelectedRows.Count > 0)
            {
                String sql = "DELETE FROM nhan_vien WHERE id =" + dt1.CurrentRow.Cells[0].Value.ToString() + "";
                conn.Insert(sql);
                DataTable dt = conn.Select("select * from nhan_vien");
                dt1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dt1.SelectedRows.Count > 0)
            {
                String sql = "UPDATE nhan_vien SET name = '" + textBox1.Text + "', sex = '" + comboBox1.Text + "', birth = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', address = '" + textBox2.Text + "', phone = " + textBox4.Text + " WHERE id = " + dt1.CurrentRow.Cells[0].Value.ToString();
                conn.Update(sql);
                DataTable dt = conn.Select("select * from nhan_vien");
                dt1.DataSource = dt;
            }
        }
    }
}
