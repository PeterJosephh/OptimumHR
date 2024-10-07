using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptimumHR.DatabaseContext;
using OptimumHR.Models;
using OptimumHR.ViewModel;
using System.Data;

namespace OptimumHR.Controllers
{
    public class AccountController : Controller
    {
        

        private readonly SignInManager<Account> signInManager;
        private readonly UserManager<Account> userManager;
        private readonly RoleManager<IdentityRole> roleManager; 

        public AccountController(SignInManager<Account> signInManager, UserManager<Account> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName!, model.PasswordHash!, model.RememberMe,false);
                if (result.Succeeded)
                {
                    return RedirectToAction("index","home");
                }
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View(model);


            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            var result = await roleManager.Roles.ToListAsync();
            ViewData["Roles"] = result;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            if (ModelState.IsValid) { 
                Account account = new()
                {
                    UserName = model.Username,
                    PasswordHash = model.Password,
                };
                var result = await userManager.CreateAsync(account,model.Password);
                if (result.Succeeded) {

                    var roleResult = await userManager.AddToRoleAsync(account, model.role);
                    if (roleResult.Succeeded)
                    {
                        await signInManager.SignInAsync(account, false);
                        return RedirectToAction("index", "home");
                    }
                    else
                    {
                        foreach (var error in roleResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);

                        }



                    }

                }
                foreach (var error in result.Errors)
                {

                    ModelState.AddModelError("", error.Description);

                }


            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login");
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return  View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleVM createRole)
        {
            if (ModelState.IsValid) 
            {
                if ( await roleManager.RoleExistsAsync(createRole.role))
                {
                    ModelState.AddModelError("", "Role already exists");
                    return View(createRole);
                }
                var result = await roleManager.CreateAsync(new IdentityRole(createRole.role));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();


            }
            return View(createRole);

        }

    }
}
