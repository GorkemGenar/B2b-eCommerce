using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using B2b_eCommerce.Identity;
using B2b_eCommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PagedList;
using PagedList.Mvc;

namespace B2b_eCommerce.Controllers
{
    public class HomeController : Controller
    {
        IdentityDataContext db = new IdentityDataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public HomeController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SearchBarMdl model)
        {
            return Redirect("/Search/List/?name=" + model.Value);
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        //CategoryList
        [HttpGet]
        public PartialViewResult GetCategories()
        {
            var query = db.Categories.Select(i => new CategoryViewMdl()
            {
                Id = i.Id,
                CategoryName = i.CategoryName,
                ProdCount = i.SupplyProducts.Count()
            }).OrderByDescending(j => j.ProdCount)/*.Take(10)*/;

            return PartialView(query.ToList());
        }

        //[HttpPost]
        //public PartialViewResult GetCategories(CategoryViewMdl category)
        //{
        //    var query = db.Categories.Select(i => new CategoryViewMdl()
        //    {
        //        Id = i.Id,
        //        CategoryName = i.CategoryName,
        //        ProdCount = i.SupplyProducts.Count()
        //    }).OrderByDescending(j => j.ProdCount);

        //    return PartialView(query.ToList());
        //}

        //Buying Request Table in HomePage
        public PartialViewResult BuyingRequestTable(int? TableSayfaNo)
        {
            int _TablesayfaNo = TableSayfaNo ?? 1;
            var ReqProducts = db.Buyings.Where(i => i.Status == "Active" || i.Status == "Passive").OrderBy(i => i.Status).ToList().ToPagedList(_TablesayfaNo, 4);
            return PartialView(ReqProducts);
        }

        public PartialViewResult SupplierProducts()
        {
            var SuppProducts = db.Supplies.Where(i => i.IsHome == true).ToList();
            return PartialView(SuppProducts);
        }

        public PartialViewResult RequestedProduct()
        {
            var ReqProducts = db.Buyings.Where(i => i.IsHome == true).ToList();

            return PartialView(ReqProducts);
        }

        public PartialViewResult SupplierTbl()
        {
            var query = UserManager.Users.ToList();
            return PartialView(query);
        }
    }
}