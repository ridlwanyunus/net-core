using Application.Repositories;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features
{
    public class StudentFeature(
        IRepositoriy<Student> _studentRepository, 
        IPlaceholderUserRepository _placeholderUserRepository,
        IUnitOfWork _iUnitOfWork,
        ILogger<StudentFeature> _logger,
        ISieveProcessor _sieveProcessor
        )
    {
        public async Task<List<Student>> GetAll(SieveModel sieveModel)
        {
            var result = _studentRepository.GetAllSieveModel();
            var resultSieve = _sieveProcessor.Apply(sieveModel, result);

            if (result != null)
            {
                _logger.LogWarning("Berhasil");
            }


            return resultSieve.ToList();
        } 

        public async Task<Student?> ImportFromPlaceholder(int idPlaceholder)
        {
            var user = await _placeholderUserRepository.GetById(idPlaceholder);

            if (user == null)
            {
                return null;
            }

            var names = user.Name.Split(' ');

            var student = new Student()
            {
                FirstMidName = string.Join(' ', names.SkipLast(1)),
                LastName = names.Last(),
                EnrollmentDate = DateTime.Now
            };

            await _studentRepository.Add(student);
            await _iUnitOfWork.SaveChanges();

            return student;
        }
    }
}
