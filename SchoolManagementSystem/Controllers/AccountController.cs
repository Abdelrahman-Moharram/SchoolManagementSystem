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
        private readonly UserManager<ApplicationUser>           userManager;
        private readonly RoleManager<IdentityRole>              roleManager;
        private readonly SignInManager<ApplicationUser>         signInManager;
        private readonly IBaseRepository<Teacher>               teacherRepo;
        private readonly IBaseRepository<Student>               studentRepo;
        private readonly IBaseRepository<Admin>                 AdminRepo;
        private readonly IBaseRepository<RegisterComplete>      registerComplete;
        public AccountController(
            UserManager<ApplicationUser>                        _userManager, 
            RoleManager<IdentityRole>                           _roleManager, 
            SignInManager<ApplicationUser>                      _signInManager,
            IBaseRepository<Teacher>                            _teacherRepo,
            IBaseRepository<Student>                            _studentRepo,
            IBaseRepository<RegisterComplete>                   _registerComplete,
             IBaseRepository<Admin>                             _AdminRepo
        )
        {
            userManager =                                       _userManager;
            roleManager =                                       _roleManager;
            signInManager =                                     _signInManager;
            teacherRepo =                                       _teacherRepo;
            studentRepo =                                       _studentRepo;
            registerComplete =                                  _registerComplete;
            AdminRepo =                                         _AdminRepo;
        }


    public IActionResult Register()
        {
            ViewBag.Roles = roleManager.Roles.Where(i=>i.Name != "Admin").ToList();
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

        public async Task<IActionResult> Logout()
        {
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
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, IFormFile Image)
        {
            ModelState.Remove("Image");
            if (ModelState.IsValid)
            {
                var uploadImage = new FileUpload();
                
                ApplicationUser user =  new  ApplicationUser
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.UserName,
                    PhoneNumber = registerViewModel.PhoneNumber,
                    Image =  uploadImage.UploadUserImage(Image),
                };

                IdentityResult result =  await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded) 
                {
                    if (registerViewModel.Type.ToLower() == "teacher")
                    {
                        Teacher teacher = new Teacher{UserId = user.Id};
                        var Claims = new[] { new Claim("Image", user.Image), new Claim("Role", "Teacher"), new Claim("TeacherId", teacher.Id) };
                        teacherRepo.Add(teacher);
                        await signInManager.SignInWithClaimsAsync(user, isPersistent:false, Claims);
                        await userManager.AddToRoleAsync(user, "Teacher");

                    }
                    else 
                    {
                        Student student = new Student { UserId = user.Id };
                        var Claims = new[] { new Claim("Image", user.Image), new Claim("Role", "Student"), new Claim("StudentId", student.Id) };
                        studentRepo.Add(student);
                        await signInManager.SignInWithClaimsAsync(user, isPersistent: false, Claims);
                        await userManager.AddToRoleAsync(user, "Student");
                    }

                    registerComplete.Add(new RegisterComplete
                    {
                        UserId = user.Id,
                    });
                    registerComplete.Save();

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
            ViewBag.Roles = roleManager.Roles.Where(i=>!i.Name.Contains("Admin")).ToList();

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

                        
                    
                        var result = await userManager.GetRolesAsync(user);
                        List<Claim> claims = new List<Claim>{
                                new Claim("Image",  user.Image != null ? user.Image:""),
                                new Claim("Id",  user.Id != null ? user.Id:""),
                            };

                        if (result.Count == 0)
                        {
                            var teacher     = await teacherRepo.Find(i => i.UserId == user.Id);
                            var student     = await studentRepo.Find(i => i.UserId == user.Id);
                            var Admin       = await AdminRepo.Find(i => i.UserId == user.Id);

                            
                            if (teacher != null)
                            {
                                await userManager.AddToRoleAsync(user, "Teacher");
                                claims.Add(new Claim("Role", "Teacher"));
                                claims.Add(new Claim("TeacherId", teacher.Id));
                                

                            }
                            else if (student != null)
                            {
                                await userManager.AddToRoleAsync(user, "Student");
                                claims.Add(new Claim("Role", "Student"));
                                claims.Add(new Claim("StudentId", student.Id));
                            }
                            else if (Admin != null)
                            {
                                await userManager.AddToRoleAsync(user, "Admin");
                                claims.Add(new Claim("Role", "Admin"));
                                claims.Add(new Claim("AdminId", Admin.Id));
                            }
                            else
                            {
                                return RedirectToAction("AddToRole", "Account");
                            }

                        }
                        else
                        {
                            var stringResult = String.Join(", ", result);
                            claims.Add(new Claim("Role", stringResult));
                            if (stringResult.Contains("Teacher"))
                            {
                                var teacher = await teacherRepo.Find(i => i.UserId == user.Id);
                                claims.Add(new Claim("TeacherId", teacher.Id));
                            }else if (stringResult.Contains("Student"))
                            {
                                var student = await studentRepo.Find(i => i.UserId == user.Id);
                                claims.Add(new Claim("StudentId", student.Id));
                            }
                            else if (stringResult.Contains("Admin"))
                            {
                                var admin = await AdminRepo.Find(i => i.UserId == user.Id);
                                claims.Add(new Claim("AdminId", admin.Id));
                            }
                        }
                        await signInManager.SignInWithClaimsAsync(user, loginViewModel.RemeberMe, claims);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("","Invalid UserName or Email with Password");
            return View(loginViewModel);
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
                    if (teacherRepo.Find(i => i.UserId == user.Id) == null)
                    {
                        teacherRepo.Add(teacher);
                        teacherRepo.Save();
                        await userManager.AddToRoleAsync(user, "Teacher");
                    }

                    Claims.AddRange(new List<Claim> { new Claim("Role", "Teacher"), new Claim("typeId", teacher.Id) });
                    await userManager.AddClaimsAsync(user, Claims);

                }
                else
                {
                    Student student = new Student { Id = user.Id };
                    if (studentRepo.Find(i=>i.UserId == user.Id) == null)
                    {
                        studentRepo.Add(student);
                        studentRepo.Save();
                        await userManager.AddToRoleAsync(user, "Student");
                    }
                    Claims.AddRange(new List<Claim> { new Claim("Role", "Student"), new Claim("typeId", student.Id) });
                    await userManager.AddClaimsAsync(user, Claims);
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
