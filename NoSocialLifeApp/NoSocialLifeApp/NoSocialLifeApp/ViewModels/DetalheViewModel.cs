using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSocialLifeApp.Models;
using Xamarin.Forms;

namespace NoSocialLifeApp.ViewModels
{

    public class DetalheViewModel : BaseViewModel
    {

        public Command ShowMaisCommand { get; }

        private string idItem;

        private DetalheItem itemSelecionado;

        public DetalheItem ItemSelecionado
        {
            get { return itemSelecionado; }
            set {
                SetProperty(ref itemSelecionado, value);
            }
        }

        public DetalheViewModel(ItemLista item)
        {



            ItemSelecionado = new DetalheItem();

            Title = item.Nome.Value;
            idItem = item.Id;

            ShowMaisCommand = new Command(ExecuteShowMaisCommand);
        }

        private async void ExecuteShowMaisCommand()
        {
            await PushModalAsync<MaisViewModel>(ItemSelecionado);
        }

    public override async Task LoadAsync()
        {
            var resultado = await BGGClient.GetItemDetalhe(idItem);

            ItemSelecionado = resultado;

            // ItemSelecionado.Descricao = "dsadasdsadas";
            // ItemSelecionado.Imagem = "https://cf.geekdo-images.com/images/pic2823310_t.jpg";
        }

    }
}
