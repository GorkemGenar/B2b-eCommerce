using B2b_eCommerce.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2b_eCommerce.Models.Identity
{
    public class Buying
    {
        [ForeignKey("BuyingProducts")]
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string GeneralProductInformation { get; set; }
        public string DeliveryCondition { get; set; }
        public string TargetPrice { get; set; }
        public string PaymentTerms { get; set; }
        public string Packaging { get; set; }
        public string AuthorityPerson { get; set; }
        public string Description { get; set; }
        public string ShippingTerms { get; set; }
        public string RequiredQuantity { get; set; }
        public string Status { get; set; }
        public bool IsHome { get; set; }

        //ForeignKey from Product
        public virtual BuyingProducts BuyingProducts { get; set; }

        //ForeignKey from ApplicationUser
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}