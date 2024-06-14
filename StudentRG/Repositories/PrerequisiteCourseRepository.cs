using StudentRG.DAO;
using StudentRG.Models.DataModels;

namespace StudentRG.Repositories
{
    public class PrerequisiteCourseRepository : IPrerequisiteCourseRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PrerequisiteCourseRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public void Create(PrerequisiteCourseEntity prerequisiteCourseEntity)
        {
            _applicationDbContext.PrerequisiteCourses.Add(prerequisiteCourseEntity);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var prerequisiteCourse = _applicationDbContext.PrerequisiteCourses.Find(id);
            if (prerequisiteCourse != null)
            {
                _applicationDbContext.PrerequisiteCourses.Remove(prerequisiteCourse);
                _applicationDbContext.SaveChanges();
            }
        }

        public IList<PrerequisiteCourseEntity> GetAll()
        {
            return _applicationDbContext.PrerequisiteCourses.ToList();
        }

        public PrerequisiteCourseEntity GetById(string id)
        {
            return _applicationDbContext.PrerequisiteCourses.Where(w => w.Id == id).SingleOrDefault();
        }

        public void Update(PrerequisiteCourseEntity prerequisiteCourseEntity)
        {
            _applicationDbContext.PrerequisiteCourses.Update(prerequisiteCourseEntity);
            _applicationDbContext.SaveChanges();
        }
    }
}
