using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Models;

namespace Test_App.Data
{
    public class ItemsContext : DbContext
    {
        public ItemsContext(DbContextOptions<ItemsContext> opt) : base(opt)
        {

        }

        public DbSet<Item> Items { set; get; }
    }
}
