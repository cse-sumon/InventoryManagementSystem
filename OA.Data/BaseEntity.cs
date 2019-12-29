using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
