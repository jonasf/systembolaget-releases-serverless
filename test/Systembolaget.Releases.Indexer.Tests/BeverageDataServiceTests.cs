using System.Linq;
using System.Threading.Tasks;
using Systembolaget.Releases.Indexer.Service;
using NSubstitute;
using Xunit;

namespace Systembolaget.Releases.Indexer.Tests
{
    public class BeverageDataServiceTests
    {
        private readonly IHttpClientWrapper _httpClientWrapper;
        private readonly BeverageDataService _sut;

        public BeverageDataServiceTests()
        {
            _httpClientWrapper = Substitute.For<IHttpClientWrapper>();
            _httpClientWrapper.GetData().Returns(CreateSystembolagetApiData());
            _sut = new BeverageDataService(_httpClientWrapper);   
        }

        [Fact]
        public async Task Should_Parse_Article_Data()
        {
            var result = await _sut.GetBeverageData();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async Task Should_Map_Properties()
        {
            var result = await _sut.GetBeverageData();

            Assert.NotNull(result);
            var beverage = result.First();
            Assert.Equal(8286806, beverage.ArticleNumber);
            Assert.Equal(248843, beverage.ArticleId);
            Assert.Equal(82868, beverage.PartNumber);
            Assert.Equal("Chimay Blå", beverage.Name);
            Assert.Equal("Grand Réserve", beverage.SecondaryName);
            Assert.Equal(239.00m, beverage.PriceIncVat);
            Assert.Equal(1500.00m, beverage.VolumeMl);
            Assert.Equal("2007-01-11T00:00:00", beverage.ReleaseDate);
            Assert.False(beverage.Discontinued);
            Assert.Equal("Öl", beverage.Group);
            Assert.Equal("Ale belgisk stil", beverage.Type);
            Assert.Equal("Belgisk mörk ale", beverage.Style);
            Assert.Equal("Flaska", beverage.Packaging);
            Assert.Equal("Kapsyl", beverage.Seal);
            Assert.Equal("Belgien", beverage.OriginCountry);
            Assert.Equal("Chimay", beverage.Producer);
            Assert.Equal("TOMP Beer Wine & Spirits AB", beverage.Supplier);
            Assert.Equal("2006", beverage.Vintage);
            Assert.Equal(9.00m, beverage.AlcoholContent);
            Assert.Equal("BS", beverage.ProductRangeAbbreviation);
            Assert.Equal("Ordervaror", beverage.ProductRange);
            Assert.False(beverage.Organic);
            Assert.False(beverage.EthicalManufacturing);
            Assert.False(beverage.Koscher);
        }

        private Task<string> CreateSystembolagetApiData()
        {
            return Task.FromResult(@"[{
                ""ProductId"": ""248843"",
                ""ProductNumber"": ""8286806"",
                ""ProductNameBold"": ""Chimay Blå"",
                ""ProductNameThin"": ""Grand Réserve"",
                ""Category"": ""Öl"",
                ""ProductNumberShort"": ""82868"",
                ""ProducerName"": ""Chimay"",
                ""SupplierName"": ""TOMP Beer Wine & Spirits AB"",
                ""IsKosher"": false,
                ""BottleTextShort"": ""Flaska"",
                ""Seal"": ""Kapsyl"",
                ""RestrictedParcelQuantity"": 0,
                ""IsOrganic"": false,
                ""IsEthical"": false,
                ""EthicalLabel"": null,
                ""IsWebLaunch"": false,
                ""SellStartDate"": ""2007-01-11T00:00:00"",
                ""IsCompletelyOutOfStock"": false,
                ""IsTemporaryOutOfStock"": false,
                ""AlcoholPercentage"": 9.00,
                ""Volume"": 1500.00,
                ""Price"": 239.00,
                ""Country"": ""Belgien"",
                ""OriginLevel1"": null,
                ""OriginLevel2"": null,
                ""Vintage"": 2006,
                ""SubCategory"": ""Öl"",
                ""Type"": ""Ale belgisk stil"",
                ""Style"": ""Belgisk mörk ale"",
                ""AssortmentText"": ""Ordervaror"",
                ""BeverageDescriptionShort"": ""Öl, Ale, Belgisk mörk ale"",
                ""Usage"": null,
                ""Taste"": null,
                ""Assortment"": ""BS"",
                ""RecycleFee"": 0.00,
                ""IsManufacturingCountry"": true,
                ""IsRegionalRestricted"": false,
                ""IsInStoreSearchAssortment"": null,
                ""IsNews"": false
            },{
                ""ProductId"": ""1103641"",
                ""ProductNumber"": ""165603"",
                ""ProductNameBold"": ""Westmalle"",
                ""ProductNameThin"": ""Tripel"",
                ""Category"": ""Öl"",
                ""ProductNumberShort"": ""1656"",
                ""ProducerName"": ""Abbey of Westmalle"",
                ""SupplierName"": ""Galatea AB"",
                ""IsKosher"": false,
                ""BottleTextShort"": ""Flaska"",
                ""Seal"": ""Kronkapsyl"",
                ""RestrictedParcelQuantity"": 0,
                ""IsOrganic"": false,
                ""IsEthical"": false,
                ""EthicalLabel"": null,
                ""IsWebLaunch"": false,
                ""SellStartDate"": ""2020-05-06T00:00:00"",
                ""IsCompletelyOutOfStock"": false,
                ""IsTemporaryOutOfStock"": false,
                ""AlcoholPercentage"": 9.50,
                ""Volume"": 330.00,
                ""Price"": 29.90,
                ""Country"": ""Belgien"",
                ""OriginLevel1"": null,
                ""OriginLevel2"": null,
                ""Vintage"": 0,
                ""SubCategory"": ""Öl"",
                ""Type"": ""Ale belgisk stil"",
                ""Style"": ""Trippel"",
                ""AssortmentText"": ""Tillfälligt sortiment"",
                ""BeverageDescriptionShort"": ""Öl, Ale, Trippel"",
                ""Usage"": ""Serveras vid 10-12°C till rätter av ljust kött eller lamm, eller till lagrade hårdostar."",
                ""Taste"": ""Nyanserad, fruktig, kryddig smak med liten sötma, inslag av kryddnejlika, aprikos, honung, banan, ljust bröd och citrus."",
                ""Assortment"": ""TSV"",
                ""RecycleFee"": 0.00,
                ""IsManufacturingCountry"": true,
                ""IsRegionalRestricted"": false,
                ""IsInStoreSearchAssortment"": null,
                ""IsNews"": false
            },{
                ""ProductId"": ""2325650"",
                ""ProductNumber"": ""49102"",
                ""ProductNameBold"": ""Bowmore"",
                ""ProductNameThin"": ""12 Years"",
                ""Category"": ""Sprit"",
                ""ProductNumberShort"": ""491"",
                ""ProducerName"": ""Jim Beam Brands"",
                ""SupplierName"": ""Edrington Sweden AB"",
                ""IsKosher"": false,
                ""BottleTextShort"": ""Flaska"",
                ""Seal"": null,
                ""RestrictedParcelQuantity"": 0,
                ""IsOrganic"": false,
                ""IsEthical"": false,
                ""EthicalLabel"": null,
                ""IsWebLaunch"": false,
                ""SellStartDate"": ""2017-09-01T00:00:00"",
                ""IsCompletelyOutOfStock"": false,
                ""IsTemporaryOutOfStock"": false,
                ""AlcoholPercentage"": 40.00,
                ""Volume"": 350.00,
                ""Price"": 209.00,
                ""Country"": ""Storbritannien"",
                ""OriginLevel1"": ""Skottland"",
                ""OriginLevel2"": ""Islay"",
                ""Vintage"": 0,
                ""SubCategory"": ""Whisky"",
                ""Type"": ""Maltwhisky"",
                ""Style"": null,
                ""AssortmentText"": ""Fast sortiment"",
                ""BeverageDescriptionShort"": ""Maltwhisky"",
                ""Usage"": ""Serveras rumstempererad."",
                ""Taste"": ""Nyanserad, tydligt rökig smak med fatkaraktär, inslag av ljunghonung, torkade aprikoser, jod, pomerans, vaniljfudge och tjära."",
                ""Assortment"": ""FS"",
                ""RecycleFee"": 0.00,
                ""IsManufacturingCountry"": true,
                ""IsRegionalRestricted"": false,
                ""IsInStoreSearchAssortment"": null,
                ""IsNews"": false
            }]");
        }
    }
}
