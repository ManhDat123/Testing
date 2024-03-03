using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Tesing
{
    public partial class QuanLyHangHoa : Form
    {
        Conn conn = DangNhap.instance.conn;
        public QuanLyHangHoa()
        {
            InitializeComponent();

            String select = "select * from nguyen_lieu";


            conn.initilize();
            conn.OpenConnection();

            DataTable dt = conn.Select(select);
            dt1.DataSource = dt;
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
            fullname.Text = DangNhap.instance.ten;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dt1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dt1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dt1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dt1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dt1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dt1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dt1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO nguyen_lieu (id, ten, don_vi, so_luong, min_du_tru, max_du_tru) VALUES (" + (conn.Count("select count(*) from nguyen_lieu") + 1) + ", '" + textBox2.Text + "', '" + textBox3.Text + "', " + textBox4.Text + ", " + textBox6.Text + ", " + textBox7.Text + ")";
            conn.Insert(sql);
            DataTable dt = conn.Select("select * from nguyen_lieu");
            dt1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dt1.SelectedRows.Count > 0)
            {
                String sql = "DELETE FROM nguyen_lieu WHERE id =" + dt1.CurrentRow.Cells[0].Value.ToString() + "";
                conn.Insert(sql);
                DataTable dt = conn.Select("select * from nguyen_lieu");
                dt1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dt1.SelectedRows.Count > 0)
            {
                String sql = "UPDATE nguyen_lieu SET ten = '" + textBox2.Text + "', don_vi = '" + textBox3.Text + "', so_luong = " + textBox4.Text + ", min_du_tru = " + textBox6.Text + ", max_du_tru = " + textBox7.Text + " WHERE id =" + dt1.CurrentRow.Cells[0].Value.ToString() + "";
                conn.Update(sql);
                DataTable dt = conn.Select("select * from nguyen_lieu");
                dt1.DataSource = dt;
            }
        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    
}
