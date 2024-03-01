using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tesing
{
    public partial class DangNhap : Form
    {
        public String ten;
        public static DangNhap instance;
        public Conn conn = new Conn("localhost", "3307", "ql_khohang", "root", "");
        public DangNhap()
        {

            InitializeComponent();
            conn.initilize();
            instance = this;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            String username = user.Text;
            String password = pass.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ tài khoản và mật khẩu");
            }
            else
            {
                if (conn.IsValid(username, password))
                {
                    ten = conn.GetName(username, password);
                    TrangChu tc = new TrangChu();
                    this.Hide();
                    tc.ShowDialog();
                }
            }
    
        }



        private void llbQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau qmk = new QuenMatKhau();
            this.Hide();
            qmk.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dk = new DangKy();
            this.Hide();
            dk.ShowDialog();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
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

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
