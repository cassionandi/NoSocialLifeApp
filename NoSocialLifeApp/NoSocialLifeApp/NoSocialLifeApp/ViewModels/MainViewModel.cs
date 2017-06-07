using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoSocialLifeApp.ViewModels
{

    public class MainViewModel : BaseViewModel
    {

        public Command ShowPopularesCommand { get; }

        public Command ShowBuscaCommand { get; }

        public MainViewModel()
        {

            ShowPopularesCommand = new Command(ExecutePopularesCommand);

            ShowBuscaCommand = new Command(ExecuteBuscaCommand);

            Title = "Início";

        }

        private async void ExecutePopularesCommand()
        {
            await PushAsync<PopularesViewModel>();
        }

        private async void ExecuteBuscaCommand()
        {
            await PushAsync<BuscaViewModel>();
        }

    }

    

}

