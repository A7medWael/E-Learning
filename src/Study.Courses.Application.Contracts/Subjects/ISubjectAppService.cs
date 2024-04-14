using Microsoft.AspNetCore.Http;
using Study.Courses.Subjects.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Study.Courses.Subjects
{
    public interface ISubjectAppService:IApplicationService
    {
        public Task<SubjectDto> CreateAsync(CreateSubjectDto input);
        public Task<CreateSubjectDto> UpdateAsync(Guid courseId,CreateSubjectDto input);

        public Task DeleteAsync(Guid subjectId);
        public Task<List<SubjectDto>> GetAllAsync(int skipCount, int maxResultCount, string? subjectTitle);
        public Task<DetailedSubjectDto> GetDetailedSubjectAsync(Guid subjectId);
        //public string UploadCourseImage(IFormFile couresImage);

    }
}
