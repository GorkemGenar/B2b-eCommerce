using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2b_eCommerce.Models
{
    public class CreateBuyingLeadsViewMdl
    {
        [Required(ErrorMessage = "Please select a role")]
        public string CategoryName { get; set; }
        
        public IEnumerable<SelectListItem> CategoryList { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string GeneralProductInformation { get; set; }

        [Required]
        public string DeliveryCondition { get; set; }

        [Required]
        public string TargetPrice { get; set; }

        [Required]
        public string PaymentTerms { get; set; }

        [Required]
        public string Packaging { get; set; }

        [Required]
        public string AuthorityPerson { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ShippingTerms { get; set; }

        [Required]
        public string RequiredQuantity { get; set; }

        [Required]
        public string Status { get; set; }

        public bool IsHome { get; set; }

        public string UserId { get; set; }
        
    }
}