using Microsoft.AspNetCore.Authorization;
using Study.Courses.Roles;
using Study.Courses.Students.Dtos;
using Study.Courses.Subjects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Study.Courses.Students
{
    [Authorize]
    public class StudentAppService : ApplicationService, IStudentAppService
    {
        private readonly IdentityUserManager _studentManager;
        private readonly IRepository<Student> _studentRepository;
        public StudentAppService(IdentityUserManager studentManager, IRepository<Student> studentRepository)
        {
            _studentManager = studentManager;
            _studentRepository = studentRepository;

        }

        public async Task<List<SubjectDto>> GetMyEnrolledSubjects()
        {
            if (CurrentUser.IsInRole(CouresesRoles.StudentRole))
            {

                var student = (await _studentRepository.WithDetailsAsync(x=>x.Subjects)).FirstOrDefault(x => x.UserId == CurrentUser.Id);

                var subjects = student.Subjects.Select(x => new SubjectDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    isFirstSemester = x.isFirstSemester,
                    Level = x.Level,
                    Photo = x.Photo,
                    QuizUrl = x.QuizUrl,
                    SubjectMaterialLink = x.SubjectMaterialLink,
                    Title = x.Title
                }).ToList();
                return subjects;
            }
            else
            {
                throw new BusinessException("Sorry you are not Student You must Login as a student First");
            }

        }

        public async Task<List<StudentForListingDto>> GetStudentsForListing(string? studentName)
        {
            var students = (await _studentManager.GetUsersInRoleAsync(CouresesRoles.StudentRole))
                .WhereIf(!String.IsNullOrEmpty(studentName), x => x.Name == studentName)
                .Select(x=>new StudentForListingDto { Id=x.Id,Name=x.Name}).ToList();
            return students;
        }
    }
}
