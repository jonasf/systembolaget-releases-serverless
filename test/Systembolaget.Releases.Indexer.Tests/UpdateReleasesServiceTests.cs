using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Systembolaget.Releases.Indexer.DataSource;
using Systembolaget.Releases.Indexer.Dto;
using Systembolaget.Releases.Indexer.Service;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NSubstitute;
using Xunit;

namespace Systembolaget.Releases.Indexer.Tests
{
    public class UpdateReleasesServiceTests
    {
        private readonly UpdateReleasesService _sut;
        private readonly IBeverageDataService _beverageDataService;
        private readonly IReleasesDataSource _releasesDataSource;

        private const string BeerGroup = "öl";
        private const string WhiteWhineGroup = "Vitt vin";
        private const string WhiskyGroup = "Whisky";

        public UpdateReleasesServiceTests()
        {
            _beverageDataService = Substitute.For<IBeverageDataService>();
            _releasesDataSource = Substitute.For<IReleasesDataSource>();
            _sut = new UpdateReleasesService(_beverageDataService, _releasesDataSource);    
        }

        [Fact]
        public async Task Should_Get_Beverage_Data()
        {
            await _sut.UpdateAsync();
            await _beverageDataService.Received(1).GetBeverageData();
        }

        [Fact]
        public async Task Should_Group_Beverages_By_Date_And_Group()
        {
            var beverages = new List<Beverage>
            {
                CreateBeverage(DateTime.Now.AddDays(10), BeerGroup),
                CreateBeverage(DateTime.Now.AddDays(10), BeerGroup),
                CreateBeverage(DateTime.Now.AddDays(12), BeerGroup),
                CreateBeverage(DateTime.Now.AddDays(12), WhiteWhineGroup),
                CreateBeverage(DateTime.Now.AddDays(12), WhiteWhineGroup),
                CreateBeverage(DateTime.Now.AddDays(15), WhiteWhineGroup),
                CreateBeverage(DateTime.Now.AddDays(17), WhiteWhineGroup),
                CreateBeverage(DateTime.Now.AddDays(15), WhiskyGroup),
                CreateBeverage(DateTime.Now.AddDays(20), WhiskyGroup),
                CreateBeverage(DateTime.Now.AddDays(20), WhiskyGroup),
            };
            _beverageDataService.GetBeverageData().Returns(beverages);

            await _sut.UpdateAsync();

            await _releasesDataSource.Received().UpdateReleases(Arg.Is<IEnumerable<Release>>(s => ValidateDateAndSubGroupGrouping(s)));
        }

        [Fact]
        public async Task Should_Not_Include_Past_Releases()
        {
            var beverages = new List<Beverage>
            {
                CreateBeverage(DateTime.Now.AddDays(10), BeerGroup),
                CreateBeverage(DateTime.Now.AddDays(10), BeerGroup),
                CreateBeverage(DateTime.Now.AddDays(-2), BeerGroup),
                CreateBeverage(DateTime.Now.AddDays(12), WhiteWhineGroup),
                CreateBeverage(DateTime.Now.AddDays(12), WhiteWhineGroup),
                CreateBeverage(DateTime.Now.AddDays(-1), WhiteWhineGroup),
                CreateBeverage(DateTime.Now.AddDays(17), WhiteWhineGroup),
                CreateBeverage(DateTime.Now.AddDays(-15), WhiskyGroup),
                CreateBeverage(DateTime.Now.AddDays(20), WhiskyGroup),
                CreateBeverage(DateTime.Now.AddDays(20), WhiskyGroup),
            };
            _beverageDataService.GetBeverageData().Returns(beverages);

            await _sut.UpdateAsync();

            await _releasesDataSource.Received().UpdateReleases(Arg.Is<IEnumerable<Release>>(s => ValidateExlusionOfOldReleases(s)));
        }

        private bool ValidateExlusionOfOldReleases(IEnumerable<Release> releases)
        {
            Assert.Equal(4, releases.Count());
            Assert.Equal(1, releases.Count(s => s.Group == BeerGroup));
            Assert.Equal(2, releases.Count(s => s.Group == WhiteWhineGroup));
            Assert.Equal(1, releases.Count(s => s.Group == WhiskyGroup));
            return true;
        }

        private bool ValidateDateAndSubGroupGrouping(IEnumerable<Release> releases)
        {
            Assert.Equal(7, releases.Count());
            Assert.Equal(2, releases.Count(s => s.Group == BeerGroup));
            Assert.Equal(3, releases.Count(s => s.Group == WhiteWhineGroup));
            Assert.Equal(2, releases.Count(s => s.Group == WhiskyGroup));
            return true;
        }

        private Beverage CreateBeverage(DateTime releaseDate, string group)
        {
            return new Beverage
            {
                ReleaseDate = releaseDate.ToString("yyyy-MM-dd"),
                Group = group
            };
        }
    }
}
