using OpenFootballApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenFootballApi.Integration.Tests
{
    public class MockDataProvider
    {
        public static Player NewPlayer
        {
            get {
                return new Player()
                {
                    Id = 0,
                    Firstname = "John",
                    Lastname = "Doe"
                };
            }
        }

        public static Player Player1
        {
            get
            {
                return new Player()
                {
                    Id = 1,
                    Firstname = "Jane",
                    Lastname = "Doe"
                };
            }
        }

        public static Tag NewTag
        {
            get { return new Tag { Id = 0, Name = "Integration Tag" }; }
        }

        public static Tag Tag1
        {
            get { return new Tag { Id = 1, Name = "Integration Tag" }; }
        }

        public static PlayerTag NewPlayerTag
        {
            get { return new PlayerTag { TagId = 1, PlayerId=1 }; }
        }

        public static Team NewTeam
        {
            get { return new Team { FullName = "Integration Team", City = "City" }; }
        }
    }
}
