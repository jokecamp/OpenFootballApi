using NUnit.Framework;
using OpenFootballApi.DTO;
using OpenFootballApi.DTO.Interfaces;
using ServiceStack.Service;
using ServiceStack.ServiceClient.Web;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
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
        private IRestClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new JsonServiceClient("http://localhost:30001/api/");
        }

        [Test]
        public void Can_GET_AllPlayers()
        {
            _client.Post(new Player());
            _client.Post(new Player());
            Assert.Greater(_client.Get(new AllPlayers()).Count, 1);
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
            where TRequest : IWithId<int>, IReturn<TRequest>, new()
        {
            // New Item
            Assert.AreEqual(request.Id, 0);
            var response = client.Post<TRequest>(request);
            Assert.Greater(response.Id, 0);

            // Update Existing Item
            var response2 = client.Post<TRequest>(response);
            Assert.Greater(response2.Id, 0);

            // Get
            var getResponse = client.Get(response2);
            Assert.AreEqual(getResponse.Id, response2.Id);

            // Delete
            var deletedReponse = client.Delete<TRequest>(getResponse);
            Assert.IsNull(deletedReponse);
        }
    }
}

