using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Permissions.Database
{
    internal static class SeedBuilder
    {
        public static void SeedBuild(this ModelBuilder builder)
        {
            var assembly = typeof(SeedBuilder).Assembly;

            foreach (var item in assembly.GetTypes())
            {
                var isTarget = item
                    .GetInterfaces()
                    .SingleOrDefault(_ => _ == typeof(ISeedable)) != null;

                if (isTarget)
                {
                    var seedable = Activator.CreateInstance(item) as ISeedable;
                    seedable.Seed(builder);
                }
            }
        }
    }
}
