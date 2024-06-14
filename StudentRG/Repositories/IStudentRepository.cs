using StudentRG.Models.DataModels;

namespace StudentRG.Repositories
{
    public interface IStudentRepository
    {
        void Create(StudentEntity studentEntity);
        IList<StudentEntity> GetAll();
        StudentEntity GetById(string id);
        void Update(StudentEntity studentEntity);

        void Delete(string id);
    }
}
