using StudentRG.Models.ViewModels;

namespace StudentRG.Services
{
    public interface IEnrollmentService
    {
        void Create(EnrollmentViewModel enrollmentViewModel);
        IList<EnrollmentViewModel> GetAll();

        EnrollmentViewModel GetByID(string id);

        void Update(EnrollmentViewModel enrollmentViewModel);

        void Delete(string Id);
    }
}
