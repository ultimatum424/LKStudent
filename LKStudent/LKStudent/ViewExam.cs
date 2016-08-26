using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace LKStudent
{
    class ViewExam : INotifyPropertyChanged
    {
        private decimal model;
        private decimal name;
        private decimal kafedra;
        private decimal room;
        private decimal building;
        private decimal teacher;

        public event PropertyChangedEventHandler PropertyChanged;

        public decimal Model
        {
            get { return model; }
            private set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string s)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }

        public ICommand LoadDataCommand { protected set; get; }

        public ViewExam()
        {
            this.LoadDataCommand = new Command(LoadData);
        }

        private async void LoadData()
        {
            string url = "https://test-lks.volgatech.net/ExamList/ExamListCurrentJSON";

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка

                // десериализация ответа в формате json
                var content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);

                var str = o.SelectToken(@"$.Model");
                var examInfo = JsonConvert.DeserializeObject<ExamJS>(str.ToString());

                this.Model = examInfo.Model;
                
            }
            catch (Exception ex)
            { }
        }

       

    
    





}
