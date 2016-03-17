namespace ClockWidget
{
    partial class frmClock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerSecond = new System.Windows.Forms.Timer(this.components);
            this.ctMenu = new System.Windows.Forms.ContextMenu();
            this.mnSecond = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.mnExit = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // timerSecond
            // 
            this.timerSecond.Enabled = true;
            this.timerSecond.Interval = 1000;
            this.timerSecond.Tick += new System.EventHandler(this.timerSecond_Tick);
            // 
            // ctMenu
            // 
            this.ctMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnSecond,
            this.menuItem6,
            this.menuItem8,
            this.mnExit});
            // 
            // mnSecond
            // 
            this.mnSecond.Index = 0;
            this.mnSecond.Text = "Show the second hand";
            this.mnSecond.Click += new System.EventHandler(this.mnSecond_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem7,
            this.menuItem9,
            this.menuItem11,
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5});
            this.menuItem6.Text = "Opacity";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 0;
            this.menuItem7.Text = "5  %";
            this.menuItem7.Click += new System.EventHandler(this.mnOpacity_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 1;
            this.menuItem9.Text = "10 %";
            this.menuItem9.Click += new System.EventHandler(this.mnOpacity_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 2;
            this.menuItem11.Text = "15 %";
            this.menuItem11.Click += new System.EventHandler(this.mnOpacity_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "20 %";
            this.menuItem1.Click += new System.EventHandler(this.mnOpacity_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 4;
            this.menuItem2.Text = "40 %";
            this.menuItem2.Click += new System.EventHandler(this.mnOpacity_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 5;
            this.menuItem3.Text = "60 %";
            this.menuItem3.Click += new System.EventHandler(this.mnOpacity_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 6;
            this.menuItem4.Text = "80 %";
            this.menuItem4.Click += new System.EventHandler(this.mnOpacity_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 7;
            this.menuItem5.Text = "100%";
            this.menuItem5.Click += new System.EventHandler(this.mnOpacity_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "-";
            // 
            // mnExit
            // 
            this.mnExit.Index = 3;
            this.mnExit.Text = "Exit";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // frmClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 263);
            this.ContextMenu = this.ctMenu;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.Name = "frmClock";
            this.ShowInTaskbar = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmClock_FormClosed);
            this.Load += new System.EventHandler(this.frmClock_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmClock_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerSecond;
        private System.Windows.Forms.ContextMenu ctMenu;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem mnExit;
        private System.Windows.Forms.MenuItem mnSecond;
    }
}

