using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gisys.WebApi.Repository.Gisys
{
    public static class SeedDb
    {
        public static void Populate(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<GisysContext>());
            }
        }

        public static void SeedData(GisysContext context)
        {
            System.Console.WriteLine("\n\nApplying Migrations ...\n\n");

            context.Database.Migrate();

            if (!context.Consultants.Any() )
            {

                System.Console.WriteLine("\n\nAdding data - Seeding ...\n\n");

                var consultant = new Consultant { ConsultantId = Guid.NewGuid(), Name = "James Bond", YearOfEmployment = 4, ChargedHours = 150 };
                context.Consultants.Add(consultant);

                context.SaveChanges();

                System.Console.WriteLine("\n\nMigrations worked !! ...\n\n");
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}
