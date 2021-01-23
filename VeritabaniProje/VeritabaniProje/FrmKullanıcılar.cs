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
    public partial class FrmKullanıcılar : Form
    {
        private int kullaniciID ;
        private int kullaniciRowIndex;

        public FrmKullanıcılar(int kullaniciId)
        {
            kullaniciID = kullaniciId;
            InitializeComponent();
        }

        private void FrmKullanıcılar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ring2DataSet.KullaniciListele' table. You can move, or remove it, as needed.
            dataGridDoldur();
        }


        private void dataGridDoldur()
        {
            this.kullaniciListeleTableAdapter.Fill(this.ring2DataSet.KullaniciListele);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) == kullaniciID)
                {
                    dataGridView1.Rows[i].ReadOnly = true;
                    kullaniciRowIndex = i;
                    break;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView) sender;
            Baglanti baglanti = new Baglanti();
            int id = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[3].Value);
            if (e.ColumnIndex==4 && e.RowIndex >= 0)
            {
                if (e.RowIndex == kullaniciRowIndex)
                {
                    MessageBox.Show("Kendinizi Silemezsiniz");
                }
                else
                {
                    if (MessageBox.Show("Emin misiniz Bu işlem geri alınamaz", "Kullanıcı Silme",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        baglanti.sorguCalistir($"delete from tblKullanicilar where kullaniciID='{id}'");
                        dataGridDoldur();
                    }
                }
            }
            else if(senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                if(e.RowIndex == kullaniciRowIndex)
                {
                    MessageBox.Show("Kendi yetkinizi değiştiremezsiniz ");
                }
                else
                {

                    if(MessageBox.Show("Yetki Değişikliğini Onaylıyor musunuz?", "Yetki Değişikliği",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                            !(bool) senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        baglanti.sorguCalistir(
                            $"update tblKullanicilar set Admin='{senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value}' where kullaniciID='{id}'");
                    }
                    else
                    {
                        dataGridView1.RefreshEdit();
                    }
                }
            }
        }
    }
}
