using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewDDBLog
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                showLog(ofd.FileName);
            }
        }

        private void showLog(string fileName)
        {
            string msg = "";
            string line;
            int i = 1;
            using (StreamReader reader = new StreamReader(fileName, Encoding.GetEncoding("utf-8")))
            {
                while((line = reader.ReadLine()) != null)
                {
                    msg += "<fieldset style=\"padding:10px;\"><legend style=\"padding:5px;\">" + 
                        "错误：<font color=\"red\">" + i.ToString() + "</font></legend>" + 
                        Base.Fun.fun.NoSql(Base.Fun.Encrypt.Decrypt3DES(line)) + "</fieldset>";
                    i++;
                }
            }
            webBrowser1.DocumentText = msg;
        }
    }
}
