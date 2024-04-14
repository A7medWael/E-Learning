using Study.Courses.Instructors.Dtos;
using Study.Courses.Subjects.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Study.Courses.Instructors
{
    public interface IInstructorAppService:IApplicationService
    {
        public Task<List<InstructorDto>> GetAllInstructorsAsync(int skipCount,int maxResultCount,string? instructorName);
        public Task <InstructorDto> CreateInstructorAsync (CreateInstructorDto instructor);
        public Task <InstructorDto> GetInstructorAsync (Guid id);
        public Task <InstructorDto> UpdateInstructorAsync (Guid id,UpdateInstructorDto instructor);
        public Task<List<InstructorForListingDto>> GetAllInstructorsForList(string? userName);
        public Task DeleteInstructorAsync(Guid id);

        public Task<List<SubjectDto>> GetCurrentInstructorUserEnrolledSubjects();
    }
}
