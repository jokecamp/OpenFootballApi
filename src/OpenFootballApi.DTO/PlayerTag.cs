using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;
using OpenFootballApi.DTO.Interfaces;

namespace OpenFootballApi.DTO
{
    [Route("/playertags/{Id}")]
    public class PlayerTag : IWithId<int>, IReturn<PlayerTag>
    {
        [AutoIncrement]
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public int TagId { get; set; }

        /// <summary>
        /// How many times has this player gotten this tag?
        /// </summary>
        public int Count { get; set; }
    }

    [Route("/playertags")]
    public class AllPlayerTags : IReturn<List<PlayerTag>> { }
}
