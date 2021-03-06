using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_App.Dtos;
using Test_App.Models;

namespace Test_App.Profiles
{
    public class ItemsProfile : Profile
    {
        public ItemsProfile()
        {
            // Source to Target
            CreateMap<Item, ItemReadDto>();
            CreateMap<ItemCreateDto, Item>();
            CreateMap<ItemUpdateDto, Item>();
            CreateMap<Item, ItemUpdateDto>();
        }
    }
}
