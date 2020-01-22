using System;
using System.Collections.Generic;
using System.Linq;

namespace Systembolaget.Releases.Indexer.Dto
{
    public class Release
    {
        public DateTime ReleaseDate { get; set; }
        public string Group { get; set; }
        public int NumberOfBeverages => Beverages.Count();
        public IEnumerable<Beverage> Beverages { get; set; }
    }
}
