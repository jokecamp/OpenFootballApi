using Funq;
using OpenFootballApi.DTO;
using OpenFootballApi.Services;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface.Cors;
using ServiceStack.WebHost.Endpoints;
using System.Configuration;

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

            var db = container.TryResolve<IDbConnectionFactory>();
            db.Run(x => x.CreateTableIfNotExists<Player>());
            db.Run(x => x.CreateTableIfNotExists<PlayerTag>());
            db.Run(x => x.CreateTableIfNotExists<Tag>());
            db.Run(x => x.CreateTableIfNotExists<Team>());

            /*
            db.Run(x => x.Insert(new Player {  Firstname="first", Lastname="last" }));
            db.Run(x => x.Insert(new PlayerTag { PlayerId = 1, TagId = 1 }));
            db.Run(x => x.Insert(new Tag { Name = "tag" }));
             */
        }
    }
}