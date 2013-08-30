using ServiceStack.DesignPatterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenFootballApi.DTO.Interfaces
{
    /// <summary>
    /// Created this because I also need the "set" method
    /// </summary>
    public interface IWithId<T> : IHasId<T>
    {
        T Id { get; set; }
    }
}
