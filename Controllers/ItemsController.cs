using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Models;
using Test_App.Data;
using AutoMapper;
using Test_App.Dtos;
using Microsoft.AspNetCore.JsonPatch;

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

        // POST api/items
        [HttpPost]
        public ActionResult<ItemReadDto> CreateItem(ItemCreateDto itemCreateDto)
        {
            var itemModel = _mapper.Map<Item>(itemCreateDto);
            _repository.CreateItem(itemModel);
            _repository.SaveChanges();

            var itemReadDto = _mapper.Map<ItemReadDto>(itemModel);

            return CreatedAtAction(nameof(GetItem), new { Id = itemReadDto.Id }, itemReadDto);
        }

        // PUT api/items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, ItemUpdateDto itemUpdateDto)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _mapper.Map(itemUpdateDto, existingItem);
            _repository.UpdateItem(existingItem);
            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/items/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateItemPartial(int id, JsonPatchDocument<ItemUpdateDto> patchDoc)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            var itemToPatch = _mapper.Map<ItemUpdateDto>(existingItem);
            patchDoc.ApplyTo(itemToPatch, ModelState);

            if (!TryValidateModel(itemToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(itemToPatch, existingItem);
            _repository.UpdateItem(existingItem);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _repository.DeleteItem(existingItem);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
