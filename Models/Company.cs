using PMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int NrTelefonit { get; set; }
        public long NrFiskal { get; set; }
        public bool Active { get; set; }
        [DataType(DataType.Date)]
        public DateTime? dateTime { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }


        /*[Display(Name = "City")]
        public int CityId { get; set; }
        [ForeignKey("Cityd")]
        public virtual City City { get; set; }*/
        public virtual ICollection<Product> Products { get; set; }
    }
}
