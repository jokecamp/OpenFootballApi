using OpenFootballApi.DTO.Interfaces;
using ServiceStack.DataAnnotations;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenFootballApi.DTO
{
    [Table]
    [Route("/links/{Id}")]
    public class ItemLink : IWithId<int>, ITimestamped, IReturn<ItemLink>
    {
        [AutoIncrement]
        public int Id { get; set; }

        public int ItemId { get; set; }
        public ItemType ItemType { get; set; }

        public string Name { get; set; }
        public SiteType SiteType { get; set; }
        public DateTime? Date { get; set; }
        public string Info { get; set; }
        public string Href { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }

    public enum SiteType
    {
        Unknown,
        Book,
        Video,
        Article,
        Twitter
    }

    public enum ItemType
    {
        Unknown,
        Player,
        Team,
        League,
        Sport
    }

    [Route("/links")]
    public class GetAllLinks : IReturn<List<ItemLink>>
    {
    }
}
