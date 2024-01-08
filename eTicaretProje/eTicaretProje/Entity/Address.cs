using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTicaretProje.Entity
{
    public class Address
    {
        [Key]
        public string UserName { get; set; }
        public string AdresBasligi { get; set; }

        public string Adres { get; set; }

        public string Sehir { get; set; }

        public string Semt { get; set; }

        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
    }
}