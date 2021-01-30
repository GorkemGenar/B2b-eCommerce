using B2b_eCommerce.Identity;
using B2b_eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2b_eCommerce.Controllers
{
    public class SearchController : Controller
    {
        IdentityDataContext db = new IdentityDataContext();

        // GET: Search
        public ActionResult List(string name)
        {
            var BuyingProducts = db.BuyingProducts
                .Where(i => i.ProductName.Contains(name))
                .Select(j => new SearchResultViewMdl
                {
                    BuyingProductName = j.ProductName,
                    BuyingGeneralProductInformation = j.GeneralProductInformation
                }).ToList();

            var SupplyProducts = db.SupplyProducts
                .Where(i => i.ProductName.Contains(name))
                .Select(j => new SearchResultViewMdl
                {
                    SupplyProductName = j.ProductName,
                    SupplyGeneralProductInformation = j.GeneralProductInformation
                }).ToList();

            var Buyers = db.Users
                .Where(i => i.CompanyName.Contains(name) && i.BuyingProducts.Count() > 0)
                .Select(j => new SearchResultViewMdl
                {
                    BuyerCompanyName = j.CompanyName,
                    BuyerCity = j.City,
                    BuyerCountry = j.Country
                }).ToList();

            var Suppliers = db.Users
                .Where(i => i.CompanyName.Contains(name) && i.SupplyProducts.Count() > 0)
                .Select(j => new SearchResultViewMdl
                {
                    SupplierName = j.CompanyName,
                    SupplierCity = j.City,
                    SupplierCountry = j.Country
                }).ToList();

            var union = BuyingProducts.Union(SupplyProducts).Union(Buyers).Union(Suppliers);
            


            return View(union.ToList());
        }
    }
}