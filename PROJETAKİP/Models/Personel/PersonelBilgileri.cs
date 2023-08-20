using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROJETAKİP.Models.Personel
{
    public class PersonelBilgileri
    {
        [Key]
        public int PersonelBilgiId { get; set; }

        public string Eposta { get; set; }

        public string Sifre { get; set; }

        public string Yetki { get; set; }

        public string AdSoyad { get; set; }

        public string TCNO { get; set; }

        public string Departman { get; set; }

        public string Gorev { get; set; }

        public string PozisyonAciklama { get; set; }

        public string TelNo { get; set; }

        public string Adres { get; set; }

        public string MedeniHali { get; set; }

        public string YakinBilgisi { get; set; }

        public string YakinTC { get; set; }

        public string YakinAdSoyad { get; set; }

        public string YakinTel { get; set; }

        public DateTime DogumTarihi { get; set; }

        public DateTime? IseGirisTarihi { get; set; }

    }
}