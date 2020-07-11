using LandonApi.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<HotelApiDbContext>());
        }
        public static async Task AddTestData(HotelApiDbContext context)
        {
            if (context.Rooms.Any())
            {
                return;
            }

            context.Rooms.Add(new RoomEntity
            {
                Id = Guid.NewGuid(),
                Name = "Oxford Suite",
                Rate = 10119
            });

            context.Rooms.Add(new RoomEntity
            {
                Id = Guid.NewGuid(),
                Name = "Driscoll Suite",
                Rate = 23959
            });

            await context.SaveChangesAsync();
        }
    }
}
