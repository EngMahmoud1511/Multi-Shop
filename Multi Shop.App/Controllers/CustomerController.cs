using Microsoft.AspNetCore.Mvc;
using Multi_Shop.Data.DTO;
using Multi_Shop.Data.Models;
using Multi_Shop.Repository.Repository;
using Multi_Shop.Service.Services;


namespace Multi_Shop.App
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CustomerController : ControllerBase
    {
        private CustomerService _CustmerService;
        public CustomerController(CustomerService service)
        {
            _CustmerService = service;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_CustmerService.GetAll());    
        }

        
        //[HttpGet("{id}")]
       
        //public IActionResult GetById(int id)
        //{
        //    return Ok(_repository.GetById(id));
        //}

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Add(CustomerDTO customer)
        {
            _CustmerService.Add(customer);
            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public IActionResult Update(CustomerDTO customer,int id)
        {
            var result=_CustmerService.Update(customer, id);
            if (result==null)
                return NotFound("Customer data is not exest");
            else
             return Ok(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_CustmerService.Delete(id))
                return Ok("Item Deleted");
            else 
                return NotFound();
        }
    }
}
