using B2b_eCommerce.Identity;
using B2b_eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2b_eCommerce.Controllers
{
    public class ProductCategoriesController : Controller
    {
        IdentityDataContext db = new IdentityDataContext();

        // GET: ProductsCategories
        public ActionResult ProductCategories()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult GetProducts()
        {
            var query = db.Supplies.Select(i => new ProductCategories
            {
                SupplierName = i.User.CompanyName,
                ProductName = i.ProductName,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                Country = i.User.Country,
                ProductId = i.SupplyProducts.Id,
                UserId = i.User.Id,
                SupplyId = i.Id
            }).ToList();

            return PartialView(query);
        }

        [HttpPost]
        public PartialViewResult GetProducts(string id)
        {
            var query = db.Categories.Where(i => i.Id == id).FirstOrDefault();
            var query2 = db.Supplies.Where(i => i.CategoryName == query.CategoryName)
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

            return PartialView(query2);
        }

        public PartialViewResult GetCategory()
        {
            var query = db.Categories;

            return PartialView(query.ToList());
        }

        [HttpGet]
        public PartialViewResult SupplierTbl()
        {
            var query = db.Users.Where(i => i.SupplyProducts.Count() > 0)
                .Select(i => new SupplierTblViewMdl()
                {
                    SupplierName = i.CompanyName,
                    Sector = i.Sector,
                    Country = i.Country,
                    CompanyType = i.CompanyType
                });
            return PartialView(query.ToList());
        }

        [HttpPost]
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