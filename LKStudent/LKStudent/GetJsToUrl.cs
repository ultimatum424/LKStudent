﻿using System;
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
using System.Diagnostics;

using System.Json;

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
                //client.BaseAddress = new Uri(ulr_);
                var response = client.GetAsync(new Uri(ulr_)).Result;
                response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка

                // десериализация ответа в формате json
                var content = await response.Content.ReadAsStringAsync();

                //JObject o = JObject.Parse(content);
                //var o = JsonObject.Parse(content);

                //var str = o.SelectToken(@"Model.[0]");
                Debug.WriteLine(content.ToString());
                Debug.WriteLine("----------------");
                //Debug.WriteLine(o.ToString());

                DependencyService.Get<ISaveAndLoad>().SaveText(name_, content.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("---------------------------------------");
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("---------------------------------------");
            }
        }      
    }
}