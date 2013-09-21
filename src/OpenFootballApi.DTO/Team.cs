using OpenFootballApi.DTO.Interfaces;
using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace OpenFootballApi.DTO
{
    [Route("/teams/{Id}")]
    [Table]
    public class Team : IWithId<int>, ITimestamped, IReturn<Team>, ISoftDelete
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [IgnoreDataMember]
        public bool Deleted { get; set; }
    }

    [Route("/teams")]
    public class AllTeams : IReturn<List<Team>>
    {
    }
}
