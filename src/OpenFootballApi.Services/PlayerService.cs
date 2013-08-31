using System;
using System.Linq;
using OpenFootballApi.DTO;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using OpenFootballApi.Services.Extensions;

namespace OpenFootballApi.Services
{
    public class PlayerService : Service
    {
        public object Get(Player request)
        {
            var p = Db.QueryById<Player>(request.Id);

            if (p == null)
                throw new Exception("Player not found.");

            return p;
        }

        public object Delete(Player request)
        {
            Db.Delete(request);
            return null;
        }

        public object Post(Player request)
        {
            Db.SaveAndGetIntId<Player>(request);
            return request;
        }

        public void Options(Player request) { }

        public object Get(AllPlayers request)
        {
            return Db.Select<Player>().ToList();
        }
    }
}