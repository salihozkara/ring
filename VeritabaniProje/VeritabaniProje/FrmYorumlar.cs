using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeritabaniProje
{
    public partial class FrmYorumlar : Form
    {
        private int filmId;
        private int kullaniciId;
        public Panel Panel { get; set; }
        private Label label;
        private bool admin;
        public FrmYorumlar(int filmId,int kullaniciId,Label label,bool admin)
        {
            InitializeComponent();
            this.filmId = filmId;
            this.kullaniciId = kullaniciId;
            this.label = label;
            this.admin = admin;
        }

        private void FilmBilgi_Load(object sender, EventArgs e)
        {
            YorumListele yorumListele=new YorumListele(filmId,kullaniciId,flowLayoutPanel1,label,admin);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Panel.Visible = false;
            this.Close();
        }
        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (richTextBoxYazYrm.Text!="")
            {
                try
                {

                    Baglanti baglanti=new Baglanti();
                    string sorgu = $"YorumEkle '{kullaniciId}','{richTextBoxYazYrm.Text}','{filmId}'";
                    baglanti.sorguCalistir(sorgu);
                    YorumListele yorumListele = new YorumListele(filmId, kullaniciId, flowLayoutPanel1,label,admin);
                    richTextBoxYazYrm.Text = "";
                    int sayi = (Convert.ToInt32(this.label.Text));
                    this.label.Text = (++sayi).ToString();
                }
                catch (Exception exception)
                {
                   MessageBox.Show(exception.Message);
                }
            }
        }

        private void richTextBoxYazYrm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGonder.PerformClick();
                e.Handled = true;
            }
        }
    }
}
