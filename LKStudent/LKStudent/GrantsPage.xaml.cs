using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LKStudent
{

    public partial class GrantsPage : ContentPage
    {
        private const string grantsJsonUrl = "https://test-lks.volgatech.net/Grants/GetGrantsLogsJSON";
        private const string jsonGrantsLocalName = "grantsData.json";

        List<GrantsData> grants;
        Label dateInfo;

        public GrantsPage()
        {
            Resources = new Xamarin.Forms.ResourceDictionary();

            dateInfo = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.FromRgba(0, 0, 255, 0.5),
                TextColor = Color.White,
                LineBreakMode = LineBreakMode.MiddleTruncation,
                VerticalTextAlignment = TextAlignment.Center,
            };

            grants = new List<GrantsData>();
            Resources.Add("grants", grants);

            LoadGrantsDataFromJson();


            InitializeComponent();


            listq.ItemTapped += (sender, e) =>
            {  
                dateInfo.Text = (e.Item as GrantsData).DateStart.GetDateTimeFormats()[0] + " - " +
                    (e.Item as GrantsData).DateEnd.GetDateTimeFormats()[0];
                AbsoluteLayout.SetLayoutBounds(dateInfo, new Rectangle(0.5, 1, 1, 0.05));
                AbsoluteLayout.SetLayoutFlags(dateInfo, AbsoluteLayoutFlags.All);
                mainStack.Children.Add(dateInfo);
                

                ((ListView)sender).SelectedItem = null;
            };

        }

        private void LoadGrantsDataFromJson()
        {
            GetJsToUrl jsonLocalGrants = new GetJsToUrl(grantsJsonUrl, jsonGrantsLocalName);

            string localJsonGrants = DependencyService.Get<ISaveAndLoad>().LoadText(jsonGrantsLocalName);
            var deserializedJsonGrants = JsonConvert.DeserializeObject<List<GrantsData>>(localJsonGrants);

            for (int i = 0; i < deserializedJsonGrants.Count; i++)
            {
                grants.Add(deserializedJsonGrants[i]);
            }      
        }

    }
}
