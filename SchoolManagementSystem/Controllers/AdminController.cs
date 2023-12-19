using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using SchoolManagementSystem.Configurations;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository;
using SchoolManagementSystem.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace SchoolManagementSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser>               userManager ;
        private readonly RoleManager<IdentityRole>                  roleManager;
        private readonly IBaseRepository<RegisterComplete>          registerRepository;
        private readonly IBaseRepository<Teacher>                   teacherRepository;
        private readonly IBaseRepository<Student>                   studentRepository;
        private readonly IBaseRepository<Classroom>                 classRoomRepository;
        private readonly IBaseRepository<Level>                     LevelRepository;
        private readonly IBaseRepository<Subject>                   subjectRepository;
        private readonly IBaseRepository<SubjectCategory>           subjectCategoryRepository;
        private readonly IBaseRepository<SubjectClassroomTeacher>   subjectClassroomTeacherRepository;
        


        public AdminController(
            UserManager<ApplicationUser>                _userManager,
            RoleManager<IdentityRole>                   _roleManager,
            IBaseRepository<RegisterComplete>           _registerRepository,
            IBaseRepository<Teacher>                    _teacherRepository,
            IBaseRepository<Student>                    _studentRepository,
            IBaseRepository<Classroom>                  _classRoomRepository,
            IBaseRepository<Level>                      _LevelRepository,
            IBaseRepository<Subject>                    _subjectRepository,
            IBaseRepository<SubjectCategory>            _subjectCategoryRepository,
            IBaseRepository<SubjectClassroomTeacher>    _subjectClassroomTeacherRepository
            )
        {
            registerRepository                          = _registerRepository;
            userManager                                 = _userManager;
            roleManager                                 = _roleManager;
            teacherRepository                           = _teacherRepository;
            studentRepository                           = _studentRepository;
            classRoomRepository                         = _classRoomRepository;
            LevelRepository                             = _LevelRepository;
            subjectRepository                           = _subjectRepository;
            subjectCategoryRepository                   = _subjectCategoryRepository;
            subjectClassroomTeacherRepository           = _subjectClassroomTeacherRepository;
        }



        public async Task<IActionResult> Index()
        {
            /*AdminListPropertiesViewModel adminList = new AdminListPropertiesViewModel
            {

                RegistersCompleted = (await registerRepository.FindAll(i => i.IsDone)).Count(),
                RegistersNotCompleted = (await registerRepository.FindAll(i => !i.IsDone)).Count(),
                RegistersCount = await registerRepository.GetCount(),
            };*/
            return View();
        }

        [Route("/Admin/New-Registers/{done?}")]
        public async Task<IActionResult> NewRegisters(string done = null)
        {
            List<NotCompletelyRegisteredUser> notCompletelies = new List<NotCompletelyRegisteredUser>();
            foreach (var r in await registerRepository.FindAll(i=>i.IsDone == (done!=null)))
            {
                var user = await userManager.FindByIdAsync(r.UserId);
                if (user == null)
                {
                    return NotFound();
                }
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
            ViewBag.Roles = roleManager.Roles.Where(i => !i.Name.Contains("Admin")).ToList();
            var roles = String.Join(", ", await userManager.GetRolesAsync(user));

            var regData = await registerRepository.Find(i=>i.UserId == user.Id);
            if (await teacherRepository.Find(i => i.UserId == user.Id) != null) 
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
                    subjectCategoryId = teacher.subjectCategoryId,
                    RoleName = roles == string.Empty ? "Teacher" : roles

            };
                ViewBag.subjectCategories = subjectCategoryRepository.GetAll();

                return View("AddTeacher", teacherViewModel);
            }
            else if (await studentRepository.Find(i => i.UserId == user.Id) != null)
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
                    LevelId = student.LevelId,
                    RoleName = roles == string.Empty ? "Student" : roles
                };

                ViewBag.Levels = await LevelRepository.GetAllAsync();
                ViewBag.Classrooms = await classRoomRepository.FindAll(i=>i.levelId == student.LevelId);
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
                student.LevelId=studentViewModel.LevelId;

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
                teacher.subjectCategoryId = teachertViewModel.subjectCategoryId;

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

        public async Task<IActionResult> AllSubjects()
        {
            
            return View(await  subjectRepository.GetAllAsync());
        }
        public async Task<IActionResult> AllLevels()
        {

            return View(await LevelRepository.GetAllAsync());
        }
        public async Task<IActionResult> SubjectCategoryList()
        {

            return View(await subjectCategoryRepository.GetAllAsync());
        }
        
        public async Task<IActionResult> AddSubject()
        {
            ViewBag.Levels = await LevelRepository.GetAllAsync();
            ViewBag.subjectCategory = await subjectCategoryRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddSubject(SubjectViewModel subjectViewModel)
        {
            if (ModelState.IsValid)
            {
                Subject subject = new Subject 
                {
                    levelId = subjectViewModel.levelId,
                    subjectCategoryId = subjectViewModel.subjectCategoryId,
                    Name = subjectViewModel.Name,
                    Grade = subjectViewModel.Grade
                };
                var classes = await classRoomRepository.FindAll(i=>i.levelId == subject.levelId);
                foreach (var item in classes)
                {

                    subjectClassroomTeacherRepository.Add(new SubjectClassroomTeacher
                    {
                        ClassroomId = item.Id,
                        SubjectId = subject.Id,
                    });
                    await Task.Run(() => item.Subjects.Add(subject));
                }
                var Students = await studentRepository.FindAll(i=>i.LevelId == subject.levelId);
                foreach (var item in Students)
                {
                    await Task.Run(() => item.Subjects.Add(subject));
                }
                await Task.Run(()=>subjectRepository.Add(subject));
                subjectRepository.Save();
                return RedirectToAction("AddSubject");
            }
            return View(subjectViewModel);
        }
        public async Task<IActionResult> AddSubjectCategory()
        {
            ViewBag.Categories = await subjectCategoryRepository.GetAllAsync();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddSubjectCategory(SubjectCategory subjectCategory)
        {
            if (ModelState.IsValid)
            {
                await Task.Run(() => subjectCategoryRepository.Add(subjectCategory));
                subjectCategoryRepository.Save();
                return RedirectToAction("AddSubjectCategory");
            }
            return View(subjectCategory);
        }

        public IActionResult AddLevel()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddLevel(Level level)
        {
            if (ModelState.IsValid)
            {
                await Task.Run(() => LevelRepository.Add(level));
                LevelRepository.Save();
                return RedirectToAction("AddLevel");
            }
            return View(level);
        }
        public async Task<IActionResult> AllClassRooms()
        {

            return View(await classRoomRepository.GetAllAsync());
        }

        public async Task<IActionResult> AddClassRoom()
        {
            ViewBag.Levels = await LevelRepository.GetAllAsync();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddClassRoom(Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                classroom.Subjects = classroom?.level?.subjects;
                await Task.Run(() => classRoomRepository.Add(classroom));
                classRoomRepository.Save();
                return RedirectToAction("AddClassRoom");
            }
            return View(classroom);
        }
        public IActionResult TeachersList()
        {
            var teacher = teacherRepository.GetAll();
            return View(teacher);
        }
        public async Task<IActionResult> AddTeacherToSubjects(string Id)
        {
            var teacher = await teacherRepository.GetById(Id);
            TeacherSubjectsViewModel teacherSubjectsViewModel = new TeacherSubjectsViewModel();
            teacherSubjectsViewModel.Teacher = teacher;
            teacherSubjectsViewModel.SubjectCategory = teacher.subjectCategory;
            teacherSubjectsViewModel.SubjectCategoryId = teacher.subjectCategoryId;
            teacherSubjectsViewModel.TeacherId = Id;
            ViewBag.ClassroomSubjects = await subjectClassroomTeacherRepository.FindAll(i=>i.subject.subjectCategoryId == teacher.subjectCategoryId);
            return View(teacherSubjectsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacherToSubjects(string Id, TeacherSubjectsViewModel teacherSubjectsViewModel)
        {
            var subjectClassroomTeacher = HttpContext.Request.Form.Where(i=>i.Key == "Subjects").ToList()[0].Value;
            var subsclassteacher = await subjectClassroomTeacherRepository.FindAll(i=>i.TeacherId == Id);
            foreach (var item in subsclassteacher)
            {
                item.TeacherId = null;
                item.Teacher = null;
            }
            foreach (var subject in subjectClassroomTeacher)
            {
                if (subject != null)
                {
                    var subteacher = await subjectClassroomTeacherRepository.GetById(subject);
                    subteacher.TeacherId = Id;
                }
            }
            subjectClassroomTeacherRepository.Save();
            return RedirectToAction(nameof(AddTeacherToSubjects));
        }



        [Route("/Admin/Classrooms/{levelId}")]
        public async Task<IActionResult> getClassrooms(string levelId)
        {
            List<Classroom> classrooms = await classRoomRepository.FindAll(i=>i.levelId == levelId);
            return Json(classrooms);
        }
    }
}
