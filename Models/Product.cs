using PMS.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int UniqueId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }
        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }
        public DateTime? DateTime { get; set; }


        [Display(Name ="Country")]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }


        [Display(Name = "City")]
        public int CityId { get; set; }
        [ForeignKey("Cityd")]
        public virtual City City { get; set; }


        [Display(Name = "Company")]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

    }
}
