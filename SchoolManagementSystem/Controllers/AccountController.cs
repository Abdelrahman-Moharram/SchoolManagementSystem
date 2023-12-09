using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Configurations;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;
using System.Drawing;
using System.Security.Claims;

namespace SchoolManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        /*private readonly RoleManager<IdentityRole> roleManager;*/
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            /*roleManager = _roleManager;*/
            signInManager = _signInManager;
        }


        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [Route("/Account/{username}")]
        public async Task<IActionResult> Profile(string username){
            var user = await userManager.FindByNameAsync(username);
            return View(user);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, IFormFile Image)
        {
            if(ModelState.IsValid)
            {
                var uploadImage = new FileUpload();
                
                ApplicationUser user =  new  ApplicationUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.UserName,
                    PhoneNumber = registerViewModel.PhoneNumber,
                    Image =  uploadImage.UploadUserImage(Image, "img/users/user.webp"),
                };

                IdentityResult result =  await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded) 
                {
                    var Claims = new[] { new Claim("Image", user.Image) };
                    await signInManager.SignInWithClaimsAsync(user, isPersistent:false, Claims);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }
            return View(registerViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            ApplicationUser user;
            if (ModelState.IsValid)
            {
                if(loginViewModel.UserName.IsEmail()){
                    user = await userManager.FindByEmailAsync(loginViewModel.UserName);

                }else{
                    user = await userManager.FindByNameAsync(loginViewModel.UserName);
                }
                if(user != null){
                    List<Claim> claims = new List<Claim>{
                        new Claim("Image", user.Image)
                    };
                    await signInManager.SignInWithClaimsAsync(user, loginViewModel.RemeberMe, claims);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginViewModel);
        }

        public async Task<IActionResult> Logout(){
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> IsUniqueUserName(string UserName)
        {
            return await userManager.FindByNameAsync(UserName) == null ? Json(true) : Json(false); 
        }
        public async Task<IActionResult> IsUniqueEmail(string Email)
        {
            return await userManager.FindByEmailAsync(Email) == null ? Json(true) : Json(false);
        }


    }
}
