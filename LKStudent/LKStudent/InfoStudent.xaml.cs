using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LKStudent
{
    public partial class InfoStudent : ContentPage
    {
        GetJsToUrl jsToUrl;
        string url = "https://test-lks.volgatech.net/Student/GetFullStudentInfoJSON";
        private string name = "StudentInfo.js";
        public InfoStudent()
        {
            InitializeComponent();

            jsToUrl = new GetJsToUrl(url, name);
            this.BindingContext = jsToUrl;
            string sToken = DependencyService.Get<ISaveAndLoad>().LoadText(name);
            var studentInfoJs = JsonConvert.DeserializeObject<StudentInfoJS>(sToken);

            FioField.Text = studentInfoJs.Fio;
            NumberStudentFill.Text = studentInfoJs.StudentNumber;
            DepartmentFill.Text = studentInfoJs.Oop.Faculty;
            SpecialtyFill.Text = studentInfoJs.Oop.FullSpzName;
            ProfileFill.Text = studentInfoJs.Oop.FullStdName;
            CourseFill.Text = studentInfoJs.EditGroup.Course;
            GroupFill.Text = studentInfoJs.GroupName;
            AcademicStatusFill.Text = studentInfoJs.AcademicState;
        }
    }
}
