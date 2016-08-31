using System.Collections.Generic;

namespace LKStudent
{
    public class StudentInfoJS
    {
        public string Fio { get; set; }
        public string StudentNumber { get; set; }
        public string AcademicState { get; set; }    
        public string GroupName { get; set; }
        public Oop Oop;
        public EduGroup EduGroup;
    }
    public class Oop
    {
        public string Faculty { get; set; }
        public string FullStdName { get; set; }
        public string FullSpzName { get; set; }
    }

    public class EduGroup
    {
        public string Course { get; set; }
    }

    public class ViewModelStudent
    {
        public string header { get; set; }
        public string description { get; set; }

    }
}
