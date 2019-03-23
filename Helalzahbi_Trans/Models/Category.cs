using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helalzahbi_Trans.Models
{
    public class Category
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="نوع الخدمة")]
        public string categName { get; set; }
        public virtual ICollection<Job> jobs { get; set; }
    }
}