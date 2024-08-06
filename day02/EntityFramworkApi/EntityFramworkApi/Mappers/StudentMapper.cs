using AutoMapper;
using EntityFramworkApi.Models;
using EntityFramworkApi.Models.Entities;

namespace EntityFramworkApi.Mappers
{
    public class StudentMapper : Profile
    {
        public StudentMapper() 
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>().ForMember(x => x.FullName, src => src.MapFrom(y => $"{y.FirstMidName} {y.LastName}"));
            CreateMap<StudentParamDTO, Student>();
        }
    }
}
