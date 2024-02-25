using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tesing
{
    public partial class BaoCaoTonKho : Form
    {
        public BaoCaoTonKho()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BaoCaoThongKe bctk = new BaoCaoThongKe();
            this.Hide();
            bctk.ShowDialog();
        }
    }
}
