using Funq;
using OpenFootballApi.DTO;
using OpenFootballApi.Services;
using ServiceStack.OrmLite;
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
            container.Register<IDbConnectionFactory>(new OrmLiteConnectionFactory(":memory:", false, ServiceStack.OrmLite.SqliteDialect.Provider));

            var db = container.TryResolve<IDbConnectionFactory>();
            db.Run(x => x.CreateTableIfNotExists<Player>());
            db.Run(x => x.CreateTableIfNotExists<PlayerTag>());
            db.Run(x => x.CreateTableIfNotExists<Tag>());

            // Setup some test data
            MockData.Players.ForEach(player => db.Run(x => x.Insert(player)));
            MockData.Tags.ForEach(tag => db.Run(x => x.Insert(tag)));
            MockData.Tags.ForEach(tag => db.Run(x => x.Insert(new PlayerTag() { PlayerId = 1, TagId = 1, Count = 1})));
            
        }
    }
}