using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenFootballApi.DTO.Interfaces
{
    public interface ITimestamped
    {
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
    }
}
