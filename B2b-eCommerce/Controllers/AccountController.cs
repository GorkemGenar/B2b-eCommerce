using B2b_eCommerce.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static B2b_eCommerce.Models.UserModel;

namespace B2b_eCommerce.Controllers
{
    public class AccountController : Controller
    {
        IdentityDataContext db = new IdentityDataContext();
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        [HttpGet]
        public ActionResult CurrentProfile()
        {
            return View(db.Users.Where(i => i.UserName == User.Identity.Name).FirstOrDefault());
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            var roles = db.Roles.Where(i => i.Name == "Supplier" || i.Name == "Buyer").Select(r => r.Name);

            var viewModel = new RegisterMdl
            {
                RoleList = new SelectList(roles)
            };

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterMdl model)
        {
            if (ModelState.IsValid)
            {
                //Register Operations
                var user = new ApplicationUser();

                user.UserName = model.UserName;
                user.Email = model.Email;
                user.CompanyName = model.CompanyName;
                user.CompanyType = model.CompanyType;
                user.Address = model.Address;
                user.PostCode = model.PostCode;
                user.City = model.City;
                user.Country = model.Country;
                user.Phone = model.PhoneNumber;
                user.Website = model.Website;
                user.Sector = model.Sector;
                user.DistrubitionArea = model.DistrubitionArea;
                user.Turnover = model.Turnover;
                user.NumberofEmployees = model.Employees;
                user.Branches = model.Branches;
                user.Certifications = model.Certifications;
                user.YearofEstablishment = model.YearofEstablishment;
                user.Category = model.Category;
                user.TypeofProduct = model.TypeofProduct;
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    result = await UserManager.AddToRoleAsync(user.Id, model.RoleName);

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            var roles = db.Roles.Where(i => i.Name == "Supplier" || i.Name == "Buyer").Select(r => r.Name);
            model.RoleList = new SelectList(roles);
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginMdl model)
        {
            if (ModelState.IsValid)
            {
                //Login Operations
                var user = UserManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var IdentityClaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;

                    authManager.SignIn(authProperties, IdentityClaims);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "The user is not found.");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetPremium()
        {
            var roles = db.Roles.Where(i => i.Name == "Gold" || i.Name == "Bronze").Select(r => r.Name);

            var viewModel = new RegisterMdl
            {
                RoleList = new SelectList(roles)
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetPremium(HttpPostedFileBase file, RegisterMdl model)
        {
            if (file != null && file.ContentLength > 0)
            {
                var extention = Path.GetExtension(file.FileName);
                if (extention == ".jpg" || extention == ".jpeg" || extention == ".pdf" || extention == ".png")
                {
                    var folder = Server.MapPath("~/Receipts/UploadedReceipts");
                    var filename = Path.ChangeExtension(User.Identity.Name + " - Receipt - " + model.RoleName + " ", extention);
                    var path = Path.Combine(folder, filename);
                    file.SaveAs(path);
                    ViewData["Message"] = "Your receipt has been uploaded.";
                }
                else
                {
                    ViewData["Message"] = "The receipt you are uploading must be only .jpg, .png or .pdf file. ";
                }
            }
            else
            {
                ViewData["Message"] = "Lütfen bir dosya seçiniz.";
            }
            var roles = db.Roles.Where(i => i.Name == "Gold" || i.Name == "Bronze").Select(r => r.Name);
            model.RoleList = new SelectList(roles);

            return View(model);
        }
    }
}