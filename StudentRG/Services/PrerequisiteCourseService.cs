using StudentRG.Models.DataModels;
using StudentRG.Models.ViewModels;
using StudentRG.Repositories;

namespace StudentRG.Services
{
    public class PrerequisiteCourseService : IPrerequisiteCourseService
    {
        private readonly IPrerequisiteCourseRepository _prerequisiteCourseRepository;
        private readonly ICourseRepository _courseRepository;

        public PrerequisiteCourseService(IPrerequisiteCourseRepository prerequisiteCourseRepository,ICourseRepository courseRepository)
        {
            this._prerequisiteCourseRepository = prerequisiteCourseRepository;
            this._courseRepository = courseRepository;
        }
        public void Create(PrerequisiteCourseViewModel prerequisiteCourseViewModel)
        {
            var IsCourseAlreadyExit = _prerequisiteCourseRepository.GetAll().Where(w => w.CourseId == prerequisiteCourseViewModel.CourseId).Any();
            if (IsCourseAlreadyExit)
            {
                throw new Exception("Course already exists in the System");
            }
            else
            {
                var prerequisiteCourse = new PrerequisiteCourseEntity()
                {
                    Id = Guid.NewGuid().ToString("N").Substring(0, 5),
                    PrerequisiteCourseId = prerequisiteCourseViewModel.PrerequisiteCourseId,
                    CourseId = prerequisiteCourseViewModel.CourseId
                };
                _prerequisiteCourseRepository.Create(prerequisiteCourse);
            }
        }

        public void Delete(string Id)
        {
            _prerequisiteCourseRepository.Delete(Id);
        }

        public IList<PrerequisiteCourseViewModel> GetAll()
        {
            /* return _prerequisiteCourseRepository.GetAll().Select(
                  s => new PrerequisiteCourseViewModel
                  {
                     CourseId= s.CourseId,
                     PrerequisiteCourseId= s.PrerequisiteCourseId,
                  }).ToList();*/
            return (from pre in _prerequisiteCourseRepository.GetAll()
                    join cou in _courseRepository.GetAll()
                    on pre.PrerequisiteCourseId equals cou.Id
                    select new PrerequisiteCourseViewModel
                    {
                        Id = pre.Id,
                        PrerequisiteCourseId = pre.PrerequisiteCourseId,
                        CourseId = pre.CourseId,
                        PrerequisiteCourseName = cou.Name,
                        CourseName= _courseRepository.GetAll().Where(d => d.Id == pre.CourseId).FirstOrDefault().Name
                    }).ToList();
        }

        public PrerequisiteCourseViewModel GetByID(string id)
        {
            var prerequisiteCourse = _prerequisiteCourseRepository.GetById(id);
            return new PrerequisiteCourseViewModel()
            {
                Id = prerequisiteCourse.Id,
                CourseId= prerequisiteCourse.CourseId,
                PrerequisiteCourseId=prerequisiteCourse.PrerequisiteCourseId

            };
        }

        public void Update(PrerequisiteCourseViewModel prerequisiteCourseViewModel)
        {
            var prerequisiteCourse = new PrerequisiteCourseEntity()
            {
                Id= prerequisiteCourseViewModel.Id,
                CourseId = prerequisiteCourseViewModel.CourseId,
                PrerequisiteCourseId = prerequisiteCourseViewModel.PrerequisiteCourseId

            };
            _prerequisiteCourseRepository.Update(prerequisiteCourse);
        }
    }
}
