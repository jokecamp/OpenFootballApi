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
    }
}
