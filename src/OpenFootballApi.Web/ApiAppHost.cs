using Funq;
using OpenFootballApi.Services;
using ServiceStack.WebHost.Endpoints;

namespace OpenFootballApi.Web
{
    public class ApiAppHost : AppHostBase
    {
        /// <summary>
        /// Initializes a new instance of your ServiceStack application, with the specified name and assembly containing the services.
        /// </summary>
        public ApiAppHost() : base("OpenFootballApi", typeof(PlayerService).Assembly) { }

        /// <summary>
        /// Configure the container with the necessary routes for your ServiceStack application.
        /// </summary>
        /// <param name="container">The built-in IoC used with ServiceStack.</param>
        public override void Configure(Container container)
        {
        }
    }
}