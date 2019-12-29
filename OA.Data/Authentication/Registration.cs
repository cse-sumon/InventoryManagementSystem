using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data
{
   public class Registration
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        public string StoreId { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
