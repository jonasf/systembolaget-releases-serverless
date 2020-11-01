using System;

namespace Systembolaget.Releases.Indexer
{
    public static class FunctionConfig
    {
        static FunctionConfig()
        {
            DatabaseEndpoint = Environment.GetEnvironmentVariable("DATABASE_ENDPOINT");
            SystembolagetApiKey = Environment.GetEnvironmentVariable("SYSTEMBOLAGET_API_KEY");
        }

        public static string DatabaseEndpoint { get; }
        public static string SystembolagetApiKey { get; }
    }
}
