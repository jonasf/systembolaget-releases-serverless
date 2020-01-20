using System.Collections.Generic;
using System.Threading.Tasks;
using Systembolaget.Releases.Indexer.Dto;

namespace Systembolaget.Releases.Indexer.Service
{
    public interface IBeverageDataService
    {
        Task<IEnumerable<Beverage>> GetBeverageData();
    }
}
