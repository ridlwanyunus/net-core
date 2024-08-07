using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CourseCreateDto
    {
        public int CourseID { get; set; }
        public required string Title { get; set; }
        public int Credits { get; set; }
    }
}
