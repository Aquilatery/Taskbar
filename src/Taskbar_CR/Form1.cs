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
            Dictionary<int, Enums.LocationType> Screen = Simple.MultiDetectDictionary;

            foreach (KeyValuePair<int, Enums.LocationType> Var in Screen)
            {
                MessageBox.Show(Var.Key + ": " + Var.Value);
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            List<Enums.LocationType> Screen = Simple.MultiDetectList;

            foreach (Enums.LocationType Var in Screen)
            {
                MessageBox.Show(Var.ToString());
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Advanced.AlwaysOnTop.ToString());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Advanced.AutoHide.ToString());
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Advanced.Position.ToString());
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Advanced.Hide();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Advanced.Show();
        }
    }
}