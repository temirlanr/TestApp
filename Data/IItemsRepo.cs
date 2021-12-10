using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Models;

namespace Test_App.Data
{
    public interface IItemsRepo
    {
        bool SaveChanges();

        IEnumerable<Item> GetItems();
        Item GetItem(int id);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Item item);
    }
}
