using B2b_eCommerce.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B2b_eCommerce.Identity
{
    public class BuyingProducts
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string GeneralProductInformation { get; set; }

        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual Buying Buying { get; set; }
    }
}