using System.Threading.Tasks;

namespace Systembolaget.Releases.Indexer.Service
{
    public interface IHttpClientWrapper
    {
        Task<string> GetData();
    }
}
