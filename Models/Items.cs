using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_App.Models
{
    public class Items
    {
        private ItemStoreContext context;

        public int Id { get; set; }

        public string Name { get; set; }

        public string ArtistName { get; set; }

        public int Price { get; set; }

        public string Genre { get; set; }
    }
}
