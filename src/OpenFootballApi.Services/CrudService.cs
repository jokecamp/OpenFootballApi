﻿using OpenFootballApi.DTO.Interfaces;
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
        where TRequest : IWithId<int>, ITimestamped, new()
        where TRequestAllItems : IReturn<List<TRequest>>, new ()
    {
        public virtual List<TRequest> Get(TRequestAllItems request)
        {
            return Db.Select<TRequest>().ToList();
        }

        public virtual object Get(TRequest request)
        {
            var item = Db.QueryById<TRequest>(request.Id);

            if (item == null)
                throw HttpError.NotFound("Item with that id not found.");

            return item;
        }

        public virtual object Post(TRequest request)
        {
            AddTimestamp(request);
            Db.Save<TRequest>(request);
            request.Id = request.Id > 0 ? request.Id : (int)Db.GetLastInsertId();
            return request;
        }

        public virtual void Delete(TRequest request)
        {
            Db.Delete<TRequest>(request);
        }

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