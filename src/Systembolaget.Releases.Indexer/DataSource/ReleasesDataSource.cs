using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Systembolaget.Releases.Indexer.Dto;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;

namespace Systembolaget.Releases.Indexer.DataSource
{
    public class ReleasesDataSource : IReleasesDataSource
    {
        private Table _table;

        public ReleasesDataSource()
        {
            IAmazonDynamoDB dynamoDbClient = new AmazonDynamoDBClient(new AmazonDynamoDBConfig
            {
                ServiceURL = "http://localhost:8000"
            });
            _table = Table.LoadTable(dynamoDbClient, "SystembolagetReleases");
        }

        public async Task UpdateReleases(IEnumerable<Release> releases)
        {
            foreach (var release in releases)
            {
                var beverages = new DynamoDBList();
                foreach (var beverage in release.Beverages)
                {
                    beverages.Add(JsonSerializer.Serialize(beverage));
                }

                var document = new Document();
                document["ReleaseDate"] = release.ReleaseDate;
                document["Group"] = release.Group;
                document["NumberOfBeverages"] = release.NumberOfBeverages;
                document["Beverages"] = beverages;

                await _table.PutItemAsync(document);
            }
        }
    }
}