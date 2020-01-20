using System.Collections.Generic;
using System.Xml.Serialization;

namespace Systembolaget.Releases.Indexer.Dto
{
    [XmlRoot(ElementName = "artiklar")]
    public class SystembolagetApiDataRoot
    {
        [XmlElement(ElementName = "artikel")]
        public List<Beverage> Beverages { get; set; }
    }
}
