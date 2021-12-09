using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Models;

namespace Test_App.Data
{
    public class SqlItemsRepo : IItemsRepo
    {

        private readonly ItemsContext _context;

        public SqlItemsRepo(ItemsContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItem(int id)
        {
            return _context.Items.FirstOrDefault(i => i.Id == id);
        }
    }
}
