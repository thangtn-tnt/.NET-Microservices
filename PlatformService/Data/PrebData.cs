using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrebData
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();

            SeedData(scope.ServiceProvider.GetService<ApplicationDbContext>());
        }

        private static void SeedData(ApplicationDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Seeding Data ........");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SqlServerExpress", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );
            }
            else
            {
                Console.WriteLine("Already have data ........");
            }
        }
    }
}