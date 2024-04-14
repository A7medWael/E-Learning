using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Study.Courses.Subjects.Dto
{
    public class CreateSubjectDto:EntityDto<Guid>
    {
        [Required]
        [MaxLength(SubjectConsts.MaxTitleLength)]
        public string Title { get; set; }
        [Required]
        public Guid InstructorId { get; set; }
        [Required]
        [MaxLength(SubjectConsts.MaxLevelLength)]
        public string Level { get; set; }
        [Required]
        [MaxLength(SubjectConsts.MaxDescriptionLength)]
        public string Description { get; set; }
        [Required]
        public List<string> SubjectMaterialLink { get; set; }
        [Required]
        public bool isFirstSemester { get; set; }
        [Required]
        [MaxLength(SubjectConsts.MaxQuizUrlLength)]
        public string QuizUrl { get; set; }
        public List<Guid>? Students { get; set; }

        public string Photo { get; set; }

    }
}
