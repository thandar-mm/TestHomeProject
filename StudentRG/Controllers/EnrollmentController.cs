using Microsoft.AspNetCore.Mvc;
using StudentRG.Models.ViewModels;
using StudentRG.Services;

namespace StudentRG.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        public EnrollmentController(IEnrollmentService enrollmentService,ICourseService courseService,IStudentService studentService)
        {
            this._enrollmentService = enrollmentService;
            this._courseService = courseService;
            this._studentService = studentService;
        }
        public IActionResult Entry(string id,string courseId)
        {
            ViewBag.Course = _courseService.GetByID(courseId);
            ViewBag.Student = _studentService.GetByID(id);
            return View();
        }

        [HttpPost]
        public IActionResult Entry(EnrollmentViewModel ui)
        {
            try
            {
                _enrollmentService.Create(ui);
                TempData["info"] = "Successfully Enrollment";
            }
            catch (Exception)
            {
                TempData["error"] = "Error occur when Enrolling";
            }
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            return View(_enrollmentService.GetAll());
        }

        public IActionResult Edit(string id)
        {
            /*ViewBag.Courses = _courseService.GetAll().Select(
                s => new CourseViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).OrderBy(o => o.Name).ToList();
            ViewBag.Students = _studentService.GetAll().Select(
                s => new CourseViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).OrderBy(o => o.Name).ToList();*/
            ViewBag.Students = _studentService.GetAll();
            ViewBag.Courses=_courseService.GetAll();
            return View(_enrollmentService.GetByID(id));
        }

        public IActionResult Update(EnrollmentViewModel ui)
        {
            try
            {
                _enrollmentService.Update(ui);
                TempData["info"] = "Successfully Update to the Enrollment";
            }
            catch (Exception e)
            {
                TempData["error"] = "Error occur when updating a record to the Enrollment ";
            }
            return RedirectToAction("List");

        }

        public IActionResult Delete(string id)
        {
            try
            {
                _enrollmentService.Delete(id);
                TempData["info"] = "Delete Successfullly";
            }
            catch (Exception e)
            {
                TempData["error"] = "Error Occur When Deleting";
            }

            return RedirectToAction("List");
        }
    }
}
