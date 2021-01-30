using B2b_eCommerce.Identity;
using B2b_eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2b_eCommerce.Controllers
{
    public class CategorysProductController : Controller
    {
        IdentityDataContext db = new IdentityDataContext();

        // GET: CategorysProduct
        public ActionResult Products(string id)
        {
            var query = db.Supplies.Where(i => i.SupplyProducts.CategoryId == id)
                .Select(i => new ProductCategories
                {
                    SupplierName = i.User.CompanyName,
                    ProductName = i.ProductName,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                    Country = i.User.Country,
                    SupplyId = i.Id,
                    ProductId = i.SupplyProducts.Id,
                    UserId = i.User.Id
                }).ToList();

            return View(query);
        }

        public PartialViewResult SupplierTbl(string id)
        {
            var query = from a in db.Users
                        join b in db.SupplyProducts
                        on a.Id equals b.UserId
                        where b.CategoryId == id
                        group a by new { a.CompanyName, a.Sector, a.Country, a.CompanyType } into g
                        select new SupplierTblViewMdl()
                        {
                            SupplierName = g.Key.CompanyName,
                            Sector = g.Key.Sector,
                            Country = g.Key.Country,
                            CompanyType = g.Key.CompanyType
                        };

            return PartialView(query.ToList());
        }
    }
}