using NoSocialLifeApp.Views;
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

        public Command ShowAgradecimentoCommand { get; }

        public MainViewModel()
        {

            ShowPopularesCommand = new Command(ExecutePopularesCommand);

            ShowBuscaCommand = new Command(ExecuteBuscaCommand);

            ShowAgradecimentoCommand = new Command(ExecuteShowAgradecimentoCommand);

            Title = "Início";

        }

        private async void ExecuteShowAgradecimentoCommand()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new AgradecimentoPage());
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

