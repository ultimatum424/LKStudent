using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LKStudent.Pages
{
    public partial class MenuPage : MasterDetailPage
    {
        public MenuPage()
        {
            Resources = new Xamarin.Forms.ResourceDictionary();
            var res = new List<MasterPageItem>();
           
            res.Add(CreatItem("Инфо", typeof(StudentInfoPage)));
            res.Add(CreatItem("Экзамены", typeof(ExamList)));
            res.Add(CreatItem("Стипендия", typeof(GrantsPage)));
            res.Add(CreatItem("Достижения", typeof(AchievementsPage)));
            Resources.Add("resurs", res);
            InitializeComponent();
                
           
        }

        private MasterPageItem CreatItem(string text, Type type)
        {
            var temp = new MasterPageItem();
            temp.TargetType = type;
            temp.Text = text;
            return temp;
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (MasterPageItem) e.Item;
            if (item != null)
            {
                //Detail = new AchievementsPage();
                     
                object q = Activator.CreateInstance(item.TargetType);
                Detail = (Page) q;
                //Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                IsPresented = false;
                ListMenu.SelectedItem = null;
            }

        }
    }
    //Android only allows one navigation page on screen at a time
}
