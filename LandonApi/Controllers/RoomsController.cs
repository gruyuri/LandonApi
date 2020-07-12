using LandonApi.Models;
using LandonApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Controllers
{

    [Route("/[controller]")]
    [ApiController]
    public class RoomsController: ControllerBase
    {
        private readonly IRoomService dbContext;

        public RoomsController(IRoomService context)
        {
            dbContext = context;
        }


        [HttpGet(Name = nameof(GetAllRooms))]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Collection<Room>>> GetAllRooms()
        {
            var rooms = await dbContext.GetRoomsAsync();

            var collection = new Collection<Room>
            {
                Self = Link.ToCollection(nameof(GetAllRooms)),
                Value = rooms.ToArray()
            };

            return collection;
        }

        [HttpGet("{roomId}", Name = nameof(GetRoomById))]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<Room>> GetRoomById(Guid roomId)
        {
            var room = await dbContext.GetRoomAsync(roomId);

            if (room == null)
                return NotFound();

            return room;
        }
    }
}
