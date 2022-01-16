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
        [Required]
        public string CountryName { get; set; }
        public int CountryCode { get; set; } 
        [DataType(DataType.Date)]
        public DateTime? CreatedDateTime { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<City> Cities { get; set; }   

    }
}
