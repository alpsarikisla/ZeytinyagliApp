using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZeytinyagliWebApp.Models
{
    public class Product
    {
        public Product() { IsActive = true; CreationTime = DateTime.Now; }
        public int ID { get; set; }

        [Display(Name ="Kategori")]
        public int? Category_ID { get; set; }

        [ForeignKey("Category_ID")]
        [Display(Name = "Kategori")]
        public virtual Category Category { get; set; }

        [Display(Name = "Marka")]
        public int? Brand_ID { get; set; }

        [ForeignKey("Brand_ID")]
        [Display(Name = "Marka")]
        public virtual Brand Brand { get; set; }

        [Display(Name="İsim")]
        [Required(ErrorMessage ="Bu alan zorunludur")]
        [StringLength(maximumLength:150, ErrorMessage ="En fazla 150 karakter olmalıdır")]
        public string Name { get; set; }

        [Display(Name = "Özet")]
        [StringLength(maximumLength:250, ErrorMessage ="En fazla 250 karakter olmalıdır")]
        public string Summary { get; set; }

        [AllowHtml]
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name= "Fiyat")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public decimal Price { get; set; }

        [Display(Name = "Stok")]
        public int stock { get; set; }

        [Display(Name = "Ürün Resmi")]
        [StringLength(maximumLength: 75)]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [Display(Name="Liste Resmi")]
        [StringLength(maximumLength:75)]
        [DataType(DataType.ImageUrl)]
        public string ListImage { get; set; }

        [Display(Name = "Ekleme Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationTime { get; set; }

        [Display(Name ="Önerilen")]
        public bool IsRecent { get; set; }

        [Display(Name = "Aktif")]
        public bool IsActive { get; set; }

        [Display(Name = "Silinmiş")]
        public bool IsDeleted { get; set; }
    }
}