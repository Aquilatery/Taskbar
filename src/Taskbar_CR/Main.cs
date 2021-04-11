using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Taskbar.Enum;
using static Taskbar.Taskbar;

namespace Taskbar_CR
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Simple.SingleDetect.ToString());
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            List<Enums.LocationType> Screen = Simple.MultiDetectList;

            foreach (Enums.LocationType Var in Screen)
            {
                MessageBox.Show(Var.ToString());
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Dictionary<int, Enums.LocationType> Screen = Simple.MultiDetectDictionary;

            foreach (KeyValuePair<int, Enums.LocationType> Var in Screen)
            {
                MessageBox.Show("Screen " + Var.Key + " => " + Var.Value);
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

        private void Button9_Click(object sender, EventArgs e)
        {
            List<Rectangle> Rectangle = Advanced.FindDockedTaskbarsList;

            foreach (Rectangle Var in Rectangle)
            {
                MessageBox.Show("X: " + Var.X + "\nY: " + Var.Y + "\nWidth: " + Var.Width + "\nHeight: " + Var.Height);
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            Dictionary<int, Rectangle> Rectangle = Advanced.FindDockedTaskbarsDictionary;

            foreach (KeyValuePair<int, Rectangle> Var in Rectangle)
            {
                MessageBox.Show("Screen " + Var.Key + " =>\n" + "\tX: " + Var.Value.X + "\n\tY: " + Var.Value.Y + "\n\tWidth: " + Var.Value.Width + "\n\tHeight: " + Var.Value.Height);
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Advanced.Data.Rect.Left + "\n" + Advanced.Data.Rect.Top + "\n" + Advanced.Data.Rect.Right + "\n" + Advanced.Data.Rect.Bot);
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Advanced.RefreshData();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Advanced.RefreshAll();
        }
    }
}