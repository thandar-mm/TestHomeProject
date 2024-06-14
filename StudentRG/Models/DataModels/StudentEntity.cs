using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRG.Models.DataModels
{
    [Table("Student")]
    public class StudentEntity
    {
        [Key]
        [MaxLength(7)]
        public string Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }

       /* public ICollection<EnrollmentEntity> Enrollments { get; set; }
        public ICollection<AttendanceEntity> Attendances { get; set; }*/


    }
}
