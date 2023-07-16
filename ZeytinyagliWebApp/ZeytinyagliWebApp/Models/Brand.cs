using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ZeytinyagliWebApp.Models
{
    public class Brand
    {
        public Brand() { IsActive = true; }

        public int ID { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [StringLength(maximumLength: 75, ErrorMessage = "Bu alan alan en fazla 75 karakter olmalıdır")]
        [Display(Name = "İsim")]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }

        [Display(Name = "Silindi")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}