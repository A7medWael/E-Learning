using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Study.Courses.Students.Dtos
{
    public class StudentForListingDto:EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
