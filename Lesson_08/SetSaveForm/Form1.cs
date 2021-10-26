using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetSaveForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.option1 = checkBox1.Checked;
            Properties.Settings.Default.option2 = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            checkBox1.Checked = Properties.Settings.Default.option1;
            checkBox2.Checked = Properties.Settings.Default.option2;
        }
    }
}
