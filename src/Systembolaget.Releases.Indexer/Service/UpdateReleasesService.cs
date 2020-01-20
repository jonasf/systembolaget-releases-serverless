using System;
using System.Collections.Generic;
using System.Linq;
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

            var allReleases = beverages.GroupBy(x => new { x.ReleaseDate, x.Group }, (key, group) => new Release
            {
                ReleaseDate = DateTime.Parse(key.ReleaseDate),
                Group = key.Group,
                Beverages = group
            });

            var futureReleases = allReleases.Where(x => x.ReleaseDate > DateTime.Now.AddDays(-1));

            await _releasesDataSource.UpdateReleases(futureReleases);
        }
    }
}