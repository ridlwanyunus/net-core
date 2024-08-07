using Application.Repositories;
using Domain.Entities;
using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features
{
    public class CourseFeature
    {
        private readonly IRepositoriy<Course> _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CourseFeature(IRepositoriy<Course> courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Course>> GetAllCourse()
        {
            return await _courseRepository.GetAll();
        }

        public async Task<Course> GetCoursById(int Id)
        {
            return await _courseRepository.GetById(Id);
        }

        public async Task<List<Course>> FindByTitle(String name)
        {
            return await _courseRepository.Get(c => c.Title.ToLower().Contains(name.ToLower()));
        }

        public async Task CreateCourse(CourseCreateDto createDto)
        {
            var course = new Course()
            {
                Title = createDto.Title,
                Credits = createDto.Credits
            };

            await _courseRepository.Add(course);
            await _unitOfWork.SaveChanges();
        }

        public async Task<bool> RemoveCourseById(int courseId)
        {
            var course = await _courseRepository.GetById(courseId);

            if (course == null)
            {
                return false;
            }

            await _courseRepository.Remove(course);
            await _unitOfWork.SaveChanges();

            return true;
        }

        public async Task<Course> UpdateCourseById(int courseId, CourseCreateDto courseDto)
        {
            var course = await _courseRepository.GetById(courseId);
            if (course == null)
            {
                return null;
            }

            course.Title = courseDto.Title;
            course.Credits = courseDto.Credits;

            await _courseRepository.Update(course);
            await _unitOfWork.SaveChanges();

            return course;
        }

    }
}
