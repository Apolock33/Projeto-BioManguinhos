using ProjetoBioManguinhos.Services;
using ProjetoBioManguinhos.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjetoBioManguinhos
{
    public partial class MainPage : ContentPage
    {
        bool isLoading;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BTNLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                isLoading = true;

                if (isLoading)
                {
                    BVTelaPreta.IsEnabled = true;
                    AIRoda.IsEnabled = true;
                }

                UserServices userServices = new UserServices();

                var verifyLoginAttempt = await userServices.IsUserFirstLogin(INPTLogin.Text);

                var login = await userServices.VeryfyAccessRegister(INPTLogin.Text, INPTPassword.Text);

                if (verifyLoginAttempt && login)
                {
                    isLoading = false;

                    if (!isLoading)
                    {
                        BVTelaPreta.IsEnabled = false;
                        AIRoda.IsEnabled = false;
                    }

                    await Navigation.PushAsync(new HomePage());
                }
                else if (login)
                {
                    await Navigation.PushAsync(new HomePage());
                }
                else
                {
                    await DisplayAlert("Falha!", "Usuário não encontrado!", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Falha!", "Algo deu errado, por favor tente de novo!" + ex.Message, "Ok");
            }
        }
    }
}
