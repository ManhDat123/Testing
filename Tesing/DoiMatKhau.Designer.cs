namespace Tesing
{
    partial class DoiMatKhau
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
            panel1 = new System.Windows.Forms.Panel();
            btnQLTC = new System.Windows.Forms.Button();
            textBox3 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            btnLuu = new System.Windows.Forms.Button();
            textBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnQLTC);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnLuu);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new System.Drawing.Point(47, 50);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(589, 303);
            panel1.TabIndex = 0;
            // 
            // btnQLTC
            // 
            btnQLTC.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            btnQLTC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnQLTC.Location = new System.Drawing.Point(433, 263);
            btnQLTC.Name = "btnQLTC";
            btnQLTC.Size = new System.Drawing.Size(153, 37);
            btnQLTC.TabIndex = 7;
            btnQLTC.Text = "Quay lại trang chủ";
            btnQLTC.UseVisualStyleBackColor = false;
            btnQLTC.Click += btnQLTC_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(158, 214);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(272, 27);
            textBox3.TabIndex = 6;
            textBox3.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(161, 181);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(174, 20);
            label3.TabIndex = 5;
            label3.Text = "Xác nhận mật khẩu mới";
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(158, 125);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(272, 27);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(161, 92);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(106, 20);
            label2.TabIndex = 3;
            label2.Text = "Mật khẩu mới";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = System.Drawing.Color.FromArgb(128, 255, 255);
            btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnLuu.Location = new System.Drawing.Point(0, 263);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new System.Drawing.Size(146, 37);
            btnLuu.TabIndex = 2;
            btnLuu.Text = "Lưu thay đổi";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(158, 45);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(272, 27);
            textBox1.TabIndex = 1;
            textBox1.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(161, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(131, 20);
            label1.TabIndex = 0;
            label1.Text = "Mật khẩu hiện tại";
            // 
            // DoiMatKhau
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
            ClientSize = new System.Drawing.Size(682, 403);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "DoiMatKhau";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Đổi mật khẩu";
            FormClosing += DoiMatKhau_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQLTC;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}