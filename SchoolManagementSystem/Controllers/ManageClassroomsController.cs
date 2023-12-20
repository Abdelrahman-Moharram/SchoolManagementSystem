using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Configurations;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository;
using System.Collections.Generic;

namespace SchoolManagementSystem.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class ManageClassroomsController : Controller
    {

        private readonly IBaseRepository<LecturePost> LecturePostRepository;
        private readonly IBaseRepository<SubjectClassroomTeacher> SubjectClassroomTeacherRepository;
        private readonly IBaseRepository<Lecture> LectureRepository;
        private readonly IBaseRepository<Subject> subjectRepository;
        private readonly IBaseRepository<Teacher> teacherRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBaseRepository<Classroom> classRoomRepository;
        public ManageClassroomsController(

            IBaseRepository<Subject> _subjectRepository,
            IBaseRepository<Lecture> _LectureRepository,
            IBaseRepository<Teacher> _teacherRepository,
            IBaseRepository<LecturePost> _LecturePostRepository,
            IBaseRepository<SubjectClassroomTeacher> _SubjectClassroomTeacherRepository,
            UserManager<ApplicationUser> _userManager,
            IBaseRepository<Classroom>                  _classRoomRepository
            )
        {
            subjectRepository = _subjectRepository;
            userManager = _userManager;
            LectureRepository = _LectureRepository;
            LecturePostRepository = _LecturePostRepository;
            SubjectClassroomTeacherRepository = _SubjectClassroomTeacherRepository;
            teacherRepository = _teacherRepository;            
            classRoomRepository                         = _classRoomRepository;
        }

        public async Task<List<Classroom>> classroomsAsync(string TeacherId)
        {
            if (TeacherId == null)
            {
                return null;
            }
            var subclassteacher = await SubjectClassroomTeacherRepository.FindAll(i => i.TeacherId == TeacherId);
            var list = subclassteacher.ToList();
            List<Classroom> classes = new List<Classroom>();
            foreach (var item in list)
            {
                classes.Add(item.classroom);
            }
            return classes.ToList();
        }

        



        [Route("/ManageClassrooms")]
        public async Task<IActionResult> Index()
        {
            var TeacherId = User.Claims.FirstOrDefault(i => i.Type == "TeacherId")?.Value;
            
            if (TeacherId != null)
            {
                var Classrooms      = await classroomsAsync(TeacherId);
                ViewBag.Classrooms  = Classrooms;
                return View(Classrooms);
            }
            return BadRequest();
        }

        [Route("/ManageClassrooms/{ClassroomName}")]
        public async Task<IActionResult> Subjects(string ClassroomName)
        {
            var TeacherId = User.Claims.FirstOrDefault(i => i.Type == "TeacherId")?.Value;
            if (TeacherId != null)
            {

                var subclassteacher = await SubjectClassroomTeacherRepository.FindAll(i => i.TeacherId == TeacherId && i.classroom.Name == ClassroomName);
                List<Subject> Subjects = new List<Subject>();
                foreach (var item in subclassteacher.ToList())
                {
                    if (item.subject != null)
                        Subjects.Add(item.subject);
                }
                ViewBag.Classrooms  = await classroomsAsync(TeacherId);
                ViewBag.ClassroomName = ClassroomName;
                
                return View(Subjects.ToList());

            }
            return BadRequest();
        }

        [Route("/ManageClassrooms/{ClassroomName}/{SubjectName}")]
        public async Task<IActionResult> Lectures(string SubjectName, string ClassroomName)
        {
            var TeacherId = User.Claims.FirstOrDefault(i => i.Type == "TeacherId")?.Value;
            if (TeacherId != null)
            {
                
                var subClassteacher = await SubjectClassroomTeacherRepository
                .Find(
                    i =>
                    i.classroom.Name == ClassroomName &&
                    i.subject.Name == SubjectName &&
                    i.TeacherId == TeacherId
                    );
                
                var Lecs = await LectureRepository.FindAll(i => i.SubjectClassroomTeacherId == subClassteacher.Id);
                
                ViewBag.ClassroomName = ClassroomName;
                ViewBag.SubjectName = SubjectName;
                ViewBag.Classrooms = await classroomsAsync(TeacherId);
                return View(Lecs?.ToList());

            }
            return BadRequest();
        }




        // add lecture 
        [Route("/ManageClassrooms/{ClassroomName}/{SubjectName}/Add")]
        public async Task<IActionResult> AddLecture(string SubjectName, string ClassroomName)
        {
            var TeacherId = User.Claims.FirstOrDefault(i => i.Type == "TeacherId")?.Value;
            if (TeacherId != null)
            {
                 var subClassteacher = await SubjectClassroomTeacherRepository
                    .Find(
                        i =>
                        i.classroom.Name == ClassroomName &&
                        i.subject.Name == SubjectName &&
                        i.TeacherId == TeacherId
                        );

                Lecture lec = new Lecture
                {
                    SubjectClassroomTeacherId = subClassteacher.Id,
                };
                return PartialView(lec);
                        

            }
            return BadRequest();
        }

        // add lecture 
        [Route("/ManageClassrooms/{ClassroomName}/{SubjectName}/Add")]
        [HttpPost]
        public async Task<IActionResult> AddLecture(string ClassroomName, string SubjectName, Lecture lecture)
        {
            var TeacherId = User.Claims.FirstOrDefault(i => i.Type == "TeacherId")?.Value;
            if (TeacherId != null)
            {
                if (lecture.SubjectClassroomTeacherId != null)
                {
                    var SubjectClassroomTeacher = await SubjectClassroomTeacherRepository.GetById(lecture.SubjectClassroomTeacherId);
                    LectureRepository.Add(new Lecture
                    {
                        Name  = lecture.Name,
                        SubjectClassroomTeacherId = lecture.SubjectClassroomTeacherId,
                        TeacherId = TeacherId,
                        subjectId = SubjectClassroomTeacher.SubjectId,
                        ClassroomId = SubjectClassroomTeacher.ClassroomId,
                    });
                    LectureRepository.Save();
                    return RedirectToAction("Lectures", new { ClassroomName = ClassroomName , SubjectName = SubjectName });   
                }
            }
            return BadRequest();

        }

        [Route("/ManageClassrooms/{ClassroomName}/{SubjectName}/{LecName}")]
        // return lecture posts
        public async Task<IActionResult> Posts(string ClassroomName, string SubjectName, string LecName)
        {
            var TeacherId = User.Claims.FirstOrDefault(i => i.Type == "TeacherId")?.Value;
            if (TeacherId != null)
            {

                var lecture = await LectureRepository.Find(i => i.Name == LecName);
                if (lecture != null)
                {
                    if (lecture?.SubjectClassroomTeacher?.TeacherId == TeacherId)
                    {
                        var posts = await LecturePostRepository.FindAll(i => i.LectureId == lecture.Id);
                        ViewBag.LecName = LecName;
                        ViewBag.ClassroomName = ClassroomName;
                        ViewBag.SubjectName = SubjectName;
                        ViewBag.Classrooms = await classroomsAsync(TeacherId);
                        return View(posts.OrderByDescending(i=>i.DateTime).ToList());
                    }
                }
            }

                
            
            return BadRequest();


        }

        [Route("/ManageClassrooms/{ClassroomName}/{SubjectName}/{LecName}")]
        [HttpPost]
        public async Task<IActionResult> Posts(string SubjectName, string LecName, IFormFile File, string Text)
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
            };
            LecturePostRepository.Add(post);
            LecturePostRepository.Save();
            return RedirectToAction("Posts");

        }

    }
}
