using NUnit.Framework;
using OpenFootballApi.DTO;
using OpenFootballApi.DTO.Interfaces;
using ServiceStack.Service;
using ServiceStack.ServiceClient.Web;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFootballApi.Integration.Tests
{
    /// <summary>
    /// Depends on the localhost running so do that before running tests.
    /// </summary>
    [TestFixture]
    public class JsonClientTests
    {
        public IRestClient _client;

        public JsonClientTests()
        {
            _client = new JsonServiceClient("http://localhost:30001/api/");

            MockData.Players.ForEach(x => _client.Post(x));
            MockData.Teams.ForEach(x => _client.Post(x));
            MockData.Links.ForEach(x => _client.Post(x));
            MockData.Tags.ForEach(x => _client.Post(x));
        }

        [Test]
        public void Can_GET_AllPlayers()
        {
            var items = _client.Get(new GetAllPlayers());
            items.ForEach(x => Console.Error.WriteLine("name = " + x.Firstname));
            Assert.Greater(items.Count, 0);
        }

        [Test]
        public void Player_CRUD()
        {
            Test_Rest_CRUD.Test<Player>(_client, MockDataProvider.NewPlayer);
        }

        [Test]
        public void Tag_CRUD()
        {
            Test_Rest_CRUD.Test<Tag>(_client, MockDataProvider.NewTag);
        }

        [Test]
        public void PlayerTag_CRUD()
        {
            Test_Rest_CRUD.Test<PlayerTag>(_client, MockDataProvider.NewPlayerTag);
        }

        [Test]
        public void Team_CRUD()
        {
            Test_Rest_CRUD.Test<Team>(_client, MockDataProvider.NewTeam);
        }
    }

    public class Test_Rest_CRUD
    {
        public static void Test<TRequest>(IRestClient client, TRequest request) 
            where TRequest : IWithId<int>, ITimestamped, IReturn<TRequest>, new()
        {
            // New Item
            Assert.AreEqual(request.Id, 0);
            var response = client.Post<TRequest>(request);
            Assert.Greater(response.Id, 0);

            // Update Existing Item
            var response2 = client.Put<TRequest>(response);
            Assert.Greater(response2.Id, 0);
            Assert.Greater(response2.DateModified, response.DateModified);

            // Get
            var getResponse = client.Get(response2);
            Assert.AreEqual(getResponse.Id, response2.Id);

            // Delete
            var deletedReponse = client.Delete<TRequest>(getResponse);
            Assert.IsNull(deletedReponse);
        }
    }
}

