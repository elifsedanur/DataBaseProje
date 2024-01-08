using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTicaretProje.Entity
{
    public class CreditCart
    {
        [Key]
        public string UserName { get; set; }
        public string CartNumber { get; set; }
        public string CVC { get; set; }
        public string Date { get; set; }


    }
}