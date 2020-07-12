using AutoMapper;
using AutoMapper.QueryableExtensions;
using LandonApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Services
{
    public class DefaultRoomService : IRoomService
    {
        private readonly HotelApiDbContext dbContext;
        private readonly IConfigurationProvider mappingConfiguration;

        public DefaultRoomService(HotelApiDbContext context, IConfigurationProvider mappingProvider)
        {
            dbContext = context;
            this.mappingConfiguration = mappingProvider;
        }
        public async Task<Room> GetRoomAsync(Guid id)
        {
            var entity = await dbContext.Rooms.SingleOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return null;

            var mapper = mappingConfiguration.CreateMapper();
            return mapper.Map<Room>(entity);
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            var query = dbContext.Rooms.ProjectTo<Room>(mappingConfiguration);

            return await query.ToArrayAsync();


        }
    }
}
