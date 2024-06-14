using Microsoft.VisualStudio.Web.CodeGeneration.CommandLine;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Runtime.InteropServices;

namespace StudentRG.Models.DataModels
{
    [Table("Attendance")]
    public class AttendanceEntity
    {
        [Key]
        [MaxLength(10)]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public bool Status {  get; set; }

        [ForeignKey("StudentId")]
        public string StudentId { get; set; }
        public virtual StudentEntity Student { get; set; }
        //public ICollection<StudentEntity> Students { get; set; }

        [ForeignKey("CourseId")]
        public string CourseId { get; set; }
        public virtual CourseEntity Course { get; set; }
        //public ICollection<CourseEntity> Courses { get; set; }
    }
}
