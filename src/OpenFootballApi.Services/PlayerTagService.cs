using OpenFootballApi.DTO;
using ServiceStack.ServiceInterface;

namespace OpenFootballApi.Services
{
    public class PlayerTagService : Service
    {
        public object Get(PlayerTag request)
        {
            return new PlayerTag {Id = request.Id, PlayerId = 1, TagId = 1};
        }
    }
}
