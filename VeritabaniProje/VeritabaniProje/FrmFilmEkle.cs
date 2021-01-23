using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeritabaniProje
{
    public partial class FrmFilmEkle : Form
    {
        FrmFilmListe frmFilmListe;
        public FrmFilmEkle(FrmFilmListe filmListe)
        {
            InitializeComponent();
            this.frmFilmListe = filmListe;
        }
        Baglanti baglanti=new Baglanti();//Db ye bağlanmak için
        SqlCommand cmd = new SqlCommand();
        Cmb cmb = new Cmb();//comboboxları düzenleyen sınıf
        private FileStream fs;
        private byte[] resim;//resmi byte olarak veritabanına aktaran dizi
        private void btnGorsel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog GorselSec=new OpenFileDialog();
                GorselSec.Filter = "resim dosyası |*.jpg;*.png|All files (*.*)|*.*";//seçilecek türleri filtreler
                if (GorselSec.ShowDialog() == DialogResult.OK)//seçildi ise yolundan alarak resmi binarye dönüştürüp byte resim dizisine aktarır
                {
                    fs = File.OpenRead(GorselSec.FileName);
                    BinaryReader br = new BinaryReader(fs);
                    resim = br.ReadBytes((int)fs.Length);
                    pictureBox1.Image = Bitmap.FromStream(new MemoryStream(resim));
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);//hata oluşursa hata mesajı
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                cmb.Düzenle(ref cmbYonetmen);
                cmb.Düzenle(ref cmbKategori);
            }
            catch (Exception exception)
            {
            }
            string sorgu = $"FilmEkle '{txtFilmAdi.Text}','{cmbKategori.SelectedItem}','{cmbYonetmen.SelectedItem}',@Gorsel,@filminfo";
            baglanti.sorguCalistir(sorgu,ref cmd);
            if (resim != null)
            {
                cmd.Parameters.AddWithValue("@Gorsel", resim);//resim seçildi ise resmi DB ye aktarılıyor
            }
            else
            {
                cmd.Parameters.Add("@Gorsel", SqlDbType.Image, 0).Value = DBNull.Value;//Resim yok ise null değeri döndürür
            }
            cmd.Parameters.Add("@filminfo", SqlDbType.Text, richTextBoxFilmInfo.Text.Length).Value =
                richTextBoxFilmInfo.Text;
            
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("eklendi");
                frmFilmListe.listele();//film eklenince sayfayı yenileme işlemi
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            cmd.Parameters.Clear();
            baglanti.baglantiKapat();
            this.Close();
        }

        private void FrmFilmEkle_Load(object sender, EventArgs e)
        {
            try
            {
                cmb.Doldur("tblYonetmenler","Ad",cmbYonetmen);
                cmb.Doldur("tblKategoriler","KategoriAdi",cmbKategori);
            }
            catch (Exception exception)
            {
            }
        }
    }
}
