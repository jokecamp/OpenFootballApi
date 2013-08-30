using NUnit.Framework;
using OpenFootballApi.DTO;
using ServiceStack.Service;
using ServiceStack.ServiceClient.Web;
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
            Assert.Greater(_client.Get(new AllPlayers()).Count, 0);
        }

        [Test]
        public void Can_POST_NewPlayer()
        {
            var p = _client.Post(new Player { Firstname = "Testy", Lastname = "Tester" });
            Assert.Greater(p.Id, 0);
        }

        [Test]
        public void Can_POST_ExistingPlayer()
        {
            var p = _client.Post(new Player { Id = 1, Firstname = "Testy", Lastname = "Tester" });
            Assert.Greater(p.Id, 0);
        }

        [Test]
        public void Can_DELETE_Player()
        {
            var p = _client.Delete(new Player { Id = 2 });
            Assert.IsNull(p);

            Assert.Throws(typeof(WebServiceException), new TestDelegate(MethodThatThrows));
        }

        private void MethodThatThrows()
        {
            _client.Get(new Player { Id = 2 });
        }

    }
}
