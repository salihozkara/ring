using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeritabaniProje
{
    class Baglanti
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=localhost;Initial Catalog=ring2;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public void sorguCalistir(string sorgu)
        {
            if (baglantiAc())
            {
                cmd.Connection = baglanti;
                cmd.CommandText = sorgu;
                cmd.ExecuteNonQuery();
                baglantiKapat();
            }
        }

        public void sorguCalistir(string sorgu,ref SqlCommand cmd2)
        {
            if (baglantiAc())
            {
                cmd.Connection = baglanti;
                cmd.CommandText = sorgu;
                cmd2 = this.cmd;
            }
        }
       
        bool baglantiAc()
        {
            try
            {
                baglanti.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public void baglantiKapat()
        {
            baglanti.Close();
        }
    }
}
