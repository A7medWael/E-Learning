using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Study.Courses.Instructors.Dtos
{
    public class UpdateInstructorDto
    {
        [Required]
        [MaxLength(InstructorConsts.MaxInstructorName)]
        public string InstructorName { get; set; }

        [Required]
        [MaxLength(InstructorConsts.MaxInstructorPhone)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(InstructorConsts.MaxPassword)]
        public string Password { get; set; }
    }
}
