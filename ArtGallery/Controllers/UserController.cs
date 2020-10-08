using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtGallery.Data;
using ArtGallery.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArtGallery.Controllers
{


    public class UserController : Controller
    {
        private IHostingEnvironment _environment;

        private IRecaptchaService _recaptcha;

        private readonly UserManager<Account> _userManager;

        private readonly SignInManager<Account> _signInManager;

        private readonly ILogger _logger;

        public UserController(IHostingEnvironment environment, IRecaptchaService recaptcha, UserManager<Account> userManager, SignInManager<Account> signInManager, ILogger<Account> logger)
        {
            _environment = environment;

            _recaptcha = recaptcha;

            _userManager = userManager;

            _signInManager = signInManager;

            _logger = logger;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }


        [HttpGet]
        public IActionResult Index()
        {
            //Login action
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(/*اسم مدل ویو*/ model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            

            if (ModelState.IsValid)
            {
               
                var user = new Account { UserName = model.Username, Email = model.Email, IsUser = true, FirstName = model.Firstname, LastName = model.Lastname, IsActive = false, IsAdmin = false, AdminType = false};
                var result = await _userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);


                    _logger.LogInformation("User created new account with password.");
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }
                return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(/*اسم مدل ویو*/ model,string returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;

            if(ModelState.IsValid)
            {
                ArtGalleryContext context = new ArtGalleryContext();
                var result = await _signInManager.PasswordSignInAsync(model.Username,model.Password,model.RememberMe, lockoutOnFailure: false);
                Account Account = await context.Account.Where(A=>A.UserName == model.Username).FirstOrDefaultAsync();
                if(result.Succeeded && Account.IsUser && Account.IsActive)
                {
                    
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction(nameof(/*اسم صفحه که قرار اجرا  بشه*/));

                }
                if(result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToLocal(nameof(Lockout));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View();

        }

    }
}
