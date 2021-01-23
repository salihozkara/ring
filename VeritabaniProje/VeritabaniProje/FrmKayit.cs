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
    public partial class FrmKayit : Form
    {
        public FrmKayit()
        {
            InitializeComponent();
        }

        private void txtSifreTkrr_KeyUp(object sender, KeyEventArgs e)
        {
            sifreKontrol();
        }

        private byte[] resim;
        bool sifreKontrol()
        {
            if (txtSifre.Text != txtSifreTkrr.Text)
            {
                label4.Text = "şifreler eşleşmiyor";
                return false;
            }
            else
            {
                label4.Text = "";
                return true;
            }
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            if (!sifreKontrol() && txtNick.Text=="")
            {
                MessageBox.Show("Bilgilerinizi Kontrol Ediniz");
            }

            if (kayit())
            {
                if (MessageBox.Show("Kaydınız Başarılı") == DialogResult.OK)
                {
                   this.Close();
                }
            }
        }

        bool kayit()
        {
            Baglanti baglanti=new Baglanti();
            string sorgu = $"KullaniciKayit ";
            SqlCommand cmd=new SqlCommand();
            try
            {
                baglanti.sorguCalistir(sorgu,ref cmd);
                cmd.Parameters.AddWithValue("@KullaniciAdi", txtNick.Text);
                cmd.Parameters.AddWithValue("@Sifre", txtSifre.Text);
                if (resim!=null)
                {
                    cmd.Parameters.AddWithValue("@Gorsel", resim);
                }
                else
                {
                    cmd.Parameters.Add("@Gorsel", SqlDbType.Image, 0).Value = DBNull.Value;
                }
                cmd.CommandType = CommandType.StoredProcedure;
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                var result = returnParameter.Value;
                if (!Convert.ToBoolean(result))
                {
                    MessageBox.Show("Kullanıcı adı var");
                    return false;
                }
                cmd.Parameters.Clear();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                
                return false;
            }
        }
        FileStream fs;
        private void btnGorsel_Click(object sender, EventArgs e)
        {
            OpenFileDialog GorselSec = new OpenFileDialog();
            GorselSec.Filter = "resim dosyası (*.jpg *.png)|*.jpg;*.png|All files (*.*)|*.*";
            try
            {
                if (GorselSec.ShowDialog() == DialogResult.OK)
                {
                    fs = File.OpenRead(GorselSec.FileName);
                    BinaryReader br = new BinaryReader(fs);
                    resim = br.ReadBytes((int)fs.Length);
                    pictureBox1.Image = Bitmap.FromStream(new MemoryStream(resim));
                }
                else
                {
                    resim = null;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
