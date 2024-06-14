using StudentRG.Helper.DataSet;
using StudentRG.Models.ViewModels;

namespace StudentRG.Services
{
    public interface IAttendanceService
    {
        void Create(AttendanceViewModel attendanceViewModel);
        IList<AttendanceViewModel> GetAll();

        AttendanceViewModel GetByID(string id);

        void Update(AttendanceViewModel attendanceViewModel);

        void Delete(string Id);

        IList<AttendanceDetail> AttendanceOver70(string CourseId, string studentId);
    }
}
