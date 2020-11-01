using Newtonsoft.Json;

namespace Systembolaget.Releases.Indexer.Dto
{
    public class Beverage
	{
        [JsonProperty("ProductNumber")]
        public int ArticleNumber { get; set; }
        [JsonProperty("ProductId")]
        public int ArticleId { get; set; }
        [JsonProperty("ProductNumberShort")]
        public int PartNumber { get; set; }
        [JsonProperty("ProductNameBold")]
        public string Name { get; set; }
        [JsonProperty("ProductNameThin")]
        public string SecondaryName { get; set; }
        [JsonProperty("Price")]
        public decimal PriceIncVat { get; set; }
        [JsonProperty("Volume")]
        public decimal VolumeMl { get; set; }
        [JsonProperty("SellStartDate")]
        public string ReleaseDate { get; set; }
        [JsonProperty("IsCompletelyOutOfStock")]
        public bool Discontinued { get; set; }
        [JsonProperty("SubCategory")]
        public string Group { get; set; }
        [JsonProperty("Type")]
        public string Type { get; set; }
        [JsonProperty("Style")]
        public string Style { get; set; }
        [JsonProperty("BottleTextShort")]
        public string Packaging { get; set; }
        [JsonProperty("Seal")]
        public string Seal { get; set; }
        [JsonProperty("Country")]
        public string OriginCountry { get; set; }
        [JsonProperty("ProducerName")]
        public string Producer { get; set; }
        [JsonProperty("SupplierName")]
        public string Supplier { get; set; }
        [JsonProperty("Vintage")]
        public string Vintage { get; set; }
        [JsonProperty("AlcoholPercentage")]
        public decimal AlcoholContent { get; set; }
        [JsonProperty("Assortment")]
        public string ProductRangeAbbreviation { get; set; }
        [JsonProperty("AssortmentText")]
        public string ProductRange { get; set; }
        [JsonProperty("IsOrganic")]
        public bool Organic { get; set; }
        [JsonProperty("IsEthical")]
        public bool EthicalManufacturing { get; set; }
        [JsonProperty("IsKosher")]
        public bool Koscher { get; set; }

    }
}
