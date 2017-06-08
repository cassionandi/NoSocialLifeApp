using NoSocialLifeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSocialLifeApp.ViewModels
{
    public class MaisViewModel : BaseViewModel
    {

        public List<MetadadoGroup> Grupos { get; set; }


        public MaisViewModel(DetalheItem detalhe)
        {

            Title = detalhe.Name[0].Value;

            Grupos = new List<MetadadoGroup>();

            Grupos = MontarGrupos(detalhe.Link);
    }

        private List<MetadadoGroup> MontarGrupos(List<LinkDetalhe> link)
        {
            var resultado = new List<MetadadoGroup>();

            var grupo = new MetadadoGroup(null);

            foreach (var item in link)
            {

                if (item.Type == "rpggenre")
                    AddLinkToGroup("Gênero", item, resultado);

                if (item.Type == "rpgcategory")
                    AddLinkToGroup("Categoria", item, resultado);

                if (item.Type == "rpgmechanic")
                    AddLinkToGroup("Mecânicas", item, resultado);

                if (item.Type == "rpgpublisher")
                    AddLinkToGroup("Editora", item, resultado);

                if (item.Type == "rpgartist")
                    AddLinkToGroup("Artista", item, resultado);

                if (item.Type == "rpgdesigner")
                    AddLinkToGroup("Designer", item, resultado);

                if (item.Type == "rpgproducer")
                    AddLinkToGroup("Produção", item, resultado);

            }
            return resultado;
        }

        private void AddLinkToGroup(string tipo, LinkDetalhe item, List<MetadadoGroup> resultado)
        {
            var grupo = resultado.Find(x => x.Tipo == tipo);
            if (grupo == null)
            {
                grupo = new MetadadoGroup(tipo);
                resultado.Add(grupo);
            }
            grupo.Add(item);
        }
    }

    public class MetadadoGroup : List<LinkDetalhe>
    {
        public string Tipo { get; set; }
        public MetadadoGroup(string tipo)
        {
            Tipo = tipo;
        }

        //public static IList<MetadadoGroup> All { private set; get; }
    }

}
