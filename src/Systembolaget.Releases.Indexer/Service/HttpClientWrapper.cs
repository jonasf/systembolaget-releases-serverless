using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Systembolaget.Releases.Indexer.Service
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _client;

        public HttpClientWrapper()
        {
            _client = new HttpClient();    
        }

        public async Task<string> GetData()
        {
            try
            {
                return await _client.GetStringAsync("https://www.systembolaget.se/api/assortment/products/xml").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}