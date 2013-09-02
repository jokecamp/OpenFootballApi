
using System.Collections.Generic;
using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;
using OpenFootballApi.DTO.Interfaces;
using System;

namespace OpenFootballApi.DTO
{
    /// <summary>
    /// A descriptive tag/attribute that will describe mainly players
    /// </summary>
    [Route("/tags/{Id}")]
    public class Tag : IWithId<int>, IReturn<Tag>, ITimestamped
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    [Route("/tags")]
    public class AllTags : IReturn<List<Tag>> { }
}
