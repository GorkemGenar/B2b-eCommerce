using B2b_eCommerce.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2b_eCommerce.Models.Identity
{
    public class Category
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }

        //public ICollection<CategoriesProducts> CategoriesProducts { get; set; }
        public virtual ICollection<SupplyProducts> SupplyProducts { get; set; }
        public virtual ICollection<BuyingProducts> BuyingProducts { get; set; }
    }
}