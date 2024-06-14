using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRG.Models.ViewModels;
using StudentRG.Services;



namespace StudentRG.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public StudentController(IStudentService studentService,ICourseService courseService)
        {
            this._studentService = studentService;
            this._courseService = courseService;
        }
        public IActionResult Register()
        {
            ViewBag.Courses= _courseService.GetAll().Select(
                s => new CourseViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).OrderBy(o => o.Name).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Register(StudentViewModel ui)
        {
            try
            {
                _studentService.Create(ui);
                TempData["info"] = "Successfully Save to the Student";
                
            }
            catch (Exception e)
            {
                TempData["error"] = "Error occur when saving a record to the Student ";
            }
            return RedirectToAction("List");
        }

        public IActionResult List()
        {

            return View(_studentService.GetAll());
        }


        public IActionResult Edit(string id)
        {
            ViewBag.Courses = _courseService.GetAll().Select(
                s => new CourseViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).OrderBy(o => o.Name).ToList();
            return View(_studentService.GetByID(id));
        }

        public IActionResult Update(StudentViewModel ui)
        {
            try
            {
                _studentService.Update(ui);
                TempData["info"] = "Successfully Update to the System";
            }
            catch (Exception e)
            {
                TempData["error"] = "Error occur when updating a record to the system ";
            }
            return RedirectToAction("List");

        }

        public IActionResult Delete(string id)
        {
            try
            {
                _studentService.Delete(id);
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
