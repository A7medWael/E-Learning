using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Study.Courses.Subjects.Dto
{
    public class DetailedSubjectDto:EntityDto<Guid>
    {
        public string Title { get; set; }
        public string InstructorName { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public List<string> SubjectMaterialLink { get; set; }
        public bool isFirstSemester { get; set; }
        public string QuizUrl { get; set; }
        public List<string> Students { get; set; }
        public string Photo { get; set; }
        public Guid InstructorId { get; set; }
    }
}
