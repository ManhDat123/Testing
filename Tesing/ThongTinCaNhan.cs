using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tesing
{
    public partial class ThongTinCaNhan : Form
    {
        Conn conn = DangNhap.instance.conn;
        String id = DangNhap.instance.id;
        public ThongTinCaNhan()
        {
            InitializeComponent();
            DataTable tb = conn.Select("SELECT * FROM users WHERE id = " + id + "");

            textBox1.Text = tb.Rows[0][0].ToString();
            textBox2.Text = tb.Rows[0][1].ToString();
            textBox3.Text = tb.Rows[0][2].ToString();
            dateTimePicker1.Text = tb.Rows[0][4].ToString();
            textBox4.Text = tb.Rows[0][5].ToString();
            textBox5.Text = tb.Rows[0][6].ToString();

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            TrangChu tc = new TrangChu();
            this.Hide();
            tc.ShowDialog();
        }


        private void ThongTinCaNhan_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            conn.CloseConnection();
            conn.Update("UPDATE users SET username = '" + textBox1.Text + "', password = '" + textBox2.Text + "', fullname = '" + textBox3.Text + "', birth = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', location = '" + textBox4.Text + "', phone = '" + textBox5.Text + "'WHERE id = " + id + "");
            MessageBox.Show("Đổi thông tin thành công");

            TrangChu tc = new TrangChu();
            this.Hide();
            tc.ShowDialog();
        }
    }
}
