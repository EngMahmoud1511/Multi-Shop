using AutoMapper;
using Multi_Shop.Data.DTO;
using Multi_Shop.Data.Models;
using Multi_Shop.Repository.Repository;
using Multi_Shop.Service.Services.Srvices.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Shop.Service.Services.Sevices.Class
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;


        IMapper mapper;
        public CustomerService(IRepository<Customer> repository, IMapper mapper)
        {
            _customerRepository = repository;
            this.mapper = mapper;

        }
        public void Add(CustomerDTO customer)
        {
            _customerRepository.Add(mapper.Map<Customer>(customer));
            _customerRepository.Save();
        }
        public Customer Update(CustomerDTO customer, int id)
        {
            var cust = _customerRepository.GetById(id);
            if (cust != null)
            {
                var Data = mapper.Map<Customer>(customer);
                Data.Id = id;
                _customerRepository.Update(Data);
                return Data;
            }
            return null;
        }
        public bool Delete(int id)
        {
            var cust = _customerRepository.GetById(id);
            if (cust != null)
            {
                _customerRepository.Delete(cust);
                return true;
            }
            return false;
        }


        public ICollection<CustomerDTO> GetAll()
        {
            var List = _customerRepository.GetAll();
            var Customers = mapper.Map<List<CustomerDTO>>(List);

            return Customers;
        }


    }
}
