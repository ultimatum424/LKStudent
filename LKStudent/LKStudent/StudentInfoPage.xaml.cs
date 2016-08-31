using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LKStudent
{
	public partial class StudentInfoPage : ContentPage
	{
        GetJsToUrl jsInfoStudent;
	    private List<ViewModelStudent> modelStudent;
        string url = "https://test-lks.volgatech.net/Student/GetFullStudentInfoJSON";
        private string name = "StudentInfo.js";
        public StudentInfoPage ()
		{
            Resources = new Xamarin.Forms.ResourceDictionary();
            modelStudent = new List<ViewModelStudent>();
            
            jsInfoStudent = new GetJsToUrl(url, name);
            var localJsonGrants = DependencyService.Get<ISaveAndLoad>().LoadText(name);
            var deserializedJsonInfoStudent = JsonConvert.DeserializeObject<StudentInfoJS>(localJsonGrants);
            

            modelStudent.Add(ConvertStudentInfo("ФИО", deserializedJsonInfoStudent.Fio));
            modelStudent.Add(ConvertStudentInfo("Номер зачетной книжки", deserializedJsonInfoStudent.StudentNumber));
            modelStudent.Add(ConvertStudentInfo("Факультет (институт)", deserializedJsonInfoStudent.Oop.Faculty));
            modelStudent.Add(ConvertStudentInfo("Направление (специальность)", deserializedJsonInfoStudent.Oop.FullSpzName));
            modelStudent.Add(ConvertStudentInfo("Профиль", deserializedJsonInfoStudent.Oop.FullStdName));
            modelStudent.Add(ConvertStudentInfo("Курс", deserializedJsonInfoStudent.EduGroup.Course));
            modelStudent.Add(ConvertStudentInfo("Группа", deserializedJsonInfoStudent.GroupName));
            modelStudent.Add(ConvertStudentInfo("Академический статус", deserializedJsonInfoStudent.AcademicState));
            Resources.Add("addInfo", modelStudent);
            InitializeComponent ();
		}

	    private ViewModelStudent ConvertStudentInfo(string header, string description)
	    {
	        var temp = new ViewModelStudent();
	        temp.header = header;
	        temp.description = description;
	        return temp;

	    }
	}
}
