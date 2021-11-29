using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_Kayıt_Programı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Personel[] personeller;
        private void Form1_Load(object sender, EventArgs e)
        {
            personeller = new Personel[0];
            nudKayitNo.Maximum = 0;
            btnGoruntule.Enabled = btnTemizle.Enabled = btnTemizle2.Enabled = false;

            chkErkek.Checked = true;
        }

        private void chkErkek_CheckedChanged_1(object sender, EventArgs e)
        {
            chkKadin.Checked = !chkErkek.Checked;
        }

        private void chkKadin_CheckedChanged_1(object sender, EventArgs e)
        {
            chkErkek.Checked = !chkKadin.Checked;
        }

        private void btnTemizle_Click_1(object sender, EventArgs e)
        {
            Temizle(grpKayit);
            btnTemizle.Enabled = false;
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            if (BosAlanVarMi())
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!");
            }
            else
            {
                Personel personel = new Personel()
                {
                    AdSoyad = txtAdSoyad.Text,
                    Birim = txtBirim.Text,
                    Cinsiyet = chkErkek.Checked,
                    DogumTarihi = dtDogumTarihi.Value,
                    TcNo = txtTcNo.Text,
                };
                personel.YasHesapla();

                Array.Resize(ref personeller, personeller.Length + 1);
                personeller[personeller.Length - 1] = personel;

                lblYas.Text = personel.Yas.ToString();
                lblKayitSayisi.Text = personeller.Length.ToString();
                nudKayitNo.Maximum = personeller.Length;

                MessageBox.Show("Kayıt işlemi başarıyla gerçekleştirildi.");

                btnTemizle.Enabled = btnTemizle2.Enabled = true;
                btnGoruntule.Enabled = true;
            }
        }

        private void btnTemizle2_Click_1(object sender, EventArgs e)
        {
            Temizle(grpGoruntuleme);
            btnTemizle2.Enabled = false;
        }

        private void btnGoruntule_Click_1(object sender, EventArgs e)
        {
            if (nudKayitNo.Value == 0)
                MessageBox.Show("Lütfen 0'dan büyük bir kayıt numarası seçiniz.");
            else
            {
                int kayitNo = (int)nudKayitNo.Value;
                lblListe.Text = personeller[kayitNo - 1].PersonelBilgileriniGoster();

                btnTemizle2.Enabled = true;
            }
        }

        bool BosAlanVarMi()
        {
            foreach (Control item in grpKayit.Controls)
            {
                if (item is TextBox)
                {
                    if (item.Text == "")
                    {
                        return true;
                    }
                }
                else if (item is DateTimePicker)
                {
                    if (((DateTimePicker)item).Value.Date == DateTime.Now.Date)
                        return true;
                }
            }
            return false;
        }
        void Temizle(GroupBox grp)
        {
            foreach (Control item in grp.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                else if (item is DateTimePicker)
                    ((DateTimePicker)item).Value = DateTime.Now;
                else if (item is Label)
                {
                    if (item.Name == "lblYas") item.Text = "?";

                    else if (item.Name == "lblListe") item.Text = "";
                }
                else if (item is NumericUpDown)
                    ((NumericUpDown)item).Value = 0;
            }
        }
        

        
    }
}
