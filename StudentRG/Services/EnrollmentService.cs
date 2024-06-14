using StudentRG.Models.DataModels;
using StudentRG.Models.ViewModels;
using StudentRG.Repositories;

namespace StudentRG.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository,IStudentRepository studentRepository,ICourseRepository courseRepository)
        {
            this._enrollmentRepository = enrollmentRepository;
            this._studentRepository = studentRepository;
            this._courseRepository = courseRepository;
        }
        public void Create(EnrollmentViewModel enrollmentViewModel)
        {
            var IsEnroll = _enrollmentRepository.GetAll().Where(w => w.StudentId == enrollmentViewModel.StudentId && w.CourseId == enrollmentViewModel.CourseId).Any();
            if (IsEnroll)
            {
                throw new Exception("Student  already enrollment to the System");
            }
            var enroll = new EnrollmentEntity()
            {
                Id = Guid.NewGuid().ToString("N").Substring(0, 5),
                StudentId = enrollmentViewModel.StudentId,
                CourseId = enrollmentViewModel.CourseId,
                EnrollDate = enrollmentViewModel.EnrollDate
            };
            _enrollmentRepository.Create(enroll);
        }

        public void Delete(string Id)
        {
            _enrollmentRepository.Delete(Id);
        }

        public IList<EnrollmentViewModel> GetAll()
        {
            return (from e in _enrollmentRepository.GetAll()
                    join s in _studentRepository.GetAll()
                    on e.StudentId equals s.Id
                    join c in _courseRepository.GetAll()
                    on e.CourseId equals c.Id
                    select new EnrollmentViewModel
                    {
                        Id = e.Id,
                        StudentId = e.StudentId,
                        CourseId = e.CourseId,
                        EnrollDate = e.EnrollDate,
                        StudentInfo = s.Name,
                        CourseInfo = c.Name
                    }).ToList();
        }

        public EnrollmentViewModel GetByID(string id)
        {
            var enrollEntity = _enrollmentRepository.GetById(id);

            return new EnrollmentViewModel()
            {

                Id = enrollEntity.Id,
                StudentId = enrollEntity.StudentId,
                CourseId = enrollEntity.CourseId,
                EnrollDate = enrollEntity.EnrollDate
            };
        }

        public void Update(EnrollmentViewModel enrollmentViewModel)
        {
            var enroll = new EnrollmentEntity()
            {
                Id = enrollmentViewModel.Id,
                StudentId = enrollmentViewModel.StudentId,
                CourseId = enrollmentViewModel.CourseId,
                EnrollDate = enrollmentViewModel.EnrollDate,
                

            };
            _enrollmentRepository.Update(enroll);
        }
    }
}
