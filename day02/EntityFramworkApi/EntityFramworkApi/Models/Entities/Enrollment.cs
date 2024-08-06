﻿using System.Text.Json.Serialization;

namespace EntityFramworkApi.Models.Entities
{
    public enum Grade
    {
        A, B, C, D, E, F
    }
    public class Enrollment
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
