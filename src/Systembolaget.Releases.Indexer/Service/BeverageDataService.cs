using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            return JsonConvert.DeserializeObject<IEnumerable<Beverage>>(apiResponse); 
        }
    }
}