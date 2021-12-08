using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Models;
using Test_App.Data;

namespace Test_App.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsApiController : ControllerBase
    {
        private readonly InMemItemsRepo _repository = new();

        // GET api/items
        [HttpGet]
        public ActionResult<IEnumerable<Item>> ApiGetAllItems()
        {
            var items = _repository.GetAppItems();

            return Ok(items);
        }

        // GET api/items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> ApiGetItemById(int id)
        {
            var item = _repository.GetItemById(id);

            return Ok(item);
        }

    }
}
