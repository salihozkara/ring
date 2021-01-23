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
using System.Windows.Forms.VisualStyles;

namespace VeritabaniProje
{
    class Listele
    { 
        public List<FlowLayoutPanel> Flp { get; set; }
        private int kullaniciId;
        private FrmFilmListe form;
        private Panel panel;
        private bool admin;
        public Listele(int kullaniciId,FrmFilmListe form,bool admin)
        {
            this.kullaniciId = kullaniciId;
            this.form = form;
            this.admin = admin;
            Flp = new List<FlowLayoutPanel>();
            kategorilendir();
        }
        private void liste(string kategori)
        {
            Baglanti baglanti=new Baglanti();
            SqlCommand cmd = new SqlCommand();
            string sorgu = $"select * from FilmListele where KategoriAdi='{kategori}'";
            baglanti.sorguCalistir(sorgu,ref cmd);
            SqlDataReader dr = cmd.ExecuteReader();
            FlowLayoutPanel fr = new FlowLayoutPanel();
            while (dr.Read())
            {
                Panel panel = new Panel();
                flpDoldur(fr);
                panelDoldur(ref panel, dr);
                fr.Controls.Add(panel);
                fr.Tag = dr["KategoriAdi"];
            }
            baglanti.baglantiKapat();
            Flp.Add(fr);
        }

        #region PanelElemanlari
        void panelDoldur(ref Panel panel, SqlDataReader dr)
        {
            panel.Controls.Clear();
            Button btnBegen = new Button();
            Button btnYorum = new Button();
            Button btnSil=new Button();
            PictureBox pictureBox1 = new PictureBox();
            RichTextBox richTextBox1 = new RichTextBox();
            Label label1 = new Label();
            Label label=new Label();
            Label lblFilmAdi = new Label();
            Label lblYonetmen=new Label();
            panel.SuspendLayout();
            ((ISupportInitialize)(pictureBox1)).BeginInit();
            // 
            // panel
            // 
            panel.AutoScroll = true;
            panel.Controls.Add(btnYorum);
            panel.Controls.Add(btnBegen);
            panel.Controls.Add(richTextBox1);
            panel.Controls.Add(pictureBox1);
            panel.Controls.Add(label1);
            panel.Controls.Add(label);
            panel.Controls.Add(btnSil);
            panel.Controls.Add(lblFilmAdi);
            panel.Controls.Add(lblYonetmen);
            panel.Size = new Size(268, 388);
            panel.BackColor = Color.Gray;
            //
            //lblFilmAdi
            //
            lblFilmAdi.AutoSize = true;
            lblFilmAdi.Text = "Film adı: "+dr["FilmAdi"];
            lblFilmAdi.ForeColor = Color.White;
            lblFilmAdi.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(162)));
            lblFilmAdi.Location = new Point(panel.Width / 2 - lblFilmAdi.Width / 2, 221);
            //
            //lblYonetmen
            //
            lblYonetmen.AutoSize = true;
            lblYonetmen.Text ="Yönetmen adı: "+ dr["Ad"];
            lblYonetmen.ForeColor = Color.White;
            lblYonetmen.Font = new Font("Times New Roman", 10.2F,FontStyle.Bold, GraphicsUnit.Point, ((byte)(162)));
            lblYonetmen.Location = new Point(panel.Width / 2 - lblYonetmen.Width / 2, 221 + lblFilmAdi.Height);
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(39, 221 + lblFilmAdi.Height+lblYonetmen.Height);
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(189, 99 - (lblFilmAdi.Height+lblYonetmen.Height));
            richTextBox1.Text = dr["FilmInfo"].ToString();
            //
            //btnSil
            //
            btnSil.Location=new Point(240,0);
            btnSil.Size= new Size(30, 26);
            btnSil.BackColor=Color.Gray;
            btnSil.Visible = false;
            btnSil.Click+=new EventHandler(btnSil_Click);
            btnSil.Tag= Convert.ToInt32(dr["FilmID"]);
            btnSil.BackgroundImage = Properties.Resources.times_circle_solid;
            btnSil.BackgroundImageLayout = ImageLayout.Zoom;
            if (admin)
            {
                btnSil.Visible = true;
            }
            // 
            // btnYorum
            // 
            btnYorum.BackgroundImage = Properties.Resources.comment_regular;
            btnYorum.BackgroundImageLayout =ImageLayout.Zoom;
            btnYorum.Location = new Point(173, 326);
            btnYorum.Size = new Size(30, 26);
            btnYorum.UseVisualStyleBackColor = true;
            btnYorum.Click += new EventHandler(this.btnYorum_Click);
            BtnBilgi yorum = new BtnBilgi();
            yorum.FilmId = Convert.ToInt32(dr["FilmID"]);
            yorum.KullaniciID = kullaniciId;
            yorum.Label = label;
            btnYorum.Tag = yorum;
            //
            // btnBegen
            // 
            Baglanti baglanti =new Baglanti();
            SqlCommand cmd = new SqlCommand();
            baglanti.sorguCalistir($"select *from tblLikes where kullaniciID='{kullaniciId}' and FilmID={dr["FilmID"]}",ref cmd);
            SqlDataReader dr2 = cmd.ExecuteReader();
            bool begen = false;
            while (dr2.Read())
            {
                begen = Convert.ToBoolean(dr2["Begendi"]);
            }
            baglanti.baglantiKapat();
            btnBegen.BackgroundImage =Properties.Resources.e6925a934d0c279e4bd98e2ddff557ee;
            btnBegen.BackgroundImageLayout =ImageLayout.Zoom;
            btnBegen.Location = new Point(39, 326);
            btnBegen.Size = new Size(30, 26);
            btnBegen.UseVisualStyleBackColor = true;
            if (begen)
            {
                btnBegen.BackColor = Color.Red;
            }
            else
            {
                btnBegen.BackColor = Color.AliceBlue;
            }
            btnBegen.FlatStyle = FlatStyle.Flat;
            BtnBilgi begeni = new BtnBilgi();
            begeni.FilmId = Convert.ToInt32(dr["FilmID"]);
            begeni.KullaniciID = kullaniciId;
            begeni.Label = label1;
            btnBegen.Tag = begeni;
            btnBegen.Click += new EventHandler(this.btnBegen_Click);
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(39, 12);
            pictureBox1.Size = new Size(189, 203);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            if (dr["Gorsel"] != DBNull.Value)
            {
                pictureBox1.Image = Bitmap.FromStream(new MemoryStream((byte[])dr["Gorsel"]));
            }
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(162)));
            label1.Location = new Point(35, 355);
            label1.Size = new Size(63, 20);
            label1.TabIndex = 5;
            Baglanti baglanti2=new Baglanti();
            SqlCommand cmd2 = new SqlCommand();
            baglanti2.sorguCalistir($"select count(*) as begeniSayisi from tblLikes where FilmID='{dr["FilmID"]}' and Begendi=1",ref cmd2);
            SqlDataReader dataReader = cmd2.ExecuteReader();
            while (dataReader.Read())
            {
                label1.Text = dataReader["begeniSayisi"].ToString();
            }
            baglanti.baglantiKapat();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(162)));
            label.Location = new Point(170, 355);
            label.Size = new Size(63, 20);
            Baglanti baglanti3 = new Baglanti();
            SqlCommand cmd3 = new SqlCommand();
            baglanti3.sorguCalistir($"select count(*) as yorumSayisi from tblYorumlar where FilmID='{dr["FilmID"]}'", ref cmd3);
            SqlDataReader dataReader2 = cmd3.ExecuteReader();
            while (dataReader2.Read())
            {
                label.Text = dataReader2["yorumSayisi"].ToString();
            }
            baglanti2.baglantiKapat();
        }
        #endregion
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istediğinize emin misiniz bu işlem geri alınamaz","Film Sil",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Button button=sender as Button;
                Baglanti baglanti=new Baglanti();
                baglanti.sorguCalistir($"delete from tblFilmler where FilmID='{button.Tag}'");
                FrmFilmListe frmFilmListe = (FrmFilmListe) Application.OpenForms["FrmFilmListe"];
                frmFilmListe.listele();
            }
        }
        private void btnBegen_Click(object sender, EventArgs e)
        {
            Baglanti baglanti=new Baglanti();
            Button button = sender as Button;
            BtnBilgi begeni = (BtnBilgi)button.Tag;
            int sayi = (Convert.ToInt32(begeni.Label.Text));
            try
            {
                if (button.BackColor == Color.Red)
                {
                    button.BackColor = Color.AliceBlue;
                    baglanti.sorguCalistir($"begen '{begeni.FilmId}','{begeni.KullaniciID}',0");
                    begeni.Label.Text = (--sayi).ToString();
                }
                else
                {
                    button.BackColor = Color.Red;
                    baglanti.sorguCalistir($"begen '{begeni.FilmId}','{begeni.KullaniciID}',1");
                    begeni.Label.Text = (++sayi).ToString();
                }
            }
            catch (Exception el)
            {
                MessageBox.Show(el.Message);
            }
        }

        private void btnYorum_Click(object sender, EventArgs e)
        {
            if (panel==null)
            {
                panel=new Panel();
            }
            Button button=sender as Button;
            BtnBilgi yorum = (BtnBilgi)button.Tag;
            panel.AutoScroll = true;
            panel.Size = new System.Drawing.Size(270, 196);
            form.panel1.Controls.Add(panel);
            panel.BringToFront();
            if (!panel.Visible)
            {
                panel.Visible = true;
            }
            panel.Controls.Clear();
            FrmYorumlar filmBilgi = new FrmYorumlar(yorum.FilmId, yorum.KullaniciID,yorum.Label,admin);
            filmBilgi.TopLevel = false;
            panel.Size = filmBilgi.Size;
            filmBilgi.FormBorderStyle = FormBorderStyle.None;
            int PSBH = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            int TaskBarHeight = PSBH - System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            int x = Cursor.Position.X - form.Location.X-filmBilgi.Width/2;
            int y=Cursor.Position.Y-form.Location.Y-18;
            if (Cursor.Position.Y>(form.Location.Y+form.Height-filmBilgi.Height-TaskBarHeight))
            {
                y -= filmBilgi.Height+35;
            }
            if (Cursor.Position.X>form.Location.X+form.Width-filmBilgi.Width/2)
            {
                x -= filmBilgi.Width/2;
            }
           
            panel.Controls.Add(filmBilgi);
            panel.Location = new Point(x, y);
            filmBilgi.Show();
            filmBilgi.Dock = DockStyle.Fill;
            filmBilgi.Panel = panel;
        }

        public void kategorilendir()
        {
            Baglanti baglanti=new Baglanti();
            SqlCommand cmd=new SqlCommand();
            baglanti.sorguCalistir("select DISTINCT KategoriAdi from FilmListele", ref cmd);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                liste(dr["KategoriAdi"].ToString());
            }
            baglanti.baglantiKapat();
        }
        void flpDoldur(FlowLayoutPanel flowLayoutPanel)
        {
            flowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            flowLayoutPanel.AutoScroll = true;
            Random rd = new Random();
            flowLayoutPanel.BackColor = Color.FromArgb(((int)(((byte)(rd.Next(0, 5))))), ((int)(((byte)(rd.Next(0, 5))))), ((int)(((byte)(rd.Next(0, 20))))));
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.Size = new Size(form.Width-18, 413);
        }
    }
}
