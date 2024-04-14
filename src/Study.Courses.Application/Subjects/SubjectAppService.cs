using Microsoft.AspNetCore.Authorization;
using Study.Courses.Students;
using Study.Courses.Subjects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Study.Courses.Subjects
{
    [Authorize]
    public class SubjectAppService : ApplicationService, ISubjectAppService
    {
        private readonly IRepository<Subject, Guid> _subjectRepository;
        private readonly IdentityUserManager _userManager;
        private readonly IRepository<Student, Guid> _studentRepository;

        public SubjectAppService(IRepository<Student, Guid> studentRepository, IdentityUserManager userManager, IRepository<Subject, Guid> subjectRepository)
        {
            _userManager = userManager;
            _subjectRepository = subjectRepository;
            _studentRepository = studentRepository;
        }

        public async Task<SubjectDto> CreateAsync(CreateSubjectDto input)
        {

            var instructor = await _userManager.GetByIdAsync(input.InstructorId);
            var allstudents = await _studentRepository.GetQueryableAsync();
            List<Student> courseStudents = new List<Student>();
            foreach (var student in allstudents)
            {
                if (input.Students.Contains(student.UserId))
                {
                    courseStudents.Add(student);
                }
            }
            Subject subject = new Subject()
            {
                SubjectMaterialLink = input.SubjectMaterialLink,
                isFirstSemester = input.isFirstSemester,
                Description = input.Description,
                Photo = String.IsNullOrEmpty(input.Photo) ? " " : input.Photo,
                Instructor = instructor,
                QuizUrl = input.QuizUrl,
                Level = input.Level,
                Title = input.Title,
                Students = courseStudents,
            };
            await _subjectRepository.InsertAsync(subject);
            return new SubjectDto()
            {
                Description = subject.Description,
                Title = subject.Title,
                InstructorId = subject.Instructor.Id,
                isFirstSemester = subject.isFirstSemester,
                Level = subject.Level,
                Photo = subject.Photo,
                QuizUrl = subject.QuizUrl,
                SubjectMaterialLink = subject.SubjectMaterialLink,
            };
        }

        public async Task DeleteAsync(Guid subjectId)
        {
            await _subjectRepository.HardDeleteAsync(x => x.Id == subjectId);
        }


        public async Task<List<SubjectDto>> GetAllAsync(int skipCount, int maxResultCount, string? subjectTitle)
        {
            var subjects = (await _subjectRepository.WithDetailsAsync(x => x.Students, y => y.Instructor)).WhereIf(!String.IsNullOrWhiteSpace(subjectTitle),x=>x.Title==subjectTitle).Select(x=> new SubjectDto
            {
                Id = x.Id,
                Description=x.Description,
                Level=x.Level, Title=x.Title,
                InstructorName = x.Instructor.Name,
                isFirstSemester=x.isFirstSemester,
                Photo=x.Photo,
                QuizUrl=x.QuizUrl,
                SubjectMaterialLink = x.SubjectMaterialLink,
                InstructorId =x.Instructor.Id,
               
            }).Skip(skipCount).Take(maxResultCount).ToList();
            
            return subjects;
        }

        public async Task<DetailedSubjectDto> GetDetailedSubjectAsync(Guid subjectId)
        {

            var subject= (await _subjectRepository.WithDetailsAsync(x => x.Students, y => y.Instructor)).FirstOrDefault(x => x.Id == subjectId);
            var students=subject.Students.Select(x=> x.Name).ToList();

            var result = new DetailedSubjectDto()
            {
                Id = subject.Id,
                Description = subject.Description,
                Level = subject.Level,
                Title = subject.Title,
                InstructorName = subject.Instructor.Name,
                isFirstSemester = subject.isFirstSemester,
                Photo = subject.Photo,
                QuizUrl = subject.QuizUrl,
                SubjectMaterialLink = subject.SubjectMaterialLink,
                InstructorId = subject.Instructor.Id,
                Students = students
            };
            return result;
        }

        public async Task<CreateSubjectDto> UpdateAsync(Guid subjectId, CreateSubjectDto input)
        {
            var tempSubject = await _subjectRepository.GetAsync(x => x.Id == subjectId);

            await _subjectRepository.HardDeleteAsync(x => x.Id == subjectId);

            var instructor = await _userManager.GetByIdAsync(input.InstructorId);
            var allstudents = await _studentRepository.GetQueryableAsync();

            List<Student> courseStudents = new List<Student>();
            foreach (var student in allstudents)
            {
                if (input.Students.Contains(student.UserId))
                {
                    courseStudents.Add(student);
                }
            }
            Subject subject = new Subject()
            {
            SubjectMaterialLink = input.SubjectMaterialLink,
            isFirstSemester = input.isFirstSemester,
            Description = input.Description,
            Photo = String.IsNullOrEmpty(input.Photo) ? " " : input.Photo,
            Instructor = instructor,
            QuizUrl = input.QuizUrl,
            Level = input.Level,
            Title = input.Title,
            Students = courseStudents,
        };
            
            
            await _subjectRepository.InsertAsync(subject);

            return input;
        }


    }
}
