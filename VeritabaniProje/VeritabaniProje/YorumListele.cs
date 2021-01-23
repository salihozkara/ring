using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeritabaniProje
{
    class YorumListele
    {
        private int filmId;
        private int kullaniciId;
        private FlowLayoutPanel flp;
        private Label label;
        private bool admin;
        public YorumListele(int filmID, int kullaniciId,FlowLayoutPanel flp,Label label,bool admin)
        {
            this.kullaniciId = kullaniciId;
            this.filmId = filmID;
            this.flp = flp;
            this.label = label;
            this.admin = admin;
            yorumlariEkle();
        }
        void panelDoldur(SqlDataReader dr,ref Panel panelYorum)
        {
            panelYorum.Controls.Clear();
            Button btnSil=new Button();
            Button btnDuzenle=new Button();
            Label lblNick=new Label();
            Label lblTarih=new Label();
            RichTextBox richTextBoxYorum=new RichTextBox();
            PictureBox pictureBoxPP=new PictureBox();
            panelYorum.SuspendLayout();
            ((ISupportInitialize)(pictureBoxPP)).BeginInit();
            // 
            // panelYorum
            // 
            panelYorum.Controls.Add(btnSil);
            panelYorum.Controls.Add(btnDuzenle);
            panelYorum.Controls.Add(lblNick);
            panelYorum.Controls.Add(richTextBoxYorum);
            panelYorum.Controls.Add(pictureBoxPP);
            panelYorum.Controls.Add(lblTarih);
            panelYorum.Size = new System.Drawing.Size(255, 60);
            panelYorum.BackColor = Color.Red;
            // 
            // richTextBoxYorum
            // 
            richTextBoxYorum.Location = new System.Drawing.Point(53, 20);
            richTextBoxYorum.Name = "richTextBoxYorum";
            if (kullaniciId!= Convert.ToInt32(dr["kullaniciID"]))
            {
                richTextBoxYorum.ReadOnly = true;
            }
            richTextBoxYorum.Size = new System.Drawing.Size(200, 38);
            richTextBoxYorum.TabIndex = 1;
            richTextBoxYorum.Text = dr["Yorum"].ToString();
            //
            //BtnBilgi
            //
            BtnBilgi yorumBilgi = new BtnBilgi();
            yorumBilgi.KullaniciID = Convert.ToInt32(dr["kullaniciID"]);
            yorumBilgi.FilmId = Convert.ToInt32(dr["FilmID"]);
            yorumBilgi.YorumID = Convert.ToInt32(dr["YorumID"]);
            yorumBilgi.RichTextBox = richTextBoxYorum;
            if (kullaniciId != Convert.ToInt32(dr["kullaniciID"]) && !admin)
            {
                btnSil.Visible = false;
                btnDuzenle.Visible = false;
            }
            // 
            // btnSil
            // 
            btnSil.Size = new Size(20, 20);
            btnSil.Location = new Point(235, 0);
            btnSil.Text = "";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click+= new EventHandler(btnSil_Click);
            btnSil.Tag = yorumBilgi;
            btnSil.BackgroundImage = Properties.Resources.trash_alt_solid;
            btnSil.BackgroundImageLayout = ImageLayout.Zoom;
            // 
            // btnDuzenle
            // 
            btnDuzenle.Size = new System.Drawing.Size(20, 20);
            btnDuzenle.Location = new System.Drawing.Point(214, 0);
            btnDuzenle.TabIndex = 3;
            btnDuzenle.Text = "";
            btnDuzenle.Click+= new EventHandler(btnDuzenle_Click);
            btnDuzenle.Tag = yorumBilgi;
            btnDuzenle.UseVisualStyleBackColor = true;
            btnDuzenle.BackgroundImage = Properties.Resources.edit_solid;
            btnDuzenle.BackgroundImageLayout = ImageLayout.Zoom;
            // 
            // lblNick
            // 
            lblNick.AutoSize = true;
            lblNick.BackColor=Color.White;
            lblNick.Location = new System.Drawing.Point(53, 7);
            lblNick.Name = "lblNick";
            lblNick.Size = new System.Drawing.Size(46, 17);
            try
            {
                lblNick.Text = dr["KullaniciAdi"].ToString();
            }
            catch (Exception)
            {
                lblNick.Text= dr["kullaniciID"].ToString();
            }
            //
            //lblTarih
            //
            lblTarih.AutoSize = true;
            lblTarih.BackColor = Color.White;
            lblTarih.Location = new System.Drawing.Point(lblNick.Location.X+lblNick.Width+20, 7);
            lblTarih.Text = dr["Tarih"].ToString();
            // 
            // pictureBoxPP
            // 
            pictureBoxPP.Location = new System.Drawing.Point(0, 0);
            pictureBoxPP.Name = "pictureBoxPP";
            pictureBoxPP.Size = new System.Drawing.Size(50, 60);
            pictureBoxPP.TabIndex = 0;
            pictureBoxPP.TabStop = false;
            pictureBoxPP.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBoxPP.SizeMode = PictureBoxSizeMode.Zoom;
            if (dr["Gorsel"]!=DBNull.Value)
            {
                pictureBoxPP.Image = Bitmap.FromStream(new MemoryStream((byte[])dr["Gorsel"]));
            }
            else
            {
                pictureBoxPP.Image = Properties.Resources.defaultPP;
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            Button button=sender as Button;
            BtnBilgi yorumBilgi = (BtnBilgi) button.Tag;
            Baglanti baglanti=new Baglanti();
            string sorgu = $"YorumGuncelle '{yorumBilgi.YorumID}','{yorumBilgi.RichTextBox.Text}'";
            baglanti.sorguCalistir(sorgu);
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            BtnBilgi yorumBilgi = (BtnBilgi)button.Tag;
            Baglanti baglanti = new Baglanti();
            string sorgu = $"Delete from tblYorumlar where YorumID='{yorumBilgi.YorumID}'";
            baglanti.sorguCalistir(sorgu);
            yorumlariEkle();
            int sayi = (Convert.ToInt32(label.Text));
            label.Text = (--sayi).ToString();
        }
        void yorumlariEkle()
        {
            flp.Controls.Clear();
            Baglanti baglanti=new Baglanti();
            SqlCommand cmd=new SqlCommand();
            string sorgu = $"select * from YorumListele where FilmID='{filmId}'";
            baglanti.sorguCalistir(sorgu,ref cmd);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Panel panel=new Panel();
                panelDoldur(dr,ref panel);
                flp.Controls.Add(panel);
            }
            baglanti.baglantiKapat();
        }

    }
}
