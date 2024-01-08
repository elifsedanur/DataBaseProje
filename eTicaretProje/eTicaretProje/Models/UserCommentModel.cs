using eTicaretProje.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace eTicaretProje.Models
{
    public class UserCommentModel
    {
        public int ProductId { get; set; }

        [DisplayName("Yorumunuzu Giriniz")]
        [Required]
        public string Content { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        

    }
}