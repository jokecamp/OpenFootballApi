using OpenFootballApi.DTO;
using ServiceStack.ServiceInterface;

namespace OpenFootballApi.Services
{
    public class TagService : Service
    {
        public object Get(Tag request)
        {
            return new Tag {Id = request.Id, Name = "Example Tag"};
        }
    }
}
