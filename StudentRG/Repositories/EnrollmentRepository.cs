using StudentRG.DAO;
using StudentRG.Models.DataModels;

namespace StudentRG.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EnrollmentRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public void Create(EnrollmentEntity enrollmentEntity)
        {
            _applicationDbContext.Enrollments.Add(enrollmentEntity);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var enroll = _applicationDbContext.Enrollments.Find(id);
            if (enroll != null)
            {
                _applicationDbContext.Enrollments.Remove(enroll);
                _applicationDbContext.SaveChanges();
            }
        }

        public IList<EnrollmentEntity> GetAll()
        {
            return _applicationDbContext.Enrollments.ToList();
        }

        public EnrollmentEntity GetById(string id)
        {
            return _applicationDbContext.Enrollments.Where(w => w.Id == id).SingleOrDefault();
        }

        public void Update(EnrollmentEntity enrollmentEntity)
        {
            _applicationDbContext.Enrollments.Update(enrollmentEntity);
            _applicationDbContext.SaveChanges();
        }
    }
}
