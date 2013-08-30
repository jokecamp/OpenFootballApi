
using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;

namespace OpenFootballApi.DTO
{
    /// <summary>
    /// A descriptive tag/attribute that will describe mainly players
    /// </summary>
    [Route("/tags/{Id}")]
    public class Tag : IHasId<int>, IReturn<Tag>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
