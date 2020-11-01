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
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", FunctionConfig.SystembolagetApiKey);    
        }

        public async Task<string> GetData()
        {
            try
            {
                return await _client.GetStringAsync("https://api-extern.systembolaget.se/product/v1/product").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}