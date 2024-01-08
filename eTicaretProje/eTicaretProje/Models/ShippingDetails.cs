using eTicaretProje.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTicaretProje.Models
{
    public class ShippingDetails
    {
        public string UserName { get; set; }
        [Required(ErrorMessage ="Lütfen adres tanımını giriniz.")]
        public string AdresBasligi { get; set; }

        [Required(ErrorMessage = "Lütfen bir adres giriniz.")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Lütfen şehir giriniz.")]
        public string Sehir { get; set; }

        [Required(ErrorMessage = "Lütfen Semt giriniz.")]
        public string Semt { get; set; }

        [Required(ErrorMessage = "Lütfen Mahalle giriniz.")]
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }

        
        [Display(Name = "Kart Numarası")]
        public string CartNumber { get; set; }

        public string CVC { get; set; }
        [Display(Name = "Son Kullanma Tarihi")]
        public string Date { get; set; }
        public EnumPaymentMethod PaymentMethod { get; set; }
    }
}