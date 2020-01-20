using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Systembolaget.Releases.Indexer.DataSource;
using Systembolaget.Releases.Indexer.Service;

namespace Systembolaget.Releases.Indexer
{
    public class Function
    {
        private static ServiceProvider _serviceProvider;

        static Function()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUpdateReleasesService, UpdateReleasesService>();
            serviceCollection.AddTransient<IHttpClientWrapper, HttpClientWrapper>();
            serviceCollection.AddTransient<IBeverageDataService, BeverageDataService>();
            serviceCollection.AddTransient<IReleasesDataSource, ReleasesDataSource>();
        }

        /// <summary>
        /// The main entry point for the custom runtime.
        /// </summary>
        /// <param name="args"></param>
        private static async Task Main(string[] args)
        {
            Func<string, ILambdaContext, Task<string>> func = FunctionHandler;
            using(var handlerWrapper = HandlerWrapper.GetHandlerWrapper(func, new JsonSerializer()))
            using(var bootstrap = new LambdaBootstrap(handlerWrapper))
            {
                await bootstrap.RunAsync();
            }
        }

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        ///
        /// To use this handler to respond to an AWS event, reference the appropriate package from 
        /// https://github.com/aws/aws-lambda-dotnet#events
        /// and change the string input parameter to the desired event type.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<string> FunctionHandler(string input, ILambdaContext context)
        {
            var updateReleasesService = _serviceProvider.GetService<IUpdateReleasesService>();
            await updateReleasesService.UpdateAsync();
            return input?.ToUpper();
        }
    }
}
