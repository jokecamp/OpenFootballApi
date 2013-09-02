using System.Collections.Generic;
using OpenFootballApi.DTO;

namespace OpenFootballApi.Integration.Tests
{
    public class MockData
    {
        public static List<Player> Players
        {
            get { return new List<Player>()
                {
                    new Player() { Firstname = "Joe", Lastname = "Kampschmidt"},
                    new Player() { Firstname = "Ryan", Lastname = "Giggs"},
                    new Player() { Firstname = "Wayne", Lastname = "Rooney"},
                };}
        }

        public static List<Tag>  Tags
        {
            get
            {
                return new List<Tag>()
                    {
                        new Tag() { Name = "Brilliant"},
                        new Tag() { Name = "Lazy"},
                    };
            }
        }
    }
}