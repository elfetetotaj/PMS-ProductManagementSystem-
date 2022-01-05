using PMS.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace PMS.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public decimal Price { get; set; }
        public DateTime? DateTime { get; set; }

        public Country Country { get; set; }
        public City City { get; set; }
        public Company Company { get; set; }    

    }
}
