
using ServiceStack.ServiceHost;

namespace OpenFootballApi.DTO
{
    /// <summary>
    /// Serves as our main Player DOT (model or POCO) and as a request for an indiviual Player.
    /// </summary>
    [Route("/players/{Id}")]
    public class Player : IReturn<Player>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
