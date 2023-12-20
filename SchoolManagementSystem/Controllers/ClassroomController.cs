using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository;
using SchoolManagementSystem.Configurations;

namespace SchoolManagementSystem.Controllers
{

    [Authorize(Roles ="Student")]
    public class ClassroomController : Controller
    {
        private readonly IBaseRepository<Teacher>                       teacherRepository;
        private readonly IBaseRepository<Student>                       studentRepository;
        private readonly IBaseRepository<Classroom>                     classRoomRepository;
        private readonly IBaseRepository<Level>                         LevelRepository;
        private readonly IBaseRepository<Subject>                       subjectRepository;
        private readonly IBaseRepository<SubjectCategory>               subjectCategoryRepository;
        private readonly IBaseRepository<Lecture>                       LectureRepository;
        private readonly IBaseRepository<LecturePost>                   LecturePostRepository; 
        private readonly IBaseRepository<SubjectClassroomTeacher>       SubjectClassroomTeacherRepository;
        private readonly UserManager<ApplicationUser>                   userManager;

        public ClassroomController(
            IBaseRepository<Teacher>                        _teacherRepository,
            IBaseRepository<Student>                        _studentRepository,
            IBaseRepository<Classroom>                      _classRoomRepository,
            IBaseRepository<Level>                          _LevelRepository,
            IBaseRepository<Subject>                        _subjectRepository,
            IBaseRepository<SubjectCategory>                _subjectCategoryRepository,
            IBaseRepository<Lecture>                        _LectureRepository,
            IBaseRepository<LecturePost>                    _LecturePostRepository,
            IBaseRepository<SubjectClassroomTeacher>        _SubjectClassroomTeacherRepository,
            UserManager<ApplicationUser>                    _userManager

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
            SubjectClassroomTeacherRepository               = _SubjectClassroomTeacherRepository;
            userManager                                     = _userManager;
        }

        public async Task<List<Subject>> SubjectsAsync(string StudentId)
        {
            if (StudentId != null)
            {
                var student = await studentRepository.GetById(StudentId);
                return student?.Subjects?.ToList();
            }
            return null;
        }


        // list Subjects in Classroom
        [Route("/Classroom")]

        public async Task<IActionResult> Index()
        {
            var StudentId = User.Claims.FirstOrDefault(i => i.Type == "StudentId")?.Value; 
            if (StudentId != null )
            {
                var student = await studentRepository.GetById(StudentId);
                var Subjects = student?.Classroom?.Subjects?.ToList();
                ViewBag.Classroom = student.Classroom?.Name;
                ViewBag.Subjects = Subjects;
                return View(Subjects);
            }
            return BadRequest();
        }
        
        // return Subject lectures
        [Route("/Classroom/{SubjectName}")]

        public async Task<IActionResult> Subject(string SubjectName)
        {
            var StudentId = User.Claims.FirstOrDefault(i => i.Type == "StudentId")?.Value;
            if (StudentId != null)
            {
                var student = await studentRepository.GetById(StudentId);
                var subject = student?.Subjects?.FirstOrDefault(i => i.Name == SubjectName);
                if (subject != null)
                {
                    ViewBag.SubjectName = SubjectName;
                    ViewBag.Subjects = await SubjectsAsync(StudentId);
                    return View(subject.Lectures?.ToList());
                }
            }
            return BadRequest();
        }





        [Route("/Classroom/{SubjectName}/{LecName}")]
        // return lecture posts
        public async Task<IActionResult> Lecture(string SubjectName, string LecName)
        {
            var StudentId = User.Claims.FirstOrDefault(i => i.Type == "StudentId")?.Value;
            if (StudentId != null)
            {
            var student = await studentRepository.GetById(StudentId);
            var subject = student?.Subjects?.FirstOrDefault(i => i.Name == SubjectName);
                if (subject != null)
                {
                    var Lecture =  subject.Lectures?.FirstOrDefault(i=>i.Name == LecName);
                    if (Lecture != null)
                    {
                        var posts = await LecturePostRepository.FindAll(i => i.LectureId == Lecture.Id);
                        ViewBag.Lecture = LecName;
                        ViewBag.SubjectName = SubjectName;
                        ViewBag.Subjects = await SubjectsAsync(StudentId);

                        return View(posts.OrderBy(i=>i.DateTime).ToList());
                    }

                }
            }
            return BadRequest();

            
        }

        [Route("/Classroom/{SubjectName}/{LecName}")]
        [HttpPost]
        public async Task<IActionResult> Lecture(string SubjectName, string LecName, IFormFile File, string Text)
        {
            FileUpload uploadPostFile = new FileUpload();
            var lecture = await LectureRepository.Find(i => i.Name == LecName);
            var userId = User?.Claims?.FirstOrDefault(i => i.Type == "Id")?.Value;
            if (userId == null || lecture == null)
            {
                return BadRequest();
            }
            LecturePost post = new LecturePost
            {
                File = uploadPostFile.UploadPostFile(File),
                Text = Text,
                LectureId = lecture.Id,
                UserId = userId,
                DateTime = DateTime.Now
            };
            LecturePostRepository.Add(post);
            LecturePostRepository.Save();
            return RedirectToAction("Lecture");

        }



    }
}
