using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSocialLifeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoSocialLifeApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        
        //private LoginViewModel ViewModel => BindingContext as LoginViewModel;

        public LoginPage()
        {
            InitializeComponent();


            BindingContext = new LoginViewModel();
            //LoginFBButton.Clicked += LoginFBButton_Clicked;
        }

        private void LoginFBButton_Clicked(object sender, EventArgs e)
        {

            //ViewModel.ShowPopularesCommand.Execute();

        }
    }
}