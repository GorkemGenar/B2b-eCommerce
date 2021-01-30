using B2b_eCommerce.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2b_eCommerce.Models.Identity
{
    public class Supply
    {
        [ForeignKey("SupplyProducts")]
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string GeneralProductInformation { get; set; }
        public string Quantity { get; set; }
        public string Size { get; set; }
        public string DeliveryCondition { get; set; }
        public string Specification { get; set; }
        public string PaymentTerms { get; set; }
        public string MinimumOrderQuantity { get; set; }
        public string ShelfLife { get; set; }
        public string Packaging { get; set; }
        public string PreservationMethod { get; set; }
        public string AuthorityPerson { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string SupplyCapacity { get; set; }
        public string DeliveryTime { get; set; }
        public bool IsHome { get; set; }

        //ForeignKey from Product
        public virtual SupplyProducts SupplyProducts { get; set; }

        //ForeignKey from ApplicationUser
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}