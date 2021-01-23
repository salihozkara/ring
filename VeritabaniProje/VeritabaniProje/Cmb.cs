using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeritabaniProje
{
    class Cmb
    {
        Baglanti baglan = new Baglanti();//bağlan sınıfından sql bağlantısını al

        public void Doldur(string tablo, string columName, ComboBox cmb)//comboboxa veritabanından veri çek
        {
            List<string> cmbList = new List<string>();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            string sorgu = "select " + columName + " from " + tablo + " ";//tablo adı ve veri adı ile komutu ver
            SqlCommand cmd=new SqlCommand();
            baglan.sorguCalistir(sorgu,ref cmd);
            SqlDataReader dr = cmd.ExecuteReader();//verileri oku
            while (dr.Read())
            {
                cmb.Items.Add(dr[columName]);//verileri cmb itemlerine ekle
                cmbList.Add(dr[columName].ToString());
                collection.Add(dr[columName].ToString());
            }
            baglan.baglantiKapat();
            cmb.AutoCompleteCustomSource = collection;
            cmb.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmb.SelectedIndex = -1;
        }

        public void Düzenle(ref ComboBox cmb)//cmb de istediğimiz veri yoksa cmb.text e yazdığımız veriyi iteme  ekle
        {
            bool kontrol = false;//cmb itemlerinde var mı
            if (cmb.SelectedIndex == -1 && cmb.Text != "")//item seçilmemiş ve cmb.text boş değilse
            {
                kontrol = true;//cmb itemlerinde yok sonraki fonksiyonda var çıkmaz ise
                foreach (var item in cmb.Items)//cmb itemlerini tarıyor
                {
                    if (cmb.Text == item.ToString())//cmb.text cmb nin itemlerinde var mı
                    {
                        kontrol = false;//cmb itemlerinde var
                        cmb.SelectedItem = item;//o item seçildi
                        break;//kontrol etmeyi bırak
                    }
                }

            }
            if (kontrol)//cmb itemlerinde yoksa
            {
                cmb.Items.Add(cmb.Text);//cmb itemlerine ekle
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                cmb.AutoCompleteCustomSource = collection;
                foreach (var item in cmb.Items)
                {
                    collection.Add(item.ToString());
                }
                cmb.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmb.SelectedIndex = -1;
                cmb.SelectedItem = cmb.Text;//o itemi seç
            }

        }
    }
}
