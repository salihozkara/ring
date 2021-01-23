using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace VeritabaniProje
{
    public partial class FrmFilmListe : Form
    {
        private int kullaniciId;
        private bool admin;
        public FrmFilmListe(int kullaniciId,bool admin)
        {
            InitializeComponent();
            if (admin)//admin ise gözükücek menü itemleri
            {
                filmEkleToolStripMenuItem.Visible = true;
                kullanıcılarıListeleToolStripMenuItem.Visible = true;
            }
            this.kullaniciId = kullaniciId;
            this.admin = admin;
        }

        private bool kapat;
        private void FrmFilmListe_Load(object sender, EventArgs e)
        {
            lblUygukamaAdi.Left = this.Width / 2 - lblUygukamaAdi.Width / 2;
            listele();
        }

        public void listele()
        {
            panel1.Controls.Clear();
            Listele listele = new Listele(kullaniciId, this, admin);
            int top = 40;

            try
            {
                foreach (var listeleFlowLayoutPanel in listele.Flp)
                {
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Font = new Font("Microsoft Sans Serif", 19.8F, FontStyle.Bold,
                        GraphicsUnit.Point, ((byte) (162)));
                    label.ForeColor = Color.Red;
                    try
                    {
                        label.Text = listeleFlowLayoutPanel.Tag.ToString().ToUpper();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }

                    label.Top = top - 40;
                    panel1.Controls.Add(label);
                    label.Left = this.Width / 2 - label.Width / 2;
                    listeleFlowLayoutPanel.Top = top;
                    panel1.Controls.Add(listeleFlowLayoutPanel);
                    top += 450;
                    top += 10;
                }
            }
            catch (Exception e)
            {
                if (MessageBox.Show(e.Message) == DialogResult.OK)
                {
                    this.listele();
                }
            }
        }
        private void filmEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFilmEkle frmFilmEkle = new FrmFilmEkle(this);
            frmFilmEkle.ShowDialog();
        }

        private void şifreDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string yeniSifre = Interaction.InputBox("Yeni Şifre", "Şifre Değiştir", "");
            if (yeniSifre != "")
            {
                try
                {
                    Baglanti baglanti = new Baglanti();
                    baglanti.sorguCalistir($"update tblLogin set Sifre='{yeniSifre}' where KullaniciId='{kullaniciId}'");
                    MessageBox.Show("başarılı");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                MessageBox.Show(yeniSifre);
            }
        }

        private void hesabımıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Emin misiniz", "Hesap Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Baglanti baglanti = new Baglanti();
                try
                {
                    baglanti.sorguCalistir($"Delete from tblKullanicilar where kullaniciId='{kullaniciId}'");
                    toolStripButtonCikis.PerformClick();
                    MessageBox.Show("Hesabınız silindi");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }
        }

        private void toolStripButtonCikis_Click(object sender, EventArgs e)
        {
            kapat = true;
            this.Close();
            Form frm = Application.OpenForms["FrmGiris"];
            frm.Show();
        }

        private void FrmFilmListe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!kapat)
            {
                Application.Exit();
            }
        }

        private void kullanıcılarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKullanıcılar frmKullanıcılar=new FrmKullanıcılar(kullaniciId);
            frmKullanıcılar.ShowDialog();
        }

        private void toolStripBtnRefresh_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
