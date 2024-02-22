using ProjetoBioManguinhos.Pages;
using ProjetoBioManguinhos.Services;
using System;
using Xamarin.Forms;

namespace ProjetoBioManguinhos
{
    public partial class MainPage : ContentPage
    {
        bool isLoading;

        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        public async void Btn_Entrar_Clicked(object sender, EventArgs e)
        {
            isLoading = true;

            if (isLoading)
            {
                BVTelaPreta.IsVisible = true;
                ACTRoda.IsRunning = true;
                ACTRoda.IsVisible = true;
            }

            UsersService usersService = new UsersService();

            var getResponse = await usersService.EnterOrCreate(TXTLogin.Text, TXTPassword.Text);

            if (getResponse)
            {
                isLoading = false;
                BVTelaPreta.IsVisible = false;
                ACTRoda.IsRunning = false;
                ACTRoda.IsVisible = false;

                await Navigation.PushAsync(new NavigationPage(new HomePage()));
            }
            else
            {
                isLoading = false;
                BVTelaPreta.IsVisible = false;
                ACTRoda.IsRunning = false;
                ACTRoda.IsVisible = false;

                DisplayAlert("Falha!", "Informações de login erradas!", "Ok");
            }
        }
    }
}
