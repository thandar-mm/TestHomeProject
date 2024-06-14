using StudentRG.Models.DataModels;
using System.ComponentModel.DataAnnotations;

namespace StudentRG.Models.ViewModels
{
    public class StudentViewModel
    {
        public string Id { get; set; }//edit,update,delete
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string CourseId { get; set; }//for entry/update
        public string CourseInfo { get; set; }
        public ICollection<AttendanceViewModel> Attendances { get; set; }

        /*  public ICollection<EnrollmentViewModel> Enrollments { get; set; }
          public ICollection<AttendanceViewModel> Attendances { get; set; }*/

    }
}
