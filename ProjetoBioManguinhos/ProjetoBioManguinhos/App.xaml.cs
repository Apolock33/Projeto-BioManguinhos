using ProjetoBioManguinhos.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoBioManguinhos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
