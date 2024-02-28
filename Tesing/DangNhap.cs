using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tesing
{
    public partial class DangNhap : Form
    {
        public static String ten;

        private MySqlConnection connection;
        private string connectionString = $"server=localhost;port=3307;database=ql_khohang;user=sa;password=1234";
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            connection = new MySqlConnection(connectionString);
           

            String username = user.Text;
            String password = pass.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ tài khoản và mật khẩu");
            }

            connection.Open();
            String login = "SELECT * FROM users WHERE username =@username AND password =@password;";
            MySqlCommand cmd = new MySqlCommand(login,connection);
            
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            MySqlDataReader rd = cmd.ExecuteReader();
            try
            {
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        ten = rd.GetString(2);
                    }
                    TrangChu tc = new TrangChu();
                    this.Hide();
                    tc.ShowDialog();
                }
                else { MessageBox.Show("Tài khoản hoặc mật khẩu không đúng"); }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            connection.Close();
    
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
