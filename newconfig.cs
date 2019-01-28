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
            String nc_filename = "";
            Form1.DATATABLE newconf = new Form1.DATATABLE();
            newconf.test[0] = 0;
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
            Byte[] tmparr = new Byte[8];
            if (tb7_sernum.Text == "")
            {
                tb7_sernum.Text = "00000000";
            }
            Array.Copy(Encoding.Default.GetBytes(tb7_sernum.Text), newconf.ser_num, 8);
            Array.Copy(Encoding.Default.GetBytes(tb7_comment.Text), newconf.rezerv, 116);

            using (FileStream fs = new FileStream(nc_filename, FileMode.Create, FileAccess.Write))
            {
                Byte[] tmp = new Byte[128];
                tmp = GetBytes<Form1.DATATABLE>(newconf);
                fs.Write(tmp, 0, 128);
            }

        }
    }
}
