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
        RateViewModel viewModel;
        string url = "https://test-lks.volgatech.net/ExamList/ExamListCurrentJSON";
        private string name = "js45.js";
        public ExamList()
        {

            viewModel = new RateViewModel(url, name);
            InitializeComponent();
            
            PickerSelectSemester.Items.Add("1 семестр");
            PickerSelectSemester.Items.Add("2 семестр");
        }

        private void AddLabelExam(string text, bool isBold)
        {
            if (isBold)
            {
                ExamStack.Children.Add(new Label
                {
                    Text = text,
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 20
                });
            }
            else
            {
                ExamStack.Children.Add(new Label
                {
                    Text = text,
                    TextColor = Color.Black,
                });
            }
        }

        private void PickerSelectSemester_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            ExamStack.Children.Clear();
            this.BindingContext = viewModel;
            string sToken = DependencyService.Get<ISaveAndLoad>().LoadText(name);
            var rateInfo = JsonConvert.DeserializeObject<ExamJS>(sToken);
            AddLabelExam(rateInfo.SubjectName, true);
            AddLabelExam(rateInfo.subjectKafedra, false);
            AddLabelExam(rateInfo.Location, false);
            AddLabelExam(rateInfo.FIO, false);
            AddLabelExam("", false);
        }
    }
}
