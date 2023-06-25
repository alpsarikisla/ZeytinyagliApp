using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeytinyagliWebApp.Models
{
    public class Manager
    {
        public Manager()
        {
            IsActive = true;IsDeleted = false; IsAdmin = false;
        }

        public int ID { get; set; }

        [Required(ErrorMessage ="Bu alan zorunludur!")]
        [Display(Name="Isim")]
        [StringLength(maximumLength:75, ErrorMessage = "En fazla 75 karakter olmalıdır.")]
        public string Name { get; set; }

        [Display(Name = "Soyisim")]
        [StringLength(maximumLength: 75, ErrorMessage = "En fazla 75 karakter olmalıdır.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur!")]
        [Display(Name= "E-Mail")]
        [StringLength(maximumLength: 200, ErrorMessage = "En fazla 200 karakter olmalıdır.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Bu alan zorunludur!")]
        [Display(Name= "Şifre")]
        [StringLength(maximumLength:20, ErrorMessage = "En fazla 20 karakter olmalıdır.")]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}