using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Repository;

namespace SchoolManagementSystem.Controllers
{
    [Authorize(Roles ="Student,Admin")]

    public class StudentController : Controller
    {
        private readonly IBaseRepository<Teacher>           teacherRepository;
        private readonly IBaseRepository<Student>           studentRepository;
        private readonly IBaseRepository<Classroom>         classRoomRepository;
        private readonly IBaseRepository<Level>             LevelRepository;
        private readonly IBaseRepository<Subject>           subjectRepository;
        private readonly IBaseRepository<SubjectCategory>   subjectCategoryRepository;
        public StudentController(
            IBaseRepository<Teacher>                        _teacherRepository,
            IBaseRepository<Student>                        _studentRepository,
            IBaseRepository<Classroom>                      _classRoomRepository,
            IBaseRepository<Level>                          _LevelRepository,
            IBaseRepository<Subject>                        _subjectRepository,
            IBaseRepository<SubjectCategory>                _subjectCategoryRepository
            )
        {
            teacherRepository                               = _teacherRepository;
            studentRepository                               = _studentRepository;
            classRoomRepository                             = _classRoomRepository;
            LevelRepository                                 = _LevelRepository;
            subjectRepository                               = _subjectRepository;
            subjectCategoryRepository                       = _subjectCategoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.Claims.FirstOrDefault(i => i.Type == "Id"); 
            if ( userId == null )
            {
                return RedirectToAction("Logout", "Account");
            }
            var student = await studentRepository.Find(i=>i.UserId== userId.Value);
            return View(student?.Subjects?.ToList());
        }

        public IActionResult Subject(string Id)
        {

            return View();
        }
    }
}
