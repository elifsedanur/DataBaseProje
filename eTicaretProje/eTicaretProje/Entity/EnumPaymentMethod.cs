using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTicaretProje.Entity
{
    public enum EnumPaymentMethod
    {
        [Display(Name = "Nakit")]
        Cash,
        [Display(Name = "Kredi Kartı")]
        CreditCart

    }
}