
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;
using OpenFootballApi.DTO.Interfaces;
using System;
using System.Runtime.Serialization;

namespace OpenFootballApi.DTO
{
    /// <summary>
    /// A descriptive tag/attribute that will describe mainly players
    /// </summary>
    [Route("/tags/{Id}")]
    [Table]
    public class Tag : IWithId<int>, IReturn<Tag>, ITimestamped, ISoftDelete
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [IgnoreDataMember]
        public bool Deleted { get; set; }
    }

    [Route("/tags")]
    public class AllTags : IReturn<List<Tag>> { }
}
