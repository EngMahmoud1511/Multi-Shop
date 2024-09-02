using AutoMapper;
using Multi_Shop.Data.DTO;
using Multi_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Shop.Data.Profiles
{
    public class AppProfile:Profile
    {
        public AppProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Item, ItemDTO>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name)).ReverseMap();

               
        }

    }
}
