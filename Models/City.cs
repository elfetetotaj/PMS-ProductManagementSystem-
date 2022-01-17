using PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.Data
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }

        public DateTime? CreatedDateTime { get; set; }


        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}
