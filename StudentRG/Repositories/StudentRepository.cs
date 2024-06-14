using StudentRG.DAO;
using StudentRG.Models.DataModels;

namespace StudentRG.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public void Create(StudentEntity studentEntity)
        {
            _applicationDbContext.Students.Add(studentEntity);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var student = _applicationDbContext.Students.Find(id);
            if (student is not null)
            {
                _applicationDbContext.Remove(student);
                _applicationDbContext.SaveChanges();
            }
        }

        public IList<StudentEntity> GetAll()
        {
            return _applicationDbContext.Students.ToList();
        }

        public StudentEntity GetById(string id)
        {
            return _applicationDbContext.Students.Where(w => w.Id == id).SingleOrDefault();
        }

        public void Update(StudentEntity studentEntity)
        {
            _applicationDbContext.Students.Update(studentEntity);
            _applicationDbContext.SaveChanges();
        }

    }
}
