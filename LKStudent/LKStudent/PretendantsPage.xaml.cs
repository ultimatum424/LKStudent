using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Diagnostics;

namespace LKStudent
{
    public partial class PretendantsPage : ContentPage
    {
        private const string grantsPretendantJsonUrl = "https://test-lks.volgatech.net/Grants/GetGrantsPretindentsJSON";
        private const string jsonGrantsPretendantLocalName = "grantsPretendantData.json";

        List<GrantsPretendantData> grantsPretendant;
        Label dateInfo;

        public PretendantsPage()
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
            grantsPretendant = new List<GrantsPretendantData>();

            LoadGrantsPretendantFromJson();

            InitializeComponent();

            listq.ItemTapped += (sender, e) =>
            {
                dateInfo.Text = (e.Item as GrantsPretendantData).Date.GetDateTimeFormats()[0];
                AbsoluteLayout.SetLayoutBounds(dateInfo, new Rectangle(0.5, 1, 1, 0.05));
                AbsoluteLayout.SetLayoutFlags(dateInfo, AbsoluteLayoutFlags.All);
                mainStack.Children.Add(dateInfo);

                Debug.WriteLine((e.Item as GrantsPretendantData).Date.GetDateTimeFormats()[0]);
                ((ListView)sender).SelectedItem = null;
            };
        }

        private void LoadGrantsPretendantFromJson()
        {
            Resources.Add("grantsPretendant", grantsPretendant);
            GetJsToUrl jsonLocalGrantsPretendant = new GetJsToUrl(grantsPretendantJsonUrl, jsonGrantsPretendantLocalName);

            string localJsonGrantsPretendant = DependencyService.Get<ISaveAndLoad>().LoadText(jsonGrantsPretendantLocalName);
            var deserializedJsonGrantsPretendant = JsonConvert.DeserializeObject<List<GrantsPretendantData>>(localJsonGrantsPretendant);

            for (int i = 0; i < deserializedJsonGrantsPretendant.Count; i++)
            {
                grantsPretendant.Add(deserializedJsonGrantsPretendant[i]);
            }

        }
    }
}
