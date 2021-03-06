﻿using System;
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
        public Byte[] _rdfile;
        public UInt32 _crc;
        public UInt32 _len;
        public UInt32 _addr;
        public UInt32 _ver;
        public String _fname;
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
                {
//                    this.Close();
                    bt_cancel.PerformClick();
                    return;
                }
                FileInfo fi = new FileInfo(ofd.FileName);
                _rdfile = new Byte[fi.Length];
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                fs.Read(_rdfile, 0, (int)fi.Length);
                Crc32 crc32 = new Crc32();
                String hash = String.Empty;
                foreach (byte b in crc32.ComputeHash(_rdfile))
                {
                    hash += b.ToString("x2").ToLower();
                }
                Byte[] crc = new Byte[4];
                crc = crc32.ComputeHash(_rdfile);
                Array.Reverse(crc);
                tb_fname.Text = fi.FullName;
                mtb_size.Text = fi.Length.ToString("X");
                mtb_crc32.Text = hash;
                _crc = BitConverter.ToUInt32(crc, 0);
                _len = (UInt32)fi.Length;
                tb_date.Text = DateTime.Now.ToString();
                _fname = fi.Name;
            }
        }
        private void bt_save_Click(object sender, EventArgs e)
        {
            if (mtb_version.Text == " . . .")
                mtb_version.Text = "1000";
            if (!mtb_version.MaskCompleted)
            {
                MessageBox.Show("1111");
                mtb_version.BackColor = Color.Red;
                _cancel = false;
                return;
            }

            String[] vv = mtb_version.Text.Split(new char[] { '.' });
            Byte[] bb = new Byte[4];
            for (int i = 0; i < 4; i++)
            {
                bb[i] = Convert.ToByte(vv[i]);
            }
            _ver = BitConverter.ToUInt32(bb, 0);
            if (!valid())
            {
                _cancel = false;
                return;
            }
            _cancel = true;
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
//            if (_addr < 16384 || _addr >= 0x3C000)
            if (_addr < 16384 || _addr >= 0x3E000)
            {
                mtb_begin.BackColor = Color.Red;
                return false;
            }
            return true;
        }

        private void mtb_begin_TextChanged(object sender, EventArgs e)
        {
            mtb_begin.BackColor = SystemColors.Control;
        }

        private void mtb_version_TextChanged(object sender, EventArgs e)
        {
            mtb_version.BackColor = SystemColors.Control;
        }

        private void mtb_version_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mtb_version.BackColor = Color.Red;
        }

        private void mtb_begin_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            mtb_begin.BackColor = Color.Red;
        }
    }
}
