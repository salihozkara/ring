using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeritabaniProje
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            Baglanti baglanti=new Baglanti();
            SqlCommand cmd=new SqlCommand();
            string sorgu = $"GirisProc '{txtNick.Text}'";
            baglanti.sorguCalistir(sorgu, ref cmd);
            SqlDataReader dr = cmd.ExecuteReader();
            bool nickKontrol = false;
            bool sifreKontrol = false;
            while (dr.Read())
            {
                nickKontrol = true;
                if (txtSifre.Text==dr["Sifre"].ToString())
                {
                    sifreKontrol = true;
                    bool admin = false;
                    if (dr["Admin"] != DBNull.Value && Convert.ToBoolean(dr["Admin"]))
                    {
                        admin = true;
                    }

                    this.Hide();
                    FrmFilmListe frmFilmListe = new FrmFilmListe(Convert.ToInt32(dr["kullaniciID"]), admin);
                    frmFilmListe.Show();
                }
            }

            if (!nickKontrol)
            {
                MessageBox.Show("Kullanıcı adı hatalı");
            }else if (!sifreKontrol)
            {
                MessageBox.Show("Şifre hatalı");
            }
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGiris.PerformClick();
            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            FrmKayit frmKayit=new FrmKayit();
            frmKayit.TopLevel = false;
            this.Controls.Add(frmKayit);
            frmKayit.Dock = DockStyle.Fill;
            frmKayit.BringToFront();
            frmKayit.Show();
        }

    }
}
