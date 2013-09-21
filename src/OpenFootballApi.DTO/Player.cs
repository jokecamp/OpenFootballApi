
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;
using OpenFootballApi.DTO.Interfaces;
using System;
using System.Runtime.Serialization;

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
        public string Lastname { get; set; }
        public string DisplayName { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [IgnoreDataMember]
        public bool Deleted { get; set; }
    }

    [Route("/players")]
    public class GetAllPlayers : IReturn<List<Player>> { }
}
