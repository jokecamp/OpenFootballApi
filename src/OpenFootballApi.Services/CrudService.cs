using OpenFootballApi.DTO.Interfaces;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.OrmLite;
using ServiceStack.Common.Web;
using ServiceStack.ServiceHost;

namespace OpenFootballApi.Services
{
    /// <summary>
    /// Most of the services are pretty thin wrappers so we can combine the functionality
    /// into this base class
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TRequestAllItems"></typeparam>
    public abstract class CrudService<TRequest, TRequestAllItems> : Service,
        IGet<TRequest>, IPost<TRequest>, IDeleteVoid<TRequest>, IOptionsVoid<TRequest>
        where TRequest : IWithId<int>, ITimestamped, ISoftDelete, new()
        where TRequestAllItems : IReturn<List<TRequest>>, new ()
    {
        public virtual List<TRequest> Get(TRequestAllItems request)
        {
            return Db.Select<TRequest>().ToList();
        }

        public virtual object Get(TRequest request)
        {
            var item = Db.QueryById<TRequest>(request.Id);

            if (item == null || item.Deleted == true)
                throw HttpError.NotFound("Item with that id not found.");

            return item;
        }

        /// <summary>
        /// Perform anything before PUTs/POSTs
        /// </summary>
        /// <param name="request"></param>
        public virtual void PreSave(TRequest request) { }

        public virtual object Post(TRequest request)
        {
            PreSave(request);
            AddTimestamp(request);
            Db.Save<TRequest>(request);
            request.Id = request.Id > 0 ? request.Id : (int)Db.GetLastInsertId();
            return request;
        }

        public virtual object Put(TRequest request)
        {
            if (request.Id < 0)
                throw new ArgumentException("Id must be greater than zero to save");

            PreSave(request);
            AddTimestamp(request);
            Db.Save<TRequest>(request);
            return request;
        }

        public virtual void Delete(TRequest request)
        {
            request.Deleted = true;
            AddTimestamp(request);
            Db.Update<TRequest>(request);
        }

        /// <summary>
        /// Provide empty Options for enabling CORS
        /// </summary>
        /// <param name="request"></param>
        public virtual void Options(TRequest request) { }

        private void AddTimestamp(TRequest request)
        {
            var now = DateTime.Now;
            request.DateModified = now;

            if (request.Id == 0)
                request.DateCreated = now;
        }
    }
}
