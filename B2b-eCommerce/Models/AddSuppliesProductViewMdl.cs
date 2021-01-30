using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2b_eCommerce.Models
{
    public class AddSuppliesProductViewMdl
    {
        [Required(ErrorMessage = "Please select a role")]
        public string CategoryName { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string GeneralProductInformation { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string DeliveryCondition { get; set; }
        [Required]
        public string Specification { get; set; }
        [Required]
        public string PaymentTerms { get; set; }
        [Required]
        public string MinimumOrderQuantity { get; set; }
        [Required]
        public string ShelfLife { get; set; }
        [Required]
        public string Packaging { get; set; }
        [Required]
        public string PreservationMethod { get; set; }
        [Required]
        public string AuthorityPerson { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string SupplyCapacity { get; set; }
        [Required]
        public string DeliveryTime { get; set; }

        public bool IsHome { get; set; }

        public string UserId { get; set; }
    }
}