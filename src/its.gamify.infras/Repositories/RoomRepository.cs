﻿using its.gamify.core.Repositories;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.infras.Datas;

namespace its.gamify.infras.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(AppDbContext context, ICurrentTime currentTime, IClaimsService claimsService)
            : base(context, currentTime, claimsService)
        {
        }
    }
}
