using PMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PMS.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int CountryCode { get; set; }
        public string Area { get; set; }    
        public DateTime? DateTime { get; set; }

        public ICollection<Company> Companies { get; set; }
        public ICollection<City> Cities { get; set; }   

    }
}
