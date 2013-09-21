
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;
using OpenFootballApi.DTO.Interfaces;
using System;

namespace OpenFootballApi.DTO
{
    /// <summary>
    /// Serves as our main Player DOT (model or POCO) and as a request for an indiviual Player.
    /// </summary>
    [Route("/players/{Id}")]
    [Table]
    public class Player : IReturn<Player>, IWithId<int>, ITimestamped
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DisplayName { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    [Route("/players")]
    public class AllPlayers : IReturn<List<Player>> { }
}
