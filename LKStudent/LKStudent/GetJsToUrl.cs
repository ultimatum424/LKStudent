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
    public class GetJsToUrl
    {
        public GetJsToUrl(string ulr_, string name_)
        {          
            LoadData(ulr_, name_);
        }

        public async void LoadData(string ulr_, string name_)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ulr_);
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка

                // десериализация ответа в формате json
                var content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);

                //var str = o.SelectToken(@"Model.[0]");
                DependencyService.Get<ISaveAndLoad>().SaveText(name_, o.ToString());
            }
            catch (Exception ex)
            { }
        }      
    }
}
