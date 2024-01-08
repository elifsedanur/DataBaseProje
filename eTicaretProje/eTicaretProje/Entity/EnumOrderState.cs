using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTicaretProje.Entity
{
    public enum EnumOrderState
    {
        [Display(Name = "Hazırlanıyor")]
        Waiting,
        [Display(Name = "Kargoya Verildi")]
        InCargo,
        [Display(Name = "Teslim Edildi")]
        Completed
    }
}