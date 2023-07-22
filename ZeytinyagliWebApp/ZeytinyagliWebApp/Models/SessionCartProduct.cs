using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZeytinyagliWebApp.Models
{
    public class SessionCartProduct
    {
        public int Product_ID { get; set; }

        public string ProductName { get; set; }

        public string ThumbImage { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

    }
}