using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personel_Kayıt_Programı
{
    public class Personel
    {
        private int myVar;

        public string AdSoyad { get; set; }

        public string TcNo { get; set; }

        public string Birim { get; set; }

        public bool Cinsiyet { get; set; }

        public DateTime DogumTarihi { get; set; }

        public int Yas { get; private set; }

        public void YasHesapla()
        {
            Yas = DateTime.Now.Year - DogumTarihi.Year;
        }

        public string PersonelBilgileriniGoster()
        {
            return string.Format("Ad Soyad: {0} \nT.C. No: {1} \nBirim: {2} \nCinsiyet: {3} \nDoğum Tarihi: {4} \nYaş: {5}", AdSoyad, TcNo, Birim, (Cinsiyet ? "Erkek" : "Kadın"), DogumTarihi.ToShortDateString(), Yas);
        }
    }
}
