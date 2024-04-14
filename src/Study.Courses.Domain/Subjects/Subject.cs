using Study.Courses.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Study.Courses.Subjects
{
    public class Subject:FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }
        public IdentityUser Instructor { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public List<string> SubjectMaterialLink { get; set; }
        public bool isFirstSemester  { get; set; }
        public string QuizUrl {  get; set; }
        public List<Student>? Students { get; set; }
        public string Photo {  get; set; }
    }
}
