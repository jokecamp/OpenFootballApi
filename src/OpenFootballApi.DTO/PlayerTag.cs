using ServiceStack.DesignPatterns.Model;
using ServiceStack.ServiceHost;

namespace OpenFootballApi.DTO
{
    [Route("/playertags/{Id}")]
    public class PlayerTag : IHasId<int>, IReturn<PlayerTag>
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int TagId { get; set; }
    }
}
