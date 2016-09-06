using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LKStudent
{
    public partial class AchievementsPage : ContentPage
    {
        GetJsToUrl jsToUrl;
        string url = "https://test-lks.volgatech.net/Grants/GetGrantsWorksJSON/";
        private string name = "GetGrantsWorksJSON.json";
        List<AchievementData> achievementList;
        public float points = 0;

        public AchievementsPage()
        {
            jsToUrl = new GetJsToUrl(url, name);
            jsToUrl.LoadData(url, name);
            this.BindingContext = jsToUrl;
            string sToken = DependencyService.Get<ISaveAndLoad>().LoadText(name);
            achievementList = JsonConvert.DeserializeObject<List<AchievementData>>(sToken);

            InitializeComponent();
            MainListView.ItemsSource = achievementList;
            points = CalculateAchievementPoints();
            Resources = new Xamarin.Forms.ResourceDictionary();
            Resources.Add("points", points);
        }

        private float CalculateAchievementPoints()
        {
            float result = 0;
            foreach(var achievement in achievementList)
            {
                result += achievement.Mark;
            }
            return result;
        }
    }
}