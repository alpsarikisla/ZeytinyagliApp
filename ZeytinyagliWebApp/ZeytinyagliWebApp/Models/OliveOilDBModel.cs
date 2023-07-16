using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ZeytinyagliWebApp.Models
{
    public partial class OliveOilDBModel : DbContext
    {
        public OliveOilDBModel()
            : base("name=OliveOilDBModel")
        {

        }

        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
