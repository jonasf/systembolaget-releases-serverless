using System.Collections.Generic;
using System.Threading.Tasks;
using Systembolaget.Releases.Indexer.Dto;

namespace Systembolaget.Releases.Indexer.DataSource
{
    public interface IReleasesDataSource
    {
        Task UpdateReleases(IEnumerable<Release> releases);
    }
}
