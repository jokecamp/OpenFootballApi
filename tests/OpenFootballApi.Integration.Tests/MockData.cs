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
                    new Player {  Firstname="David", Lastname="Beckham" },
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

        public static List<Team> Teams
        {
            get
            {
                return new List<Team>() {
                    new Team { City = "London", FullName = "Arsenal Gunners" }
            };
            }
        }

        public static List<ItemLink> Links
        {
            get
            {
                return new List<ItemLink>() {
                    new ItemLink
                    {
                        ItemId = 1,
                        ItemType = ItemType.Player,

                        Name = "Beckham: Both Feet on the Ground: An Autobiography",
                        Info =  "By David Beckham and Tom Watt",
                        SiteType = DTO.SiteType.Book,
                        Href = "http://www.amazon.com/Beckham-ebook/dp/B000FC10RU/ref=sr_1_1?s=books&ie=UTF8&qid=1379783469&sr=1-1&keywords=beckham",
                        Date = new System.DateTime(2004, 11, 2)  
                    },
                    new ItemLink
                    {
                        ItemId = 1,
                        ItemType = ItemType.Team,
                        Name = "Fever Pitch",
                        Info = "By Nick Hornby",
                        SiteType = DTO.SiteType.Book,
                        Href = "http://www.amazon.com/Fever-Pitch-Nick-Hornby/dp/1573226882",
                        Date = new System.DateTime(1998, 3, 1)
                    }
                };
            }
        }
    }
}