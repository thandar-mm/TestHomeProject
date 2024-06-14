using StudentRG.Models.ViewModels;
using StudentRG.Helper.DataSet;
using StudentRG.Models.DataModels;

namespace StudentRG.Services
{
    public interface IStudentService
    {
        void Create(StudentViewModel studentViewModel);
        IList<StudentViewModel> GetAll();

        StudentViewModel GetByID(string id);

        void Update(StudentViewModel studentViewModel);

        void Delete(string Id);

        IList<StudentDetail> GetByCourseName(string CourseId, string Gender);

    }
}
