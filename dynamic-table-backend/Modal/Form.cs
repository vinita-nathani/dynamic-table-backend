using System.Collections.Generic;

namespace dynamic_table_backend.Controllers
{
    public class Form
    {
        public int WorkingDays { get; set; }
        public int SubjectsPerDay { get; set; }
        public int TotalSubjects { get; set; }
        public List<SubjectAndHrs> SubjectAndHrs { get; set; } = new List<SubjectAndHrs>();
    }

    public class SubjectAndHrs
    {
        public string SubName { get; set; }
        public int SubHrs { get; set; }
    }

}
