using System;
using System.Linq;
using OpenFootballApi.DTO;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using OpenFootballApi.Services.Extensions;
using ServiceStack.ServiceHost;

namespace OpenFootballApi.Services
{
    public class PlayerTagService : CrudService<PlayerTag, AllPlayerTags>
    {
    }
}
