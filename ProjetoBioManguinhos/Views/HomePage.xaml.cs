using ProjetoBioManguinhos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoBioManguinhos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();

            GetAllStudies();
        }

        public async void GetAllStudies()
        {
            var list = new StudyServices();
            var getList = list.GetStudies();

            CVLista.ItemsSource = await getList;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var aba = Children[1];
            CurrentPage = aba;
        }
    }
}