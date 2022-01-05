using PMS.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace PMS.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int NrTelefonit { get; set; }
        public long NrFiskal { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public bool Active { get; set; }
        public DateTime? dateTime { get; set; }

        public Country Country { get; set; }
        public City Cities { get; set; }
    }
}
