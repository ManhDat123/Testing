namespace Tesing
{
    partial class LichSuXuatNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LichSuXuatNhap));
            button5 = new System.Windows.Forms.Button();
            textBox10 = new System.Windows.Forms.TextBox();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button5
            // 
            button5.Image = (System.Drawing.Image)resources.GetObject("button5.Image");
            button5.Location = new System.Drawing.Point(674, 71);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(32, 27);
            button5.TabIndex = 25;
            button5.UseVisualStyleBackColor = true;
            // 
            // textBox10
            // 
            textBox10.Location = new System.Drawing.Point(418, 71);
            textBox10.Name = "textBox10";
            textBox10.Size = new System.Drawing.Size(250, 27);
            textBox10.TabIndex = 24;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridView1.Location = new System.Drawing.Point(76, 104);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new System.Drawing.Size(629, 191);
            dataGridView1.TabIndex = 23;
            // 
            // Column1
            // 
            Column1.HeaderText = "Cột 1";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Cột 2";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.HeaderText = "Cột 3";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.HeaderText = "Cột 4";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // button6
            // 
            button6.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button6.Location = new System.Drawing.Point(563, 333);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(142, 49);
            button6.TabIndex = 22;
            button6.Text = "Quay lại";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // LichSuXuatNhap
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
            ClientSize = new System.Drawing.Size(782, 453);
            Controls.Add(button5);
            Controls.Add(textBox10);
            Controls.Add(dataGridView1);
            Controls.Add(button6);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "LichSuXuatNhap";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Lịch sử xuất nhập";
            FormClosing += LichSuXuatNhap_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button button6;
    }
}