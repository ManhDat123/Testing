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
    public partial class BaoCaoTonKho : Form
    {
        Conn conn = DangNhap.instance.conn;
        public BaoCaoTonKho()
        {
            InitializeComponent();
            String select = "select * from nguyen_lieu";
            conn.CloseConnection();
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

        private void button6_Click(object sender, EventArgs e)
        {
            BaoCaoThongKe bctk = new BaoCaoThongKe();
            this.Hide();
            bctk.ShowDialog();
        }

        private void BaoCaoTonKho_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            String sql = "INSERT INTO nguyen_lieu (id, ten, don_vi, so_luong, min_du_tru, max_du_tru) VALUES (" + (conn.Count("select count(*) from nguyen_lieu") + 1) + ", '" + textBox2.Text + "', '" + textBox3.Text + "', " + textBox4.Text + ", " + textBox6.Text + ", " + textBox7.Text + ")";
            conn.Insert(sql);
            DataTable dt = conn.Select("select * from nguyen_lieu");
            dt1.DataSource = dt;
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

        private void dt1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dt1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dt1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dt1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dt1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dt1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dt1.CurrentRow.Cells[5].Value.ToString();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            conn.OpenConnection();
            String cond = textBox10.Text;
            String search = "select * from nguyen_lieu where ten like'%" + cond + "%';";
            dt1.DataSource = conn.Select(search);
            conn.CloseConnection();
        }
    }
}
