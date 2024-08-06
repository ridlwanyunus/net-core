using AutoMapper;
using EntityFramworkApi.Models;
using EntityFramworkApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EntityFramworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _schoolContext;
        private readonly IMapper _mapper;

        public StudentController(SchoolContext schoolContext, IMapper mapper)
        {
            _schoolContext = schoolContext;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var studentId = _schoolContext.Students.FirstOrDefault(X => X.ID == 1);
            var studentBudi = _schoolContext.Students.Where(x => x.FirstMidName.ToLower().Contains("budi")).ToList();

            var students = _schoolContext.Students.AsQueryable();
            var student10 = students.Take(10);
            var student1120 = students.Skip(10).Take(10);

            var studentsNoTracking = _schoolContext.Students.ToList();

            return Ok(studentsNoTracking);
        }

        [HttpGet("search/query")]
        public IActionResult GetAllStudentByName([FromQuery] String? search)
        {
            var students = _schoolContext.Students.AsQueryable();
            search = search.ToLower();
            students = students.Where(x => x.FirstMidName.ToLower().Contains(search.ToLower()) || x.LastName.ToLower().Contains(search.ToLower()));

            return Ok(new
            {
                Total = students.Count(),
                Data = _mapper.Map<List<StudentDTO>>(students)
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _schoolContext.Students.Where(x => x.ID == id).Include(x => x.Enrollments).ThenInclude(x => x.Course).FirstOrDefault();
            return Ok(student);
        }

        

        [HttpPost]
        public IActionResult PostStudent([FromBody] StudentParamDTO studentDTO)
        {
            var student = _mapper.Map<Student>(studentDTO);
            student.EnrollmentDate = DateTime.Now;

            _schoolContext.Students.Add(student);
            _schoolContext.SaveChanges();
            return Ok(student);
        }

        [HttpPost("{id}/Enrollment")]
        public IActionResult AddEnrollment(int id, [FromBody] AddStudentEnrollment AddStudentEnrollment)
        {

            var student = _schoolContext.Students.Find(id);
            if (student == null)
            {
                BadRequest("Student not found");
            }

            var course = _schoolContext.Courses.Find(AddStudentEnrollment.CourseID);
            if(course == null)
            {
                BadRequest("Course not found");
            }

            var Enrollment = new Enrollment()
            {
                StudentID = student.ID,
                CourseID = AddStudentEnrollment.CourseID,
                Course = course,
                Student = student,
                Grade = AddStudentEnrollment.Grade

            };

            _schoolContext.Enrollments.Add(Enrollment);
            _schoolContext.SaveChanges();
            return Ok(AddStudentEnrollment);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, AddStudentDto addStudentDto)
        {
            var oldStudent = _schoolContext.Students.Find(id);
            if (oldStudent == null)
            {
                BadRequest("Student not found");
            }
            
            oldStudent.FirstMidName = addStudentDto.FirstMidName;
            oldStudent.LastName = addStudentDto.LastName;
            oldStudent.EnrollmentDate = addStudentDto.EnrollmentDate;

            _schoolContext.Students.Update(oldStudent);
            _schoolContext.SaveChanges();
            return Ok(oldStudent);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _schoolContext.Students.Find(id);
            if (student == null)
            {
                BadRequest("Student not found");
            }
            _schoolContext.Entry(student).State = EntityState.Deleted;
            _schoolContext.SaveChanges();
            return Ok(student);
        }
    }
}
