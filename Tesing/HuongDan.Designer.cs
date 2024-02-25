namespace Tesing
{
    partial class HuongDan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HuongDan));
            panel1 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            btnQuayLai = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnQuayLai);
            panel1.Location = new System.Drawing.Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(808, 479);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(45, 24);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(718, 366);
            label2.TabIndex = 1;
            label2.Text = resources.GetString("label2.Text");
            // 
            // btnQuayLai
            // 
            btnQuayLai.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnQuayLai.Location = new System.Drawing.Point(630, 411);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new System.Drawing.Size(133, 43);
            btnQuayLai.TabIndex = 12;
            btnQuayLai.Text = "Quay lại";
            btnQuayLai.UseVisualStyleBackColor = false;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // HuongDan
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
            ClientSize = new System.Drawing.Size(832, 503);
            Controls.Add(panel1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "HuongDan";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Hướng dẫn";
            FormClosing += HuongDan_FormClosing;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Label label2;
    }
}