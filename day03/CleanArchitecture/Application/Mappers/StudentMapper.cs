using AutoMapper;
using Domain.DTO;
using Domain.Entities;


namespace Application.Mappers
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
