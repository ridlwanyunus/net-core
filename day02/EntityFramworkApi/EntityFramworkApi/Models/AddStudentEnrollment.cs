using EntityFramworkApi.Models.Entities;
using System.Text.Json.Serialization;

namespace EntityFramworkApi.Models
{
    public class AddStudentEnrollment
    {
        public int CourseID { get; set; }
        public Grade? Grade { get; set; }
    }
}
