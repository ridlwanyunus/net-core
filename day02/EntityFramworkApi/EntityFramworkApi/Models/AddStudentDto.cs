using EntityFramworkApi.Models.Entities;

namespace EntityFramworkApi.Models
{
    public class AddStudentDto
    {
        public string FirstMidName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? EnrollmentDate { get; set; }

    }
}
