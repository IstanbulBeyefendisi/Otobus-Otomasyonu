using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace OtobusOtomasyonu
{
    public partial class YoneticiForm : Form
    {
        public YoneticiForm()
        {
            InitializeComponent();
        }
        // ↓↓↓ Diğer tüm formlardan BaglantiAc() fonksiyonuna ulaşacağız ve veritabanı işlemlerimizi bu sayede yapacağız.
        public static OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDB.12.0;Data Source=" + Application.StartupPath + "\\DB.accdb");
        public static void BaglantiAc()
        {
            try
            {
                baglanti.Open();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Bağlantı Açma Hata Penceresi");
                baglanti.Close();
            }
        }

        public void perIslemleri_menuItem_Click(object sender, EventArgs e)
        {
            PerIslemleriForm perIslemleriForm = new PerIslemleriForm();
            perIslemleriForm.ShowDialog();
        }

        private void YoneticiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Programı Kapatmak İstediğinizden Emin Misiniz?", "Program Kapatma Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No) e.Cancel = true;
            else Environment.Exit(0);
        }
    }
}
