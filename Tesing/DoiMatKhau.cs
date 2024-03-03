using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tesing
{
    public partial class DoiMatKhau : Form
    {
        Conn conn = DangNhap.instance.conn;
        String id = DangNhap.instance.id;
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnQLTC_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu tc = new TrangChu();
            tc.ShowDialog();
        }

        private void DoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnLuu_Click(object sender, EventArgs e)
        {


            if (!textBox1.Text.Equals(conn.Select("SELECT password FROM users WHERE id = " + id + "").Rows[0][0].ToString()))
            {
                if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("Xác Nhận không chính xác");
                }
                else
                {
                    String sql = "UPDATE users SET password = '" + textBox2.Text + " 'WHERE id = " + id + "";
                    conn.CloseConnection();
                    conn.Update(sql);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng");
                
            }
        }
    }
}
