using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace Kapee.Models
{
    public class AppUser : IdentityUser
    {
         public List<Vender> Venders { get; set; }
    }
}
