using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenFootballApi.DTO
{
    [Route("/report")]
    public class PlayerReport : IReturn<List<PlayerReport>>
    {
        public Player Player { get; set; }
        public List<PlayerTagReport> Tags { get; set; }
    }

    /// <summary>
    /// Reporting object to return both DTOs together
    /// </summary>
    public class PlayerTagReport
    {
        public PlayerTag PlayerTag { get; set; }
        public Tag Tag { get; set; }
    }
}
