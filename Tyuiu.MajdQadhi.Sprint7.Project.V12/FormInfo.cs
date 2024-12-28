using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyuiu.MajdQadhi.Sprint7.Project.V12
{
    public partial class FormInfo : Form
    {
        public FormInfo()
        {
            InitializeComponent();
        }

        private void buttonDone_KKA_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxDeveloper_KKA_Click(object sender, EventArgs e)
        {
            Process.Start("https://vk.com/majdqadi");
        }

        private void labelInfo_KKA_Click(object sender, EventArgs e)
        {

        }
    }
}
