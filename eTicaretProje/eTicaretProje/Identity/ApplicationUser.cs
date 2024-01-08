using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTicaretProje.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string Name;
        public string Surname { get; set; }
    }
}