using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace server.Models
{
    [Table("AppUser")]
    public class AppUser : IdentityUser
    {
    }
}