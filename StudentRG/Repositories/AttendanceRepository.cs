using StudentRG.DAO;
using StudentRG.Models.DataModels;

namespace StudentRG.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AttendanceRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public void Create(AttendanceEntity attendanceEntity)
        {
            _applicationDbContext.Attendances.Add(attendanceEntity);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var att = _applicationDbContext.Attendances.Find(id);
            if (att != null)
            {
                _applicationDbContext.Attendances.Remove(att);
                _applicationDbContext.SaveChanges();
            }
        }

        public IList<AttendanceEntity> GetAll()
        {
            return _applicationDbContext.Attendances.ToList();
        }

        public AttendanceEntity GetById(string id)
        {
            return _applicationDbContext.Attendances.Where(w => w.Id == id).SingleOrDefault();
        }

        public void Update(AttendanceEntity attendanceEntity)
        {
            _applicationDbContext.Attendances.Update(attendanceEntity);
            _applicationDbContext.SaveChanges();
        }
    }
}
