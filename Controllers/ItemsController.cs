using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Data;
using Test_App.Models;

namespace Test_App.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Index()
        {
            ItemStoreContext context = HttpContext.RequestServices.GetService(typeof(Test_App.Models.ItemStoreContext)) as ItemStoreContext;

            return View(context.GetAllItems());
        }
    }
}
