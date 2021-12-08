using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Models;

namespace Test_App.Data
{
    public class InMemItemsRepo : IItemsRepo
    {

        private readonly List<Item> items = new()
        {
            new Item { Id = 2, Name = "Destiny", ArtistName = "Akon", Price = 15, Genre = "pop" },
            new Item { Id = 1, Name = "MySongs", ArtistName = "Temirlan", Price = 0, Genre = "rock" },
        };
        public IEnumerable<Item> GetAppItems()
        {
            return items;
        }

        public Item GetItemById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
