using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository;
using SchoolManagementSystem.Configurations;

namespace SchoolManagementSystem.Controllers
{

    [Authorize]
    public class StudentController : Controller
    {
        private readonly IBaseRepository<Teacher>                       teacherRepository;
        private readonly IBaseRepository<Student>                       studentRepository;
        private readonly IBaseRepository<Classroom>                     classRoomRepository;
        private readonly IBaseRepository<Level>                         LevelRepository;
        private readonly IBaseRepository<Subject>                       subjectRepository;
        private readonly IBaseRepository<SubjectCategory>               subjectCategoryRepository;
        private readonly IBaseRepository<Lecture>                       LectureRepository;
        private readonly IBaseRepository<LecturePost>                   LecturePostRepository; 
        private readonly UserManager<ApplicationUser>                   userManager;
        private readonly IBaseRepository<SubjectClassroomTeacher>       SubjectClassroomTeacherRepository;

        public StudentController(
            IBaseRepository<Teacher>                        _teacherRepository,
            IBaseRepository<Student>                        _studentRepository,
            IBaseRepository<Classroom>                      _classRoomRepository,
            IBaseRepository<Level>                          _LevelRepository,
            IBaseRepository<Subject>                        _subjectRepository,
            IBaseRepository<SubjectCategory>                _subjectCategoryRepository,
            IBaseRepository<Lecture>                        _LectureRepository,
            IBaseRepository<LecturePost>                    _LecturePostRepository,
            UserManager<ApplicationUser>                    _userManager,
            IBaseRepository<SubjectClassroomTeacher>        _SubjectClassroomTeacherRepository

            )
        {
            teacherRepository                               = _teacherRepository;
            studentRepository                               = _studentRepository;
            classRoomRepository                             = _classRoomRepository;
            LevelRepository                                 = _LevelRepository;
            subjectRepository                               = _subjectRepository;
            subjectCategoryRepository                       = _subjectCategoryRepository;
            LectureRepository                               = _LectureRepository;
            LecturePostRepository                           = _LecturePostRepository;
            userManager                                     = _userManager;
            SubjectClassroomTeacherRepository               = _SubjectClassroomTeacherRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.Claims.FirstOrDefault(i => i.Type == "Id"); 
            if ( userId == null )
            {
                return RedirectToAction("Logout", "Account");
            }
            var student = await studentRepository.Find(i=>i.UserId== userId.Value);
            return View(student.Level?.subjects?.ToList());
        }
        public async Task<IActionResult> Subject(string Name)
        {
            var UserName = User?.Identity?.Name;
            var std = await studentRepository.Find(i=>i.User.UserName == UserName);
            var subject = await subjectRepository.Find(i=>i.Name == Name);
            if ( std?.Level.subjects?.Find(i=>i == subject) != null )
            {
                ViewBag.Subject = Name;
                return View(await LectureRepository.FindAll(i=>i.SubjectClassroomTeacher.SubjectId == subject.Id));

            }
            return RedirectToAction(nameof(Index));
        }





        [Route("/{Classroom}/Subjects/{Name}/Add")]
        public async Task<IActionResult> AddLecture(string Name, string Classroom)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if ( user == null)
            {
                return NotFound();
            }
            var subject = await subjectRepository.Find(i => i.Name == Name);
            Teacher teacher = await teacherRepository.Find(i=>i.UserId == user.Id);
            var subClassteacher = await SubjectClassroomTeacherRepository
                .Find(
                    i=>
                    i.classroom.Name== Classroom && 
                    i.subject.Name == Name && 
                    i.TeacherId==teacher.Id
                 );

            Lecture lec = new Lecture
            {
                SubjectClassroomTeacherId = subClassteacher.Id,
                /*TeacherId = teacher.Id,*/
            };
            return PartialView(lec);
        }
        [Route("/Student/Subject/{Name}/Add")]
        [HttpPost]
        public async Task<IActionResult> AddLecture(string Name, Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                LectureRepository.Add(lecture);
                LectureRepository.Save();
                return RedirectToAction(nameof(Subject), "Student", routeValues: Name);
            }
            return View();
        }
        [Route("/Student/Subject/{Name}/Lecture/{LecName}")]
        public async Task<IActionResult> Lecture(string Name, string LecName)
        {
            ViewBag.Lecture = LecName;
            var lecture = await LectureRepository.Find(i => i.Name == LecName);
            var userId = User?.Claims?.FirstOrDefault(i => i.Type == "Id")?.Value;
            if (userId == null || lecture == null)
            {
                return NotFound();
            }
            var posts = await LecturePostRepository.FindAll(i => i.Lecture.Name == LecName);

            return View(posts);
        }

        [Route("/Student/Subject/{Name}/Lecture/{LecName}")]
        [HttpPost]
        public async Task<IActionResult> Lecture(string Name, string LecName, IFormFile File, string Text)
        {
            FileUpload uploadPostFile = new FileUpload();
            var lecture = await LectureRepository.Find(i => i.Name == LecName);
            var userId = User?.Claims?.FirstOrDefault(i => i.Type == "Id")?.Value;
            if (userId == null || lecture == null)
            {
                return NotFound();
            }
            LecturePost post = new LecturePost
            {
                File = uploadPostFile.UploadPostFile(File),
                Text = Text,
                LectureId = lecture.Id,
                UserId = userId,
            };
            LecturePostRepository.Add(post);
            LecturePostRepository.Save();
            return RedirectToAction("Lecture");
                
        }
    }
}
