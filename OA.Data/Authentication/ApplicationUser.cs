using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string StoreId { get; set; }
        public string CreatedBy { get; set; }

    }
}
