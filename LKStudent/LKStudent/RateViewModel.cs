using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace LKStudent
{
    public class RateViewModel
    {
       // public ICommand LoadDataCommand { protected set; get; }
        private string url;
        private string name;
        public RateViewModel(string ulr_, string name_)
        {
            url = ulr_;
            name = name_;
            //this.LoadDataCommand = new Command(LoadData);
            LoadData();
        }

        private async void LoadData()
        {
            //string url = "https://test-lks.volgatech.net/ExamList/ExamListCurrentJSON";
            //string url = "https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22USDRUB%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка

                // десериализация ответа в формате json
                var content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);

                var str = o.SelectToken(@"Model.[0]");
               

                DependencyService.Get<ISaveAndLoad>().SaveText(name, str.ToString());
               // string sToken = DependencyService.Get<ISaveAndLoad>().LoadText("temp3.json");

                //var rateInfo = JsonConvert.DeserializeObject<ExamJS>(sToken);                
            }
            catch (Exception ex)
            { }
        }      
    }
}
