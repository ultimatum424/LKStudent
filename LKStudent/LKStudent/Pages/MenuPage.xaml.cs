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
                Page displayPage = (Page)Activator.CreateInstance(item.TargetType);
                Detail = displayPage;
                IsPresented = false;
                ListMenu.SelectedItem = null;
                
            }

        }
    }
    //Android only allows one navigation page on screen at a time

/* <ContentPage BackgroundColor="White" Title="Меню" x:Name="masterPage">    
   <StackLayout Orientation="Vertical">
     <ListView ItemTapped="ListView_OnItemTapped" ItemsSource="{StaticResource resurs}" x:Name="ListMenu">
       <ListView.ItemTemplate>
         <DataTemplate>
           <ViewCell>
             <Label Text="{Binding Text}" TextColor="Black" FontSize="20"/>
           </ViewCell>
         </DataTemplate>
       </ListView.ItemTemplate>
     </ListView>
    </StackLayout>
  </ContentPage>
  */
}
