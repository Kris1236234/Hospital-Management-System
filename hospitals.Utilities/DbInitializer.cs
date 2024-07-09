using Hospital.Models;
using Hospital.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitals.Utilities
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DbInitializer(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void ClearDatabase()
        {
            try
            {
                _context.Patients.RemoveRange(_context.Patients);
                _context.Doctors.RemoveRange(_context.Doctors);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (!_roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();
                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "KrisMan",
                    Email = "krystian.stepien4@o2.pl"

                }, 
                
                "KrisMan@123").GetAwaiter().GetResult();
                var Appuser = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "krystian.stepien4@o2.pl");
                if (Appuser != null)
                {
                    _userManager.AddToRoleAsync(Appuser, WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult();
                }
            }
        }

        public void SeedData()
        {
            try
            {
                if (!_context.Roles.Any())
                {
                    
                    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).Wait();
                    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Patient)).Wait();
                    _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Doctor)).Wait();
                }

                if (!_userManager.Users.Any(u => u.UserName == "KrisMan"))
                {
                    
                    var user = new ApplicationUser
                    {
                        UserName = "KrisMan",
                        Email = "krystian.stepien4@o2.pl"
                    };

                    var result = _userManager.CreateAsync(user, "KrisMan@123").Result;

                    if (result.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, WebSiteRoles.WebSite_Admin).Wait();
                    }
                }
            }
            catch (Exception ex)
            {
             
                throw ex;
            }
        }

    }
}
