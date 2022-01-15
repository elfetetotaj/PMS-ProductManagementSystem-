using PMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PMS.Data
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string ZipCode { get; set; }
        public DateTime? DateTime { get; set; }

        public Country Country { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}
