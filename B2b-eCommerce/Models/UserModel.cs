using B2b_eCommerce.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B2b_eCommerce.Models
{
    public class UserModel
    {
        public class LoginMdl
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }

        public class RegisterMdl
        {
            //For Account Operations
            [Required]
            public string UserName { get; set; }

            [Required]
            [EmailAddress(ErrorMessage = "Please enter your mail address in correct form.")]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }

            [Required]
            public string RePassword { get; set; }

            [Required(ErrorMessage = "Please select a role")]
            public string RoleName { get; set; }

            public IEnumerable<SelectListItem> RoleList { get; set; }

            //For Bussiness Operations
            [Required]
            public string CompanyName { get; set; }

            [Required]
            public string CompanyType { get; set; }

            [Required]
            public string Address { get; set; }

            [Required]
            public string PostCode { get; set; }

            [Required]
            public string City { get; set; }

            [Required]
            public string Country { get; set; }

            [Required]
            [Phone]
            public string PhoneNumber { get; set; }

            public string Website { get; set; }

            [Required]
            public string Sector { get; set; }

            public string DistrubitionArea { get; set; }

            [Required]
            public string Turnover { get; set; }

            [Required]
            public string Employees { get; set; }

            [Required]
            public string Branches { get; set; }

            public string Certifications { get; set; }

            [Required]
            public string YearofEstablishment { get; set; }

            [Required]
            public string Category { get; set; }

            [Required]
            public string TypeofProduct { get; set; }
        }

        public class RoleEditMdl
        {
            public IdentityRole Role { get; set; }
            public IEnumerable<ApplicationUser> Members { get; set; }
            public IEnumerable<ApplicationUser> NonMembers { get; set; }
        }

        public class RoleUpdateModel
        {
            [Required]
            public string RoleName { get; set; }
            public string RoleId { get; set; }
            public string[] IdsToAdd { get; set; }
            public string[] IdsToDelete { get; set; }
        }
    }
}