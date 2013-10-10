using System;
using System.Linq;
using OpenFootballApi.DTO;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using OpenFootballApi.Services.Extensions;
using System.Collections.Generic;

namespace OpenFootballApi.Services
{
    public class PlayerService : CrudService<Player, GetAllPlayers>
    {
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

        public override void PreSave(Player request)
        {
            if (string.IsNullOrWhiteSpace(request.DisplayName))
            {
                request.DisplayName = string.Format("{0} {1}", request.Firstname, request.Lastname).Trim();
            }
        }

        public object Get(GetPlayerData request)
        {
            var data = new PlayerData()
            {
                Player = Db.GetById<Player>(request.PlayerId),
                Links = Db.Where<ItemLink>(x => x.ItemType == ItemType.Player).ToList(),
                PlayerTags = Db.Where<PlayerTag>(x => x.PlayerId == request.PlayerId).ToList(),
            };
            data.Tags = Db.Where<Tag>(x => data.PlayerTags.Select(t => t.TagId).Contains(x.Id)).ToList();

            return data;
        }
    }
}