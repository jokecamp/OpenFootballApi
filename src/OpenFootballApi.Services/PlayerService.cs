using OpenFootballApi.DTO;
using ServiceStack.ServiceInterface;

namespace OpenFootballApi.Services
{
    public class PlayerService : Service
    {
        public object Get(Player request)
        {
            // hard coded player for now
            return new Player() {Id = request.Id, Firstname = "Joe", Lastname = "Kampschmidt"};
        }
    }
}