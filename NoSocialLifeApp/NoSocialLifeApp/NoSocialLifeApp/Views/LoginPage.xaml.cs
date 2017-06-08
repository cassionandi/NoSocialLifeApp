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

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

    }
}