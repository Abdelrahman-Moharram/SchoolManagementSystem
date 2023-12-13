using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository;
using SchoolManagementSystem.ViewModels;

namespace SchoolManagementSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IBaseRepository<RegisterComplete> registerRepository;
        private readonly IBaseRepository<Teacher> teacherRepository;
        private readonly IBaseRepository<Student> studentRepository;
        private readonly IBaseRepository<Classroom> classRoomRepository;
        private readonly UserManager<ApplicationUser> userManager ;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(
            IBaseRepository<RegisterComplete> _registerRepository,
            UserManager<ApplicationUser> _userManager,
            RoleManager<IdentityRole> _roleManager,
            IBaseRepository<Teacher> _teacherRepository,
            IBaseRepository<Student> _studentRepository,
            IBaseRepository<Classroom> _classRoomRepository
            )
        {
            registerRepository = _registerRepository;
            userManager = _userManager;
            roleManager = _roleManager;
            teacherRepository = _teacherRepository;
            studentRepository = _studentRepository;
            classRoomRepository = _classRoomRepository;
        }
        public async Task<IActionResult> Index()
        {
            AdminListPropertiesViewModel  adminList = new AdminListPropertiesViewModel
            {
                
                RegistersCount = await registerRepository.GetCount()
            };
            return View(adminList);
        }

        [Route("/Admin/New-Registers")]
        public async Task<IActionResult> NewRegisters()
        {
            List<NotCompletelyRegisteredUser> notCompletelies = new List<NotCompletelyRegisteredUser>();
            foreach (var r in await registerRepository.GetAllAsync())
            {
                var user = await userManager.FindByIdAsync(r.UserId);
                NotCompletelyRegisteredUser notCompletele = new NotCompletelyRegisteredUser
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Image = user.Image,
                    IsDone = r.IsDone,
                    DateTime = r.DateTime,
                    Role = String.Join(", ", await userManager.GetRolesAsync(user))
                };
                notCompletelies.Add(notCompletele);
            }
            return View(notCompletelies);
        }

        [Route("/Admin/Complete-Register/")]
        public async Task<IActionResult> CompleteUserData(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await userManager.FindByIdAsync(id);
            if (await userManager.IsInRoleAsync(user, "Teacher")) 
            {
                var teacher = await teacherRepository.Find(i=>i.UserId == user.Id);
                return View("AddTeacher", teacher);
            }
            else if (await userManager.IsInRoleAsync(user, "Student"))
            {
                var student = await studentRepository.Find(i => i.UserId == user.Id);
                var classrooms = await classRoomRepository.GetAllAsync();

                ViewBag.Classrooms = classrooms;
                return View("AddStudent", student);
            }
            return RedirectToAction("Error", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent(Student student)
        {
            var IsDone = HttpContext.Request.Form["IsDone"] == "true";
            if (ModelState.IsValid)
            {
                studentRepository.update(student);
                var std = await registerRepository.Find(i=>i.UserId == student.UserId);
                std.IsDone = IsDone;
                registerRepository.update(std);
                studentRepository.Save();
            }
            return RedirectToAction ("NewRegisters");
        }
    }
}
