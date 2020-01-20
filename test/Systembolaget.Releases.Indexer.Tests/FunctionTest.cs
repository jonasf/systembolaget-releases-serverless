using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using Systembolaget.Releases.Indexer;

namespace Systembolaget.Releases.Indexer.Tests
{
    public class FunctionTest
    {
        [Fact(Skip = "Integration test")]
        public async Task TestToUpperFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var context = new TestLambdaContext();
            var upperCase = await Function.FunctionHandler("hello world", context);

            Assert.Equal("HELLO WORLD", upperCase);
        }
    }
}
