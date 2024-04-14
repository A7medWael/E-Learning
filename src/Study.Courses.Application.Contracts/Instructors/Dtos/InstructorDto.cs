using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Study.Courses.Instructors.Dtos
{
    public class InstructorDto:EntityDto<Guid>
    {
        public string UserName { get; set; }
       
        public string InstructorName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
