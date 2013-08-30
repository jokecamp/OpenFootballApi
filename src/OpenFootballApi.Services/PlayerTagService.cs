﻿using System;
using System.Linq;
using OpenFootballApi.DTO;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using OpenFootballApi.Services.Extensions;

namespace OpenFootballApi.Services
{
    public class PlayerTagService : Service
    {
        public object Get(PlayerTag request)
        {
            var pt = Db.QueryById<PlayerTag>(request.Id);

            if (pt == null)
                throw new Exception("PlayerTag not found.");

            return pt;
        }

        public object Post(PlayerTag request)
        {
            if (request.Id <= 0)
            {
                request.Count = 1;
                Db.InsertAndGetIntId<PlayerTag>(request);
            }
            else
            {
                request.Count++;
                Db.Update(request);
            }

            return request;
        }

        public object Get(AllPlayerTags request)
        {
            return Db.Select<PlayerTag>().ToList();
        }
    }
}
