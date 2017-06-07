using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoSocialLifeApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public Command ShowMainCommand { get; }

        public Command LogoutCommand { get; }


        public LoginViewModel()
        {
            ShowMainCommand = new Command(ExecuteMainCommand);

            LogoutCommand = new Command(ExecuteLogoutCommand);
        }

        private async void ExecuteMainCommand()
        {
            await PushAsync<MainViewModel>();
        }

        private async void ExecuteLogoutCommand()
        {
            await PushAsync<LoginViewModel>();
        }

    }
}
