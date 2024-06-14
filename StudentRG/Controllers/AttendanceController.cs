using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentRG.Models.ViewModels;
using StudentRG.Services;

namespace StudentRG.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        public AttendanceController(IAttendanceService attendanceService,ICourseService courseService,IStudentService studentService)
        {
            this._attendanceService = attendanceService;
            this._courseService = courseService;
            this._studentService = studentService;
        }
        public IActionResult Entry(string Id,string courseId)
        {
            /*string[] statusArray = { "Present", "Absent" };
            ViewBag.Status= statusArray.Select(s => new SelectListItem
            {
                Value = s,
                Text = s
            }).ToList();*/
            ViewBag.Course = _courseService.GetByID(courseId);
            ViewBag.Student = _studentService.GetByID(Id);
            return View();
        }

        [HttpPost]
        public IActionResult Entry(AttendanceViewModel att)
        {
            try
            {
                _attendanceService.Create(att);
                TempData["info"] = "Save Successfully into Attendance";
            }
            catch (Exception)
            {
                TempData["error"] = "Error occur When saving into Attendance";
            }
            return RedirectToAction("List");
        }

        public IActionResult List()
        {

            return View(_attendanceService.GetAll());
        }

        public IActionResult Edit(string id)
        {
          /*  string[] statusArray = { "Present", "Absent" };
            ViewBag.Status = statusArray.Select(s => new SelectListItem
            {
                Value = s,
                Text = s
            }).ToList();*/
            ViewBag.Students = _studentService.GetAll();
            ViewBag.Courses = _courseService.GetAll();
            return View(_attendanceService.GetByID(id));

        }

        public IActionResult Update(AttendanceViewModel ui)
        {
            try
            {
                _attendanceService.Update(ui);
                TempData["info"] = "Successfully Update to the Attendance";
            }
            catch (Exception e)
            {
                TempData["error"] = "Error occur when updating a record to the Attendance ";
            }
            return RedirectToAction("List");

        }

        public IActionResult Delete(string id)
        {
            try
            {
                _attendanceService.Delete(id);
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
