using PROJETAKİP.Models.ProjeTakip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROJETAKİP.Models.Personel
{
    public class PersonelBilgileri
    {
        public PersonelBilgileri()
        {
            this.PersonelProjeleris = new HashSet<PersonelProjeleri>();
        }

        [Key]
        public int PersonelBilgiId { get; set; }

        [DisplayName("E-POSTA")] //İSİMLENDİRMELER
        public string Eposta { get; set; }

        [DisplayName("ŞİFRE")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz ")]
        public string Sifre { get; set; }

        [DisplayName("YETKİ")]
        [StringLength(15, ErrorMessage = "Maximum uzunluk 15 karakterden fazla olamaz ")]
        public string Yetki { get; set; }

        [DisplayName("AD SOYAD")]
        [StringLength(50, ErrorMessage = "Maximum uzunluk 50 karakterden fazla olamaz ")]
        public string AdSoyad { get; set; }

        [DisplayName("TC KİMLİK NO")]
        [StringLength(11, ErrorMessage = "Maximum uzunluk 11 karakterden fazla olamaz ")]
        public string TCNO { get; set; }

        [DisplayName("DEPARTMAN")]
        public string Departman { get; set; }

        [DisplayName("GÖREVİ")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz ")]
        public string Gorev { get; set; }

        [DisplayName("AÇIKLAMA")]
        public string PozisyonAciklama { get; set; }

        [DisplayName("TELEFON NUMARASI")]
        [StringLength(15, ErrorMessage = "Maximum uzunluk 15 karakterden fazla olamaz ")]
        public string TelNo { get; set; }

        [DisplayName("ADRES BİLGİLERİ")]
        public string Adres { get; set; }

        [DisplayName("MEDENİ HALİ")]
        [StringLength(10, ErrorMessage = "Maximum uzunluk 10 karakterden fazla olamaz ")]
        public string MedeniHali { get; set; }

        [DisplayName("YAKINLIK BİLGİSİ")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz ")]
        public string YakinBilgisi { get; set; }

        [DisplayName("YAKIN TC NO")]
        [StringLength(11, ErrorMessage = "Maximum uzunluk 11 karakterden fazla olamaz ")]
        public string YakinTC { get; set; }

        [DisplayName("YAKIN AD SOYAD")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz ")]
        public string YakinAdSoyad { get; set; }

        [DisplayName("YAKIN TELEFONU")]
        [StringLength(11, ErrorMessage = "Maximum uzunluk 11 karakterden fazla olamaz ")]
        public string YakinTel { get; set; }

        [DisplayName("DOĞUM TARİHİ")]
        public DateTime DogumTarihi { get; set; }

        [DisplayName("İŞE GİRİŞ TARİHİ")]
        public DateTime? IseGirisTarihi { get; set; }

        [DisplayName("PERSONEL GÖRSELİ")]
        public string PersonelGorseli { get; set; }

        public virtual ICollection<PersonelProjeleri> PersonelProjeleris { get; set; }
    }
}