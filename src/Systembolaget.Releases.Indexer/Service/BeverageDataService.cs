using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Systembolaget.Releases.Indexer.Dto;

namespace Systembolaget.Releases.Indexer.Service
{
    public class BeverageDataService : IBeverageDataService
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public BeverageDataService(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<IEnumerable<Beverage>> GetBeverageData()
        {
            var apiResponse = await _httpClientWrapper.GetData();
            var cleanedApiResponse = apiResponse.Replace("&", "&amp;");
            var serializer = new XmlSerializer(typeof(SystembolagetApiDataRoot));
            var data = (SystembolagetApiDataRoot)serializer.Deserialize(new StringReader(cleanedApiResponse));
            return data.Beverages;
        }
    }
}