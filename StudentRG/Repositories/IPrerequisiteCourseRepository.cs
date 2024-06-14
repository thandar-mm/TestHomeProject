using StudentRG.Models.DataModels;

namespace StudentRG.Repositories
{
    public interface IPrerequisiteCourseRepository
    {
        void Create(PrerequisiteCourseEntity prerequisiteCourseEntity);
        IList<PrerequisiteCourseEntity> GetAll();
        PrerequisiteCourseEntity GetById(string id);
        void Update(PrerequisiteCourseEntity prerequisiteCourseEntity);

        void Delete(string id);
    }
}
