using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LKStudent.Pages;
using Xamarin.Forms;

namespace LKStudent
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application

            //MainPage = new ExamList();
            //MainPage = new StudentInfoPage();
            //MainPage = new GrantsPage();
            //MainPage = new AchievementsPage();
            MainPage = new NavigationPage(new MenuPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
