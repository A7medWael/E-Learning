using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Study.Courses.Instructors.Dtos
{
    public class InstructorForListingDto:EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
