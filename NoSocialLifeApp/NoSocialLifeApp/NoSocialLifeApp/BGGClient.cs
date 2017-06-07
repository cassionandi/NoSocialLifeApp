using BGGXMLTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BGGXMLTest
{
    public static class BGGClient
    {

        static string BASE_URL = "https://www.boardgamegeek.com/xmlapi2/";

        public static async Task<string> GetURLContent(string path)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            HttpResponseMessage response = await client.GetAsync(path);
            
            string xml = "";
            if (response.IsSuccessStatusCode)
            {
                byte[] bytes = await response.Content.ReadAsByteArrayAsync();
                Encoding enc = Encoding.GetEncoding("utf-8");
                xml = enc.GetString(bytes, 0, bytes.Length);
            }

            return xml;
        }

        public static async Task<RootLista> GetItems()
        {

            string HOT_RPG_URL = "hot?type=rpg";

            var xml = await GetURLContent(HOT_RPG_URL);

            RootLista lista = new RootLista();

            using (TextReader reader = new StringReader(xml))
            {
                try
                {
                    lista = (RootLista)new XmlSerializer(typeof(RootLista)).Deserialize(reader);
                }
                catch (InvalidOperationException)
                {
                    //XML inválido
                }
            }

            return lista;
        }

        public static async Task<RootLista> GetItems(string query)
        {

            string SEARCH_RPG_URL = $"search?type=rpgitem&query={query}";

            var xml = await GetURLContent(SEARCH_RPG_URL);

            RootLista lista = new RootLista();

            using (TextReader reader = new StringReader(xml))
            {
                try
                {
                    lista = (RootLista)new XmlSerializer(typeof(RootLista)).Deserialize(reader);
                }
                catch (InvalidOperationException)
                {
                    //XML inválido
                }
            }

            return lista;

        }

        public static async Task<RootDetalhe> GetItemDetalhe(int id)
        {
            string RPG_ITEM = $"thing?id={id}";
            var xml = await GetURLContent(RPG_ITEM);

            RootDetalhe obj = new RootDetalhe();

            using (TextReader reader = new StringReader(xml))
            {
                try
                {
                    obj = (RootDetalhe)new XmlSerializer(typeof(RootDetalhe)).Deserialize(reader);
                }
                catch (InvalidOperationException)
                {
                    //XML inválido
                }
            }

            return obj;
        }

    }
}
