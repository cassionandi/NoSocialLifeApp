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

            /*
            Lista = new List<ItemLista>()
            {
                new ItemLista()
                {
                    Id = "218704",
                    Thumbnail = new ItemThumbnail(){
                        Value = "https://cf.geekdo-images.com/images/pic2823310_t.jpg"
                    },
                    Nome = new ItemNome()
                    {
                        Value = "nome do livro"
                    },
                    AnoPublicacao = new ItemAnoPublicacao()
                    {
                        Value = "2017"
                    }
                },
                new ItemLista()
                {
                    Id = "218704",
                    Thumbnail = new ItemThumbnail(){
                        Value = "https://cf.geekdo-images.com/images/pic2823310_t.jpg"
                    },
                    Nome = new ItemNome()
                    {
                        Value = "nome do livro"
                    },
                    AnoPublicacao = new ItemAnoPublicacao()
                    {
                        Value = "2017"
                    }
                },
            };
            */
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
