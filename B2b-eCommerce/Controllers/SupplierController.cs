using B2b_eCommerce.Identity;
using B2b_eCommerce.Models;
using B2b_eCommerce.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2b_eCommerce.Controllers
{
    public class SupplierController : Controller
    {
        IdentityDataContext db = new IdentityDataContext();

        // GET: Supplier
        public ActionResult Supplier()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddSupplyProduct()
        {
            var userId = User.Identity.GetUserId();
            var categories = db.Categories.Select(i => i.CategoryName);

            var viewModel = new AddSuppliesProductViewMdl
            {
                UserId = userId,
                CategoryList = new SelectList(categories)
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddSupplyProduct(AddSuppliesProductViewMdl model)
        {

            if (ModelState.IsValid)
            {
                var Id = Guid.NewGuid().ToString();
                var supplyproducts = new Supply();

                supplyproducts.Id = Id;
                supplyproducts.CategoryName = model.CategoryName;
                supplyproducts.ProductName = model.ProductName;
                supplyproducts.GeneralProductInformation = model.GeneralProductInformation;
                supplyproducts.Quantity = model.Quantity;
                supplyproducts.Size = model.Size;
                supplyproducts.DeliveryCondition = model.DeliveryCondition;
                supplyproducts.Specification = model.Specification;
                supplyproducts.PaymentTerms = model.PaymentTerms;
                supplyproducts.MinimumOrderQuantity = model.MinimumOrderQuantity;
                supplyproducts.ShelfLife = model.ShelfLife;
                supplyproducts.Packaging = model.Packaging;
                supplyproducts.PreservationMethod = model.PreservationMethod;
                supplyproducts.AuthorityPerson = model.AuthorityPerson;
                supplyproducts.Description = model.Description;
                supplyproducts.Status = model.Status;
                supplyproducts.SupplyCapacity = model.SupplyCapacity;
                supplyproducts.DeliveryTime = model.DeliveryTime;
                supplyproducts.IsHome = model.IsHome;
                supplyproducts.UserId = model.UserId;

                db.Supplies.Add(supplyproducts);
                db.SaveChanges();

                return RedirectToAction("CurrentProfile" + "/" + User.Identity.Name, "Account");
            }
            return View();
        }

        [HttpGet]
        public PartialViewResult GetSupplier()
        {
            var query = db.Supplies.ToList();

            return PartialView(query);
        }

        [HttpPost]
        public PartialViewResult GetSupplier(string id)
        {
            var query = db.Categories.Where(i => i.Id == id).FirstOrDefault();
            var query2 = db.Supplies.Where(i => i.CategoryName == query.CategoryName);

            return PartialView(query2.ToList());

        }

        public PartialViewResult SuppliersTbl()
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
        public PartialViewResult SuppliersTbl(string id)
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

        public PartialViewResult GetCategories()
        {
            var GetCategories = db.Categories;

            return PartialView(GetCategories.ToList());
        }
    }
}