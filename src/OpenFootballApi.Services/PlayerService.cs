using System;
using System.Linq;
using OpenFootballApi.DTO;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using OpenFootballApi.Services.Extensions;
using System.Collections.Generic;

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

        /// <summary>
        /// Get all players and their asscociated tags
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public object Get(PlayerReport request)
        {
            //todo: better query that will scale
            var players = Db.Select<Player>().ToList();
            var playertags = Db.Select<PlayerTag>().ToList();
            var tags = Db.Select<Tag>().ToDictionary(x => x.Id, y => y);

            var reports = players.Select(x => new PlayerReport()
            {
                Player = x,
                Tags = new List<PlayerTagReport>()
            }).ToList();

            foreach (var r in reports)
            {
                var pts = playertags.Where(x => x.PlayerId == r.Player.Id).Select(y => new PlayerTagReport()
                {
                    PlayerTag = y,
                    Tag = tags[y.TagId]
                }).ToList();

                r.Tags.AddRange(pts);
            }

            return reports;
        }
    }
}