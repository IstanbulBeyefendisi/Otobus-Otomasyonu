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
    public partial class PerIslemleriForm : Form
    {
        public PerIslemleriForm()
        {
            InitializeComponent();
        }

        private void PerIslemleriForm_Load(object sender, EventArgs e)
        {
            // ↓↓↓ Personel Kayıt Sayfasındaki Nesnelerin Özelliklerinin Ayarlanması
            string[] sehirler = { "Adana", "Adıyaman", "Afyon", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum ", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya ", "Malatya", "Manisa", "Kahramanmaraş", "Mardin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon  ", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt ", "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük ", "Kilis", "Osmaniye ", "Düzce" };
            string[] birimler = { "İdari Pozisyon", "Çağrı Merkezi", "Muhasebe", "Kaptan Şoför", "Host - Araç İçi Servis Görevlisi" };
            perKayitTc_txt.Mask = "0000000000";
            perKayitAd_txt.Mask = "LL????????????????????";
            perKayitSoyad_txt.Mask = "LL????????????????????";
            perKayitDYer_cbox.DropDownStyle = ComboBoxStyle.DropDownList;
            perKayitDYer_cbox.Items.AddRange(sehirler);
            perKayitDYer_cbox.DropDownHeight = 250;
            perKayitBirim_cbox.DropDownStyle = ComboBoxStyle.DropDownList;
            perKayitBirim_cbox.Items.AddRange(birimler);
            perKayitTel_txt.Mask = "(000) 000 - 0000";
            perKayitDTar_date.Format = DateTimePickerFormat.Short;
            perKayitTc_txt.BeepOnError = true;
            perKayitAd_txt.BeepOnError = true;
            perKayitSoyad_txt.BeepOnError = true;
            perKayitTel_txt.BeepOnError = true;
            /*DateTime suan = DateTime.Now;
            int yil = Convert.ToInt32(suan.ToString("yyyy"));
            int ay = Convert.ToInt32(suan.ToString("MM"));
            int gun = Convert.ToInt32(suan.ToString("dd"));
            perKayitDTar_date.MaxDate = new DateTime(yil - 18, ay, gun);
            */


            // ↓↓↓ Personel Sil Sayfasındaki Nesnelerin Özelliklerin Ayarlanması
            perSil_panel.Visible = false;
            sil_btn.Visible = false;
            perSilTc_txt.Mask = "0000000000";
            toolTip1.SetToolTip(perSilTc_txt, "Bu Alana 11 karakter giriniz!");
            perSilAd_txt.Enabled = false;
            perSilSoyad_txt.Enabled = false;
            perSilDYer_txt.Enabled = false;
            perSilBirim_txt.Enabled = false;
            perSilTel_txt.Enabled = false;
            perSilDTar_txt.Enabled = false;
            perSilCns_txt.Enabled = false;

            // ↓↓↓ Personel Güncelle Sayfasındaki Nesnelerin Özelliklerinin Ayarlanması
            //perGun_panel.Visible = false;
            //guncelle_btn.Visible = false;
            perGun_panel.Visible = false;
            perGunTc_txt.Mask = "0000000000";
            perGunAd_txt.Mask = "LL????????????????????";
            perGunSoyad_txt.Mask = "LL????????????????????";
            perGunDYer_cbox.DropDownStyle = ComboBoxStyle.DropDownList;
            perGunDYer_cbox.Items.AddRange(sehirler);
            perGunDYer_cbox.DropDownHeight = 250;
            perGunBirim_cbox.DropDownStyle = ComboBoxStyle.DropDownList;
            perGunBirim_cbox.Items.AddRange(birimler);
            perGunTel_txt.Mask = "(000) 000 - 0000";
            perGunDTar_date.Format = DateTimePickerFormat.Short;

        }

        public bool PerKayitBoslukKontrol()
        {
            bool bosVarMi = false;

            perKayitTc_lbl.ForeColor = Color.Black;
            perKayitAd_lbl.ForeColor = Color.Black;
            perKayitSoyad_lbl.ForeColor = Color.Black;
            perKayitDYer_lbl.ForeColor = Color.Black;
            perKayitBirim_lbl.ForeColor = Color.Black;
            perKayitTel_lbl.ForeColor = Color.Black;
            perKayitDTar_lbl.ForeColor = Color.Black;
            perKayitCns_lbl.ForeColor = Color.Black;

            #region Nesneleri Kontrol İşlemi

            if (perKayitErkek_rad.Checked == false && perKayitKadin_rad.Checked == false)
            {
                bosVarMi = true;
                perKayitCns_lbl.ForeColor = Color.Red;
            }

            if (perKayitDTar_date.Text == DateTime.Now.ToShortDateString())
            {
                bosVarMi = true;
                perKayitDTar_lbl.ForeColor = Color.Red;
                perKayitDTar_date.Focus();
            }

            if (perKayitTel_txt.Text.Length < perKayitTel_txt.TextLength)
            {
                bosVarMi = true;
                perKayitTel_lbl.ForeColor = Color.Red;
                perKayitTel_txt.Focus();
            }

            // ↓↓↓ Boş bırakılmışsa VEYA Yapılan Seçim "Lütfen Seçim Yapınız" ise Aşağıdaki işlemler gerçekleşecek. Ancak zaten lütfen seçim yapınız varsa 1'den fazla olmasını engelliyoruz.
            if (perKayitBirim_cbox.SelectedItem == null || perKayitBirim_cbox.Text == "Lütfen Seçim Yapınız")
            {
                if (perKayitBirim_cbox.Items.Contains("Lütfen Seçim Yapınız"))
                {
                    perKayitBirim_cbox.Items.Remove("Lütfen Seçim Yapınız");
                }
                bosVarMi = true;
                perKayitBirim_cbox.Items.Add("Lütfen Seçim Yapınız");
                perKayitBirim_cbox.SelectedIndex = perKayitBirim_cbox.Items.Count - 1;
                perKayitBirim_lbl.ForeColor = Color.Red;
                perKayitBirim_cbox.Focus();
            }
            if (perKayitBirim_cbox.SelectedItem != null && perKayitBirim_cbox.Text != "Lütfen Seçim Yapınız")
            {
                perKayitBirim_cbox.Items.Remove("Lütfen Seçim Yapınız");
            }
            //-----------------------------------------------
            // ↓↓↓ Boş bırakılmışsa VEYA Yapılan Seçim "Lütfen Seçim Yapınız" ise Aşağıdaki işlemler gerçekleşecek. Ancak zaten lütfen seçim yapınız varsa 1'den fazla olmasını engelliyoruz.
            if (perKayitDYer_cbox.SelectedItem == null || perKayitDYer_cbox.Text == "Lütfen Seçim Yapınız")
            {
                if (perKayitDYer_cbox.Items.Contains("Lütfen Seçim Yapınız"))
                {
                    perKayitDYer_cbox.Items.Remove("Lütfen Seçim Yapınız");
                }
                bosVarMi = true;
                perKayitDYer_cbox.Items.Add("Lütfen Seçim Yapınız");
                perKayitDYer_cbox.SelectedIndex = perKayitDYer_cbox.Items.Count - 1;
                perKayitDYer_lbl.ForeColor = Color.Red;
                perKayitDYer_cbox.Focus();
            }
            if (perKayitDYer_cbox.SelectedItem != null && perKayitDYer_cbox.Text != "Lütfen Seçim Yapınız")
            {
                perKayitDYer_cbox.Items.Remove("Lütfen Seçim Yapınız");
            }
            //-----------------------------------------------
            if (perKayitSoyad_txt.Text == "" || perKayitSoyad_txt.Text.Length < 2)
            {
                bosVarMi = true;
                perKayitSoyad_lbl.ForeColor = Color.Red;
                perKayitSoyad_txt.Focus();
            }

            if (perKayitAd_txt.Text == "" || perKayitAd_txt.Text.Length < 2)
            {
                bosVarMi = true;
                perKayitAd_lbl.ForeColor = Color.Red;
                perKayitAd_txt.Focus();
            }

            if (perKayitTc_txt.Text == "" || perKayitTc_txt.Text.Length < perKayitTc_txt.TextLength)
            {
                bosVarMi = true;
                perKayitTc_lbl.ForeColor = Color.Red;
                perKayitTc_txt.Focus();
            }

            #endregion

            return bosVarMi;
        }

        public void Ekle()
        {
            try
            {
                YoneticiForm.BaglantiAc();
                string sorgu = "INSERT INTO PERSONEL (tcNo,ad,soyad,dYer,dTar,tel,cns,birim) VALUES (@tcNo,@ad,@soyad,@dYer,@dTar,@tel,@cns,@birim)";
                OleDbCommand ekleKomut = new OleDbCommand(sorgu, YoneticiForm.baglanti);
                ekleKomut.Parameters.AddWithValue("@tcNo", perKayitTc_txt.Text);
                ekleKomut.Parameters.AddWithValue("@ad", perKayitAd_txt.Text);
                ekleKomut.Parameters.AddWithValue("@soyad", perKayitSoyad_txt.Text);
                ekleKomut.Parameters.AddWithValue("@dYer", perKayitDYer_cbox.Text);
                ekleKomut.Parameters.AddWithValue("@dTar", perKayitDTar_date.Value.ToShortDateString());
                ekleKomut.Parameters.AddWithValue("@tel", perKayitTel_txt.Text);
                if (perKayitErkek_rad.Checked)
                    ekleKomut.Parameters.AddWithValue("cns", perKayitErkek_rad.Text);
                else if (perKayitKadin_rad.Checked)
                    ekleKomut.Parameters.AddWithValue("cns", perKayitKadin_rad.Text);
                ekleKomut.Parameters.AddWithValue("birim", perKayitBirim_cbox.Text);

                if (ekleKomut.ExecuteNonQuery() == 1)
                    MessageBox.Show(perKayitTc_txt.Text + " Tc No'lu kayıt eklendi");

                YoneticiForm.baglanti.Close();

            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel Kayıt Hata Penceresi");
                YoneticiForm.baglanti.Close();
            }
        }

        public void Sil()
        {
            try
            {
                YoneticiForm.BaglantiAc();
                string sorgu = "DELETE FROM PERSONEL where tcNo='" + perSilTc_txt.Text + "'";
                OleDbCommand silKomut = new OleDbCommand(sorgu, YoneticiForm.baglanti);
                DialogResult result = MessageBox.Show("Bilgileri verilen kaydı silmek istediğinzden emin misiniz?", "Personel Silme Uyarı Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    silKomut.ExecuteNonQuery();
                    MessageBox.Show(perSilTc_txt.Text + " TC No'lu kayıt silindi");
                    perSilTc_txt.Clear();
                    perSilTc_txt.Focus();
                }
                else
                    MessageBox.Show("Vazgeçtiniz");
                YoneticiForm.baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel Silme Hata Penceresi");
                YoneticiForm.baglanti.Close();
            }
        }

        public void PerSilAra()
        {
            try
            {
                YoneticiForm.BaglantiAc();
                string sorgu = "SELECT * from PERSONEL where tcNo='" + perSilTc_txt.Text + "'";
                OleDbCommand araKomut = new OleDbCommand(sorgu, YoneticiForm.baglanti);
                OleDbDataReader arananKayit = araKomut.ExecuteReader();

                if (arananKayit.Read())
                {
                    perSil_panel.Visible = true;
                    sil_btn.Visible = true;
                    perSilAd_txt.Text = arananKayit["ad"].ToString();
                    perSilSoyad_txt.Text = arananKayit["soyad"].ToString();
                    perSilDYer_txt.Text = arananKayit["dYer"].ToString();
                    perSilBirim_txt.Text = arananKayit["birim"].ToString();
                    perSilTel_txt.Text = arananKayit["tel"].ToString();
                    perSilDTar_txt.Text = arananKayit["dTar"].ToString();
                    perSilCns_txt.Text = arananKayit["cns"].ToString();
                }
                else
                {
                    perSil_panel.Visible = false;
                    sil_btn.Visible = false;
                    perSilAd_txt.Clear();
                    perSilSoyad_txt.Clear();
                    perSilDYer_txt.Clear();
                    perSilBirim_txt.Clear();
                    perSilTel_txt.Clear();
                    perSilDTar_txt.Clear();
                    perSilCns_txt.Clear();
                    MessageBox.Show("Aranan Kayıt Bulunamadı");
                }
                YoneticiForm.baglanti.Close();
            }
            catch (Exception Hata)
            {
                MessageBox.Show(Hata.Message, "Personel Arama Hata Penceresi");
                YoneticiForm.baglanti.Close();
            }
        }

        private void ekle_btn_Click(object sender, EventArgs e)
        {
            if (PerKayitBoslukKontrol() == true) MessageBox.Show("Boş Alanları Doldurunuz", "Boş Alan Uyarısı");
            else
            {
                Ekle();
                perKayitTc_txt.Clear();
                perKayitAd_txt.Clear();
                perKayitSoyad_txt.Clear();
                perKayitDYer_cbox.Text = "";
                perKayitBirim_cbox.Text = "";
                perKayitTel_txt.Clear();
                perKayitDTar_date.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void listele_btn_Click(object sender, EventArgs e)
        {
            PersonelListeleForm personelListeleForm = new PersonelListeleForm();
            personelListeleForm.ShowDialog();
        }

        private void perSilTc_txt_TextChanged(object sender, EventArgs e)
        {
            if (perSilTc_txt.Text == "" || perSilTc_txt.Text.Length < perSilTc_txt.TextLength)
            {
                perSil_panel.Visible = false;
                sil_btn.Visible = false;
                errorProvider1.SetError(perSilTc_txt, "Lütfen Tc No'yu 11 karakter giriniz");
                perSilAd_txt.Clear();
                perSilSoyad_txt.Clear();
                perSilDYer_txt.Clear();
                perSilBirim_txt.Clear();
                perSilTel_txt.Clear();
                perSilDTar_txt.Clear();
                perSilCns_txt.Clear();
                perSilTc_lbl.ForeColor = Color.Red;
                perSilTc_txt.Focus();
            }
            else
            {
                errorProvider1.Clear();
                perSilTc_lbl.ForeColor = Color.Black;
                PerSilAra();
            }

        }

        private void sil_btn_Click(object sender, EventArgs e)
        {
            Sil();
        }


        //Burada Yapmak istediğim, işlemin kontrolünü textchange ile sağlamak. Veritabanında eğer o tc numarası var ise ona göre nesnelerim seçili hale gelicek veya textleri dolacak
        //Eğer öyle bir kayıt yoksa ekranda öyle bir kayıtın olmadığı bilgisi verilecek.
        //Artık kafam almıyo biraz ara vericem (:
        //Yoksa yapardım. Yukarıda benzer şeyleri yaptım
        //Takıldığım nokta şu silme işlemini yaparken getirdiğim bilgiler textboxlara yazılıyordu o bakımdan kolaydı Ancak
        //Veritabanındaki cinsiyet bilgisi kadın mesela ben o zaman kadın radiobuttonunu seçeceğim falan yada
        //Doğum yeri bilgisine göre o item selected olacak takıldığım nokta tamda bu
        private void perGunTc_txt_TextChanged(object sender, EventArgs e)
        {
            if (perGunTc_txt.Text == "" || perGunTc_txt.Text.Length < perGunTc_txt.TextLength)
            {
                perGun_panel.Visible = false;
                errorProvider1.SetError(perGunTc_txt, "Lütfen Tc No'yu 11 karakter giriniz");
                perGunTc_lbl.ForeColor = Color.Red;
            }
            else
            {
                errorProvider1.Clear();
                perGunTc_lbl.ForeColor = Color.Black;
            }

        }
    }
}
