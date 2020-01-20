using System;

namespace Systembolaget.Releases.Indexer.Dto
{
    public class Beverage
	{
        //<nr>43301</nr>
        public int ArticleNumber { get; set; }
        //<Artikelid>7303</Artikelid>
        public int ArticleId { get; set; }
        //<Varnummer>433</Varnummer>
        public string PartNumber { get; set; }
        //<Namn>Bowmore</Namn>
        public string Name { get; set; }
        //<Namn2>12 Years</Namn2>
        public string SecondaryName { get; set; }
        //<Prisinklmoms>399.00</Prisinklmoms>
        public decimal PriceIncVat { get; set; }
        //<Volymiml>700.00</Volymiml>
        public decimal VolumeMl { get; set; }
        //<PrisPerLiter>570.00</PrisPerLiter>
        public decimal PricePerLiter { get; set; }
        //<Saljstart>1995-02-13</Saljstart>
        public string ReleaseDate { get; set; }
        //<Utgått>0</Utgått>
        public bool Discontinued { get; set; }
        //<Varugrupp>Whisky</Varugrupp>
        public string Group { get; set; }
        //<Typ>Maltwhisky</Typ>
        public string Type { get; set; }
        //<Stil/>
        public string Style { get; set; }
        //<Forpackning>Flaska</Forpackning>
        public string Packaging { get; set; }
        //<Forslutning/>
        public string Seal { get; set; }
        //<Ursprung>Skottland</Ursprung>
        public string Origin { get; set; }
        //<Ursprunglandnamn>Storbritannien</Ursprunglandnamn>
        public string OriginCountry { get; set; }
        //<Producent>Morrison's Bowmore Distillery</Producent>
        public string Producer { get; set; }
        //<Leverantor>Edrington Sweden AB</Leverantor>
        public string Supplier { get; set; }
        //<Argang/>
        public int Vintage { get; set; }
        //<Provadargang/>
        public int SampledYear { get; set; }
        //<Alkoholhalt>40.00%</Alkoholhalt>
        public decimal AlcoholContent { get; set; }
        //<Sortiment>FS</Sortiment>
        public string ProductRangeAbbreviation { get; set; }
        //<SortimentText>Fast sortiment</SortimentText>
        public string ProductRange { get; set; }
        //<Ekologisk>0</Ekologisk>
        public bool Organic { get; set; }
        //<Etiskt>0</Etiskt>
        public bool EthicalManufacturing { get; set; }
        //<Koscher>0</Koscher>
        public bool Koscher { get; set; }

    }
}
