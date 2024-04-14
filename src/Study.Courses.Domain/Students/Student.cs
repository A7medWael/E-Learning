using Study.Courses.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Study.Courses.Students
{
    public class Student :FullAuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }
        public List<Subject> Subjects  { get; set; }
        public string Name { get; set; }
    }
}
