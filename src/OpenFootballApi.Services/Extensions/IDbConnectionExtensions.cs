﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ServiceStack.OrmLite;
using OpenFootballApi.DTO.Interfaces;

namespace OpenFootballApi.Services.Extensions
{
    public static class IDbConnectionExtensions
    {
        /// <summary>
        /// Inserts and populates the request with the new Id
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="db"></param>
        /// <param name="request"></param>
        public static void InsertAndGetIntId<TRequest>(this IDbConnection db, TRequest request)
            where TRequest : IWithId<int>, new()
        {
            db.Insert<TRequest>(request);
            request.Id = (int)db.GetLastInsertId();
        }

        /// <summary>
        /// Either inserts or updates record base on if there is a valid id.
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="db"></param>
        /// <param name="request"></param>
        public static void SaveAndGetIntId<TRequest>(this IDbConnection db, TRequest request)
            where TRequest : IWithId<int>, new()
        {
            if (request.Id <= 0)
            {
                db.InsertAndGetIntId<TRequest>(request);
            }
            else
            {
                db.Update(request);
            }
        }
    }
}
