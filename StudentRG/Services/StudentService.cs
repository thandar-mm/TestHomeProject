using Microsoft.AspNetCore.Mvc;
using StudentRG.Helper.DataSet;
using StudentRG.Models.DataModels;
using StudentRG.Models.ViewModels;
using StudentRG.Repositories;
using System.Text;

namespace StudentRG.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IAttendanceRepository _attendanceRepository;

        public StudentService(IStudentRepository studentRepository,ICourseRepository courseRepository,IAttendanceRepository attendanceRepository)
        {
            this._studentRepository = studentRepository;
            this._courseRepository = courseRepository;
            this._attendanceRepository = attendanceRepository;
        }
        public void Create(StudentViewModel studentViewModel)
        {
            try
            {
                var IsValidEmail = _studentRepository.GetAll().Where(w => w.Email == studentViewModel.Email).Any();
                if (IsValidEmail)
                {
                    throw new Exception("Student Email already exist in the System");
                }
                else
                {
                    var student = new StudentEntity()
                    {
                        Id = Guid.NewGuid().ToString("N").Substring(0, 5),
                        Name = studentViewModel.Name,
                        DOB = studentViewModel.DOB,
                        Email = studentViewModel.Email,
                        Phone = studentViewModel.Phone,
                        Address = studentViewModel.Address,
                        Gender = studentViewModel.Gender,
                        CourseId = studentViewModel.CourseId,

                    };
                    _studentRepository.Create(student);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Delete(string Id)
        {
            _studentRepository.Delete(Id);
        }

        public IList<StudentViewModel> GetAll()
        {
            return (from st in _studentRepository.GetAll()
                    join cc in _courseRepository.GetAll()
                    on st.CourseId equals cc.Id
                    select new StudentViewModel
                    {
                        Id= st.Id,
                        Name = st.Name,
                        DOB = st.DOB,
                        Email = st.Email,
                        Phone = st.Phone,
                        Address = st.Address,
                        Gender = st.Gender,
                        CourseId = st.CourseId,
                        CourseInfo=cc.Name
                    }).ToList();
        }

        public IList<StudentDetail> GetByCourseName(string CourseId, string Gender)
        {
            if(string.IsNullOrEmpty(Gender))
            {
                return (from st in _studentRepository.GetAll()
                        join cc in _courseRepository.GetAll()
                        on st.CourseId equals cc.Id
                        where (st.CourseId == CourseId) || (st.Gender == Gender)
                        select new StudentDetail
                        {
                            Id = st.Id,
                            Name = st.Name,
                            DOB = st.DOB,
                            Email = st.Email,
                            Phone = st.Phone,
                            Address = st.Address,
                            Gender = st.Gender,
                            Course = cc.Name,
                        }).ToList();
            }
            else
            {
                return (from st in _studentRepository.GetAll()
                        join cc in _courseRepository.GetAll()
                        on st.CourseId equals cc.Id
                        where (st.CourseId == CourseId) && (st.Gender == Gender)
                        select new StudentDetail
                        {
                            Id = st.Id,
                            Name = st.Name,
                            DOB = st.DOB,
                            Email = st.Email,
                            Phone = st.Phone,
                            Address = st.Address,
                            Gender = st.Gender,
                            Course = cc.Name,
                        }).ToList();
            }            
        }

        public StudentViewModel GetByID(string id)
        {
            var studentEntity = _studentRepository.GetById(id);
            var c = _courseRepository.GetById(studentEntity.CourseId);
            return new StudentViewModel()
            {
                Id=studentEntity.Id,
                Name = studentEntity.Name,
                DOB = studentEntity.DOB,
                Email = studentEntity.Email,
                Address = studentEntity.Address,
                Gender = studentEntity.Gender,
                Phone = studentEntity.Phone,
                CourseId = studentEntity.CourseId,
            };
        }

        public void Update(StudentViewModel studentViewModel)
        {
            try
            {
                var student = new StudentEntity()
                {
                    Id = studentViewModel.Id,
                    Name = studentViewModel.Name,
                    DOB = studentViewModel.DOB,
                    Email = studentViewModel.Email,
                    Phone = studentViewModel.Phone,
                    Address = studentViewModel.Address,
                    Gender = studentViewModel.Gender,
                    CourseId = studentViewModel.CourseId,

                };
                _studentRepository.Update(student);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
