using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2b_eCommerce.Models
{
    public class SupplierTblViewMdl
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Sector { get; set; }
        public string YearofEstablishment { get; set; }
        public string CompanyType { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Certifications { get; set; }
        public string TurnOver { get; set; }
        public string NumberofEmployees { get; set; }
    }
}