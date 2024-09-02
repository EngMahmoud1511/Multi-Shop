using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Multi_Shop.Data.Data;
using Multi_Shop.Data.DTO;
using Multi_Shop.Data.Models;
using Multi_Shop.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Shop.Service.Services.Sevices.Class
{
    public class ItemService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly ShopContext _context;


        private readonly IMapper mapper;
        public ItemService(IRepository<Item> repository, IMapper mapper, IRepository<Category> categoryRepository, ShopContext context)
        {
            _itemRepository = repository;
            this.mapper = mapper;
           
            _context = context;
        }
        public ICollection<ItemDTO> GetItems() 
        { 
          
          var DtoList=  mapper.Map<List<ItemDTO>>(_itemRepository.GetAllWithInclude(x=>x.Category));
           
            return DtoList;
        }
        public ItemDTO GetById(int id)
        {
            return mapper.Map<ItemDTO>(_itemRepository.GetById(id));
        }
        public bool Add(ItemDTO item)
        {
            if (item != null)
            {
                var itemDb = mapper.Map<Item>(item);
                _itemRepository.Add(itemDb);
                _itemRepository.Save();
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
