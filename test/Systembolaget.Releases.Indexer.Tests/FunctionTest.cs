using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using Systembolaget.Releases.Indexer;
using Amazon.Lambda.CloudWatchLogsEvents;

namespace Systembolaget.Releases.Indexer.Tests
{
    public class FunctionTest
    {
        [Fact(Skip = "Integration test")]
        public async Task InvokeFunction()
        {

            // Invoke the lambda function.
            await Function.FunctionHandler(new CloudWatchLogsEvent());
        }
    }
}
