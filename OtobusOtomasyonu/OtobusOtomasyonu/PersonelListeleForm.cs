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
    public partial class PersonelListeleForm : Form
    {
        public PersonelListeleForm()
        {
            InitializeComponent();
        }

        public void PersonelListele()
        {
            try
            {
                YoneticiForm.BaglantiAc();
                string sorgu = "SELECT tcNo AS[TC KİMLİK NO], ad AS[AD], soyad AS[SOYAD], dYer AS[DOĞUM YERİ], dTar AS[DOĞUM TARİHİ], tel AS[TELEFON], cns AS[CİNSİYET], birim AS[BİRİM] from PERSONEL";
                OleDbDataAdapter personelListe = new OleDbDataAdapter(sorgu, YoneticiForm.baglanti);
                DataSet dshafiza = new DataSet();
                personelListe.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                YoneticiForm.baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel Listeleme Hata Penceresi");
                YoneticiForm.baglanti.Close();
            }
        }

        private void PersonelListeleForm_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            PersonelListele();
        }
    }
}
