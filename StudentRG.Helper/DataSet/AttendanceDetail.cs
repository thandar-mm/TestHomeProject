
using System;

namespace StudentRG.Helper.DataSet
{
    public class AttendanceDetail
    {
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }

        public string AttendanceDay { get; set; }
    }
}
