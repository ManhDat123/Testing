using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tesing
{
    public partial class LichSuXuatNhap : Form
    {
        Conn conn = DangNhap.instance.conn;
        public LichSuXuatNhap()
        {
            InitializeComponent();
            conn.initilize();
            conn.OpenConnection();
            String select = "select * from ql_nhap";

            DataTable dt = conn.Select(select);
            dt.Merge(conn.Select("SELECT * FROM ql_xuat"));
            dt1.DataSource = dt;
            conn.CloseConnection();
            dt1.Columns[0].HeaderText = "ID";
            dt1.Columns[1].HeaderText = "Tên nhân viên";
            dt1.Columns[2].HeaderText = "Tên đại lý";
            dt1.Columns[3].HeaderText = "Mặt hàng";
            dt1.Columns[4].HeaderText = "Đơn vị";
            dt1.Columns[5].HeaderText = "Số lượng";
            dt1.Columns[6].HeaderText = "Đơn giá";
            dt1.Columns[7].HeaderText = "Ngày";
        }

        private void LichSuXuatNhap_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            BaoCaoThongKe bctk = new BaoCaoThongKe();
            this.Hide();
            bctk.ShowDialog();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            

            conn.OpenConnection();
            String select = "select * from ql_nhap WHERE id like '%" + textBox10.Text + "%'";

            DataTable dt = conn.Select(select);
            dt.Merge(conn.Select("SELECT * FROM ql_xuat WHERE id like '%" + textBox10.Text + "%'"));
            dt1.DataSource = dt;
            conn.CloseConnection();
        }
    }
}
