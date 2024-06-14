using System.ComponentModel.DataAnnotations;

namespace StudentRG.Models.ViewModels
{
    public class CourseViewModel
    {
        public string Id { get; set; }
        [Required]
        //public string Code { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> PrerequisiteCourseNames { get; set; }

    }
}
