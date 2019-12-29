using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class StoreViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string RegistrationNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}
