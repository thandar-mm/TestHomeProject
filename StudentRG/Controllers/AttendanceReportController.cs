using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using StudentRG.Services;
using System.Runtime.CompilerServices;
using System.Text;

namespace StudentRG.Controllers
{
    public class AttendanceReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAttendanceService _attendanceService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        public AttendanceReportController(IWebHostEnvironment webHostEnvironment,IAttendanceService attendanceService,
            ICourseService courseService,IStudentService studentService)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._attendanceService = attendanceService;
            this._courseService = courseService;
            this._studentService = studentService;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        public IActionResult AttendanceOver70()
        {
            ViewBag.Courses = _courseService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult AttendanceOver70(string courseId,string studentId)
        {
            var attendanceDetail = _attendanceService.AttendanceOver70(courseId,studentId);
            var rdlcPath = $"{_webHostEnvironment.WebRootPath}\\RdlcReportFile\\AttendanceDetailReport.rdlc";
            if (attendanceDetail != null)
            {
                Stream reportDefinition = new FileStream(rdlcPath, FileMode.Open);
                IList<ReportParameter> parameters = new List<ReportParameter>();

                if ("x".Equals(courseId))
                {
                    parameters.Add(new ReportParameter("rpCourse", "null"));
                }
                else
                {
                    parameters.Add(new ReportParameter("rpCourse", _courseService.GetByID(courseId).Name));
                }
                parameters.Add(new ReportParameter("rpStudent", _studentService.GetByID(studentId).Name));
                LocalReport report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);
                report.DataSources.Add(new ReportDataSource("AttendanceDetailDataSet", attendanceDetail));
                report.SetParameters(parameters);
                byte[] pdf = report.Render("PDF");
                return File(pdf, "application/pdf");
            }
            return View(attendanceDetail);
        }
    }
}
