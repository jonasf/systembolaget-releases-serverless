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
            Assert.Equal(159.33m, beverage.PricePerLiter);
            Assert.Equal("2007-01-11", beverage.ReleaseDate);
            Assert.False(beverage.Discontinued);
            Assert.Equal("Öl", beverage.Group);
            Assert.Equal("Ale belgisk stil", beverage.Type);
            Assert.Equal("Belgisk mörk ale", beverage.Style);
            Assert.Equal("Flaska", beverage.Packaging);
            Assert.Equal("Kapsyl", beverage.Seal);
            Assert.Equal("Flandern", beverage.Origin);
            Assert.Equal("Belgien", beverage.OriginCountry);
            Assert.Equal("Chimay", beverage.Producer);
            Assert.Equal("TOMP Beer Wine & Spirits AB", beverage.Supplier);
            Assert.Equal("2006", beverage.Vintage);
            Assert.Equal("2007", beverage.SampledYear);
            Assert.Equal("9.00%", beverage.AlcoholContent);
            Assert.Equal("BS", beverage.ProductRangeAbbreviation);
            Assert.Equal("Ordervaror", beverage.ProductRange);
            Assert.False(beverage.Organic);
            Assert.False(beverage.EthicalManufacturing);
            Assert.False(beverage.Koscher);
        }

        private Task<string> CreateSystembolagetApiData()
        {
            return Task.FromResult(@"<artiklar xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                    <skapad-tid>2020-01-17 05:12</skapad-tid>
                                    <info>
                                    <meddelande>Läs detta viktiga meddelande. Det är oerhört viktigt!</meddelande>
                                    </info>
                                    <artikel>
                                    <nr>8286806</nr>
                                    <Artikelid>248843</Artikelid>
                                    <Varnummer>82868</Varnummer>
                                    <Namn>Chimay Blå</Namn>
                                    <Namn2>Grand Réserve</Namn2>
                                    <Prisinklmoms>239.00</Prisinklmoms>
                                    <Volymiml>1500.00</Volymiml>
                                    <PrisPerLiter>159.33</PrisPerLiter>
                                    <Saljstart>2007-01-11</Saljstart>
                                    <Utgått>0</Utgått>
                                    <Varugrupp>Öl</Varugrupp>
                                    <Typ>Ale belgisk stil</Typ>
                                    <Stil>Belgisk mörk ale</Stil>
                                    <Forpackning>Flaska</Forpackning>
                                    <Forslutning>Kapsyl</Forslutning>
                                    <Ursprung>Flandern</Ursprung>
                                    <Ursprunglandnamn>Belgien</Ursprunglandnamn>
                                    <Producent>Chimay</Producent>
                                    <Leverantor>TOMP Beer Wine & Spirits AB</Leverantor>
                                    <Argang>2006</Argang>
                                    <Provadargang>2007</Provadargang>
                                    <Alkoholhalt>9.00%</Alkoholhalt>
                                    <Sortiment>BS</Sortiment>
                                    <SortimentText>Ordervaror</SortimentText>
                                    <Ekologisk>0</Ekologisk>
                                    <Etiskt>0</Etiskt>
                                    <Koscher>0</Koscher>
                                    </artikel>
                                    <artikel>
                                    <nr>165603</nr>
                                    <Artikelid>1103641</Artikelid>
                                    <Varnummer>1656</Varnummer>
                                    <Namn>Westmalle</Namn>
                                    <Namn2>Tripel</Namn2>
                                    <Prisinklmoms>30.90</Prisinklmoms>
                                    <Volymiml>330.00</Volymiml>
                                    <PrisPerLiter>93.64</PrisPerLiter>
                                    <Saljstart>2016-12-01</Saljstart>
                                    <Utgått>0</Utgått>
                                    <Varugrupp>Öl</Varugrupp>
                                    <Typ>Ale belgisk stil</Typ>
                                    <Stil>Trippel</Stil>
                                    <Forpackning>Flaska</Forpackning>
                                    <Forslutning>Kronkapsyl</Forslutning>
                                    <Ursprung/>
                                    <Ursprunglandnamn>Belgien</Ursprunglandnamn>
                                    <Producent>Abbey of Westmalle</Producent>
                                    <Leverantor>Galatea AB</Leverantor>
                                    <Argang/>
                                    <Provadargang/>
                                    <Alkoholhalt>9.50%</Alkoholhalt>
                                    <Sortiment>BS</Sortiment>
                                    <SortimentText>Ordervaror</SortimentText>
                                    <Ekologisk>0</Ekologisk>
                                    <Etiskt>0</Etiskt>
                                    <Koscher>0</Koscher>
                                    <RavarorBeskrivning>Kornmalt och humle.</RavarorBeskrivning>
                                    </artikel>
                                    <artikel>
                                    <nr>49102</nr>
                                    <Artikelid>2325650</Artikelid>
                                    <Varnummer>491</Varnummer>
                                    <Namn>Bowmore</Namn>
                                    <Namn2>12 Years</Namn2>
                                    <Prisinklmoms>199.00</Prisinklmoms>
                                    <Volymiml>350.00</Volymiml>
                                    <PrisPerLiter>568.57</PrisPerLiter>
                                    <Saljstart>2017-09-01</Saljstart>
                                    <Utgått>0</Utgått>
                                    <Varugrupp>Whisky</Varugrupp>
                                    <Typ>Maltwhisky</Typ>
                                    <Stil/>
                                    <Forpackning>Flaska</Forpackning>
                                    <Forslutning/>
                                    <Ursprung>Skottland</Ursprung>
                                    <Ursprunglandnamn>Storbritannien</Ursprunglandnamn>
                                    <Producent>Jim Beam Brands</Producent>
                                    <Leverantor>Edrington Sweden AB</Leverantor>
                                    <Argang/>
                                    <Provadargang/>
                                    <Alkoholhalt>40.00%</Alkoholhalt>
                                    <Sortiment>FS</Sortiment>
                                    <SortimentText>Fast sortiment</SortimentText>
                                    <Ekologisk>0</Ekologisk>
                                    <Etiskt>0</Etiskt>
                                    <Koscher>0</Koscher>
                                    <RavarorBeskrivning>Kornmalt.</RavarorBeskrivning>
                                    </artikel>
                                    </artiklar>");
        }
    }
}
