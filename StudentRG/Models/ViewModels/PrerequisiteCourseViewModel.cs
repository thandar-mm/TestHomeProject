using StudentRG.Models.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRG.Models.ViewModels
{
    public class PrerequisiteCourseViewModel
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string PrerequisiteCourseId { get; set; }
        public string PrerequisiteCourseName { get; set; }
    }
}
