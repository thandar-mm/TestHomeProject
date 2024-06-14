using StudentRG.Models.ViewModels;
using StudentRG.Services;
using Microsoft.AspNetCore.Mvc;


namespace StudentRG.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            this._courseService = courseService;
        }
        public IActionResult Entry()
        {
            ViewBag.Courses = _courseService.GetAll().Select(
                s => new CourseViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).OrderBy(o => o.Name).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Entry(CourseViewModel course)
        {
            try
            {
                _courseService.Create(course);
                TempData["info"] = "Save Successfully into Course";
            }
            catch (Exception)
            {
                TempData["error"] = "Error occur When saving into Course";
            }
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            return View(_courseService.GetAll());
        }

        public IActionResult Edit(string id)
        {
            ViewBag.Courses = _courseService.GetAll().Select(
                s => new CourseViewModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).OrderBy(o => o.Name).ToList();
            return View(_courseService.GetByID(id));
           
        }

        public IActionResult Update(CourseViewModel ui)
        {
            try
            {
                _courseService.Update(ui);
                TempData["info"] = "Successfully Update to the Course";
            }
            catch (Exception e)
            {
                TempData["error"] = "Error occur when updating a record to the Course ";
            }
            return RedirectToAction("List");

        }

        public IActionResult Delete(string id)
        {
            try
            { 
                _courseService.Delete(id);
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
