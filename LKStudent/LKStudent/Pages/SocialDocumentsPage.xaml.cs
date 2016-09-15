using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LKStudent.Pages
{
    public partial class SocialDocumentsPage : ContentPage
    {
        GetJsToUrl jsToUrl;
        string url = "https://test-lks.volgatech.net/Grants/GetSocialRequestsJSON";
        private string name = "SocialDocumentsJSON.json";
        List<SocialDocumentsJS> socialDocumentsList;

        public SocialDocumentsPage()
        {
            jsToUrl = new GetJsToUrl(url, name);
            jsToUrl.LoadData(url, name);
            this.BindingContext = jsToUrl;
            string sToken = DependencyService.Get<ISaveAndLoad>().LoadText(name);
            socialDocumentsList = JsonConvert.DeserializeObject<List<SocialDocumentsJS>>(sToken);
            InitializeComponent();
            SocialDocuments.ItemsSource = socialDocumentsList;
        }
    }
}
