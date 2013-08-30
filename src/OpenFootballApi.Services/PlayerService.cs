using System;
using System.Linq;
using OpenFootballApi.DTO;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

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

        public object Post(Player request)
        {
            if (request.Id <= 0)
                Db.Insert(request);
            else
                Db.Update(request);

            return request;
        }

        public object Get(AllPlayers request)
        {
            return Db.Select<Player>().ToList();
        }
    }
}