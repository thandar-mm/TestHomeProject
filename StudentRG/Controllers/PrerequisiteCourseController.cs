using Microsoft.AspNetCore.Mvc;
using StudentRG.Models.ViewModels;
using StudentRG.Services;

namespace StudentRG.Controllers
{
    public class PrerequisiteCourseController : Controller
    {
        private readonly IPrerequisiteCourseService _prerequisiteCourseService;
        private readonly ICourseService _courseService;

        public PrerequisiteCourseController(IPrerequisiteCourseService prerequisiteCourseService,ICourseService courseService)
        {
            this._prerequisiteCourseService = prerequisiteCourseService;
            this._courseService = courseService;
        }
        public IActionResult List()
        {
            return View(_prerequisiteCourseService.GetAll());
        }

        public IActionResult Edit(string id)
        {
            ViewBag.Courses = _courseService.GetAll();
            ViewBag.PrerequisiteCourse= _courseService.GetAll();
            if (id != null)
            {
                return View(_prerequisiteCourseService.GetByID(id));
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        public IActionResult Update(PrerequisiteCourseViewModel ui)
        {
            try
            {
                _prerequisiteCourseService.Update(ui);
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
                _prerequisiteCourseService.Delete(id);
                TempData["info"] = "Delete Successfullly";
            }
            catch (Exception e)
            {
                TempData["error"] = "Error Occur When Deleting";
            }

            return RedirectToAction("List");
        }

        public IActionResult Entry()
        {
            ViewBag.Courses=_courseService.GetAll();
            ViewBag.PrerequisiteCourse = _courseService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Entry(PrerequisiteCourseViewModel ui)
        {
            try
            {
                _prerequisiteCourseService.Create(ui);
                TempData["info"] = "Save Successfully";
            }
            catch (Exception)
            {
                TempData["error"] = "Error occur When saving";
            }
            return RedirectToAction("List");
        }
    }
}
