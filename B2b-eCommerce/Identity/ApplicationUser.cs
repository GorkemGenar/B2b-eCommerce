using B2b_eCommerce.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2b_eCommerce.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Sector { get; set; }
        public string DistrubitionArea { get; set; }
        public string Turnover { get; set; }
        public string NumberofEmployees { get; set; }
        public string Branches { get; set; }
        public string Certifications { get; set; }
        public string YearofEstablishment { get; set; }
        public string TypeofProduct { get; set; }
        public string Category { get; set; }
        public string CompanyType { get; set; }

        public ICollection<SupplyProducts> SupplyProducts { get; set; }
        public ICollection<BuyingProducts> BuyingProducts { get; set; }
    }
}