using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LKStudent
{
    public partial class ExamList : ContentPage
    {
        GetJsToUrl jsToUrl;
        string url = "https://test-lks.volgatech.net/ExamList/ExamListCurrentJSON";
        private string name = "js414424255.js";

        
        public ExamList()
        {
            Resources = new Xamarin.Forms.ResourceDictionary();
            
            jsToUrl = new GetJsToUrl(url, name);
            Resources.Clear();
            var localJson = DependencyService.Get<ISaveAndLoad>().LoadText(name);
            var deserializedJson = JsonConvert.DeserializeObject<List<ExamJS>>(localJson);
            Resources.Add("ExamItems", deserializedJson);
            InitializeComponent();
            
            PickerSelectSemester.Items.Add("1 семестр");
            PickerSelectSemester.Items.Add("2 семестр");
            PickerSelectSemester.Items.Add("3 семестр");
            PickerSelectSemester.Items.Add("4 семестр");
        }

        
        private void PickerSelectSemester_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
            Resources.Clear();
            var localJson = DependencyService.Get<ISaveAndLoad>().LoadText(name);
            var deserializedJson = JsonConvert.DeserializeObject<List<ExamJS>>(localJson);
            Resources.Add("ExamItems", deserializedJson);
        }
    }
}
