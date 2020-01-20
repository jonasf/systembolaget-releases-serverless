using System.Xml.Serialization;

namespace Systembolaget.Releases.Indexer.Dto
{
    [XmlRoot(ElementName = "artikel")]
    public class Beverage
	{
        [XmlElement(ElementName = "nr")]
        public int ArticleNumber { get; set; }
        [XmlElement(ElementName = "Artikelid")]
        public int ArticleId { get; set; }
        [XmlElement(ElementName = "Varnummer")]
        public int PartNumber { get; set; }
        [XmlElement(ElementName = "Namn")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Namn2")]
        public string SecondaryName { get; set; }
        [XmlElement(ElementName = "Prisinklmoms")]
        public decimal PriceIncVat { get; set; }
        [XmlElement(ElementName = "Volymiml")]
        public decimal VolumeMl { get; set; }
        [XmlElement(ElementName = "PrisPerLiter")]
        public decimal PricePerLiter { get; set; }
        [XmlElement(ElementName = "Saljstart")]
        public string ReleaseDate { get; set; }
        [XmlElement(ElementName = "Utgått")]
        public bool Discontinued { get; set; }
        [XmlElement(ElementName = "Varugrupp")]
        public string Group { get; set; }
        [XmlElement(ElementName = "Typ")]
        public string Type { get; set; }
        [XmlElement(ElementName = "Stil")]
        public string Style { get; set; }
        [XmlElement(ElementName = "Forpackning")]
        public string Packaging { get; set; }
        [XmlElement(ElementName = "Forslutning")]
        public string Seal { get; set; }
        [XmlElement(ElementName = "Ursprung")]
        public string Origin { get; set; }
        [XmlElement(ElementName = "Ursprunglandnamn")]
        public string OriginCountry { get; set; }
        [XmlElement(ElementName = "Producent")]
        public string Producer { get; set; }
        [XmlElement(ElementName = "Leverantor")]
        public string Supplier { get; set; }
        [XmlElement(ElementName = "Argang")]
        public string Vintage { get; set; }
        [XmlElement(ElementName = "Provadargang")]
        public string SampledYear { get; set; }
        [XmlElement(ElementName = "Alkoholhalt")]
        public string AlcoholContent { get; set; }
        [XmlElement(ElementName = "Sortiment")]
        public string ProductRangeAbbreviation { get; set; }
        [XmlElement(ElementName = "SortimentText")]
        public string ProductRange { get; set; }
        [XmlElement(ElementName = "Ekologisk")]
        public bool Organic { get; set; }
        [XmlElement(ElementName = "Etiskt")]
        public bool EthicalManufacturing { get; set; }
        [XmlElement(ElementName = "Koscher")]
        public bool Koscher { get; set; }

    }
}
