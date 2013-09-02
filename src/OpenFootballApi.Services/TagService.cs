using System;
using System.Linq;
using OpenFootballApi.DTO;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using OpenFootballApi.Services.Extensions;

namespace OpenFootballApi.Services
{
    public class TagService : CrudService<Tag, AllTags>
    {
    }
}
