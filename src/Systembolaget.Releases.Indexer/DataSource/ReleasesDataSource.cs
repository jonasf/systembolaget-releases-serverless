using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Systembolaget.Releases.Indexer.Dto;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;

namespace Systembolaget.Releases.Indexer.DataSource
{
    public class ReleasesDataSource : IReleasesDataSource
    {
        public ReleasesDataSource()
        {
#if DEBUG
            var config = new AmazonDynamoDBConfig
            {
                ServiceURL = "http://localhost:8000"
            };
            IAmazonDynamoDB dynamoDbClient = new AmazonDynamoDBClient(config);
#elif RELEASE
            var config = new AmazonDynamoDBConfig
            {
                ServiceURL = FunctionConfig.DatabaseEndpoint
            };
            IAmazonDynamoDB dynamoDbClient = new AmazonDynamoDBClient(new EnvironmentVariablesAWSCredentials(), config);
#endif
            _table = Table.LoadTable(dynamoDbClient, "SystembolagetReleases");
        }

        private readonly Table _table;

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