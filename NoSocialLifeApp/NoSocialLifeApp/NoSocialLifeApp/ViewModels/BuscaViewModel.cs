using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NoSocialLifeApp.Models;
using Xamarin.Forms;

namespace NoSocialLifeApp.ViewModels
{
    public class BuscaViewModel : BaseViewModel
    {

        public Command<ItemLista> ShowDetalheCommand { get; }

        public BuscaViewModel()
        {
            Lista = new ObservableCollection<ItemLista>();
            ShowDetalheCommand = new Command<ItemLista>(ExecuteShowDetalheCommand);
            BuscaCommand = new Command(ExecuteBuscaCommand, CanExecuteBuscaCommand);

            Title = "Busca";
        }

        private async void ExecuteShowDetalheCommand(ItemLista obj)
        {
            await PushAsync<DetalheViewModel>(obj);
        }

        private bool CanExecuteBuscaCommand(object obj)
        {
            return string.IsNullOrWhiteSpace(QueryBusca) == false;
        }

        private async void ExecuteBuscaCommand(object obj)
        {

            /*
            //Aqui ocorre a busca
            var resultado = new List<ItemLista>()
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
                }
            };
            */

            var resultado = await BGGClient.GetItems(QueryBusca);

            //Lista.Clear();

            foreach (var itemResultado in resultado)
            {
                Lista.Add(itemResultado);
            }
        }

        public Command BuscaCommand { get; }

        private string queryBusca;

        public string QueryBusca
        {
            get { return queryBusca; }
            set {
                SetProperty(ref queryBusca, value);
                BuscaCommand.ChangeCanExecute();
                Lista.Clear();
            }
        }
        public ObservableCollection<ItemLista> Lista { get; }

    }
}
