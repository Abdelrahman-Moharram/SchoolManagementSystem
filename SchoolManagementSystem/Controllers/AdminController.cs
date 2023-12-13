using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Configurations;
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

        [Route("/Admin/New-Registers/{done?}")]
        public async Task<IActionResult> NewRegisters(string done = null)
        {
            List<NotCompletelyRegisteredUser> notCompletelies = new List<NotCompletelyRegisteredUser>();
            foreach (var r in await registerRepository.FindAll(i=>i.IsDone == (done!=null)))
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
                return NotFound(id);
            }
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(user);
            }
            ViewBag.Roles = roleManager.Roles.Where(i => !i.Name.Contains("Admin")).ToList(); ;
            var regData = await registerRepository.Find(i=>i.UserId == user.Id);
            if (await userManager.IsInRoleAsync(user, "Teacher")) 
            {
                var teacher = await teacherRepository.Find(i=>i.UserId == user.Id);
                TeacherViewModel teacherViewModel = new TeacherViewModel
                {
                    UserId = user.Id,
                    TeacherId = teacher.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Image = user.Image,
                    IsDone = regData.IsDone,
                    PhoneNumber = user.PhoneNumber,
                    Salary = teacher.Salary,
                    RoleName = String.Join(", ", await userManager.GetRolesAsync(user))

                };
                return View("AddTeacher", teacherViewModel);
            }
            else if (await userManager.IsInRoleAsync(user, "Student"))
            {
                var student = await studentRepository.Find(i => i.UserId == user.Id);
                var studentViewModel = new StudentUserViewModel
                {
                    UserId = user.Id,
                    StudentId = student.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Image = user.Image,
                    IsDone = regData.IsDone,
                    PhoneNumber = user.PhoneNumber,
                    ClassroomId = student.ClassroomId,
                    RoleName = String.Join(", ", await userManager.GetRolesAsync(user))
                };

                ViewBag.Classrooms = await classRoomRepository.GetAllAsync();
                return View("AddStudent", studentViewModel);
            }
            return RedirectToAction("Error", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent(StudentUserViewModel studentViewModel, IFormFile Image)
        {
            ModelState.Remove("Image");
            if (ModelState.IsValid)
            {
                
                var student = await studentRepository.GetById(studentViewModel.StudentId);
                var user = await userManager.FindByIdAsync(studentViewModel.UserId);
                var registeredStudent = await registerRepository.Find(i=>i.UserId == studentViewModel.UserId);
                var uploadImage = new FileUpload();

                if (user == null)
                {
                    return NotFound();
                }
                // update std data
                student.ClassroomId=studentViewModel.ClassroomId;
                
                // update user data
                user.Email = studentViewModel.Email;
                user.PhoneNumber = studentViewModel.PhoneNumber;
                user.UserName = studentViewModel.UserName;
                user.Image = uploadImage.UploadUserImage(Image, user?.Image);

                // Complete Register Data
                registeredStudent.IsDone = studentViewModel.IsDone == true;
                

                studentRepository.update(student);
                registerRepository.update(registeredStudent);
                await userManager.UpdateAsync(user);
                studentRepository.Save();
            }
            return RedirectToAction ("NewRegisters");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTeacher(TeacherViewModel teachertViewModel, IFormFile Image)
        {
            ModelState.Remove("Image");
            if (ModelState.IsValid)
            {

                var teacher = await teacherRepository.GetById(teachertViewModel.TeacherId);
                var user = await userManager.FindByIdAsync(teachertViewModel.UserId);
                var registeredTeacher = await registerRepository.Find(i => i.UserId == teachertViewModel.UserId);
                var uploadImage = new FileUpload();

                if (user == null)
                {
                    return NotFound();
                }
                // update Teacher data
                teacher.Salary = teachertViewModel.Salary;

                // update user data
                user.Email = teachertViewModel.Email;
                user.PhoneNumber = teachertViewModel.PhoneNumber;
                user.UserName = teachertViewModel.UserName;
                user.Image = uploadImage.UploadUserImage(Image, user?.Image);

                // Complete Register Data
                registeredTeacher.IsDone = teachertViewModel.IsDone == true;


                teacherRepository.update(teacher);
                registerRepository.update(registeredTeacher);
                await userManager.UpdateAsync(user);
                teacherRepository.Save();
            }
            return RedirectToAction("NewRegisters");
        }
    }
}
