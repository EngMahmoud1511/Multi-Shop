using Multi_Shop.Data.DTO;
using Multi_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multi_Shop.Service.Services.Srvices.Interfase
{
    public interface ICustomerService
    {
        void Add(CustomerDTO customer);
        Customer Update(CustomerDTO customer, int id);
        ICollection<CustomerDTO> GetAll();
        bool Delete(int id);

    }
}
