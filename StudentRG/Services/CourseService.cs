using Microsoft.EntityFrameworkCore;
using StudentRG.DAO;
using StudentRG.Models.DataModels;
using StudentRG.Models.ViewModels;
using StudentRG.Repositories;

namespace StudentRG.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IPrerequisiteCourseRepository _prerequisiteCourseRepository;

        public CourseService(ICourseRepository courseRepository,IPrerequisiteCourseRepository prerequisiteCourseRepository)
        {
            this._courseRepository = courseRepository;
            this._prerequisiteCourseRepository = prerequisiteCourseRepository;
        }
        public void Create(CourseViewModel courseViewModel)
        {
            var isCourseNameAlreadyExits = _courseRepository.GetAll().Where(w => w.Name == courseViewModel.Name).Any();
            if (isCourseNameAlreadyExits)
            {
                throw new Exception("Course already exists in the System");
            }
            else
            {
                var course = new CourseEntity()
                {
                    Id = Guid.NewGuid().ToString("N").Substring(0, 5),
                    Name = courseViewModel.Name,
                    Description = courseViewModel.Description,
                    StartDate = courseViewModel.StartDate,
                    EndDate = courseViewModel.EndDate,
                };
                _courseRepository.Create(course);
            }
        }

        public void Delete(string Id)
        {
            _courseRepository.Delete(Id);
        }

        public IList<CourseViewModel> GetAll()
        {
            /*   return (from cou in _courseRepository.GetAll()
                       join pre in _prerequisiteCourseRepository.GetAll()
                       on cou.Id equals pre.PrerequisiteCourseId
                       select new CourseViewModel
                       {
                           Id = cou.Id,
                           Name = cou.Name,
                           Description = cou.Description,
                           StartDate = cou.StartDate,
                           EndDate = cou.EndDate,
                            = _prerequisiteCourseRepository.GetAll().Where(d => d.PrerequisiteCourseId == cou.Id).SingleorDefault.CourseName.ToList()
                       }).ToList();*/
            //_courseRepository.GetAll().Where(d => d.Id == cou.PrerequisiteCourseId).FirstOrDefault().Name
            var course = _courseRepository.GetAll().Select(
                 cou => new CourseViewModel
                 {
                     Id = cou.Id,
                     Name = cou.Name,
                     Description = cou.Description,
                     StartDate = cou.StartDate,
                     EndDate = cou.EndDate,
                 }).ToList();
            return course;
        }

        public CourseViewModel GetByID(string id)
        {
            var courseEntity = _courseRepository.GetById(id);
            return new CourseViewModel()
            {
                Id = courseEntity.Id,
                Name = courseEntity.Name,
                Description = courseEntity.Description,
                StartDate = courseEntity.StartDate,
                EndDate = courseEntity.EndDate
            };
        }

        public void Update(CourseViewModel courseViewModel)
        {
            try
            {
                var course = new CourseEntity()
                {
                    Id = courseViewModel.Id,
                    Name = courseViewModel.Name,
                    Description = courseViewModel.Description,
                    StartDate = courseViewModel.StartDate,
                    EndDate = courseViewModel.EndDate
                };
                _courseRepository.Update(course);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
