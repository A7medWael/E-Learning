
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Study.Courses.Instructors.Dtos;
using Study.Courses.Roles;
using Study.Courses.Subjects;
using Study.Courses.Subjects.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Study.Courses.Instructors
{
    [Authorize]
    public class InstructorAppService : ApplicationService, IInstructorAppService
    {

        private readonly IdentityUserManager _identityUserManager;
        private readonly IRepository<Volo.Abp.Identity.IdentityUser, Guid> _userRepository;
        private readonly IRepository<Subject, Guid> _subjectRepository;


        public InstructorAppService(IRepository<Subject, Guid> subjectRepository,IdentityUserManager userManager, IRepository<Volo.Abp.Identity.IdentityUser, Guid> userRepository)
        {
            _identityUserManager = userManager;
            _userRepository = userRepository;
            _subjectRepository = subjectRepository;

        }

        public async Task<InstructorDto> CreateInstructorAsync(CreateInstructorDto input)
        {
            var instructor=new Volo.Abp.Identity.IdentityUser(input.Id, input.UserName, input.Email);
            instructor.Name = input.InstructorName;
            (await  _identityUserManager.CreateAsync(instructor, input.Password, true)).CheckErrors();
            await _identityUserManager.AddToRoleAsync(instructor, CouresesRoles.InstructorRole);

            return new InstructorDto()
            {
                Id = input.Id,
                Email = input.Email,
                InstructorName = input.InstructorName,
                PhoneNumber = input.PhoneNumber,
                UserName=input.UserName,
            };

        }

        public async Task DeleteInstructorAsync(Guid id)
        {
            var instructor=await _userRepository.GetAsync(x=>x.Id == id);
            if(instructor != null)
            {
                await _identityUserManager.DeleteAsync(instructor);
            }
        }

        public async Task<List<InstructorDto>> GetAllInstructorsAsync(int skipCount, int maxResultCount, string? instructorName)
        {
            var instructors = (await _identityUserManager.GetUsersInRoleAsync(CouresesRoles.InstructorRole))
                .WhereIf(!String.IsNullOrEmpty(instructorName), x => x.Name == instructorName)
                .Select(x => new InstructorDto
                {
                    Id = x.Id,
                    Email = x.Email,
                    InstructorName = x.Name,
                    PhoneNumber = x.PhoneNumber,
                    UserName = x.UserName

                }).Skip(skipCount).Take(maxResultCount).ToList();
            return instructors;
        }

        public async Task<List<InstructorForListingDto>> GetAllInstructorsForList(string? userName)
        {
            List<InstructorForListingDto> instructors = (await _identityUserManager.GetUsersInRoleAsync(CouresesRoles.InstructorRole))
                .WhereIf(!String.IsNullOrEmpty(userName),x=>x.UserName==userName)
                .Select(x => new InstructorForListingDto
            {
                Id=x.Id,
                Name = x.Name,
            }).ToList();
            return instructors;
        }

        public async Task<List<SubjectDto>> GetCurrentInstructorUserEnrolledSubjects()
        {
            if (CurrentUser.IsInRole(CouresesRoles.InstructorRole))
            {

                var subjects=(await _subjectRepository.GetQueryableAsync()).Where(x=>x.Instructor.Id==CurrentUser.Id)
              .Select(x => new SubjectDto
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
                throw new BusinessException("Sorry you are not Instructor You must Login as a Instructor First");
            }
        }

        public async Task<InstructorDto> GetInstructorAsync(Guid id)
        {
            var instructor = await _userRepository.GetAsync(x => x.Id == id);
            return new InstructorDto() { 
                Id = instructor.Id,
                Email=instructor.Email,
                InstructorName=instructor.Name,
                PhoneNumber=instructor.PhoneNumber,
                UserName = instructor.UserName,
            };
        }

        public async Task<InstructorDto> UpdateInstructorAsync(Guid id, UpdateInstructorDto input)
        {
            var instructor = await _userRepository.GetAsync(x => x.Id == id);


            if (instructor != null)
            {
                await _identityUserManager.RemovePasswordAsync(instructor);
                await _identityUserManager.AddPasswordAsync(instructor, input.Password);
                instructor.SetPhoneNumber(input.PhoneNumber,true);
                instructor.Name = input.InstructorName;
               var result= await _identityUserManager.UpdateAsync(instructor);
                return new InstructorDto()
                {
                    Id = id,
                    Email = instructor.Email,
                    PhoneNumber = input.PhoneNumber,
                    InstructorName = input.InstructorName,
                    UserName = instructor.UserName
                };
            }
            else
            {
                throw new BusinessException("404","User is Not Founded !");
            }

            
        }
    }
}
