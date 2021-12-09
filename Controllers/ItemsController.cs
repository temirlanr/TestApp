using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Models;
using Test_App.Data;
using AutoMapper;
using Test_App.Dtos;

namespace Test_App.Controllers
{

    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepo _repository;
        private readonly IMapper _mapper;

        public ItemsController(IItemsRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/items
        [HttpGet]
        public ActionResult<IEnumerable<ItemReadDto>> GetItems()
        {
            var items = _repository.GetItems();

            return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(items));
        }

        // GET api/items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemReadDto> GetItem(int id)
        {
            var item = _repository.GetItem(id);

            if(item != null)
            {
                return Ok(_mapper.Map<ItemReadDto>(item));
            }
            return NotFound();
        }

    }
}
