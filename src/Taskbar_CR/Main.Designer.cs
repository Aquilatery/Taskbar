namespace Taskbar_CR
{
    partial class Main
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "Simple\r\nSingle Detect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(324, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 64);
            this.button2.TabIndex = 1;
            this.button2.Text = "Simple\r\nMulti Detect Dictionary";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 176);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 64);
            this.button3.TabIndex = 2;
            this.button3.Text = "Advanced\r\nAlways On Top";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(168, 176);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 64);
            this.button4.TabIndex = 3;
            this.button4.Text = "Advanced\r\nAuto Hide";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(324, 176);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 64);
            this.button5.TabIndex = 4;
            this.button5.Text = "Advanced\r\nPosition";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 246);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(150, 64);
            this.button6.TabIndex = 5;
            this.button6.Text = "Advanced\r\nHide";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(168, 246);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(150, 64);
            this.button7.TabIndex = 6;
            this.button7.Text = "Advanced\r\nShow";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(168, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(150, 64);
            this.button8.TabIndex = 7;
            this.button8.Text = "Simple\r\nMulti Detect List";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(324, 246);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(150, 64);
            this.button9.TabIndex = 8;
            this.button9.Text = "Advanced\r\nFind Docked Taskbars List";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(12, 316);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(150, 64);
            this.button10.TabIndex = 9;
            this.button10.Text = "Advanced\r\nFind Docked Taskbars Dictionary";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(168, 316);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(150, 64);
            this.button11.TabIndex = 10;
            this.button11.Text = "Advanced\r\nData Taskbar Value";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(12, 386);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(150, 64);
            this.button12.TabIndex = 11;
            this.button12.Text = "Advanced\r\nRefresh All";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(324, 316);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(150, 64);
            this.button13.TabIndex = 12;
            this.button13.Text = "Advanced\r\nRefresh Data";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.Button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(12, 82);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(150, 64);
            this.button14.TabIndex = 13;
            this.button14.Text = "Simple\r\nSingle Location";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.Button14_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(168, 82);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(150, 64);
            this.button15.TabIndex = 14;
            this.button15.Text = "Simple\r\nMulti Location List";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.Button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(324, 82);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(150, 64);
            this.button16.TabIndex = 15;
            this.button16.Text = "Simple\r\nMulti Location Dictionary\r\n";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.Button16_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(486, 462);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
    }
}