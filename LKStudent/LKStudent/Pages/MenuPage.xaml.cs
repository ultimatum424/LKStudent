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
            
            Detail = new NavigationPage(new StudentInfoPage());
            Resources = new Xamarin.Forms.ResourceDictionary();
            var res = new List<MasterPageItem>();
           
            res.Add(CreatItem("Моя страница", typeof(StudentInfoPage)));
            res.Add(CreatItem("Расписание экзаменов", typeof(ExamList)));
            res.Add(CreatItem("Мои стипендии", typeof(GrantsPage)));
            res.Add(CreatItem("Мои достижения", typeof(AchievementsPage)));
            res.Add(CreatItem("Мои социальные стипендии", typeof(SocialDocumentsPage)));
            Resources.Add("resurs", res);
            InitializeComponent();
             
        }

        private MasterPageItem CreatItem(string text, Type type)
        {
            var pageItem = new MasterPageItem();
            pageItem.TargetType = type;
            pageItem.Text = text;
            return pageItem;
        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (MasterPageItem) e.Item;
            if (item != null)
            {
                Page displayPage = (Page)Activator.CreateInstance(item.TargetType);
                Detail = displayPage;
                IsPresented = false;
                ListMenu.SelectedItem = null;
                
            }
        }
    }
}
