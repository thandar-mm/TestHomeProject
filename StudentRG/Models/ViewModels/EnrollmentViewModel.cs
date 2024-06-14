using StudentRG.Models.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRG.Models.ViewModels
{
    public class EnrollmentViewModel
    {
        public string Id { get; set; }
        public DateTime EnrollDate { get; set; }
        public string StudentId { get; set; }
        public string StudentInfo { get; set; }
        public string CourseId { get; set; }
        public string CourseInfo { get; set; }
    }
}
