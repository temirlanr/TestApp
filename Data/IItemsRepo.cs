using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Models;

namespace Test_App.Data
{
    public interface IItemsRepo
    {
        IEnumerable<Item> GetAppItems();
        Item GetItemById(int id);
    }
}
