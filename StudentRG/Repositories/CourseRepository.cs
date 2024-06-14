using StudentRG.DAO;
using StudentRG.Models.DataModels;

namespace StudentRG.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CourseRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }
        public void Create(CourseEntity courseEntity)
        {
            _applicationDbContext.Courses.Add(courseEntity);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            var course = _applicationDbContext.Courses.Find(id);
            if (course != null)
            {
                _applicationDbContext.Courses.Remove(course);
                _applicationDbContext.SaveChanges();
            }
        }

        public IList<CourseEntity> GetAll()
        {
            return _applicationDbContext.Courses.ToList();
        }

        public CourseEntity GetById(string id)
        {
            return _applicationDbContext.Courses.Where(w => w.Id == id).SingleOrDefault();
        }

        public void Update(CourseEntity courseEntity)
        {
            _applicationDbContext.Courses.Update(courseEntity);
            _applicationDbContext.SaveChanges();
        }
    }
}
