using StudentRG.Models.DataModels;

namespace StudentRG.Repositories
{
    public interface ICourseRepository
    {
        void Create(CourseEntity courseEntity);
        IList<CourseEntity> GetAll();
        CourseEntity GetById(string id);
        void Update(CourseEntity courseEntity);

        void Delete(string id);
    }
}
