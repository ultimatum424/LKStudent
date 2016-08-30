namespace LKStudent
{
    public class StudentInfoJS
    {
        public string Fio { get; set; }
        public string StudentNumber { get; set; }
        public string AcademicState { get; set; }
        public string GroupName { get; set; }

        public Oop Oop;
        public EditGroup EditGroup;
    }
    public class Oop
    {
        public string Faculty { get; set; }
        public string FullStdName { get; set; }
        public string FullSpzName { get; set; }
    }

    public class EditGroup
    {
        public string Course { get; set; }
    }


}