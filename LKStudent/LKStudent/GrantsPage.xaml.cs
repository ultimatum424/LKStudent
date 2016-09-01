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

    public partial class GrantsPage : ContentPage
    {
        private const string grantsJsonUrl = "https://test-lks.volgatech.net/Grants/GetGrantsLogsJSON";
        private const string jsonGrantsLocalName = "grantsData.json";

        List<GrantsData> grants;

        public GrantsPage()
        {
            Resources = new Xamarin.Forms.ResourceDictionary();
            grants = new List<GrantsData>();

            LoadGrantsDataFromJson();

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

            Resources.Add("grants", grants);
        }


    }
}
