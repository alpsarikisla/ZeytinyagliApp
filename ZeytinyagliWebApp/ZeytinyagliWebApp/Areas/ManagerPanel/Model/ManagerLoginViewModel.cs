using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeytinyagliWebApp.Areas.ManagerPanel.Model
{
    public class ManagerLoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Mail alanı boş bırakılamaz")]
        public string Mail { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        public string password { get; set; }
    }
}