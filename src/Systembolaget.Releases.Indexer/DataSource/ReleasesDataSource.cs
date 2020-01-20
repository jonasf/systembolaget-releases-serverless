using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Systembolaget.Releases.Indexer.Dto;

namespace Systembolaget.Releases.Indexer.DataSource
{
    public class ReleasesDataSource : IReleasesDataSource
    {
        public Task UpdateReleases(IEnumerable<Release> releases)
        {
            // TODO: Actually save the data
            foreach (var release in releases)
            {
                Console.WriteLine($"Release for date {release.ReleaseDate} in group {release.Group}");
                foreach (var beverage in release.Beverages)
                {
                    ObjectDump.Write(beverage);
                }
            }

            return Task.CompletedTask;
        }
    }

    public static class ObjectDump
    {
        public static void Write(object obj)
        {
            if (obj == null)
            {
                Console.WriteLine("Object is null");
                return;
            }

            var props = GetProperties(obj);

            if (props.Count > 0)
            {
                Console.WriteLine("-------------------------");
            }

            foreach (var prop in props)
            {
                Console.Write(prop.Key);
                Console.Write(": ");
                Console.WriteLine(prop.Value);
            }
        }

        private static Dictionary<string, string> GetProperties(object obj)
        {
            var props = new Dictionary<string, string>();
            if (obj == null)
                return props;

            var type = obj.GetType();
            foreach (var prop in type.GetProperties())
            {
                var val = prop.GetValue(obj, new object[] { });
                var valStr = val == null ? "" : val.ToString();
                props.Add(prop.Name, valStr);
            }

            return props;
        }
    }
}