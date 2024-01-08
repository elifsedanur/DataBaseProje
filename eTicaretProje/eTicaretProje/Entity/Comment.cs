using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eTicaretProje.Entity
{
    public class Comment
    {
        [Key]
        public int Id{ get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public double Rating { get; set; }
        public string   UserName {  get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}