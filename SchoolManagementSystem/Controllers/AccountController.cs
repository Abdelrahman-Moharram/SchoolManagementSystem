using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using NuGet.Packaging;
using SchoolManagementSystem.Configurations;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository;
using SchoolManagementSystem.ViewModels;
using System.Drawing;
using System.Linq;
using System.Security.Claims;

namespace SchoolManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IBaseRepository<Teacher> teacherRepo;
        private readonly IBaseRepository<Student> studentRepo;
        public AccountController(
            UserManager<ApplicationUser> _userManager, 
            RoleManager<IdentityRole> _roleManager, 
            SignInManager<ApplicationUser> _signInManager,
            IBaseRepository<Teacher> _teacherRepo,
            IBaseRepository<Student> _studentRepo
            )
        {
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
            teacherRepo = _teacherRepo;
            studentRepo = _studentRepo;
        }


        public IActionResult Register()
        {
            ViewBag.Roles = roleManager.Roles.Where(i=>!i.Name.Contains("Admin")).ToList();
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [Route("/user/{username}")]
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
                    if (registerViewModel.Type.ToLower() == "teacher")
                    {
                        Teacher teacher = new Teacher{UserId = user.Id};
                        teacherRepo.Add(teacher);
                        teacherRepo.Save();
                        Claims.AddRange(new List<Claim> { new Claim("Role", "Teacher"), new Claim("typeId", teacher.Id)});
                        await signInManager.SignInWithClaimsAsync(user, isPersistent:false, Claims);
                        await userManager.AddToRoleAsync(user, "Teacher");

                    }
                    else 
                    {
                        Student student = new Student { Id = user.Id };
                        studentRepo.Add(student);
                        studentRepo.Save();
                        Claims.AddRange(new List<Claim> { new Claim("Role", "Student"), new Claim("typeId", student.Id) });
                        await signInManager.SignInWithClaimsAsync(user, isPersistent: false, Claims);
                        await userManager.AddToRoleAsync(user, "Student");
                    }
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
                if(user != null)
                {
                    var signresult = await signInManager.CheckPasswordSignInAsync(user, loginViewModel.Password, false);
                    if (signresult.Succeeded)
                    {
                        List<Claim> claims = new List<Claim>{
                            new Claim("Image",  user.Image != null ? user.Image:""),
                            new Claim("Id",  user.Id != null ? user.Id:"")
                        };
                    
                        await signInManager.SignInWithClaimsAsync(user, loginViewModel.RemeberMe, claims);
                        var result = await userManager.GetRolesAsync(user);
                        if (result.Count == 0)
                        {
                            return RedirectToAction("AddToRole", "Account");
                        }
                        return RedirectToAction("Index", "Home");
                    }
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

        public IActionResult AddToRole()
        {
            ViewBag.Roles = roleManager.Roles.Where(i => !i.Name.Contains("Admin")).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddToRoleAsync(string roleType)
        {

            if (roleManager.Roles.FirstOrDefault(i => i.Name == roleType ) != null)
            {
                var userId = User.Claims.FirstOrDefault(i => i.Type == "Id");
                var Claims = new List<Claim>();

                if (userId == null)
                {
                    return RedirectToAction("Logout", "Account");
                }
                var user = await userManager.FindByIdAsync(userId.Value);
                if (roleType.ToLower() == "teacher")
                {
                    Teacher teacher = new Teacher { UserId = userId.Value };
                    teacherRepo.Add(teacher);
                    teacherRepo.Save();
                    await userManager.AddToRoleAsync(user, "Teacher");
                    Claims.AddRange(new List<Claim> { new Claim("Role", "Teacher"), new Claim("typeId", teacher.Id) });
                    await userManager.AddClaimsAsync(user, Claims);

                }
                else
                {
                    Student student = new Student { Id = user.Id };
                    studentRepo.Add(student);
                    studentRepo.Save();
                    await userManager.AddToRoleAsync(user, "Student");
                    Claims.AddRange(new List<Claim> { new Claim("Role", "Student"), new Claim("typeId", student.Id) });
                    await userManager.AddClaimsAsync(user, Claims);
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");   
            }
            else
            {
                ViewBag.Error = roleType+" Not Found, Please select correct role !";
            }
            ViewBag.Roles = roleManager.Roles.Where(i => !i.Name.Contains("Admin")).ToList();
            return View();
        }


    }
}
