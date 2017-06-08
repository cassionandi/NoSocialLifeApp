using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSocialLifeApp.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace NoSocialLifeApp.ViewModels
{

    public class PopularesViewModel : BaseViewModel
    {

        public Command<ItemLista> ShowDetalheCommand { get; }

        public ObservableCollection<ItemLista> Lista { get; }

        public PopularesViewModel()
        {
            Title = "Populares";

            Lista = new ObservableCollection<ItemLista>();

            ShowDetalheCommand = new Command<ItemLista>(ExecuteShowDetalheCommand);

        }

        public override async Task LoadAsync()
        {

            var resultado = await BGGClient.GetItems();

            Lista.Clear();

            foreach (var item in resultado)
            {
                Lista.Add(item);
            }

        }

        private async void ExecuteShowDetalheCommand(ItemLista obj)
        {
            await PushAsync<DetalheViewModel>(obj);
        }
        

    }
}
