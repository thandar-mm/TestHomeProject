using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRG.Models.DataModels
{
    [Table("Enrollment")]
    public class EnrollmentEntity
    {
        [Key]
        [MaxLength(10)]
        public string Id { get; set; }
        public DateTime EnrollDate { get; set; }
        [ForeignKey("StudentId")]
        public string StudentId { get; set; }
        public virtual StudentEntity Student { get; set; }
        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
    }
}
