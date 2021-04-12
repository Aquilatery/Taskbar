#region Imports

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static Taskbar.Enum.Enums;
using static Taskbar.Taskbar;

#endregion

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
            List<LocationType> Screen = Simple.MultiDetectList;

            foreach (LocationType Var in Screen)
            {
                MessageBox.Show(Var.ToString());
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Dictionary<int, LocationType> Screen = Simple.MultiDetectDictionary;

            foreach (KeyValuePair<int, LocationType> Var in Screen)
            {
                MessageBox.Show("Screen " + Var.Key + " => " + Var.Value);
            }
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            Location = Simple.SingleLocation(EdgeLocationType.TopLeft, Width, Height, 32);
            Thread.Sleep(750);
            Location = Simple.SingleLocation(EdgeLocationType.TopCenter, Width, Height, 32);
            Thread.Sleep(750);
            Location = Simple.SingleLocation(EdgeLocationType.TopRight, Width, Height, 32);
            Thread.Sleep(750);
            Location = Simple.SingleLocation(EdgeLocationType.BotLeft, Width, Height, 32);
            Thread.Sleep(750);
            Location = Simple.SingleLocation(EdgeLocationType.BotCenter, Width, Height, 32);
            Thread.Sleep(750);
            Location = Simple.SingleLocation(EdgeLocationType.BotRight, Width, Height, 32);
            Thread.Sleep(750);
            Location = Simple.SingleLocation(EdgeLocationType.LeftCenter, Width, Height, 32);
            Thread.Sleep(750);
            Location = Simple.SingleLocation(EdgeLocationType.RightCenter, Width, Height, 32);
            Thread.Sleep(750);
            Location = Simple.SingleLocation(EdgeLocationType.CalcCenter, Width, Height);
            Thread.Sleep(750);
            Location = Simple.SingleLocation(EdgeLocationType.FullCenter, Width, Height);
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            List<Point> Location = Simple.MultiLocationList(EdgeLocationType.TopLeft, Width, Height, 32);

            foreach (Point Var in Location)
            {
                this.Location = Var;
                MessageBox.Show("X: " + Var.X + "\nY: " + Var.Y);
            }

            Location = Simple.MultiLocationList(EdgeLocationType.TopCenter, Width, Height, 32);

            foreach (Point Var in Location)
            {
                this.Location = Var;
                MessageBox.Show("X: " + Var.X + "\nY: " + Var.Y);
            }

            Location = Simple.MultiLocationList(EdgeLocationType.TopRight, Width, Height, 32);

            foreach (Point Var in Location)
            {
                this.Location = Var;
                MessageBox.Show("X: " + Var.X + "\nY: " + Var.Y);
            }

            Location = Simple.MultiLocationList(EdgeLocationType.BotLeft, Width, Height, 32);

            foreach (Point Var in Location)
            {
                this.Location = Var;
                MessageBox.Show("X: " + Var.X + "\nY: " + Var.Y);
            }

            Location = Simple.MultiLocationList(EdgeLocationType.BotCenter, Width, Height, 32);

            foreach (Point Var in Location)
            {
                this.Location = Var;
                MessageBox.Show("X: " + Var.X + "\nY: " + Var.Y);
            }

            Location = Simple.MultiLocationList(EdgeLocationType.BotRight, Width, Height, 32);

            foreach (Point Var in Location)
            {
                this.Location = Var;
                MessageBox.Show("X: " + Var.X + "\nY: " + Var.Y);
            }

            Location = Simple.MultiLocationList(EdgeLocationType.LeftCenter, Width, Height, 32);

            foreach (Point Var in Location)
            {
                this.Location = Var;
                MessageBox.Show("X: " + Var.X + "\nY: " + Var.Y);
            }

            Location = Simple.MultiLocationList(EdgeLocationType.RightCenter, Width, Height, 32);

            foreach (Point Var in Location)
            {
                this.Location = Var;
                MessageBox.Show("X: " + Var.X + "\nY: " + Var.Y);
            }

            Location = Simple.MultiLocationList(EdgeLocationType.CalcCenter, Width, Height);

            foreach (Point Var in Location)
            {
                this.Location = Var;
                MessageBox.Show("X: " + Var.X + "\nY: " + Var.Y);
            }

            Location = Simple.MultiLocationList(EdgeLocationType.FullCenter, Width, Height);

            foreach (Point Var in Location)
            {
                this.Location = Var;
                MessageBox.Show("X: " + Var.X + "\nY: " + Var.Y);
            }
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            Dictionary<int, Point> Location = Simple.MultiLocationDictionary(EdgeLocationType.TopLeft, Width, Height, 32);

            foreach (KeyValuePair<int, Point> Var in Location)
            {
                this.Location = Var.Value;
                MessageBox.Show("Screen " + Var.Key + " =>\n" + "\tX: " + Var.Value.X + "\n\tY: " + Var.Value.Y);
            }

            Location = Simple.MultiLocationDictionary(EdgeLocationType.TopCenter, Width, Height, 32);

            foreach (KeyValuePair<int, Point> Var in Location)
            {
                this.Location = Var.Value;
                MessageBox.Show("Screen " + Var.Key + " =>\n" + "\tX: " + Var.Value.X + "\n\tY: " + Var.Value.Y);
            }

            Location = Simple.MultiLocationDictionary(EdgeLocationType.TopRight, Width, Height, 32);

            foreach (KeyValuePair<int, Point> Var in Location)
            {
                this.Location = Var.Value;
                MessageBox.Show("Screen " + Var.Key + " =>\n" + "\tX: " + Var.Value.X + "\n\tY: " + Var.Value.Y);
            }

            Location = Simple.MultiLocationDictionary(EdgeLocationType.BotLeft, Width, Height, 32);

            foreach (KeyValuePair<int, Point> Var in Location)
            {
                this.Location = Var.Value;
                MessageBox.Show("Screen " + Var.Key + " =>\n" + "\tX: " + Var.Value.X + "\n\tY: " + Var.Value.Y);
            }

            Location = Simple.MultiLocationDictionary(EdgeLocationType.BotCenter, Width, Height, 32);

            foreach (KeyValuePair<int, Point> Var in Location)
            {
                this.Location = Var.Value;
                MessageBox.Show("Screen " + Var.Key + " =>\n" + "\tX: " + Var.Value.X + "\n\tY: " + Var.Value.Y);
            }

            Location = Simple.MultiLocationDictionary(EdgeLocationType.BotRight, Width, Height, 32);

            foreach (KeyValuePair<int, Point> Var in Location)
            {
                this.Location = Var.Value;
                MessageBox.Show("Screen " + Var.Key + " =>\n" + "\tX: " + Var.Value.X + "\n\tY: " + Var.Value.Y);
            }

            Location = Simple.MultiLocationDictionary(EdgeLocationType.LeftCenter, Width, Height, 32);

            foreach (KeyValuePair<int, Point> Var in Location)
            {
                this.Location = Var.Value;
                MessageBox.Show("Screen " + Var.Key + " =>\n" + "\tX: " + Var.Value.X + "\n\tY: " + Var.Value.Y);
            }

            Location = Simple.MultiLocationDictionary(EdgeLocationType.RightCenter, Width, Height, 32);

            foreach (KeyValuePair<int, Point> Var in Location)
            {
                this.Location = Var.Value;
                MessageBox.Show("Screen " + Var.Key + " =>\n" + "\tX: " + Var.Value.X + "\n\tY: " + Var.Value.Y);
            }

            Location = Simple.MultiLocationDictionary(EdgeLocationType.CalcCenter, Width, Height);

            foreach (KeyValuePair<int, Point> Var in Location)
            {
                this.Location = Var.Value;
                MessageBox.Show("Screen " + Var.Key + " =>\n" + "\tX: " + Var.Value.X + "\n\tY: " + Var.Value.Y);
            }

            Location = Simple.MultiLocationDictionary(EdgeLocationType.FullCenter, Width, Height);

            foreach (KeyValuePair<int, Point> Var in Location)
            {
                this.Location = Var.Value;
                MessageBox.Show("Screen " + Var.Key + " =>\n" + "\tX: " + Var.Value.X + "\n\tY: " + Var.Value.Y);
            }
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Width: " + Simple.SingleSize.Width + "\nHeight: " + Simple.SingleSize.Height);
        }

        private void Button20_Click(object sender, EventArgs e)
        {
            List<Size> Size = Simple.MultiSizeList;

            foreach (Size Var in Size)
            {
                MessageBox.Show("Width: " + Var.Width + "\nHeight: " + Var.Height);
            }
        }

        private void Button21_Click(object sender, EventArgs e)
        {
            Dictionary<int, Size> Size = Simple.MultiSizeDictionary;

            foreach (KeyValuePair<int, Size> Var in Size)
            {
                MessageBox.Show("Screen " + Var.Key + " =>\n" + "\tWidth: " + Var.Value.Width + "\n\tHeight: " + Var.Value.Height);
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

        private void Button18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Width: " + Advanced.Size.Width + "\nHeight: " + Advanced.Size.Height);
        }

        private void Button17_Click(object sender, EventArgs e)
        {
            Location = Advanced.SingleLocation(EdgeLocationType.TopLeft, Width, Height, 32);
            Thread.Sleep(750);
            Location = Advanced.SingleLocation(EdgeLocationType.TopCenter, Width, Height, 32);
            Thread.Sleep(750);
            Location = Advanced.SingleLocation(EdgeLocationType.TopRight, Width, Height, 32);
            Thread.Sleep(750);
            Location = Advanced.SingleLocation(EdgeLocationType.BotLeft, Width, Height, 32);
            Thread.Sleep(750);
            Location = Advanced.SingleLocation(EdgeLocationType.BotCenter, Width, Height, 32);
            Thread.Sleep(750);
            Location = Advanced.SingleLocation(EdgeLocationType.BotRight, Width, Height, 32);
            Thread.Sleep(750);
            Location = Advanced.SingleLocation(EdgeLocationType.LeftCenter, Width, Height, 32);
            Thread.Sleep(750);
            Location = Advanced.SingleLocation(EdgeLocationType.RightCenter, Width, Height, 32);
            Thread.Sleep(750);
            Location = Advanced.SingleLocation(EdgeLocationType.CalcCenter, Width, Height);
            Thread.Sleep(750);
            Location = Advanced.SingleLocation(EdgeLocationType.FullCenter, Width, Height);
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