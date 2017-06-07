using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoSocialLifeApp.Models;

namespace NoSocialLifeApp.ViewModels
{

    public class DetalheViewModel : BaseViewModel
    {

        public DetalheItem ItemSelecionado { get; }

        public DetalheViewModel(ItemLista itemSelecionado)
        {

            //get full thing here

            ItemSelecionado = new DetalheItem()
            {
                Descricao = "dadasdadas",
                Imagem = "https://cf.geekdo-images.com/images/pic2823310_t.jpg"
            };

            Title = ItemSelecionado.Descricao;

        }

    }
}
