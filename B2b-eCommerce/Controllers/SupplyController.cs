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
    public class SupplyController : Controller
    {
        //private B2bDbEntities db = new B2bDbEntities();

        // GET: Supply
        public ActionResult Index()
        {
            //var tbl_Supply = db.tbl_Supply.Include(t => t.tbl_Suppliers);
            return View(/*tbl_Supply.ToList()*/);
        }

        // GET: Supply/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_Supply tbl_Supply = db.tbl_Supply.Find(id);
        //    if (tbl_Supply == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_Supply);
        //}

        // GET: Supply/Create
        //public ActionResult Create()
        //{
        //    ViewBag.SupplierId = new SelectList(db.tbl_Suppliers, "Id", "SupplierName");
        //    return View();
        //}

        //// POST: Supply/Create
        //// Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        //// daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Quantity,Size,DeliveryCondition,Specification,PaymentTerms,MinimumOrderQuantity,ShelfLife,Packaging,PreservationMethod,AuthorityPerson,Description,Status,SupplyCapacity,DeliveryTime,SupplierId,ProductOrigin,IsHome,ProductName,GeneralProductInformation")] tbl_Supply tbl_Supply)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.tbl_Supply.Add(tbl_Supply);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.SupplierId = new SelectList(db.tbl_Suppliers, "Id", "SupplierName", tbl_Supply.SupplierId);
        //    return View(tbl_Supply);
        //}

        //// GET: Supply/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_Supply tbl_Supply = db.tbl_Supply.Find(id);
        //    if (tbl_Supply == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.SupplierId = new SelectList(db.tbl_Suppliers, "Id", "SupplierName", tbl_Supply.SupplierId);
        //    return View(tbl_Supply);
        //}

        //// POST: Supply/Edit/5
        //// Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        //// daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Quantity,Size,DeliveryCondition,Specification,PaymentTerms,MinimumOrderQuantity,ShelfLife,Packaging,PreservationMethod,AuthorityPerson,Description,Status,SupplyCapacity,DeliveryTime,SupplierId,ProductOrigin,IsHome,ProductName,GeneralProductInformation")] tbl_Supply tbl_Supply)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tbl_Supply).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.SupplierId = new SelectList(db.tbl_Suppliers, "Id", "SupplierName", tbl_Supply.SupplierId);
        //    return View(tbl_Supply);
        //}

        //// GET: Supply/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_Supply tbl_Supply = db.tbl_Supply.Find(id);
        //    if (tbl_Supply == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_Supply);
        //}

        //// POST: Supply/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tbl_Supply tbl_Supply = db.tbl_Supply.Find(id);
        //    db.tbl_Supply.Remove(tbl_Supply);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
