using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSocialLifeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NoSocialLifeApp.Services;

namespace NoSocialLifeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        //private LoginViewModel ViewModel => BindingContext as LoginViewModel;
        readonly AzureService azureService = new AzureService();

        public LoginPage()
        {
            InitializeComponent();


            BindingContext = new LoginViewModel();
            //LoginFBButton.Clicked += LoginFBButton_Clicked;
        }

        private async void LoginFBButton_Clicked(object sender, EventArgs e)
        {

            //ViewModel.ShowPopularesCommand.Execute();
            var user = await azureService.LoginAsync();
            TokenLabel.Text = (user != null) ? $"Bem vindo: {user.UserId}" : "Falha no login, tente novamente!";

        }
    }
}