using System;

namespace Systembolaget.Releases.Indexer
{
    public static class FunctionConfig
    {
        static FunctionConfig()
        {
            DatabaseEndpoint = Environment.GetEnvironmentVariable("DATABASE_ENDPOINT");
        }

        public static string DatabaseEndpoint { get; }
    }
}
