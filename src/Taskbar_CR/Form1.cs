using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Taskbar.Enum;
using static Taskbar.Taskbar;

namespace Taskbar_CR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Simple.SingleDetect.ToString());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Dictionary<int, Enums.LocationType> Screen = Simple.MultiDetect;

            foreach (KeyValuePair<int, Enums.LocationType> Var in Screen)
            {
                MessageBox.Show(Var.Key + ": " + Var.Value);
            }
        }
    }
}