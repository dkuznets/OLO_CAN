namespace OLO_CAN
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
            this.tb_crc32 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mtb_size = new System.Windows.Forms.MaskedTextBox();
            this.mtb_begin = new System.Windows.Forms.MaskedTextBox();
            this.mtb_crc32 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // tb_fname
            // 
            this.tb_fname.Location = new System.Drawing.Point(12, 12);
            this.tb_fname.Name = "tb_fname";
            this.tb_fname.Size = new System.Drawing.Size(540, 20);
            this.tb_fname.TabIndex = 0;
            // 
            // tb_crc32
            // 
            this.tb_crc32.Location = new System.Drawing.Point(172, 64);
            this.tb_crc32.Name = "tb_crc32";
            this.tb_crc32.ReadOnly = true;
            this.tb_crc32.Size = new System.Drawing.Size(100, 20);
            this.tb_crc32.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(477, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // mtb_size
            // 
            this.mtb_size.AsciiOnly = true;
            this.mtb_size.Location = new System.Drawing.Point(92, 38);
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
            this.mtb_begin.Location = new System.Drawing.Point(12, 38);
            this.mtb_begin.Mask = "\\0x>aaaaaaaa";
            this.mtb_begin.Name = "mtb_begin";
            this.mtb_begin.PromptChar = ' ';
            this.mtb_begin.Size = new System.Drawing.Size(74, 20);
            this.mtb_begin.TabIndex = 6;
            // 
            // mtb_crc32
            // 
            this.mtb_crc32.Location = new System.Drawing.Point(172, 38);
            this.mtb_crc32.Mask = ">AAAAAAAA";
            this.mtb_crc32.Name = "mtb_crc32";
            this.mtb_crc32.ReadOnly = true;
            this.mtb_crc32.Size = new System.Drawing.Size(100, 20);
            this.mtb_crc32.TabIndex = 7;
            // 
            // UploadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 262);
            this.Controls.Add(this.mtb_crc32);
            this.Controls.Add(this.mtb_begin);
            this.Controls.Add(this.mtb_size);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_crc32);
            this.Controls.Add(this.tb_fname);
            this.Name = "UploadFile";
            this.Text = "UploadFile";
            this.Load += new System.EventHandler(this.UploadFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_fname;
        private System.Windows.Forms.TextBox tb_crc32;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox mtb_size;
        private System.Windows.Forms.MaskedTextBox mtb_begin;
        private System.Windows.Forms.MaskedTextBox mtb_crc32;
    }
}