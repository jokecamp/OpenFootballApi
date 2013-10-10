
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;
using OpenFootballApi.DTO.Interfaces;
using System;
using System.Runtime.Serialization;
using OpenFootballApi.DTO.Attributes;

namespace OpenFootballApi.DTO
{
    /// <summary>
    /// Serves as our main Player DOT (model or POCO) and as a request for an indiviual Player.
    /// </summary>
    [Table]
    [Route("/players")]
    [Route("/players/{Id}")]
    public class Player : IReturn<Player>, IWithId<int>, ITimestamped, ISoftDelete
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string DisplayName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        public decimal HeightInMeters { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [IgnoreDataMember]
        public bool Deleted { get; set; }
    }

    [Route("/players", "GET")]
    public class GetAllPlayers : IReturn<List<Player>> { }

    /// <summary>
    /// Extended player data besides the basics
    /// </summary>
    public class PlayerData
    {
        public Player Player { get; set; }
        public List<PlayerTag> PlayerTags { get; set; }
        public List<Tag> Tags { get; set; }
        public List<ItemLink> Links { get; set; }
    }

    [Route("/playerdata/{PlayerId}")]
    public class GetPlayerData : IReturn<PlayerData>
    {
        public int PlayerId { get; set; }
    }
}
