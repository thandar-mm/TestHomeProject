using StudentRG.Helper.DataSet;
using StudentRG.Models.DataModels;
using StudentRG.Models.ViewModels;
using StudentRG.Repositories;

namespace StudentRG.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository,IStudentRepository studentRepository,
            ICourseRepository courseRepository) 
        {
            this._attendanceRepository = attendanceRepository;
            this._studentRepository = studentRepository;
            this._courseRepository = courseRepository;
        }

        public IList<AttendanceDetail> AttendanceOver70(string courseId,string studentId)
        {
            var attendances= _attendanceRepository.GetAll();
            int totalWeekdays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); // Get total days in the current month
            //t totalDaysPresent = attendances.Count(a => a.Status);
            //int totalDaysPresent = _attendanceRepository.GetAll().Select(a => a.StudentId ==studentId && a.Status).Count();
            int stutotaldaypresent=(from a in attendances where a.StudentId==studentId && a.Status
                                    select a.StudentId).Count();
            double attendanceRate = (double)stutotaldaypresent / totalWeekdays * 100;
            return (from a in _attendanceRepository.GetAll()
                    join s in _studentRepository.GetAll()
                    on a.StudentId equals s.Id
                    join c in _courseRepository.GetAll()
                    on a.CourseId equals c.Id
                    where (a.CourseId==courseId) && (a.StudentId==studentId)
                    select new AttendanceDetail
                    {
                        StudentName = s.Name,
                        CourseName = c.Name,
                        Date = a.Date,
                        Status = a.Status,
                        AttendanceDay=attendanceRate.ToString("F2")
                    }).ToList();
        }

        public void Create(AttendanceViewModel attendanceViewModel)
        {
            try
            {
                var IsValidEmail = _attendanceRepository.GetAll().Where(w => w.StudentId == attendanceViewModel.StudentId && w.Date == attendanceViewModel.Date).Any();
                if (IsValidEmail)
                {
                    throw new Exception("Attendance already existsint the System");
                }
                var att = new AttendanceEntity()
                {
                    Id = Guid.NewGuid().ToString("N").Substring(0, 5),
                    StudentId = attendanceViewModel.StudentId,
                    CourseId = attendanceViewModel.CourseId,
                    Date = attendanceViewModel.Date,
                    Status = attendanceViewModel.Status

                };
                _attendanceRepository.Create(att);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(string Id)
        {
            _attendanceRepository.Delete(Id);
        }

        public IList<AttendanceViewModel> GetAll()
        {
            return (from a in _attendanceRepository.GetAll()
                    join s in _studentRepository.GetAll()
                    on a.StudentId equals s.Id
                    join c in _courseRepository.GetAll()
                    on a.CourseId equals c.Id
                    select new AttendanceViewModel
                    {
                        Id = a.Id,
                        StudentId = a.StudentId,
                        CourseId= a.CourseId,
                        Date=a.Date,
                        Status=a.Status,
                        StudentInfo = s.Name,
                        CourseInfo = c.Name
                    }).ToList();
        }

        public AttendanceViewModel GetByID(string id)
        {
            var attendanceEntity = _attendanceRepository.GetById(id);
            
            return new AttendanceViewModel()
            {

                Id = attendanceEntity.Id,
                StudentId = attendanceEntity.StudentId,
                CourseId = attendanceEntity.CourseId,
                Date = attendanceEntity.Date,
                Status= attendanceEntity.Status,
             
            };
        }

        public void Update(AttendanceViewModel attendanceViewModel)
        {
            var att = new AttendanceEntity()
            {
                Id = attendanceViewModel.Id,
                StudentId= attendanceViewModel.StudentId,
                CourseId= attendanceViewModel.CourseId,
                Date=attendanceViewModel.Date,
                Status=attendanceViewModel.Status

            };
            _attendanceRepository.Update(att);
        }
    }
}
