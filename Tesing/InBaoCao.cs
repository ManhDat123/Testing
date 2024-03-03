using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tesing
{
    public partial class InBaoCao : Form
    {
        Conn conn = DangNhap.instance.conn;
        Bitmap bitmap;
        public InBaoCao()
        {
            InitializeComponent();
            DisplayCurrentDateTime();
        }
        private void DisplayCurrentDateTime()
        {
            DateTime now = DateTime.Now;
        }

        private void InBaoCao_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            BaoCaoThongKe bctk = new BaoCaoThongKe();
            this.Hide();
            bctk.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics graphics = panel.CreateGraphics();

            Size size = this.ClientSize;

            size.Height -= 80;


            bitmap = new Bitmap(size.Width, size.Height, graphics);

            graphics = Graphics.FromImage(bitmap);

            Point point = PointToScreen(panel.Location);

            graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void InBaoCao_Load(object sender, EventArgs e)
        {
            int i = 0;
            foreach(String ten in conn.Get_id())
            {
                comboBox1.Items.Add(ten);

            }
            /*for(int i=0;i<conn.Get_id().Length;i++)
            {
                try{ comboBox1.Items.Add(conn.Get_id()[i]); }
                    catch(Exception) { }
            }*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String ind = comboBox1.Text.ToString();

            
            stt.Text = conn.GetInfo(ind)[0];
            label3.Text = conn.GetInfo(ind)[2];
            label14.Text = conn.GetInfo(ind)[3];
            label15.Text = conn.GetInfo(ind)[4];
            label16.Text = conn.GetInfo(ind)[5];
            label17.Text = conn.GetInfo(ind)[6];
            int dongia=int.Parse(label17.Text);
            int soluong=int.Parse(label16.Text);
            label19.Text= (dongia*soluong).ToString();
        }
    }
}
