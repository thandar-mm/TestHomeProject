using StudentRG.Models.ViewModels;

namespace StudentRG.Services
{
    public interface IPrerequisiteCourseService
    {
        void Create(PrerequisiteCourseViewModel prerequisiteCourseViewModel);
        IList<PrerequisiteCourseViewModel> GetAll();

        PrerequisiteCourseViewModel GetByID(string id);

        void Update(PrerequisiteCourseViewModel prerequisiteCourseViewModel);

        void Delete(string Id);
    }
}
