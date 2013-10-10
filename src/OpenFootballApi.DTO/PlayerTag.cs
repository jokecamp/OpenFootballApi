using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;
using OpenFootballApi.DTO.Interfaces;
using System;
using System.Runtime.Serialization;
using OpenFootballApi.DTO.Attributes;

namespace OpenFootballApi.DTO
{
    [Route("/playertags/{Id}")]
    [Table]
    public class PlayerTag : IWithId<int>, IReturn<PlayerTag>, ITimestamped, ISoftDelete
    {
        [AutoIncrement]
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public int TagId { get; set; }

        /// <summary>
        /// Allow users to vote for attributes to voice their opinion
        /// </summary>
        public int Votes { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [IgnoreDataMember]
        public bool Deleted { get; set; }
    }

    [Route("/playertags")]
    public class AllPlayerTags : IReturn<List<PlayerTag>> { }
}
