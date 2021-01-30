using B2b_eCommerce.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace B2b_eCommerce.Identity
{
    public class IdentityDataContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext() : base("IdentityConnection")
        {

        }

        public DbSet<SupplyProducts> SupplyProducts { get; set; }
        public DbSet<BuyingProducts> BuyingProducts { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Buying> Buyings { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}