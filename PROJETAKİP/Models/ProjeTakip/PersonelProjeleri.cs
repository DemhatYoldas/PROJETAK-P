using PROJETAKİP.Models.Personel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROJETAKİP.Models.ProjeTakip
{
    public class PersonelProjeleri
    {
        public PersonelProjeleri() 
        {
            // çoka çok ileşki görmese null değer dönememesi için hassetoluşturuyoruz

            this.PersonelBilgileris = new HashSet<PersonelBilgileri>();
        }

        [Key]
        public int PersonelProjeId { get; set; }

        [DisplayName("PROJE BAŞLIĞI")]
        [StringLength(100, ErrorMessage = "Maximum uzunluk 100 karakterden fazla olamaz ")]
        public string ProjeBaslik { get; set; }

        public string ProjeAciklama { get; set; }

        public DateTime OlusturulmaTarihi { get; set; }

        [DisplayName("ÖNCELİK DURUMU")]
        [StringLength(25, ErrorMessage = "Maximum uzunluk 25 karakterden fazla olamaz ")]
        public string OncelikDurumu { get; set; }

        public int TamamlanmaOrani { get; set; }
        public DateTime? TamamlanmaTarihi { get; set; }
        public bool TamamlanmaDurumu { get; set; }

        public virtual ICollection<PersonelBilgileri> PersonelBilgileris { get; set; }

    }
}