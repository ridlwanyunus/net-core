﻿using Domain.Common;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public int ID { get; set; }
        public string FirstMidName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? EnrollmentDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
