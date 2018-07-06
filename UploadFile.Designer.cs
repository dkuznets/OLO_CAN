﻿namespace OLO_CAN
{
    partial class UploadFile
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
            this.tb_fname = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mtb_size = new System.Windows.Forms.MaskedTextBox();
            this.mtb_begin = new System.Windows.Forms.MaskedTextBox();
            this.mtb_crc32 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtb_version = new System.Windows.Forms.MaskedTextBox();
            this.tb_date = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_fname
            // 
            this.tb_fname.Location = new System.Drawing.Point(12, 12);
            this.tb_fname.Name = "tb_fname";
            this.tb_fname.Size = new System.Drawing.Size(260, 20);
            this.tb_fname.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(395, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Записать";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // mtb_size
            // 
            this.mtb_size.AsciiOnly = true;
            this.mtb_size.Location = new System.Drawing.Point(92, 61);
            this.mtb_size.Mask = "\\0x>aaaaaaaa";
            this.mtb_size.Name = "mtb_size";
            this.mtb_size.PromptChar = ' ';
            this.mtb_size.ReadOnly = true;
            this.mtb_size.Size = new System.Drawing.Size(74, 20);
            this.mtb_size.TabIndex = 5;
            // 
            // mtb_begin
            // 
            this.mtb_begin.AsciiOnly = true;
            this.mtb_begin.Location = new System.Drawing.Point(12, 61);
            this.mtb_begin.Mask = "\\0x>aaaaaaaa";
            this.mtb_begin.Name = "mtb_begin";
            this.mtb_begin.PromptChar = ' ';
            this.mtb_begin.Size = new System.Drawing.Size(74, 20);
            this.mtb_begin.TabIndex = 6;
            // 
            // mtb_crc32
            // 
            this.mtb_crc32.Location = new System.Drawing.Point(172, 61);
            this.mtb_crc32.Mask = ">AAAAAAAA";
            this.mtb_crc32.Name = "mtb_crc32";
            this.mtb_crc32.ReadOnly = true;
            this.mtb_crc32.Size = new System.Drawing.Size(100, 20);
            this.mtb_crc32.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Адрес";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Размер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "CRC32";
            // 
            // mtb_version
            // 
            this.mtb_version.Location = new System.Drawing.Point(278, 61);
            this.mtb_version.Mask = "0\\.0\\.0\\.0";
            this.mtb_version.Name = "mtb_version";
            this.mtb_version.Size = new System.Drawing.Size(56, 20);
            this.mtb_version.TabIndex = 11;
            // 
            // tb_date
            // 
            this.tb_date.Location = new System.Drawing.Point(340, 61);
            this.tb_date.Name = "tb_date";
            this.tb_date.Size = new System.Drawing.Size(100, 20);
            this.tb_date.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Версия";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Дата";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(477, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Отменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(321, 146);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(223, 146);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // UploadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 262);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_date);
            this.Controls.Add(this.mtb_version);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtb_crc32);
            this.Controls.Add(this.mtb_begin);
            this.Controls.Add(this.mtb_size);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_fname);
            this.Name = "UploadFile";
            this.Text = "UploadFile";
            this.Load += new System.EventHandler(this.UploadFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_fname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox mtb_size;
        private System.Windows.Forms.MaskedTextBox mtb_begin;
        private System.Windows.Forms.MaskedTextBox mtb_crc32;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtb_version;
        private System.Windows.Forms.TextBox tb_date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
    }
}