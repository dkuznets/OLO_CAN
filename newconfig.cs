using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace OLO_CAN
{
    public partial class newconfig : Form
    {
        public String nc_filename = "";
        public newconfig()
        {
            InitializeComponent();
        }
        static unsafe byte[] GetBytes<T>(T obj) where T : struct
        {
            var size = Marshal.SizeOf(typeof(T));
            var buffer = new byte[size];

            fixed (void* pointer = buffer)
            {
                Marshal.StructureToPtr(obj, new IntPtr(pointer), false);
                return buffer;
            }
        }

        private unsafe void bt7_saveconf_Click(object sender, EventArgs e)
        {
//            String nc_filename = "";
            Form1.DATATABLE newconf = new Form1.DATATABLE();

            newconf.test = new Byte[1];
            newconf.test[0] = 0;

            newconf.dev_id = new Byte[3];
            if (rb7_olo_right.Checked)
            {
                nc_filename = "config_right.bin";
                for (int i = 0; i < 3; i++)
    			{
                    newconf.dev_id[i] = 0x11;
	    		}
            }
            else
            {
                nc_filename = "config_left.bin";
                for (int i = 0; i < 3; i++)
                {
                    newconf.dev_id[i] = 0x12;
                }
            }
            newconf.ser_num = new Byte[8];
            newconf.rezerv = new Byte[116];
            if (tb7_sernum.Text == "")
            {
                tb7_sernum.Text = "00000000";
            }
            Array.Copy(Encoding.Default.GetBytes(tb7_sernum.Text), newconf.ser_num, 8);
            Array.Copy(Encoding.Default.GetBytes(tb7_comment.Text), newconf.rezerv, tb7_comment.Text.Length);
            try
            {
                using (FileStream fs = new FileStream(nc_filename, FileMode.Create, FileAccess.Write))
                {
                    Byte[] tmp = new Byte[128];
                    tmp = GetBytes<Form1.DATATABLE>(newconf);
                    fs.Write(tmp, 0, 128);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не могу открыть файл!");
                
                return;
            }
        }
    }
}
