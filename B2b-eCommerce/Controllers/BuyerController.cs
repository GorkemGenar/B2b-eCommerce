using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using B2b_eCommerce.Identity;
using B2b_eCommerce.Models;
using B2b_eCommerce.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using PagedList.Mvc;

namespace B2b_eCommerce.Controllers
{
    public class BuyerController : Controller
    {
        IdentityDataContext db = new IdentityDataContext();
        private UserManager<ApplicationUser> UserManager;

        public BuyerController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
        }
        
        //public ActionResult BuyerProfile()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult CreateBuyingLeads()
        {
            var userId = User.Identity.GetUserId();
            var categories = db.Categories.Select(i => i.CategoryName);

            var viewModel = new CreateBuyingLeadsViewMdl
            {
                UserId = userId,
                CategoryList = new SelectList(categories)
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBuyingLeads(CreateBuyingLeadsViewMdl model)
        {
            if (ModelState.IsValid)
            {
                var lead = new Buying();

                lead.Id = Guid.NewGuid().ToString();
                lead.CategoryName = model.CategoryName;
                lead.ProductName = model.ProductName;
                lead.GeneralProductInformation = model.GeneralProductInformation;
                lead.DeliveryCondition = model.DeliveryCondition;
                lead.TargetPrice = model.TargetPrice;
                lead.PaymentTerms = model.PaymentTerms;
                lead.Packaging = model.Packaging;
                lead.AuthorityPerson = model.AuthorityPerson;
                lead.Description = model.Description;
                lead.ShippingTerms = model.ShippingTerms;
                lead.RequiredQuantity = model.RequiredQuantity;
                lead.Status = model.Status;
                lead.IsHome = model.IsHome;
                lead.UserId = model.UserId;

                db.Buyings.Add(lead);
                db.SaveChanges();
                
                return RedirectToAction("CurrentProfile" + "/" + User.Identity.Name, "Account");
            }

            var categories = db.Categories.Select(i => i.CategoryName);
            model.CategoryList = new SelectList(categories);
            return View(model);
        }

        public ActionResult Buyer(string id)
        {
            var query = db.Buyings.Where(i => i.Id == id).FirstOrDefault();

            return View(query);
        }

        public PartialViewResult BuyerRequestTable(string id, int? TableSayfaNo)
        {
            int _TablesayfaNo = TableSayfaNo ?? 1;
            var query = db.Buyings.Where(i => i.Id == id).FirstOrDefault();
            var query2 = db.Buyings.Where(i => i.CategoryName == query.CategoryName && i.Id != id).OrderBy(i => i.Status).ToList().ToPagedList(_TablesayfaNo, 4);
            return PartialView(query2);
        }

        public ActionResult Buyers()
        {
            return View();
        }

        public PartialViewResult GetProduct()
        {
            var query = db.Categories;

            return PartialView(query.ToList());
        }

        [HttpGet]
        public PartialViewResult GettingBuyer()
        {
            var query = db.Buyings.ToList();

            return PartialView(query);
        }


        [HttpPost]
        public PartialViewResult GettingBuyer(string id)
        {
            var query = db.Categories.Where(i => i.Id == id).FirstOrDefault();
            var query2 = db.Buyings.Where(i => i.CategoryName == query.CategoryName);

            return PartialView(query2.ToList());
        }

        public PartialViewResult BuyingRequestsTable(int? TableSayfaNo)
        {
            int _TablesayfaNo = TableSayfaNo ?? 1;
            var ReqProducts = db.Buyings.Where(i => i.Status == "Active" || i.Status == "Passive").OrderBy(i => i.Status).ToList().ToPagedList(_TablesayfaNo, 4);

            return PartialView(ReqProducts);
        }
    }
}
