﻿using Domain.Common;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public enum Grade
    {
        A, B, C, D, E, F
    }
    public class Enrollment : BaseEntity
    {
        public int EnrollmentID {  get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
