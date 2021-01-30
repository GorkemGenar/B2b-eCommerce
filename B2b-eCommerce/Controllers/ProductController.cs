using B2b_eCommerce.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace B2b_eCommerce.Controllers
{
    public class ProductController : Controller
    {
        IdentityDataContext db = new IdentityDataContext();

        public ActionResult Product(string id)
        {
            var query = db.SupplyProducts.Where(i => i.Id == id).FirstOrDefault();

            return View(query);
        }

        public PartialViewResult RelatedProduct(string id)
        {
            var query = db.Supplies.Where(i => i.Id == id).Select(i => i.CategoryName).FirstOrDefault();
            var query2 = db.Supplies.Where(i => i.CategoryName == query && i.Id != id).ToList();

            return PartialView(query2);
        }
    }
}
