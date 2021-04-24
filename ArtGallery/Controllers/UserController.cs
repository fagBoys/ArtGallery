using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ArtGallery.Data;
using ArtGallery.Models;
using ArtGallery.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;



namespace ArtGallery.Controllers
{


    public class UserController : Controller
    {
        private IHostingEnvironment _environment;

        //private IRecaptchaService _recaptcha;

        private readonly UserManager<Account> _userManager;

        private readonly SignInManager<Account> _signInManager;

        private readonly ILogger _logger;

        public UserController(IHostingEnvironment environment, /*IRecaptchaService recaptcha,*/ UserManager<Account> userManager, SignInManager<Account> signInManager, ILogger<Account> logger)
        {
            _environment = environment;

            //_recaptcha = recaptcha;

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
                return RedirectToAction(nameof(UserController.Index), "Home");
            }
        }


        [HttpGet]
        public IActionResult Index()
        {

            ArtGalleryContext context = new ArtGalleryContext();
            IEnumerable<Post> posts= context.Post.ToList();

            //EF core end

            return View(posts);
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
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = "Login")
        {
            ViewData["ReturnUrl"] = returnUrl;
            

            if (ModelState.IsValid)
            {
               
                var user = new Account { UserName = model.Username, Email = model.Email, IsUser = true, FirstName = model.FirstName, LastName = model.LastName, IsActive = false, IsAdmin = false, AdminType = false};
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
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl = "Index")
        {

            ViewData["ReturnUrl"] = returnUrl;

            if(ModelState.IsValid)
            {
                ArtGalleryContext context = new ArtGalleryContext();
                var result = await _signInManager.PasswordSignInAsync(model.Username,model.Password,model.RememberMe, lockoutOnFailure: false);
                Account Account = context.Account.Where(A=>A.UserName == model.Username).FirstOrDefault();
                if(result.Succeeded && Account.IsUser && Account.IsActive)
                {
                    
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction(returnUrl);

                }
                if(result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    //return RedirectToLocal(nameof(Lockout));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View();

        }

        [HttpGet]
        public IActionResult AddPost()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddPost(AddPostViewModel Post)
        {

            // input image to database

            ArtGalleryContext Context = new ArtGalleryContext();
            Post NewPost= new Post();
            NewPost.Date = DateTime.Now;
            NewPost.Caption = Post.Caption;
            if (Post.PostImage.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    Post.PostImage.CopyTo(ms);
                    var FileByte = ms.ToArray();
                    NewPost.PostImage = FileByte;
                }
            }
            Context.Post.Add(NewPost);
            Context.SaveChanges();
            return View();
        }

        [HttpGet]
        public IActionResult Post(int id)
        {

            ArtGalleryContext context = new ArtGalleryContext();
            PostViewModel PostVM = new PostViewModel();
            var post = context.Post.Where(A => A.PostId == id).FirstOrDefault();
            var comments = context.Comment.Where(C => C.PostId == id).ToList();
            var images = context.Image.Where(I => I.PostId == id).ToList();
            var tags = context.PostTag.Include(T => T.Tag).Where(PT => PT.PostId == id).ToList();
            var account = context.Account.Where(A => A.Id == post.AccountId).FirstOrDefault();

            PostVM.Post = post;
            PostVM.PostComments = comments;
            PostVM.Images = images;
            PostVM.Tags = tags;
            PostVM.Account = account;

            return View(PostVM);
        }

        public IActionResult AddComment(string Message ,int CommentId, string AccountId, int PostId)
        {
            ArtGalleryContext Context = new ArtGalleryContext();
            Comment comment = new Comment();
            comment.UserId = AccountId;
            comment.PostId = PostId;

            Context.Comment.Add(comment);
            Context.SaveChanges();
            return View();
        }



    }
}
