using System;
using System.Threading.Tasks;

namespace Systembolaget.Releases.Indexer.Service
{
    public interface IUpdateReleasesService
    {
        Task UpdateAsync();
    }

    public class UpdateReleasesService : IUpdateReleasesService
    {
        public async Task UpdateAsync()
        {
            Console.WriteLine("Logging from console");
        }
    }
}
