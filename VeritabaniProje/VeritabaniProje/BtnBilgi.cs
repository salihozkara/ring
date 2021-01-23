using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeritabaniProje
{
    class BtnBilgi
    {
        public int FilmId { get; set; }
        public int KullaniciID { get; set; }
        public Label Label { get; set; }
        public int YorumID { get; set; }
        public RichTextBox RichTextBox { get; set; }
    }
}
