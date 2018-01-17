namespace WindowsFormsApplication27
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.busToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.halterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jadwalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiketToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.busToolStripMenuItem,
            this.halterToolStripMenuItem,
            this.ruteToolStripMenuItem,
            this.jadwalToolStripMenuItem,
            this.tiketToolStripMenuItem,
            this.tiketToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(749, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // busToolStripMenuItem
            // 
            this.busToolStripMenuItem.Name = "busToolStripMenuItem";
            this.busToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.busToolStripMenuItem.Text = "Beranda";
            // 
            // halterToolStripMenuItem
            // 
            this.halterToolStripMenuItem.Name = "halterToolStripMenuItem";
            this.halterToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.halterToolStripMenuItem.Text = "Bus";
            this.halterToolStripMenuItem.Click += new System.EventHandler(this.halterToolStripMenuItem_Click);
            // 
            // ruteToolStripMenuItem
            // 
            this.ruteToolStripMenuItem.Name = "ruteToolStripMenuItem";
            this.ruteToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.ruteToolStripMenuItem.Text = "Halte";
            // 
            // jadwalToolStripMenuItem
            // 
            this.jadwalToolStripMenuItem.Name = "jadwalToolStripMenuItem";
            this.jadwalToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.jadwalToolStripMenuItem.Text = "Rute";
            // 
            // tiketToolStripMenuItem
            // 
            this.tiketToolStripMenuItem.Name = "tiketToolStripMenuItem";
            this.tiketToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.tiketToolStripMenuItem.Text = "Jadwal";
            // 
            // tiketToolStripMenuItem1
            // 
            this.tiketToolStripMenuItem1.Name = "tiketToolStripMenuItem1";
            this.tiketToolStripMenuItem1.Size = new System.Drawing.Size(45, 20);
            this.tiketToolStripMenuItem1.Text = "Tiket";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 579);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem busToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem halterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ruteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jadwalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiketToolStripMenuItem1;
    }
}