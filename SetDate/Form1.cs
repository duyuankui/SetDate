using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetDate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime t =  Convert.ToDateTime("2022-09-29 " + DateTime.Now.ToString("HH:mm:ss"));

            SYSTEMTIME st = new SYSTEMTIME();
            st.FromDateTime(t);
            bool b = Win32API.SetLocalTime(ref st);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    if (DateTime.Now.ToString("yyyy-MM-dd") != "2022-09-29")
                    {
                        DateTime t = Convert.ToDateTime("2022-09-29 " + DateTime.Now.ToString("HH:mm:ss"));
                        SYSTEMTIME st = new SYSTEMTIME();
                        st.FromDateTime(t);
                        Win32API.SetLocalTime(ref st);
                    }
                    Thread.Sleep(100);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
