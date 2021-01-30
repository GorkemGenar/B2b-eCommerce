using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B2b_eCommerce.Models
{
    public class CategoryViewMdl
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public int ProdCount { get; set; }
        //public string variable { get; set; }
        //public virtual ICollection<SupplyProducts> SupplyProducts { get; set; }
    }
}