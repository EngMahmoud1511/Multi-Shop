using Microsoft.AspNetCore.Mvc;
using Multi_Shop.Data.Models;
using Multi_Shop.Repository.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Multi_Shop.App
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CustomerController : ControllerBase
    {
        private IRepository<Customer> _repository;
        public CustomerController(IRepository<Customer>repository)
        {
            _repository = repository;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());    
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_repository.GetById(id));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            _repository.Add(customer);
            return Ok();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
