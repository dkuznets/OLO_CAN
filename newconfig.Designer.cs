namespace OLO_CAN
{
    partial class newconfig
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
            this.rb7_olo_right = new System.Windows.Forms.RadioButton();
            this.rb7_olo_left = new System.Windows.Forms.RadioButton();
            this.tb7_sernum = new System.Windows.Forms.TextBox();
            this.tb7_comment = new System.Windows.Forms.TextBox();
            this.lb7_sernum = new System.Windows.Forms.Label();
            this.lb7_comment = new System.Windows.Forms.Label();
            this.bt7_saveconf = new System.Windows.Forms.Button();
            this.bt7_cancelconf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rb7_olo_right
            // 
            this.rb7_olo_right.AutoSize = true;
            this.rb7_olo_right.Checked = true;
            this.rb7_olo_right.Location = new System.Drawing.Point(13, 13);
            this.rb7_olo_right.Name = "rb7_olo_right";
            this.rb7_olo_right.Size = new System.Drawing.Size(90, 17);
            this.rb7_olo_right.TabIndex = 0;
            this.rb7_olo_right.TabStop = true;
            this.rb7_olo_right.Text = "ОЛО правый";
            this.rb7_olo_right.UseVisualStyleBackColor = true;
            // 
            // rb7_olo_left
            // 
            this.rb7_olo_left.AutoSize = true;
            this.rb7_olo_left.Location = new System.Drawing.Point(13, 37);
            this.rb7_olo_left.Name = "rb7_olo_left";
            this.rb7_olo_left.Size = new System.Drawing.Size(84, 17);
            this.rb7_olo_left.TabIndex = 1;
            this.rb7_olo_left.Text = "ОЛО левый";
            this.rb7_olo_left.UseVisualStyleBackColor = true;
            // 
            // tb7_sernum
            // 
            this.tb7_sernum.Location = new System.Drawing.Point(116, 36);
            this.tb7_sernum.MaxLength = 8;
            this.tb7_sernum.Name = "tb7_sernum";
            this.tb7_sernum.Size = new System.Drawing.Size(94, 20);
            this.tb7_sernum.TabIndex = 2;
            // 
            // tb7_comment
            // 
            this.tb7_comment.Location = new System.Drawing.Point(12, 89);
            this.tb7_comment.MaxLength = 116;
            this.tb7_comment.Multiline = true;
            this.tb7_comment.Name = "tb7_comment";
            this.tb7_comment.Size = new System.Drawing.Size(245, 49);
            this.tb7_comment.TabIndex = 3;
            // 
            // lb7_sernum
            // 
            this.lb7_sernum.AutoSize = true;
            this.lb7_sernum.Location = new System.Drawing.Point(117, 15);
            this.lb7_sernum.Name = "lb7_sernum";
            this.lb7_sernum.Size = new System.Drawing.Size(93, 13);
            this.lb7_sernum.TabIndex = 4;
            this.lb7_sernum.Text = "Серийный номер";
            // 
            // lb7_comment
            // 
            this.lb7_comment.AutoSize = true;
            this.lb7_comment.Location = new System.Drawing.Point(10, 73);
            this.lb7_comment.Name = "lb7_comment";
            this.lb7_comment.Size = new System.Drawing.Size(205, 13);
            this.lb7_comment.TabIndex = 5;
            this.lb7_comment.Text = "Комментарий (не более 116 символов)";
            // 
            // bt7_saveconf
            // 
            this.bt7_saveconf.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bt7_saveconf.Location = new System.Drawing.Point(101, 144);
            this.bt7_saveconf.Name = "bt7_saveconf";
            this.bt7_saveconf.Size = new System.Drawing.Size(75, 23);
            this.bt7_saveconf.TabIndex = 6;
            this.bt7_saveconf.Text = "Записать";
            this.bt7_saveconf.UseVisualStyleBackColor = true;
            this.bt7_saveconf.Click += new System.EventHandler(this.bt7_saveconf_Click);
            // 
            // bt7_cancelconf
            // 
            this.bt7_cancelconf.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bt7_cancelconf.Location = new System.Drawing.Point(182, 144);
            this.bt7_cancelconf.Name = "bt7_cancelconf";
            this.bt7_cancelconf.Size = new System.Drawing.Size(75, 23);
            this.bt7_cancelconf.TabIndex = 7;
            this.bt7_cancelconf.Text = "Отменить";
            this.bt7_cancelconf.UseVisualStyleBackColor = true;
            // 
            // newconfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 172);
            this.Controls.Add(this.bt7_cancelconf);
            this.Controls.Add(this.bt7_saveconf);
            this.Controls.Add(this.lb7_comment);
            this.Controls.Add(this.lb7_sernum);
            this.Controls.Add(this.tb7_comment);
            this.Controls.Add(this.tb7_sernum);
            this.Controls.Add(this.rb7_olo_left);
            this.Controls.Add(this.rb7_olo_right);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newconfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создать и загрузить конфигурацию";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb7_olo_right;
        private System.Windows.Forms.RadioButton rb7_olo_left;
        private System.Windows.Forms.TextBox tb7_sernum;
        private System.Windows.Forms.TextBox tb7_comment;
        private System.Windows.Forms.Label lb7_sernum;
        private System.Windows.Forms.Label lb7_comment;
        private System.Windows.Forms.Button bt7_saveconf;
        private System.Windows.Forms.Button bt7_cancelconf;
    }
}