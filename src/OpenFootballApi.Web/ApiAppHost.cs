using Funq;
using OpenFootballApi.DTO;
using OpenFootballApi.Services;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface.Cors;
using ServiceStack.WebHost.Endpoints;
using System.Configuration;
using System.Linq;

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
            Plugins.Add(new CorsFeature());

            container.Register<IDbConnectionFactory>(
                new OrmLiteConnectionFactory(
                    ConfigurationManager.ConnectionStrings["db"].ConnectionString,
                    false,
                    ServiceStack.OrmLite.SqliteDialect.Provider)
                );

            ConfigureDatabase(container);
        }

        private void ConfigureDatabase(Container container)
        {
            // find all the DTOs we will be storing and ensure the tables exist
            var dtos = TableAttribute.GetTableClasses(typeof(Player).Assembly).Cast<System.Type>().ToArray();
            var db = container.TryResolve<IDbConnectionFactory>();
            db.Run(x => x.CreateTableIfNotExists(dtos));
        }
    }
}