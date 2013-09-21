using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenFootballApi.DTO.Interfaces
{
    /// <summary>
    /// Deleted records will not be served via the API but will remain in the data store
    /// </summary>
    public interface ISoftDelete
    {   
        bool Deleted { get; set; }
    }
}
