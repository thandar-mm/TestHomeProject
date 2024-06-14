using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRG.Models.DataModels
{
    [Table("Course")]
    public class CourseEntity
    {

        [Key]
        [MaxLength(5)]
        public string Id { get; set; }

        //public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual PrerequisiteCourseEntity PrerequisiteCourse { get; set; }
    }
        
}
