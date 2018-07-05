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
            this.tb_begin = new System.Windows.Forms.TextBox();
            this.tb_size = new System.Windows.Forms.TextBox();
            this.tb_crc32 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_fname
            // 
            this.tb_fname.Location = new System.Drawing.Point(12, 12);
            this.tb_fname.Name = "tb_fname";
            this.tb_fname.Size = new System.Drawing.Size(540, 20);
            this.tb_fname.TabIndex = 0;
            // 
            // tb_begin
            // 
            this.tb_begin.Location = new System.Drawing.Point(13, 39);
            this.tb_begin.Name = "tb_begin";
            this.tb_begin.Size = new System.Drawing.Size(100, 20);
            this.tb_begin.TabIndex = 1;
            // 
            // tb_size
            // 
            this.tb_size.Location = new System.Drawing.Point(119, 38);
            this.tb_size.Name = "tb_size";
            this.tb_size.Size = new System.Drawing.Size(100, 20);
            this.tb_size.TabIndex = 2;
            // 
            // tb_crc32
            // 
            this.tb_crc32.Location = new System.Drawing.Point(225, 38);
            this.tb_crc32.Name = "tb_crc32";
            this.tb_crc32.Size = new System.Drawing.Size(100, 20);
            this.tb_crc32.TabIndex = 3;
            // 
            // UploadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 262);
            this.Controls.Add(this.tb_crc32);
            this.Controls.Add(this.tb_size);
            this.Controls.Add(this.tb_begin);
            this.Controls.Add(this.tb_fname);
            this.Name = "UploadFile";
            this.Text = "UploadFile";
            this.Load += new System.EventHandler(this.UploadFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_fname;
        private System.Windows.Forms.TextBox tb_begin;
        private System.Windows.Forms.TextBox tb_size;
        private System.Windows.Forms.TextBox tb_crc32;
    }
}