using System.Collections.Generic;
using System.Threading.Tasks;
using Systembolaget.Releases.Indexer.DataSource;
using Systembolaget.Releases.Indexer.Dto;

namespace Systembolaget.Releases.Indexer.Service
{
    public class UpdateReleasesService : IUpdateReleasesService
    {
        private readonly IBeverageDataService _beverageDataService;
        private readonly IReleasesDataSource _releasesDataSource;

        public UpdateReleasesService(IBeverageDataService beverageDataService, IReleasesDataSource releasesDataSource)
        {
            _beverageDataService = beverageDataService;
            _releasesDataSource = releasesDataSource;
        }

        public async Task UpdateAsync()
        {
            var beverages = await _beverageDataService.GetBeverageData();

            // TODO: group data
            var releases = new List<Release> { new Release { } };

            //save data
            await _releasesDataSource.UpdateReleases(releases);
        }
    }
}