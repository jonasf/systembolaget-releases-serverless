using System.Threading.Tasks;

namespace Systembolaget.Releases.Indexer.Service
{
    public interface IUpdateReleasesService
    {
        Task UpdateAsync();
    }
}
