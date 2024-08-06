using System.Text.Json.Serialization;

namespace EntityFramworkApi.Models.Entities
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstMidName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? EnrollmentDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
