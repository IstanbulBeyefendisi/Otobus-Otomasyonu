using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtobusOtomasyonu
{
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
        }

        private void musteriGiris_btn_Click(object sender, EventArgs e)
        {
            MusteriForm musteriForm = new MusteriForm();
            musteriForm.Show();
            this.Hide();
        }

        private void yoneticiGiris_btn_Click(object sender, EventArgs e)
        {
            YoneticiForm yoneticiForm = new YoneticiForm();
            yoneticiForm.Show();
            this.Hide();
        }

        private void GirisForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void GirisForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Programı Kapatmak İstediğinizden Emin Misiniz?", "Program Kapatma Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.No) e.Cancel = true;
            else Environment.Exit(0);
        }
    }
}
