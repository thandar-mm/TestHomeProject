using StudentRG.Models.ViewModels;

namespace StudentRG.Services
{
    public interface ICourseService
    {
        void Create(CourseViewModel courseViewModel);
        IList<CourseViewModel> GetAll();

        CourseViewModel GetByID(string id);

        void Update(CourseViewModel courseViewModel);

        void Delete(string Id);
    }
}
