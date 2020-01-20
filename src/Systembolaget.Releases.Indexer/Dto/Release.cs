using System;
using System.Collections.Generic;

namespace Systembolaget.Releases.Indexer.Dto
{
    public class Release
    {
        public DateTime ReleaseDate { get; set; }
        public string Group { get; set; }
        public IEnumerable<Beverage> Beverages { get; set; }
    }
}
