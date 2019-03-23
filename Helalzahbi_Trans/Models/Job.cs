using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Helalzahbi_Trans.Models
{
    public class Job
    {
        public int id { get; set; }

        [DisplayName("اسم الخدمة")]
        public string jobtitl { get; set; }
        [DisplayName("وصف الخدمة")]
        public string jobcontent { get; set; }
      
        [DisplayName("صورة الخدمة")]
        public string jobimage { get; set; }
        [DisplayName("نوع الخدمة")]
        public int CategoryId { get; set; }
        public virtual Category category { get; set; }
    }
}