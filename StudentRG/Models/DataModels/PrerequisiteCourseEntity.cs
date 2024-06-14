using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRG.Models.DataModels
{
    [Table("PrerequisiteCourse")]
    public class PrerequisiteCourseEntity
    {

        [Key]
        [MaxLength(5)]
        public string Id { get; set; }
        public string PrerequisiteCourseId { get; set; }

        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
    }
}
