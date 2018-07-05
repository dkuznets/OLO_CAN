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
        public UploadFile()
        {
            InitializeComponent();
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
                Byte[] rdfile = new Byte[fi.Length];
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
                UInt32 _crc = BitConverter.ToUInt32(crc, 0);

                // 

            }
        }
    }
}
