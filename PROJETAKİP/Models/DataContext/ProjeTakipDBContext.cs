using PROJETAKİP.Models.Personel;
using PROJETAKİP.Models.ProjeTakip;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PROJETAKİP.Models.DataContext
{
    public class ProjeTakipDBContex : DbContext
    {
        public ProjeTakipDBContex():base("ProjeTakipDB") 
        { 

        }

        public DbSet<PersonelBilgileri> personelBilgileris { get; set; }
        public DbSet<PersonelProjeleri> personelProjeleris { get; set; }

    }
}