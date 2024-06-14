using StudentRG.Models.DataModels;

namespace StudentRG.Repositories
{
    public interface IAttendanceRepository
    {
        void Create(AttendanceEntity AttendanceEntity);
        IList<AttendanceEntity> GetAll();
        AttendanceEntity GetById(string id);
        void Update(AttendanceEntity AttendanceEntity);

        void Delete(string id);
    }
}
