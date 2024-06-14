using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using StudentRG.Helper.DataSet;
using StudentRG.Services;
using System.Text;

namespace StudentRG.Controllers
{
    public class StudentReportController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public StudentReportController(IWebHostEnvironment webHostEnvironment,IStudentService studentService,ICourseService courseService)
        {
            this._webHostEnvironment = webHostEnvironment;
            this._studentService = studentService;
            this._courseService = courseService;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
        public IActionResult GetByCourseName()
        {
            ViewBag.Course = _courseService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult GetByCourseName(string courseId, string gender)
        {
            var studentDetail = _studentService.GetByCourseName(courseId, gender);
            /*Dictionary<string,string> parameters= new Dictionary<string,string>();
            parameters.Add("rpfromCode", fromCode);
            parameters.Add("rptoCode", toCode);
            parameters.Add("rpDepartmentName", _departmentService.GetByID(departmentId).Name);*/
            var rdlcPath = $"{_webHostEnvironment.WebRootPath}\\RdlcReportFile\\StudentDetailReport.rdlc";
            if (studentDetail != null)
            {
                Stream reportDefinition = new FileStream(rdlcPath, FileMode.Open);
                IList<ReportParameter> parameters = new List<ReportParameter>();
                if ("x".Equals(courseId))
                { 
                    parameters.Add(new ReportParameter("rpCourseId", "null"));
                }
                else
                {
                    parameters.Add(new ReportParameter("rpCourseId", _courseService.GetByID(courseId).Name));
                } 
                parameters.Add(new ReportParameter("rpGender", gender));
                /*Stream reportDefinition = new FileStream(rdlcPath, FileMode.Open);*/
                LocalReport report = new LocalReport();
                report.LoadReportDefinition(reportDefinition);
                report.DataSources.Add(new ReportDataSource("StudentDetail", studentDetail));
                /*report.SetParameters(new ReportParameter[3]
                {   new ReportParameter("rpfromCode", fromCode) ,
                    new ReportParameter("rptoCode", toCode) ,
                    new ReportParameter("rpDepartmentName", _departmentService.GetByID(departmentId).Name) });*/
                report.SetParameters(parameters);
                byte[] pdf = report.Render("PDF");
                return File(pdf, "application/pdf");
            }
            return View(studentDetail);
        }
    }
}
