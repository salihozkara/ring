
namespace VeritabaniProje
{
    partial class FrmFilmListe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFilmListe));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonCikis = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownBtnMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.şifreDeğiştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hesabımıSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullanıcılarıListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filmEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.lblUygukamaAdi = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 264);
            this.panel1.TabIndex = 11;
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButtonCikis,
            this.toolStripDropDownBtnMenu,
            this.toolStripButton1});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(480, 31);
            this.toolStrip.TabIndex = 10;
            this.toolStrip.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 28);
            // 
            // toolStripButtonCikis
            // 
            this.toolStripButtonCikis.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonCikis.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCikis.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCikis.Image")));
            this.toolStripButtonCikis.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCikis.Name = "toolStripButtonCikis";
            this.toolStripButtonCikis.Size = new System.Drawing.Size(29, 28);
            this.toolStripButtonCikis.Text = "Çıkış";
            this.toolStripButtonCikis.Click += new System.EventHandler(this.toolStripButtonCikis_Click);
            // 
            // toolStripDropDownBtnMenu
            // 
            this.toolStripDropDownBtnMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownBtnMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownBtnMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.şifreDeğiştirToolStripMenuItem,
            this.hesabımıSilToolStripMenuItem,
            this.kullanıcılarıListeleToolStripMenuItem,
            this.filmEkleToolStripMenuItem});
            this.toolStripDropDownBtnMenu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownBtnMenu.Image")));
            this.toolStripDropDownBtnMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownBtnMenu.Name = "toolStripDropDownBtnMenu";
            this.toolStripDropDownBtnMenu.Size = new System.Drawing.Size(34, 28);
            // 
            // şifreDeğiştirToolStripMenuItem
            // 
            this.şifreDeğiştirToolStripMenuItem.Name = "şifreDeğiştirToolStripMenuItem";
            this.şifreDeğiştirToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.şifreDeğiştirToolStripMenuItem.Text = "şifre değiştir";
            this.şifreDeğiştirToolStripMenuItem.Click += new System.EventHandler(this.şifreDeğiştirToolStripMenuItem_Click);
            // 
            // hesabımıSilToolStripMenuItem
            // 
            this.hesabımıSilToolStripMenuItem.Name = "hesabımıSilToolStripMenuItem";
            this.hesabımıSilToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.hesabımıSilToolStripMenuItem.Text = "hesabımı sil";
            this.hesabımıSilToolStripMenuItem.Click += new System.EventHandler(this.hesabımıSilToolStripMenuItem_Click);
            // 
            // kullanıcılarıListeleToolStripMenuItem
            // 
            this.kullanıcılarıListeleToolStripMenuItem.Name = "kullanıcılarıListeleToolStripMenuItem";
            this.kullanıcılarıListeleToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.kullanıcılarıListeleToolStripMenuItem.Text = "Kullanıcıları Listele";
            this.kullanıcılarıListeleToolStripMenuItem.Visible = false;
            this.kullanıcılarıListeleToolStripMenuItem.Click += new System.EventHandler(this.kullanıcılarıListeleToolStripMenuItem_Click);
            // 
            // filmEkleToolStripMenuItem
            // 
            this.filmEkleToolStripMenuItem.Name = "filmEkleToolStripMenuItem";
            this.filmEkleToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.filmEkleToolStripMenuItem.Text = "Film Ekle";
            this.filmEkleToolStripMenuItem.Visible = false;
            this.filmEkleToolStripMenuItem.Click += new System.EventHandler(this.filmEkleToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 28);
            this.toolStripButton1.Text = "Yenile";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripBtnRefresh_Click);
            // 
            // lblUygukamaAdi
            // 
            this.lblUygukamaAdi.AutoSize = true;
            this.lblUygukamaAdi.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblUygukamaAdi.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUygukamaAdi.Location = new System.Drawing.Point(187, 0);
            this.lblUygukamaAdi.Name = "lblUygukamaAdi";
            this.lblUygukamaAdi.Size = new System.Drawing.Size(94, 35);
            this.lblUygukamaAdi.TabIndex = 12;
            this.lblUygukamaAdi.Text = "RING";
            // 
            // FrmFilmListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(480, 295);
            this.Controls.Add(this.lblUygukamaAdi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFilmListe";
            this.Text = "Ring";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFilmListe_FormClosing);
            this.Load += new System.EventHandler(this.FrmFilmListe_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        public System.Windows.Forms.ToolStripButton toolStripButtonCikis;
        public System.Windows.Forms.ToolStripDropDownButton toolStripDropDownBtnMenu;
        private System.Windows.Forms.ToolStripMenuItem şifreDeğiştirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hesabımıSilToolStripMenuItem;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem kullanıcılarıListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filmEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label lblUygukamaAdi;
    }
}