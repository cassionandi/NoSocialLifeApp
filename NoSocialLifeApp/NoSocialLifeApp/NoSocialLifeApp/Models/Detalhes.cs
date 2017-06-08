using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace NoSocialLifeApp.Models
{

    [XmlRoot(ElementName = "items")]
    public class RootDetalhe
    {
        [XmlElement(ElementName = "item")]
        public DetalheItem Item { get; set; }
        [XmlAttribute(AttributeName = "termsofuse")]
        public string Termsofuse { get; set; }
    }

    [XmlRoot(ElementName = "name")]
    public class DetalheNome
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "sortindex")]
        public string Sortindex { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "link")]
    public class LinkDetalhe
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "yearpublished")]
    public class DetalheAnoPublicacao
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "seriescode")]
    public class DetalheSeriesCode
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class DetalheItem
    {
        [XmlElement(ElementName = "thumbnail")]
        public string Thumbnail { get; set; }
        [XmlElement(ElementName = "image")]
        public string Imagem { get; set; }
        [XmlElement(ElementName = "name")]
        public List<DetalheNome> Name { get; set; }
        [XmlElement(ElementName = "link")]
        public List<LinkDetalhe> Link { get; set; }
        [XmlElement(ElementName = "description")]
        public string Descricao { get; set; }
        [XmlElement(ElementName = "yearpublished")]
        public DetalheAnoPublicacao AnoPublicacao { get; set; }
        [XmlElement(ElementName = "seriescode")]
        public DetalheSeriesCode Seriescode { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }



}
