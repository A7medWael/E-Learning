using Study.Courses.Students.Dtos;
using Study.Courses.Subjects.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Study.Courses.Students
{
    public interface IStudentAppService: IApplicationService
    {
        public Task<List<StudentForListingDto>> GetStudentsForListing(string? studentName);
        public Task<List<SubjectDto>> GetMyEnrolledSubjects();
        
    }
}
