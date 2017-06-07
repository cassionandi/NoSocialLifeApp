using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace NoSocialLifeApp.Models
{

    [XmlRoot(ElementName = "items")]
    public class RootLista
    {
        [XmlElement(ElementName = "item")]
        public List<ItemLista> Lista { get; set; }
        [XmlAttribute(AttributeName = "termsofuse")]
        public string TermosDeUso { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class ItemLista
    {
        [XmlElement(ElementName = "thumbnail")]
        public ItemThumbnail Thumbnail { get; set; }
        [XmlElement(ElementName = "name")]
        public ItemNome Nome { get; set; }
        [XmlElement(ElementName = "yearpublished")]
        public ItemAnoPublicacao AnoPublicacao { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "rank")]
        public string Rank { get; set; }
    }

    [XmlRoot(ElementName = "thumbnail")]
    public class ItemThumbnail
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "name")]
    public class ItemNome
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "yearpublished")]
    public class ItemAnoPublicacao
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

 

}
