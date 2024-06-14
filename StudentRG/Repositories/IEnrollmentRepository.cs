using StudentRG.Models.DataModels;

namespace StudentRG.Repositories
{
    public interface IEnrollmentRepository
    {
        void Create(EnrollmentEntity enrollmentEntity);
        IList<EnrollmentEntity> GetAll();
        EnrollmentEntity GetById(string id);
        void Update(EnrollmentEntity enrollmentEntity);

        void Delete(string id);
    }
}
