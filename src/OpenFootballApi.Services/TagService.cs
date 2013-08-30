using System;
using System.Linq;
using OpenFootballApi.DTO;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;

namespace OpenFootballApi.Services
{
    public class TagService : Service
    {
        public object Get(Tag request)
        {
            var t = Db.QueryById<Tag>(request.Id);

            if (t == null)
                throw new Exception("Tag not found.");

            return t;
        }

        public object Post(Tag request)
        {
            if (request.Id <= 0)
                Db.Insert(request);
            else
                Db.Update(request);

            return request;
        }

        public object Get(AllTags request)
        {
            return Db.Select<Tag>().ToList();
        }
    }
}
