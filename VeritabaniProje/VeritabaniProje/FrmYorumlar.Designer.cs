
namespace VeritabaniProje
{
    partial class FrmYorumlar
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
            this.richTextBoxYazYrm = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGonder = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxYazYrm
            // 
            this.richTextBoxYazYrm.Location = new System.Drawing.Point(1, 327);
            this.richTextBoxYazYrm.Name = "richTextBoxYazYrm";
            this.richTextBoxYazYrm.Size = new System.Drawing.Size(317, 67);
            this.richTextBoxYazYrm.TabIndex = 2;
            this.richTextBoxYazYrm.Text = "";
            this.richTextBoxYazYrm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxYazYrm_KeyDown);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(373, 296);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btnGonder
            // 
            this.btnGonder.BackgroundImage = global::VeritabaniProje.Properties.Resources.paper_plane_solid;
            this.btnGonder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGonder.Location = new System.Drawing.Point(324, 342);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(45, 45);
            this.btnGonder.TabIndex = 3;
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.BackgroundImage = global::VeritabaniProje.Properties.Resources.times_circle_solid;
            this.btnKapat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnKapat.Location = new System.Drawing.Point(346, 1);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(28, 27);
            this.btnKapat.TabIndex = 0;
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // FrmFilmBilgi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(381, 399);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.richTextBoxYazYrm);
            this.Controls.Add(this.btnKapat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFilmBilgi";
            this.Text = "FilmBilgi";
            this.Load += new System.EventHandler(this.FilmBilgi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.RichTextBox richTextBoxYazYrm;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}