using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OLO_CAN
{
    public partial class UploadFile : Form
    {
        public Byte[] rdfile;
        public UInt32 _crc;
        public UInt32 _len;
        public UInt32 _addr;
        bool _cancel = false;
        public UploadFile()
        {
            InitializeComponent();
        }
        public UInt32 lbaddr
        {
            get { return Convert.ToUInt32(mtb_begin.Text.Replace("0x", "").Trim(), 16); }
            set { mtb_begin.Text = value.ToString("X"); }
        }
        private void UploadFile_Load(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // открываем файл и считаем crc32

                ofd.Filter = "Файлы (*.bin)|*.bin";
                ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;
                FileInfo fi = new FileInfo(ofd.FileName);
                rdfile = new Byte[fi.Length];
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                fs.Read(rdfile, 0, (int)fi.Length);
                Crc32 crc32 = new Crc32();
                String hash = String.Empty;
                foreach (byte b in crc32.ComputeHash(rdfile))
                {
                    hash += b.ToString("x2").ToLower();
                }
                Byte[] crc = new Byte[4];
                crc = crc32.ComputeHash(rdfile);
                Array.Reverse(crc);
                tb_fname.Text = fi.FullName;
                mtb_size.Text = fi.Length.ToString("X");
                mtb_crc32.Text = hash;
                _crc = BitConverter.ToUInt32(crc, 0);
                _len = (UInt32)fi.Length;
//                _addr =

                // 

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = mtb_begin.Text;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(mtb_begin.Text != "0x")
                textBox1.Text = Convert.ToUInt32(mtb_begin.Text.Replace("0x","").Trim(),16).ToString();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            _cancel = true;
        }

        private void UploadFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cancel)
                e.Cancel = false;
            else
                if (!valid())
                    e.Cancel = true;
        }

        private bool valid()
        {
            if (mtb_begin.Text == "0x")
            {
                mtb_begin.BackColor = Color.Red;
                return false;
            }
            _addr = Convert.ToUInt32(mtb_begin.Text.Replace("0x", "").Trim(), 16);
            if(_addr < 16535)
                return false;
            return true;
        }
    }
}
