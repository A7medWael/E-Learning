using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Study.Courses.Instructors.Dtos
{
    public class CreateInstructorDto : EntityDto<Guid>
    {
        [Required]
        [MaxLength(InstructorConsts.MaxUserName)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(InstructorConsts.MaxInstructorName)]
        public string InstructorName { get; set; }
        [Required]
        [MaxLength(InstructorConsts.MaxInstructorPhone)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(InstructorConsts.MaxPassword)]
        public string Password { get; set; }
        [Required]
        [MaxLength(InstructorConsts.MaxInstructorEmail)]
        public string Email { get; set; }

    }
}
