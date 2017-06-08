﻿using NoSocialLifeApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NoSocialLifeApp
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

        public static async Task<List<ItemLista>> GetItems()
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

            return lista.Lista;
        }

        public static async Task<List<ItemLista>> GetItems(string query)
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

            return lista.Lista;

        }

        public static async Task<DetalheItem> GetItemDetalhe(string id)
        {
            string RPG_ITEM = $"thing?id={id}";
            var xml = await GetURLContent(RPG_ITEM);

            RootDetalhe resultado = new RootDetalhe();

            using (TextReader reader = new StringReader(xml))
            {
                try
                {
                    resultado = (RootDetalhe)new XmlSerializer(typeof(RootDetalhe)).Deserialize(reader);
                    resultado.Item.Descricao = System.Net.WebUtility.HtmlDecode(resultado.Item.Descricao);
                }
                catch (InvalidOperationException)
                {
                    //XML inválido
                }
            }

            return resultado.Item;
        }

    }
}
