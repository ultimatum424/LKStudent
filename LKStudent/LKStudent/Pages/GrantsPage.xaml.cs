using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LKStudent
{

    public partial class GrantsPage : TabbedPage
    {
        private const string grantsJsonUrl = "https://test-lks.volgatech.net/Grants/GetGrantsLogsJSON";
        private const string jsonGrantsLocalName = "grantsData.json";

        private const string grantsPretendantJsonUrl = "https://test-lks.volgatech.net/Grants/GetGrantsPretindentsJSON";
        private const string jsonGrantsPretendantLocalName = "grantsPretendantData.json";

        List<GrantsData> grants;
        List<GrantsPretendantData> grantsPretendant;
        bool IsGrantsRefreshing;

        public GrantsPage()
        {
            Resources = new Xamarin.Forms.ResourceDictionary();

            grants = new List<GrantsData>();
            grantsPretendant = new List<GrantsPretendantData>();

            Resources.Add("grants", grants);

            LoadGrantsDataFromJson();
            LoadGrantsPretendantFromJson();

            InitializeComponent();
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

        private void ShowData()
        {

        }

        private void RefreshGrants(object sender, EventArgs args)
        {
            Debug.WriteLine("_________________Start upd");
            IsGrantsRefreshing = true;
            LoadGrantsDataFromJson();
            IsGrantsRefreshing = false;
            Debug.WriteLine("_________________End upd");
        }

    }
}
