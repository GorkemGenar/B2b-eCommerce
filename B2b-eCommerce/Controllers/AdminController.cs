using B2b_eCommerce.Identity;
using B2b_eCommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static B2b_eCommerce.Models.UserModel;

namespace B2b_eCommerce.Controllers
{
    public class AdminController : Controller
    {
        IdentityDataContext db = new IdentityDataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<IdentityRole> RoleManager;

        public AdminController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(new IdentityDataContext());
            RoleManager = new RoleManager<IdentityRole>(roleStore);

        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(RoleManager.Roles);
        }

        //List of Suppliers
        public PartialViewResult Suppliers()
        {
            var roleUserIdsQuery = from role in db.Roles
                                   where role.Name == "Supplier"
                                   from user in role.Users
                                   select user.UserId;
            var users = db.Users.Where(u => roleUserIdsQuery.Contains(u.Id)).ToList();

            return PartialView(users);
        }

        //List of Buyers
        public PartialViewResult Buyers()
        {
            var roleUserIdsQuery = from role in db.Roles
                                   where role.Name == "Buyer"
                                   from user in role.Users
                                   select user.UserId;
            var users = db.Users.Where(u => roleUserIdsQuery.Contains(u.Id)).ToList();

            return PartialView(users);
        }

        //List of UploadedReceipts
        public PartialViewResult UploadedUsers()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Receipts/UploadedReceipts"));
            List<ReceiptViewMdl> files = new List<ReceiptViewMdl>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ReceiptViewMdl { FileName = Path.GetFileName(filePath) });
            }
            return PartialView(files);
        }

        //List of ApprovedReceipts
        public PartialViewResult ApprovedUsers()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Receipts/ApprovedReceipts"));
            List<ReceiptViewMdl> files = new List<ReceiptViewMdl>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ReceiptViewMdl { FileName = Path.GetFileName(filePath) });
            }
            return PartialView(files);
        }

        // GET: Admin
        [HttpGet]
        public ActionResult Approving(string fileName)
        {
            //string[] filePaths = Directory.GetFiles(Server.MapPath("~/Receipts/UploadedReceipts"));
            //List<FileModel> files = new List<FileModel>();
            //foreach (string filePath in filePaths)
            //{
            //    files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            //}

            //var files = Directory.GetFiles(Server.MapPath("~/Receipts/UploadedReceipts/" + fileName));

            var file = new ReceiptViewMdl()
            {
                FileName = fileName
            };

            return View(file);
        }

        //Approving process of uploaded receipt and assinging  a user to role
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Approving(ReceiptViewMdl model)
        {
            if (ModelState.IsValid)
            {
                var fileNameSplitted = model.FileName.Split(' ');
                var userName = fileNameSplitted[0];
                var userId = UserManager.Users.Where(i => i.UserName == userName).Select(j => j.Id).FirstOrDefault();
                var roleNameSplitted = model.FileName.Split(' ');
                var roleName = roleNameSplitted[4];
                string sourceFile = Server.MapPath("~/Receipts/UploadedReceipts/") + model.FileName;
                string destinationFile = Server.MapPath("~/Receipts/ApprovedReceipts/") + model.FileName;
                System.IO.File.Move(sourceFile, destinationFile);
                UserManager.AddToRole(userId, roleName);

                return RedirectToAction("/Index");
            }
            else
            {
                return View(ViewData["Message"] = "Any User does not exist for approving");
            }


        }

        public ActionResult Delete(string fileName)
        {
            if (fileName.Count() != 0)
            {
                string sourceFile = Server.MapPath("~/Receipts/UploadedReceipts/") + fileName;
                if (sourceFile != null)
                {
                    System.IO.File.Delete(sourceFile);
                    return RedirectToAction("/Index");
                }
            }
            return View();
        }

        //Role Crud İşlemleri
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole([Required] string name)
        {
            if (ModelState.IsValid)
            {
                var result = RoleManager.Create(new IdentityRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item);
                    }
                }
            }
            return View(name);
        }

        public ActionResult DeleteRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteRole(string id)
        {
            var role = RoleManager.FindById(id);
            if (role != null)
            {
                var result = RoleManager.Delete(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "Role Bulunamadı." });
            }
        }

        [HttpGet]
        public ActionResult EditRole(string id)
        {
            var role = RoleManager.FindById(id);
            var members = new List<ApplicationUser>();
            var nonmembers = new List<ApplicationUser>();

            foreach (var user in UserManager.Users.ToList())
            {
                var list = UserManager.IsInRole(user.Id, role.Name) ? members : nonmembers;
                list.Add(user);
            }

            return View(new RoleEditMdl()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            });
        }

        [HttpPost]
        public ActionResult EditRole(RoleUpdateModel model)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    result = UserManager.AddToRole(userId, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }

                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    result = UserManager.RemoveFromRole(userId, model.RoleName);
                    if (!result.Succeeded)
                    {
                        return View("Error", result.Errors);
                    }
                }
                return RedirectToAction("Index");
            }

            return View("Error", new string[] { "Aranılan rol bulunamadı." });
        }
    }
}